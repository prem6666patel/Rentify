<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="Rentify.homePage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Online Rent Management System</title>
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
        .intro {
            margin-bottom: 30px;
            font-size: 18px;
            color: #555;
        }

        .fea{

            background-color:#97C4D2;
            padding-top:1rem;
            padding-bottom:1rem;
        }
        .features {
            display: flex;
            justify-content: space-around;
            flex-wrap: wrap;
            margin-top: 20px;
            background-color:#97C4D2;
            border-radius:10px;
        }
        .feature {
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
            width: 200px;
            margin: 10px;
            transition: transform 0.3s;
        }
        .feature:hover {
            transform: scale(1.05);
        }
        footer {
            background-color:black;
            color: white;
            text-align: center;
            padding: 15px;
            margin-top: 50px;
        }
        footer p {
            margin: 0;
        }

        .cat{

            background-color:#d9eecc;
            padding-top:1rem;
            padding-bottom:1rem;
            margin-top:2rem;
        }

        .categories {
            display: flex;
            justify-content: space-around;
            flex-wrap: wrap;
            margin-top: 20px;
            background-color:#d9eecc;
        }

        .category {
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
            width: 200px;
            margin: 10px;
            transition: transform 0.3s;
        }
        .category:hover {
            transform: scale(1.05);
        }
        .category img {
            width: 80px;
            height: 80px;
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
        <h1>Welcome Rentify</h1>
        <p class="intro">Facilitating the renting process for both providers and seekers across various categories such as vehicles, electronics, clothes, and properties.</p>
        
        <div class="fea">

        <h2>Key Functionalities</h2>
        <div class="features">
            <div class="feature">
                <h3>User Registration</h3>
                <p>Sign up to create an account and start renting or listing items.</p>
            </div>
            <div class="feature">
                <h3>Item Listing</h3>
                <p>Providers can easily list their items for rent with detailed descriptions.</p>
            </div>
            <div class="feature">
                <h3>Transaction Management</h3>
                <p>Manage your rentals and returns efficiently through our platform.</p>
            </div>
            <div class="feature">
                <h3>Return Processing</h3>
                <p>Secure Return for a hassle-free renting experience.</p>
            </div>
            <div class="feature">
                <h3>Review website</h3>
                <p>Rate and review website to help others make informed decisions.</p>
            </div>
        </div>

        </div>

        <div class="cat">

        <h2>Explore Our Categories</h2>
        <div class="categories">
            <div class="category">
                
                <h3>Vehicles</h3>
                <p>Cars, motorcycles, bicycles</p>
            </div>
            <div class="category">
               
                <h3>Electronics</h3>
                <p>Laptops, smartphones, tablets</p>
            </div>
            <div class="category">
                
                <h3>Clothes</h3>
                <p>Dresses, shirts, pants</p>
            </div>
            <div class="category">
                
                <h3>Properties</h3>
                <p>Houses, apartments, offices</p>
            </div>
        </div>
        </div>
    </main>
    <footer>
        <p>&copy; 2025 Renify. All Rights Reserved.</p>
    </footer>
    </form>
</body>
</html>