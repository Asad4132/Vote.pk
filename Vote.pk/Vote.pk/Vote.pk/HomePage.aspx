<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Vote.pk.HomePage" %>

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
<body>

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
                        <li class="active"><a href="HomePage.aspx">Home</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="SignUp.aspx"><span class="glyphicon glyphicon-user"></span>SignUp</a></li>
                        <li><a href="Login.aspx"><span class="glyphicon glyphicon-log-in"></span>Login</a></li>

                    </ul>

                </div>
            </div>


            <!--carousal-->

            <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li data-target="#myCarousel" data-slide-to="1"></li>
                    <li data-target="#myCarousel" data-slide-to="2"></li>
                    <li data-target="#myCarousel" data-slide-to="3"></li>
                    <li data-target="#myCarousel" data-slide-to="4"></li>
                </ol>

                <!-- Wrapper for slides -->
                <div class="carousel-inner img-responsive" style="max-height: 620px">
                    <div class="item active">
                        <img src="pics/bg_flag.jpg" style="width: 100%">
                        <div class="carousel-caption">
                            <p>Welcome to</p>
                            <hr style="width: 40%">
                            <h2>E - Voting</h2>
                        </div>
                    </div>

                    <div class="item">
                        <img src="pics/wall/9.jpg" style="width: 100%">
                        <div class="carousel-caption">
                            <p>Your Vote Matters!</p>
                            <hr style="width: 40%">
                            <h2>Think Before Casting Your Vote</h2>
                        </div>
                    </div>

                    <div class="item">
                        <img src="pics/fireWorks.jpg" style="width: 100%">
                        <div class="carousel-caption">
                            <p>Whom to Choose!</p>
                            <hr style="width: 40%">
                            <h2>Better Pakistan, Better Future</h2>
                        </div>
                    </div>

                    <div class="item">
                        <img src="pics/wall/11.jpg" style="width: 100%">
                        <div class="carousel-caption">
                            <p>Have any question?</p>
                            <hr style="width: 40%">
                            <h2>Contact Us</h2>
                        </div>
                    </div>

                    <div class="item">
                        <img src="pics/wall/12.jpg" style="width: 100%">
                        <div class="carousel-caption">
                            <p>Have any question?</p>
                            <hr style="width: 40%">
                            <h2>Contact Us</h2>
                        </div>
                    </div>
                </div>
            </div>
        </nav>


        <div class="row" style="padding: 5rem ;margin: 0; text-align: center;">
            <div class="col-sm-4">
                <div class="thumbnail" href="booking.html">
                    <img src="pics/quaid.jpeg" style="width:100%;height: 35rem">
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail" href="contactus.html">
                    <img src="pics/map.jpg" style="width:100%;height: 35rem">
                                                            
                </div>
            </div>
            <div class="col-md-4">
                <div class="thumbnail" href="aboutus.html">
                    <img src="pics/iqbal.jpeg" style="width:100%;height: 35rem">
                                                            
                </div>
            </div>
        </div>
                                    
        <!--background slide image-->
        <div class="background-wrapper" style="background-image: url(pics/bg_flag.jpg);">
            <div style="text-align: center; padding: 10rem; color:white">
                <h3>come to improve our homeland together, come towards better future - better Pakistan</h3>
                <hr width="30%" align="center">
                <h1>Welcome to Vote.pk</h1>
            </div>
        </div>
    </form>
</body>
</html>
