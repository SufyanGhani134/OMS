<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="Project.UserPage" %>
<%@ Register Src="~/User Controls/MovieUC.ascx" TagPrefix="UC" TagName="MovieCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <UC:MovieCard runat="server"></UC:MovieCard>
</asp:Content>
