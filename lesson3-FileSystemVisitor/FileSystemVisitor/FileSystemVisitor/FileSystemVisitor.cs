using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemVisitorProj
{
    public class FileSystemVisitor : IFileSystemVisitor
    {
        private DirectoryInfo root;
        private Logger logger;
        private Func<FileSystemInfo, bool> fileSystemFilter;
        private bool terminateSearch;
        private bool exclude;

        public event EventHandler<IterationControlArgs> Start;
        public event EventHandler<IterationControlArgs> Finish;
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

        
        public IEnumerator<FileSystemInfo> GetEnumerator()
        {
            if (terminateSearch)
            {
                logger.Info("The end search.");
                yield break;
            }

            IterationControlArgs args = DefaultIterationControlArgs();
            args.CurrentFile = root;
            OnEvent(Start, args);
            if (args.TerminateSearch)
            {
                terminateSearch = true;
                logger.Info("The end search.");
                yield break;
            }

            if (!args.Exclude)
            {
                if (fileSystemFilter(root))
                    yield return root;

                // Get Directories
                foreach (DirectoryInfo d in root.GetDirectories())
                {
                    args = DefaultIterationControlArgs();
                    args.CurrentFile = d;
                    OnEvent(DirectoryFinded, args);
                    if (args.TerminateSearch)
                    {
                        terminateSearch = true;
                        logger.Info("The end search.");
                        yield break;
                    }
                    if (args.Exclude)
                    {
                        logger.Warn("Folder was exclude.");
                        continue;
                    }

                    if (fileSystemFilter(d))
                    {
                        args = DefaultIterationControlArgs();
                        args.CurrentFile = d;
                        OnEvent(FilteredDirectoryFinded, args);
                        if (args.TerminateSearch)
                        {
                            terminateSearch = true;
                            logger.Info("The end search.");
                            yield break;
                        }
                        if (args.Exclude)
                        {
                            logger.Warn("Folder was exclude.");
                            continue;
                        }
                    }
                    var newVisitor = new FileSystemVisitor(d.FullName, fileSystemFilter);
                    InheritAllEvents(newVisitor);
                    foreach (var info in newVisitor)
                    {
                        if (fileSystemFilter(info))
                            yield return info;
                    }
                }

                // Get Files
                foreach (FileInfo f in root.GetFiles())
                {
                    args = DefaultIterationControlArgs();
                    args.CurrentFile = f;
                    OnEvent(FileFinded, args);
                    if (args.TerminateSearch)
                    {
                        terminateSearch = true;
                        logger.Info("The end search.");
                        yield break;
                    }
                    if (args.Exclude)
                    {
                        logger.Log(LogLevel.Warn, "Folder was exclude.");
                        continue;
                    }

                    if (fileSystemFilter(f))
                    {
                        args = DefaultIterationControlArgs();
                        args.CurrentFile = f;
                        OnEvent(FilteredFileFinded, args);
                        if (args.TerminateSearch)
                        {
                            terminateSearch = true;
                            logger.Info("The end search.");
                            yield break;
                        }
                        if (args.Exclude)
                        {
                            logger.Warn("Folder was exclude.");
                            continue;
                        }

                        yield return f;
                    }
                }
            }
            args = DefaultIterationControlArgs();
            OnEvent(Finish, args);
            if (args.TerminateSearch)
            {
                terminateSearch = true;
                logger.Info("The end search.");
            }
        }

        private void OnEvent(EventHandler<IterationControlArgs> triggeredEvent, IterationControlArgs args)
        {
            triggeredEvent?.Invoke(this, args);
        }

        private IterationControlArgs DefaultIterationControlArgs()
        {
            return new IterationControlArgs { CurrentFile = null, Exclude = false, TerminateSearch = false };
        }

        private void InheritAllEvents(FileSystemVisitor newVisitor)
        {
            newVisitor.terminateSearch         = terminateSearch;
            newVisitor.FileFinded              = FileFinded;
            newVisitor.FilteredFileFinded      = FilteredFileFinded;
            newVisitor.DirectoryFinded         = DirectoryFinded;
            newVisitor.FilteredDirectoryFinded = FilteredDirectoryFinded;
        }
    }
}
