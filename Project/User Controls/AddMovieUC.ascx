<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddMovieUC.ascx.cs" ClientIDMode="Static" Inherits="Project.User_Controls.AddMovieUC" %>
<div class="container bg-light d-flex flex-column p-5 rounded-3 mt-3" style="gap:1rem;">
    <asp:HiddenField runat="server" ID="genre"/>
    <div class="d-flex w-100 justify-content-center">
        <div class="d-flex w-25 align-items-center">
           <label for="fname"><strong>Title :</strong></label>
           <asp:TextBox runat="server" type="text" class="form-control w-75 mx-2" id="movieTitle" placeholder="Movie Title">
           </asp:TextBox>
        </div>
        <div class="d-flex w-25 align-items-center">
           <label for="fname"><strong>Release Year :</strong></label>
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
                    <input type="checkbox" class="form-check-input">
                    <label class="form-check-label" for="exampleCheck1"><%= items %></label>
                 </div>
                <%
            }
            %>
    </div>
        
    <div class="d-flex justify-content-evenly w-100"> 
        <div class="d-flex w-50 justify-content-evenly">
            <label for="inputPassword" class="col-sm-2 col-form-label"><strong>Duration :</strong></label>
            <input type="number" class="form-control w-25" id="inputPassword">
            <strong>hrs.</strong>
            <input type="number" class="form-control w-25">
            <strong>mins.</strong>
        </div>
        <div class="d-flex align-items-center">
            <label><strong>Ratings :</strong></label>
            <input class="form-control w-25 mx-1"/><strong>/ 10</strong>
        </div>
    </div>
    <div class="input-group">
          <div class="input-group-prepend">
            <span class="input-group-text">Description :</span>
          </div>
          <textarea class="form-control mx-1" aria-label="With textarea"></textarea>
    </div>

    <div class="form-group">
        <label for="exampleFormControlFile1"><strong>Movie Poster :</strong></label>
        <input type="file" class="form-control-file" id="exampleFormControlFile1">
    </div>

    <div class="d-flex w-100 justify-content-between">
        <div class="d-flex justify-content-evenly w-50  align-items-center">
            <label><strong>Genres :</strong></label>
            <div class="form-check">
                    <input type="checkbox" class="form-check-input">
                    <label class="form-check-label" for="exampleCheck1">Genre</label>
            </div>
            <% foreach(var item in genre.Value)
            {
                    %>
                <div class="form-check">
                        <input type="checkbox" class="form-check-input">
                        <label class="form-check-label" for="exampleCheck1"><%= item %></label>
                </div>
            <%

            } %>
          
        </div>
        <div class="d-flex align-items-center" style="gap:0.5rem;">
            <label>Others: </label>
            <input class="form-control w-50" />
            <button class="btn btn-outline-primary">Add New Genre</button>
        </div>
    </div>
    <div class="d-flex justify-content-center">
        <ul class="w-75 selectedItems">
            <li>selected genre</li>
        </ul>
    </div>

    <div class="input-group mb-3">
          <div class="input-group-prepend">
            <span class="input-group-text">Price: $</span>
          </div>
      <input type="text" class="form-control" aria-label="Amount (to the nearest dollar)">
    </div>
    <div class="d-flex w-100 justify-content-center ">
        <asp:Button runat="server" type="button" class="btn btn-primary"
                        id="addMovie" Text="Add Movie">
                    </asp:Button>
    </div>
</div>
