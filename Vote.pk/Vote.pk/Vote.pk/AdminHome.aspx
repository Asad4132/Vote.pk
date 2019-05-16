﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="Vote.pk.AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vote.pk</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="myjs.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=Poppins">
    <link rel="stylesheet" href="mycss.css">
</head>
<body style="background-image: url(pics/bg_flag.jpg);">

    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse" style="border-radius: 0px !important; margin: 0; border: 0;">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand textWhite" href="HomePage.aspx">Vote.pk</a>
                </div>
                <div class="collapse navbar-collapse" id="myNavbar">
                    <ul class="nav navbar-nav">
                        <li class="active"><a href="VoterHome.aspx">(My)Home</a></li>
                        <li><a href="AddConstituency.aspx">AddConstituency</a></li>
                        <li><a href="Constituencies.aspx">Constituencies</a></li>
                        <li><a href="RegisterVoter.aspx">Register Voter</a></li>
                        <li><a href="Voters.aspx">Voters</a></li>
                        <li><a href="RegisterCandidate.aspx">Register Candidate</a></li>
                        <li><a href="Candidates.aspx">Candidates</a></li>

                    </ul>
                    <ul class="nav navbar-nav navbar-right">

                        <li><a href="SignOut.aspx"><span class="glyphicon glyphicon-log-in"></span>SignOut</a></li>

                    </ul>

                </div>
            </div>
        </nav>

        <div class="background-wrapper">

            <!--header-->

            <div class="container-fluid">
                <header>
                    <h2>Your Profile</h2>
                    <hr>
                </header>
                <br>
                <br>
                <br>

                <!--panel-->
                <div class="col-sm-8 col-sm-offset-2">
                    <div class="panel-group">
                        <div class="panel panel-default panel-transparent">
                            <div class="panel-heading">
                                <legend style="text-align: center;">Profile Information</legend>
                            </div>
                            <div class="panel-body">

                                <div>
                                    <form class="form-horizontal" name="signup" method="post" action="signup" style="padding: 0; margin: auto;">


                                        <br>
                                        <br>
                                        <br>
                                        <br>

                                    </form>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
            <br>
        </div>

    </form>
</body>
</html>