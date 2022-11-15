<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auxiliar.aspx.cs" Inherits="Carrito_de_Compras.Auxiliar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- CSS only -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
     
    <title>Pagina Auxiliar</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- NAV CON STICKY (Funciona?) -->
        <nav class="navbar sticky-bottom bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Sticky bottom</a>
            </div>
        </nav>

        <!-- NAV CON RESPONSIVE -->
                <nav class="navbar navbar-expand-lg bg-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Navbar scroll</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarScroll" aria-controls="navbarScroll" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarScroll">
                    <ul class="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll" style="--bs-scroll-height: 100px;">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Link
                            </a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="#">Action</a></li>
                                <li><a class="dropdown-item" href="#">Another action</a></li>
                                <li>
                                    <hr class="dropdown-divider">
                                </li>
                                <li><a class="dropdown-item" href="#">Something else here</a></li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link disabled">Link</a>
                        </li>
                    </ul>
                    <form class="d-flex" role="search">
                        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                        <button class="btn btn-outline-success" type="submit">Search</button>
                    </form>
                </div>
            </div>
        </nav>
        
        <!-- OTROS EJEMPLOS -->
        <%--        <div>
            <div class="container-sm">
                100% wide until small breakpoint
                <div class="container text-center">
                    <div class="row align-items-start">
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                    </div>
                    <div class="row align-items-end">
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                    </div>
                </div>
            </div>
            <div class="container-md">
                100% wide until medium breakpoint
                <div class="container text-center">
                    <div class="row align-items-start">
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                    </div>
                    <div class="row align-items-center">
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                    </div>
                    <div class="row align-items-end">
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                        <div class="col">
                            One of three columns
                        </div>
                    </div>
                </div>
            </div>
            <div class="container-lg">
                100% wide until large breakpoint
            <div class="container text-center">
                <div class="row align-items-start">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
                <div class="row align-items-center">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
                <div class="row align-items-end">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
            </div>
            </div>
            <div class="container-xl">
                100% wide until extra large breakpoint
            <div class="container text-center">
                <div class="row align-items-start">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
                <div class="row align-items-center">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
                <div class="row align-items-end">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
            </div>
            </div>
            <div class="container-xxl">
                100% wide until extra extra large breakpoint
            <div class="container text-center">
                <div class="row align-items-start">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
                <div class="row align-items-center">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
                <div class="row align-items-end">
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                    <div class="col">
                        One of three columns
                    </div>
                </div>
            </div>
            </div>
            <div>
                <button class="btn btn-primary">HOLA</button>
            </div>
        </div>--%>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
    </form>
</body>
</html>
