<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Project.UserPage"  %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <style>
    .poster{
        width:100%;
        height: 270px;
    }
    .cardList{
        list-style: none;
        gap:10px;
    }
    .duration{
        gap:30px;
    }
    .card{
        padding:25px;
    }
    .cardList li{
        padding: 5px 10px;
        border-radius: 20px;
    }
    .genreList li{
        background: slateblue;
    }
    .resolutionsList li{
        background: teal;
    }
    .detail{
        width: 90%;
    background: darkgray;
    padding: 10px;
    border-radius: 10px;
    }
</style>
   
     <input type="hidden" id="cartItems" name="arrayData" runat="server"   enableviewstate="false" />

    <div id="movieContainer" class="d-flex justify-content-evenly flex-wrap my-3">

    </div>
    <script src='<%=ResolveClientUrl("~/myScripts/GetMovie.js") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/DisplayMovies.js?v=1.5") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/AddCart.js?v=2.1") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/AlertMsg.js") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/GetCartID.js?v=1.2") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/GetCartAndCheckOut.js") %>' 
    type="text/javascript"></script>
</asp:Content>
