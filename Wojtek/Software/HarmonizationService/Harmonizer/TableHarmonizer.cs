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

namespace Harmonizer
{
    public class TableHarmonizer : ITableHarmonizer
    {
        private readonly IDataBaseViewAccessor _dataBaseAccessor;
        private readonly IUtilityDbAccessor _utilityDataBaseAccessor;

        public TableHarmonizer()
        {
            _dataBaseAccessor = new DbViewAccessor();
            _utilityDataBaseAccessor = new UtilityDbAccessor();
        }
        public WasteWaterTreatmentPlant HarmonizeTable(TableFormattedObject tableObject)
        {
            //step 1 : find numeric columns 
            var indexesOfNumericColumns = FindNumericColumns(tableObject);

            //step 2 : finding the timestamp column
            var firstDateTimeCellAt = FindFirstCellWithDateTime(tableObject);

            //step 3 : find indicatorNames (one per column) -> at least as many as value columns
            var indicatorNames = FindIndicatorNames(tableObject);

            //TODO wenn indicator names fehlen patterns benutzen um die indicators woanders herzuholen
            //TODO Units vllt?
            if (indexesOfNumericColumns.Count != indicatorNames.Keys.Count) throw new Exception("The number of numeric columns doesn't match the number of indicator names");

            //step 4 : associate indicator names with numeric columns
            var nameToValueColumnIndex = AssociateColumnIndexesWithIndicatorNames(indexesOfNumericColumns, indicatorNames);

            //step 5 : create harmonized object
            var wwtp = CreateWasteWaterTreatmentPlantObject(tableObject, indexesOfNumericColumns, firstDateTimeCellAt,
                nameToValueColumnIndex);

            return wwtp;
        }

        private WasteWaterTreatmentPlant CreateWasteWaterTreatmentPlantObject(
            TableFormattedObject tableObject,
            List<int> indexesOfNumericColumns,
            Tuple<int, int> firstDateTimeCellAt,
            Dictionary<int, string> columnIndexToName)
        {
            var wwtp = new WasteWaterTreatmentPlant() //TODO add properties
            {

            };
            wwtp.TreatmentSteps = new List<WaterTreatmentStep>();
            wwtp.TreatmentSteps.Add(new WaterTreatmentStep()); //TODO add treatment step name

            //Setting QualityIndicators
            wwtp.TreatmentSteps[0].QualityIndicators = new List<WaterQualityIndicator>();

            //for each indicator
            for (var i = 0; i < indexesOfNumericColumns.Count; i++)
            {
                //for each entry of a specific indicator create a valid entry
                for (var j = tableObject.NumberOfTitleRows; j < tableObject.Cells.Count; j++)
                {
                    var waterQualityIndicator = new WaterQualityIndicator();
                    DateTime.TryParse(tableObject.Cells[j][firstDateTimeCellAt.Item2], out var dateTime);
                    waterQualityIndicator.TimeStamp = dateTime;
                    waterQualityIndicator.Name = columnIndexToName[indexesOfNumericColumns[i]];
                    //TODO check if value and unit are matching
                    waterQualityIndicator.Value = double.Parse(tableObject.Cells[j][indexesOfNumericColumns[i]]);
                    //set defaultUnit
                    //TODO check if there is another unit set


                    waterQualityIndicator.Unit = _utilityDataBaseAccessor.GetDefaultUnitForIndicator(waterQualityIndicator.Name);

                    wwtp.TreatmentSteps[0].QualityIndicators.Add(waterQualityIndicator);
                }
            }

            Debug.WriteLine("Creation of Harmonized WasteWaterTreatmentPlant Object successful!");

            return wwtp;
        }

        private Dictionary<int, string> AssociateColumnIndexesWithIndicatorNames(List<int> indexesOfNumericColumns, Dictionary<string, Tuple<int, int>> indicatorNames)
        {
            var associations = new Dictionary<int, string>();

            for (var i = 0; i < indexesOfNumericColumns.Count; i++)
            {
                associations.Add(indexesOfNumericColumns[i], indicatorNames.Keys.ElementAt(i));
                Debug.WriteLine($"Associated Indicator [{indicatorNames.Keys.ElementAt(i)}] with ColumnIndex [{indexesOfNumericColumns[i]}]");
            }

            return associations;
        }


