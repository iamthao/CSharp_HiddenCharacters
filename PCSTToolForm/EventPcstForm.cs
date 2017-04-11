using System;
using System.Diagnostics;
using CefSharp;
using CefSharp.WinForms;

namespace PCSTToolForm
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

        public void Cancel()
        {
            _closeForm();
        }
    }
   
}
