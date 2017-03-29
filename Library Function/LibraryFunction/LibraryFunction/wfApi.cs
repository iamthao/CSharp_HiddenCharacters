
namespace LibraryFunction
{
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "wfApiSoap", Namespace = "http://faxcoreserver/services/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(object[]))]
    public partial class wfApi : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback AuthenticateUserOperationCompleted;

        private System.Threading.SendOrPostCallback ServerStatusOperationCompleted;

        private System.Threading.SendOrPostCallback SendMessageOperationCompleted;

        private System.Threading.SendOrPostCallback SendMixedModeOperationCompleted;

        private System.Threading.SendOrPostCallback SendMessage1OperationCompleted;

        private System.Threading.SendOrPostCallback DelegateMessageOperationCompleted;

        private System.Threading.SendOrPostCallback GetMessageDetailsOperationCompleted;

        private System.Threading.SendOrPostCallback GetMessageStatusOperationCompleted;

        private System.Threading.SendOrPostCallback IsMessageDeletedOperationCompleted;

        private System.Threading.SendOrPostCallback DeleteMessageOperationCompleted;

        private System.Threading.SendOrPostCallback CancelMessageOperationCompleted;

        private System.Threading.SendOrPostCallback RetryFailedOperationCompleted;

        private System.Threading.SendOrPostCallback ForwardToUserOperationCompleted;

        private System.Threading.SendOrPostCallback AssignMessageOperationCompleted;

        private System.Threading.SendOrPostCallback GetMessageListOperationCompleted;

        private System.Threading.SendOrPostCallback GetMessageList1OperationCompleted;

        private System.Threading.SendOrPostCallback GetMessageList2OperationCompleted;

        private System.Threading.SendOrPostCallback GetMessageList3OperationCompleted;

        private System.Threading.SendOrPostCallback CreateUserOperationCompleted;

        private System.Threading.SendOrPostCallback CreateUser1OperationCompleted;

        private System.Threading.SendOrPostCallback UpdateUserOperationCompleted;

        private System.Threading.SendOrPostCallback UpdateUser1OperationCompleted;

        private System.Threading.SendOrPostCallback UpdateUser2OperationCompleted;

        private System.Threading.SendOrPostCallback RemoveUserOperationCompleted;

        private System.Threading.SendOrPostCallback DeactivateUserOperationCompleted;

        private System.Threading.SendOrPostCallback DeactivateUsersOperationCompleted;

        private System.Threading.SendOrPostCallback ActivateUserOperationCompleted;

        private System.Threading.SendOrPostCallback ActivateUsersOperationCompleted;

        private System.Threading.SendOrPostCallback CreateInboundRouteOperationCompleted;

        private System.Threading.SendOrPostCallback DownloadMessageByteOperationCompleted;

        private System.Threading.SendOrPostCallback DownloadMessageByte1OperationCompleted;

        private System.Threading.SendOrPostCallback DownloadMessageByte2OperationCompleted;

        private System.Threading.SendOrPostCallback DownloadMessageByte3OperationCompleted;

        private bool useDefaultCredentialsSetExplicitly;

