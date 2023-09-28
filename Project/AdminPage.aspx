<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Project.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <input type="hidden" id="arrayData" name="arrayData" runat="server"  />
    <div class="container bg-light d-flex flex-column p-5 rounded-3 mt-3" style="gap:1rem;">
    <div class="d-flex w-100 justify-content-center">
        <div class="d-flex w-25 align-items-center">
           <label for="movieTitle"><strong>Title :</strong></label>
           <asp:TextBox runat="server" type="text" class="form-control w-75 mx-2" id="movieTitle" placeholder="Movie Title" >
           </asp:TextBox>
        </div>
        <div class="d-flex w-25 align-items-center">
           <label for="releaseYear"><strong>Release Year :</strong></label>
           <asp:TextBox runat="server" type="text" class="form-control w-50 mx-2" id="releaseYear" placeholder="Release Year">
           </asp:TextBox>
        </div>
    </div>
   <div class="d-flex justify-content-evenly w-50 align-items-center">
        <label><strong>Resolutions :</strong></label>
       <asp:CheckBoxList runat="server" ID="ResolutionList" RepeatDirection="Horizontal">
           

       </asp:CheckBoxList>
       
    </div>

        
    <div class="d-flex justify-content-evenly w-100"> 
        <div class="d-flex w-50 justify-content-evenly">
            <label class="col-sm-2 col-form-label"><strong>Duration :</strong></label>
            <asp:TextBox runat="server" type="number" class="form-control w-25" id="hrs"></asp:TextBox>
            <strong>hrs.</strong>
            <asp:TextBox runat="server" type="number" class="form-control w-25" id="mins"></asp:TextBox>
            <strong>mins.</strong>
        </div>
        <div class="d-flex align-items-center">
            <label><strong>Ratings :</strong></label>
            <asp:Textbox runat="server" class="form-control w-25 mx-1" id="rating"/><strong>/ 10</strong>
        </div>
    </div>
    <div class="input-group">
          <div class="input-group-prepend">
            <span class="input-group-text">Description :</span>
          </div>
          <textarea runat="server" class="form-control mx-1" aria-label="With textarea" id="description"></textarea>
    </div>

    <div class="form-group">
        <label for="exampleFormControlFile1"><strong>Movie Poster :</strong></label>
        <asp:FileUpload ID="poster" runat="server" CssClass="form-control-file" />
    </div>

    <div class="d-flex w-100 justify-content-between">
        <div runat="server" class="d-flex justify-content-evenly w-50 flex-wrap align-items-center" id="genreContainer">
            <label><strong>Genres :</strong></label>
          
        </div>
        <div class="d-flex align-items-center" style="gap:0.5rem;">
            <label>Others: </label>
            <input class="form-control w-50" id="newGenre" />
            <asp:Button runat="server" OnClientClick="return false" 
                class="btn btn-outline-primary" id="addGenre" Text="Add New Genre">
            </asp:Button>
        </div>
    </div>
    <div class="d-flex justify-content-center">
        <strong class="px-2">Selected Genres:</strong>
        <ul class="w-75 selectedItems d-flex " id="selectedGenres">

        </ul>
    </div>

    <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text">Price: $</span>
          </div>
      <asp:TextBox runat="server" type="text" class="form-control" aria-label="Amount (to the nearest dollar)" id="price" />
    </div>
    <div class="d-flex w-100 justify-content-center ">
        <asp:Button runat="server" type="button" class="btn btn-primary" 
            ID="addMovie" Text="Add Movie" OnClientClick="return AddMovie()" OnClick="addMovie_Click">
                    </asp:Button>
    </div>
</div>
    <script src='<%=ResolveClientUrl("myScripts/AddMovie.js?v=1.5") %>'></script>
</asp:Content>
