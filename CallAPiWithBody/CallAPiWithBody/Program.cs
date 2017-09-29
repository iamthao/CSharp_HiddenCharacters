using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CallAPiWithBody
{
    class Program
    {
        static void Main(string[] args)
        {
            var page = 1;
            var pageSize = 1;
            var pageTotal = 1;
            var componentKeys = "org.sonarqube:idaho";//
            var url = string.Format("http://sonarqube.caminois.local/api/issues/search?p={0}&ps={1}&componentKeys={2}", 1, 1, componentKeys);
            //Get total to paging
            var data = GetData(url);
            var dataConvert = JsonConvert.DeserializeObject<SonarIssue>(data);
            if (dataConvert.total > 0)
            {
                pageSize = 100;//

                if (dataConvert.total / pageSize >= 1)
                {
                    pageTotal = dataConvert.total / pageSize;
                }

                if (pageTotal * pageSize < dataConvert.total)
                {
                    pageTotal = pageTotal + 1;
                }
            }

            var listReport = new List<ReportIssue>();            

            for (int i = 0; i < pageTotal; i++)
            {
                var urlGet = string.Format("http://sonarqube.caminois.local/api/issues/search?p={0}&ps={1}&componentKeys={2}", i + 1, pageSize, componentKeys);
                var dataGet = GetData(urlGet);
                if (!string.IsNullOrEmpty(dataGet))
                {
                    var dataGetConvert = JsonConvert.DeserializeObject<SonarIssue>(dataGet);
                    if (dataGetConvert.issues != null && dataGetConvert.issues.Count > 0)
                    {
                        foreach (var item in dataGetConvert.issues)
                        {
                            listReport.Add(new ReportIssue
                            {
                                Component = item.component,
                                Line = item.line.ToString(),
                                Message = item.message,
                                Type = item.type,
                                Author = item.author,
                                Severity = item.severity
                            });
                        }
                    }
                }

            }
            var path = @"D:\\issue_idaho.csv";//
            File.WriteAllText(path, String.Empty);
            using (StreamWriter stream = File.AppendText(path))
            {
                stream.WriteLine("File,Line,Message,Type,Severity,Author");
                foreach (var item in listReport)
                {
                    stream.WriteLine(CreateLine(item));
                }                           
            }

            Console.WriteLine("Successfully");
            Console.ReadLine();
        }

        public static string CreateLine(ReportIssue data)
        {
            return data.FileName + "," + data.Line + ",\"" + data.Message + "\"," + data.Type + "," + data.Severity + "," + data.Author;
        }
        public static string GetData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }      
    }

    public class Paging
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }

    public class TextRange
    {
        public int startLine { get; set; }
        public int endLine { get; set; }
        public int startOffset { get; set; }
        public int endOffset { get; set; }
    }

    public class Issue
    {
        public string organization { get; set; }
        public string key { get; set; }
        public string rule { get; set; }
        public string severity { get; set; }
        public string component { get; set; }
        public string project { get; set; }
        public string subProject { get; set; }
        public int line { get; set; }
        public TextRange textRange { get; set; }
        public List<object> flows { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string effort { get; set; }
        public string debt { get; set; }
        public string author { get; set; }
        public List<string> tags { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updateDate { get; set; }
        public string type { get; set; }
    }

    public class Component
    {
        public string organization { get; set; }
        public string key { get; set; }
        public string uuid { get; set; }
        public bool enabled { get; set; }
        public string qualifier { get; set; }
        public string name { get; set; }
        public string longName { get; set; }
        public string path { get; set; }
    }

    public class SonarIssue
    {
        public int total { get; set; }
        public int p { get; set; }
        public int ps { get; set; }
        public Paging paging { get; set; }
        public List<Issue> issues { get; set; }
        public List<Component> components { get; set; }
    }

    public class ReportIssue
    {
        public string Component { get; set; }
        public string FileName
        {
            get
            {
                if (!string.IsNullOrEmpty(Component))
                {
                    var arr = Component.Split(':');
                    if (arr.Count() == 6)
                    {
                        if (!string.IsNullOrEmpty(arr[5]))
                        {
                            return arr[5];
                        }
                    }
                }

                return "";
            }
        }
        public string Line { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public string Author { get; set; }
        public string Severity { get; set; }
    }
}
