<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="TIIT.Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Download
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        table th {
            padding: 5px 10px;
            font-size: 15px;
        }

        table td {
            padding: 5px 10px;
            font-size: 15px;
            color: #333;
        }

        text-decoration-justify {
            text-align: center;
            width: 100px;
            text-decoration: alphabetic;
        }

        table tr {
            height: auto;
            width: 100%;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
        }

        .table-bordered {
            height: auto;
            width: 100%;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        table, th {
            height: auto;
            margin: 0px 0px 0px 0px;
            padding: 8px 10px 8px 10px !important;
            font-size: 16px;
            line-height: 23px;
            color: #fff;
            text-align: left!important;
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
                                <h2 class="aboutus-pagetext-h2">Download</h2>
                            </div>
                            <ul class="aboutus-pagetext-ul">
                                <li><a href="Default.aspx">Home /</a></li>
                                <li><a href="javascript:">Download</a></li>
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
                        <h2 class="text-headingtt-h2">Download File List</h2>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-8 col-lg-offset-2 col-md-8 col-md-offset-2 col-sm-12 col-xs-12">
                        <div class="mnge-bdy-wpr" data-ng-app="downloadbpage_ReportApp" data-ng-controller="myctrldownloaddd_page">

                            <div class="table-responsive">
                                <table class="table-bordered">
                                    <tr style="background-color: #138400d4; color: #fff">
                                        <th style="width: 70px">Sl. No.</th>
                                        <th>Headline</th>

                                        <th>Download File</th>
                                        <th>Uploaded Date</th>
                                    </tr>

                                    <tr data-ng-repeat="x in download">

                                        <td>{{ $index + 1 | number }}</td>
                                        <td>{{x.Heading}}</td>
                                        <td><a href="{{x.FilePath}}" target="_blank" title="Download" style="padding: 6px 0px; float: left; width: 100%; color: #2d2d2d;"><i class="fa fa-download" aria-hidden="true" style="color: #033b4a; margin-right: 8px; font-size: 18px;"></i></a></td>
                                        <td>{{x.Date}}</td>
                                    </tr>

                                </table>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>

    <script type="text/javascript">
        var app = angular.module('downloadbpage_ReportApp', []);
        app.controller('myctrldownloaddd_page', function ($scope, $http) {
            $http.get("WebService1.asmx/fetch_download_page").then(function (response) {
                $scope.download = response.data;
                if ($scope.download == "") {
                    alert("No data found");
                }
            })
        });
    </script>


</asp:Content>
