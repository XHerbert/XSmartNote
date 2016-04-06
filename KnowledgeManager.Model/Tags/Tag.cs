using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManager.Model.Tags
{
    public class Tag
    {
        /// <summary>
        /// Tag ID
        /// </summary>
        public virtual Guid TagID { get; set; }
        /// <summary>
        /// Tag Content
        /// </summary>
        public virtual string TagContent { get; set; }
    }
}
