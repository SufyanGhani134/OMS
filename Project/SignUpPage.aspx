<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="Project.SignUpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container text-light d-flex flex-column align-items-center mt-4">
        <div class="alert w-75 alert-danger alert-dismissible fade show" role="alert" id="SignUpAlert" style="display:none;" >
            <strong>Holy guacamole!</strong> You should check in on some of those fields below.
        </div>
        <h1>Sign Up</h1>
        <div class="d-flex w-75 justify-content-between p-3">
            <div class="form-group inputGroup">
                <label for="fname">First Name</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="fname" placeholder="First Name">
                </asp:TextBox>
            </div>

            <div class="form-group inputGroup">
                <label for="lname">Last Name</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="lname" placeholder="Last Name">
                </asp:TextBox>
            </div>
        </div>
        
        <div class="d-flex w-75 justify-content-between p-3">
            <div class="form-group inputGroup">
                <label for="dob">Date Of Birth</label>
                <asp:TextBox  runat="server" type="date" class="form-control" id="dob" placeholder="Date Of Birth">
                    </asp:TextBox>
            </div>

            <div class="form-group inputGroup">
                <label for="email">Email</label>
                <asp:TextBox runat="server" type="email" class="form-control" id="email" placeholder="Enter your Email">
                    </asp:TextBox>
            </div>
        </div>

        <div class="d-flex w-75 justify-content-between p-3">
            <div class="form-group inputGroup">
                <label for="password">Password</label>
                <asp:TextBox runat="server" type="password" class="form-control" id="password" placeholder="Password">
                    </asp:TextBox>
            </div>

            <div class="form-group inputGroup">
                <label for="confirmPassword">Confirm Password</label>
                <asp:TextBox runat="server" type="password" class="form-control" id="confirmPassword" placeholder="Confirm Password">
                    </asp:TextBox>
            </div>
         </div>
        <div class="w-75 p-3">
            <div class="form-check">
                <input type="checkbox" class="form-check-input" id="exampleCheck1">
                <label class="form-check-label" for="exampleCheck1">Agree with Terms & Conditions</label>
            </div>
            <asp:Button runat="server" type="button"  ID="SignUpBtn"  Cssclass="btn btn-primary my-4" 
                Text="Sign Up" OnClientClick="return false" >
            </asp:Button>
        </div>
     </div>
    <script src="myScripts/SignUpScript.js?v=1"></script>

</asp:Content>
