<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="About-College.aspx.cs" Inherits="TIIT.About_College" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    About College
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
                                <h2 class="aboutus-pagetext-h2">About Us</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">About Us</a></li>
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
                                <h2 class="text-headingtt-h2">Techno Institute of Information Technology Institute of Information<span class="pcolorr">&nbsp; Technology (TIIT)</span></h2>
                            </div>

                            <p class="aboupage-section-psec">
                                <b>Tauheed Institute of Technology is an emerging institution in the field of Career-Oriented Computer Education provider in Kolkata.</b>
                                <br />
                                Welcome to TIIT (Tauheed Institute of Technology), an emerging IT-Institution for better Education.
                                      <br />
                                The <b>Tauheed Institute of Technology,</b> a Knowledge Resource Center (College) of Maulana Mazharul Haque Arabic and Persian University, Patna, popularly known as <b>TIIT,</b> was  established in <b>2008</b>  with a vision to contribute to the IT world by focusing on better education and guidance.
                                        <br />
                                We are committed to provide high quality academic and non academic facilities to create such a stimulating and effective environment where students can grow holistically and which enable them to face the new challenges of IT world and make them capable to produce best results in every circumstances.
                            </p>
                        </div>
                    </div>

                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">
                        <div class="boxpage">
                            <div class="blog-imag">
                                <img src="images/slider/slider-1.jpg"  class="img-responsive blog-boxheading-img" alt="Tauheed Institute of Technology (TIIT)" title="Tauheed Institute of Technology (TIIT)" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
               
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <h2 class="orgainhead-h2">Ongoing Projects</h2>
                            </div>

                            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <ul class="auline-ul">
                                    <li>Kasturba Gandhi Balika Vidyalya Block- Azamnagar, Amdabad</li>
                                    <li>Rajiv Gandhi National Crechee Scheme</li>
                                </ul>
                            </div>
                              <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <ul class="auline-ul">
                                     <li>Total Sanitation Campaign</li>
                                    <li>Residential Bridge Course</li>
                                </ul>
                            </div>
                              <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                <ul class="auline-ul">
                                    <li>Drug Counselling Centre</li>
                                    <li>Health Programme</li>
                                    <li>Vocational Training Programme</li>
                                </ul>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
