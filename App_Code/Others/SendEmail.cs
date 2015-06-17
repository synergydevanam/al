using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;


/// <summary>
/// Summary description for Sendmail
/// </summary>
public class Sendmail
{
    public Sendmail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static bool sendEmail(String fromAddr, String fromName, String toAddr, String ccAddr, String subject, String body)
    {
        try
        {
            System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
            objMailMessage.From = new MailAddress(fromAddr,fromName);

            objMailMessage.To.Add(toAddr);
            
            if (ccAddr.Trim() != "")
            {
                string[] strArray = ccAddr.Trim().Split(new char[] { ';' });

                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Trim() != "")
                        objMailMessage.CC.Add(new MailAddress(strArray[i].Trim()));
                }
            }
            objMailMessage.Bcc.Add(new MailAddress("txtorchtemp@yahoo.com", "Riyad"));

            objMailMessage.Subject = subject;

            objMailMessage.Body = body;
            objMailMessage.IsBodyHtml = true;
            System.Net.Mail.SmtpClient objSMTPClient = new System.Net.Mail.SmtpClient("dedrelay.secureserver.net", 25);

            objSMTPClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            objSMTPClient.Send(objMailMessage);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool sendEmailForRegistration(String fromAddr, String fromName, String toAddr, String ccAddr, String subject, String body)
    {
        try
        {
            System.Net.Mail.MailMessage objMailMessage = new System.Net.Mail.MailMessage();
            objMailMessage.From = new MailAddress(fromAddr, fromName);

            objMailMessage.To.Add(toAddr);

            if (ccAddr.Trim() != "")
            {
                string[] strArray = ccAddr.Trim().Split(new char[] { ';' });

                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Trim() != "")
                        objMailMessage.CC.Add(new MailAddress(strArray[i].Trim()));
                }
            }

            objMailMessage.Subject = subject;

            objMailMessage.Body = body;
            objMailMessage.IsBodyHtml = true;
            System.Net.Mail.SmtpClient objSMTPClient = new System.Net.Mail.SmtpClient("dedrelay.secureserver.net", 25);

            objSMTPClient.Credentials = CredentialCache.DefaultNetworkCredentials;
            objSMTPClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            objSMTPClient.Send(objMailMessage);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    //public static bool sendEmail(String fromAddr, String fromName, String toAddr, String ccAddr, String subject, String body)
    //{
    //    try
    //    {
    //        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

    //        client.EnableSsl = true;

    //        client.Credentials = new System.Net.NetworkCredential
    //             ("acknoreply@gmail.com", "noreply123");

    //        MailAddress from = new MailAddress(fromAddr, fromName);

    //        //string mailTo1st = toAddr.Substring(0, toAddr.IndexOf(';'));
    //        string mailTo1st = toAddr.Contains(";") ? toAddr.Substring(0, toAddr.IndexOf(';')) : toAddr;

    //        string mailTolastst = toAddr.Replace(mailTo1st, "");

    //        MailAddress to = new MailAddress(mailTo1st);

    //        MailMessage message = new MailMessage(from, to);

    //        if (toAddr.Trim() != "")
    //        {

    //            string[] strArray = mailTolastst.Trim().Split(new char[] { ';' });

    //            for (int i = 0; i < strArray.Length; i++)
    //            {
    //                if (strArray[i].Trim() != "")
    //                    message.To.Add(new MailAddress(strArray[i].Trim()));

    //            }

    //        }

    //        //ccAddr =  " Shoriful@MavrickIT.com ; Shahin@MavrickIT.com ;";

    //        if (ccAddr.Trim() != "")
    //        {

    //            string[] strArray = ccAddr.Trim().Split(new char[] { ';' });

    //            for (int i = 0; i < strArray.Length; i++)
    //            {
    //                if (strArray[i].Trim() != "")
    //                    message.CC.Add(new MailAddress(strArray[i].Trim()));

    //            }

    //        }

    //        //message.Bcc.Add(new MailAddress("riyad_ch@yahoo.com"));
            
    //        message.Subject = subject;

    //        message.IsBodyHtml = true;

    //        message.Body = body;

    //        try
    //        {

    //            client.Send(message);

    //            return true;

    //        }

    //        catch (Exception ex)
    //        {

    //            return false;

    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        return false;

    //    }

    //}

}
