<%@ Page Title="Book Ticket" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="BookTicket.aspx.cs" Inherits="SkyAirline.Views.Search.BookTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 20px; background-color: rgba(255,255,255,0.7);">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Boot ticket for  yourself</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ScheduleID" CssClass="col-md-10 control-label">Flight Schedule ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ScheduleID" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ScheduleID"
                                CssClass="text-danger" ErrorMessage="The scheduler id is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerID" CssClass="col-md-10 control-label">Passenger ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PassengerID" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerID"
                                CssClass="text-danger" ErrorMessage="The passenger id field is required." />                            
                        </div>
                    </div>
                </div>
            </div>

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

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PaymentMode" CssClass="col-md-10 control-label">Mode of Payment</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="PaymentMode"  CssClass="form-control"/>             
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PaymentMode"
                                CssClass="text-danger" ErrorMessage="The mode of payment field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="SeatClass" CssClass="col-md-10 control-label">Class of seats</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="SeatClass"  CssClass="form-control" AutoPostBack="True" onselectedindexchanged="seatClass_SelectedIndexChanged"/>             
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="SeatClass"
                                CssClass="text-danger" ErrorMessage="The class of seat field is required." />
                        </div>
                    </div>
                </div>
            </div> 
            
            <div class="row">
                <div class="col">                    
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PaymentAmount" CssClass="col-md-10 control-label">Payment Amount</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PaymentAmount" CssClass="form-control" TextMode="SingleLine" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PaymentAmount"
                                CssClass="text-danger" ErrorMessage="The payment amount field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                </div>
            </div>
            
             <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Book Ticket" OnClick="bookTicketForm_Click" CssClass="btn btn-primary btn-sm" />
                    <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" CssClass="btn btn-secondary btn-sm"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
