<%@ page title="" language="C#" masterpagefile="~/ACMasterPage.master" autoeventwireup="True" codebehind="RestaurantReview.aspx.cs" inherits="RestaurantReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Restaurant Review</h1>
        <br />
    <div class="row">
        <div class="col-md-2"><label for="drpRestaurants">Restaurant: </label></div>
        <div class="col-md-6"><asp:DropDownList ID="drpRestaurants" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpRestaurants_SelectedIndexChanged" Width="400px" >
                                    <asp:ListItem Value="-1">Select One...</asp:ListItem>
                              </asp:DropDownList></div>
    </div>
    <br />
    <asp:Panel ID="pnlViewRestaurant" runat="server">
        <div class="row">
            <div class="col-md-2"><label for="txtAddress">Street Address: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtAddress" runat="server" CssClass="form-control" Width="400px"></asp:Textbox></div>
        </div>
         <div class="row">
            <div class="col-md-2"><label for="txtCity">City: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtCity" runat="server" CssClass="form-control" Width="400px"></asp:Textbox></div>
        </div>
         <div class="row">
            <div class="col-md-2"><label for="txtProvinceState">Province/State: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtProvinceState" runat="server" CssClass="form-control" Width="400px" ></asp:Textbox></div>
        </div>
        <div class="row">
            <div class="col-md-2"><label for="txtPostalZipCode">Postal/Zip Code: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtPostalZipCode" runat="server" CssClass="form-control" Width="400px" ></asp:Textbox></div>
        </div>
        <div class="row">
            <div class="col-md-2"><label for="txtSummary">Summary: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtSummary" runat="server" CssClass="form-control" Width="400px" Height="120px" TextMode="MultiLine"></asp:Textbox></div>
        </div>
        <div class="row">
            <div class="col-md-2"><label for="txtRating">Rating: </label></div>
            <div class="col-md-6">
                <asp:DropDownList ID="drpRating" runat="server" CssClass="form-control" Width="400px" >
                    <asp:ListItem Text="1" Value ="1" />
                    <asp:ListItem Text="2" Value ="2" />
                    <asp:ListItem Text="3" Value ="3" />
                    <asp:ListItem Text="4" Value ="4" />
                    <asp:ListItem Text="5" Value ="5" />
                </asp:DropDownList>

            </div>
        </div>
        <div class="row">
            <div class="col-md-6 col-md-offset-2"><asp:button ID="btnSave" runat="server" CssClass="form-control btn-primary" Text="Save Changes" OnClick="btnSave_Click"></asp:button></div>
        </div>
        <div class="row">
            <div class="col-md-8"><asp:label ID="lblConfirmation" runat="server" CssClass="form-control alert-success"></asp:label></div>
        </div>
    </asp:Panel>
   
    <div>


    </div>

    
</asp:Content>

