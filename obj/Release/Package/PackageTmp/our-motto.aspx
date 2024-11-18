<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="our-motto.aspx.cs" Inherits="TIIT.our_moto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Our Motto
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
                                <h2 class="aboutus-pagetext-h2">Our Motto</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">Our Motto</a></li>
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
                    <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12">
                        <div class="aboupage-section22">
                            <div class="headinggm">
                                <h2 class="text-headingtt-h2">Our<span class="pcolorr"> &nbsp;Motto</span></h2>
                            </div>

                            <p class="aboupage-section-psec">
                                The Moto of <b>TIIT</b> is to upgrade, improve knowledge of students in computer science and its various applications and to develop understanding of modern business practices to enable them to make informed decision in problem solving in business and industry. The placement division provides career resources for the students who seek summer internships. The College provides resources, contacts and information to help students to determine career strategy that suits individual interest, background and goods.
                            </p>
                        </div>
                    </div>

                    <div class="col-lg-1 col-md-1 col-sm-12 col-xs-12"></div>

                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                        <div class="boxpage">
                            <div class="blog-imag">
                                <img src="images/motto.png" class="img-responsive blog-boxheading-img" alt="Tauheed Institute of Information Technology (TIIT)" title="Tauheed Institute of Information Technology (TIIT)" />
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </section>


</asp:Content>
