<%@ Page Title="My Ticket" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="ViewTicket.aspx.cs" Inherits="SkyAirline.Views.Search.ViewTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 20px; background-color: rgba(255,255,255,0.7);">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Ticket</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerName" CssClass="col-md-10 control-label">Passenger Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PassengerName" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerName"
                                CssClass="text-danger" ErrorMessage="The passenger name field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="FlightNumber" CssClass="col-md-10 control-label">Flight Number</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="FlightNumber" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FlightNumber"
                                CssClass="text-danger" ErrorMessage="The flight number field is required." />                            
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="DepartureLocation" CssClass="col-md-10 control-label">Departure Location</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="DepartureLocation" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartureLocation"
                                CssClass="text-danger" ErrorMessage="The departure location field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ArrivalLocation" CssClass="col-md-10 control-label">Arrival Location</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ArrivalLocation" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ArrivalLocation"
                                CssClass="text-danger" ErrorMessage="The arrival location field is required." />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="DepartureDate" CssClass="col-md-10 control-label">Departure Date</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="DepartureDate" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartureDate"
                                CssClass="text-danger" ErrorMessage="The departure date field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ArrivalDate" CssClass="col-md-10 control-label">Arrival Date</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ArrivalDate" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ArrivalDate"
                                CssClass="text-danger" ErrorMessage="The arrival date field is required." />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
