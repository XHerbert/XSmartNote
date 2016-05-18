using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSmartNote.Model
{
    public class PostAndTag
    {
        private int postId;
        private int tagId;

        public int PostId
        {
            get
            {
                return postId;
            }

            set
            {
                postId = value;
            }
        }

        public int TagId
        {
            get
            {
                return tagId;
            }

            set
            {
                tagId = value;
            }
        }
    }
}
