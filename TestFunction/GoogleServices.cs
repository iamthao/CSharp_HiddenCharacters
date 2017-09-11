using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestFunction
{
    public class GoogleServices
    {
        public static GoogleResultDirection GetDirection(GoogleMapPoint origin, GoogleMapPoint destination)
        {
            var originString = string.Format("{0},{1}", origin.Lat, origin.Lng);
            var destinationString = string.Format("{0},{1}", destination.Lat, destination.Lng);

            var requestUrl = string.Format("https://maps.google.com/maps/api/directions/json?origin={0}&destination={1}&sensor=false", originString, destinationString);

            var client = new WebClient();
            var result = client.DownloadString(requestUrl);
            return JsonConvert.DeserializeObject<GoogleResultDirection>(result);
        }

        public static GoogleGetDistance GetDistance(GoogleMapPoint origin, GoogleMapPoint destination)
        {
            var originString = string.Format("{0},{1}", origin.Lat, origin.Lng);
            var destinationString = string.Format("{0},{1}", destination.Lat, destination.Lng);

            var requestUrl = string.Format("https://maps.googleapis.com/maps/api/distancematrix/json?origins={0}&destinations={1}", originString, destinationString);
            var client = new WebClient();
            var result = client.DownloadString(requestUrl);
            return JsonConvert.DeserializeObject<GoogleGetDistance>(result);
        }

        public static GoogleGetLocation GetAddress(GoogleMapPoint origin)
        {
            var originString = string.Format("{0},{1}", origin.Lat, origin.Lng);

            var requestUrl = string.Format("https://maps.googleapis.com/maps/api/geocode/json?latlng={0}", originString);
            var client = new WebClient();
            var result = client.DownloadString(requestUrl);
            return JsonConvert.DeserializeObject<GoogleGetLocation>(result);
        }
    }
}
