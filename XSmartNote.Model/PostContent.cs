using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSmartNote.Model
{
    public class PostContent
    {
        private int _Id;
        private int? _ParentId;
        private string _Title;
        private string _Content;
        private bool _Type;
        private DateTime _CreateDate;
        private DateTime _ModifyDate;
        private bool _Enable;

        public int Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public int? ParentId
        {
            get
            {
                return _ParentId;
            }

            set
            {
                _ParentId = value;
            }
        }

        public string Title
        {
            get
            {
                return _Title;
            }

            set
            {
                _Title = value;
            }
        }

        public string Content
        {
            get
            {
                return _Content;
            }

            set
            {
                _Content = value;
            }
        }

        public bool Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }

            set
            {
                _CreateDate = value;
            }
        }

        public DateTime ModifyDate
        {
            get
            {
                return _ModifyDate;
            }

            set
            {
                _ModifyDate = value;
            }
        }

        public bool Enable
        {
            get
            {
                return _Enable;
            }

            set
            {
                _Enable = value;
            }
        }
    }
}
