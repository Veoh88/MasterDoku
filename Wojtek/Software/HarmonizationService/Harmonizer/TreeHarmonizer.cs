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
        public WasteWaterTreatmentPlant HarmonizeTree(TreeFormattedObject treeObject, int? waterPlantId = null, int? treatmentStepType = null)
        {
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

            dynamic mappingResult = null;
            if (_aliasNameToRealNameDict != null)
            {
                 mappingResult = MapWaterPlantAliases(treeObject.Object);
            }

            var dynamicDict = mappingResult == null ?
                JsonConvert.DeserializeObject <Dictionary<dynamic, string>>(treeObject.Object) :
                JsonConvert.DeserializeObject<Dictionary<dynamic, string>>(mappingResult);


        }

        #region Private Methods
        private Dictionary<string, dynamic> MapWaterPlantAliases(Dictionary<string, dynamic> dynamicObject)
        {
            var cleanedResult = new Dictionary<string, dynamic>();

            foreach (var key in dynamicObject.Keys)
            {
                //remove every keyvalue where the key is blacklisted
                if (_aliasNameToRealNameDict.Keys.Contains(key)) continue;

                //if the value is another json also check that json
                if (dynamicObject[key] is string && IsJson(dynamicObject[key]))
                {
                    var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dynamicObject[key]);
                    var subResult = MapWaterPlantAliases(jsonObject);
                    cleanedResult.Add(key, subResult);
                    continue;
                }
                cleanedResult.Add(key, dynamicObject[key]);
            }

            return cleanedResult;
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
