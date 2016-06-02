using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace XSmartNote.ThemeManager.Themes.Splash
{
    class LoadMessage
    {
        public static void Load()
        {
            Thread.Sleep(5000);
            SplashScreen.ChangeTitle("正在加载UI组件 ... ...");
            Thread.Sleep(1000);
            SplashScreen.ChangeTitle("正在加载Data组件 ... ...");
            Thread.Sleep(5000);
            SplashScreen.ChangeTitle("正在加载主题插件 ... ...");
            Thread.Sleep(1000);
            SplashScreen.ChangeTitle("正在加载主界面 ... ...");
            Thread.Sleep(5000);
            SplashScreen.ChangeTitle("正在加载UI组件 ... ...");
            Thread.Sleep(1000);
            SplashScreen.ChangeTitle("正在加载Data组件 ... ...");
            Thread.Sleep(5000);
            SplashScreen.ChangeTitle("正在加载主题插件 ... ...");
            Thread.Sleep(1000);
            SplashScreen.ChangeTitle("正在加载主界面 ... ...");
            SplashScreen.Close();
        }
    }
}
