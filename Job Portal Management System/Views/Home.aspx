<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Job_Portal_Management_System.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
          <%--carousel start--%>
       <div class="row">
           <div class="col-md-12">
<div id="carouselExampleCaptions" class="carousel slide" data-ride="carousel">
  <ol class="carousel-indicators">
    <li data-target="#carouselExampleCaptions" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleCaptions" data-slide-to="1"></li>
    <li data-target="#carouselExampleCaptions" data-slide-to="2"></li>
  </ol>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="../Resources/images/slide1.jpg" class="d-block w-100" height="460px" alt="...">
      <div class="carousel-caption d-none d-md-block">
        <h1 class="display-3 text-info font-weight-normal">Brilliant Job</h1>
        <p class="font-weight-bold text-dark">Don't waste your time.Find the job match with you.</p>
      </div>
    </div>
    <div class="carousel-item">
      <img src="../Resources/images/slide2.jpg" class="d-block w-100" height="460px" alt="...">
      <div class="carousel-caption d-none d-md-block">
        <h1 class="display-4 text-info font-weight-normal">Best Job Searching Website</h1>
        <p class="font-weight-bold text-dark">Trust Us.You will find the best job ever</p>
      </div>
    </div>
    <div class="carousel-item">
      <img src="../Resources/images/slide3.jpg" class="d-block w-100" height="460px" alt="...">
      <div class="carousel-caption d-none d-md-block">
        <button class="btn btn-info">Register Now</button>
        <p class="font-weight-bold text-dark">If you need the best employer.let's join us ,we will help you</p>
      </div>
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleCaptions" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleCaptions" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
           </div>
       </div>
        <%--carousel end--%>
    </div>
</asp:Content>
