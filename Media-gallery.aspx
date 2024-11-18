<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Media-gallery.aspx.cs" Inherits="TIIT.Media_gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
Media Gallery
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
      <link href="Gallery/style.css" rel="stylesheet" />
    <link href="Gallery/swipebox.css" rel="stylesheet" />
    
      <style>
        .menubar nav > ul > li > a.gall {
            color: #ee344e;
        }

         .img-bx-wpr {
            margin: 0px;
            padding: 0px 0px;
            width: 0;
            height: auto;
            float: left;
        }

        .caption-p {
            margin: 0px 0px 10px 0px;
            padding: 3px 0px;
            width: 100%;
            height: auto;
            float: left;
            text-align: center;
            background: #ff3100;
            font-size: 14px;
            color: #fff;
        }

        .other-page-sec {
            min-height: 700px;
        }

        .galleryimg88 {
            width: 100%;
            height: 250px;
        }

        @media only screen and (max-width:800px) {
            .my-gallery-img {
                width: 100%;
                min-height: inherit;
            }

            .galleryimg88 {
                height: auto !important;
            }
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
                                <h2 class="aboutus-pagetext-h2">Media Gallery</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">Media Gallery</a></li>
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
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="aboupage-section22">
                            <div class="headinggm">
                                <h2 class="text-headingtt-h2">Media Gallery</h2>
                            </div>                     
                        </div>
                    </div>
                </div>

                  <div class="row">
                    <div class="my-gallery" id="galry">
                        <asp:HiddenField ID="hf_value" runat="server" />
                        <div id="portfolio" class="services portfolio">
                            <div class="gallery_gds" data-ng-app="mediagalleryApp" data-ng-controller="ctrlCategory">
                                <div class="filtr-container">
                                    <div style="position: relative;">
                                        <div data-category="1" style="position: inherit !important;">

                                            <div class="col-md-4 col-sm-4 col-xs-12" data-ng-repeat="x in images">
                                                <div class="agileits-img mygallery-wraper">
                                                    <a href="{{x.image_path}}" class="swipebox">
                                                        <img src="{{x.image_path}}" class="img-responsive mygallery-imgmedia" />
                                                        <div class="wthree-pcatn">
                                                            <h4 style="font-weight: 400"><i class="fa fa-search-plus" style="font-size: 30px; color: #fff;" aria-hidden="true"></i></h4>
                                                        </div>
                                                    </a>
                                                      <h3 class="headingcatth1">{{x.heading}}</h3>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </section>

     <script type="text/javascript">
         var app = angular.module('mediagalleryApp', []);
         app.controller('ctrlCategory', function ($scope, $http) {
             $http.get("WebService1.asmx/fetch_media_gallery").then(function (response) {
                 $scope.images = response.data;
                 if ($scope.images == "") {
                     alert("Sorry no data found");
                 }
             })

         });
    </script>


    <script src="Gallery/jquery.filterizr.js"></script>
    <script type="text/javascript">
        $(function () {
            //Initialize filterizr with default options
            $('.filtr-container').filterizr();
        });
    </script>
    <!-- swipe box js -->

    <script src="Gallery/jquery.swipebox.min.js"></script>
    <script type="text/javascript">
        jQuery(function ($) {
            $(".swipebox").swipebox();
        });
    </script>

</asp:Content>
