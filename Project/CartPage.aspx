<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="Project.CartPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .cartTable{
                border: solid 1px white;
                width: 100%;
                background: steelblue;
                color: aliceblue;
                text-align: center;
        }
        .cartTable th{
                padding: 10px 20px;
                text-align: center;
        }
        .cartTable td{ 
            border: solid 1px;
        }
    </style>
    <h1>Cart Page</h1> 
    <div class="container text-light">
        <table class="cartTable">
           <thead>
                <tr>
                  <th scope="col">#</th>
                  <th scope="col">poster</th>
                  <th scope="col">Movie Title</th>
                  <th scope="col">Checked In Date</th>
                  <th scope="col">Cost</th>
                </tr>
          </thead>
            <tbody id="cartTableBody">
            
          </tbody>
        </table>
        <div>
            <asp:Button runat="server" type="button" id="checkOutBtn" data-bs-toggle="modal" data-bs-target="#receiptBtn"
                class="btn btn-primary w-100" Text="Check out" OnClientClick="return false">
                
            </asp:Button>
        </div>
        <div class="modal fade" id="receiptBtn" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
              <div class="modal-dialog">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  </div>
                  <div class="modal-body" id="receiptBody">
                      <p>Body</p>
                    
                  </div>
                  <div class="modal-footer">
                    <asp:Button runat="server" type="button" class="btn btn-secondary" data-bs-dismiss="modal" Text="Close"></asp:Button>
                  </div>
                </div>
              </div>
       </div>

    </div>
    <script src='<%=ResolveClientUrl("~/myScripts/getCartIDScript.js") %>' 
    type="text/javascript"></script>
    <script src='<%=ResolveClientUrl("~/myScripts/GetCartScript.js?v=1.2") %>' 
    type="text/javascript"></script>
</asp:Content>
