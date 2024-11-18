<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin/main.Master" AutoEventWireup="true" CodeBehind="Change-Password.aspx.cs" Inherits="TIIT.MasterAdmin.Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Change Password
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
                        <h2 class="title">Change Password</h2>
                        <div class="txtbx-sec">
                            <div class="txtbx-wraper">
                                <p class="txtbx-name-p">Old Password<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_old_password" Display="Dynamic" ID="RequiredFieldValidator1" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></p>
                                <asp:TextBox ID="txt_old_password" Placeholder="Enter Old Password" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="txtbx-wraper">
                                <p class="txtbx-name-p">New Password<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_new_password" Display="Dynamic" ID="RequiredFieldValidator2" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></p>
                                <asp:TextBox ID="txt_new_password" Placeholder="Enter New Password" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="txtbx-wraper">
                                <p class="txtbx-name-p">Confirm Password<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_confirm" Display="Dynamic" ID="RequiredFieldValidator3" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></p>
                                <asp:TextBox ID="txt_confirm" Placeholder="Enter Confirm Password" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-btn-sec">
                            <asp:Button ID="btn_change_password" runat="server" Text="Change Password" ValidationGroup="D" class="form-btn" OnClick="btn_change_password_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
