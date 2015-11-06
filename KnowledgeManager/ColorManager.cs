using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManager
{
    public class ColorManager
    {
        public enum Color
        {
            d0f0fd = 0,
            fffedc = 1,
            edebfd = 2,
            fff7c6 = 3,
            ccf7fc = 4,
            cff0cc = 5,
            ffe6e0 = 6,
            d6d5f9 = 7,
            fdf0e0 = 8,
            edf8c6 = 9,
            f5e0fd = 10,
            f1fefe = 11,
            f0fde6 = 12,
             fdeef3= 13,
            f3f3fc = 14,
            dcf09b = 15,
            ffe0c3 = 16,
            fff0e4 = 17,
            ffd0d7 = 18,
            fff89e = 19
        }

        public static string ColorConvertor(int flag)
        {
            StringBuilder builder = new StringBuilder("#");
            builder.Append(((ColorManager.Color)flag).ToString());
            return builder.ToString();
        }
    }
}
