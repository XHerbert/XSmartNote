using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace XSmartNote.ThemeManager
{
    public interface IThemeManager
    {
        void ChangeFormTheme(ThemeEnums.ThemeEnum enums);
    }


    public class ThemeContext 
    {
        ITheme theme = null;

        public ThemeContext(ITheme myTheme)
        {
            theme = myTheme;
        }

        public void SetTheme()
        {
            theme.SetTheme();
        }
    }

    public interface ITheme
    {
        void SetTheme();
    }

    public class MistyRose : ITheme
    {
        private MainForm _Main;
        public MistyRose(MainForm main)
        {
            this._Main = main;
        }
        public void SetTheme()
        {
            //实现主题设置
            _Main.Panel_Main.BackColor = Color.MistyRose;
            _Main.Tv_Folder.BackColor = Color.MistyRose;
            _Main.Txt_Title.BoxBackColor = Color.MistyRose;
            _Main.Txt_Content.BoxBackColor = Color.MistyRose;

            _Main.MenuStripHeader.BackColor = Color.Maroon;
            _Main.MenuStripHeader.ForeColor = Color.Silver;
            foreach (ToolStripMenuItem item in _Main.MenuStripHeader.Items)
            {
                item.ForeColor = Color.Silver;
            }
        }
    }

    public class AliceBlue : ITheme
    {
        private MainForm _Main;
        public AliceBlue(MainForm main)
        {
            this._Main = main;
        }
        public void SetTheme()
        {
            //实现主题设置
            _Main.Panel_Main.BackColor = Color.AliceBlue;
            _Main.Tv_Folder.BackColor = Color.AliceBlue;
            _Main.Txt_Title.BoxBackColor = Color.AliceBlue;
            _Main.Txt_Content.BoxBackColor = Color.AliceBlue;

            _Main.MenuStripHeader.BackColor = Color.LightBlue;
            _Main.MenuStripHeader.ForeColor = Color.Black;
            foreach (ToolStripMenuItem item in _Main.MenuStripHeader.Items)
            {
                item.ForeColor = Color.Black;
            }
        }
    }


    public class Honeydew : ITheme
    {
        private MainForm _Main;
        public Honeydew(MainForm main)
        {
            this._Main = main;
        }
        public void SetTheme()
        {
            //实现主题设置
            _Main.Panel_Main.BackColor = Color.Honeydew;
            _Main.Tv_Folder.BackColor = Color.Honeydew;
            _Main.Txt_Title.BoxBackColor = Color.Honeydew;
            _Main.Txt_Content.BoxBackColor = Color.Honeydew;

            _Main.MenuStripHeader.BackColor = Color.LightGreen;
            _Main.MenuStripHeader.ForeColor = Color.Black;
            foreach (ToolStripMenuItem item in _Main.MenuStripHeader.Items)
            {
                item.ForeColor = Color.Black;
            }
        }
    }

    public class LemonChiffon : ITheme
    {
        private MainForm _Main;
        public LemonChiffon(MainForm main)
        {
            this._Main = main;
        }
        public void SetTheme()
        {
            //实现主题设置
            _Main.Panel_Main.BackColor = Color.LemonChiffon;
            _Main.Tv_Folder.BackColor = Color.LemonChiffon;
            _Main.Txt_Title.BoxBackColor = Color.LemonChiffon;
            _Main.Txt_Content.BoxBackColor = Color.LemonChiffon;

            _Main.MenuStripHeader.BackColor = Color.Orange;
            _Main.MenuStripHeader.ForeColor = Color.Black;
            foreach (ToolStripMenuItem item in _Main.MenuStripHeader.Items)
            {
                item.ForeColor = Color.Black;
            }
        }
    }

}
