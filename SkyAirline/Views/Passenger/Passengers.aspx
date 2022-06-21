<%@ Page Title="Passengers" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="Passengers.aspx.cs" Inherits="SkyAirline.Views.Passenger.Passengers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="passengersGrid"
        ItemType="SkyAirline.Models.Passenger" DataKeyNames="PassengerID" 
        SelectMethod="GetPassengers" AutoGenerateColumns="false"
        AllowSorting="true" AllowPaging="true" PageSize="4" OnCallingDataMethods="passengersGrid_CallingDataMethods" 
        CssClass="container table table-success table-striped" RowStyle-CssClass="table-primary">
        <Columns>
            <asp:DynamicField DataField="PassengerID" ItemStyle-CssClass="table-primary" />
            <asp:DynamicField DataField="PassengerName" ItemStyle-CssClass="table-primary" /> 
            <asp:DynamicField DataField="PassengerEmail" ItemStyle-CssClass="table-primary" /> 
            <asp:DynamicField DataField="PassengerMobileNo" ItemStyle-CssClass="table-primary" /> 
        </Columns>
    </asp:GridView>
</asp:Content>
