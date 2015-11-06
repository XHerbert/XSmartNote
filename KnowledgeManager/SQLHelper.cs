using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KnowledgeManager.Model;

namespace KnowledgeManager
{
    public class SQLHelper
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(@"server=4RBLIOWUDMHUMSF;database=db_KnowledgeManager;uid=sa;pwd=123456");
        }

        //继续封装，执行无参查询操作
        private static DataSet QuerySet(StringBuilder sbcmd)
        {
            using (SqlConnection conn = SQLHelper.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sbcmd.ToString(), conn))
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(ds);
                    return ds;
                }
            }
        }

        private static DataTable QueryTable(StringBuilder sbcmd)
        {
            using (SqlConnection conn = SQLHelper.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sbcmd.ToString(), conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter sda = new SqlDataAdapter();
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    return dt;
                }
            }
        }

        public static DataTable GetFoldersTable()
        {
            StringBuilder cmd = new StringBuilder("SELECT * FROM Table_Folder");
            return QueryTable(cmd);
        }

        //插入文件夹
        public static int InsertFolder(PostContent post,bool isRoot)
        {
            int result = -1;
            int? parentId = post.ParentId;
            string title = post.Title;
            string content = post.Content;
            bool type = post.Type;
            StringBuilder cmd = null;
            if (isRoot)
            {
                 cmd= new StringBuilder(string.Format("insert into Table_Content(Title,Content,Type,CreateDate,ModifyDate,Enable) values('{0}','{1}','{2}',getdate(),getdate(),1)",  title, content, type));
            }
            else
            {
                cmd = new StringBuilder(string.Format("insert into Table_Content(ParentId,Title,Content,Type,CreateDate,ModifyDate,Enable) values({0},'{1}','{2}','{3}',getdate(),getdate(),1)", parentId, title, content, type));
            }
            
            return NonQuery(cmd,result);
        }

        //获取文件夹列表
        public static DataSet GetFoldersSet()
        {
            StringBuilder cmd = new StringBuilder("SELECT Id,ParentId,Title,Content,Type FROM Table_Content");
            return QuerySet(cmd);
        }

        public static DataTable GetListByFolderId(int Id)
        {
            StringBuilder cmd = new StringBuilder(string.Format("select * from Table_Content where Type=1 and ParentId={0}",Id));
            return QueryTable(cmd);
        }


        //对文件夹进行重命名
        public static int UpdateFolder(string oldValue, string newValue,int id)
        {
            int result = 0;
            if (string.IsNullOrEmpty(newValue))
            {
                return -1;
            }
            StringBuilder cmd = new StringBuilder(string.Format("update Table_Content set {0}='{1}' where {0}='{2}' and  Id={3}", Enums.Title.ToString(), newValue, oldValue,id));
            return NonQuery(cmd, result);
        }

        //通过ID获取文件夹名称
        public static DataTable GetNameById(int Id)
        {
            StringBuilder cmd = new StringBuilder(string.Format("select Title from Table_Content where Id={0}",Id));
            return QueryTable(cmd);
        }

        //通过文件夹名称获取ID
        public static int GetIdByName(string folderText)
        {
            StringBuilder cmd = new StringBuilder(string.Format("select Id from Table_Content where Title='{0}'", folderText));
            DataTable dt= QueryTable(cmd);
            return dt.Rows[0][0].ToInt();
        }

        public static string GetContentById(int Id)
        {
            string result = string.Empty;
            StringBuilder cmd = new StringBuilder();
            cmd.Append(string.Format("select Content from Table_Content where Id={0}",Id));
            DataTable dt = QueryTable(cmd);
            if (dt != null)
            {
                result = dt.Rows[0][0].ToString();
            }
            return result;
        }

        //更新标题及内容
        public static int UpdateContent(int id,string title,string content)
        {
            int result = -1;
            StringBuilder cmd = new StringBuilder();
            cmd.Append(string.Format("update Table_Content set Content = '{0}',Title='{1}'  where Id={2}",content,title,id));
            return NonQuery(cmd, result);
        }

        //获取最大ID
        public static int GetMaxID(string table,string id)
        {
            StringBuilder cmd = new StringBuilder(string.Format("select max({0}) from {1}",id, table));
            DataTable dt=QueryTable(cmd);
            return dt.Rows[0][0].ToInt();
        }
        public static int InsertArticle()
        {
            return 0;
        }

        //添加书签
        public static int InsertTag(string tag)
        {
            int result = -1;
            StringBuilder cmd = new StringBuilder(string.Format("insert into Table_Tag  values('{0}')",tag));
            return NonQuery(cmd, result);
        }
        
        //获取所有的书签
        public static DataTable GetAllTags()
        {
            StringBuilder cmd = new StringBuilder("select * from Table_Tag");
            return QueryTable(cmd);
        }

        //取得指定文章Id包含的标签
        public static DataTable GetTagsByPostId(int id)
        {
            StringBuilder cmd = new StringBuilder(string.Format("select t.tagContent,t.tagId from Table_Content c,Table_Content_Tag ct,Table_Tag t "));
            cmd.Append(string.Format(" where c.Id=ct.postId and t.tagId=ct.tagId and c.id={0} ", id));
            return QueryTable(cmd);
        }


        //检测是否包含重名标签
        public static bool CheckOverrideName(string txt)
        {
            StringBuilder cmd = new StringBuilder(string.Format("select tagContent from Table_Tag where tagContent='{0}'", txt));
            int result=QueryTable(cmd).Rows.Count;
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int AddRelations(int contentId,int tagId)
        {
            StringBuilder cmd = new StringBuilder(string.Format("insert into Table_Content_tag values({0},{1})", contentId, tagId));
            int result = -1;
            return NonQuery(cmd, result);
        }

        public static int RemoveRelations(int contentId, int tagId)
        {
            StringBuilder cmd = new StringBuilder(string.Format("delete from Table_Content_tag where postId={0} and tagId={1}", contentId, tagId));
            int result = -1;
            return NonQuery(cmd, result);
        }

        private static int NonQuery(StringBuilder sb, SqlParameter[] para, int i)
        {
            using (SqlConnection conn = SQLHelper.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
                {
                    foreach (SqlParameter sp in para)
                    {
                        if (sp.Value == null)
                        {
                            //非空判断
                            sp.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(sp);
                    }
                    i = cmd.ExecuteNonQuery();
                }
            }
            return i;
        }

        private static int NonQuery(StringBuilder sb,int result)
        {
            using (SqlConnection conn = SQLHelper.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
                {
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}