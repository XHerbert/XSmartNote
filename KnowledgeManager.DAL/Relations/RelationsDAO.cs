using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeManager.Model.Relations;
using NHibernate;
using NHibernate.Criterion;

namespace KnowledgeManager.DAL.Relations
{
    public class RelationsDAO : IRelationsDAO
    {

        private ISessionFactory sessionFactory;
        private static RelationsDAO RelationsDao;
        private  RelationsDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("../../Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public static RelationsDAO CreateRelationsDAO()
        {
            if (null == RelationsDao)
            {
                RelationsDao = new RelationsDAO();
            }
            return RelationsDao;
        }


        public bool Delete(Relation relation)
        {
            bool IsSuccess = false;
            using (ISession session = sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                session.Delete(relation);
                trans.Commit();
                if (trans.WasCommitted)
                {
                    IsSuccess = true;
                }
            }
            return IsSuccess;
        }

        public bool Save(Relation relation)
        {
            bool IsSuccess = false;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                Guid id=(Guid)session.Save(relation);
                trans.Commit();
                if (id != Guid.Empty)
                {
                    IsSuccess = true;
                }
            }
            return IsSuccess;
        }


        public bool BatchSave(IList<Relation> relations)
        {
            return false;
        }


        public bool BatchDelete(IList<Relation> relations)
        {
            return false;
        }


        public Relation GetRelationById(Guid Id)
        {
            Relation r = null;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction();
                try
                {
                   r= session.Get<Relation>(Id);
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return r;
        }

        public Relation IsExistTag(Guid postId,Guid tagId,out bool IsExist)
        {
            IsExist = false;
            Relation rel = null;
            using (ISession session=sessionFactory.OpenSession())
            {
                ITransaction trans = session.BeginTransaction(); try
                {
                    IList<Relation> list=session.CreateCriteria(typeof(Relation)).Add(Restrictions.Eq("PostId", postId)).Add(Restrictions.Eq("TagId", tagId)).List<Relation>();
                    if (list.Count > 0)
                    {
                        IsExist = true;
                        rel = list[0];
                    }
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
            return rel;
        }
    }
}
