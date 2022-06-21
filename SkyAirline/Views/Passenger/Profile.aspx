<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Views/Master/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="SkyAirline.Views.Passenger.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding: 20px; background-color: rgba(255,255,255,0.7);">
        <h2><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>

        <div class="form-horizontal">
            <h4>Edit my profile</h4>
            <hr />
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerName" CssClass="col-md-10 control-label">Name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PassengerName" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerName"
                                CssClass="text-danger" ErrorMessage="The name field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerEmail" CssClass="col-md-10 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PassengerEmail" CssClass="form-control" TextMode="Email" ReadOnly="true"/>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerEmail"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                            <%-- asp:RegularExpressionValidator ID="EmailValidator" runat="server" CssClass="text-danger" ErrorMessage="Invalid email address format"
                                ValidationExpression="/^w+[+.w-]*@([w-]+.)*w+[w-]*.([a-z]{2,4}|d+)$/i" ValidationGroup="string" ControlToValidate="PassengerEmail">
                            </asp:RegularExpressionValidator  --%>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerMobileNo" CssClass="col-md-10 control-label">Mobile No.</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PassengerMobileNo" CssClass="form-control" TextMode="Phone" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerMobileNo"
                                CssClass="text-danger" ErrorMessage="The mobile no field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerGender" CssClass="col-md-10 control-label">Gender</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="PassengerGender"  CssClass="form-control"/>             
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerGender"
                                CssClass="text-danger" ErrorMessage="The gender field is required." />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerIdentityType" CssClass="col-md-10 control-label">Identity Type</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="PassengerIdentityType"  CssClass="form-control"/>             
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerIdentityType"
                                CssClass="text-danger" ErrorMessage="The idenity type name field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerIdentity" CssClass="col-md-10 control-label">Identity Value</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PassengerIdentity" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerIdentity"
                                CssClass="text-danger" ErrorMessage="The identity value field is required." />
                        </div>
                    </div>
                </div>
            </div>           

            <div class="row">
                <div class="col">            
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerDateOfBirth" CssClass="col-md-10 control-label">Date of Birth</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PassengerDateOfBirth" CssClass="form-control" TextMode="Date" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerDateOfBirth"
                                CssClass="text-danger" ErrorMessage="The date of birth field is required." />
                        </div>
                    </div>
                </div>
                <div class="col">  
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PassengerAddress" CssClass="col-md-10 control-label">Address</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PassengerAddress" CssClass="form-control" TextMode="MultiLine" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PassengerAddress"
                                CssClass="text-danger" ErrorMessage="The address field is required." />
                        </div>
                    </div>
                </div>
            </div>
            
             <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Save" OnClick="updatePassengerForm_Click" CssClass="btn btn-primary btn-sm" />
                    <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="cancelButton_Click" CssClass="btn btn-secondary btn-sm"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
