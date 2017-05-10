using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GetHashCertificate
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Website\\test.txt");


            //var certStr = "";
            //var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            //store.Open(OpenFlags.ReadOnly);
            //foreach (X509Certificate2 mCert in store.Certificates)
            //{
            //    certStr = "DB6D777384F295CD80710FEF3DDF9E5404D218D4";
            //    Console.WriteLine(certStr);
            //    Console.WriteLine( mCert.Thumbprint.ToUpper() + "--" + mCert.Thumbprint.Length
            //        + "--" + mCert.Thumbprint.ToUpper().Contains(certStr) + "--" + certStr.Length);
            //    file.WriteLine(mCert.Thumbprint.ToUpper());
            //}
            //Console.WriteLine("----------------------------------------");
            //foreach (X509Certificate2 mCert in store.Certificates)
            //{
            //    certStr = "A8985D3A65E5E5C4B2D7D66D40C6DD2FB19C5436";
            //    Console.WriteLine(certStr);
            //    Console.WriteLine(mCert.Thumbprint.ToUpper() + "--" + mCert.Thumbprint.Length
            //        + "--" + mCert.Thumbprint.ToUpper().Contains(certStr) + "--" + certStr.Length);
            //    file.WriteLine(mCert.Thumbprint.ToUpper());
            //}
            //Console.WriteLine("----------------------------------------");
            //foreach (X509Certificate2 mCert in store.Certificates)
            //{
            //    certStr = "A184E6449473950320A04F4DC082D310242BF980";
            //    Console.WriteLine(certStr);
            //    Console.WriteLine(mCert.Thumbprint.ToUpper() + "--" + mCert.Thumbprint.Length
            //        + "--" + mCert.Thumbprint.ToUpper().Contains(certStr) + "--" + certStr.Length);
            //    file.WriteLine(mCert.Thumbprint.ToUpper());
            //}
            //Console.WriteLine("----------------------------------------");
            //foreach (X509Certificate2 mCert in store.Certificates)
            //{
            //    certStr = "7FCD032DCBD1ABB127E75F0D8B4533364C0B7B5A";
            //    Console.WriteLine(certStr);
            //    Console.WriteLine(mCert.Thumbprint.ToUpper() + "--" + mCert.Thumbprint.Length
            //        + "--" + mCert.Thumbprint.ToUpper().Contains(certStr) + "--" + certStr.Length);
            //    file.WriteLine(mCert.Thumbprint.ToUpper());
            //}
            //Console.WriteLine("----------------------------------------");
            //foreach (X509Certificate2 mCert in store.Certificates)
            //{
            //    certStr = "2167727E19FAE519270ABEF669A29594DE87F4EB";
            //    Console.WriteLine(certStr);
            //    Console.WriteLine(mCert.Thumbprint.ToUpper() + "--" + mCert.Thumbprint.Length
            //        + "--" + mCert.Thumbprint.ToUpper().Contains(certStr) + "--" + certStr.Length);
            //    file.WriteLine(mCert.Thumbprint.ToUpper());
            //}
            //store.Close();
            //file.Close();
            Console.WriteLine(Convert(0));
            Console.ReadLine();
        }

        public static string Convert(int mins)
        {
            TimeSpan timeSpan = TimeSpan.FromMinutes(mins);
            DateTime time = DateTime.Today.Add(timeSpan);
            return time.ToString("hh:mm tt"); // It will give "03:00 AM"
        }
        
        public static string ConvertIntToTime(int minutes)
        {
            int mins = 0;
            int h = 0;
            int m = 0;
            string s = "";
            if (minutes <= 720)
            {
                mins = minutes;
                h = mins / 60;
                m = mins % 60;
                s = "" + h.ToString("00") + ":" + m.ToString("00") + "  AM";
            }
            else if (minutes > 720)
            {
                mins = minutes - 720;
                h = mins / 60;
                m = mins % 60;
                s = "" + h.ToString("00") + ":" + m.ToString("00") + "  PM";
            }

            return s;
        }
    }
}
