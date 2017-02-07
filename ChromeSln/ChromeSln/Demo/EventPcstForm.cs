using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;

namespace Demo
{
    public class EventPcstForm
    {
        [JavascriptIgnore]
        public ChromiumWebBrowser ChromeBrowser { get; set; }

        private Action _closeForm;

        public EventPcstForm(ChromiumWebBrowser webBrwsr, Action closeForm)
        {
            ChromeBrowser = webBrwsr;
            _closeForm = closeForm;
        }

        public void Cancel(string data)
        {
            _closeForm();
            //return data;
        }
        public string Save(string data)
        {
            return data;
        }
    }
}
