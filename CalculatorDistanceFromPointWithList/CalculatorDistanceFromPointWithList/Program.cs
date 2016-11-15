using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorDistanceFromPointWithList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LocationReportGridVo> lisLocation = new List<LocationReportGridVo>
            {
                new LocationReportGridVo
                {
                    Id = 1,
                    Name = "Galaxy Tân Bình",
                    Lat = 10.790272417561814,
                    Lng = 106.64074074603275
                },               
                new LocationReportGridVo
                {
                    Id = 2,
                    Name = "An Đông Market",
                    Lat = 10.7572475,
                    Lng = 106.67367820000004
                },
                new LocationReportGridVo
                {
                    Id = 3,
                    Name = "Công viên Gia Định",
                    Lat = 10.8174889,
                    Lng = 106.68405370000005
                },
                new LocationReportGridVo
                {
                    Id = 4,
                    Name = "AEON MALL Bình Dương",
                    Lat = 10.9303774,
                    Lng = 106.711229399999
                },
                new LocationReportGridVo
                {
                    Id = 5,
                    Name = "Khu công nghiệp Linh Trung",
                    Lat = 10.868236,
                    Lng = 106.780244999999
                },
                new LocationReportGridVo
                {
                    Id = 6,
                    Name = "Siêu thị BigC Đồng Nai",
                    Lat = 10.9175772,
                    Lng = 106.861351799999
                },
                new LocationReportGridVo
                {
                    Id = 7,
                    Name = "Công Viên Văn Hóa Đầm Sen",
                    Lat = 10.769192,
                    Lng = 106.638222
                },
                 new LocationReportGridVo
                {
                    Id = 8,
                    Name = "Chung cư Thủy Lợi 4",
                    Lat = 10.8166403,
                    Lng = 106.68356770000003
                },
            };

            GoogleMapPoint point1 = new GoogleMapPoint
            {
                Name = "19/5B Nguyễn Xí, phường 26, Bình Thạnh, Hồ Chí Minh, Vietnam",
                Lat = 10.81599833910429,
                Lng = 106.7068174482386,
            };

            GoogleMapPoint point2= new GoogleMapPoint
            {
                Name = "Chung cư Thủy Lợi 4, 205 Nguyễn Xí, phường 26, Bình Thạnh, Hồ Chí Minh, Vietnam",
                Lat = 10.81583315,
                Lng = 106.70699653,
            };

            GoogleMapPoint point3 = new GoogleMapPoint
            {
                Name = "79/5/E17 Nguyễn Xí, phường 26, Bình Thạnh, Hồ Chí Minh, Vietnam",
                Lat = 10.81561498,
                Lng = 106.70608645,
            };
            GoogleMapPoint point4 = new GoogleMapPoint
            {
                Name = "79/5BX45 Nguyễn Xí, phường 26, Bình Thạnh, Hồ Chí Minh, Vietnam",
                Lat = 10.81612603739911,
                Lng = 106.7067881115775,
            };

            Caculator(point4,lisLocation);
            Console.WriteLine("---------------");
            //Caculator(point2, lisLocation);
            Console.WriteLine("---------------");
            //Caculator(point3, lisLocation);

            Console.ReadLine();
        }

        private static void Caculator(GoogleMapPoint point, List<LocationReportGridVo> listLocation)
        {
            var minDistance = 2.0;
            var distanceChange = false;
            var nameLocation = "";
            foreach (var item in listLocation)
            {
                if (item.Lat != null && item.Lat != 0 && item.Lng != null && item.Lng != 0)
                {
                    var origin = new GeoCoordinate(Convert.ToDouble(point.Lat), Convert.ToDouble(point.Lng));
                    var destination = new GeoCoordinate(Convert.ToDouble(item.Lat), Convert.ToDouble(item.Lng));
                    var dis = MetersToMiles(origin.GetDistanceTo(destination),7);
                    var dis2 = MetersToMiles(origin.GetDistanceTo(destination),2);
                    Console.WriteLine(point.Name + " - " + item.Name + ": " + dis2 + " - " + dis);
                    //if (distance <= minDistance)
                    //{
                    //    minDistance = distance;
                    //    nameLocation = item.Name;
                    //    distanceChange = true;
                    //}
                }

            }

            
        }
        public static double MetersToMiles( double? meters, int digits = 0)
        {
            return meters == null ? 0 : Math.Round(meters.Value * 0.000621371, digits);
        }
    }

     
        public class LocationReportGridVo
    {
        public int Id { get; set; }
        public string Name { get; set; }       
        public double? Lat { get; set; }
        public double? Lng { get; set; }

    }

        public class GoogleMapPoint
        {
            public double Lat { get; set; }
            public double Lng { get; set; }
            public string Name { get; set; }

            public GoogleMapPoint(double lat, double lng, string name)
            {
                Lat = lat;
                Lng = lng;
                Name = name;
            }

            public GoogleMapPoint()
            {
                // TODO: Complete member initialization
            }
        }
}
