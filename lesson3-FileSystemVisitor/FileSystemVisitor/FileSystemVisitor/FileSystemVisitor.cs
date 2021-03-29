using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileSystemVisitorProj
{
    public class FileSystemVisitor : IFileSystemVisitor
    {
        private DirectoryInfo root;
        private Logger logger;
        private Func<FileSystemInfo, bool> fileSystemFilter;

        public event EventHandler Start;
        public event EventHandler Finish;

        public event EventHandler<IterationControlArgs> FileFinded;
        public event EventHandler<IterationControlArgs> DirectoryFinded;

        public event EventHandler<IterationControlArgs> FilteredFileFinded;
        public event EventHandler<IterationControlArgs> FilteredDirectoryFinded;


        public FileSystemVisitor(string rootPath)
        {
            root = new DirectoryInfo(rootPath);
            fileSystemFilter = x => true;
            logger = LogManager.GetCurrentClassLogger();
        }

        public FileSystemVisitor(string rootPath, Func<FileSystemInfo, bool> filter)
        {
            root = new DirectoryInfo(rootPath);
            fileSystemFilter = filter;
            logger = LogManager.GetCurrentClassLogger();
        }

        public IEnumerable<FileSystemInfo> GetItems()
        {
            var args = DefaultIterationControlArgs();
            args.CurrentItem = root;
            OnEventArg(Start, args);

            var directories = GetDirectories();
            var files = GeFiles();
            var result = directories.Concat(files);

            OnEventArg(Finish, args);

            return result;
        }

        private void OnEvent(EventHandler<IterationControlArgs> triggeredEvent, IterationControlArgs args)
        {
            triggeredEvent?.Invoke(this, args);
        }

        private void OnEventArg(EventHandler triggeredEvent, EventArgs args)
        {
            triggeredEvent?.Invoke(this, args);
        }

        private IterationControlArgs DefaultIterationControlArgs()
        {
            return new IterationControlArgs { CurrentItem = null, Exclude = false, TerminateSearch = false };
        }

        private IEnumerable<FileSystemInfo> GetDirectories()
        {
            var directories = root.GetDirectories();

            foreach (var d in directories)
            {
                var args = DefaultIterationControlArgs();
                args.CurrentItem = d;
                OnEvent(DirectoryFinded, args);

                if (args.Exclude)
                {
                    logger.Warn("Folder was exclude.");
                    continue;
                }

                if (fileSystemFilter(d))
                {
                    args = DefaultIterationControlArgs();
                    args.CurrentItem = d;
                    OnEvent(FilteredDirectoryFinded, args);

                    if (args.Exclude)
                    {
                        logger.Warn("Folder was exclude.");
                        continue;
                    }
                    var newVisitor = new FileSystemVisitor(d.FullName, fileSystemFilter);
                    yield return newVisitor.root;

                    foreach (var info in newVisitor)
                    {
                        if (fileSystemFilter(info))
                            yield return info;
                    }
                }
            }
        }

        private IEnumerable<FileSystemInfo> GeFiles()
        {
            var files = root.GetFiles();

            foreach (var f in files)
            {
                var args = DefaultIterationControlArgs();
                args.CurrentItem = f;
                OnEvent(FileFinded, args);

                if (args.Exclude)
                {
                    logger.Log(LogLevel.Warn, "File was exclude.");
                    continue;
                }

                if (fileSystemFilter(f))
                {
                    args = DefaultIterationControlArgs();
                    args.CurrentItem = f;
                    OnEvent(FilteredFileFinded, args);

                    if (args.Exclude)
                    {
                        logger.Warn("File was exclude.");
                        continue;
                    }

                    yield return f;
                }
            }
        }

        public IEnumerator<FileSystemInfo> GetEnumerator()
        {
            return GetItems().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
