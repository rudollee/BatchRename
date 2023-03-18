using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path = Directory.GetCurrentDirectory();
        string oldName = "";
        string newName = "";

        if (args.Length == 3)
        {
            path = args[0];
            oldName = args[1];
            newName = args[2];
        }
        else if (args.Length == 2)
        {
            oldName = args[0];
            newName = args[1];
        }
        else
        {
            Console.WriteLine("Usage: batchRename.exe [path] oldpart newpart");
            return;
        }

        DirectoryInfo directory = new DirectoryInfo(path);
        FileInfo[] files = directory.GetFiles();

        foreach (FileInfo file in files)
        {
            if (file.Name.Contains(oldName))
            {
                string newFileName = file.Name.Replace(oldName, newName);
                file.MoveTo(Path.Combine(file.DirectoryName, newFileName));
            }
        }
    }
}