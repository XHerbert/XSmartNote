﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeManager.DAL.Base;
using KnowledgeManager.Model.PostContents;

namespace KnowledgeManager.DAL.PostContents
{
    public interface IPostContentsDAO
    {
        object Save(PostContent entity);

        IList<PostContent> QueryAll(out int lineNum);

        PostContent GetEntityById(Guid guid);

        IList<PostContent> GetEntityByCondition(string condition,string val);

        bool Update(PostContent post);

        bool Delete(PostContent post);

        Guid GetGuidByLineNum(int lineNum);
    }
}
