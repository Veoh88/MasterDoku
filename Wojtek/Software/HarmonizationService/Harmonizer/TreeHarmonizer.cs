using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccessor;
using Interfaces;
using Library.ConvertedObjects;
using Library.HarmonizedObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Harmonizer
{
    public class TreeHarmonizer : ITreeHarmonizer
    {
        #region Private Members

        private IUtilityDbAccessor _utilityDbAccessor;
        private Dictionary<string, string> _aliasNameToRealNameDict = null;

        #endregion

        #region

        public TreeHarmonizer()
        {
            _utilityDbAccessor = new UtilityDbAccessor();
        }
        #endregion
        public WasteWaterTreatmentPlant HarmonizeTree(TreeFormattedObject treeObject, int? waterPlantId = null, int? treatmentStepTypeId = null)
        {
            WasteWaterTreatmentPlant wwtp;
            // if the object was conform to the predefined schema all along, just convert and return it
            if (treeObject.IsPredefinedSchema)
            {
                return JsonConvert.DeserializeObject<WasteWaterTreatmentPlant>(treeObject.Object);
            }
            // ... otherwise first replace the single valeus by waterplant aliases and then try to convert it
            // if that does not work, the object is not valid

            // we can only map if waterPlantId is passed as parameter or can be read from the treeobject
            if (waterPlantId != null)
                _aliasNameToRealNameDict = _utilityDbAccessor.GetAliasToRealNameOnWwtpDict((int)waterPlantId);
            else
            {
                var attemptedWaterPlantName = ((WasteWaterTreatmentPlant)JsonConvert.DeserializeObject<WasteWaterTreatmentPlant>(treeObject.Object)).Name;
                if (!string.IsNullOrEmpty(attemptedWaterPlantName))
                {
                    waterPlantId = _utilityDbAccessor.GetIdForWwtpName(attemptedWaterPlantName);
                    _aliasNameToRealNameDict = _utilityDbAccessor.GetAliasToRealNameOnWwtpDict((int)waterPlantId);
                }
            }

            // map the dynamic object
            dynamic mappingResult = null;
            if (_aliasNameToRealNameDict != null)
            {
                 mappingResult = MapWaterPlantAliases(treeObject.Object);
            }

            // even if the mapping wasnt successful, we still might have a valid waterplant object
            // last try to deserialize it and checks if everything is correct afterwars
            //TODO vllt sind nur qualityindicators übergeben oder nur die treatmentsteps ohne pflanze drüber
            var dynamicDict = mappingResult == null ?
                JsonConvert.DeserializeObject<Dictionary<dynamic, string>>(treeObject.Object) :
                JsonConvert.DeserializeObject<Dictionary<dynamic, string>>(mappingResult);

            //<<DESERIALIZATION CHECKS>>
            //try to deserialuze the wwtp as a whole first
            if (IsWholeWwtp(dynamicDict, out wwtp))
            {
                return wwtp;
            }

            //if this didnt work, check if its an option to only deserialize parts of the wwtp
            //treatment step list
            if (waterPlantId != null && IsTreatmentSteps(dynamicDict, out wwtp))
            {
                wwtp.Name = _utilityDbAccessor.GetWwtpNameForId((int)waterPlantId);
                return wwtp;
            }

            //qualityIndicators
            if (waterPlantId != null && treatmentStepTypeId != null && IsQualityIndicators(dynamicDict, out wwtp))
            {
                wwtp.Name = _utilityDbAccessor.GetWwtpNameForId((int)waterPlantId);
                wwtp.TreatmentSteps.FirstOrDefault().Name = _utilityDbAccessor.GetTreatmentTypeForId((int)treatmentStepTypeId);
                return wwtp;
            }

            //if nothing worked so far - last try is to check if its a qualityindicatorlist that is directly assigned to the waterplant
            // -> which might actually lead to inconsistent data
            if (waterPlantId != null && IsQualityIndicators(dynamicDict, out wwtp))
            {
                wwtp.Name = _utilityDbAccessor.GetWwtpNameForId((int)waterPlantId);
                return wwtp;
            }

            throw new Exception("Could not harmonize the dynamicObject"); //TODO handle this better

        }

        #region Private Methods

        private bool IsWholeWwtp(dynamic dynamicObject, out WasteWaterTreatmentPlant wwtp)
        {
            var isCorrect = true;
            wwtp = (WasteWaterTreatmentPlant)JsonConvert.DeserializeObject<WasteWaterTreatmentPlant>(dynamicObject);

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

        private bool IsTreatmentSteps(dynamic dynamicObject, out WasteWaterTreatmentPlant wwtp)
        {
            var isCorrect = true;
            wwtp = new WasteWaterTreatmentPlant();

            var treatmentStepList = (List<WaterTreatmentStep>)JsonConvert.DeserializeObject<List<WaterTreatmentStep>>(dynamicObject);

            // checks if list is correct
            if (treatmentStepList == null || !treatmentStepList.Any())
                isCorrect = false;

            else if (treatmentStepList.FirstOrDefault().QualityIndicators == null ||
                !treatmentStepList.FirstOrDefault().QualityIndicators.Any())
            {
                isCorrect = false;
            }

            wwtp.TreatmentSteps = treatmentStepList;

            return isCorrect;
        }

        private bool IsQualityIndicators(dynamic dynamicObject, out WasteWaterTreatmentPlant wwtp)
        {
            var isCorrect = true;

            wwtp = new WasteWaterTreatmentPlant();

            var qualityIndicatorList =
                (List<WaterQualityIndicator>) JsonConvert.DeserializeObject<List<WaterQualityIndicator>>(dynamicObject);

            // checks if list is correct
            if (qualityIndicatorList == null || !qualityIndicatorList.Any())
                isCorrect = false;

            wwtp.TreatmentSteps = new List<WaterTreatmentStep>
            {
                new WaterTreatmentStep()
                {
                    QualityIndicators = qualityIndicatorList
                }
            };

            return isCorrect;
        }

        private Dictionary<string, dynamic> MapWaterPlantAliases(Dictionary<string, dynamic> dynamicObject)
        {
            var mappedResult = new Dictionary<string, dynamic>();

            foreach (var key in dynamicObject.Keys)
            {
                var currentValue = dynamicObject[key];
                //if the value is another json also check that json
                if (dynamicObject[key] is string && IsJson(dynamicObject[key]))
                {
                    var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dynamicObject[key]);
                    currentValue = MapWaterPlantAliases(jsonObject);
                }
                //map values
                if (_aliasNameToRealNameDict.Keys.Contains(key))
                {
                    mappedResult.Add(_aliasNameToRealNameDict[key], currentValue[key]);
                }
                else
                {
                    mappedResult.Add(key, currentValue[key]);
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
