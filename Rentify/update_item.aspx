<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="update_item.aspx.cs" Inherits="Rentify.update_item" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Item</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }
        .container {
            width: 50%;
            margin: 50px auto;
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            text-align: center;
            color: #333;
        }
        label {
            font-weight: bold;
            color: #555;
        }
        input[type="text"], textarea {
            width: 100%;
            padding: 10px;
            margin: 10px 0 20px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        input[type="file"] {
            margin: 10px 0 20px 0;
        }
        .btn {
            display: block;
            width: 100%;
            background: #4CAF50;
            color: #fff;
            padding: 10px;
            border: none;
            border-radius: 5px;
            text-align: center;
            font-size: 1rem;
            cursor: pointer;
        }
        .btn:hover {
            background: #45a049;
        }
        .message {
            text-align: center;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Update Item</h1>
            <asp:Label ID="lblMessage" runat="server" CssClass="message"></asp:Label>
            <br />
            <div class="form-group">
                 <asp:label for="category">Category Name:</asp:label>
                        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True">
                            <asp:ListItem>select Category</asp:ListItem>
                            <asp:ListItem>Electronic</asp:ListItem>
                            <asp:ListItem>Property</asp:ListItem>
                            <asp:ListItem>Clothes</asp:ListItem>
                            <asp:ListItem>Vehicle</asp:ListItem>
                         </asp:DropDownList>
              <br />
            <label for="itemName">Item Name:</label>
            <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>

            <label for="description">Description:</label>
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>

            <label for="price">Item price:</label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

            <label for="deposit_amount">Item deposit amount :</label>
            <asp:TextBox ID="txtDeposit" runat="server"></asp:TextBox>

            <label for="penalty">Item penalty :</label>
            <asp:TextBox ID="txtPenalty" runat="server"></asp:TextBox>


            <asp:Button ID="btnUpdate" runat="server" Text="Update Item" CssClass="btn" OnClick="btnUpdate_Click" />

            <br />


            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn" OnClick="btnCancel_Click" />
        </div>
    </form>
</body>
</html>
