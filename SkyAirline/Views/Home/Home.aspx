<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SkyAirline._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card" style="height: 200px; background-color: rgba(255,255,255,0.7);">
        <div class="card-body">                       
            <asp:PlaceHolder runat="server" ID="AdminMessagePanel">
               <div class="row">
                    <div class="col text-center">
                         <h1>Welcome to SkyAirlines</h1>
                    </div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="UserMessagePanel">
                <div class="row">
                    <div class="col text-center">  
                        <h1>Welcome to SkyAirlines</h1>
                    </div>
                </div>
                <div class="row">
                </div>
                <div class="row">
                    <div class="col d-flex justify-content-center text-center">
                        <asp:HyperLink NavigateUrl="~/Views/Search/SearchFlights" Text="Search Flights" runat="server" CssClass="btn btn-primary"/>
                    </div>
                    <div class="col d-flex justify-content-center text-center">
                        <asp:HyperLink NavigateUrl="~/Views/Search/MyBookings" Text="View My Bookings" runat="server" CssClass="btn btn-primary"/>
                    </div>
                </div>                               
            </asp:PlaceHolder>
        </div>
    </div>

    <div class="container" style="margin-top: 50px;">
        <div class="row">
            <div class="col">
                <div class="card">
                  <img src="/Images/bid-upfront.png" class="card-img-top" alt="...">
                  <div class="card-img-overlay" style="margin-top: 90%; background-color: rgba(255,255,255,0.7);">
                    <h5 class="card-title">Bid. Fly. Enjoy</h5>
                    <p class="card-text">To be updated with actual contents.</p>
                    <button type="button" class="btn btn-outline-secondary">Learn more</button>
                  </div>
                </div>
            </div>

            <div class="col">
                <div class="card">
                  <img src="/Images/experience-dreamliner.png" class="card-img-top" alt="...">
                  <div class="card-img-overlay" style="margin-top: 90%; background-color: rgba(255,255,255,0.7);">
                    <h5 class="card-title">Experience Dreamliner</h5>
                    <p class="card-text">To be updated with actual contents.</p>
                    <button type="button" class="btn btn-outline-secondary">Learn more</button>
                  </div>
                </div>
            </div>

            <div class="col">
                <div class="card">
                    <img src="/Images/flying-returns.png" class="card-img-top" alt="...">
                    <div class="card-img-overlay" style="margin-top: 90%; background-color: rgba(255,255,255,0.7);">
                    <h5 class="card-title">Enjoy Flying Returns</h5>
                    <p class="card-text">To be updated with actual contents.</p>
                    <button type="button" class="btn btn-outline-secondary">Learn more</button>
                    </div>
                </div>
            </div>

            <div class="col">
                <div class="card">
                    <img src="/Images/maha-scholar.png" class="card-img-top" alt="...">
                    <div class="card-img-overlay" style="margin-top: 90%; background-color: rgba(255,255,255,0.7);">
                    <h5 class="card-title">SkyAirline Scholar's Scheme</h5>
                    <p class="card-text">To be updated with actual contents.</p>
                    <button type="button" class="btn btn-outline-secondary">Learn more</button>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
