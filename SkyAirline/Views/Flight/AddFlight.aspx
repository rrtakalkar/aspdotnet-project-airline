<%@ Page Title="Flight" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="AddFlight.aspx.cs" Inherits="SkyAirline.Views.Flight.AddFlight" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 20px; background-color: rgba(255,255,255,0.7);">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Create a new flight</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="FlightNumber" CssClass="col-md-10 control-label">Flight Number</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="FlightNumber" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FlightNumber"
                        CssClass="text-danger" ErrorMessage="The flight number field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Departure" CssClass="col-md-10 control-label">Departure Location</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="Departure"  CssClass="form-control"/>             
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Departure"
                        CssClass="text-danger" ErrorMessage="The departure field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Arrival" CssClass="col-md-10 control-label">Arrival Location</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="Arrival"  CssClass="form-control"/>             
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Arrival"
                        CssClass="text-danger" ErrorMessage="The arrival field is required." />
                    <asp:CompareValidator runat="server" ID="CompareLocations" ControlToValidate="Departure" 
                                ControlToCompare="Arrival" Operator="NotEqual" Type="String" 
                                CssClass="text-danger" ErrorMessage="The departure and arrival locations should not be same!" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="EconomyClassSeats" CssClass="col-md-10 control-label">Economy Class Seats</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="EconomyClassSeats" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EconomyClassSeats"
                        CssClass="text-danger" ErrorMessage="The economy class seats field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="BusinessClassSeats" CssClass="col-md-10 control-label">Business Class Seats</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="BusinessClassSeats" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="BusinessClassSeats"
                        CssClass="text-danger" ErrorMessage="The buisness class seats field is required." />
                </div>
            </div>
             <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Insert" OnClick="addFlightForm_Click" CssClass="btn btn-primary btn-sm" />
                    <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" CssClass="btn btn-secondary btn-sm"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
