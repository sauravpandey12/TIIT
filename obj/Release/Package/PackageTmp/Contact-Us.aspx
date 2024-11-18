<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Contact-Us.aspx.cs" Inherits="TIIT.Contact_Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Contact Us
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .menubar nav > ul > li > a.contactuss {
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
                                <h2 class="aboutus-pagetext-h2">Contact Us</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">Contact Us</a></li>
                            </ul>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>

    <section>
        <div class="contactus-sec">
            <div class="container">

                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="headinggm">
                            <h2 class="text-headingtt-h2">Contact Us</h2>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="locationbackgrou">

                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <div class="row">
                                <div class="locboxxm">

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="contact-shadw">
                                            <i class="fa fa-map-marker cont-secbox22" aria-hidden="true"></i>
                                            <div class="contact-secbox2">
                                                <h2 class="contact-secbox2-h222">Address</h2>
                                                <a class="contact-secbox2-a">Newtown Action Area , Kolkata  Kolkata 700135</a>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="contact-shadw">
                                            <i class="fa fa-phone cont-secbox22" aria-hidden="true"></i>
                                            <div class="contact-secbox2">
                                                <h2 class="contact-secbox2-h222">Contact No.: </h2>
                                                <a class="contact-secbox2-a" href="tel:+91 9102689390 " title="">+91 9102689390 &nbsp; / &nbsp;</a>
                                                <a class="contact-secbox2-a" href="tel:+91 9102689390" title="">9102689390</a>
                                            </div>
                                        </div>
                                    </div>

                                     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="contact-shadw">
                                            <i class="fa fa-phone cont-secbox22" aria-hidden="true"></i>
                                            <div class="contact-secbox2">
                                                <h2 class="contact-secbox2-h222">Fax : </h2>
                                                <a class="contact-secbox2-a" href="tel:9102689390" title="">9102689390</a>
                                               
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="contact-shadw">
                                            <i class="fa fa-envelope cont-secbox22" aria-hidden="true"></i>
                                            <div class="contact-secbox2">
                                                <h2 class="contact-secbox2-h222">Email :</h2>
                                                <a class="contact-secbox2-a" href="mailto:kumarsaurav32971@gmail.com" title="">kumarsaurav32971@gmail.com</a>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                            <asp:UpdatePanel runat="server" ID="UpdatePanel33">
                                <ContentTemplate>

                                    <div class="contact-shadw">


                                        <div class="row">
                                            <div class="texbox-border">

                                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                    <p class="textcont33">Subject <sup>**</sup></p>
                                                    <asp:DropDownList CssClass="formcontrol" ID="ddl_subject" runat="server">
                                                        <asp:ListItem>Subject</asp:ListItem>
                                                        <asp:ListItem>Online Enquiry </asp:ListItem>
                                                        <asp:ListItem>Feedback </asp:ListItem>
                                                        <asp:ListItem>Complain </asp:ListItem>
                                                        <asp:ListItem>Suggestion</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                    <p class="textcont33">Name <sup>**</sup></p>
                                                    <asp:TextBox ID="txt_name" runat="server" CssClass="formcontrol" placeholder="Your Name"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="texbox-border">
                                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                    <p class="textcont33">Mobile No. <sup>**</sup></p>
                                                    <asp:TextBox ID="txt_mobileno" runat="server" MaxLength="10" onkeypress="return isNumberKey(event)" CssClass="formcontrol" placeholder="10 Digit Mobile No."></asp:TextBox>
                                                </div>

                                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                                    <p class="textcont33">Email Id</p>
                                                    <asp:TextBox ID="txt_emailid" type="email" runat="server" CssClass="formcontrol" placeholder="Email Id"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="texbox-border">
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                    <p class="textcont33">Message <sup>**</sup></p>
                                                    <asp:TextBox ID="txt_message" Height="80px" TextMode="MultiLine" runat="server" CssClass="formcontrol" placeholder="Entre Message"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                                                <div class="capchamargin-sec">
                                                    <asp:TextBox ID="txt_enter_captcha" placeholder="CAPTCHA" runat="server" CssClass="protectedcap22"></asp:TextBox>
                                                    <asp:Label ID="Captcha" runat="server" CssClass="protectedcap"></asp:Label>
                                                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" CausesValidation="false" CssClass="btnrefreshcaptcha" runat="server"><i class="fa fa-refresh" title="Refresh" aria-hidden="true"></i></asp:LinkButton>
                                                </div>
                                            </div>

                                            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                                <div class="contmarg56">
                                                    <asp:Button ID="btn_submit" runat="server" Class="cont-submit" Text="Submit Now" OnClick="btn_submit_Click" />
                                                    <asp:Label ID="lblmessage" runat="server" CssClass="loginmessage333"></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>


                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
