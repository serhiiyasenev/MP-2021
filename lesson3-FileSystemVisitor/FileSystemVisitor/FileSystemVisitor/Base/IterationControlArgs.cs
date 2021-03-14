using System.IO;

namespace FileSystemVisitor.Base
{
    public class IterationControlArgs
    {
        public FileSystemInfo CurrentFile { get; set; }
        public bool TerminateSearch { get; set; }
        public bool Exclude { get; set; }
    }
}
