using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitor.Base
{
    public interface IFileSystemVisitor : IEnumerable<FileSystemInfo>
    {
        // return Directory.EnumerateFiles(path);
        IEnumerable<string> GetFiles(string path);

        // return Directory.EnumerateDirectories(path);
        IEnumerable<string> GetDirectories(string path);

        event EventHandler Start;
        event EventHandler Finish;
        event EventHandler<IterationControlArgs> FileFinded;
        event EventHandler<IterationControlArgs> DirectoryFinded;
        event EventHandler<IterationControlArgs> FilteredFileFinded;
        event EventHandler<IterationControlArgs> FilteredDirectoryFinded;

    }
}