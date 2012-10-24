using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Net;
using System.IO;

namespace ReadCer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LogMessage(string str)
        {
            this.txtLog.Text += str + Environment.NewLine;

        }
        private X509Certificate2 GetSSLCertificate(string certName,string certPassword)
        {
            X509Certificate2 certificate = null;
            try
            {
                LogMessage("GetSSLCerttificate");
                LogMessage("    CertLocation:" + certName);
                LogMessage("    Password:" + certPassword);
                certificate = new X509Certificate2(certName, certPassword);
                LogMessage("Can get Cert");
                //certificate = new X509Certificate2(fileName, password);
                //myLog.Info("Read Certificate from PFX file OK.");
            }
            catch (Exception exception)
            {
                LogMessage ("Read Certificate from PFX file Fail. " + exception.Message);
            }
            return certificate;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void selfCheckMaster()
        {
            
            string postURL = "";
            string responseData = "";
            string errMsg = "";
            postURL = this.txtURL.Text;
            if (postDataStream(postURL, "<ThreeDSecure></ThreeDSecure>", true, out responseData, out errMsg))
            {
              
                LogMessage("----------------------");
                LogMessage ("SinaptIQ.SSLPost Self Check Master OK");
                LogMessage("----------------------");
            }
            else
            {
                
                LogMessage("SinaptIQ.SSLPost Self Check Master Fail");
            }
            Application.DoEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            X509Certificate2 MyCert = GetSSLCertificate(this.txtCertLocation.Text, this.txtCertPassword.Text);
            System.Text.StringBuilder strB = new StringBuilder();
            strB.Append("==== Cert Information ====").Append(Environment.NewLine);
            strB.Append("HasPrivateKey:").Append(MyCert.HasPrivateKey.ToString()).Append(Environment.NewLine);
            strB.Append("ExpiryDate:").Append(MyCert.GetExpirationDateString()).Append(Environment.NewLine);

            strB.Append("FriendlyName:").Append(MyCert.FriendlyName).Append(Environment.NewLine);
            strB.Append("IssuerName:").Append (Environment.NewLine ).Append ("  ").Append(MyCert.GetIssuerName ()).Append(Environment.NewLine);
            strB.Append("Name:").Append(Environment.NewLine).Append("  ").Append(MyCert.GetName()).Append(Environment.NewLine);
            //strB.Append("PublickeyString:").Append(MyCert.GetPublicKeyString ()).Append(Environment.NewLine);
            
            //strB.Append("Issuer:").Append(MyCert.Issuer ).Append(Environment.NewLine);
            //strB.Append("IssuerName:").Append(MyCert.IssuerName.Name  ).Append(Environment.NewLine);
            strB.Append("Subject:").Append(Environment.NewLine).Append("  ").Append(MyCert.Subject).Append(Environment.NewLine);
            //strB.Append("SubjectName:").Append(MyCert.SubjectName.Name  ).Append(Environment.NewLine);
            strB.Append("==========================").Append(Environment.NewLine);
            LogMessage(strB.ToString());

            //strB.Append("").Append(MyCert.).Append(Environment.NewLine);
            
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.txtLog.Text = "";
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            selfCheckMaster();

        }



        public bool postDataStream(string postURL, string data2Post, bool withCert, out string responseData, out string errMsg)
        {
            responseData = "";
            errMsg = "";
            bool flag = false;
            int retryCounter = 0;
            int num2 = 0;
            num2 = 3;
            if (data2Post == "")
            {
                errMsg = "Nothing to post!";
                LogMessage ("No data to post");
                return false;
            }
            do
            {
                retryCounter++;
                try
                {
                    LogMessage("Call Post: Attempt #" + retryCounter);
                    flag = this.postData(postURL, data2Post, out responseData, retryCounter);
                }
                catch (Exception exception)
                {
                    errMsg = exception.Message;
                    LogMessage(string.Concat(new object[] { "Call Error: Attempt #", retryCounter, " - ", errMsg }));
                    flag = false;
                }
                finally
                {
                    LogMessage("Call Completed. Attempt #" + retryCounter);
                }
            }
            while (!flag && (retryCounter < num2));
            return flag;
        }


        private bool postData(string postURL, string data2Post, out string responseData, int retryCounter)
        {
            responseData = "";
            int num = 0;
            byte[] bytes = null;
            bool flag = false;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postURL);
            HttpWebResponse response = null;
            ServicePointManager.CertificatePolicy = new CertPolicy();
            if (data2Post == "")
            {
                responseData = "Nothing to post!";
                LogMessage ("No data to post");
                return false;
            }
            num = 30000;
            try
            {
                request.Method = "POST";
                request.UserAgent = "SinaptIQ WebBot";
                request.ContentType = "application/xml; charset=utf-8";
                request.ContentLength = data2Post.Length;
                request.KeepAlive = true;
                request.Timeout = num;
                LogMessage ("URL: " + postURL);
                
                    LogMessage ("Trying to read certificate to post to MDURL;");
                    try
                    {
                        X509Certificate2 sSLCertificate = this.GetSSLCertificate(this.txtCertLocation.Text , this.txtCertPassword.Text );
                        request.ClientCertificates.Add(sSLCertificate);
                        LogMessage("Certificate read successful;");
                    }
                    catch (Exception exception)
                    {
                        responseData = exception.Message;
                        LogMessage("Certificate read failed;" + responseData.ToString());
                        flag = false;
                    }
                
                if (data2Post != null)
                {
                    LogMessage("data2Post is not null");
                    bytes = Encoding.UTF8.GetBytes(data2Post);
                    request.ContentLength = bytes.Length;
                    LogMessage("    Before get Request Stream");
                    
                    Stream requestStream = request.GetRequestStream();
                    LogMessage("    After get Request Stream");
                    LogMessage("    Before Write Byte");
                    requestStream.Write(bytes, 0, bytes.Length);

                    requestStream.Close();
                    LogMessage("    After Write Byte");
                    LogMessage("Data sent: " + data2Post);
                }
                else
                {
                    request.ContentLength = 0L;
                }
                LogMessage("   Before Get Response");
                response = (HttpWebResponse)request.GetResponse();
                LogMessage("   After Get Response");
                LogMessage("    Before Get ResponseData");
                responseData = new StreamReader(response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                LogMessage("   After Get ResponseData");
                responseData = responseData.Trim();
                LogMessage ("Data received: " + responseData);
                flag = true;
            }
            catch (Exception exception2)
            {
                responseData = exception2.Message;
                LogMessage("Post Error: " + responseData);
                flag = false;
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
                LogMessage("Finally statement. Closed successful.");
            }
            return flag;
        }

        private void btnGetIPAddress_Click(object sender, EventArgs e)
        {
            string HostName = this.txtURL.Text.Replace (@"https://","");
            IPAddress[] addresslist = Dns.GetHostAddresses(HostName );
            System.Text.StringBuilder strB = new StringBuilder();
            strB.Append("------------------------").Append (Environment.NewLine );
            strB.Append("IP Address of ").Append(HostName);
            foreach (IPAddress theaddress in addresslist)
            {
                //Console.WriteLine(theaddress.ToString());
                strB.Append(theaddress.ToString()).Append(Environment.NewLine);
            }
            strB.Append("------------------------").Append (Environment.NewLine );
            LogMessage(strB.ToString());
        }

    }
}