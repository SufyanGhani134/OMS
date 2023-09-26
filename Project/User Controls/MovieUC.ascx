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


<div class="bg-primary text-white rounded" style="width: 30%;">
  <img class="card-img-top poster" src="../img/peakpx.jpg" alt="Card image cap">
  <div>
      <div class="d-flex justify-content-between align-items-center mx-2">
          <h3 class="card-title">
              <i class="bi bi-chevron-up px-3"></i>Avengers<sub>(2020)</sub>
          </h3>
          <strong>Ratings</strong>
      </div>
          <div class="d-flex justify-content-between align-items-center m-4">
            <button  class="btn btn-warning text-light">Add To Cart</button>        
            <h2 class="text-warning">$10</h2>
          </div>
  </div>
</div>