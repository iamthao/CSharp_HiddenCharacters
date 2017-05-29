using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace AutoDeploymentWindowsService.Hubs
{
    [HubName("BrowserFolderHub")]
    public class BrowserFolderHub : Hub
    {
        private readonly string _serverId = ConfigurationManager.AppSettings["ServerId"];

        [HubMethodName("ListLogicalDrive")]
        public void ListLogicalDrive(string serverId)
        {
            var result = new string[] { };
            if (!string.IsNullOrEmpty(serverId) && _serverId == serverId)
                result = DriveInfo.GetDrives().Select(p => p.Name).ToArray();

            Clients.Client(Context.ConnectionId).ListLogicalDrive(result);
        }

        [HubMethodName("ListFolder")]
        public void ListFolder(string serverId, string fullPath)
        {
            var result = new string[] {};
            if (!string.IsNullOrEmpty(serverId) && _serverId == serverId)
                result = Directory.GetDirectories(fullPath);

            Clients.Client(Context.ConnectionId).ListFolder(result);
        }
    }
}
