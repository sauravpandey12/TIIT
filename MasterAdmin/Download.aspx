<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin/main.Master" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="TIIT.MasterAdmin.Download" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
Download
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
                        <h2 class="title">Upload Download File</h2>
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
                                <p class="txtbx-name-p">Select File</p>
                                <asp:FileUpload ID="fileupload" runat="server" class="form-control" />
                                <span style="color: #e42323; float: right;">Max size (2MB)</span>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 colmd-12 col-sm-12 col-xs-12">
                                    <asp:Panel ID="pnl_btn_new_add" runat="server">
                                        <div class="form-btn-sec">
                                            <asp:Button ID="btn_add_notice_board" runat="server" Text="Submit" ValidationGroup="D" class="form-btn" OnClick="btn_add_notice_board_Click" />
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
                        </div>
                    </div>
                </div>

                <asp:Label ID="lbl_filepath3" runat="server"></asp:Label> 
                <asp:Panel ID="pnl_grid" runat="server">
                    <div class="col-lg-8 colmd-8 col-sm-12 col-xs-12">
                        <div class="content-wraper">
                            <h2 class="title">View Download File</h2>
                            <div class="grid-wraper">
                                <div class="table-responsive" style="overflow: auto">
                                    <table class="table table-striped table-advance table-hover">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grd_download" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="true" OnPageIndexChanging="grd_download_PageIndexChanging" AllowPaging="True" Font-Bold="False" class="table table-striped table-advance table-hover" Style="margin-top: 0; width: 100%; overflow: scroll" OnSelectedIndexChanged="grd_download_SelectedIndexChanged">
                                                    <RowStyle />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Headline">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_headline" runat="server" Text='<%#Bind("Heading") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Downlode File">
                                                            <ItemTemplate>
                                                                  <asp:Label runat="server" ID="lbl_file_path" Visible="false" Text='<%#Bind("FilePath") %>'></asp:Label>
                                                                <a href='<%#Eval("FilePath") %>' target="_blank" style="padding: 5px 0px 7px 30px; font-family: ebrima; font-size: 14px; color: #0066CC; text-decoration: none;"><i class="fa fa-download" aria-hidden="true"></i></a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_date" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="link_delete" runat="server" OnClientClick='return confirm("Are you sure want to delete ?")' OnClick="link_delete_Click1" CausesValidation="False">Delete</asp:LinkButton>
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
