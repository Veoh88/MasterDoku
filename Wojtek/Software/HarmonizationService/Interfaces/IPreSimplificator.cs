using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ConvertedObjects;

namespace Interfaces
{
    public interface IPreSimplificator
    {
        TableFormattedObject PreSimplyfyTableObject(TableFormattedObject tableObject);
        TreeFormattedObject PreSimplyfyJsonObject(TreeFormattedObject treeObject);

    }
}