        /// <remarks/>
        public wfApi()
        {
            this.Url = "http://10.11.120.44/webservices/wfapi.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true))
            {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else
            {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        public new string Url
        {
            get
            {
                return base.Url;
            }
            set
            {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true)
                            && (this.useDefaultCredentialsSetExplicitly == false))
                            && (this.IsLocalFileSystemWebService(value) == false)))
                {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }

        public new bool UseDefaultCredentials
        {
            get
            {
                return base.UseDefaultCredentials;
            }
            set
            {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }

        /// <remarks/>
        public event AuthenticateUserCompletedEventHandler AuthenticateUserCompleted;

        /// <remarks/>
        public event ServerStatusCompletedEventHandler ServerStatusCompleted;

        /// <remarks/>
        public event SendMessageCompletedEventHandler SendMessageCompleted;

        /// <remarks/>
        public event SendMixedModeCompletedEventHandler SendMixedModeCompleted;

        /// <remarks/>
        public event SendMessage1CompletedEventHandler SendMessage1Completed;

        /// <remarks/>
        public event DelegateMessageCompletedEventHandler DelegateMessageCompleted;

        /// <remarks/>
        public event GetMessageDetailsCompletedEventHandler GetMessageDetailsCompleted;

        /// <remarks/>
        public event GetMessageStatusCompletedEventHandler GetMessageStatusCompleted;

        /// <remarks/>
        public event IsMessageDeletedCompletedEventHandler IsMessageDeletedCompleted;

        /// <remarks/>
        public event DeleteMessageCompletedEventHandler DeleteMessageCompleted;

        /// <remarks/>
        public event CancelMessageCompletedEventHandler CancelMessageCompleted;

        /// <remarks/>
        public event RetryFailedCompletedEventHandler RetryFailedCompleted;

        /// <remarks/>
        public event ForwardToUserCompletedEventHandler ForwardToUserCompleted;

        /// <remarks/>
        public event AssignMessageCompletedEventHandler AssignMessageCompleted;

        /// <remarks/>
        public event GetMessageListCompletedEventHandler GetMessageListCompleted;

        /// <remarks/>
        public event GetMessageList1CompletedEventHandler GetMessageList1Completed;

        /// <remarks/>
        public event GetMessageList2CompletedEventHandler GetMessageList2Completed;

        /// <remarks/>
        public event GetMessageList3CompletedEventHandler GetMessageList3Completed;

        /// <remarks/>
        public event CreateUserCompletedEventHandler CreateUserCompleted;

        /// <remarks/>
        public event CreateUser1CompletedEventHandler CreateUser1Completed;

        /// <remarks/>
        public event UpdateUserCompletedEventHandler UpdateUserCompleted;

        /// <remarks/>
        public event UpdateUser1CompletedEventHandler UpdateUser1Completed;

        /// <remarks/>
        public event UpdateUser2CompletedEventHandler UpdateUser2Completed;

        /// <remarks/>
        public event RemoveUserCompletedEventHandler RemoveUserCompleted;

        /// <remarks/>
        public event DeactivateUserCompletedEventHandler DeactivateUserCompleted;

        /// <remarks/>
        public event DeactivateUsersCompletedEventHandler DeactivateUsersCompleted;

        /// <remarks/>
        public event ActivateUserCompletedEventHandler ActivateUserCompleted;

        /// <remarks/>
        public event ActivateUsersCompletedEventHandler ActivateUsersCompleted;

        /// <remarks/>
        public event CreateInboundRouteCompletedEventHandler CreateInboundRouteCompleted;

        /// <remarks/>
        public event DownloadMessageByteCompletedEventHandler DownloadMessageByteCompleted;

        /// <remarks/>
        public event DownloadMessageByte1CompletedEventHandler DownloadMessageByte1Completed;

        /// <remarks/>
        public event DownloadMessageByte2CompletedEventHandler DownloadMessageByte2Completed;

        /// <remarks/>
        public event DownloadMessageByte3CompletedEventHandler DownloadMessageByte3Completed;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/AuthenticateUser", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public long AuthenticateUser(string userName, string password)
        {
            object[] results = this.Invoke("AuthenticateUser", new object[] {
                        userName,
                        password});
            return ((long)(results[0]));
        }

        /// <remarks/>
        public void AuthenticateUserAsync(string userName, string password)
        {
            this.AuthenticateUserAsync(userName, password, null);
        }

        /// <remarks/>
        public void AuthenticateUserAsync(string userName, string password, object userState)
        {
            if ((this.AuthenticateUserOperationCompleted == null))
            {
                this.AuthenticateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAuthenticateUserOperationCompleted);
            }
            this.InvokeAsync("AuthenticateUser", new object[] {
                        userName,
                        password}, this.AuthenticateUserOperationCompleted, userState);
        }

        private void OnAuthenticateUserOperationCompleted(object arg)
        {
            if ((this.AuthenticateUserCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AuthenticateUserCompleted(this, new AuthenticateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/ServerStatus", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ServerStatus()
        {
            object[] results = this.Invoke("ServerStatus", new object[0]);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void ServerStatusAsync()
        {
            this.ServerStatusAsync(null);
        }

        /// <remarks/>
        public void ServerStatusAsync(object userState)
        {
            if ((this.ServerStatusOperationCompleted == null))
            {
                this.ServerStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnServerStatusOperationCompleted);
            }
            this.InvokeAsync("ServerStatus", new object[0], this.ServerStatusOperationCompleted, userState);
        }

        private void OnServerStatusOperationCompleted(object arg)
        {
            if ((this.ServerStatusCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ServerStatusCompleted(this, new ServerStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/SendCompleteMessage", RequestElementName = "SendCompleteMessage", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "SendCompleteMessageResponse", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("SendCompleteMessageResult")]
        public string SendMessage(
                    long userID,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    string scheduleDate,
                    int priority,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    string[] trackLabel,
                    string[] trackValue,
                    string[] recpName,
                    string[] recpCompName,
                    string[] recpAddress,
                    bool[] recpRawFax,
                    string[] recpNotifyAddr,
                    bool[] recpIsRRFOn,
                    bool[] recpIsRRSOn,
                    string[] documentName,
                    string[] documentPath,
                    object[] documentBytes,
                    bool[] documentIsMerge)
        {
            var results = this.Invoke("SendMessage", new object[] {
                        userID,
                        senderName,
                        senderCompName,
                        subject,
                        note,
                        billingCode,
                        scheduleDate,
                        priority,
                        isOnHold,
                        mss,
                        msf,
                        trackLabel,
                        trackValue,
                        recpName,
                        recpCompName,
                        recpAddress,
                        recpRawFax,
                        recpNotifyAddr,
                        recpIsRRFOn,
                        recpIsRRSOn,
                        documentName,
                        documentPath,
                        documentBytes,
                        documentIsMerge});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void SendMessageAsync(
                    long userID,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    string scheduleDate,
                    int priority,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    string[] trackLabel,
                    string[] trackValue,
                    string[] recpName,
                    string[] recpCompName,
                    string[] recpAddress,
                    bool[] recpRawFax,
                    string[] recpNotifyAddr,
                    bool[] recpIsRRFOn,
                    bool[] recpIsRRSOn,
                    string[] documentName,
                    string[] documentPath,
                    object[] documentBytes,
                    bool[] documentIsMerge)
        {
            this.SendMessageAsync(userID, senderName, senderCompName, subject, note, billingCode, scheduleDate, priority, isOnHold, mss, msf, trackLabel, trackValue, recpName, recpCompName, recpAddress, recpRawFax, recpNotifyAddr, recpIsRRFOn, recpIsRRSOn, documentName, documentPath, documentBytes, documentIsMerge, null);
        }

        /// <remarks/>
        public void SendMessageAsync(
                    long userID,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    string scheduleDate,
                    int priority,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    string[] trackLabel,
                    string[] trackValue,
                    string[] recpName,
                    string[] recpCompName,
                    string[] recpAddress,
                    bool[] recpRawFax,
                    string[] recpNotifyAddr,
                    bool[] recpIsRRFOn,
                    bool[] recpIsRRSOn,
                    string[] documentName,
                    string[] documentPath,
                    object[] documentBytes,
                    bool[] documentIsMerge,
                    object userState)
        {
            if ((this.SendMessageOperationCompleted == null))
            {
                this.SendMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMessageOperationCompleted);
            }
            this.InvokeAsync("SendMessage", new object[] {
                        userID,
                        senderName,
                        senderCompName,
                        subject,
                        note,
                        billingCode,
                        scheduleDate,
                        priority,
                        isOnHold,
                        mss,
                        msf,
                        trackLabel,
                        trackValue,
                        recpName,
                        recpCompName,
                        recpAddress,
                        recpRawFax,
                        recpNotifyAddr,
                        recpIsRRFOn,
                        recpIsRRSOn,
                        documentName,
                        documentPath,
                        documentBytes,
                        documentIsMerge}, this.SendMessageOperationCompleted, userState);
        }

        private void OnSendMessageOperationCompleted(object arg)
        {
            if ((this.SendMessageCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMessageCompleted(this, new SendMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/SendMixedMode", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SendMixedMode(
                    string userID,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    int priority,
                    string scheduleDate,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    bool useDefaultNotify,
                    bool useDefaultCP,
                    MsgDocument[] documents,
                    MsgRecipient[] recipients,
                    MsgTracking[] trackings)
        {
            object[] results = this.Invoke("SendMixedMode", new object[] {
                        userID,
                        senderName,
                        senderCompName,
                        subject,
                        note,
                        billingCode,
                        priority,
                        scheduleDate,
                        isOnHold,
                        mss,
                        msf,
                        useDefaultNotify,
                        useDefaultCP,
                        documents,
                        recipients,
                        trackings});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void SendMixedModeAsync(
                    string userID,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    int priority,
                    string scheduleDate,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    bool useDefaultNotify,
                    bool useDefaultCP,
                    MsgDocument[] documents,
                    MsgRecipient[] recipients,
                    MsgTracking[] trackings)
        {
            this.SendMixedModeAsync(userID, senderName, senderCompName, subject, note, billingCode, priority, scheduleDate, isOnHold, mss, msf, useDefaultNotify, useDefaultCP, documents, recipients, trackings, null);
        }

        /// <remarks/>
        public void SendMixedModeAsync(
                    string userID,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    int priority,
                    string scheduleDate,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    bool useDefaultNotify,
                    bool useDefaultCP,
                    MsgDocument[] documents,
                    MsgRecipient[] recipients,
                    MsgTracking[] trackings,
                    object userState)
        {
            if ((this.SendMixedModeOperationCompleted == null))
            {
                this.SendMixedModeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMixedModeOperationCompleted);
            }
            this.InvokeAsync("SendMixedMode", new object[] {
                        userID,
                        senderName,
                        senderCompName,
                        subject,
                        note,
                        billingCode,
                        priority,
                        scheduleDate,
                        isOnHold,
                        mss,
                        msf,
                        useDefaultNotify,
                        useDefaultCP,
                        documents,
                        recipients,
                        trackings}, this.SendMixedModeOperationCompleted, userState);
        }

        private void OnSendMixedModeOperationCompleted(object arg)
        {
            if ((this.SendMixedModeCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMixedModeCompleted(this, new SendMixedModeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "SendMessage1")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/BasicSendMessageWithBytes", RequestElementName = "BasicSendMessageWithBytes", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "BasicSendMessageWithBytesResponse", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("BasicSendMessageWithBytesResult")]
        public string SendMessage(long userID, string senderName, string senderCompName, string subject, string note, string[] trackLabel, string[] trackValue, string[] recpName, string[] recpAddress, bool[] recpRawFax, string[] documentName, object[] documentBytes, bool[] documentIsMerge)
        {
            object[] results = this.Invoke("SendMessage1", new object[] {
                        userID,
                        senderName,
                        senderCompName,
                        subject,
                        note,
                        trackLabel,
                        trackValue,
                        recpName,
                        recpAddress,
                        recpRawFax,
                        documentName,
                        documentBytes,
                        documentIsMerge});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void SendMessage1Async(long userID, string senderName, string senderCompName, string subject, string note, string[] trackLabel, string[] trackValue, string[] recpName, string[] recpAddress, bool[] recpRawFax, string[] documentName, object[] documentBytes, bool[] documentIsMerge)
        {
            this.SendMessage1Async(userID, senderName, senderCompName, subject, note, trackLabel, trackValue, recpName, recpAddress, recpRawFax, documentName, documentBytes, documentIsMerge, null);
        }

        /// <remarks/>
        public void SendMessage1Async(long userID, string senderName, string senderCompName, string subject, string note, string[] trackLabel, string[] trackValue, string[] recpName, string[] recpAddress, bool[] recpRawFax, string[] documentName, object[] documentBytes, bool[] documentIsMerge, object userState)
        {
            if ((this.SendMessage1OperationCompleted == null))
            {
                this.SendMessage1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMessage1OperationCompleted);
            }
            this.InvokeAsync("SendMessage1", new object[] {
                        userID,
                        senderName,
                        senderCompName,
                        subject,
                        note,
                        trackLabel,
                        trackValue,
                        recpName,
                        recpAddress,
                        recpRawFax,
                        documentName,
                        documentBytes,
                        documentIsMerge}, this.SendMessage1OperationCompleted, userState);
        }

        private void OnSendMessage1OperationCompleted(object arg)
        {
            if ((this.SendMessage1Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMessage1Completed(this, new SendMessage1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/DelegateMessage", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DelegateMessage(
                    long delegateUserID,
                    string userName,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    string scheduleDate,
                    int priority,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    string[] trackLabel,
                    string[] trackValue,
                    string[] recpName,
                    string[] recpCompName,
                    string[] recpAddress,
                    bool[] recpRawFax,
                    string[] recpNotifyAddr,
                    bool[] recpIsRRFOn,
                    bool[] recpIsRRSOn,
                    string[] documentName,
                    string[] documentPath,
                    object[] documentBytes,
                    bool[] documentIsMerge)
        {
            object[] results = this.Invoke("DelegateMessage", new object[] {
                        delegateUserID,
                        userName,
                        senderName,
                        senderCompName,
                        subject,
                        note,
                        billingCode,
                        scheduleDate,
                        priority,
                        isOnHold,
                        mss,
                        msf,
                        trackLabel,
                        trackValue,
                        recpName,
                        recpCompName,
                        recpAddress,
                        recpRawFax,
                        recpNotifyAddr,
                        recpIsRRFOn,
                        recpIsRRSOn,
                        documentName,
                        documentPath,
                        documentBytes,
                        documentIsMerge});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void DelegateMessageAsync(
                    long delegateUserID,
                    string userName,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    string scheduleDate,
                    int priority,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    string[] trackLabel,
                    string[] trackValue,
                    string[] recpName,
                    string[] recpCompName,
                    string[] recpAddress,
                    bool[] recpRawFax,
                    string[] recpNotifyAddr,
                    bool[] recpIsRRFOn,
                    bool[] recpIsRRSOn,
                    string[] documentName,
                    string[] documentPath,
                    object[] documentBytes,
                    bool[] documentIsMerge)
        {
            this.DelegateMessageAsync(delegateUserID, userName, senderName, senderCompName, subject, note, billingCode, scheduleDate, priority, isOnHold, mss, msf, trackLabel, trackValue, recpName, recpCompName, recpAddress, recpRawFax, recpNotifyAddr, recpIsRRFOn, recpIsRRSOn, documentName, documentPath, documentBytes, documentIsMerge, null);
        }

        /// <remarks/>
        public void DelegateMessageAsync(
                    long delegateUserID,
                    string userName,
                    string senderName,
                    string senderCompName,
                    string subject,
                    string note,
                    string billingCode,
                    string scheduleDate,
                    int priority,
                    bool isOnHold,
                    bool mss,
                    bool msf,
                    string[] trackLabel,
                    string[] trackValue,
                    string[] recpName,
                    string[] recpCompName,
                    string[] recpAddress,
                    bool[] recpRawFax,
                    string[] recpNotifyAddr,
                    bool[] recpIsRRFOn,
                    bool[] recpIsRRSOn,
                    string[] documentName,
                    string[] documentPath,
                    object[] documentBytes,
                    bool[] documentIsMerge,
                    object userState)
        {
            if ((this.DelegateMessageOperationCompleted == null))
            {
                this.DelegateMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDelegateMessageOperationCompleted);
            }
            this.InvokeAsync("DelegateMessage", new object[] {
                        delegateUserID,
                        userName,
                        senderName,
                        senderCompName,
                        subject,
                        note,
                        billingCode,
                        scheduleDate,
                        priority,
                        isOnHold,
                        mss,
                        msf,
                        trackLabel,
                        trackValue,
                        recpName,
                        recpCompName,
                        recpAddress,
                        recpRawFax,
                        recpNotifyAddr,
                        recpIsRRFOn,
                        recpIsRRSOn,
                        documentName,
                        documentPath,
                        documentBytes,
                        documentIsMerge}, this.DelegateMessageOperationCompleted, userState);
        }

        private void OnDelegateMessageOperationCompleted(object arg)
        {
            if ((this.DelegateMessageCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DelegateMessageCompleted(this, new DelegateMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/GetMessageDetails", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetMessageDetails(string msgID)
        {
            object[] results = this.Invoke("GetMessageDetails", new object[] {
                        msgID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void GetMessageDetailsAsync(string msgID)
        {
            this.GetMessageDetailsAsync(msgID, null);
        }

        /// <remarks/>
        public void GetMessageDetailsAsync(string msgID, object userState)
        {
            if ((this.GetMessageDetailsOperationCompleted == null))
            {
                this.GetMessageDetailsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessageDetailsOperationCompleted);
            }
            this.InvokeAsync("GetMessageDetails", new object[] {
                        msgID}, this.GetMessageDetailsOperationCompleted, userState);
        }

        private void OnGetMessageDetailsOperationCompleted(object arg)
        {
            if ((this.GetMessageDetailsCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessageDetailsCompleted(this, new GetMessageDetailsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/GetMessageStatus", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetMessageStatus(string msgID)
        {
            object[] results = this.Invoke("GetMessageStatus", new object[] {
                        msgID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void GetMessageStatusAsync(string msgID)
        {
            this.GetMessageStatusAsync(msgID, null);
        }

        /// <remarks/>
        public void GetMessageStatusAsync(string msgID, object userState)
        {
            if ((this.GetMessageStatusOperationCompleted == null))
            {
                this.GetMessageStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessageStatusOperationCompleted);
            }
            this.InvokeAsync("GetMessageStatus", new object[] {
                        msgID}, this.GetMessageStatusOperationCompleted, userState);
        }

        private void OnGetMessageStatusOperationCompleted(object arg)
        {
            if ((this.GetMessageStatusCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessageStatusCompleted(this, new GetMessageStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/IsMessageDeleted", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string IsMessageDeleted(string messageID, string userID)
        {
            object[] results = this.Invoke("IsMessageDeleted", new object[] {
                        messageID,
                        userID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void IsMessageDeletedAsync(string messageID, string userID)
        {
            this.IsMessageDeletedAsync(messageID, userID, null);
        }

        /// <remarks/>
        public void IsMessageDeletedAsync(string messageID, string userID, object userState)
        {
            if ((this.IsMessageDeletedOperationCompleted == null))
            {
                this.IsMessageDeletedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsMessageDeletedOperationCompleted);
            }
            this.InvokeAsync("IsMessageDeleted", new object[] {
                        messageID,
                        userID}, this.IsMessageDeletedOperationCompleted, userState);
        }

        private void OnIsMessageDeletedOperationCompleted(object arg)
        {
            if ((this.IsMessageDeletedCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsMessageDeletedCompleted(this, new IsMessageDeletedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/DeleteMessage", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DeleteMessage(string msgID, long userID)
        {
            object[] results = this.Invoke("DeleteMessage", new object[] {
                        msgID,
                        userID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void DeleteMessageAsync(string msgID, long userID)
        {
            this.DeleteMessageAsync(msgID, userID, null);
        }

        /// <remarks/>
        public void DeleteMessageAsync(string msgID, long userID, object userState)
        {
            if ((this.DeleteMessageOperationCompleted == null))
            {
                this.DeleteMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteMessageOperationCompleted);
            }
            this.InvokeAsync("DeleteMessage", new object[] {
                        msgID,
                        userID}, this.DeleteMessageOperationCompleted, userState);
        }

        private void OnDeleteMessageOperationCompleted(object arg)
        {
            if ((this.DeleteMessageCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteMessageCompleted(this, new DeleteMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/CancelMessage", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CancelMessage(string msgID)
        {
            object[] results = this.Invoke("CancelMessage", new object[] {
                        msgID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void CancelMessageAsync(string msgID)
        {
            this.CancelMessageAsync(msgID, null);
        }

        /// <remarks/>
        public void CancelMessageAsync(string msgID, object userState)
        {
            if ((this.CancelMessageOperationCompleted == null))
            {
                this.CancelMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCancelMessageOperationCompleted);
            }
            this.InvokeAsync("CancelMessage", new object[] {
                        msgID}, this.CancelMessageOperationCompleted, userState);
        }

        private void OnCancelMessageOperationCompleted(object arg)
        {
            if ((this.CancelMessageCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CancelMessageCompleted(this, new CancelMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/RetryFailed", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetryFailed(string msgID)
        {
            object[] results = this.Invoke("RetryFailed", new object[] {
                        msgID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void RetryFailedAsync(string msgID)
        {
            this.RetryFailedAsync(msgID, null);
        }

        /// <remarks/>
        public void RetryFailedAsync(string msgID, object userState)
        {
            if ((this.RetryFailedOperationCompleted == null))
            {
                this.RetryFailedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetryFailedOperationCompleted);
            }
            this.InvokeAsync("RetryFailed", new object[] {
                        msgID}, this.RetryFailedOperationCompleted, userState);
        }

        private void OnRetryFailedOperationCompleted(object arg)
        {
            if ((this.RetryFailedCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetryFailedCompleted(this, new RetryFailedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/ForwardToUser", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ForwardToUser(string userID, string msgID, string[] usernames)
        {
            object[] results = this.Invoke("ForwardToUser", new object[] {
                        userID,
                        msgID,
                        usernames});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void ForwardToUserAsync(string userID, string msgID, string[] usernames)
        {
            this.ForwardToUserAsync(userID, msgID, usernames, null);
        }

        /// <remarks/>
        public void ForwardToUserAsync(string userID, string msgID, string[] usernames, object userState)
        {
            if ((this.ForwardToUserOperationCompleted == null))
            {
                this.ForwardToUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnForwardToUserOperationCompleted);
            }
            this.InvokeAsync("ForwardToUser", new object[] {
                        userID,
                        msgID,
                        usernames}, this.ForwardToUserOperationCompleted, userState);
        }

        private void OnForwardToUserOperationCompleted(object arg)
        {
            if ((this.ForwardToUserCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ForwardToUserCompleted(this, new ForwardToUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/AssignMessage", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AssignMessage(string userID, string msgID, string[] usernames)
        {
            object[] results = this.Invoke("AssignMessage", new object[] {
                        userID,
                        msgID,
                        usernames});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void AssignMessageAsync(string userID, string msgID, string[] usernames)
        {
            this.AssignMessageAsync(userID, msgID, usernames, null);
        }

        /// <remarks/>
        public void AssignMessageAsync(string userID, string msgID, string[] usernames, object userState)
        {
            if ((this.AssignMessageOperationCompleted == null))
            {
                this.AssignMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAssignMessageOperationCompleted);
            }
            this.InvokeAsync("AssignMessage", new object[] {
                        userID,
                        msgID,
                        usernames}, this.AssignMessageOperationCompleted, userState);
        }

        private void OnAssignMessageOperationCompleted(object arg)
        {
            if ((this.AssignMessageCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AssignMessageCompleted(this, new AssignMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/GetMessageList3", RequestElementName = "GetMessageList3", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "GetMessageList3Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("GetMessageList3Result")]
        public string[] GetMessageList(long userID, string folderName, bool isRead, bool sortDescending, int maxResults)
        {
            object[] results = this.Invoke("GetMessageList", new object[] {
                        userID,
                        folderName,
                        isRead,
                        sortDescending,
                        maxResults});
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetMessageListAsync(long userID, string folderName, bool isRead, bool sortDescending, int maxResults)
        {
            this.GetMessageListAsync(userID, folderName, isRead, sortDescending, maxResults, null);
        }

        /// <remarks/>
        public void GetMessageListAsync(long userID, string folderName, bool isRead, bool sortDescending, int maxResults, object userState)
        {
            if ((this.GetMessageListOperationCompleted == null))
            {
                this.GetMessageListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessageListOperationCompleted);
            }
            this.InvokeAsync("GetMessageList", new object[] {
                        userID,
                        folderName,
                        isRead,
                        sortDescending,
                        maxResults}, this.GetMessageListOperationCompleted, userState);
        }

        private void OnGetMessageListOperationCompleted(object arg)
        {
            if ((this.GetMessageListCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessageListCompleted(this, new GetMessageListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "GetMessageList1")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/GetMessageList2", RequestElementName = "GetMessageList2", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "GetMessageList2Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("GetMessageList2Result")]
        public string[] GetMessageList(long userID, string folderName, bool isRead, string startDate, string endDate, bool sortDescending, int maxResults)
        {
            object[] results = this.Invoke("GetMessageList1", new object[] {
                        userID,
                        folderName,
                        isRead,
                        startDate,
                        endDate,
                        sortDescending,
                        maxResults});
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetMessageList1Async(long userID, string folderName, bool isRead, string startDate, string endDate, bool sortDescending, int maxResults)
        {
            this.GetMessageList1Async(userID, folderName, isRead, startDate, endDate, sortDescending, maxResults, null);
        }

        /// <remarks/>
        public void GetMessageList1Async(long userID, string folderName, bool isRead, string startDate, string endDate, bool sortDescending, int maxResults, object userState)
        {
            if ((this.GetMessageList1OperationCompleted == null))
            {
                this.GetMessageList1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessageList1OperationCompleted);
            }
            this.InvokeAsync("GetMessageList1", new object[] {
                        userID,
                        folderName,
                        isRead,
                        startDate,
                        endDate,
                        sortDescending,
                        maxResults}, this.GetMessageList1OperationCompleted, userState);
        }

        private void OnGetMessageList1OperationCompleted(object arg)
        {
            if ((this.GetMessageList1Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessageList1Completed(this, new GetMessageList1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "GetMessageList2")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/GetMessageList1", RequestElementName = "GetMessageList1", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "GetMessageList1Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("GetMessageList1Result")]
        public string[] GetMessageList(long userID, string folderName, string startDate, string endDate, bool sortDescending, int maxResults)
        {
            object[] results = this.Invoke("GetMessageList2", new object[] {
                        userID,
                        folderName,
                        startDate,
                        endDate,
                        sortDescending,
                        maxResults});
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetMessageList2Async(long userID, string folderName, string startDate, string endDate, bool sortDescending, int maxResults)
        {
            this.GetMessageList2Async(userID, folderName, startDate, endDate, sortDescending, maxResults, null);
        }

        /// <remarks/>
        public void GetMessageList2Async(long userID, string folderName, string startDate, string endDate, bool sortDescending, int maxResults, object userState)
        {
            if ((this.GetMessageList2OperationCompleted == null))
            {
                this.GetMessageList2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessageList2OperationCompleted);
            }
            this.InvokeAsync("GetMessageList2", new object[] {
                        userID,
                        folderName,
                        startDate,
                        endDate,
                        sortDescending,
                        maxResults}, this.GetMessageList2OperationCompleted, userState);
        }

        private void OnGetMessageList2OperationCompleted(object arg)
        {
            if ((this.GetMessageList2Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessageList2Completed(this, new GetMessageList2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "GetMessageList3")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/GetMessageList", RequestElementName = "GetMessageList", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "GetMessageListResponse", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute("GetMessageListResult")]
        public string[] GetMessageList(long userID, string folderName, bool sortDescending, int maxResults)
        {
            object[] results = this.Invoke("GetMessageList3", new object[] {
                        userID,
                        folderName,
                        sortDescending,
                        maxResults});
            return ((string[])(results[0]));
        }

        /// <remarks/>
        public void GetMessageList3Async(long userID, string folderName, bool sortDescending, int maxResults)
        {
            this.GetMessageList3Async(userID, folderName, sortDescending, maxResults, null);
        }

        /// <remarks/>
        public void GetMessageList3Async(long userID, string folderName, bool sortDescending, int maxResults, object userState)
        {
            if ((this.GetMessageList3OperationCompleted == null))
            {
                this.GetMessageList3OperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessageList3OperationCompleted);
            }
            this.InvokeAsync("GetMessageList3", new object[] {
                        userID,
                        folderName,
                        sortDescending,
                        maxResults}, this.GetMessageList3OperationCompleted, userState);
        }

        private void OnGetMessageList3OperationCompleted(object arg)
        {
            if ((this.GetMessageList3Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessageList3Completed(this, new GetMessageList3CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/CreateNewUser1", RequestElementName = "CreateNewUser1", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "CreateNewUser1Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("CreateNewUser1Result")]
        public string CreateUser(
                    long userID,
                    string domainName,
                    string userName,
                    string password,
                    Role role,
                    bool isExternalAuth,
                    bool isActive,
                    string displayName,
                    string firstName,
                    string middleName,
                    string lastName,
                    string companyName,
                    AddressType preferAddrType,
                    string email,
                    string fax,
                    string rawFax,
                    string desc)
        {
            object[] results = this.Invoke("CreateUser", new object[] {
                        userID,
                        domainName,
                        userName,
                        password,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        email,
                        fax,
                        rawFax,
                        desc});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void CreateUserAsync(
                    long userID,
                    string domainName,
                    string userName,
                    string password,
                    Role role,
                    bool isExternalAuth,
                    bool isActive,
                    string displayName,
                    string firstName,
                    string middleName,
                    string lastName,
                    string companyName,
                    AddressType preferAddrType,
                    string email,
                    string fax,
                    string rawFax,
                    string desc)
        {
            this.CreateUserAsync(userID, domainName, userName, password, role, isExternalAuth, isActive, displayName, firstName, middleName, lastName, companyName, preferAddrType, email, fax, rawFax, desc, null);
        }

        /// <remarks/>
        public void CreateUserAsync(
                    long userID,
                    string domainName,
                    string userName,
                    string password,
                    Role role,
                    bool isExternalAuth,
                    bool isActive,
                    string displayName,
                    string firstName,
                    string middleName,
                    string lastName,
                    string companyName,
                    AddressType preferAddrType,
                    string email,
                    string fax,
                    string rawFax,
                    string desc,
                    object userState)
        {
            if ((this.CreateUserOperationCompleted == null))
            {
                this.CreateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateUserOperationCompleted);
            }
            this.InvokeAsync("CreateUser", new object[] {
                        userID,
                        domainName,
                        userName,
                        password,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        email,
                        fax,
                        rawFax,
                        desc}, this.CreateUserOperationCompleted, userState);
        }

        private void OnCreateUserOperationCompleted(object arg)
        {
            if ((this.CreateUserCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateUserCompleted(this, new CreateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "CreateUser1")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/CreateNewUser2", RequestElementName = "CreateNewUser2", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "CreateNewUser2Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("CreateNewUser2Result")]
        public string CreateUser(
                    long userID,
                    string domainName,
                    string userName,
                    string password,
                    Role role,
                    bool isExternalAuth,
                    bool isActive,
                    string displayName,
                    string firstName,
                    string middleName,
                    string lastName,
                    string companyName,
                    AddressType preferAddrType,
                    string email,
                    string fax,
                    string rawFax,
                    bool NOR,
                    bool NOS,
                    string desc)
        {
            object[] results = this.Invoke("CreateUser1", new object[] {
                        userID,
                        domainName,
                        userName,
                        password,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        email,
                        fax,
                        rawFax,
                        NOR,
                        NOS,
                        desc});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void CreateUser1Async(
                    long userID,
                    string domainName,
                    string userName,
                    string password,
                    Role role,
                    bool isExternalAuth,
                    bool isActive,
                    string displayName,
                    string firstName,
                    string middleName,
                    string lastName,
                    string companyName,
                    AddressType preferAddrType,
                    string email,
                    string fax,
                    string rawFax,
                    bool NOR,
                    bool NOS,
                    string desc)
        {
            this.CreateUser1Async(userID, domainName, userName, password, role, isExternalAuth, isActive, displayName, firstName, middleName, lastName, companyName, preferAddrType, email, fax, rawFax, NOR, NOS, desc, null);
        }

        /// <remarks/>
        public void CreateUser1Async(
                    long userID,
                    string domainName,
                    string userName,
                    string password,
                    Role role,
                    bool isExternalAuth,
                    bool isActive,
                    string displayName,
                    string firstName,
                    string middleName,
                    string lastName,
                    string companyName,
                    AddressType preferAddrType,
                    string email,
                    string fax,
                    string rawFax,
                    bool NOR,
                    bool NOS,
                    string desc,
                    object userState)
        {
            if ((this.CreateUser1OperationCompleted == null))
            {
                this.CreateUser1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateUser1OperationCompleted);
            }
            this.InvokeAsync("CreateUser1", new object[] {
                        userID,
                        domainName,
                        userName,
                        password,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        email,
                        fax,
                        rawFax,
                        NOR,
                        NOS,
                        desc}, this.CreateUser1OperationCompleted, userState);
        }

        private void OnCreateUser1OperationCompleted(object arg)
        {
            if ((this.CreateUser1Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateUser1Completed(this, new CreateUser1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/UpdateUser-basic", RequestElementName = "UpdateUser-basic", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "UpdateUser-basicResponse", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("UpdateUser-basicResult")]
        public string UpdateUser(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc)
        {
            object[] results = this.Invoke("UpdateUser", new object[] {
                        adminID,
                        userID,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        desc});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void UpdateUserAsync(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc)
        {
            this.UpdateUserAsync(adminID, userID, role, isExternalAuth, isActive, displayName, firstName, middleName, lastName, companyName, preferAddrType, desc, null);
        }

        /// <remarks/>
        public void UpdateUserAsync(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc, object userState)
        {
            if ((this.UpdateUserOperationCompleted == null))
            {
                this.UpdateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateUserOperationCompleted);
            }
            this.InvokeAsync("UpdateUser", new object[] {
                        adminID,
                        userID,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        desc}, this.UpdateUserOperationCompleted, userState);
        }

        private void OnUpdateUserOperationCompleted(object arg)
        {
            if ((this.UpdateUserCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateUserCompleted(this, new UpdateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "UpdateUser1")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/UpdateUser-extra", RequestElementName = "UpdateUser-extra", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "UpdateUser-extraResponse", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("UpdateUser-extraResult")]
        public string UpdateUser(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc, string localCSID, string callerID)
        {
            object[] results = this.Invoke("UpdateUser1", new object[] {
                        adminID,
                        userID,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        desc,
                        localCSID,
                        callerID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void UpdateUser1Async(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc, string localCSID, string callerID)
        {
            this.UpdateUser1Async(adminID, userID, role, isExternalAuth, isActive, displayName, firstName, middleName, lastName, companyName, preferAddrType, desc, localCSID, callerID, null);
        }

        /// <remarks/>
        public void UpdateUser1Async(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc, string localCSID, string callerID, object userState)
        {
            if ((this.UpdateUser1OperationCompleted == null))
            {
                this.UpdateUser1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateUser1OperationCompleted);
            }
            this.InvokeAsync("UpdateUser1", new object[] {
                        adminID,
                        userID,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        desc,
                        localCSID,
                        callerID}, this.UpdateUser1OperationCompleted, userState);
        }

        private void OnUpdateUser1OperationCompleted(object arg)
        {
            if ((this.UpdateUser1Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateUser1Completed(this, new UpdateUser1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "UpdateUser2")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/UpdateUser-advance", RequestElementName = "UpdateUser-advance", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "UpdateUser-advanceResponse", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("UpdateUser-advanceResult")]
        public string UpdateUser(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc, UserConfig[] config)
        {
            object[] results = this.Invoke("UpdateUser2", new object[] {
                        adminID,
                        userID,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        desc,
                        config});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void UpdateUser2Async(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc, UserConfig[] config)
        {
            this.UpdateUser2Async(adminID, userID, role, isExternalAuth, isActive, displayName, firstName, middleName, lastName, companyName, preferAddrType, desc, config, null);
        }

        /// <remarks/>
        public void UpdateUser2Async(long adminID, long userID, Role role, bool isExternalAuth, bool isActive, string displayName, string firstName, string middleName, string lastName, string companyName, AddressType preferAddrType, string desc, UserConfig[] config, object userState)
        {
            if ((this.UpdateUser2OperationCompleted == null))
            {
                this.UpdateUser2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateUser2OperationCompleted);
            }
            this.InvokeAsync("UpdateUser2", new object[] {
                        adminID,
                        userID,
                        role,
                        isExternalAuth,
                        isActive,
                        displayName,
                        firstName,
                        middleName,
                        lastName,
                        companyName,
                        preferAddrType,
                        desc,
                        config}, this.UpdateUser2OperationCompleted, userState);
        }

        private void OnUpdateUser2OperationCompleted(object arg)
        {
            if ((this.UpdateUser2Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateUser2Completed(this, new UpdateUser2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/RemoveUser", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RemoveUser(long adminID, long userID)
        {
            object[] results = this.Invoke("RemoveUser", new object[] {
                        adminID,
                        userID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void RemoveUserAsync(long adminID, long userID)
        {
            this.RemoveUserAsync(adminID, userID, null);
        }

        /// <remarks/>
        public void RemoveUserAsync(long adminID, long userID, object userState)
        {
            if ((this.RemoveUserOperationCompleted == null))
            {
                this.RemoveUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRemoveUserOperationCompleted);
            }
            this.InvokeAsync("RemoveUser", new object[] {
                        adminID,
                        userID}, this.RemoveUserOperationCompleted, userState);
        }

        private void OnRemoveUserOperationCompleted(object arg)
        {
            if ((this.RemoveUserCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RemoveUserCompleted(this, new RemoveUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/DeactivateUser", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DeactivateUser(long adminID, long userID)
        {
            object[] results = this.Invoke("DeactivateUser", new object[] {
                        adminID,
                        userID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void DeactivateUserAsync(long adminID, long userID)
        {
            this.DeactivateUserAsync(adminID, userID, null);
        }

        /// <remarks/>
        public void DeactivateUserAsync(long adminID, long userID, object userState)
        {
            if ((this.DeactivateUserOperationCompleted == null))
            {
                this.DeactivateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeactivateUserOperationCompleted);
            }
            this.InvokeAsync("DeactivateUser", new object[] {
                        adminID,
                        userID}, this.DeactivateUserOperationCompleted, userState);
        }

        private void OnDeactivateUserOperationCompleted(object arg)
        {
            if ((this.DeactivateUserCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeactivateUserCompleted(this, new DeactivateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/DeactivateUsers", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DeactivateUsers(long adminID, long[] userIDList)
        {
            object[] results = this.Invoke("DeactivateUsers", new object[] {
                        adminID,
                        userIDList});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void DeactivateUsersAsync(long adminID, long[] userIDList)
        {
            this.DeactivateUsersAsync(adminID, userIDList, null);
        }

        /// <remarks/>
        public void DeactivateUsersAsync(long adminID, long[] userIDList, object userState)
        {
            if ((this.DeactivateUsersOperationCompleted == null))
            {
                this.DeactivateUsersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeactivateUsersOperationCompleted);
            }
            this.InvokeAsync("DeactivateUsers", new object[] {
                        adminID,
                        userIDList}, this.DeactivateUsersOperationCompleted, userState);
        }

        private void OnDeactivateUsersOperationCompleted(object arg)
        {
            if ((this.DeactivateUsersCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeactivateUsersCompleted(this, new DeactivateUsersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/ActivateUser", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ActivateUser(long adminID, long userID)
        {
            object[] results = this.Invoke("ActivateUser", new object[] {
                        adminID,
                        userID});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void ActivateUserAsync(long adminID, long userID)
        {
            this.ActivateUserAsync(adminID, userID, null);
        }

        /// <remarks/>
        public void ActivateUserAsync(long adminID, long userID, object userState)
        {
            if ((this.ActivateUserOperationCompleted == null))
            {
                this.ActivateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnActivateUserOperationCompleted);
            }
            this.InvokeAsync("ActivateUser", new object[] {
                        adminID,
                        userID}, this.ActivateUserOperationCompleted, userState);
        }

        private void OnActivateUserOperationCompleted(object arg)
        {
            if ((this.ActivateUserCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ActivateUserCompleted(this, new ActivateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/ActivateUsers", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ActivateUsers(long adminID, long[] userIDList)
        {
            object[] results = this.Invoke("ActivateUsers", new object[] {
                        adminID,
                        userIDList});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void ActivateUsersAsync(long adminID, long[] userIDList)
        {
            this.ActivateUsersAsync(adminID, userIDList, null);
        }

        /// <remarks/>
        public void ActivateUsersAsync(long adminID, long[] userIDList, object userState)
        {
            if ((this.ActivateUsersOperationCompleted == null))
            {
                this.ActivateUsersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnActivateUsersOperationCompleted);
            }
            this.InvokeAsync("ActivateUsers", new object[] {
                        adminID,
                        userIDList}, this.ActivateUsersOperationCompleted, userState);
        }

        private void OnActivateUsersOperationCompleted(object arg)
        {
            if ((this.ActivateUsersCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ActivateUsersCompleted(this, new ActivateUsersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/CreateInboundRoute", RequestNamespace = "http://faxcoreserver/services/", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CreateInboundRoute(long userID, string forwardedUserName, ConditionType condition1, string conditionExp1, bool isAndOperator, ConditionType condition2, string conditionExp2, bool isActive, int priority)
        {
            object[] results = this.Invoke("CreateInboundRoute", new object[] {
                        userID,
                        forwardedUserName,
                        condition1,
                        conditionExp1,
                        isAndOperator,
                        condition2,
                        conditionExp2,
                        isActive,
                        priority});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void CreateInboundRouteAsync(long userID, string forwardedUserName, ConditionType condition1, string conditionExp1, bool isAndOperator, ConditionType condition2, string conditionExp2, bool isActive, int priority)
        {
            this.CreateInboundRouteAsync(userID, forwardedUserName, condition1, conditionExp1, isAndOperator, condition2, conditionExp2, isActive, priority, null);
        }

        /// <remarks/>
        public void CreateInboundRouteAsync(long userID, string forwardedUserName, ConditionType condition1, string conditionExp1, bool isAndOperator, ConditionType condition2, string conditionExp2, bool isActive, int priority, object userState)
        {
            if ((this.CreateInboundRouteOperationCompleted == null))
            {
                this.CreateInboundRouteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateInboundRouteOperationCompleted);
            }
            this.InvokeAsync("CreateInboundRoute", new object[] {
                        userID,
                        forwardedUserName,
                        condition1,
                        conditionExp1,
                        isAndOperator,
                        condition2,
                        conditionExp2,
                        isActive,
                        priority}, this.CreateInboundRouteOperationCompleted, userState);
        }

        private void OnCreateInboundRouteOperationCompleted(object arg)
        {
            if ((this.CreateInboundRouteCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateInboundRouteCompleted(this, new CreateInboundRouteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/DownloadMessageByte1", RequestElementName = "DownloadMessageByte1", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "DownloadMessageByte1Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("DownloadMessageByte1Result")]
        public string DownloadMessageByte(string messageID, int deliveryNum, string downloadType, int startPageIndex, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] out byte[] output)
        {
            object[] results = this.Invoke("DownloadMessageByte", new object[] {
                        messageID,
                        deliveryNum,
                        downloadType,
                        startPageIndex});
            output = ((byte[])(results[1]));
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void DownloadMessageByteAsync(string messageID, int deliveryNum, string downloadType, int startPageIndex)
        {
            this.DownloadMessageByteAsync(messageID, deliveryNum, downloadType, startPageIndex, null);
        }

        /// <remarks/>
        public void DownloadMessageByteAsync(string messageID, int deliveryNum, string downloadType, int startPageIndex, object userState)
        {
            if ((this.DownloadMessageByteOperationCompleted == null))
            {
                this.DownloadMessageByteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadMessageByteOperationCompleted);
            }
            this.InvokeAsync("DownloadMessageByte", new object[] {
                        messageID,
                        deliveryNum,
                        downloadType,
                        startPageIndex}, this.DownloadMessageByteOperationCompleted, userState);
        }

        private void OnDownloadMessageByteOperationCompleted(object arg)
        {
            if ((this.DownloadMessageByteCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DownloadMessageByteCompleted(this, new DownloadMessageByteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "DownloadMessageByte1")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/DownloadMessageInByte2", RequestElementName = "DownloadMessageInByte2", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "DownloadMessageInByte2Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("DownloadMessageInByte2Result")]
        public string DownloadMessageByte(string messageID, int deliveryNum, string downloadType, int startPageIndex, int[] excludePageList, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] out byte[] output)
        {
            object[] results = this.Invoke("DownloadMessageByte1", new object[] {
                        messageID,
                        deliveryNum,
                        downloadType,
                        startPageIndex,
                        excludePageList});
            output = ((byte[])(results[1]));
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void DownloadMessageByte1Async(string messageID, int deliveryNum, string downloadType, int startPageIndex, int[] excludePageList)
        {
            this.DownloadMessageByte1Async(messageID, deliveryNum, downloadType, startPageIndex, excludePageList, null);
        }

        /// <remarks/>
        public void DownloadMessageByte1Async(string messageID, int deliveryNum, string downloadType, int startPageIndex, int[] excludePageList, object userState)
        {
            if ((this.DownloadMessageByte1OperationCompleted == null))
            {
                this.DownloadMessageByte1OperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadMessageByte1OperationCompleted);
            }
            this.InvokeAsync("DownloadMessageByte1", new object[] {
                        messageID,
                        deliveryNum,
                        downloadType,
                        startPageIndex,
                        excludePageList}, this.DownloadMessageByte1OperationCompleted, userState);
        }

        private void OnDownloadMessageByte1OperationCompleted(object arg)
        {
            if ((this.DownloadMessageByte1Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DownloadMessageByte1Completed(this, new DownloadMessageByte1CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "DownloadMessageByte2")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/DownloadMessageInByte3", RequestElementName = "DownloadMessageInByte3", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "DownloadMessageInByte3Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("DownloadMessageInByte3Result")]
        public string DownloadMessageByte(string deliveryID, string downloadType, int startPageIndex, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] out byte[] output)
        {
            object[] results = this.Invoke("DownloadMessageByte2", new object[] {
                        deliveryID,
                        downloadType,
                        startPageIndex});
            output = ((byte[])(results[1]));
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void DownloadMessageByte2Async(string deliveryID, string downloadType, int startPageIndex)
        {
            this.DownloadMessageByte2Async(deliveryID, downloadType, startPageIndex, null);
        }

        /// <remarks/>
        public void DownloadMessageByte2Async(string deliveryID, string downloadType, int startPageIndex, object userState)
        {
            if ((this.DownloadMessageByte2OperationCompleted == null))
            {
                this.DownloadMessageByte2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadMessageByte2OperationCompleted);
            }
            this.InvokeAsync("DownloadMessageByte2", new object[] {
                        deliveryID,
                        downloadType,
                        startPageIndex}, this.DownloadMessageByte2OperationCompleted, userState);
        }

        private void OnDownloadMessageByte2OperationCompleted(object arg)
        {
            if ((this.DownloadMessageByte2Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DownloadMessageByte2Completed(this, new DownloadMessageByte2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.WebMethodAttribute(MessageName = "DownloadMessageByte3")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://faxcoreserver/services/DownloadMessageInByte4", RequestElementName = "DownloadMessageInByte4", RequestNamespace = "http://faxcoreserver/services/", ResponseElementName = "DownloadMessageInByte4Response", ResponseNamespace = "http://faxcoreserver/services/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("DownloadMessageInByte4Result")]
        public string DownloadMessageByte(string deliveryID, string downloadType, int startPageIndex, int[] excludePageList, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] out byte[] output)
        {
            object[] results = this.Invoke("DownloadMessageByte3", new object[] {
                        deliveryID,
                        downloadType,
                        startPageIndex,
                        excludePageList});
            output = ((byte[])(results[1]));
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void DownloadMessageByte3Async(string deliveryID, string downloadType, int startPageIndex, int[] excludePageList)
        {
            this.DownloadMessageByte3Async(deliveryID, downloadType, startPageIndex, excludePageList, null);
        }

        /// <remarks/>
        public void DownloadMessageByte3Async(string deliveryID, string downloadType, int startPageIndex, int[] excludePageList, object userState)
        {
            if ((this.DownloadMessageByte3OperationCompleted == null))
            {
                this.DownloadMessageByte3OperationCompleted = new System.Threading.SendOrPostCallback(this.OnDownloadMessageByte3OperationCompleted);
            }
            this.InvokeAsync("DownloadMessageByte3", new object[] {
                        deliveryID,
                        downloadType,
                        startPageIndex,
                        excludePageList}, this.DownloadMessageByte3OperationCompleted, userState);
        }

        private void OnDownloadMessageByte3OperationCompleted(object arg)
        {
            if ((this.DownloadMessageByte3Completed != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DownloadMessageByte3Completed(this, new DownloadMessageByte3CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }

        private bool IsLocalFileSystemWebService(string url)
        {
            if (((url == null)
                        || (url == string.Empty)))
            {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024)
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0)))
            {
                return true;
            }
            return false;
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://faxcoreserver/services/")]
    public partial class UserConfig
    {

        private string configNameField;

        private string configValueField;

        /// <remarks/>
        public string ConfigName
        {
            get
            {
                return this.configNameField;
            }
            set
            {
                this.configNameField = value;
            }
        }

        /// <remarks/>
        public string ConfigValue
        {
            get
            {
                return this.configValueField;
            }
            set
            {
                this.configValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://faxcoreserver/services/")]
    public partial class MsgTracking
    {

        private string trackLabelField;

        private string trackValueField;

        /// <remarks/>
        public string TrackLabel
        {
            get
            {
                return this.trackLabelField;
            }
            set
            {
                this.trackLabelField = value;
            }
        }

        /// <remarks/>
        public string TrackValue
        {
            get
            {
                return this.trackValueField;
            }
            set
            {
                this.trackValueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://faxcoreserver/services/")]
    public partial class MsgRecipient
    {

        private string nameField;

        private string compNameField;

        private string addressField;

        private int addressTypeField;

        private string notifyAddressField;

        private bool isRRFOnField;

        private bool isRRSOnField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string CompName
        {
            get
            {
                return this.compNameField;
            }
            set
            {
                this.compNameField = value;
            }
        }

        /// <remarks/>
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <remarks/>
        public int AddressType
        {
            get
            {
                return this.addressTypeField;
            }
            set
            {
                this.addressTypeField = value;
            }
        }

        /// <remarks/>
        public string NotifyAddress
        {
            get
            {
                return this.notifyAddressField;
            }
            set
            {
                this.notifyAddressField = value;
            }
        }

        /// <remarks/>
        public bool IsRRFOn
        {
            get
            {
                return this.isRRFOnField;
            }
            set
            {
                this.isRRFOnField = value;
            }
        }

        /// <remarks/>
        public bool IsRRSOn
        {
            get
            {
                return this.isRRSOnField;
            }
            set
            {
                this.isRRSOnField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://faxcoreserver/services/")]
    public partial class MsgDocument
    {

        private string nameField;

        private string pathField;

        private byte[] bytesField;

        private bool isMergeField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string Path
        {
            get
            {
                return this.pathField;
            }
            set
            {
                this.pathField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")]
        public byte[] Bytes
        {
            get
            {
                return this.bytesField;
            }
            set
            {
                this.bytesField = value;
            }
        }

        /// <remarks/>
        public bool IsMerge
        {
            get
            {
                return this.isMergeField;
            }
            set
            {
                this.isMergeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://faxcoreserver/services/")]
    public enum Role
    {

        /// <remarks/>
        DomainAdmin,

        /// <remarks/>
        SuperUser,

        /// <remarks/>
        StandardUser,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://faxcoreserver/services/")]
    public enum AddressType
    {

        /// <remarks/>
        Fax,

        /// <remarks/>
        Email,

        /// <remarks/>
        FaxRaw,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://faxcoreserver/services/")]
    public enum ConditionType
    {

        /// <remarks/>
        None,

        /// <remarks/>
        BarCode,

        /// <remarks/>
        FaxPortNo,

        /// <remarks/>
        RoutingDigits,

        /// <remarks/>
        RemoteCallerID,

        /// <remarks/>
        RemoteCSID,

        /// <remarks/>
        ServerName,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void AuthenticateUserCompletedEventHandler(object sender, AuthenticateUserCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AuthenticateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal AuthenticateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public long Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((long)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void ServerStatusCompletedEventHandler(object sender, ServerStatusCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServerStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal ServerStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void SendMessageCompletedEventHandler(object sender, SendMessageCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SendMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void SendMixedModeCompletedEventHandler(object sender, SendMixedModeCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMixedModeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SendMixedModeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void SendMessage1CompletedEventHandler(object sender, SendMessage1CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMessage1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SendMessage1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DelegateMessageCompletedEventHandler(object sender, DelegateMessageCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DelegateMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DelegateMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetMessageDetailsCompletedEventHandler(object sender, GetMessageDetailsCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessageDetailsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetMessageDetailsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetMessageStatusCompletedEventHandler(object sender, GetMessageStatusCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessageStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetMessageStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void IsMessageDeletedCompletedEventHandler(object sender, IsMessageDeletedCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsMessageDeletedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal IsMessageDeletedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DeleteMessageCompletedEventHandler(object sender, DeleteMessageCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DeleteMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void CancelMessageCompletedEventHandler(object sender, CancelMessageCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CancelMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CancelMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void RetryFailedCompletedEventHandler(object sender, RetryFailedCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetryFailedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal RetryFailedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void ForwardToUserCompletedEventHandler(object sender, ForwardToUserCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ForwardToUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal ForwardToUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void AssignMessageCompletedEventHandler(object sender, AssignMessageCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AssignMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal AssignMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetMessageListCompletedEventHandler(object sender, GetMessageListCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessageListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetMessageListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetMessageList1CompletedEventHandler(object sender, GetMessageList1CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessageList1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetMessageList1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetMessageList2CompletedEventHandler(object sender, GetMessageList2CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessageList2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetMessageList2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void GetMessageList3CompletedEventHandler(object sender, GetMessageList3CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessageList3CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetMessageList3CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string[] Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void CreateUserCompletedEventHandler(object sender, CreateUserCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CreateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void CreateUser1CompletedEventHandler(object sender, CreateUser1CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateUser1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CreateUser1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void UpdateUserCompletedEventHandler(object sender, UpdateUserCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal UpdateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void UpdateUser1CompletedEventHandler(object sender, UpdateUser1CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateUser1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal UpdateUser1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void UpdateUser2CompletedEventHandler(object sender, UpdateUser2CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateUser2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal UpdateUser2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void RemoveUserCompletedEventHandler(object sender, RemoveUserCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RemoveUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal RemoveUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DeactivateUserCompletedEventHandler(object sender, DeactivateUserCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeactivateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DeactivateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DeactivateUsersCompletedEventHandler(object sender, DeactivateUsersCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeactivateUsersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DeactivateUsersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void ActivateUserCompletedEventHandler(object sender, ActivateUserCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ActivateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal ActivateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void ActivateUsersCompletedEventHandler(object sender, ActivateUsersCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ActivateUsersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal ActivateUsersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void CreateInboundRouteCompletedEventHandler(object sender, CreateInboundRouteCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateInboundRouteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CreateInboundRouteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DownloadMessageByteCompletedEventHandler(object sender, DownloadMessageByteCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadMessageByteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DownloadMessageByteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }

        /// <remarks/>
        public byte[] output
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[1]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DownloadMessageByte1CompletedEventHandler(object sender, DownloadMessageByte1CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadMessageByte1CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DownloadMessageByte1CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }

        /// <remarks/>
        public byte[] output
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[1]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DownloadMessageByte2CompletedEventHandler(object sender, DownloadMessageByte2CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadMessageByte2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DownloadMessageByte2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }

        /// <remarks/>
        public byte[] output
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[1]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void DownloadMessageByte3CompletedEventHandler(object sender, DownloadMessageByte3CompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DownloadMessageByte3CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal DownloadMessageByte3CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }

        /// <remarks/>
        public byte[] output
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[1]));
            }
        }
    }

}
