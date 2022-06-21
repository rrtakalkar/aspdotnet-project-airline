<%@ Page Title="Airport" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="AddAirport.aspx.cs" Inherits="SkyAirline.Views.Airport.AddAirport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 20px; background-color: rgba(255,255,255,0.7);">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Create a new airport</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="AirportCode" CssClass="col-md-10 control-label">Airport Code</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="AirportCode" CssClass="form-control" TextMode="SingleLine" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="AirportCode"
                        CssClass="text-danger" ErrorMessage="The airport code field is required." />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="City" CssClass="col-md-10 control-label">Airport Location</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="City"  CssClass="form-control"/>             
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="City"
                        CssClass="text-danger" ErrorMessage="The city name field is required." />
                </div>
            </div>
             <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Insert" OnClick="addAirportForm_Click" CssClass="btn btn-primary btn-sm" />
                    <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" CssClass="btn btn-secondary btn-sm"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
