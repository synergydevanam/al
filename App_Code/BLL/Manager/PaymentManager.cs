using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Text;
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;


/// <summary>
/// Summary description for PaymentManager
/// </summary>
public class PaymentManager
{   
    public static string GetPayPalPaymentUrl(int loginID, bool sandboxMode)
    {
        Login login = LoginManager.GetLoginByID(loginID);
        string serverUrl = (sandboxMode ?
           "https://www.sandbox.paypal.com/us/cgi-bin/webscr" :
           "https://www.paypal.com/us/cgi-bin/webscr");

        string amount = login.ExtraField10;
        //amount = amount.Remove(amount.IndexOf(".") + 2, 2);
        string shipping = "0.00";
        //shipping = shipping.Remove(shipping.IndexOf(".") + 2, 2);
        string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(
           HttpContext.Current.Request.Url.PathAndQuery, "") + HttpContext.Current.Request.ApplicationPath;
        if (!baseUrl.EndsWith("/"))
            baseUrl += "/";
        string notifyUrl = HttpUtility.UrlEncode(baseUrl + "PayPal/Default.aspx?Notification=1");
        string returnUrl = HttpUtility.UrlEncode(baseUrl + "PayPal/Default.aspx?orderSuccessfull=1&ID=" + loginID.ToString());
        string cancelUrl = HttpUtility.UrlEncode(baseUrl + "PayPal/Default.aspx?orderCencel=1");

        string business = HttpUtility.UrlEncode("rc@caregivermax.com");
        string itemName = HttpUtility.UrlEncode("Order #" + loginID.ToString());
        string currencyCode = "USD";

        string firstName = login.FirstName;
        string lastName = login.FirstName;

        string shipping_address = login.Details;
        string city = "";
        string state = "";
        string zipCode ="";
        string shipping_email = login.Email;

         string shipping_day_phone = login.CellPhone;
         string shipping_night_phone = login.HomePhone;
        
        StringBuilder url = new StringBuilder();
        url.AppendFormat(
          "{0}?cmd=_xclick&upload=1&rm=2&no_shipping=1&no_note=1&currency_code={1}&business={2}&item_number={3}&custom={3}&item_name={4}&amount={5}&shipping={6}&notify_url={7}&return={8}&cancel_return={9}&first_name={10}&last_name={11}&address1={12}&city={13}&state={14}&zip={15}&email={16}&day_phone_a={17}&night_phone_a={18}",
          serverUrl, currencyCode, business, loginID, itemName, amount, shipping, notifyUrl, returnUrl, cancelUrl, firstName, lastName, shipping_address, city, state, zipCode, shipping_email, shipping_day_phone, shipping_day_phone);


        return url.ToString();
    }
}
