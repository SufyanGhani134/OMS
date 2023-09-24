<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMovieUC.ascx.cs" ClientIDMode="Static" Inherits="Project.User_Controls.AddMovieUC" %>
<div class="container bg-light d-flex flex-column p-5 rounded-3 mt-3" style="gap:1rem;">
    <div class="alert w-75 alert-danger alert-dismissible fade show" role="alert" id="AddMovieAlert" style="display:none;" >
            <strong>Holy guacamole!</strong> You should check in on some of those fields below.
    </div>
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
       
        <%
          foreach(var items in getResolution())
            {
                %>
                <div class="form-check">
                    <input type="checkbox" class="form-check-input resolutionArr" value="<%= items %>">
                    <label class="form-check-label" for="exampleCheck1" ><%= items %></label>
                 </div>
                <%
            }
            %>
    </div>
        
    <div class="d-flex justify-content-evenly w-100"> 
        <div class="d-flex w-50 justify-content-evenly">
            <label class="col-sm-2 col-form-label"><strong>Duration :</strong></label>
            <input type="number" class="form-control w-25" id="hrs">
            <strong>hrs.</strong>
            <input type="number" class="form-control w-25" id="mins">
            <strong>mins.</strong>
        </div>
        <div class="d-flex align-items-center">
            <label><strong>Ratings :</strong></label>
            <input class="form-control w-25 mx-1" id="rating"/><strong>/ 10</strong>
        </div>
    </div>
    <div class="input-group">
          <div class="input-group-prepend">
            <span class="input-group-text">Description :</span>
          </div>
          <textarea class="form-control mx-1" aria-label="With textarea" id="description"></textarea>
    </div>

    <div class="form-group">
        <label for="exampleFormControlFile1"><strong>Movie Poster :</strong></label>
        <input type="file" class="form-control-file" id="poster">
    </div>

    <div class="d-flex w-100 justify-content-between">
        <div class="d-flex justify-content-evenly w-50 flex-wrap align-items-center">
            <label><strong>Genres :</strong></label>
            <% foreach(var item in getGenres())
            {
                    %>
                <div class="form-check">
                        <input type="checkbox" class="form-check-input genres" value="<%= item %>">
                        <label class="form-check-label" for="exampleCheck1"><%= item %></label>
                </div>
            <%

            } %>
          
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
      <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)" id="price" />
    </div>
    <div class="d-flex w-100 justify-content-center ">
        <asp:Button runat="server" type="button" class="btn btn-primary"
                        id="addMovie" Text="Add Movie" OnClientClick="return false">
                    </asp:Button>
    </div>
</div>


