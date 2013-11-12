using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDrivers
{
    class Drive
    {
        private String _driveName;
        private String _drivePath;
        
        public Drive(String driveName, String drivePath)
        {
            _driveName = driveName;
            _drivePath = driveName;
        }

        public String DriveName
        {
            get { return _driveName; }
            set { _driveName = value; }
        }

        public String DrivePath
        {
            get { return _drivePath; }
            set { _drivePath = value; }
        }



    }
}
