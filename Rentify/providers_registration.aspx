<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="providers_registration.aspx.cs" Inherits="Rentify.providers_registration" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registration Form</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color:bisque;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            
        }
        .container {
            background:#f4f4f4;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 400px;
        }
        h2 {
            text-align: center;
            margin-bottom: 20px;
        }
        label {
            font-weight: bold;
        }
        input {
            width: 90%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        button {
            width: 100%;
            padding: 10px;
            background: #28a745;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        button:hover {
            background: #218838;
        }
    </style>
</head>
<body>
    <div class="container">
        <h2>providers Registration Form</h2>
        <form runat="server">
            <label for="lblFullname">Full Name</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" required></asp:TextBox>
            
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required></asp:TextBox>
            
            <label for="txtContact">Contact</label>
            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" TextMode="Phone" required></asp:TextBox>
            
            <label for="lblPassword">Password</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
            
            <asp:Button ID="btnRegister" runat="server" CssClass="btn" Text="Register" BackColor="#FFCC99" OnClick="btnRegister_Click" />
        </form>
    </div>
</body>
</html>