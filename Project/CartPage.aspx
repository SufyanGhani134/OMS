﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Project.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .cartTable{
                border: solid 1px white;
                width: 100%;
                background: steelblue;
                color: aliceblue;
                text-align: center;
        }
        .cartTable th{
                padding: 10px 20px;
                text-align: center;
        }
        .cartTable td{ 
            border: solid 1px;
        }
    </style>
    <h1>Cart Page</h1> 
    <div class="container text-light">
        <table class="cartTable">
           <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">poster</th>
                  <th scope="col">Movie Title</th>
                  <th scope="col">Checked In Date</th>
                  <th scope="col">Cost</th>
                </tr>
          </thead>
            <tbody id="cartTableBody">
            
          </tbody>
        </table>
        <div>
            <button type="button" id="checkOutBtn" class="btn btn-primary w-100">Check out</button>
        </div>
        
    </div>
    <script src='<%=ResolveClientUrl("~/myScripts/getCartIDScript.js") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/GetCartScript.js") %>' 
    type="text/javascript"></script>
</asp:Content>
