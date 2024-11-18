<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TIIT.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    TIIT
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .menubar nav > ul > li > a.home {
            color: #bb2221;
        }
           .slide-text > h2 {
    padding: 0px 0px 0px 0px;
    margin: 0px 0px 0px 0px;
    color: #fff;
    font-size:35px;
    font-style: normal;
    line-height:100px;
    letter-spacing: 0px;
    display: inline-block;
    -webkit-animation-delay: 0.7s;
    animation-delay: 0.7s;
    font-weight: 500!important;
    width: 100%;
    }
        .control-round .carousel-control {
            top: 30%;
       
        }
        .newsdefaulll {
    height: auto;
    width: 100%;
    margin: 0px 0px 0px 0px;
    padding: 60px 0px 60px 0px;
    float: left;
    background: #f9f9f9;
    /* background-image: url(https://www.transparenttextures.com/patterns/skeletal-weave.png); */
    box-shadow: -3px 13px 24px -1px rgb(0 0 0 / 69%);
}
    </style>
    <%--.........................owl.................... --%>
    <link href="owl/owl.css" rel="stylesheet" />
    <link href="owl/font-awesome.min.css" rel="stylesheet" />

    <link href="Popup/popup.css" rel="stylesheet" />

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- ........slider................ --%>
    <section>
        <div class="slider-sec">
            <div id="bootstrap-touch-slider" class="carousel bs-slider fade  control-round indicators-line" data-ride="carousel" data-pause="hover" data-interval="5000">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#bootstrap-touch-slider" data-slide-to="0" class="active"></li>
                    <li data-target="#bootstrap-touch-slider" data-slide-to="1"></li>
                </ol>

                <div class="carousel-inner" role="listbox">

                    <div class="item active">
                        <img src="images/slider/slider-1.jpg" class="slide-image" alt="Tauheed Institute of Technology" title="Tauheed Institute of Technology" />
                        <div class="bs-slider-overlay"></div>
                        <div class="slide-text slide_style_right">
                             <h2 data-animation="animated bounceInLeft"><spain style="color:#f00;"  >L</spain> <spain style="color:#f00;"  ></spain>earning, <spain style="color:#f00;"  >I</spain>nnovating and <spain style="color:#f00;"  >N</spain> <spain style="color:#f00;"  ></spain>etworking....the <spain style="color:#f00;"  >K</spain>nowledge
</h2>

                        </div>
                    </div>

                    <div class="item">
                        <img src="images/slider/slider-2.jpg" class="slide-image" alt="Tauheed Institute of Technology" title="Tauheed Institute of Technology" />
                        <div class="bs-slider-overlay"></div>
                        <div class="slide-text slide_style_left">
                           
                            
  <h2 data-animation="animated bounceInLeft"><spain style="color:#f00;"  >L</spain> <spain style="color:#f00;"  ></spain>earning, <spain style="color:#f00;"  >I</spain>nnovating and <spain style="color:#f00;"  >N</spain> <spain style="color:#f00;"  ></spain>etworking....the <spain style="color:#f00;"  >K</spain>nowledge
