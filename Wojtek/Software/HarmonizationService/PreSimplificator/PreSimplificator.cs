using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccessor;
using Interfaces;
using Library.ConvertedObjects;
using Newtonsoft.Json;

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

            Console.WriteLine($"Removed  {listWithEmptyColumns.Count} empty columns from the dataset");
            Console.Write("The removed column indexes: ");
            listWithEmptyColumns.ForEach(x => Console.Write(x + "; "));
            Console.WriteLine();

            return tableObject;
        }

        public TreeFormattedObject PreSimplyfyJsonObject(TreeFormattedObject treeObject)
        {
            if (treeObject.IsPredefinedSchema)
            {
                Console.WriteLine("The object is already in the recommended common schema and does no require any simplification");
                return treeObject;
            }

            Dictionary<string, dynamic> d = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(treeObject.Object.ToString());
            foreach (var key in d.Keys)
            {
                //TODO iterate and match keys with blacklist ( this probably has to be done recursivly )
                Console.WriteLine(key);
            }



            return null;
        }
    }
}
