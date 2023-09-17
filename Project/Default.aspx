<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project._Default" %>
<%@ Register Src="~/User Controls/MovieUC.ascx" TagPrefix="UC" TagName="MovieCard" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <UC:MovieCard runat="server"></UC:MovieCard>
</asp:Content>
