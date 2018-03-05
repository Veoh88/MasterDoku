using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ConvertedObjects;

namespace Interfaces
{
    public interface IConverter
    {
        TreeFormattedObject ConvertTreeObject(string treeStringObject);
        TableFormattedObject ConvertTableObject(DataSet tableObject);

    }
}
