<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Project.UserPage" %>
<%@ Register Src="~/User Controls/MovieUC.ascx" TagPrefix="UC" TagName="MovieCard" %>
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
    
    <div id="movieContainer" class="d-flex justify-content-evenly flex-wrap my-3">

    </div>
    <script src='<%=ResolveClientUrl("~/myScripts/GetMovie.js") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/DisplayMovies.js") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/AddCart.js") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/GetCartID.js") %>' 
    type="text/javascript"></script>
</asp:Content>
