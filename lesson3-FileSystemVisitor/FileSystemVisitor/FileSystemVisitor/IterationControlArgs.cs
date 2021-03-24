using System;
using System.IO;

namespace FileSystemVisitorProj
{
    public class IterationControlArgs : EventArgs
    {
        public FileSystemInfo CurrentItem { get; set; }
        public bool TerminateSearch { get; set; }
        public bool Exclude { get; set; }
    }
}
