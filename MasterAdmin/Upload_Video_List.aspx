<%@ Page Title="" Language="C#" MasterPageFile="~/MasterAdmin/main.Master" AutoEventWireup="true" CodeBehind="Upload_Video_List.aspx.cs" Inherits="TIIT.MasterAdmin.Upload_Video_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Upload Video List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>

    <style>
        .form-control[disabled], .form-control[readonly], fieldset[disabled] .form-control {
            cursor: text;
            background-color: #fff;
            opacity: 1;
        }

        .calender-icon {
            margin: 0px 0px 0px 0px;
            position: relative;
        }

        .clndr-icon {
            font-size: 20px !important;
            color: #00c2cb;
            margin: 3px 0px 0px 5px;
            position: inherit;
            top: 28px;
            right: 6px;
        }

        .ui-datepicker select.ui-datepicker-month, .ui-datepicker select.ui-datepicker-year {
            width: 45%;
            color: black;
        }
    </style>

    <script type="text/javascript">
        function openModal1() {
            $('#myModal1').modal('show');
        }
    </script>

    <style>
        /*******find button*********/

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
            background: #002147;
            border: 1px solid #002147;
            transition: background 0.3s ease-in-out, color 0.3s ease-in-out;
        }

            .buttonsectcontbt:hover {
                background: #ff6a00;
                border: 1px solid #ff6a00;
            }


        @media only screen and (max-width:900px) {
            .find-buttonsectcont {
                margin: 15px 0px 20px 0px;
            }
        }
        /*******end button*/





        .modal-header {
            padding: 10px 15px;
            background: #1cf3fd3d;
        }

        .modal-title {
            margin: 0;
            padding: 0px;
            line-height: 20px;
            font-size: 24px;
        }

        .modal-dialog {
            top: 20%;
        }


        .btn-ul {
            margin: 0px 0px 0px 0px;
            padding: 0px 0px;
            height: auto;
            width: 100%;
            float: left;
        }

            .btn-ul li {
                margin: 0px 0px 0px 0px;
                padding: 0px 0px;
                height: auto;
                width: 100%;
                float: left;
                list-style-type: none;
            }

                .btn-ul li a {
                    background: #ff6c12;
                    width: 100%;
                    margin: 0px;
                    padding: 7px 15px 8px;
                    text-decoration: none;
                    font-size: 14px;
                    line-height: normal;
                    cursor: pointer;
                    font-weight: bold;
                    text-transform: uppercase;
                    border: 0px solid #ff6c12;
                    border-radius: 3px;
                    color: #ffffff;
                    -webkit-transition: all 300ms linear;
                    -moz-transition: all 300ms linear;
                    -o-transition: all 300ms linear;
                    -ms-transition: all 300ms linear;
                    transition: all 300ms linear;
                    float: left;
                    text-align: center;
                }

        .conf-alrt-sec {
            position: fixed;
            top: 0;
            right: 0;
            bottom: 0;
            left: 0;
            z-index: 999999;
            background: rgba(0, 0, 0, 0.26);
        }

        .conf-alrt-inr {
            position: relative;
            top: 30%;
            margin: 0px auto;
            border-radius: 2px;
            padding: 20px;
            width: 300px;
            height: auto;
            background: #fff;
            -webkit-transition: -webkit-transform .3s ease-out;
            -o-transition: -o-transform .3s ease-out;
            transition: transform .3s ease-out;
            -webkit-transform: translate(0,-25%);
            -ms-transform: translate(0,-25%);
            -o-transform: translate(0,-25%);
            transform: translate(0,-25%);
            -webkit-box-shadow: 0 5px 15px rgba(0,0,0,.5);
            box-shadow: 0 5px 15px rgba(0,0,0,.5);
        }

        .conf-alrt-msg-p {
            margin: 0px;
            padding: 0px;
            width: 100%;
            height: auto;
            font-size: 15px;
            color: #333;
            letter-spacing: .5px;
        }

        .conf-btn-ul {
            margin: 15px 0px 37px 0px;
            padding: 0px;
            width: 100%;
            height: auto;
            text-align: right;
        }

            .conf-btn-ul li {
                margin: 0px;
                padding: 0px;
                list-style-type: none;
                display: inline;
            }

                .conf-btn-ul li a {
                    margin: 0px 5px;
                    padding: 0px 10px 1px;
                    text-decoration: none;
                    background: #0072ff;
                    color: #fff;
                    width: 65px;
                    float: right;
                    text-align: center;
                    border-radius: 3px;
                    font-size: 13px;
                    line-height: 29px;
                    font-weight: 600;
                }

        .video-pseccc {
            height: auto;
            width: 100%;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
            font-size: 11px;
            line-height: 21px;
            font-weight: 400;
            color: #282828;
            text-align: center;
            text-transform: uppercase;
        }

        .videobttnn44 {
            height: auto!important;
            width: 100%!important;
            margin: 0px 0px 30px 0px!important;
            padding: 0px 0px 0px 0px!important;
            float: left!important;
        }

    </style>

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


    <section id="main-content" data-ng-app="MyAngularApp" data-ng-controller="MyVideoCtrl">
        <div class="wrapper">




            <div class="row">
                <div class="col-lg-12 colmd-12 col-sm-12 col-xs-12">
                    <div class="content-wraper">
                        <h2 class="title">Video List</h2>
                        <div class="grid-wraper">

                            <div class="row">
                                <div class="videobttnn44">
                                    <div class="col-lg-3 colmd-3 col-sm-12 col-xs-12">
                                        <div class="txtbx-wraper">
                                            <p class="txtbx-name-p">Choose Video Category</p>
                                            <asp:DropDownList ID="ddl_video_category" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-lg-4 colmd-4 col-sm-12 col-xs-12">
                                        <div class="find-buttonsectcont">
                                            <asp:Button ID="btn_find" runat="server" Text="Find" CssClass="buttonsectcontbt" />
                                            <asp:Button ID="btn_reset" CssClass="buttonsectcontbt" runat="server" Text="Reset"></asp:Button>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-lg-3 colmd-3 col-sm-12 col-xs-12" data-ng-repeat="x in videos">
                                    <div class="video-wpr">
                                        <div class="video-ifrm-wpr">
                                            <iframe width="100%" height="150" data-ng-src="{{x.Video_url | trusted}}" frameborder="0" allowfullscreen></iframe>
                                        </div>
                                        <h2 class="video-pseccc">{{x.Date}}</h2>
                                        <h2 class="video-title-h">{{x.Heading}}</h2>

                                        <ul class="anglr-btn-ul">
                                            <li><a href="javascript:" data-ng-click="ButtonDelete(x.Id)">Delete</a></li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="conf-alrt-sec fade in hidden" id="conf_alrt">
                    <div class="conf-alrt-inr">
                        <p class="conf-alrt-msg-p">Are you sure you want delete?</p>
                        <ul class="conf-btn-ul">
                            <li><a href="javascript:" data-ng-click="ButtonCancelDelete()" style="background: #fff; border: 1px solid #ddd; color: #0072ff;">Cancel</a></li>
                            <li><a href="javascript:" data-ng-click="ButtonConfDelete()">Ok</a></li>
                        </ul>
                    </div>
                </div>

            </div>

        </div>
    </section>



    <script src="js/ng-youtube-embed.min.js"></script>
    <script type="text/javascript">

        var app = angular.module('MyAngularApp', ['ngYoutubeEmbed']);
        app.controller('MyVideoCtrl', function ($scope, $http) {


            //------FetchVideO
            $http.get("WebService1.asmx/fetch_video_details").then(function (response) {
                $scope.videos = response.data;
            })

            //DeleteVideo
            var del_id = "";
            $scope.ButtonDelete = function (id) {
                del_id = id;
                $("#conf_alrt").removeClass("hidden");
            }
            $scope.ButtonCancelDelete = function () {
                del_id = "0";
                $("#conf_alrt").addClass("hidden");
            }
            $scope.ButtonConfDelete = function () {
                $http.get("WebService1.asmx/delete_video", { params: { "Id": del_id } }).then(function (response) {
                    $scope.client_dt = response.data;
                    if ($scope.client_dt == "") {
                        $("#con").addClass("hidden");
                        $("#mesg").removeClass("hidden");
                        $("#conf_alrt").addClass("hidden");
                        messge("Video Deleted Successfully.");
                        //FetchVideo
                        $http.get("WebService1.asmx/fetch_video_details").then(function (response) {
                            $scope.videos = response.data;
                        })
                    }
                })
            }
        });



        app.filter('trusted', ['$sce', function ($sce) {
            return function (url) {
                var video_id = url.split('v=')[1].split('&')[0];
                return $sce.trustAsResourceUrl("https://www.youtube.com/embed/" + video_id);
            };
        }]);

        function messge(msg) {
            $("#<%=lblmessage.ClientID%>").text(msg);
            $('.notificationpan').hide().slideDown(1000);
            $('.notificationpan').delay(4000).show().slideUp(1000);
        }

    </script>

    <style>
        .hidden {
            display: none;
        }
    </style>

</asp:Content>
