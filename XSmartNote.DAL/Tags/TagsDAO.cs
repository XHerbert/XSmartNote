using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSmartNote.Model.Tags;
using XSmartNote.Model.PostContents;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace XSmartNote.DAL.Tags
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

        public bool IsExistTag(string text)
        {
            IList<Tag> tag = null;
            using (ISession session = sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    tag=session.CreateCriteria(typeof(Tag)).Add(Restrictions.Eq("TagContent", text.Trim())).List<Tag>();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                if (tag.Count > 0)
                    return true;
                return false;
            }
        }

        public Tag GetTagByName(string text)
        {
            IList<Tag> tag = null;
            using (ISession session = sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    tag = session.CreateCriteria(typeof(Tag)).Add(Restrictions.Eq("TagContent", text.Trim())).List<Tag>();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            if (tag.Count > 0)
                return tag[0];
            return null;
        }

        public object Save(Tag tag)
        {
            Guid id = Guid.Empty;
            using (ISession session = sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    //tag = session.CreateCriteria(typeof(Tag)).Add(Restrictions.Eq("TagContent", text.Trim())).List<Tag>();
                    id=(Guid)session.Save(tag);//数据没有进数据库？
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return id;
        }
    }
}
