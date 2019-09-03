<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Countries.aspx.cs" Inherits="Countries" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <LINK href="MainDesign.css" rel="stylesheet" type="text/css">
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Open+Sans" />

<head runat="server">
    <title>Countries</title>
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
             <asp:Label ID="title" runat="server" Text="Our Countries.."></asp:Label><br />
            <p id="content">


                 <asp:Table ID="userTbl" runat="server" Height="62px" Width="57px">
                    <asp:TableRow>
                        <asp:TableCell>
                            <center>
                            <asp:Label ID="countryNametxt" runat="server" Text="" CssClass="title02"></asp:Label>
                                </center>
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Image ID="countryImg" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                       
                     <asp:TableRow>
                         <asp:TableCell>
                             <asp:Label ID="historyLab" runat="server" Text=""></asp:Label>
                         </asp:TableCell>
                     </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                     
                        <asp:Button id="nextButton" CssClass="btns" runat="server" Text="Next" onClick="nextButton_Click"></asp:Button>  
                     </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                
                
                  <asp:Table ID="mangTbl" runat="server">
                      <asp:TableRow>
                        <asp:TableCell>
                          <asp:TextBox ID="countryNameUpd" runat="server"></asp:TextBox>
                        </asp:TableCell>
                      </asp:TableRow>

                      <asp:TableRow>
                           <asp:TableCell>
                           <asp:TextBox ID="countryDescUpd" runat="server"></asp:TextBox>
                        </asp:TableCell>
                      </asp:TableRow>

                      <asp:TableRow>
                          <asp:TableCell>
                               <asp:Button ID="nextUpdBtn" CssClass="btns" runat="server" Text="Next" OnClick="nextButton_Click"></asp:Button>
                               <asp:Button ID="updateBtn" CssClass="btns" runat="server" Text="Update" OnClick="updateButton_Click"></asp:Button>
                                <asp:Button ID="delBtn" CssClass="btns" runat="server" Text="Delete" onClick="DeleteButton_Click"></asp:Button>
                         </asp:TableCell>
                      </asp:TableRow>
                  </asp:Table>

            </p>
                 </center>
        </div>

    </form>
</body>
</html>
