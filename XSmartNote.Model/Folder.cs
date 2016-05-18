using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSmartNote.Model
{
    public class Folder
    {
        private string folderName;
        private int folderId;
        private int folderParentId;

        public Folder(int parentId)
        {
            this.folderParentId = parentId;
        }

        public Folder (string text)
        {
            //this.
        }

        public string FolderName
        {
            get
            {
                return folderName;
            }

            set
            {
                folderName = value;
            }
        }

        

        public int FolderParentId
        {
            get
            {
                return folderParentId;
            }

            set
            {
                folderParentId = value;
            }
        }

        public int FolderId
        {
            get
            {
                return folderId;
            }

            set
            {
                folderId = value;
            }
        }
    }
}
