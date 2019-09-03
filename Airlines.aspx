<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Airlines.aspx.cs" Inherits="Airlines" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <LINK href="MainDesign.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Open+Sans" />

<head runat="server">
    <title>Airlines</title>
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
             <asp:Label ID="title" runat="server" Text="Our Airlines.."></asp:Label><br />
            <p id="content">
                <asp:Table ID="Table1" runat="server" Height="62px" Width="57px">
                    <asp:TableRow>
                        <asp:TableCell>
                            <center>
                            <asp:Label ID="airlineNametxt" runat="server" Text="" CssClass="title02"></asp:Label>
                                </center>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Image ID="airlineImg" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <center>
                        <asp:Button id="nextButton" CssClass="btns" runat="server" Text="Next" onClick="nextButton_Click"></asp:Button>
                                </center>
                            </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

            </p>
                </center>
        </div>

    </form>
</body>
</html>
