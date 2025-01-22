<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Rentify.ContactUs" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Contact Us</title>
    <style>
        body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f9f9f9;
}
header {
    background: #DCE4D7;
    color: white;
    padding: 15px 0;
    text-align: center;

}
header nav {
    display:flex;
    align-items:center;
    justify-content:space-between;
}
header nav a {
    color: black;
    text-decoration: none;
    margin: 0 15px;
    font-size: 18px;
    transition: color 0.3s;
}
header nav a:hover {
    color: #FFD700; /* Gold color on hover */
}
        main {
            padding: 20px;
            text-align: center;
        }
        h1 {
            color: #333;
        }
        .contact-form {
            margin: 0 auto;
            width: 50%;
            background: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
        .contact-form input,
        .contact-form textarea {
            width: 90%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .contact-form button {
            background:black;
            color: white;
            padding: 10px 15px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .contact-form button:hover {
            background: #003745;
        }
        .dropdown {
    position: relative;
    display: inline-block;
}
.dropbtn {
    color: black;
    text-decoration: none;
    font-size: 18px;
    margin: 0 15px;
    transition: color 0.3s;
}
.dropdown-content {
    display: none;
    position: absolute;
    background-color: white;
    min-width: 160px;
    box-shadow: 0px 8px 16px rgba(0, 0, 0, 0.2);
    z-index: 1;
}
.dropdown-content a {
    color: black;
    padding: 12px 16px;
    text-decoration: none;
    display: block;
    font-size: 16px;
}
.dropdown-content a:hover {
    background-color: #f1f1f1;
}
.dropdown:hover .dropdown-content {
    display: block;
}
.dropdown:hover .dropbtn {
    color: #FFD700;
}
.header-item{
    display:flex;
    align-items:center;
    justify-content:space-around;
}
.logo-com{
    display:flex;
    align-items:center;
    
}
 footer {
     background: #333;
     color: white;
     text-align: center;
     padding: 15px;
     margin-top:75px;
 }
 footer p {
     margin: 0;
 }


    </style>
</head>
<body>
    <form id="form1" runat="server">
      <header>
      <nav>
          <div class="logo-com">
          <asp:Image ID="Image1" runat="server" Height="79px" ImageUrl="~/photos/RENTIFY__LOGO.png" Width="102px" />
          <h1 style="margin: 0; font-size: 2.5rem; color: black;">Rentify</h1>
          </div>
          <div class="header-item">
          <a href="HomePage.aspx">Home</a>
          <a href="aboutUs.aspx">About Us</a>
          <a href="Categories.aspx">Categories</a>
          
         <div class="dropdown">
              <a href="#" class="dropbtn">Login</a>
              <div class="dropdown-content">
                  <a href="seekers_loginForm.aspx?type=seeker">Login as Seeker</a>
                  <a href="providers_loginForm.aspx?type=provider">Login as Provider</a>
                  <a href="admin_loginForm.aspx?type=admin">Login as Admin</a>
              </div>
          </div>

           <div class="dropdown">
    <a href="#" class="dropbtn">Sign in</a>
    <div class="dropdown-content">
        <a href="seekers_registration.aspx?type=seeker">register as Seeker</a>
        <a href="providers_registration.aspx?type=provider">register as Provider</a>
    </div>
</div>
          <a href="OurValues.aspx">Our Values</a>
          <a href="ContactUs.aspx">Contact Us</a>
          </div>

      </nav>
  </header>
    <main>
        <div class="contact-form">
            <h2>We'd love to hear from you!</h2>
            <asp:Label ID="lblName" runat="server" Text="Your Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            
            <asp:Label ID="lblEmail" runat="server" Text="Your Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            
            <asp:Label ID="lblMessage" runat="server" Text="Your Message:"></asp:Label><br />
            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox><br />
            
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

            <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label>
        </div>
    </main>
         <footer>
     <p>&copy; 2025 Renify. All Rights Reserved.</p>
 </footer>
    </form>
</body>
</html>
