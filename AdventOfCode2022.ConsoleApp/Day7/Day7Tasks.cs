using AdventOfCode2022.ConsoleApp.Shared;
using AOC = AdventOfCode2022.ConsoleApp.Day7.Models;

namespace AdventOfCode2022.ConsoleApp.Day7
{
    public class Day7Tasks : BaseTask
    {
        const int SpaceOnSystem = 70_000_000;
        const int SpaceRequired = 30_000_000;

        AOC.Directory baseDir = new AOC.Directory(0, "/");
        List<int> _directoriesCollection = new List<int>();

        public Day7Tasks()
        {
            ReadFileSystem();
            FillDirectoriesCollection(baseDir, Int32.MaxValue);
        }
        public int Task1()
        {
            return _directoriesCollection.Where(x => x <= 100000).Sum(x => x);
        }

        public int Task2()
        {
            int totalSpaceInUse = GetTotalSizeInUse(baseDir);
            int unusedSpace = SpaceOnSystem - totalSpaceInUse;
            int needed = SpaceRequired - unusedSpace;

            // 21_618_835
            foreach (var directorySize in _directoriesCollection.OrderBy(x => x))
            {
                if((directorySize + unusedSpace) >= SpaceRequired)
                {
                    return directorySize;
                }
            }
            
            return 0;
        }

        private int GetTotalSizeInUse(AOC.Directory directory)
        {
            int totalSpaceInUse = directory.TotalSizeOfFiles;
            foreach (var dir in directory.SubDirectories)
            {
                totalSpaceInUse += GetTotalSizeInUse(dir);
            }

            return totalSpaceInUse;
        }

        private void ReadFileSystem()
        {
            string[] commands = base.GetInput("Day7/Day7Input1.txt");

            Stack<AOC.Directory> directoryStack = new Stack<AOC.Directory>();

            AOC.Directory currentDir = null!;

            for (int lineIndex = 0; lineIndex < commands.Length; lineIndex++)
            {
                string command = commands[lineIndex]!;

                if (string.Equals(command, "$ cd /"))
                {
                    currentDir = baseDir;
                    continue;
                }
                else if (command.StartsWith("$ cd .."))
                {
                    // Move one dir up.
                    currentDir = directoryStack.Pop();
                }
                else if (command.StartsWith("$ cd"))
                {
                    var foundDir = FindDirectory(currentDir, command);
                    if (foundDir is null)
                        throw new ApplicationException("dir not found");

                    directoryStack.Push(currentDir);
                    currentDir = foundDir!;
                }

                if (string.Equals(command, "$ ls"))
                {
                    lineIndex = ReadDirectory(currentDir, commands, lineIndex);
                    if (lineIndex == -1)
                    {
                        break;
                    }
                }
            }
        }

        Dictionary<string, int> directoryCounts = new Dictionary<string, int>();
        private void FillDirectoriesCollection(AOC.Directory dir, int limit)
        {
            directoryCounts.Add(Guid.NewGuid().ToString(), dir.TotalFilesAndDirSize);

            if (dir.TotalFilesAndDirSize < limit)
            {
                _directoriesCollection.Add(dir.TotalFilesAndDirSize);
            }

            foreach (var subdir in dir.SubDirectories)
            {
                FillDirectoriesCollection(subdir, limit);
            }
        }

        private AOC.Directory FindDirectory(AOC.Directory dir, string command)
        {
            var directoryName = command.Split(' ')[2];

            foreach (var subDir in dir.SubDirectories)
            {
                if (subDir.Name == directoryName)
                    return subDir;
            }

            throw new ApplicationException("Directory not found!");
        }
        private int ReadDirectory(AOC.Directory currentDir, string[] commands, int lineIndex)
        {
            for (int index = lineIndex + 1; index < commands.Length; index++)
            {
                string command = commands[index];
                if (command.StartsWith("dir "))
                {
                    var directory = new AOC.Directory((currentDir.Level + 1), command.Split(' ')[1]);
                    currentDir.AddSubDirectory(directory);
                }
                else if (command.StartsWith('$'))
                {
                    return index - 1;
                }
                else
                {
                    //14848514 b.txt
                    var fileDetails = command.Split(' ');
                    currentDir.AddFile(new AOC.File(fileDetails[1], int.Parse(fileDetails[0])));
                }
            }

            // End of program?
            return -1;
        }
    }
}
