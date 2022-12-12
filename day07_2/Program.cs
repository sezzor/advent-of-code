using day7_1.Models;

string text = File.ReadAllText("input.txt");
string[] inputLines = text.Split('\n');

Folder root = new Folder("/");
Folder currentFolder = root;
List<Folder> allFolders = new List<Folder>();
allFolders.Add(root);


foreach (var line in inputLines)
{
    if (line == "$ cd /" || line == "$ ls") continue;

    // Go back
    else if (line == "$ cd ..")
    {
        currentFolder = currentFolder.OpenParentFolder();
    }

    // Go deeper
    else if (line.Substring(0, 4) == "$ cd")
    {
        string name = line.Substring(5, line.Count() - 5);
        currentFolder = currentFolder.OpenSubFolder(name);
    }

    // New folder
    else if (line.Substring(0, 3) == "dir")
    {
        string name = line.Substring(4, line.Count() - 4);
        Folder newFolder = new Folder(name)
        {
            ParentFolder = currentFolder
        };
        currentFolder.SubFolders.Add(newFolder);
        allFolders.Add(newFolder);
    }

    // New file
    else
    {
        string name = line.Split(" ")[1];
        int size = int.Parse(line.Split(" ")[0]);

        currentFolder.Files.Add(new Filex(name, size));
        UpdateSizes(size);
    }

}

void UpdateSizes(int size)
{
    Folder curr = currentFolder;
    bool notInRoot = true;
    while (notInRoot)
    {
        curr.Size += size;

        if (curr.Name == "/") notInRoot = false;
        else curr = curr.OpenParentFolder();
    }
}


int diskSpace = 70000000;
int spaceNeeded = 30000000;
int missingSpace = spaceNeeded - (diskSpace - root.Size);


List<Folder> SortedList = allFolders.OrderBy(o => o.Size).ToList();
string FolderToDelete()
{
    foreach (var folder in SortedList)
    {
        if (folder.Size >= missingSpace)
        {
            return $"Delete folder {folder.Name} with size {folder.Size} to free enough space.";
        }
    }
    return "lol";
}

System.Console.WriteLine(FolderToDelete());
