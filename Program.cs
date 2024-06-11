
using Microsoft.VisualBasic;

string comand, path = "", path1;
DirectoryInfo dir = new DirectoryInfo(@"C:\\");
DirectoryInfo[] dirs;

while (true)
{
    Console.Write(dir.FullName+"> ");
    comand = Console.ReadLine();
    if (comand == "dirs")
    {
        Dirs(dir);
    }
    else if (comand == "files")
    {
        Files(dir);
    }
    else if (comand == "cd ..")
    {
        dir = new DirectoryInfo(Exit(dir));

    }
    else
    {
        for(int i=3;i<comand.Length;i++)
        {
            path += comand[i];
        }
        dirs = dir.GetDirectories();
        foreach (DirectoryInfo d in dirs)
        {
            if(d.Name == path)
            {
                dir = new DirectoryInfo(dir.FullName+path);
                break;
            }
        }
    }
}

static void Dirs(DirectoryInfo dir)
{
    DirectoryInfo[] dirs = dir.GetDirectories();
    foreach(var d in dirs)
    {
        Console.WriteLine(d.FullName);
    }
}

static void Files(DirectoryInfo dir)
{
    FileInfo[] files = dir.GetFiles();
    foreach (var d in files)
    {
        Console.WriteLine(d.FullName);
    }
}

static string Exit(DirectoryInfo dir)
{
    int counter = 0;
    string fullName = "";
    for(int i = dir.FullName.Length - 1; i >= 0; i--)
    {
        if(counter == 0)
        {
            if (dir.FullName[i] == char.Parse(@"\"))
            {
                counter++;
            }
        }
        else
        {
            fullName += dir.FullName[i];
        }
    }
    fullName = Strings.StrReverse(fullName) +@"\";
    Console.WriteLine(fullName);
    return fullName;
}
