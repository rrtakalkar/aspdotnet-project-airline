<%@ Page Title="My Tickets" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="MyBookings.aspx.cs" Inherits="SkyAirline.Views.Search.MyBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div style="padding: 20px; background-color: rgba(255,255,255,0.7);">
        <h2><%: Title %>.</h2>
        
         <div>  
            <asp:GridView ID="MyBookingsGridView" runat="server" CssClass="container table table-success table-striped" 
                RowStyle-CssClass="table-primary" DataKeyNames="BookingID">
                <Columns>
                    <asp:BoundField DataField="BookingID" HtmlEncode="False" 
                        DataFormatString="<a href='ViewTicket.aspx?bookingid={0}'>View Ticket</a>" />
                </Columns>
            </asp:GridView>
        </div> 

    </div>

</asp:Content>
