<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="location.aspx.cs" Inherits="TIIT.location" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Location
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .menubar nav > ul > li > a.about {
            color: #bb2221;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <div class="aboutus-page">
            <div class="aboutus-page-bg">
                <div class="container">
                    <div class="row">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="aboutus-pagetext">
                                <h2 class="aboutus-pagetext-h2">Location</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">Location</a></li>
                            </ul>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <section>
        <div class="aboupage-section">
            <div class="container">
                <div class="row">

                    <div class="col-lg-8 col-lg-offset-2 col-md-8 col-md-offset-2 col-sm-12 col-xs-12">
                        <div class="aboupage-section22">
                            <div class="headinggm">
                                <h2 class="text-headingtt-h2">Location</h2>
                            </div>
                            <img src="images/location.jpg" class="img-responsive locatinn" alt="Tauheed Institute of Information Technology (TIIT)" title="Tauheed Institute of Information Technology (TIIT)" />
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>


</asp:Content>
