﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seekers_dashboard.aspx.cs" Inherits="Rentify.seekers_dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seekers Dashboard</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }

        header {
            background: #DCE4D7;
            padding: 1rem 0;
            text-align: center;
        }

            header nav {
                display: flex;
                align-items: center;
                justify-content: space-between;
            }

            header h1 {
                margin: 0;
                font-size: 2.5rem;
                color: black;
            }

        .container {
            display: flex;
            flex-direction: row;
            margin: 20px;
            gap: 20px;
        }

        .left-panel {
            flex: 2;
            background: #f1f1f1;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .right-panel {
            flex: 8;
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

            .left-panel h2, .right-panel h2 {
                font-size: 1.5rem;
                color: #333;
                margin-bottom: 20px;
            }

        .personal-details {
            line-height: 1.8;
            color: #555;
        }

        .items {
            display: flex;
            flex-wrap: wrap;
            gap: 15px;
        }

        .item {
            background: #DCE4D7;
            padding: 15px;
            border-radius: 8px;
            text-align: center;
            width: 100%;
            height: 21rem;
            box-shadow: 0 0 5px rgba(0, 0, 0, 0.1);
        }

            .item h3 {
                font-size: 1.2rem;
                margin-bottom: 10px;
            }

            .item p {
                color: #555;
            }

        .btn {
            display: inline-block;
            padding: 10px 20px;
            font-size: 1rem;
            color: #fff;
            background: #4CAF50;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            text-align: center;
            width: 100%;
        }

            .btn:hover {
                background: #45a049;
            }

             .btnstyle{
     display:flex;
     align-items:center;
     justify-content:space-around;
 }
 .DivDetails{
     
   text-align:left;
 }
 .logo-com{
    display:flex;
    align-items:center;
    
}
.form-control{

    width : 100%;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Header -->
            <header>
                <nav>
                     <div class="logo-com">
                            <asp:Image ID="Image1" runat="server" Height="79px" ImageUrl="~/photos/RENTIFY__LOGO.png" Width="102px" />
                            <h1 style="margin: 0; font-size: 2.5rem; color: black;">Rentify</h1>
                    </div>
                     <h1>Welcome to Seekers Dashboard</h1>
                </nav>
            </header>

            <!-- Main Content -->
            <div class="container">
                <!-- Left Panel: Personal Details -->
                <div class="left-panel">
                    <h2>Personal Details</h2>
                    <div class="personal-details">
                        <p><strong>Name:</strong><asp:Label ID="lblname" runat="server" ForeColor="black"></asp:Label></p>
                        <p><strong>Email:</strong>
                            <asp:Label ID="lblemail" runat="server" ForeColor="black"></asp:Label></p>
                        <p><strong>Contact:</strong><asp:Label ID="lblcontact" runat="server" ForeColor="black"></asp:Label></p>
                        <p><strong>password:</strong><asp:Label ID="lblpass" runat="server" ForeColor="black"></asp:Label></p>
                        <br />
                        <hr />
                        <br />
                        <asp:Button ID="btnEditDetails" runat="server" Text="Edit Details" CssClass="btn" OnClick="btnEditDetails_Click" />
                        <br />
                        <br />
                        <asp:Button ID="btnAddItems" runat="server" Text="My renting items" CssClass="btn" OnClick="btnAddItems_Click" />
                        <br />
                        <br />
                        <asp:Button ID="btnLogout" runat="server" Text="LogOut" CssClass="btn" OnClick="btnLogout_Click" />
                        <br />
                    </div>
                </div>

                <!-- Right Panel: Available Items -->


                <div class="right-panel">
                    <asp:Label ID="lblData" runat="server" ForeColor="Red"></asp:Label>

                    <div style="margin-bottom: 20px; display: flex; gap: 10px;">
                        <asp:TextBox ID="txtSearchCategory" runat="server" CssClass="form-control" Placeholder="Enter category"></asp:TextBox>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" OnClick="btnSearch_Click"  />
                    </div>

                    <div class="items">
                        <asp:Repeater ID="rptItems" runat="server" OnItemCommand="rptItems_ItemCommand">
    <ItemTemplate>
        <div class="item" style="display: flex; align-items: flex-start; gap: 15px;">
            <!-- Image Section -->
            <div style="flex: 1;">
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' Height="300px" Width="300px" Style="border-radius: 8px;" />
            </div>

            <!-- Details Section -->
            <div style="flex: 2;" class="DivDetails">
                <p><strong>Item Name:</strong> <%# Eval("item_name") %></p>
                <p><strong>Description:</strong> <%# Eval("discription") %></p>
                <p><strong>Price:</strong> <%# Eval("price") %> per month</p>
                <p><strong>Deposit Amount:</strong> <%# Eval("deposit_amount") %></p>
                <p><strong>Penalty:</strong> <%# Eval("Penalty") %> per month</p>
                <p><strong>Available?</strong> <%# Eval("available") %></p>

                <!-- Buttons -->
                <div style="margin-top: 10px;" class="btnstyle">
                    <asp:Button 
                        ID="btnRented" 
                        runat="server" 
                        Text="Rent Now" 
                        CommandName="Rented" 
                        CommandArgument='<%# Eval("item_id") %>' 
                        CssClass="btn" 
                        Visible='<%# string.Equals(Eval("available").ToString().Trim(), "Yes", StringComparison.OrdinalIgnoreCase) %>' />
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>






