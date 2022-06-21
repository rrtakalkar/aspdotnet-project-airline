<%@ Page Title="SearchFlights" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="SearchFlights.aspx.cs" Inherits="SkyAirline.Views.Schedule.SearchFlights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 20px; background-color: rgba(255,255,255,0.7);">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Search for flights </h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Departure" CssClass="col-md-10 control-label">Departure Location</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="Departure"  CssClass="form-control"/>             
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Departure"
                                CssClass="text-danger" ErrorMessage="The departure field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="DepartureDate" CssClass="col-md-10 control-label">Date of Departure</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="DepartureDate" CssClass="form-control" TextMode="Date" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartureDate"
                                CssClass="text-danger" ErrorMessage="The date of departure field is required." />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
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
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ArrivalDate" CssClass="col-md-10 control-label">Date of Arrival</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="ArrivalDate" CssClass="form-control" TextMode="Date" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ArrivalDate"
                                CssClass="text-danger" ErrorMessage="The date of arrival field is required." />
                        </div>
                    </div>
                </div>
            </div>
            
             <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Search" OnClick="searchForm_Click" CssClass="btn btn-primary btn-sm" />
                    <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" CssClass="btn btn-secondary btn-sm"/>
                </div>
            </div>
        </div>
    </div>

    <asp:PlaceHolder runat="server" ID="SearchResultsPanel" Visible="false">
        <div>  
            <asp:GridView ID="SearchResultGridView" runat="server" CssClass="container table table-success table-striped" 
                RowStyle-CssClass="table-primary" DataKeyNames="ScheduleID">
                <Columns>
                    <asp:BoundField DataField="ScheduleID" HtmlEncode="False" 
                        DataFormatString="<a href='BookTicket.aspx?scheduleid={0}'>Book Ticket</a>" />
                </Columns>
            </asp:GridView>
        </div> 
    </asp:PlaceHolder>

</asp:Content>
