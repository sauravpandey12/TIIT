<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin/main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="TIIT.MasterAdmin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Dashboard
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        /*--------------------Dashboard-------------------------*/
        .block {
            margin: 50px 0px 0px 0px;
            width: 100%;
            height: auto;
            padding: 15px 0px 0px 0px;
            box-sizing: border-box;
            text-align: center;
            display: inline-block;
        }


            .block a {
                width: 100%;
                text-align: center;
                text-decoration: none;
                padding: 5px;
                font-size: 14px;
            }

            .block figure {
                margin: 0px 0px 0px 0px !important;
                padding: 10px 10px 10px 10px;
                width: 100%;
                height: 160px;
                float: left;
                background: #fff;
                border-radius: 10px;
                box-shadow: 0 4px 6px -1px rgb(0 0 0 / 10%), 0 2px 4px -1px rgb(0 0 0 / 6%);
            }

        .block-isec {
            height: 64px;
            width: 64px;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            font-size: 21px;
            line-height: 60px;
            color: #fff;
            text-align: center;
            position: relative;
            background-image: linear-gradient(195deg,#42424a,#191919);
            top: -30px;
            border-radius: 10%;
            float: left;
            margin-left: 15px;
            box-shadow: 0 4px 20px 0 rgba(0,0,0,.14),0 7px 10px -5px rgba(64,64,64,.4)!important;
        }

        .block figure figcaption {
            padding: 10px;
            width: 100%;
            margin: 30px 0px 0px 0px;
            float: left;
            box-sizing: border-box;
            color: #fff;
            background: #7876c3;
        }

            .block figure figcaption:hover, .block figure:hover figcaption {
            }

        .block-headingss {
            height: auto;
            width: 100%;
            margin: 0px 0px 15px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
            font-size: 18px;
            line-height: 20px;
            text-align: center;
            font-weight: 600;
            color: #344767;
        }
    </style>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--main content start-->
    <section id="main-content">
        <div class="wrapper">


            <div class="row">

                <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="Add-News.aspx">
                                <i class="fa fa-newspaper-o block-isec" aria-hidden="true"></i>
                                <h2 class="block-headingss">Upload News</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">Upload All News</p>
                            </a>
                        </figure>
                    </div>
                </div>

                <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="Notice_Board.aspx">
                                <i class="fa fa-calendar-o block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#ec407a,#d81b60);"></i>
                                <h2 class="block-headingss">Notice Board</h2>
                                 <p class="linebbb"></p>
                                <p class="viewallppp">Upload Notice Board</p>
                            </a>
                        </figure>
                    </div>
                </div>

                <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="Popup.aspx">
                                <i class="fa fa-upload block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#66bb6a,#43a047);"></i>
                                <h2 class="block-headingss">Upload Popup</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">Upload Popup Images</p>
                            </a>
                        </figure>
                    </div>
                </div>

                <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="Upload-Image.aspx">
                                <i class="fa fa-picture-o block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#49a3f1,#1a73e8);"></i>
                                <h2 class="block-headingss">Upload Image</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">Upload All Image</p>
                            </a>
                        </figure>
                    </div>
                </div>

            </div>




            <div class="row">

                  <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="Download.aspx">
                                <i class="fa fa-upload block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#49a3f1,#1a73e8);"></i>
                                <h2 class="block-headingss">Upload Download File</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">Upload All document</p>
                            </a>
                        </figure>
                    </div>
                </div>


                 <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="add-video-category.aspx">
                                <i class="fa fa-video-camera block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#56ab2f,#a8e063);"></i>
                                <h2 class="block-headingss">Add Video Category</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">Add All Video Category</p>
                            </a>
                        </figure>
                    </div>
                </div>

                <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="Upload-video.aspx">
                                <i class="fa fa-video-camera block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#56ab2f,#a8e063);"></i>
                                <h2 class="block-headingss">Upload Video</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">Upload All Video</p>
                            </a>
                        </figure>
                    </div>
                </div>
               
                <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="Contact-Enquiry.aspx">
                                <i class="fa fa-phone block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#eb3349 ,#f45c43);"></i>
                                <h2 class="block-headingss">Contact Enquiry</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">View All Contact Enquiry</p>
                            </a>
                        </figure>
                    </div>
                </div>

               

                 
             
            </div>

              <div class="row">

                   <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="View-Career.aspx">
                                <i class="fa fa-user block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#cc2b5e,#753a88);"></i>
                                <h2 class="block-headingss">View Careers</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">View All Careers</p>
                            </a>
                        </figure>
                    </div>
                </div>


                  <div class="col-sm-3">
                    <div class="block">
                        <figure>
                            <a href="Change-Password.aspx">
                                <i class="fa fa-key block-isec" aria-hidden="true" style="background-image: linear-gradient(195deg,#000428,#004e92);"></i>
                                <h2 class="block-headingss">Change Password</h2>
                                <p class="linebbb"></p>
                                <p class="viewallppp">Change Old Password</p>
                            </a>
                        </figure>
                    </div>
                </div>
              </div>


        </div>
    </section>

</asp:Content>
