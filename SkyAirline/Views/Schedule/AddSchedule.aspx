<%@ Page Title="Schedule" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="AddSchedule.aspx.cs" Inherits="SkyAirline.Views.Schedule.AddSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 20px; background-color: rgba(255,255,255,0.7);">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Create a new flight schedule</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Flight" CssClass="col-md-10 control-label">Flight</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList runat="server" ID="Flight"  CssClass="form-control"/>             
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Flight"
                        CssClass="text-danger" ErrorMessage="The flight field is required." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DepartureDate" CssClass="col-md-10 control-label">Date of Departure</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="DepartureDate" CssClass="form-control" TextMode="DateTimeLocal" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="DepartureDate"
                        CssClass="text-danger" ErrorMessage="The date of departure field is required." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ArrivalDate" CssClass="col-md-10 control-label">Date of Arrival</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="ArrivalDate" CssClass="form-control" TextMode="DateTimeLocal" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ArrivalDate"
                        CssClass="text-danger" ErrorMessage="The date of arrival field is required." />
                </div>
            </div>

             <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="EconomyClassFare" CssClass="col-md-10 control-label">Economy Class Fare</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="EconomyClassFare" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="EconomyClassFare"
                        CssClass="text-danger" ErrorMessage="The economy class fare field is required." />
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="BusinessClassFare" CssClass="col-md-10 control-label">Business Class Fare</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="BusinessClassFare" CssClass="form-control" TextMode="Number" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="BusinessClassFare"
                        CssClass="text-danger" ErrorMessage="The business class fare field is required." />
                </div>
            </div>
            
             <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Insert" OnClick="addScheduleForm_Click" CssClass="btn btn-primary btn-sm" />
                    <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" CssClass="btn btn-secondary btn-sm"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
