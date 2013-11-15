using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using System.Net.Sockets;
using System.Threading;

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

        public static void sendBySocket(Drive[] drivers, String fileName)
        {
            Drive a = null;
            for (int i = 0; i < drivers.Length; i++)
            {
                if (drivers[i].DriveName == fileName) a = drivers[i];
            }
            string json = JsonConvert.SerializeObject(a, Formatting.Indented);

            //Console.WriteLine("Client started");
            int port = 8000;
            TcpClient client = new TcpClient("127.0.0.1", port);
            Stream str = client.GetStream();
            //Console.WriteLine("Client connected.");
            StreamReader reader = new StreamReader(str);
            StreamWriter writer = new StreamWriter(str);
            writer.AutoFlush = true;
            writer.WriteLine(json);

            str.Close();
            client.Close();

        }
    }
}
