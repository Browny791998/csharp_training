<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Common/Layout/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Job_Portal_Management_System.Views.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container bg-light bg-info">
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
            
            <h1 class="text-center mt-3 text-warning">About Our Wesite</h1>

        <div class="row mt-3">
            <div class="col-md-5">
                <img src="../Resources/images/slide1.jpg" width="400" height="250" class="img-thumbnail"/>
            </div>
            <div class="col-md-7">
                <p>
                    Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.
                </p>
            </div>
        </div>


           <h1 class="text-center mt-5 text-warning">What We do</h1>
        <div class="d-flex flex-row justify-content-around mt-5">
            <div class="card border-info mb-3" style="max-width: 18rem;">
<div class="card-body text-info">
    <h5 class="card-title"> <i class="fa-solid fa-chart-user"></i> Best Service</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
</div>
            <div class="card border-info mb-3" style="max-width: 18rem;">
<div class="card-body text-info">
    <h5 class="card-title"> <i class="fa-solid fa-chart-user"></i> Best Service</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
</div>
            <div class="card border-info mb-3" style="max-width: 18rem;">
<div class="card-body text-info">
    <h5 class="card-title"> <i class="fa-solid fa-chart-user"></i> Best Service</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
  </div>
</div>
          
        </div>
    </div>
</asp:Content>
