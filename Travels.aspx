<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Travels.aspx.cs" Inherits="Travels" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
      <LINK href="MainDesign.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Open+Sans" />
<head runat="server">
    <title>Travels</title>
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
             <center>
             <asp:Label ID="title" runat="server" Text="Our travels, book your seat now!"></asp:Label><br />
             
            <p id="content">

            <asp:Table ID="travelsTbl" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                       <asp:Label ID="traCountry" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                     </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                          <asp:Label ID="traAirline" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                        </asp:TableRow>

                <asp:TableRow>
                      <asp:TableCell>
                       <asp:Label ID="traPrice" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                     </asp:TableRow>

                      <asp:TableRow>
                      <asp:TableCell>
                       <asp:Label ID="traDate" runat="server" Text=""></asp:Label>
                    </asp:TableCell>
                     </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                          <asp:Image ID="traImg" ImageUrl="Images/" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>
                          <asp:Button ID="BookBtn" runat="server" CssClass="btns" Text="Book" OnClick="BookButton_Click"></asp:Button>
                          <asp:Button ID="NextBtn" runat="server" CssClass="btns" Text="Next" OnClick="nextButton_Click"></asp:Button>
                    </asp:TableCell>
                </asp:TableRow>
              </asp:Table>

                     <asp:Label ID="doneLab" runat="server" Text="You've booked your seat successfully!"></asp:Label>
                     <asp:Label ID="errorLab" runat="server" Text="Please Sign in first :)"></asp:Label>
              </p>
              </center>
             </div>
    </form>
</body>
</html>
