<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
       <link rel="stylesheet" type="text/css" href="css/site.css" />
 
</head>
<body>
    <form id="form1" runat="server">
  <div style="width:782px; margin:0 auto; padding-top:100px;">
    <asp:Image runat="server" ID="imglogo" ImageUrl="~/images/logo.jpg" />
  </div>
    <div style="width:400px; margin:0 auto; padding-top:100px;">
     
   <table style="border: #006699 1px solid;    ">
   <tr style="background-color:#006699"><td>.</td></tr>
   <tr>
   <td>
      <asp:LoginView ID="masterview" runat="server">
            <AnonymousTemplate>
                <asp:Login ID="masterLogin" runat="server" Width="100%" DestinationPageUrl="~/Default.aspx"
                    OnAuthenticate="OnAuthenticate"  >
                    <LayoutTemplate>
                        
                            <div id="LoginControl" runat="server" style="width: 100%; float:left;">
                              
                                <table style="width:100%;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="userNameLabel" runat="server" Text="User Name:" />
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="UserName" runat="server" CssClass="txt large-input" />
                                            <asp:RequiredFieldValidator ID="userNameValidator" runat="server" SetFocusOnError="true"
                                                Text="Invalid UserName!" ControlToValidate="UserName" ForeColor="Red" Font-Bold="true" ValidationGroup="Login" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="passwordLabel" runat="server">Password:</asp:Label>
                                        </td>
                                        <td style="text-align: left">
                                            <asp:TextBox ID="Password" CssClass="txt large-input" runat="server" TextMode="Password"  />
                                            <asp:RequiredFieldValidator ID="passwordValidator" runat="server" SetFocusOnError="true"
                                                Text="Invalid Password!" ControlToValidate="Password" ForeColor="Red" Font-Bold="true" ValidationGroup="Login" /><br />
                                        </td>
                                    </tr>
                                            <tr>
                                                <td>
                                                
                                                </td>
                                                <td style="padding-left:10px;">
                                                <asp:Button runat="server" CssClass="button" ID="btnLogin" Text="Log IN"  CommandName="Login"  ValidationGroup="Login"  />
                                                  
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    
                                    <div style="float:left; width:100%; margin:0px auto; text-align:center; margin-top:20px;">
                                        <div style="width: 30%;padding-left:2%; float:left;">
                                               
                                        </div>
                                       <div style="width: 30%; float:left; padding-left:10px;">                                            
                                                <%--<asp:Button ID="btnChangePass" runat="server" OnClick="btnChangePass_OnClick" Text="Change Password" CssClass="css3button"/>                                            --%>

                                            
                                        </div>
                                       <%-- <div style="width:100%; padding-left:20px; padding-top:20px;">
                                         
                                          <b>New User?</b> 
                                           
                                           <a href="Register.aspx" style="text-decoration:underline">Join Now</a>            
                                        </div>--%>
                                   </div>   
                                                    
                            </LayoutTemplate>
                        </asp:Login>
                                          
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <h4>Logged In</h4>
                    <div>
                        <asp:LoginName ID="memberLoginName" runat="server" FormatString="Hey {0}!" Font-Size="16px" /><br />
                        <br />
                        <asp:LoginStatus ID="memberLoginStatus" CssClass="css3button" runat="server" LogoutText="Log out" LogoutPageUrl="~/login.aspx" />  
                        
                          
                   </div> 
                </LoggedInTemplate>
            </asp:LoginView>
       </td> </tr>    </table>
    </div>
    </form>
</body>
</html>
