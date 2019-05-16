<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CastVote.aspx.cs" Inherits="Vote.pk.CastVote" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vote.pk</title>
    <script type="text/javascript" language="javascript">
        function Confirmation()
        {
            if (confirm("Are you sure?") == true)
                return true;
            else
                return false;
        }
    </script>
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
                        <li><a href="VoterHome.aspx">(My)Home</a></li>
                        <li class="active"><a href="CastVote.aspx">Cast Vote</a></li>
                        <li><a href="ConstituencyResult.aspx">Constituency Result</a></li>

                    </ul>
                    <ul class="nav navbar-nav navbar-right">

                        <li><a href="SignOut.aspx"><span class="glyphicon glyphicon-log-in"></span>SignOut</a></li>

                    </ul>

                </div>
            </div>
        </nav>

        <div class="background-wrapper" style="background-image: url(pics/bg_flag.jpg);">

            <!--header-->

            <div class="container-fluid">
                <header>
                    <h2>Candidates List</h2>
                    <hr>
                </header>
                <br>
                <br>
                <br>

                <!--panel-->
                <div class="col-sm-10 col-sm-offset-1">
                    <div class="panel-group">
                        <div class="panel panel-default panel-transparent">
                            <div class="panel-heading">
                                <legend style="text-align: center;">Candidates Information</legend>
                            </div>
                            <div class="panel-body">

                                <div align="center">
                                    <form class="form-horizontal" name="constituencyresult" method="post" action="constituencyresult" style="padding: 0; margin: auto;">

                                        <asp:GridView ID="GridView1" style="text-align=center" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:Button ID="Button1" class="btn btn-success trans-input-area" OnClick="Button1_Click" Text="Vote" runat="server" OnClientClick="return Confirmation();" CommandName="AddToCart" CommandArgument='<%#Eval("ID")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <Columns>
                                                <asp:TemplateField HeaderText="ElectoralSignImage">
                                                    <ItemTemplate>
                                                        <asp:Image ID="Image1"  runat="server" Height="100px" Width="100px"
                                                            ImageUrl='<%#"data:Image/png;base64," + Convert.ToBase64String((byte[])Eval("ElectoralSignImage")) %>'/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:Label ID="label1" runat="server"></asp:Label>
                                        <br>
                                        <br>
                                        <br>
                                        <br>

                                        <div class="from-group-btn col-sm-12">

                                            <br>
                                        </div>
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
