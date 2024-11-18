<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Video-gallery.aspx.cs" Inherits="TIIT.Video_gallery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
Video Gallery
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
       <style>
        .menubar nav > ul > li > a.gall {
            color: #bb2221;
        }

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
            margin: 20px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .buttonsectcontbt {
            height: 41px;
            margin: 0px 10px 0px 0px;
            padding: 5px 30px 5px 30px;
            float: left;
            font-size: 15px;
            font-weight: 400;
            text-align: center;
            color: #fff;
            background: #002147;
            border: 1px solid #002147;
            transition: background 0.3s ease-in-out, color 0.3s ease-in-out;
        }

            .buttonsectcontbt:hover {
                background: #ff6a00;
                border: 1px solid #ff6a00;
            }

        .vieocatmmm {
            height: auto;
            width: 100%;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .videobttnn {
            height: auto;
            width: 100%;
            margin: 0px 0px 30px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .txtbx-name-p {
            margin: 0px 0px 4px 0px;
            padding: 0px;
            width: 100%;
            height: auto;
            float: left;
            font-size: 14px;
            color: #333;
        }

        .vdo-cat-ul {
            margin: 0px 0px 0px 0px;
            padding: 0px;
            width: 100%;
            height: auto;
            float: left;
            text-align: center;
        }

            .vdo-cat-ul li {
                margin: 0px 0px 0px 0px;
                padding: 0px 5px;
                list-style-type: none;
                display: inline;
            }

                .vdo-cat-ul li a {
                    display: inline-flex;
                    justify-content: center;
                    align-items: center;
                    text-align: center;
                    background-color: #138400d4;
                    background-image: url(https://www.transparenttextures.com/patterns/asfalt-light.png);
                    color: #ffffff;
                    border: 1px solid #138400d4;
                    font-weight: 600;
                    position: relative;
                    outline: none;
                    cursor: pointer;
                    transition: color 0.4s ease;
                    overflow: hidden;
                    white-space: nowrap;
                    height: 38px;
                    padding: 0px 15px 0px 15px;
                    margin: 5px 0px 5px 0px;
                    font-size: 14px;
                    line-height: 20px;
                }

                    .vdo-cat-ul li a span {
                        position: relative;
                        z-index: 1;
                    }

                    .vdo-cat-ul li a:before {
                        content: "";
                        position: absolute;
                        height: 0%;
                        left: 50%;
                        top: 50%;
                        width: 150%;
                        z-index: 0;
                        transition: all 0.35s ease 0s;
                        background: #f00;
                        -webkit-transform: translateX(-50%) translateY(-50%) rotate( -25deg );
                        transform: translateX(-50%) translateY(-50%) rotate( -25deg );
                    }

                    .vdo-cat-ul li a:hover:before {
                        height: 450%;
                        transition: all 1s ease 0s;
                    }

        .video-title-p {
            margin: 0px 0px 0px 0px;
            padding: 0px 10px 10px 10px;
            width: 100%;
            height: auto;
            float: left;
            text-align: center;
            font-size: 11px;
            line-height: 20px;
            color: #222;
            font-weight: 400;
            text-transform: uppercase;
        }

        .video-wpr {
            width: 100%;
            height: 255px;
            margin: 0px 0px 15px 0px;
            padding: 10px;
            float: left;
            background: #f5f5f5;
        }

        .video-ifrm-wpr {
            width: 100%;
            height: auto;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .videogallmm {
            width: 100%;
            height: 190px;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .magvtt {
            width: 100%;
            height: auto;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .videotitle-h {
            margin: 10px 0px 10px 0px;
            padding: 0px 0px 0px 0px;
            width: 100%;
            height: auto;
            float: left;
            text-align: center;
            font-size: 17px;
            line-height: 20px;
            color: #222;
            font-weight: 600;
            background: #f5f5f5;
            font-family: 'Open Sans', sans-serif;
        }

        .videotitle-p {
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 10px 0px;
            width: 100%;
            height: auto;
            float: left;
            text-align: center;
            font-size: 11px;
            line-height: 20px;
            color: #222;
            font-weight: 400;
            text-transform: uppercase;
            background: #f5f5f5;
        }

        .margingallll34 {
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            width: 100%;
            height: auto;
            float: left;
        }

        @media only screen and (max-width:900px) {
            .find-buttonsectcont {
                margin: 15px 0px 20px 0px;
            }

            .video-wpr {
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
                                <h2 class="aboutus-pagetext-h2">Video Gallery</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">Video Gallery</a></li>
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
                                <h2 class="text-headingtt-h2">Video Gallery</h2>
                            </div>

                        </div>
                    </div>
                </div>

                  <div class="margingallll34" data-ng-app="MyAngularApp" data-ng-controller="MyVideoCtrl">

                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="videobttnn">
                                <ul class="vdo-cat-ul">
                                    <li><a href="#!" data-ng-click="ButtonFndByCat('all')"><span>All</span></a></li>
                                    <li data-ng-repeat="x in vdo_cat"><a href="#!" data-ng-click="ButtonFndByCat(x.Video_cat_id)"><span>{{x.Category_name}}</span></a></li>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12 colmd-12 col-sm-12 col-xs-12">
                            <div class="grid-wraper">
                                <div class="row">
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" data-ng-repeat="x in videos">
                                        <div class="video-wpr">
                                            <div class="video-ifrm-wpr">
                                                <iframe class="videogallmm" data-ng-src="{{x.Video_url | trusted}}" frameborder="0" allowfullscreen></iframe>
                                            </div>

                                            <div class="magvtt">
                                                <h2 class="videotitle-h">{{x.Heading}}</h2>
                                                <%-- <p class="videotitle-p">Upload Date : {{x.Date}}</p>--%>
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

      <script src="MasterAdmin/js/ng-youtube-embed.min.js"></script>

    <script type="text/javascript">
        var app = angular.module('MyAngularApp', ['ngYoutubeEmbed']);
        app.controller('MyVideoCtrl', function ($scope, $http) {


            //------FetchVideO
            $http.get("WebService1.asmx/fetch_video_details").then(function (response) {
                $scope.videos = response.data;
            })


            //------FetchVideO
            $http.get("WebService1.asmx/fetch_video_cat_details").then(function (response) {
                $scope.vdo_cat = response.data;
            })



            $scope.ButtonFndByCat = function (cat) {
                if (cat == "all") {
                    $http.get("WebService1.asmx/fetch_video_details").then(function (response) {
                        $scope.videos = response.data;
                    })
                }
                else {
                    $http.get("WebService1.asmx/fetch_video_details_by_cat", { params: { "Cat": cat } }).then(function (response) {
                        $scope.videos = response.data;
                    })
                }
            }


        });

        app.filter('trusted', ['$sce', function ($sce) {
            return function (url) {
                var video_id = url.split('v=')[1].split('&')[0];
                return $sce.trustAsResourceUrl("https://www.youtube.com/embed/" + video_id);
            };
        }]);
    </script>

    <style>
        .hidden {
            display: none;
        }
    </style>


</asp:Content>
