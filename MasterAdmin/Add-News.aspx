﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin/main.Master" AutoEventWireup="true" CodeBehind="Add-News.aspx.cs" Inherits="TIIT.MasterAdmin.Add_News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add News
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-control[disabled], .form-control[readonly], fieldset[disabled] .form-control {
            cursor: text;
            background-color: #fff;
            opacity: 1;
        }
    </style>
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
                        <h2 class="title">Add News</h2>
                        <div class="txtbx-sec">
                            <div class="txtbx-wraper">
                                <p class="txtbx-name-p">Date<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_date" Display="Dynamic" ID="RequiredFieldValidator11" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></p>
                                <asp:TextBox ID="txt_date" runat="server" CssClass="form-control calender-icon" placeholder="dd/mm/yyyy*"></asp:TextBox>
                                <i class="fa fa-calendar clndr-icon" aria-hidden="true"></i>
                                <script type="text/javascript">
                                    $(function () {
                                        $("#<%=txt_date.ClientID %>").datepicker({
                                                        dateFormat: "dd/mm/yy",
                                                        changeMonth: true,
                                                        changeYear: true,
                                                        yearRange: "2022:2025"

                                            //minDate: 0
                                        })
                                            .attr("readonly", "true");
                                                });
                                </script>
                            </div>



                            <div class="txtbx-wraper">
                                <p class="txtbx-name-p">Headline<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_headline" Display="Dynamic" ID="RequiredFieldValidator1" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></p>
                                <asp:TextBox ID="txt_headline" Placeholder="Enter Headline" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="txtbx-wraper">
                                <p class="txtbx-name-p">News Description<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_news_desc" Display="Dynamic" ID="RequiredFieldValidator2" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></p>
                                <asp:TextBox ID="txt_news_desc" Placeholder="Enter News Description" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
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
                            <h2 class="title">News List</h2>
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
                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_date" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Headline">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_headline" runat="server" Text='<%#Bind("Headline") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="News Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_description" runat="server" Text='<%#Bind("Description") %>'></asp:Label>
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


    <script>
        $(function () {
            $('#<%=txt_date.ClientID %>').datepicker(
             {
                 dateFormat: "dd/mm/yy"
             });
        });
    </script>

    <link href="calender/jqueryUI.css" rel="stylesheet" />
    <script src="calender/jquery-ui.js"></script>


</asp:Content>