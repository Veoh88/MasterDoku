using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DataBaseAccessor;
using HarmonizationService.BusinessLogic;
using Library.HarmonizationApi;
using Library.HarmonizedObjects;

namespace HarmonizationService.Pull
{
    public class DataPuller : IDataPuller
    {
        #region

        private IDataBaseViewAccessor _dbAccessor;
        private IBusinessLogic _businessLogic;
        private IUtilityDbAccessor _utilityDbAccessor;

        private const int PULLFREQUENCY_SECONDS = 1;
        #endregion
        
        
        #region Constructors

        public DataPuller()
        {
            _utilityDbAccessor = new UtilityDbAccessor();
            _dbAccessor = new DbViewAccessor();
            _businessLogic = new BusinessLogic.BusinessLogic();
        }
        #endregion

        #region Interface Methods
        /// <summary>
        /// This method must be started in the background
        /// </summary>
        public void StartPulling()
        {
            while (true)
            {
                var pullSources = _dbAccessor.GetPullSources().ToList();

                foreach (var pullSource in pullSources)
                {
                    try
                    {
                        WasteWaterTreatmentPlant wwtp = null;
                        if (pullSource.dataType.ToLower() == FileFormat.CSV.ToString().ToLower() || pullSource.dataType == FileFormat.XLS.ToString().ToLower())
                        {
                            var waterPlant = _utilityDbAccessor.GetWwtpNameForId((int)pullSource.waterPlantId);
                            var treatmentStepType = _utilityDbAccessor.GetWwtpNameForId((int)pullSource.treatmentStepTypeId);

                            foreach (var file in Directory.GetFiles(pullSource.sourcePath))
                            {
                                if (file.StartsWith("_")) continue; // ignore files starting with _
                                using (FileStream stream = File.Open(Path.Combine(pullSource.sourcePath, file), FileMode.Open))
                                {
                                    wwtp = _businessLogic.HarmonizeData(stream, (FileFormat)Enum.Parse(typeof(FileFormat), pullSource.dataType), waterPlant, treatmentStepType);
                                }
                            }

                        }
                        else if (pullSource.dataType.ToLower() == FileFormat.JSON.ToString().ToLower())
                        {
                            var waterPlant = pullSource.waterPlantId == null ? "" : _utilityDbAccessor.GetWwtpNameForId((int)pullSource.waterPlantId);
                            var treatmentStepType = pullSource.treatmentStepTypeId == null ? "" : _utilityDbAccessor.GetWwtpNameForId((int)pullSource.treatmentStepTypeId);

                            foreach (var file in Directory.GetFiles(pullSource.sourcePath))
                            {
                                if (file.StartsWith("_")) continue; // ignore files starting with _

                                var json = File.ReadAllText(Path.Combine(pullSource.sourcePath, file));
                                wwtp = _businessLogic.HarmonizeData(json, waterPlant, treatmentStepType);
                            }
                        }

                        //file processed without errors - rename the file
                        var fileName = Path.GetFileName(pullSource.sourcePath);
                        var directory = Path.GetDirectoryName(pullSource.sourcePath);
                        File.Move(Path.Combine(directory, fileName), Path.Combine(directory, $"_{fileName}"));

                        Debug.WriteLine("-- WaterPlant just got harmonized!: \n" + wwtp);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }
                }

                Task.Delay(PULLFREQUENCY_SECONDS * 1000);
            }
        }
        #endregion
    }
}