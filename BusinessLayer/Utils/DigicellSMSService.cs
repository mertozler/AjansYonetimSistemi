﻿using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace BusinessLayer.Utils
{
    public class DigicellSMSService
    {
        private DigicellSMSSettingsManager _digicellSmsSettingsManager =
            new DigicellSMSSettingsManager(new EfDigicellSMSSettingsRepository());
        
        
        public string GetCredit()
        {
            var settings = _digicellSmsSettingsManager.GetSettings();
            string sURL ="http://api.sms.digicell.com.tr:8080/api/credit/v1?username="+ settings.Username + "&password=" + settings.Password;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {

                HttpWebResponse response = (HttpWebResponse)request.GetResponse (); 
                Stream receiveStream = response.GetResponseStream ();

                StreamReader readStream = new StreamReader (receiveStream, Encoding.UTF8); 
                string sResponse = readStream.ReadToEnd();
                response.Close ();
                readStream.Close ();
                return sResponse;
            } catch {
                return "";
            }

        }
        
        public string SendSMS(string sXml)
        {
            try
            {
                
                HttpWebRequest request = WebRequest.Create(new Uri("http://api.sms.digicell.com.tr:8080/api/smspost/v1")) as HttpWebRequest; 
                request.Method = "POST";

                request.ContentType = "text/xml; charset=UTF-8"; 
                request.Timeout = 5000;
                byte[] data = UTF8Encoding.UTF8.GetBytes(sXml);
                request.ContentLength = data.Length;
                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(data, 0, data.Length);
                }
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string NumberParams(string phonenumber, string message)
        {
            var SMSsettings = _digicellSmsSettingsManager.GetSettings();
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings(); 
            settings.Encoding = Encoding.Unicode;

            settings.Indent = true;
            settings.IndentChars = ("	");

            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                writer.WriteStartElement("sms");
                writer.WriteElementString("username", SMSsettings.Username);
                writer.WriteElementString("password", SMSsettings.Password);
                writer.WriteElementString("header", SMSsettings.Header);
                writer.WriteElementString("validity", "2880");
                writer.WriteStartElement("message");
                writer.WriteStartElement("gsm");
                writer.WriteElementString("no", phonenumber);
                writer.WriteEndElement(); //gsm
                writer.WriteStartElement("msg");
                writer.WriteCData(message);
                writer.WriteEndElement(); //msg
                writer.WriteEndElement(); //message
                writer.WriteEndElement(); // sms
                writer.Flush();
            }
            return sb.ToString();

        }
    }
}