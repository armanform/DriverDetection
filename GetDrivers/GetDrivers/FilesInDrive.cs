using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GetDrivers
{
    class FilesInDrive
    {

        /*
         * Get collection of files in the specified folder
         */ 
        public static Drive[] getCollection(String driveName)
        {

            DirectoryInfo dirInfo = new DirectoryInfo(@driveName);

            FileInfo[] fileNames = dirInfo.GetFiles("*.*");

            Drive[] driveCol = new Drive[fileNames.Length];

            int i = 0;
            foreach (FileInfo fi in fileNames)
            {
                driveCol[i] = new Drive(fi.Name, fi.FullName);
                i++;
            }

            return driveCol;
        }


        /*
         * Get collection of directories in the specified folder
         */ 
        public static String[] getDirectories(String path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@path);
            // Get a reference to each directory in that directory.
            DirectoryInfo[] diArr = dirInfo.GetDirectories();

            String[] directories = new String[diArr.Length];

            int i = 0;
            foreach (DirectoryInfo dri in diArr)
            {
                directories[i] = dri.Name;
                i++;
            }
            
            return directories;
        }
    }
}
