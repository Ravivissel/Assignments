<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        body {
            background: url('http://i.imgur.com/Eor57Ae.jpg') no-repeat fixed center center;
            background-size: cover;
            font-family: Montserrat;
        }

        .logo {
            width: 213px;
            height: 36px;    
            margin: 30px auto;
        }

        .login-block {
            width: 320px;
            padding: 20px;
            background: #fff;
            border-radius: 5px;
            border-top: 5px solid #ff656c;
            margin: 0 auto;
        }

        .login-block h1 {
            text-align: center;
            color: #000;
            font-size: 18px;
            text-transform: uppercase;
            margin-top: 0;
            margin-bottom: 20px;
        }

        .login-block input {
            width: 100%;
            height: 42px;
            box-sizing: border-box;
            border-radius: 5px;
            border: 1px solid #ccc;
            margin-bottom: 20px;
            font-size: 14px;
            font-family: Montserrat;
            padding: 0 20px 0 50px;
            outline: none;
        }

        .login-block input#username {
            background: #fff url('http://i.imgur.com/u0XmBmv.png') 20px top no-repeat;
            background-size: 16px 80px;
        }

        .login-block input#username:focus {
            background: #fff url('http://i.imgur.com/u0XmBmv.png') 20px bottom no-repeat;
            background-size: 16px 80px;
        }

        .login-block input#Password {
            background: #fff url('http://i.imgur.com/Qf83FTt.png') 20px top no-repeat;
            background-size: 16px 80px;
        }

        .login-block input#Password:focus {
            background: #fff url('http://i.imgur.com/Qf83FTt.png') 20px bottom no-repeat;
            background-size: 16px 80px;
        }

        .login-block input:active, .login-block input:focus {
            border: 1px solid #ff656c;
        }

        .login-block #login {
            width: 100%;
            height: 40px;
            background: #ff656c;
            box-sizing: border-box;
            border-radius: 5px;
            border: 1px solid #e15960;
            color: #fff;
            font-weight: bold;
            text-transform: uppercase;
            font-size: 14px;
            font-family: Montserrat;
            outline: none;
            cursor: pointer;
            margin: 0 auto;
            text-align: center;
        }

        #login:hover {
            background: #ff7b81;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <link href='http://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css' />
        <div class="logo"></div>
        <div class="login-block">
            <h1>Welcome</h1>
            <asp:TextBox type="text" ID="username" placeholder="user name" runat="server" required="required"></asp:TextBox>
            <asp:TextBox type="password" ID="Password" placeholder="password" runat="server" required="required"></asp:TextBox>
            <asp:Button ID="login" runat="server" Text="Login        " OnClick="login_Click" />
            <input type="checkbox" checked="checked" id="rememberMe"/> זכור אותי
        </div>
    </form>
</body>
</html>
