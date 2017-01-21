using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XSmartNote
{
    public class GlobalParam
    {
        private static TreeNode globalNode = null;

        public GlobalParam()
        {
            globalNode = new TreeNode(); 
        }

        public static TreeNode GlobalNode
        {
            get
            {
                return globalNode;
            }

            set
            {
                globalNode = value;
            }
        }

    }
}
