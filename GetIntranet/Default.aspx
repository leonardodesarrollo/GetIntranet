<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GetIntranet.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server">
        <%: System.Web.Optimization.Styles.Render("~/Content/AjaxControlToolkit/Styles/Bundle") %>
    </asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <%--        <div class="span12">
            <div id="target-1" class="widget">
                <div class="widget-content">
                    <h1>12 Columns</h1>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                </div>
                <!-- /widget-content -->
            </div>
            <!-- /widget -->
        </div>
        <!-- /span12 -->--%>

        <%--        <div class="span6">

            <div class="widget">

                <div class="widget-content">

                    <h1>6 Columns</h1>

                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip.</p>

                </div>
                <!-- /widget-content -->

            </div>
            <!-- /widget -->

        </div>
        <!-- /span6 -->


        <div class="span6">

            <div id="target-2" class="widget">

                <div class="widget-content">

                    <h1>6 Columns</h1>

                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip.</p>

                </div>
                <!-- /widget-content -->

            </div>
            <!-- /widget -->

        </div>
        <!-- /span6 -->--%>





        <%--

        <div class="span4">

            <div id="target-3" class="widget">

                <div class="widget-content">

                    <h1>CONSTRUCTORA TAGOR</h1>

                    <p>
                        La empresa está orientada principalmente a servicios de construcción a nivel nacional e internacional para proyectos de minería, obras civiles, urbanizaciones y edificación de extensión y altura, entre otros.
Gracias a la correcta ejecución de los trabajos y cumplimiento de los tiempos de entrega de cada obra, somos una empresa confiable, flexible, que vela por la seguridad de sus colaboradores y busca ser un aliado estratégico de sus clientes.
                    </p>

                </div>
                <!-- /widget-content -->

            </div>
            <!-- /widget -->

        </div>
        <!-- /span4 -->


        <div class="span4">

            <div class="widget">

                <div class="widget-content">

                    <h1>TAGOR MANTENIMIENTO</h1>

                    <p>Diseño e implementación de planes de mantenimiento correctivos y preventivos de instalaciones y activos, con el fin de evitar anomalías o fallas de funcionamiento que afecten la disponibilidad de activos, en particular, y la rentabilidad del negocio de nuestros clientes, en general.</p>

                </div>
                <!-- /widget-content -->

            </div>
            <!-- /widget -->

        </div>
        <!-- /span4 -->


        <div class="span4">

            <div class="widget">

                <div class="widget-content">

                    <h1>TAGOR MINERIA</h1>

                    <p>En construcción.</p>

                </div>
                <!-- /widget-content -->

            </div>
            <!-- /widget -->

        </div>
        <!-- /span4 -->
        --%>



        <div class="span4">
            <a href="servicios/servicios-detalles.php?id=1">
                <h1 class="textoservicio">CONSTRUCTORA TAGOR</h1>
            </a>

            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=1" class="avatar">
                <img width="350px" src="Assets/img/servicio3.jpg" /></a>

            <h3 class="segundotitulo">Constructora</h3>

            <p class="tercertitulo">
                La empresa está orientada principalmente a servicios  de construcción a nivel nacional e internacional  para proyectos de minería,  obras civiles, urbanizaciones y edificación de extensión y altura, entre otros.<br>
                Gracias a la correcta ejecución de los trabajos y cumplimiento de los tiempos de entrega de cada obra, somos una empresa confiable, flexible, que vela por la seguridad de sus colaboradores y busca ser un aliado estratégico de sus clientes. 
            </p>
            <a class="btn btn-default" style="text-align: right" href="http://tagor.cl/servicios/servicios-detalles.php?id=1">Ver Más</a>

        </div>
        <div class="span4">
            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=2">
                <h1 class="textoservicio">TAGOR MANTENIMIENTO</h1>
            </a>
            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=2">
                <img class="avatar" width="350px" alt="" src="Assets/img/servicio2.jpg"></a>
            <h3 class="segundotitulo">Mantenimiento Industrial</h3>
            <p class="tercertitulo">Diseño e implementación de planes de mantenimiento correctivos y preventivos de instalaciones y activos, con el fin de evitar anomalías o fallas de funcionamiento que afecten la disponibilidad de activos, en particular, y la rentabilidad del negocio de nuestros clientes, en general.</p>
            <a class="btn btn-default" style="text-align: right" href="http://tagor.cl/servicios/servicios-detalles.php?id=2">Ver Más</a>

        </div>
        <div class="span4">
            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=3">
                <h1 class="textoservicio">TAGOR MINERIA</h1>
            </a>
            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=3">
                <img class="avatar" alt="" width="350px" src="Assets/img/servicio1.jpg"></a>
            <h3 class="segundotitulo">Mineria</h3>

            <p class="tercertitulo">
                En construcción.


            </p>
            <a class="btn btn-default" style="text-align: right" href="http://tagor.cl/servicios/servicios-detalles.php?id=3">Ver Más</a>

        </div>




    </div>
    <!-- /row -->
    <br />

    <h1>Noticias</h1>
    <div class="row">
        <div class="span8">
            <div class="row-fluid">
                <div class=" span12">
                    <div id="target-3" class="widget">
                        <div class="widget-content">
                            <h1>CONSTRUCTORA TAGOR</h1>
                            <p>
                                fffs
                            </p>
                        </div>
                        <!-- /widget-content -->
                    </div>
                    <!-- /widget -->
                </div>
            </div>
            <div class="row-fluid">
                <div class="span12">
                    <div id="target-4" class="widget">
                        <div class="widget-content">
                            <h1>CONSTRUCTORA TAGOR2</h1>
                            <p>
                                fffs
                            </p>
                        </div>
                        <!-- /widget-content -->
                    </div>
                    <!-- /widget -->
                </div>
            </div>
        </div>
        <div class="span4">
            <div id="target-5" class="widget">
                <div class="widget-content">
                    <h1>CONSTRUCTORA TAGOR</h1>
                    <p>
                        fffs
                    </p>
                </div>
                <!-- /widget-content -->
            </div>
            <!-- /widget -->
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
