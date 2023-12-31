﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="Project.SignUpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container text-light d-flex flex-column align-items-center mt-4">
        <h1>Sign Up</h1>
        <div class="d-flex w-75 justify-content-between p-3">
            <div class="form-group inputGroup">
                <label for="fname">First Name</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="fname" placeholder="First Name">
                </asp:TextBox>
                <asp:RegularExpressionValidator id="fnameValidator" 
                     ControlToValidate="fname"
                     ValidationExpression="^[a-zA-Z]+$"
                     Display="Dynamic" ForeColor="red"
                     ErrorMessage="*Alphabets only"
                     runat="server"/>
            </div>

            <div class="form-group inputGroup">
                <label for="lname">Last Name</label>
                <asp:TextBox runat="server" type="text" class="form-control" id="lname" placeholder="Last Name">
                </asp:TextBox>
                <asp:RegularExpressionValidator id="lnameValidator" 
                     ControlToValidate="lname"
                     ValidationExpression="^[a-zA-Z]+$"
                     Display="Dynamic" ForeColor="red"
                     ErrorMessage="*Alphabets only"
                     runat="server"/>
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
                <asp:RegularExpressionValidator id="emailValidator" 
                     ControlToValidate="email"
                     ValidationExpression="^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"
                     Display="Dynamic" ForeColor="red"
                     ErrorMessage="* email must be of format abc@example.com"
                     runat="server"/>

            </div>
        </div>

        <div class="d-flex w-75 justify-content-between p-3">
            <div class="form-group inputGroup">
                <label for="password">Password</label>
                <asp:TextBox runat="server" type="password" class="form-control" id="password" placeholder="Password">
                    </asp:TextBox>
                 <asp:RegularExpressionValidator id="passwordValidator" 
                     ControlToValidate="password"
                     ValidationExpression="^.{8,}$"
                     Display="Dynamic" ForeColor="red"
                     ErrorMessage="* password must be atleast 8 characters"
                     runat="server"/>
            </div>

            <div class="form-group inputGroup">
                <label for="confirmPassword">Confirm Password</label>
                <asp:TextBox runat="server" type="password" class="form-control" id="confirmPassword" placeholder="Confirm Password">
                    </asp:TextBox>
                <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="password" 
                ControlToValidate="confirmPassword" Operator="Equal" 
                    ErrorMessage="* Passwords must match" ForeColor="red"></asp:CompareValidator>
            </div>
         </div>
        <div class="w-75 p-3">
            <div class="form-check">
                <input type="checkbox" class="form-check-input" id="exampleCheck1">
                <label class="form-check-label" for="exampleCheck1">Agree with Terms & Conditions</label>
            </div>
            <asp:Button runat="server" type="button"  ID="SignUpBtn"  Cssclass="btn btn-primary my-4" 
                Text="Sign Up" OnClick="SignUpBtn_Click" >
            </asp:Button>
        </div>
     </div>
    <script src="myScripts/SignUp.js?v=1.4"></script>


</asp:Content>
