<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <LINK href="MainDesign.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Open+Sans" />

<head runat="server">
    <title>Sign up</title>
</head>
<body background="Images/main2.jpg">
    <form id="form1" runat="server">
      <div id="header">
      <asp:Image ID="logo" src="Images/logop.png" runat="server" />

          <div id="options">
            <asp:LinkButton ID="about" runat="server" Text="About" href="About.aspx" CssClass="link"></asp:LinkButton>
        <asp:LinkButton ID="travels" runat="server" Text="Travels" href="Travels.aspx" CssClass="link"></asp:LinkButton>
        <asp:LinkButton ID="airlines" runat="server" Text="Airlines" href="Airlines.aspx" CssClass="link"></asp:LinkButton>
        <asp:LinkButton ID="countries" runat="server" Text="Countries" href="Countries.aspx" CssClass="link"></asp:LinkButton>
                         <asp:LinkButton ID="name" runat="server" Text="name" href="#" CssClass="link"></asp:LinkButton>
        <asp:LinkButton ID="signUp" runat="server" Text="Sign up" href="SignUp.aspx" CssClass="link"></asp:LinkButton>
       
        <asp:LinkButton ID="signIn" runat="server" Text="Sign in" href="SignIn.aspx" CssClass="link"></asp:LinkButton>
        <asp:LinkButton ID="logout" runat="server" Text="Log out" href="LogOut.aspx" CssClass="link"></asp:LinkButton>
 
          </div>
      </div>

          <div class="divClass">
              
           
            <p id="content">
                <center>
                <asp:Label ID="title" runat="server" Text="Sign up and start traveling the world.."></asp:Label><br />

               <asp:Label ID="fnameError" class="errors" runat="server" Text=""></asp:Label><br />
              <asp:TextBox id="fnametxt" CssClass="inputFld" runat="server" placeholder="First name"></asp:TextBox><br />
           <asp:Label ID="lnameError" class="errors" runat="server" Text=""></asp:Label> <br />
              <asp:TextBox id="lnametxt" CssClass="inputFld" runat="server" placeholder="Last name"></asp:TextBox>
                      <br />
                    <asp:Label ID="emailError" class="errors" runat="server" Text=""></asp:Label><br />
              <asp:TextBox id="emailtxt" CssClass="inputFld" runat="server" placeholder="Email"></asp:TextBox>
                  
                        <br />
               <asp:Label ID="passwordError" class="errors" runat="server" Text=""></asp:Label><br />
              <asp:TextBox id="passwordtxt" CssClass="inputFld" runat="server" TextMode="password" placeholder="Password"></asp:TextBox>
                 
                      <br />
                    <asp:Label ID="addressError" class="errors" runat="server" Text=""></asp:Label><br />
              <asp:TextBox id="addresstxt" CssClass="inputFld" runat="server" placeholder="Address"></asp:TextBox>
                
                         <br />
              <asp:Button id="signUpbtn" CssClass="btns" runat="server" Text="Sign up" OnClick="signUpbtn_Click"></asp:Button>
              
                    </center>
             </p>
               </div>
    </form>
</body>
</html>
