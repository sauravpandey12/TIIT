<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Career.aspx.cs" Inherits="TIIT.Career" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Careers               
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <style>
        .texbox-border-conte {
            height: auto;
            width: 100%;
            margin: 10px 0px 0px 0px;
            padding: 0px 0px 5px 0px;
            float: left;
            font-size: 14px;
            line-height: 23px;
            font-weight: 400;
            text-align: left;
            color: #6f6c6c;
        }

        .formcontrol2a {
            height: 42px;
            width: 100%;
            margin: 0px 0px 0px 0px;
            padding: 8px 15px 8px 15px;
            float: left;
            font-size: 15px;
            color: #075061;
            text-align: left;
            border: 1px solid #00000017;
            background-color: #f9fafa;
        }

            .formcontrol2a:focus {
                border-color: #ccc;
                outline: 0;
                -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(255, 152, 0, 0.46);
                box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(255, 152, 0, 0.41);
            }

        .career-mainsec {
            height: auto;
            width: 100%;
            margin: 0px 0px 0px 0px;
            padding: 20px 15px 30px 15px;
            float: left;
            background-color: #ffffff;
            box-shadow: 0 4px 26px 3px rgb(227 226 226);
        }

        .contentbox-message-p {
            height: auto;
            width: 100%;
            margin: 0px 0px 5px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
            font-size: 14px;
            line-height: 19px;
            text-align: left;
            color: #fd1010;
            font-weight: 400;
        }

        .career-sec {
            margin: 0px 0px 0px 0px;
            padding: 10px 30px 30px;
            width: 100%;
            height: auto;
            float: left;
            box-shadow: 0 4px 26px 3px rgb(234, 230, 227);
        }

        .career-h {
            height: auto;
            width: 100%;
            margin: 15px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
            font-size: 20px;
            color: #67b341;
            line-height: 30px;
            text-align: center;
            font-weight: 700;
            letter-spacing: 1px;
            font-family: Poppins;
        }

        .career-section22 {
            margin: 0px 0px 0px 0px;
            padding: 30px 0px 40px 0px;
            width: 100%;
            height: auto;
            float: left;
            /*background-color: #76ccf9;*/
        }

        .career-sec {
            margin: 0px 0px 0px 0px;
            padding: 10px 30px 30px;
            width: 100%;
            height: auto;
            float: left;
            box-shadow: 0 4px 26px 3px rgb(234, 230, 227);
        }

        .career-h {
            height: auto;
            width: 100%;
            margin: 15px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
            font-size: 20px;
            color: #67b341;
            line-height: 30px;
            text-align: center;
            font-weight: 700;
            letter-spacing: 1px;
            font-family: Poppins;
        }

        .careeimages {
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            width: 100%;
            height: auto;
            float: left;
        }

        .careerimg22 {
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            width: 100%;
            height: auto;
            float: left;
        }

        .contact-button {
            background-color: #138400d4;
            border: 1px solid #138400d4;
            display: inline-block;
            color: #ffffff;
            font-size: 16px;
            margin: 0px 0px 0px 0px;
            padding: 9px 38px;
            text-decoration: none;
            transition: all 0.3s ease;
            transform: translateY(0px);
        }

            .contact-button:hover {
                background-color: #333;
                border: 1px solid #333;
            }

        .texbox-border {
            height: auto;
            width: 100%;
            margin: 5px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }


        .btnrefreshcaptcha55 {
            height: 40px;
            width: 40px;
            margin: 0px 0px 0px 5px;
            padding: 0px 0px 0px 0px;
            float: left;
            font-size: 15px;
            font-weight: 400;
            color: #fff!important;
            line-height: 38px;
            text-align: center;
            background-color: #138400d4;
            border: 1px solid #138400d4;
            transition: all 0.3s ease;
            transform: translateY(0px);
        }

            .btnrefreshcaptcha55:hover {
                background-color: #333;
                border: 1px solid #333;
            }

        .margincarrr {
            height: auto;
            width: 100%;
            margin: 30px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .protectedcap22 {
            user-select: none;
            font-size: 14px;
            line-height: 20px;
            background: #fff;
            padding: 9px 10px 6px 10px;
            border: 1px solid #d5d5d5;
            color: #333 !important;
            font-weight: 600;
            height: 41px;
            width: 103px;
            float: left;
            letter-spacing: 0.5px;
            margin: 0px 10px 0px 0px;
        }

        .protepage33 {
            user-select: none;
            font-size: 14px;
            line-height: 20px;
            background: #fff;
            padding: 9px 10px 6px 10px;
            border: 1px solid #d5d5d5;
            font-weight: 600;
            height: 42px;
            width: 90px;
            float: left;
            margin: 0px 10px 0px 0px;
        }

        @media screen and (max-width:900px) {
            .contact-button {
                width: 100%;
                margin: 10px 0px 0px 0px;
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

      <section>
        <div class="aboutus-page">
            <div class="aboutus-page-bg">
                <div class="container">
                    <div class="row">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="aboutus-pagetext">
                                <h2 class="aboutus-pagetext-h2">Careers</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">Careers</a></li>
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
                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"></div>

                    <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                        <h2 class="text-headingtt-h2">Careers</h2>

                        <div class="career-mainsec">
                            <div class="row">
                                <div class="texbox-border">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <p class="texbox-border-conte">Name <sup>*</sup></p>
                                        <asp:TextBox ID="txt_name" runat="server" Class="formcontrol2a" placeholder="Your Name"></asp:TextBox>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <p class="texbox-border-conte">Mobile No.<sup>*</sup></p>
                                        <asp:TextBox ID="txt_mobileno" runat="server" Class="formcontrol2a" MaxLength="10" onkeypress="return isNumberKey(event)" placeholder="Mobile No."></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="texbox-border">

                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <p class="texbox-border-conte">Email Id <sup>*</sup></p>
                                        <asp:TextBox ID="txt_emailid" type="email" runat="server" Class="formcontrol2a" placeholder="Email Id"></asp:TextBox>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <p class="texbox-border-conte">Aadhar No. <sup>*</sup></p>
                                        <asp:TextBox ID="txt_aadharno" MaxLength="16" runat="server" Class="formcontrol2a" onkeypress="return isNumberKey(event)" placeholder="Aadhar No*"></asp:TextBox>
                                    </div>

                                </div>
                            </div>

                            <div class="row">
                                <div class="texbox-border">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <p class="texbox-border-conte">Address<sup>*</sup></p>
                                        <asp:TextBox ID="txt_address" runat="server" TextMode="MultiLine" Class="formcontrol2a" placeholder="Address"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <p class="texbox-border-conte">Message <sup>*</sup></p>
                                        <asp:TextBox ID="txt_message" runat="server" TextMode="MultiLine" Class="formcontrol2a" placeholder="Type Messeage"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="texbox-border">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="contentbox-message">
                                            <p class="texbox-border-conte">Upload File <sup>*</sup></p>
                                            <p class="contentbox-message-p">Maximum File Size 500kb (Only PDF File)</p>
                                            <asp:FileUpload ID="FileUpload1" Class="formcontrol2a" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="margincarrr">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="capchamargin-sec">
                                            <asp:TextBox ID="txt_enter_captcha" runat="server" placeholder="CAPTCHA" CssClass="protectedcap22"></asp:TextBox>
                                            <asp:Label ID="lbl_captcha_code" runat="server" CssClass="protepage33"></asp:Label>
                                            <asp:LinkButton ID="LinkButton1" CausesValidation="false" CssClass="btnrefreshcaptcha55" runat="server" OnClick="LinkButton1_Click"><i class="fa fa-refresh" title="Refresh" aria-hidden="true"></i></asp:LinkButton>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <asp:Button ID="btn_submit" runat="server" Class="contact-button" Text="Submit" OnClick="btn_submit_Click" />
                                    </div>
                                </div>

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <asp:Label ID="lblmessage" runat="server" CssClass="contmessage33" Text=""></asp:Label>
                                </div>
                            </div>

                        </div>

                    </div>

                    <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12"></div>
                </div>

            </div>
        </div>
    </section>
</asp:Content>
