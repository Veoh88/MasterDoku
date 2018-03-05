﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccessor;
using Interfaces;
using Library.ConvertedObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PreSimplificator
{
    public class PreSimplificator : IPreSimplificator
    {
        private IDataBaseViewAccessor _dataBaseAccessor;
        private List<string> _blackList;


        public PreSimplificator()
        {
            _dataBaseAccessor = new DbViewAccessor();
            _blackList = _dataBaseAccessor.GetBlackList().Select(x=>x.propertyName).ToList();
        }
        public TableFormattedObject PreSimplyfyTableObject(TableFormattedObject tableObject)
        {
            //look for columns which are not numeric or datetimes and not in the title
            var listWithEmptyColumns = new List<int>();

            //find empty columns
            for (int i = 0; i < tableObject.Cells[0].Count; i++)
            {
                var currentCell = tableObject.Cells[0][i];
                if (string.IsNullOrEmpty(currentCell))
                {
                    listWithEmptyColumns.Add(i);
                }
            }

            Debug.WriteLine($"Removed  {listWithEmptyColumns.Count} empty columns from the dataset");
            Console.Write("The removed column indexes: ");
            listWithEmptyColumns.ForEach(x => Console.Write(x + "; "));
            Debug.WriteLine("");

            return tableObject;
        }

        public TreeFormattedObject PreSimplyfyJsonObject(TreeFormattedObject treeObject)
        {
            if (treeObject.IsPredefinedSchema)
            {
                Debug.WriteLine("The object is already in the recommended common schema and does no require any simplification");
                return treeObject;
            }

            Dictionary<string, dynamic> dynamicObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(treeObject.Object.ToString());

            RemoveBlacklistedKeys(dynamicObject);

            return treeObject;
        }

        #region Private Methods

        private Dictionary<string, dynamic> RemoveBlacklistedKeys(Dictionary<string, dynamic> dynamicObject)
        {
            var cleanedResult = new Dictionary<string, dynamic>();

            foreach (var key in dynamicObject.Keys)
            {
                //remove every keyvalue where the key is blacklisted
                if (_blackList.Contains(key)) continue;

                //if the value is another json also check that json
                if (dynamicObject[key] is string && IsJson(dynamicObject[key]))
                {
                    var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dynamicObject[key]);
                    var subResult = RemoveBlacklistedKeys(jsonObject);
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
