using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFolderToFolder
{
    public class CopyFolder
    {
        public static void CopyFolderToFolder(string pathSource, string pathDestination)
        {
            DirectoryCopy(pathSource, pathDestination);
        }

        private static void DirectoryCopy(string sourcePath, string destPath)
        {
            // Get the subdirectories for the specified directory.
            var dir = new DirectoryInfo(sourcePath);
            var dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourcePath);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destPath))
            {
                Directory.CreateDirectory(destPath);
            }

            // Get the files in the directory and copy them to the new location.
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                string temppath = Path.Combine(destPath, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            foreach (var subdir in dirs)
            {
                string temppath = Path.Combine(destPath, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }
        }

    }
}
