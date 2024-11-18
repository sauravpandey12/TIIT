<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin/main.Master" AutoEventWireup="true" CodeBehind="add-video-category.aspx.cs" Inherits="TIIT.MasterAdmin.add_video_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Category
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div id="notification">
            <div id="pan" class="notificationpan">
                <div style="float: left; width: 235px; height: auto;">
                    <asp:Label ID="lblmessage" runat="server" class="notif-txt"></asp:Label>
                </div>
                <asp:ImageButton ID="ImageButton1" ImageUrl="images/close.png" runat="server" OnClientClick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                    class="closenotificationpan" Style="background: none" />
            </div>
        </div>
    </div>

    <!--main content start-->

    <section id="main-content">
        <div class="wrapper">
            <div class="row">
                <div class="col-lg-4 colmd-4 col-sm-12 col-xs-12">
                    <div class="content-wraper">
                        <h2 class="title">Add Category</h2>
                        <div class="txtbx-sec">



                            <div class="txtbx-wraper">
                                <p class="txtbx-name-p">Category Name<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_name" Display="Dynamic" ID="RequiredFieldValidator1" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></p>
                                <asp:TextBox ID="txt_name"  runat="server" class="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <asp:Panel ID="pnl_btn_new_add" runat="server">
                            <div class="form-btn-sec">
                                <asp:Button ID="btn_add" runat="server" Text="Submit" ValidationGroup="D" class="form-btn" OnClick="btn_add_Click" />
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="pnl_btn_edit" runat="server" Visible="false">
                            <div class="form-btn-sec">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 ">
                                        <asp:Button ID="btn_update" runat="server" Text="Update" ValidationGroup="D" class="form-btn" OnClick="btn_update_Click" />
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 ">
                                        <asp:Button ID="btn_cencel" runat="server" Text="Cencel" class="form-btn" OnClick="btn_cencel_Click" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>

                    </div>
                </div>

                <asp:Panel ID="pnl_grid" runat="server">
                    <div class="col-lg-8 colmd-8 col-sm-12 col-xs-12">
                        <div class="content-wraper">
                            <h2 class="title">Category List</h2>
                            <div class="grid-wraper">
                                <div class="table-responsive" style="overflow: auto">
                                    <table class="table table-striped table-advance table-hover">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grd_news_list" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true" OnPageIndexChanging="grd_news_list_PageIndexChanging" AllowPaging="True" Font-Bold="False" class="table table-striped table-advance table-hover" Style="margin-top: 0; width: 100%; overflow: scroll" OnSelectedIndexChanged="grd_news_list_SelectedIndexChanged">
                                                    <RowStyle />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Category Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Category_name" runat="server" Text='<%#Bind("Category_name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="link_delete" runat="server" OnClick="link_delete_Click" OnClientClick='return confirm("Are you sure want to delete ?")' CausesValidation="False">Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>

                                                    <FooterStyle BackColor="#CCCC99" />
                                                    <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <SelectedRowStyle BackColor="#EFEFEF" Font-Bold="True" ForeColor="#CC0000" />
                                                    <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="#333333" Height="40px" />
                                                    <AlternatingRowStyle BackColor="White" />

                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>



            </div>
        </div>
    </section>
</asp:Content>
