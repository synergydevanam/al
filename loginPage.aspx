<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
    <link href="App_Themes/Default/styleWithAsrafviCodeGeneratedPage.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="loginWrapper">
		<div style="margin:auto;width:333px;">
            <h1>synergy developers</h1>
            <h2>Assisted Living</h2>
            
            <div class="clear"></div>
        </div>
        <div class="loginbg">
            <p ID="div_PasswordRecovary" runat="server">Please provide your email address that you have registered with.
After varification We will send your password to your email. </p>
            <ul ID="div_Login" runat="server">
                <li>
                    <img src="App_Themes/Default/images/userIcon.png" alt="" />
                        <asp:TextBox ID="txtLoginName" runat="server"></asp:TextBox>
                </li>
                <li>
                    <img src="App_Themes/Default/images/passwordIcon.png" alt="" />
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </li>
            </ul>
            <ul ID="div_PasswordRecovaryEmail" runat="server">
                <li>
                    <img src="App_Themes/Default/images/email.png" alt="" />
                        <asp:TextBox ID="txtEmail" runat="server" Text=""></asp:TextBox>
                </li>
                
            </ul>
            <span class="fpassword">
                <span style="width:30px;padding-left:90px;"><asp:CheckBox ID="chkRememberme" Checked="true" Visible="false" runat="server" Text="Remember me"/></span>
                    <%--<br /><br />
            	<a href="#">Forgot your password?</a> | <a href="#">Sign Up</a>--%>
                <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
            </span>
            <div class="login_btn">
            <asp:ImageButton ID="btnResetPasswrd"  runat="server" 
                    ImageUrl="App_Themes/Default/images/btnSendPassword.png" 
                    onclick="btnResetPasswrd_Click" />
            <asp:ImageButton ID="btnLogin" OnClick="btnLogin_OnClick" runat="server" ImageUrl="App_Themes/Default/images/login.png" />

                <%--<asp:Button ID="btnLogin" runat="server" Text="Log In" 
                    onclick="btnLogin_OnClick"/>--%>
            </div>
            <p ID="div_RessetPassword" runat="server">
Trouble with login? 
<br />
    <asp:LinkButton ID="lbtnResetPassword" runat="server"  
                    style="color:Blue;text-decoration:underline;" onclick="lbtnResetPassword_Click">Reset Password</asp:LinkButton><br />
<br />
If you have not Registered with us yet then <a href="http://www.caregivermax.com/Register.aspx" style="color:Blue;text-decoration:underline;">Click here to Register.</a>
</p>
        </div><!-- END CLASS LOGINBG -->    
    
    </div><!-- END ID LOGINWRAPPER -->

    </form>
</body>
</html>
