using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeManager.Model
{
    public class Constant
    {
        /// <summary>
        /// 主窗体最小宽度
        /// </summary>
        public const int KM_MIN_WIDTH = 1015;
        /// <summary>
        /// 主窗体最小高度
        /// </summary>
        public const int KM_MIN_HIGHT = 550;
        /// <summary>
        /// 结构树与主窗体的底部距离
        /// </summary>
        public const int KM_TREE_LESS_MAIN = 75;
        /// <summary>
        /// 结构树相对于父容器的调整
        /// </summary>
        public const int KM_TREE_ADJUST_TVFOLDER = 8;
        /// <summary>
        /// 编辑区相对于主窗体的底部距离
        /// </summary>
        public const int KM_ARTICLE_LESS_MAIN = 75;
        /// <summary>
        /// 编辑区相对于父容器的调整
        /// </summary>
        public const int KM_ARTICLE_ADJUST_CONTENT = 14;
        /// <summary>
        /// 展示区横坐标调整
        /// </summary>
        public const int KM_PANELSELECTSAVE_X = 3;
        /// <summary>
        /// 展示区纵坐标调整
        /// </summary>
        public const int KM_PANELSELECTSAVE_Y = 5;
        /// <summary>
        /// 展示区相对于主窗体的底部距离
        /// </summary>
        public const int KM_PANELMAIN_LESS_MAIN = 75;
        /// <summary>
        /// 列表区纵坐标调整
        /// </summary>
        public const int KM_PANELLIST_HEIGHT = 14;
        /// <summary>
        /// 列数
        /// </summary>
        public const int KM_PANELLIST_COLUMN = 6;

        public const string KM_KNOWLEDGESYSTEM = "知识体系";
        public const string KM_DEFAULT_FOLDERNAME = "新建文件夹";
        public const string KM_DEFAULT_NOTENAME = "新建文章";


        public const string KM_TYPE_WARN = "注意";
        public const string KM_TYPE_ERROR = "错误";
        public const string KM_TYPE_INFO = "提示";

        public const string KM_ER_CONVERT_FAIL = "整数转换异常！";
        public const string KM_WN_TITLE_OR_CONTENT_NOT_NULL = "标题或内容不能为空！";
        public const string KM_WN_DISPATCH_DIR = "请为该文章分配目录！";
        public const string KM_INFO_SAVE_OK = "保存成功！";
        public const string KM_ER_DATA_SAVE_FAILED = "数据保存失败！";
        public const string KM_ER_NOTE_SAVE_FAILED="添加随笔失败！";
        public const string KM_WN_ADD_EXIST_LABEL_NOT_ALLOWED = "不能重复添加标签！";
        public const string KM_WN_NODE_NOT_SELECTED = "请选择文章节点！";

        public const string KM_ER_REFERENCE_ID_WRONG = "关联ID出错！";
        public const string KM_WN_NOTE_NOT_SELECTED = "尚未选择文章！";
        public const string KM_REMOVE_REFERENCE_WRONG = "移除关联ID出错！";
    }
}
