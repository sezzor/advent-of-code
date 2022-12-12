using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace day7_1.Models
{
    public class Folder
    {
        public Folder(string name)
        {
            Name = name;
        }

        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; init; }
        public int Size { get; set; } = 0;
        public List<Filex> Files { get; } = new List<Filex>();
        public List<Folder> SubFolders { get; } = new List<Folder>();
        public Folder? ParentFolder { private get; set; } = null;


        public Folder OpenSubFolder(string folderName)
        {
            return SubFolders.Single(f => f.Name == folderName);
        }
        public Folder OpenParentFolder()
        {
            if (ParentFolder != null)
                return ParentFolder;
            else return null;
        }
    }
}