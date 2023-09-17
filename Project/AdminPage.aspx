<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Project.AdminPage" %>
<%@ Register Src="~/User Controls/AddMovieUC.ascx" TagPrefix="UC" TagName="MovieForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <UC:MovieForm runat="server"></UC:MovieForm>

</asp:Content>
