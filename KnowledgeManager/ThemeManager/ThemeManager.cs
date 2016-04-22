using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManager.ThemeManager
{
    public class ThemeManager:IThemeManager
    {
        private static ThemeManager themeManager;
        private MainForm mainForm;
        private event Action<ThemeEnums.ThemeEnum> ThemeChangeEvent;
        private ThemeManager(MainForm mainForm)
        {
            this.mainForm = mainForm;
            ThemeChangeEvent += mainForm.SetTheme;
        }

        public static ThemeManager CreateThemeManager(MainForm form)
        {
            if (themeManager == null)
            {
                themeManager = new ThemeManager(form);
            }
            return themeManager;
        }

        public void ChangeFormTheme(ThemeEnums.ThemeEnum enums)
        {
            if (ThemeChangeEvent != null)
            {
                ThemeChangeEvent(enums);
            }
        }
    }
}
