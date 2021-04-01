using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitorProj
{
    public interface IFileSystemVisitor : IEnumerable<FileSystemInfo>
    {
        IEnumerable<FileSystemInfo> GetItems();


        event EventHandler Start;
        event EventHandler Finish;

        event EventHandler<IterationControlArgs> FileFinded;
        event EventHandler<IterationControlArgs> DirectoryFinded;
        event EventHandler<IterationControlArgs> FilteredFileFinded;
        event EventHandler<IterationControlArgs> FilteredDirectoryFinded;
    }
}