<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MovieUC.ascx.cs" Inherits="Project.User_Controls.MovieUC" %>
<style>
    .poster{
        width:100%;
        height: 270px;
    }
    .genreList{
        list-style: none;
        gap:10px;
    }
    .duration{
        gap:30px;
    }
    .card{
        padding:25px;
    }
    
</style>


<div class="card bg-primary text-white" style="width: 30rem;">
  <img class="card-img-top poster rounded" src="../img/peakpx.jpg" alt="Card image cap">
  <div class="card-body">
      <div class="d-flex justify-content-between align-items-center mb-4">
          <h1 class="card-title">Avengers<sub>(2020)</sub></h1>
          <strong>Ratings</strong>
      </div>
          <div class="d-flex align-items-center">
              <strong class="text-dark">Genres:</strong>
              <ul class="d-flex flex-wrap genreList m-0 align-items-center">
                  <li>genre</li>
                  <li>genre</li>
                  <li>genre</li>
              </ul>
          </div>
          <div class="d-flex duration my-2 align-items-center">
            <strong class="text-dark">Duration:</strong>
            <p class="m-0">1h 50m</p>
          </div>
          <div class="d-flex align-items-center">
              <strong class="text-dark">Resolution:</strong>
              <ul class="d-flex flex-wrap genreList align-items-center m-0">
                  <li>1080p</li>
                  <li>4k</li>
              </ul>
          </div>
          <div>
              <strong class="text-dark">Details:</strong>
                <p class="card-text px-2">Some quick example text to build on the card title and make up the bulk of 
                    the card's content.
                </p>
          </div>
          <div class="d-flex justify-content-between align-items-center mt-2">
            <a href="#" class="btn btn-warning text-light">Add To Cart</a>        
            <h2 class="text-warning">$10</h2>
          </div>
  </div>
</div>