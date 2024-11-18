<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin/main.Master" AutoEventWireup="true" CodeBehind="Upload-Image.aspx.cs" Inherits="TIIT.MasterAdmin.Upload_Image" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Upload Image
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        @media only screen and (max-width:760px),(min-device-width:768px) and (max-device-width:1024px) {
            table, thead, tbody, th, td, tr {
                display: block;
            }

                thead tr {
                    position: absolute;
                    top: -9999px;
                    left: -9999px;
                }

            tr {
                border: 0 solid #ccc;
            }

            td {
                border: 0;
                position: relative;
                text-align: center;
            }

                td:before {
                    position: absolute;
                    top: 6px;
                    left: 6px;
                    width: 45%;
                    padding-right: 10px;
                    white-space: nowrap;
                }
        }

        .table > thead > tr > th, .table > tbody > tr > th, .table > tfoot > tr > th, .table > thead > tr > td, .table > tbody > tr > td, .table > tfoot > tr > td {
            padding: 8px;
            line-height: 1.42857143;
            text-align: center;
            vertical-align: top;
            border: 1px solid #2974ac;
        }

        .drop-wraper span {
            color: #f00;
            font-size: 12px;
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
                <div class="col-lg-12">
                    <div class="content-wraper">
                        <h2 class="title">Upload Image</h2>
                        <div class="txtbx-sec">
                            <div class="txtbx-wraper">
                                <div class="row">
                                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                        <p class="txtbx-name-p">Select Category :-</p>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 padd-l-of">
                                        <div class="drop-wraper">
                                            <asp:DropDownList ID="ddl_categorgy" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddl_categorgy_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="txtbx-wraper">
                            <div class="row">
                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                    <p class="drop-p"></p>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 padd-l-of">
                                    <div class="drop-wraper">
                                        <asp:TextBox ID="txt_category" runat="server" CssClass="input form-control" Visible="False" Style="margin-bottom: 10px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="content-spacing">
                            <div class="row">
                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                    <p class="txtbx-name-p">Select Image :- </p>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 padd-l-of">
                                    <div class="drop-wraper">
                                        <asp:FileUpload ID="FileUpload1" runat="server" Style="cursor: pointer" class="form-control" />
                                          <span> Size of file Max (500kb)</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-btn-sec">
                            <div class="row">
                                <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                                    <asp:Label ID="lblpath" runat="server" Style="text-align: left" Visible="False"></asp:Label>
                                </div>
                                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 padd-l-of">
                                    <div class="drop-wraper">
                                        <asp:Button ID="btn_upload" runat="server" Text="Upload" Style="cursor: pointer" class="form-btn" OnClick="btn_upload_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnl_view_image" runat="server" Visible="false">
                        <div class="content-wraper">
                            <h2 class="title">View Images</h2>
                            <table border="0" style="height: auto; width: 100%">
                                <tr>
                                    <td style="padding: 20px 0 10px 0">
                                        <asp:DataList ID="dlImages" runat="server" CellPadding="4" RepeatColumns="5" Style="margin: 0 auto" OnDeleteCommand="dlImages_DeleteCommand" class="table-responsive table table-striped table-advance table-hover">
                                            <ItemTemplate>
                                                <table border="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Image ID="Image1" runat="server" Height="84" ImageUrl='<%# Bind("image_path") %>' Style="margin: 0 5px 5px 0; border: 1px solid #eaeaea; padding: 2px" Width="112" />
                                                        </td>
                                                    </tr>
                                                    <tr style="display: none">
                                                        <td style="text-align: center; font-size: 13px">
                                                            <asp:Label ID="lbl_foldr_name" runat="server" Text='<%#Bind("Category") %>' Visible="True"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center">
                                                            <asp:Label ID="lbl_imageid" runat="server" Text='<%#Bind("Id") %>' Visible="False"></asp:Label>
                                                            <asp:Button ID="btn_delete" runat="server" Text="Delete" CommandName="delete" OnClientClick="return confirm('Are you sure want delete this image ?')" CssClass="noPrint btn-success btn" Style="cursor: pointer; width: 111px; font-size: 15px; padding: 2px 0px 2px 0px; margin: 0 0 0 -4px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
            </div>

        </div>
    </section>
</asp:Content>
