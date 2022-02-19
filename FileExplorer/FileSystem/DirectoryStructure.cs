using FileExplorer.FileSystem.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileExplorer.FileSystem
{
    public static class DirectoryStructure
    {
        public static List<DataItem> GetLogicalDrives()
        {
            var drives = DriveInfo.GetDrives();

            // This is only called once so set FullPath with the VolumeLabel, in DataItemViewModel I substring the actual drive name for the expanded items...
            foreach (var drive in drives)
            {
                System.Console.WriteLine($"Checking drive {drive}");
                if (!drive.IsReady)
                {
                    if (!drive.RootDirectory.Exists)
                    {
                        System.Console.WriteLine($"Drive does not exist \"{drive}\"");
                    }
                }
                System.Console.WriteLine($"Drive \"{drive}\" is now ready!");
            }


            var result = drives
                .Where(drive => drive.IsReady && drive.RootDirectory.Exists)
                .Select(x => new DataItem
                {
                    FullPath = x.Name,
                    Type = DataType.Drive
                }).ToList();

            return result;
        }

        public static string GetFileOrFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            var normalizedPath = path.Replace('/', '\\');
            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
            {
                return path;
            }

            return path.Substring(lastIndex + 1);
        }

        public static List<DataItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DataItem>();

            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                {
                    items.AddRange(dirs.Select(dir => new DataItem
                    {
                        FullPath = dir,
                        Type = DataType.FolderClosed
                    }));
                }
            }
            catch
            {
                //TODO: handle exception.
            }

            try
            {
                var files = Directory.GetFiles(fullPath);

                if (files.Length > 0)
                {
                    items.AddRange(files.Select(dir => new DataItem
                    {
                        FullPath = dir,
                        Type = DataType.File
                    }));
                }
            }
            catch
            {
                //TODO: handle exception.
            }

            return items;
        }
    }
}
