using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFunction
{
    [Serializable]
    public class GoogleMapPoint
    {
        public double Lat { get; set; }
        public double Lng { get; set; }

        public GoogleMapPoint(double lat, double lng)
        {
            Lat = lat;
            Lng = lng;
        }

        public GoogleMapPoint()
        {
            // TODO: Complete member initialization
        }
    }
}
