using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManager.ThemeManager
{
    public interface IThemeManager
    {
        void ChangeFormTheme(ThemeEnums.ThemeEnum enums);
    }
}
