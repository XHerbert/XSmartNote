using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSmartNote.DAL.Relations
{
    public interface IRelationsDAO
    {
        bool Save(Model.Relations.Relation relation);

        bool Delete(Model.Relations.Relation relation);

    }
}
