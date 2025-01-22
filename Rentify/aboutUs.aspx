<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutUs.aspx.cs" Inherits="Rentify.aboutUs" %>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>About Us - Online Rent Management System</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }
        header {
            background: #DCE4D7;
            color:black;
            padding: 15px 0;
            text-align: center;
        }
        header nav {
            display: flex;
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
        .mission {
            margin: 20px 0;
            font-size: 18px;
            color: #555;
        }
        .team {
            display: flex;
            justify-content: space-around;
            flex-wrap: wrap;
            margin-top: 20px;
        }
        .team-member {
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
            width: 200px;
            margin: 10px;
        }
        footer {
            background: #333;
            color: white;
            text-align: center;
            padding: 15px;
           // margin-top:5px;
        }
        footer p {
            margin: 0;
        }

        .categories {
    display: flex;
    justify-content: space-around;
    flex-wrap: wrap;
    margin-top: 20px;
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
     <header>
     <nav>
         <div class="logo-com">
<asp:Image ID="Image1" runat="server" Height="79px" ImageUrl="~/photos/RENTIFY__LOGO.png" Width="102px" />
<h1 style="margin: 0; font-size: 2.5rem; color: black;">      Rentify</h1>
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
        <h1>About Us</h1>
        <p class="mission">At Rentify, our mission is to simplify the renting process for both Seekers and Providers. We aim to provide a seamless platform that connects people with the items they need, while empowering sellers to reach a wider audience.</p>
        
        <h2>Our Vision</h2>
        <p>We envision a world where renting is as easy as clicking a button, making it accessible for everyone to find and rent items efficiently.</p>
        
        <h2>Meet Our Team</h2>
        <div class="team">
            <div class="team-member">
                <h3>Prem patel</h3>
                <p>CEO & Founder</p>
                <p>Passionate about technology and innovation, prem leads the team with a vision for a better renting experience.</p>
            </div>
            <div class="team-member">
                <h3>Harsh Rana</h3>
                <p>CTO</p>
                <p>With a strong background in software development, harsh oversees the technical aspects of the platform.</p>
            </div>
            <div class="team-member">
                <h3>shubham patel</h3>
                <p>Marketing Director</p>
                <p>shubham is responsible for spreading the word about our platform and connecting with our users.</p>
            </div>
            <div class="team-member">
                <h3>Tapan patel</h3>
                <p>Customer Support</p>
                <p>Tapan ensures that our users have the best experience and addresses any concerns they may have.</p>
            </div>
        </div>
    </main>
    <footer>
        <p>&copy; 2025 Rentify. All Rights Reserved.</p>
    </footer>
</body>
</html>