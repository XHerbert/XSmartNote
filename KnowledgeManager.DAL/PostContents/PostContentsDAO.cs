using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeManager.Model.PostContents;
using KnowledgeManager.DAL;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Criterion;

namespace KnowledgeManager.DAL.PostContents
{
    public class PostContentsDAO : IPostContentsDAO
    {
        private ISessionFactory sessionFactory;
        private static PostContentsDAO PostContentsDao;
        private PostContentsDAO()
        {
            //在构造函数中获取配置，并产生SessionFactory
            var cfg = new NHibernate.Cfg.Configuration().Configure("../../Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public static PostContentsDAO CreatePostContentsDAO()
        {
            if (null == PostContentsDao)
            {
                PostContentsDao = new PostContentsDAO();
            }
            return PostContentsDao;
        }

        public IList<PostContent> GetEntityByCondition(string condition,string val)
        {
            IList<PostContent> PostContents;
            using (ISession session = sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    IQuery query = session.CreateQuery(condition).SetString("fn", val);
                    PostContents= query.List<PostContent>();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                return PostContents;
            }
        }


        /// <summary>
        /// 根据父Id取到所有隶属其的Note
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public IList<PostContent> GetEntityByExample(Guid ParentId)
        {
            PostContent post = new PostContent()
            {
                ParentId = ParentId
            };
            IList<PostContent> list = null;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    //list=session.CreateCriteria(typeof(PostContent)).Add(Example.Create(post)).List<PostContent>();
                    list = session.CreateCriteria(typeof(PostContent)).Add(Restrictions.Eq("ParentId", ParentId)).List<PostContent>();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return list;
        }

        public PostContent GetEntityById(Guid guid)
        {
            using (ISession session =sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                PostContent post;
                try
                {
                    post=session.Get<PostContent>(guid);
                    trans.Commit();
                    
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                return post;
            }
        }

        public Guid GetGuidByLineNum(int lineNum)
        {
            using (ISession session=sessionFactory.OpenSession())
            {
                Guid parentGuid = Guid.Empty;
                ITransaction trans = session.BeginTransaction();
                try
                {
                    IQuery query = session.CreateQuery("select Id from PostContent PC where PC.LineNum=:fn").SetString("fn", lineNum.ToString());
                    parentGuid = query.List<Guid>()[0];
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                return parentGuid;
            }
        }

        public IList<PostContent> QueryAll(out int count)
        {
            IList<PostContent> list;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    list = session.Query<PostContent>().ToList();
                    //取所有记录的数量
                    count = list.Count;
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                return list;
            }
        }
        //pass
        public object Save(PostContent entity)
        {
            bool IsSuccess=false;
            Guid newId = Guid.Empty;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    //开始事务处理
                    newId=(Guid)session.Save(entity);
                    trans.Commit();
                    if (Guid.Empty != newId)
                        IsSuccess = true;
                }
                catch(HibernateException)
                {
                    trans.Rollback();
                }
               
            }
            return IsSuccess;
        }

        public bool Update(PostContent post)
        {
            bool IsUpdated = false;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                    session.Update(post);
                    trans.Commit();
                    if (trans.WasCommitted)
                    {
                        IsUpdated = true;
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return IsUpdated;
        }

        public bool Delete(Model.PostContents.PostContent post)
        {
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                bool IsSuccess = false;
                try
                {
                    session.Delete(post);
                    session.Flush();
                    trans.Commit();
                    if (trans.WasCommitted)
                    {
                        IsSuccess = true;
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
                return IsSuccess;
            }
        }
    }
}
