using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Chef_Plus
{
    public static class SystemAdmin
    {
        public static string IdentifyThisComputer()
        {
            string sProcessorID = "";
            string sQuery = "SELECT ProcessorId FROM Win32_Processor";
            ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);
            ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();
            foreach (ManagementObject oManagementObject in oCollection)
            {
                sProcessorID = (string)oManagementObject["ProcessorId"];
            }
            string drive = System.Environment.CurrentDirectory.Substring(0, 1);
            ManagementObject dsk = new ManagementObject(
                @"win32_logicaldisk.deviceid=""" + drive + @":""");
            dsk.Get();
            string volumeSerial = dsk["VolumeSerialNumber"].ToString();
            return sProcessorID + volumeSerial;
        }
    }
}
