using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeManager.Model.Tags;
using KnowledgeManager.Model.PostContents;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace KnowledgeManager.DAL.Tags
{
    public class TagsDAO : ITagsDAO
    {

        private ISessionFactory sessionFactory;
        private static TagsDAO tagsDAO;
        private TagsDAO()
        {
            //在构造函数中获取配置，并产生SessionFactory
            var cfg = new NHibernate.Cfg.Configuration().Configure("../../Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }


        public static TagsDAO CreateTagsDAO()
        {
            if (null == tagsDAO)
            {
                tagsDAO = new TagsDAO();
            }
            return tagsDAO;
        }

        public IList<Tag> GetTagsByPostId(Guid Id)
        {
            IList<Model.Tags.Tag> tags = null;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    //tags=session.CreateCriteria(typeof(PostContent)).Add(Restrictions.Eq("Id", Id))
                    //    .CreateCriteria("Tags").List<Tag>();

                    tags = session.CreateCriteria(typeof(Tag)).CreateCriteria("Posts").Add(Restrictions.Eq("Id", Id)).List<Tag>();
                        //.CreateCriteria("PostContent").Add(Restrictions.Eq("Id", Id)).List<Tag>();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                return tags;
            }
        }


        public Tag GetTagById(Guid Id)
        {
            Tag tag = null;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    tag=session.Get<Tag>(Id);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return tag;
        }

        public IList<Tag> GetAllTags()
        {
            IList<Tag> tags = null;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    tags= session.Query<Tag>().ToList();
                    session.Flush();
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return tags;
        }
    }
}
