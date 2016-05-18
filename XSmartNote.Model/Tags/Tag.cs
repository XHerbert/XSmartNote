using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSmartNote.Model.Tags
{
    public class Tag
    {
        /// <summary>
        /// Tag ID
        /// </summary>
        public virtual Guid TagId { get; set; }
        /// <summary>
        /// Tag Content
        /// </summary>
        public virtual string TagContent { get; set; }

        /// <summary>
        /// One Tag Has Many Posts
        /// </summary>
        public virtual IList<Model.PostContents.PostContent> Posts { get; set; }
    }
}
