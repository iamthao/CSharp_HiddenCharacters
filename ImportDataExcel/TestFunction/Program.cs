using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Web.Administration;
using ModifyWebconfig;
using Newtonsoft.Json;

namespace TestFunction
{
    class Program
    {

        static void Main(string[] args)
        {
            //var origin = new GoogleMapPoint
            //{
            //    Lat = 10.8160092,
            //    Lng = 106.7068522
            //};

            //var destination = new GoogleMapPoint
            //{
            //    Lat = 10.802195,
            //    Lng = 106.650778
            //};

            //var origin1 = new GeoCoordinate(Convert.ToDouble(origin.Lat), Convert.ToDouble(origin.Lng));
            //var destination1 = new GeoCoordinate(Convert.ToDouble(destination.Lat), Convert.ToDouble(destination.Lng));

            //var metter = origin1.GetDistanceTo(destination1);
            //var miles = metter * 0.000621371;
            //var data = MetersToMiles(origin1.GetDistanceTo(destination1),2);

            //Console.WriteLine(metter);
            //Console.WriteLine(miles);
            //Console.WriteLine(data);
       
            XmlLibrary.ReadXmlToList();
            Console.WriteLine("Finished");
            Console.ReadLine();
        }

        public static double MetersToMiles( double? meters, int digits = 0)
        {
            return meters == null ? 0 : Math.Round(meters.Value * 0.000621371, digits, MidpointRounding.AwayFromZero);
        }

        
       
    }
}
