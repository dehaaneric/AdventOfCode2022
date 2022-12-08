namespace AdventOfCode2022.ConsoleApp.Day7.Models
{
    public class Directory
    {
        private List<Directory> _subDirectories = new List<Directory>();
        private List<File> _files = new List<File>();

        public int Level { get; }
        public string Name { get; }

        public Directory(int level, string name)
        {
            Level = level;
            Name = name;
        }
        public void AddSubDirectory(Directory directory)
        {
            _subDirectories.Add(directory);
        }
        public void AddFile(File file)
        {
            _files.Add(file);
        }
        public IEnumerable<Directory> SubDirectories => _subDirectories;

        public int TotalFilesSize => _files.Sum(x => x.FileSize) + _subDirectories.Sum(x=>x.TotalFilesSize);
        //public int TotalFilesSize
        //{
        //    get
        //    {
        //        var fileSize = _files.Sum(x => x.FileSize);
        //        int dirSize = 0;
        //        foreach (var subdir in _subDirectories)
        //        {
        //            dirSize += subdir.TotalFilesSize;
        //        }

        //        return fileSize + dirSize;
        //    }
        //}
    }

    public class File
    {
        public File(string name, int fileSize)
        {
            Name = name;
            FileSize = fileSize;
        }

        public string Name { get; }
        public int FileSize { get; }
    }
}
