<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="News-and-events.aspx.cs" Inherits="TIIT.News_and_events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    News & Events
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <section>
        <div class="aboutus-page">
            <div class="aboutus-page-bg">
                <div class="container">
                    <div class="row">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <div class="aboutus-pagetext">
                                <h2 class="aboutus-pagetext-h2">News & Events</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">News & Events</a></li>
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
                                <h2 class="text-headingtt-h2">News & Events</h2>
                            </div>

                            <div class="row" data-ng-app="newssboardrr_ReportApp" data-ng-controller="myNews44">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" data-ng-repeat="x in news">
                                    <div class="new-wraper">
                                        <h2 class="new-date">
                                            <img src="images/calendar.png" class="calender-icon44" />
                                            &nbsp;&nbsp;{{x.Date}}</h2>
                                        <h2 class="new-heading">{{x.Headline}}</h2>
                                        <p class="new-p">{{x.Description}} </p>
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
        var app = angular.module('newssboardrr_ReportApp', []);
        app.controller('myNews44', function ($scope, $http) {
            $http.get("WebService1.asmx/fetch_news_details").then(function (response) {
                $scope.news = response.data;
                if ($scope.news == "") {
                    alert("Sorry no data found");
                }
            })
        });
    </script>

</asp:Content>
