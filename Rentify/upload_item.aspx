<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upload_item.aspx.cs" Inherits="Rentify.upload_item" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Upload an Item</title>
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
        h2 {
            text-align: center;
            color: #333;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: block;
            font-size: 1rem;
            color: #555;
        }
        input, textarea, select {
            width: 95%;
            padding: 10px;
            margin-top: 5px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }
        .btn {
            background-color: #4CAF50;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
        }
        .btn:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            
            <h2>Upload an Item</h2>
            <div class="form-group">
                <label for="category">Category Name:</label>
                <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True">
                    <asp:ListItem>select Category</asp:ListItem>
                    <asp:ListItem>Electronic</asp:ListItem>
                    <asp:ListItem>Property</asp:ListItem>
                    <asp:ListItem>Clothes</asp:ListItem>
                    <asp:ListItem>Vehicle</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="itemName">Item Name:</label>
                <asp:TextBox ID="txtItemName" runat="server" />
            </div>
            <div class="form-group">
                <label for="description">Description:</label>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" />
            </div>
            <div class="form-group">
                <label for="price">Price:</label>
                <asp:TextBox ID="txtPrice" runat="server" />
            </div>
            <div class="form-group">
                <label for="deposit">Deposit Amount:</label>
                <asp:TextBox ID="txtDeposit" runat="server" />
            </div>
            <div class="form-group">
                <label for="penalty">Penalty:</label>
                <asp:TextBox ID="txtPenalty" runat="server" />
            </div>
            <div class="form-group">
                 <label for="image">upload image:</label>
                <asp:FileUpload ID="item_image" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnUpload" runat="server" Text="Upload Item" CssClass="btn" OnClick="btnUpload_Click" />
            </div>
          
        </div>
    </form>
</body>
</html>
