using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSmartNote.DAL.Base
{
    public interface IDAO
    {
        object Save(object entity);
    }
}