</h2>
                        </div>
                    </div>

                </div>

                <!-- Left Control -->
                <a class="left carousel-control" href="#bootstrap-touch-slider" role="button" data-slide="prev">
                    <span class="fa fa-angle-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>

                <!-- Right Control -->

                <a class="right carousel-control" href="#bootstrap-touch-slider" role="button" data-slide="next">
                    <span class="fa fa-angle-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>

            </div>
        </div>
    </section>

    <section>
        <div class="latestnewssec">

            <div class="newshealine">
                <p class="newshealine-p"><i class="fa fa-volume-up" aria-hidden="true"></i>&nbsp; Highlights</p>
            </div>

            <div class="latestnewssec-mainn">
                <div class="scollingsection">
                    <marquee onmouseover="stop();" onmouseout="start ();" scrollamount="7" scrolldelay="1" direction="left">
                              <ul class="scollingsection-ul">
                               <li><a  href="javascript:" title="">Tauheed Institute of Technology </a></li>
                                <li><a  href="javascript:" title="">Tauheed Institute of Technology</a></li>
                               </ul>
                             </marquee>
                </div>
            </div>

        </div>
    </section>

    <%--......about Us.....--%>
    <section>
        <div class="aboutus-sec">
            <div class="container">
                <div class="row">

                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <div class="aboutussectext2">

                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <p class="aboutussectext23-p">Welcome To</p>
                                    <h2 class="aboutussectext2-h2"> <spain style="color:#bb2221;"></spain>Tauheed Institute of Technology  </h2>
                                    <p class="aboutussectext2-p22">
                                        <b>Tauheed Institute of Technology is an emerging institution in the field of Career-Oriented Computer Education provider in BIHAR.</b>
                                        <br />
                                        Welcome to TIIT (Tauheed Institute of Technology), an emerging IT-Institution for better Education.
                                      <br />
                                        The <b>Tauheed Institute of Technology,</b> a Knowledge Resource Center (College) of Maulana Mazharul Haque Arabic and Persian University, Patna, popularly known as <b>TIIT,</b> was established in 2008 with a vision to contribute to the IT world by focusing on better education and guidance....
                                    </p>
                                </div>
                            </div>

                            <div class="abobtnnn">
                                <a href="About-College.aspx" class="abobtnnn123"><i class="fa fa-pencil" aria-hidden="true"></i>&nbsp; Read More</a>
                                <a href="Contact-Us.aspx" class="abobtnnn123 abobtnnn144"><i class="fa fa-phone" aria-hidden="true"></i>&nbsp; Contact Now </a>
                            </div>

                        </div>
                    </div>

                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                        <div class="aboutdefaul">

                            <div class="boxab">
                                <img src="images/slider/slider-2.jpg"  alt="about in Tauheed Institute of Technology " title="about in Tauheed Institute of Technology " />
                                <div class="boxab-content">
                                    <h3 class="title">Learning, Innovating and Networking....the Knowledge</h3>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <%--.....latest news.....--%>
    <div data-ng-app="newssboard_ReportApp">

        <section>
            <div class="newsdefaulll">
                <div class="container">
                    <div class="row">

                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="serviceBox green">
                                <div class="service-icon">
                                    <span><i class="fa fa-newspaper-o"></i></span>
                                </div>
                                <h3 class="title">Latest News</h3>

                                <marquee onmouseover="stop();" onmouseout="start ();" scrollamount="5" scrolldelay="1" direction="up">
                                <div class="latest-news" data-ng-controller="myctrlnewss_page">
                                    <ul>
                                         <li data-ng-repeat="x in newss"><a rel="canonical" href="News-and-events.aspx">{{x.Headline22}}</a> </li>
                                    </ul>
                                </div>
                            </marquee>

                                <a href="News-and-events.aspx" class="read-more"><i class="fa fa-arrow-circle-o-right"></i></a>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="serviceBox read">
                                <div class="service-icon">
                                    <span><i class="fa fa-cloud-download"></i></span>
                                </div>
                                <h3 class="title">Download Link</h3>
                                <marquee onmouseover="stop();" onmouseout="start ();" scrollamount="6" scrolldelay="1" direction="up">
                                <div class="latest-news" data-ng-controller="myctrldownload_def">
                                    <ul >
                                         <li data-ng-repeat="x in downloaddef"><a rel="canonical" href="Download.aspx">{{x.Heading}} &nbsp;<i class="fa fa-cloud-download"></i></a> </li>
                                        
                                    </ul>
                                </div>
                            </marquee>
                                <a href="Download.aspx" class="read-more"><i class="fa fa-arrow-circle-o-right"></i></a>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="serviceBox blue">
                                <div class="service-icon">
                                    <span><i class="fa fa-pencil-square-o"></i></span>
                                </div>
                                <h3 class="title">Notice Board</h3>
                                <marquee onmouseover="stop();" onmouseout="start ();" scrollamount="7" scrolldelay="1" direction="up">
                                <div class="latest-news" data-ng-controller="myctrlnotice_def">
                                    <ul>
                                        <li data-ng-repeat="x in noticedef"><a rel="canonical" href="Notice-board.aspx" title="">{{x.Heading}} &nbsp;<i class="fa fa-cloud-download"></i></a> </li>
                                    </ul>
                                </div>
                            </marquee>
                                <a href="Notice-board.aspx" class="read-more"><i class="fa fa-arrow-circle-o-right"></i></a>
                            </div>
                        </div>

                    </div>
                </div>

                <%-- .............popup.............. --%>
                <div class="modal fade" id="myModa2" role="dialog" style="z-index: 999999">
                    <div class="modal-dialog" data-ng-controller="mypopupdef">
                        <div class="popup-content">
                            <button type="button" class="closepp" data-dismiss="modal"><i class="fa fa-times-circle" aria-hidden="true"></i></button>
                            <div class="popupimages" data-ng-repeat="x in popup">
                                <img src="{{x.Filepath}}" class="img-responsive popupimages22" title="" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </section>
    </div>

   
    <%-- ........student says.......... --%>
    <section style="display:none;">
        <div class="studentsays-sec">
            <div class="studentsays-secbgg">
                <div class="container">

                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                            <div class="testmonial333">
                                <h2 class="studsayssssh2">Students Says</h2>

                                <div class="client-says">
                                    <div class="three-column-carousel">

                                        <div class="item-holder">
                                            <div class="patinet-box">
                                                <figure>


                                                    <div class="owltext-imagexx">
                                                        <a rel="canonical" class="team-imgsec-a" href="javascript:">
                                                            <img src="images/student/kamal.jpg" alt="Kamal Haldar " />
                                                        </a>
                                                        <div class="top-iconsstar">
                                                            <ul class="top-icons-uliconsstar">
                                                                <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                                                <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                                                <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                                                <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                                                <li><i class="fa fa-star-half-o" aria-hidden="true"></i></li>
                                                            </ul>
                                                        </div>
                                                    </div>

                                                    <div class="owltext-imagexxtxx">
                                                        <h4 class="team-imgsec-h4">In Kolkata, TIIT (Tauheed Institute of Technology) studies are very good and here teachers are also very good who come on time every day and teach all the students on time and all the students study together.</h4>
                                                        <h2 class="team-imgsec-h2">Saurav Pandey
                                                            <br />
                                                            MCA -III 
                                                        </h2>
                                                    </div>


                                                </figure>
                                            </div>
                                        </div>

                                        <div class="item-holder">
                                            <div class="patinet-box">

                                                <div class="owltext-imagexx">
                                                    <a rel="canonical" class="team-imgsec-a" href="javascript:">
                                                        <img src="images/student/saurav.jpg" alt="Saurav Panday" />
                                                    </a>
                                                    <div class="top-iconsstar">
                                                        <ul class="top-icons-uliconsstar">
                                                            <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                                            <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                                            <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                                            <li><i class="fa fa-star" aria-hidden="true"></i></li>
                                                            <li><i class="fa fa-star-half-o" aria-hidden="true"></i></li>
                                                        </ul>
                                                    </div>
                                                </div>

                                                <div class="owltext-imagexxtxx">
                                                   <h4 class="team-imgsec-h4">TIIT (Tauheed Institute of Technology) at  Best of all, I felt that all the students live together without any caste discrimination and the teachers too and here every bell is studied and all the teachers explain very well.</h4>
                                                        <h2 class="team-imgsec-h2">Saurav Panday
                                                            <br />
                                                            BCA -III (2019-22)
                                                        </h2>
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
   
    <%--.....quick link.....--%>
    <section style="display:none;">
        <div class="quicklinkkd">
            <div class="container">
                <div class="row">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="dteammm">
                            <div class="servfacilitheading">
                                <p class="servfacilitw-p">Tauheed Institute of Technology</p>
                                <h2 class="servfacilitw-h2">Quick Links</h2>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="four-column-carousel">

                            <div class="item-holder">
                                <div class="patinet-box">
                                    <figure>
                                        <div class="owltext-quicklin">
                                            <a rel="canonical" class="quicklin-imgsec-a" href="javascript:">
                                                <img src="images/link/fac.png" alt="link in Tauheed Institute of Technology" title="link in Tauheed Institute of Technology" />
                                            </a>
                                            <a rel="canonical" href="#!" class="patinetaaa">Facilities</a>
                                        </div>
                                    </figure>
                                </div>
                            </div>

                            <div class="item-holder">
                                <div class="patinet-box">
                                    <figure>
                                        <div class="owltext-quicklin">
                                            <a rel="canonical" class="quicklin-imgsec-a" href="javascript:">
                                                <img src="images/link/calendar.png" alt="link in Tauheed Institute of Technology" title="link in Tauheed Institute of Technology" />
                                            </a>
                                            <a rel="canonical" href="#!" class="patinetaaa">Calendar</a>
                                        </div>
                                    </figure>
                                </div>
                            </div>

                            <div class="item-holder">
                                <div class="patinet-box">
                                    <figure>
                                        <div class="owltext-quicklin">
                                            <a rel="canonical" class="quicklin-imgsec-a" href="javascript:">
                                                <img src="images/link/faculity.png" alt="link in Tauheed Institute of Technology" title="link in Tauheed Institute of Technology" />
                                            </a>
                                            <a rel="canonical" href="#!" class="patinetaaa">Faculty</a>
                                        </div>
                                    </figure>
                                </div>
                            </div>

                            <div class="item-holder">
                                <div class="patinet-box">
                                    <figure>
                                        <div class="owltext-quicklin">
                                            <a rel="canonical" class="quicklin-imgsec-a" href="javascript:">
                                                <img src="images/link/result.png" alt="link in Tauheed Institute of Technology" title="link in Tauheed Institute of Technology" />
                                            </a>
                                            <a rel="canonical" href="#!" class="patinetaaa">Result</a>
                                        </div>
                                    </figure>
                                </div>
                            </div>

                            <div class="item-holder">
                                <div class="patinet-box">
                                    <figure>
                                        <div class="owltext-quicklin">
                                            <a rel="canonical" class="quicklin-imgsec-a" href="javascript:">
                                                <img src="images/link/course.png" alt="link in Tauheed Institute of Technology" title="link in Tauheed Institute of Technology" />
                                            </a>
                                            <a rel="canonical" href="#!" class="patinetaaa">Courses</a>
                                        </div>
                                    </figure>
                                </div>
                            </div>

                            <div class="item-holder">
                                <div class="patinet-box">
                                    <figure>
                                        <div class="owltext-quicklin">
                                            <a rel="canonical" class="quicklin-imgsec-a" href="javascript:">
                                                <img src="images/link/students.png" alt="link in Tauheed Institute of Technology" title="link in Tauheed Institute of Technology" />
                                            </a>
                                            <a rel="canonical" href="#!" class="patinetaaa">Students</a>
                                        </div>
                                    </figure>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <%--.....members.....--%>
    <%--.  <section>
        <div class="team-sec">
            <div class="container">

                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <div class="dteammm">
                            <div class="servfacilitheading">
                                <p class="servfacilitw-p">Tauheed Institute of Technology</p>
                                <h2 class="servfacilitw-h2">Our Members</h2>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="our-team">
                            <div class="pic">
                                <img src="images/members/member.jpg" alt="name" />
                            </div>
                            <h3 class="title">Umang Sir</h3>
                            <p class="linenann"></p>
                            <span class="post">Teacher</span>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="our-team">
                            <div class="pic">
                                <img src="images/members/member.jpg" alt="" />
                            </div>
                            <h3 class="title">Teacher Name</h3>
                            <p class="linenann"></p>
                            <span class="post">Teacher</span>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="our-team">
                            <div class="pic">
                                <img src="images/members/member.jpg" alt="Lalu Sir" />
                              
                            </div>
                            <h3 class="title">Teacher's Name</h3>
                            <p class="linenann"></p>
                            <span class="post">Accountant</span>
                        </div>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="our-team">
                            <div class="pic">
                                <img src="images/members/member.jpg" />
                            </div>
                            <h3 class="title">Teacher Name</h3>
                            <p class="linenann"></p>
                            <span class="post">Designation</span>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>.... --%>

    <%-- .................owl................ --%>
    <script src="owl/owl.carousel.min.js"></script>
    <script src="owl/script.js"></script>

    <script type="text/javascript">
        var app = angular.module('newssboard_ReportApp', []);
        app.controller('myctrlnewss_page', function ($scope, $http) {
            $http.get("WebService1.asmx/fetch_news_detailsmain").then(function (response) {
                $scope.newss = response.data;
            })
        });

        app.controller('myctrlnotice_def', function ($scope, $http) {
            $http.get("WebService1.asmx/fetch_notice_details_page").then(function (response) {
                $scope.noticedef = response.data;
            })
        });

        app.controller('myctrldownload_def', function ($scope, $http) {
            $http.get("WebService1.asmx/fetch_download_page").then(function (response) {
                $scope.downloaddef = response.data;
            })
        });

        app.controller('mypopupdef', function ($scope, $http) {
            $http.get("WebService1.asmx/fetch_popup_details").then(function (response) {
                $scope.popup = response.data;
                if ($scope.popup == "") {

                }
                else {
                    $('#myModa2').modal('show');
                }
            })
        });


    </script>

</asp:Content>
