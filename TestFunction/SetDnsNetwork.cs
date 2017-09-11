using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ProcessStartInfo = System.Diagnostics.ProcessStartInfo;

namespace TestFunction
{
    public class SetDnsNetwork
    {
        /// <summary>
        /// Set's WINS of the local machine
        /// </summary>
        /// <param name="nic">NIC Address</param>
        /// <param name="dns">Primary WINS server address</param>
        /// <remarks>Requires a reference to the System.Management namespace</remarks>
        public void SetDns(string nic, string dns)
        {
            ManagementClass objMc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMoc = objMc.GetInstances();

            foreach (var o in objMoc)
            {
                var objMo = (ManagementObject) o;
                if ((bool)objMo["IPEnabled"])
                {
                    // if you are using the System.Net.NetworkInformation.NetworkInterface you'll need to change this line to if (objMO["Caption"].ToString().Contains(NIC)) and pass in the Description property instead of the name 
                    if (objMo["Caption"].Equals(nic))
                    {
                        try
                        {
                            ManagementBaseObject newDns =
                                objMo.GetMethodParameters("SetDNSServerSearchOrder");
                            newDns["DNSServerSearchOrder"] = dns.Split(',');
                            ManagementBaseObject setDns =
                                objMo.InvokeMethod("SetDNSServerSearchOrder", newDns, null);
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
        }

        public static void RunChangeDns(string cardName,string dns1, string dns2)
        {
            ExecuteCommandLine.ExecuteCommand("netsh interface ip set dns name="+cardName+" static "+dns1);
            ExecuteCommandLine.ExecuteCommand("netsh interface ip add dns name=" + cardName + dns2 +" index=2");
            ExecuteCommandLine.ExecuteCommand("ipconfig /flushdns");         
        }
    }
}
