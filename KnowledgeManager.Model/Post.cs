using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManager.Model
{
    public class Post
    {
        private string postTitle;
        private string postContent;
        private int postParentId;

        public string PostTitle
        {
            get
            {
                return postTitle;
            }

            set
            {
                postTitle = value;
            }
        }

        public string PostContent
        {
            get
            {
                return postContent;
            }

            set
            {
                postContent = value;
            }
        }

        public int PostParentId
        {
            get
            {
                return postParentId;
            }

            set
            {
                postParentId = value;
            }
        }
    }
}
