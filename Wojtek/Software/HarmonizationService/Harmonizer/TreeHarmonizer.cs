using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccessor;
using Interfaces;
using Library.ConvertedObjects;
using Library.HarmonizedObjects;
using Library.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Harmonizer
{
    public class TreeHarmonizer : ITreeHarmonizer
    {
        #region Private Members

        private IUtilityDbAccessor _utilityDbAccessor;
        private IDataBaseViewAccessor _dbAccessor;
        private Dictionary<string, string> _aliasNameToRealNameDict = null;

        #endregion

        #region Constructors

        public TreeHarmonizer()
        {
            _utilityDbAccessor = new UtilityDbAccessor();
            _dbAccessor = new DbViewAccessor();
        }

        #endregion
        public WasteWaterTreatmentPlant HarmonizeTree(TreeFormattedObject treeObject, int? waterPlantId = null, int? treatmentStepTypeId = null)
        {
            WasteWaterTreatmentPlant wwtp;
            // if the object was conform to the predefined schema all along, just convert, map and return it
            if (treeObject.IsPredefinedSchema)
            {
                var wwtpObject = treeObject.Object as WasteWaterTreatmentPlant;
                _aliasNameToRealNameDict = waterPlantId != null ? 
                    _utilityDbAccessor.GetAliasToRealNameOnWwtpDict((int)waterPlantId):
                    _utilityDbAccessor.GetAliasToRealNameOnWwtpDict(_utilityDbAccessor.GetIdForWwtpName(wwtpObject?.Name));
                foreach (var treatmentStep in wwtpObject.TreatmentSteps)
                {
                    treatmentStep.QualityIndicators = MapWaterPlantAliases(treatmentStep.QualityIndicators);
                }
                return wwtpObject;
            }
            // ... otherwise first replace the single valeus by waterplant aliases and then try to convert it
            // if that does not work, the object is not valid

            // we can only map if waterPlantId is passed as parameter or can be read from the treeobject
            if (waterPlantId != null && _aliasNameToRealNameDict != null)
                _aliasNameToRealNameDict = _utilityDbAccessor.GetAliasToRealNameOnWwtpDict((int)waterPlantId);
            else
            {
                try
                {
                    var wwtpAsObject = ((JObject)treeObject.Object).ToObject<WasteWaterTreatmentPlant>();
                    var name = wwtpAsObject.Name;
                    if (!string.IsNullOrEmpty(name))
                    {
                        waterPlantId = waterPlantId ?? _utilityDbAccessor.GetIdForWwtpName(name);
                        _aliasNameToRealNameDict = _utilityDbAccessor.GetAliasToRealNameOnWwtpDict((int)waterPlantId);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Name & Id of Wwtp missing");
                }
            }

            // map the dynamic object
            dynamic mappingResult = null;
            if (_aliasNameToRealNameDict != null && _aliasNameToRealNameDict.Any())
            {
                var dynamicJsonDict = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(treeObject.Object.ToString());
                mappingResult = MapWaterPlantAliases(dynamicJsonDict);

                // convert mapping result back into the correct format
                ExpandoObject expandoObject = ((Dictionary<string, dynamic>)mappingResult).ToExpando();
                var serializedExpandoObject = JsonConvert.SerializeObject(expandoObject);
                mappingResult = JsonConvert.DeserializeObject<dynamic>(serializedExpandoObject);
            }

            // even if the mapping wasnt successful, we still might have a valid waterplant object
            // last try to deserialize it and checks if everything is correct afterwars
            var dynamicDict = mappingResult == null ? treeObject.Object : mappingResult;

            //<<DESERIALIZATION CHECKS>>
            //try to deserialuze the wwtp as a whole first
            if (IsWholeWwtp(dynamicDict, out wwtp))
            {
                foreach (var treatmentStep in wwtp.TreatmentSteps)
                {
                    treatmentStep.QualityIndicators = MapWaterPlantAliases(treatmentStep.QualityIndicators);
                }
                return wwtp;
            }

            //if this didnt work, check if its an option to only deserialize parts of the wwtp
            //treatment step list
            if (waterPlantId != null && IsTreatmentSteps(dynamicDict, out wwtp))
            {
                wwtp.Name = _utilityDbAccessor.GetWwtpNameForId((int)waterPlantId);
                foreach (var treatmentStep in wwtp.TreatmentSteps)
                {
                    treatmentStep.QualityIndicators = MapWaterPlantAliases(treatmentStep.QualityIndicators);
                }
                return wwtp;
            }

            //qualityIndicators
            if (waterPlantId != null && treatmentStepTypeId != null && IsQualityIndicators(dynamicDict, out wwtp))
            {
                wwtp.Name = _utilityDbAccessor.GetWwtpNameForId((int)waterPlantId);
                wwtp.TreatmentSteps.FirstOrDefault().Name = _utilityDbAccessor.GetTreatmentTypeForId((int)treatmentStepTypeId);
                foreach (var treatmentStep in wwtp.TreatmentSteps)
                {
                    treatmentStep.QualityIndicators = MapWaterPlantAliases(treatmentStep.QualityIndicators);
                }
                return wwtp;
            }

            //if nothing worked so far - last try is to check if its a qualityindicatorlist that is directly assigned to the waterplant
            if (waterPlantId != null && IsQualityIndicators(dynamicDict, out wwtp, true))
            {
                wwtp.Name = _utilityDbAccessor.GetWwtpNameForId((int)waterPlantId);
                foreach (var treatmentStep in wwtp.TreatmentSteps)
                {
                    treatmentStep.QualityIndicators = MapWaterPlantAliases(treatmentStep.QualityIndicators);
                }
                return wwtp;
            }

            throw new Exception("Could not harmonize the dynamicObject");

        }

        #region Private Methods

        private bool IsWholeWwtp(dynamic dynamicObject, out WasteWaterTreatmentPlant wwtp)
        {
            try
            {
                var isCorrect = true;
                wwtp = JsonConvert.DeserializeObject<WasteWaterTreatmentPlant>(dynamicObject.ToString());

                // checks if the wwtp is correct
                if (wwtp == null)
                    isCorrect = false;

                else if (wwtp.GeneralIndicators == null && 
                         (wwtp.TreatmentSteps == null  || (wwtp.TreatmentSteps.Any() && wwtp.TreatmentSteps.First().QualityIndicators == null)))
                {
                    isCorrect = false;
                }

                return isCorrect;
            }
            catch (Exception e)
            {
                wwtp = null;
                return false;
            }
        }

        private bool IsTreatmentSteps(dynamic dynamicObject, out WasteWaterTreatmentPlant wwtp)
        {
            var isCorrect = true;
            wwtp = new WasteWaterTreatmentPlant();

            try
            {
                var treatmentStepList = (List<WaterTreatmentStep>)JsonConvert.DeserializeObject<List<WaterTreatmentStep>>(dynamicObject.ToString());

                // checks if list is correct
                if (treatmentStepList == null || !treatmentStepList.Any())
                    isCorrect = false;

                else if (treatmentStepList.FirstOrDefault().QualityIndicators == null ||
                         !treatmentStepList.FirstOrDefault().QualityIndicators.Any())
                {
                    isCorrect = false;
                }

                wwtp.TreatmentSteps = treatmentStepList;

                if (isCorrect)
                    return true;
                
            }
            catch (Exception e)
            {
                
            }

            try
            {
                var treatmentStep = (WaterTreatmentStep)JsonConvert.DeserializeObject<WaterTreatmentStep>(dynamicObject.ToString());

                // checks if treatmentstep is correct
                if (treatmentStep.QualityIndicators == null ||
                    !treatmentStep.QualityIndicators.Any())
                {
                    throw new Exception("invalid treatmentStep");
                }

                if (wwtp == null)
                {
                    wwtp = new WasteWaterTreatmentPlant()
                    {
                        TreatmentSteps = new List<WaterTreatmentStep>()
                    };
                }
                else if (wwtp.TreatmentSteps == null || !wwtp.TreatmentSteps.Any())
                {
                    wwtp.TreatmentSteps = new List<WaterTreatmentStep>();
                }
                wwtp.TreatmentSteps.Add(treatmentStep);

                return true;
            }
            catch (Exception e)
            {
                wwtp = null;
                return false;
            }

        }

        private bool IsQualityIndicators(dynamic dynamicObject, out WasteWaterTreatmentPlant wwtp, bool assignToWwtp = false)
        {
            var isCorrect = true;
            wwtp = new WasteWaterTreatmentPlant();

            try
            {
                var qualityIndicatorList =
                    (List<WaterQualityIndicator>) JsonConvert.DeserializeObject<List<WaterQualityIndicator>>(dynamicObject.ToString());

                // checks if list is correct
                if (qualityIndicatorList == null || !qualityIndicatorList.Any())
                    isCorrect = false;

                if (assignToWwtp)
                {
                    wwtp.GeneralIndicators = qualityIndicatorList;
                }
                else
                {
                    wwtp.TreatmentSteps = new List<WaterTreatmentStep>
                    {
                        new WaterTreatmentStep()
                        {
                            QualityIndicators = qualityIndicatorList
                        }
                    };
                }
                
                if (isCorrect)
                    return true;
            }
            catch (Exception e)
            {
                
            }

            try
            {
                var qualityIndicator =
                    (WaterQualityIndicator)JsonConvert.DeserializeObject<WaterQualityIndicator>(dynamicObject.ToString());

                if (string.IsNullOrEmpty(qualityIndicator.Name) ||
                    qualityIndicator.TimeStamp == default(DateTime) ||
                    string.IsNullOrEmpty(qualityIndicator.Unit))
                {
                    throw new Exception("not valid qualityindentifier");
                }

                if (assignToWwtp)
                {
                    if (wwtp.GeneralIndicators == null)
                    {
                        wwtp.GeneralIndicators = new List<WaterQualityIndicator>();
                    }
                    wwtp.GeneralIndicators.Add(qualityIndicator);
                }
                else
                {
                    if (wwtp.TreatmentSteps == null)
                    {
                        wwtp.TreatmentSteps = new List<WaterTreatmentStep>
                        {
                            new WaterTreatmentStep()
                        };
                    }

                    if (wwtp.TreatmentSteps.First().QualityIndicators == null)
                    {
                        wwtp.TreatmentSteps.First().QualityIndicators = new List<WaterQualityIndicator>();
                    }

                    wwtp.TreatmentSteps.First().QualityIndicators.Add(qualityIndicator);
                }

                return true;
            }
            catch (Exception e)
            {
                wwtp = null;
                return false;
            }
        }

        private List<WaterQualityIndicator> MapWaterPlantAliases(List<WaterQualityIndicator> qualityIndicators)
        {
            var mappedList = new List<WaterQualityIndicator>();
            var indicatorAliasesFromDb = _dbAccessor.GetQualityIndicatorTypeMappings().Select(x => x.indicatorAlias).ToList();

            foreach (var qualityIndicator in qualityIndicators)
            {
                var mappedQualityIndicator = qualityIndicator;

                if (_aliasNameToRealNameDict.Keys.Contains(qualityIndicator.Name))
                {
                    mappedQualityIndicator.Name = _aliasNameToRealNameDict[qualityIndicator.Name];
                }
                else if (indicatorAliasesFromDb.Contains(qualityIndicator.Name))
                {
                    mappedQualityIndicator.Name = _utilityDbAccessor.GetIndicatorForAlias(qualityIndicator.Name);
                }

                mappedList.Add(mappedQualityIndicator);
            }

            return mappedList;
        }
        private dynamic MapWaterPlantAliases(Dictionary<string, dynamic> dynamicObject)
        {
            var mappedResult = new Dictionary<string, object>();

            foreach (var key in dynamicObject.Keys)
            {
                var currentValue = dynamicObject[key];
                //if the value is another json also check that json
                if (dynamicObject[key] is string && IsJson(dynamicObject[key]))
                {
                    var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dynamicObject[key].ToString());
                    currentValue = MapWaterPlantAliases(jsonObject);
                }
                //map values
                if (_aliasNameToRealNameDict.Keys.Contains(key))
                {
                    mappedResult.Add(_aliasNameToRealNameDict[key], currentValue);
                }
                else
                {
                    mappedResult.Add(key, currentValue);
                }
            }

            return mappedResult;
        }

        #endregion

        #region Helpers
        private bool IsJson(string treeStringObject)
        {
            treeStringObject = treeStringObject.Trim();
            if (treeStringObject.StartsWith("{") && treeStringObject.EndsWith("}"))
            {
                try
                {
                    var obj = JToken.Parse(treeStringObject);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Debug.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }
        #endregion
    }
}
