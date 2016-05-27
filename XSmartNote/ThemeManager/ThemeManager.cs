using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSmartNote.ThemeManager
{
    public class ThemeManager:IThemeManager
    {
        private static ThemeManager themeManager;
        private MainForm mainForm;
        private event Action<ThemeEnums.ThemeEnum> ThemeChangeEvent;
        private static object _lock = new object();
        private ThemeManager(MainForm mainForm)
        {
            this.mainForm = mainForm;
            //ThemeChangeEvent += mainForm.SetTheme;
        }

        public static ThemeManager CreateThemeManager(MainForm form)
        {
            ThemeManager _themeManager;
            if (themeManager == null)
            {
                lock (_lock)
                {
                    if (themeManager == null)
                    {
                        _themeManager = new ThemeManager(form);
                        themeManager = _themeManager;
                    }
                }
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
