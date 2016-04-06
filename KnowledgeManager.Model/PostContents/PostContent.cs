using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManager.Model.PostContents
{
    public class PostContent
    {
        /// <summary>
        /// Note ID
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// ParentNode ID
        /// </summary>
        public virtual Guid ParentId { get; set; }
        /// <summary>
        /// Note Title
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// Note Content
        /// </summary>
        public virtual string Content { get; set; }
        /// <summary>
        /// Note Type 0:Level 1 childNode ; 1:Level 2 Upper childNodes
        /// </summary>
        public virtual bool Type { get; set; }
        /// <summary>
        /// Note CreateDate
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        /// <summary>
        /// Note Last ModifyDate
        /// </summary>
        public virtual DateTime ModifyDate { get; set; }
        /// <summary>
        /// Note Is Enable Or Not
        /// </summary>
        public virtual bool Enable { get; set; }
    }
}
