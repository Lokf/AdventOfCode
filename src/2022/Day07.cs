using System.Collections;

namespace Lokf.AdventOfCode2022;

public static partial class Day07
{
    public static long Task1(IEnumerable<string> lines)
    {
        var root = Parse(lines.ToArray());

        return root
            .Where(directory => directory.CaluculteTotalSize() <= 100000)
            .Sum(directory => directory.CaluculteTotalSize());
    }

    public static long Task2(IEnumerable<string> lines)
    {
        var root = Parse(lines.ToArray());
        var totalSize = root.CaluculteTotalSize();
        var unused = 70_000_000 - totalSize;
        var neededToRemove = 30_000_000 - unused;

        return root
            .Select(directory => directory.CaluculteTotalSize())
            .Where(size => size >= neededToRemove)
            .Min();
    }

    private static Directory Parse(string[] lines)
    {
        var lineNumber = 0;
        if (lines[lineNumber] != "$ cd /")
        {
            throw new ArgumentException("Invalid input", nameof(lines));
        }

        var root = new Directory("/");
        var currentDirectory = root;
        lineNumber++;

        while (lineNumber < lines.Length)
        {
            if (lines[lineNumber] == "$ ls")
            {
                while (true)
                {
                    lineNumber++;
                    if ((lineNumber == lines.Length))
                    {
                        return root;
                    }
                    if (lines[lineNumber].StartsWith("dir"))
                    {
                        var name = lines[lineNumber][4..];
                        var directory = new Directory(name);
                        currentDirectory.AddSubDirectory(directory);
                        continue;
                    }
                    if (lines[lineNumber].StartsWith("$"))
                    {
                        break;
                    }
                    var fileInfo = lines[lineNumber].Split(' ');
                    currentDirectory.AddFile(int.Parse(fileInfo[0]));
                }
            }
            else if (lines[lineNumber] == "$ cd ..")
            {
                lineNumber++;
                currentDirectory = currentDirectory.Parent;
            }
            else if (lines[lineNumber].StartsWith("$ cd "))
            {
                var name = lines[lineNumber][5..];
                lineNumber++;
                currentDirectory = currentDirectory.GoToSubDirectory(name);
            }
        }

        return root;
    }

    private sealed class Directory : IEnumerable<Directory>
    {
        private readonly string name;
        private Directory? parent;
        private readonly List<int> files = new();
        private readonly Dictionary<string, Directory> subDirectories = new();

        public Directory(string name)
        {
            this.name = name;
        }

        public Directory Parent => parent!;

        public void AddFile(int fileSize)
        {
            files.Add(fileSize);
        }

        public void AddSubDirectory(Directory directory)
        {
            directory.parent = this;
            subDirectories.Add(directory.name, directory);
        }

        public Directory GoToSubDirectory(string name)
        {
            return subDirectories[name];
        }

        public long CaluculteTotalSize()
        {
            return subDirectories.Values.Sum(directory => directory.CaluculteTotalSize()) + files.Sum();
        }

        public IEnumerator<Directory> GetEnumerator()
        {
            yield return this;
            foreach (var subDirectory in subDirectories.Values)
            {
                // I wish for yield return IEnumerable syntax...
                foreach (var directory in subDirectory)
                {
                    yield return directory;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
