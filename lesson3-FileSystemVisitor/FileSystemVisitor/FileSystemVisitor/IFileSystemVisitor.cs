using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitorProj
{
    public interface IFileSystemVisitor
    {
        IEnumerator<FileSystemInfo> GetEnumerator();
    }
}