        private List<int> FindNumericColumns(TableFormattedObject tableObject)
        {
            var indexesOfNumericColumns = new List<int>();

            for (var i = tableObject.NumberOfTitleRows; i < tableObject.Cells[tableObject.NumberOfTitleRows].Count; i++)
            {
                var currentCell = tableObject.Cells[tableObject.NumberOfTitleRows][i];
                var isNumeric = double.TryParse(currentCell, out double _);
                if (isNumeric)
                {
                    indexesOfNumericColumns.Add(i);
                }
            }
            Console.Write("Found numeric columns at indexes: ");
            indexesOfNumericColumns.ForEach(x => Console.Write(x + "; "));
            Debug.WriteLine("");

            return indexesOfNumericColumns;
        }

        private Tuple<int, int> FindFirstCellWithDateTime(TableFormattedObject tableObject)
        {
            Debug.WriteLine("Trying to find the first cell with a datetime again because table was modified...");
            Tuple<int, int> firstDateTimeCell = null;
            for (int i = 0; i < tableObject.Cells.Count; i++)
            {
                for (int j = 0; j < tableObject.Cells[i].Count; j++)
                {
                    var cell = tableObject.Cells[i][j];
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
            return firstDateTimeCell;
        }

        /// <summary>
        /// returns a dictionnary of [nameOfIdentificator, Cell(x,y)]
        /// </summary>
        private Dictionary<string, Tuple<int, int>> FindIndicatorNames(TableFormattedObject tableObject)
        {
            Debug.WriteLine("Searching for IndicatorNames and Aliases in the title...");

            var indicatorNamesWithCells = new Dictionary<string, Tuple<int, int>>();
            var indicatorNamesFromDb = _dataBaseAccessor.GetQualityIndicatorTypes().Select(x=>x.indicatorName).ToList();
            var indicatorAliasesFromDb = _dataBaseAccessor.GetQualityIndicatorTypeMappings().Select(x=>x.indicatorAlias).ToList();

            //iterate through all rows of title on the search for indicator names
            for (int i = 0; i < tableObject.NumberOfTitleRows; i++)
            {
                for (var j = 0; j < tableObject.Cells[i].Count; j++)
                {
                    var currentCell = tableObject.Cells[i][j];
                    if (indicatorNamesWithCells.ContainsKey(currentCell)) continue;
                    if (indicatorNamesFromDb.Contains(currentCell))
                    {
                        Debug.WriteLine($"Indicator [{currentCell}] found at ({i},{j})");
                        indicatorNamesWithCells.Add(currentCell, new Tuple<int, int>(i, j));
                    }
                    else if (indicatorAliasesFromDb.Contains(currentCell))
                    {
                        var indicatorName = _utilityDataBaseAccessor.GetIndicatorForAlias(currentCell);
                        Debug.WriteLine($"[{currentCell}] found at ({i},{j}) is an alias for [{indicatorName}]");
                        indicatorNamesWithCells.Add(indicatorName, new Tuple<int, int>(i, j));
                    }
                }
            }

            Debug.WriteLine("Searching for IndicatorNames and Aliases in the rows...");

            //iterate through all rows of title on the search for indicator names
            for (var i = 0; i < tableObject.Cells[tableObject.NumberOfTitleRows].Count; i++)
            {
                var currentCell = tableObject.Cells[tableObject.NumberOfTitleRows][i];
                if (indicatorNamesWithCells.ContainsKey(currentCell)) continue;
                if (indicatorNamesFromDb.Contains(currentCell))
                {
                    Debug.WriteLine($"Indicator [{currentCell}] found at ({tableObject.NumberOfTitleRows},{i})");
                    indicatorNamesWithCells.Add(currentCell, new Tuple<int, int>(tableObject.NumberOfTitleRows, i));
                }
                else if (indicatorAliasesFromDb.Contains(currentCell))
                {
                    var indicatorName = _utilityDataBaseAccessor.GetIndicatorForAlias(currentCell);
                    Debug.WriteLine($"[{currentCell}] found at ({tableObject.NumberOfTitleRows},{i}) is an alias for [{indicatorName}]");
                    indicatorNamesWithCells.Add(indicatorName, new Tuple<int, int>(tableObject.NumberOfTitleRows, i));
                }
            }

            return indicatorNamesWithCells;
        }
    }
}
