<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin/main.Master" AutoEventWireup="true" CodeBehind="Contact-Enquiry.aspx.cs" Inherits="TIIT.MasterAdmin.Contact_Enquiry" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    View Contact Enquiry
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   
     <style>
        .buttonfind {
            height: auto;
            width: 100%;
            margin: 20px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .find-buttonsectcont {
            height: auto;
            width: 100%;
            margin: 40px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .buttonsectcontbt {
            height: auto;
            margin: 0px 10px 0px 0px;
            padding: 5px 20px 5px 20px;
            float: left;
            font-size: 15px;
            font-weight: 400;
            text-align: center;
            color: #fff;
            border: 1px solid #109100;
            background-color: #109100;
            background-image: url("https://www.transparenttextures.com/patterns/classy-fabric.png");
            transition: background 0.3s ease-in-out, color 0.3s ease-in-out;
        }

            .buttonsectcontbt:hover {
                background: #1dcb07;
                background-image: url("https://www.transparenttextures.com/patterns/classy-fabric.png");
            }


        @media only screen and (max-width:900px) {
            .find-buttonsectcont {
                margin: 15px 0px 20px 0px;
            }
        }
    </style>


    <script language="Javascript">
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode != 46 && charCode > 31
          && (charCode < 48 || charCode > 57))
            return false;

        return true;
    }
    function onlyZeroandOne(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode < 48 || charCode > 49)
            return false;

        return true;
    }
    //-->
    </script>

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
                <div class="buttonfind">
                    <div class="col-lg-2 colmd-2 col-sm-12 col-xs-12">
                        <div class="txtbx-wraper">
                            <p class="txtbx-name-p">Start Date</p>
                            <asp:TextBox ID="txt_start_date" runat="server" CssClass="form-control calender-icon" placeholder="dd/mm/yyyy*"></asp:TextBox>
                            <i class="fa fa-calendar clndr-icon" aria-hidden="true"></i>
                            <script type="text/javascript">
                                $(function () {
                                    $("#<%=txt_start_date.ClientID %>").datepicker({
                                        dateFormat: "dd/mm/yy",
                                        changeMonth: true,
                                        changeYear: true,
                                        yearRange: "2022:2025",

                                        //minDate: 0
                                    })
                             .attr("readonly", "true");
                                });
                            </script>
                        </div>
                    </div>

                    <div class="col-lg-2 colmd-2 col-sm-12 col-xs-12">
                        <div class="txtbx-wraper">
                            <p class="txtbx-name-p">End Date</p>
                            <asp:TextBox ID="txt_end_date" runat="server" CssClass="form-control calender-icon" placeholder="dd/mm/yyyy*"></asp:TextBox>
                            <i class="fa fa-calendar clndr-icon" aria-hidden="true"></i>
                            <script type="text/javascript">
                                $(function () {
                                    $("#<%=txt_end_date.ClientID %>").datepicker({
                                        dateFormat: "dd/mm/yy",
                                        changeMonth: true,
                                        changeYear: true,
                                        yearRange: "2022:2025",

                                        //minDate: 0
                                    })
                              .attr("readonly", "true");
                                });
                            </script>
                        </div>
                    </div>

                    <div class="col-lg-4 colmd-4 col-sm-12 col-xs-12">
                        <div class="find-buttonsectcont">
                            <asp:Button ID="btn_find" runat="server" OnClick="btn_find_Click" Text="Find" CssClass="buttonsectcontbt" />
                            <asp:Button ID="btn_reset" CssClass="buttonsectcontbt" OnClick="btn_reset_Click" runat="server" Text="Reset"></asp:Button>
                            <asp:Button ID="btn_export_excel" OnClick="btn_export_excel_Click" CssClass="buttonsectcontbt" runat="server" Text="Excel Download"></asp:Button>
                        </div>
                    </div>


                    <%--
                      <div class="col-lg-2 colmd-2 col-sm-12 col-xs-12">
                        <div class="txtbx-wraper">
                            <p class="txtbx-name-p">Enter Mobile</p>
                            <asp:TextBox ID="txt_mobileno_find" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)" CssClass="form-control" placeholder="10 digit mobile No"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-3 colmd-3 col-sm-12 col-xs-12">
                        <div class="find-buttonsectcont">
                            <asp:Button ID="btn_mobilenoenquery" runat="server" Text="Find"  CssClass="buttonsectcontbt" />
                            <asp:Button ID="btn_mobilenoenquery_reset"  runat="server" Text="Reset" CssClass="buttonsectcontbt"  />
                        </div>
                    </div>--%>
                </div>
            </div>

            <div class="row">
                <asp:Panel ID="pnl_grid" runat="server">
                    <div class="col-lg-12 colmd-12 col-sm-12 col-xs-12">
                        <div class="content-wraper">
                            <h2 class="title">Contact Enquiry List</h2>
                            <div class="grid-wraper">
                                <div class="table-responsive" style="overflow: auto">
                                    <table class="table table-striped table-advance table-hover">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grd_enquiry_list" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="False" OnPageIndexChanging="grd_enquiry_list_PageIndexChanging" PageSize="10" AllowPaging="True" Font-Bold="False" class="table table-striped table-advance table-hover" Style="margin-top: 0; width: 100%; overflow: scroll">
                                                    <RowStyle />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Subject" runat="server" Text='<%#Bind("Subject") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Name" runat="server" Text='<%#Bind("Name") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Mobile">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Mobile" runat="server" Text='<%#Bind("Mobile") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Email">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Email" runat="server" Text='<%#Bind("Email") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Message">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Message" runat="server" Text='<%#Bind("Message") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Date" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>' Visible="false"></asp:Label>
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
