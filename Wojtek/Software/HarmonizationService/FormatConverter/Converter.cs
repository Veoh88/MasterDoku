using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Library.ConvertedObjects;
using Library.HarmonizedObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace FormatConverter
{
    public class Converter : IConverter
    {
        public TreeFormattedObject ConvertTreeObject(string treeStringObject)
        {
            if (IsJson(treeStringObject))
            {
                Debug.WriteLine("The object is a valid Json");
                //first check if the json object is in the predefined format
                if (IsCommonSchemaJson(treeStringObject))
                {
                    Debug.WriteLine("Perfect! The object is in the predefined schema");
                    var jsonObject = JsonConvert.DeserializeObject<WasteWaterTreatmentPlant>(treeStringObject);
                    var treeFormattedObject = new TreeFormattedObject()
                    {
                        IsPredefinedSchema = true,
                        Object = jsonObject
                    };

                    return treeFormattedObject;
                }
                else
                {
                    Debug.WriteLine("The Json format does not equal the predefined format");
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(treeStringObject);
                    var treeFormattedObject = new TreeFormattedObject()
                    {
                        IsPredefinedSchema = false,
                        Object = jsonObject
                    };

                    return treeFormattedObject;
                }
            }

            throw new Exception("The passed object didnt have a supported format");
        }

        /// <summary>
        /// Returns cells in the format table[rowNo][cellNo]
        /// </summary>
        /// <param name="tableObject"></param>
        /// <returns></returns>
        public TableFormattedObject ConvertTableObject(DataSet tableObject)
        {
            //determine orientation
            var isHorizontal = IsHorizontalOrientation(tableObject, out var firstDateTimeCellTuple);

            //set the number of title rows
            var titleRowNumbres = isHorizontal ? firstDateTimeCellTuple.Item2 : firstDateTimeCellTuple.Item1;

            Debug.WriteLine($"Rows and columns before converting: [{tableObject.Tables[0].Rows.Count},{tableObject.Tables[0].Columns.Count}]");
            //convert dataset to a list<list<string>> invert if vertical
            var cellList = DataSetToHorizontalList(tableObject.Tables[0].DataSet);

            Debug.WriteLine($"Rows and columns after converting: [{cellList.Count},{cellList.First().Count}]");

            var convertionResult = new TableFormattedObject()
            {
                Cells = cellList,
                NumberOfTitleRows = titleRowNumbres
            };

            return convertionResult;
        }

        #region Tree Formatted Private Methods

        private bool IsCommonSchemaJson(string treeStringObject)
        {

            try
            {
                var jsonSchemaGenerator = new JsonSchemaGenerator();
                var myType = typeof(WasteWaterTreatmentPlant);
                var schema = jsonSchemaGenerator.Generate(myType);
                schema.Title = myType.Name;

                var jSchema = JSchema.Parse(schema.ToString());
                JObject jWwtp = JObject.Parse(treeStringObject);
                var isValid = jWwtp.IsValid(jSchema, out IList<ValidationError> errors);
                if (errors.Any()) return false;

                //the object requires indicators either directly related to the wwtp or to a treatment step otherwise its not valid
                var jsonWwtp = JsonConvert.DeserializeObject<WasteWaterTreatmentPlant>(treeStringObject);
                if (jsonWwtp?.TreatmentSteps?.First().QualityIndicators == null && jsonWwtp?.GeneralIndicators == null) return false;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
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

        #region Table Formatted Private Methods
        private List<List<string>> DataSetToHorizontalList(DataSet dataSet, bool invert = false)
        {
            var currentTable = dataSet.Tables[0];
            var cellList = new List<List<string>>();

            if (!invert)
            {
                for (var i = 0; i < currentTable.Rows.Count; i++)
                {
                    cellList.Add(new List<string>());
                    for (var j = 0; j < currentTable.Columns.Count; j++)
                    {
                        cellList[i].Add(currentTable.Rows[i][j].ToString());
                    }
                }
            }
            else
            {
                for (var i = 0; i < currentTable.Columns.Count; i++)
                {
                    cellList.Add(new List<string>());
                    for (var j = 0; j < currentTable.Rows.Count; j++)
                    {
                        cellList[i].Add(currentTable.Rows[j][i].ToString());
                    }
                }
            }

            return cellList;
        }

        /// <summary>
        /// determine orientation through finding the timestamp row(s)
        /// </summary>
        /// <param name="tableObject"></param>
        /// <returns></returns>
        private bool IsHorizontalOrientation(DataSet tableObject, out Tuple<int, int> firstDateTimeCellTuple)
        {
            Tuple<int, int> firstDateTimeCell = null;

            var dateTimesInRow = 0;
            var dateTimesInColumn = 0;

            //find first cell which contains a datetime
            var currentTable = tableObject.Tables[0];

            Debug.WriteLine("Trying to find the first cell with a datetime...");
            for (int i = 0; i < currentTable.Rows.Count; i++)
            {
                for (int j = 0; j < currentTable.Columns.Count; j++)
                {
                    var cell = currentTable.Rows[i][j];
                    //is this cell a datetime?
                    DateTime.TryParse(cell.ToString(), out var dateTime);
                    if (dateTime == default(DateTime)) continue;

                    //save the first finding and close the search
                    firstDateTimeCell = new Tuple<int, int>(i, j);
                    break;
                }

                if (firstDateTimeCell != null) break;
            }

            if (firstDateTimeCell == null) throw new Exception("no datetime was found");

            Debug.WriteLine($"First dateTime cell found at cell:[{firstDateTimeCell.Item1},{firstDateTimeCell.Item2}]");
            firstDateTimeCellTuple = firstDateTimeCell;
            //determine if datetime flow is downwards or sidewards
            //check sidewards
            for (var i = firstDateTimeCell.Item1; i < currentTable.Columns.Count; i++)
            {
                if (currentTable.Rows[firstDateTimeCell.Item1][i] == null) continue;

                DateTime.TryParse(currentTable.Rows[firstDateTimeCell.Item1][i].ToString(), out var dateTime);
                if (dateTime != default(DateTime)) dateTimesInRow++;
            }

            //check downwards
            for (var i = firstDateTimeCell.Item2; i < currentTable.Rows.Count; i++)
            {
                if (currentTable.Rows[i][firstDateTimeCell.Item2] == null) continue;

                DateTime.TryParse(currentTable.Rows[i][firstDateTimeCell.Item2].ToString(), out var dateTime);
                if (dateTime != default(DateTime)) dateTimesInRow++;
            }

            if (dateTimesInRow < dateTimesInColumn)
            {
                Debug.WriteLine("Table Orientation: Vertical");
                return true;
            }

            if (dateTimesInColumn < dateTimesInRow)
            {
                Debug.WriteLine("Table Orientation: Horizontal");
                return false;
            }

            throw new Exception("Orientation could not be determined");
        }
        #endregion

    }
}
