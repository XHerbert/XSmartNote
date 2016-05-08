using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManager.DAL.Tags
{
    public interface ITagsDAO
    {
        IList<Model.Tags.Tag> GetTagsByPostId(Guid Id);
    }
}
