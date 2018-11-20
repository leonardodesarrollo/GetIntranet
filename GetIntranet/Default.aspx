<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GetIntranet.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:PlaceHolder runat="server">
        <%: System.Web.Optimization.Styles.Render("~/Content/AjaxControlToolkit/Styles/Bundle") %>
    </asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">


        <div class="span4">
            <a href="servicios/servicios-detalles.php?id=1">
                <h1 class="textoservicio">CONSTRUCTORA TAGOR</h1>
            </a>

            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=1" class="avatar">
                <img width="350px" src="Assets/img/servicio3.jpg" /></a>

            <h3 class="segundotitulo">Constructora</h3>

            <p class="tercertitulo" style="text-align: justify">
                La empresa está orientada principalmente a servicios  de construcción a nivel nacional e internacional  para proyectos de minería,  obras civiles, urbanizaciones y edificación de extensión y altura, entre otros.<br>
                Gracias a la correcta ejecución de los trabajos y cumplimiento de los tiempos de entrega de cada obra, somos una empresa confiable, flexible, que vela por la seguridad de sus colaboradores y busca ser un aliado estratégico de sus clientes. 
            </p>
            <a class="btn btn-default" target="_blank" style="text-align: justify" href="http://tagor.cl/servicios/servicios-detalles.php?id=1">Ver Más</a>

        </div>
        <div class="span4">
            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=2">
                <h1 class="textoservicio">TAGOR MANTENIMIENTO</h1>
            </a>
            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=2">
                <img class="avatar" width="350px" alt="" src="Assets/img/servicio2.jpg"></a>
            <h3 class="segundotitulo">Mantenimiento Industrial</h3>
            <p class="tercertitulo" style="text-align: justify">Diseño e implementación de planes de mantenimiento correctivos y preventivos de instalaciones y activos, con el fin de evitar anomalías o fallas de funcionamiento que afecten la disponibilidad de activos, en particular, y la rentabilidad del negocio de nuestros clientes, en general.</p>
            <a class="btn btn-default" target="_blank" style="text-align: justify" href="http://tagor.cl/servicios/servicios-detalles.php?id=2">Ver Más</a>

        </div>
        <div class="span4">
            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=3">
                <h1 class="textoservicio">TAGOR MINERIA</h1>
            </a>
            <a href="http://tagor.cl/servicios/servicios-detalles.php?id=3">
                <img class="avatar" alt="" width="350px" src="Assets/img/servicio1.jpg"></a>
            <h3 class="segundotitulo">Mineria</h3>

            <p class="tercertitulo" style="text-align: justify">
                En construcción.
            </p>
            <a class="btn btn-default" style="text-align: justify" target="_blank" href="http://tagor.cl/servicios/servicios-detalles.php?id=3">Ver Más</a>

        </div>




    </div>
    <!-- /row -->
    <br />



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <a href="#">
                <h1 class="textoservicio">NOTICIAS</h1>
            </a>
            <div class="row">
                <div class="span8">
                    <asp:Repeater ID="RptNoticias" runat="server">
                        <ItemTemplate>
                            <div class="row-fluid">
                                <div class=" span12">
                                    <div class="widget widget-table action-table">
                                        <div class="widget-header">
                                            <i class=" icon-paperclip"></i>
                                            <h3><%# Eval("TITULO") %></h3>
                                        </div>
                                        <div class="widget-content">
                                            <div class="row-fluid">
                                                <div class="span11">
                                                    <%# Eval("DESCRIPCION") %>
                                                </div>
                                            </div>
                                            
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                   <%-- <div class="row-fluid">
                        <div class=" span12">
                            <div class="widget widget-table action-table">
                                <div class="widget-header">
                                    <i class=" icon-paperclip"></i>
                                    <h3>eeee</h3>
                                </div>
                                <div class="widget-content">
                                    ddd
                                </div>
                            </div>
                        </div>
                    </div>--%>
                </div>
                <div class="span4">

                    <div class="widget widget-table action-table">
                        <div class="widget-header">
                            <i class="icon-money"></i>
                            <h3>Indicadores</h3>
                        </div>
                        <div class="widget-content">
                            <table class="table table-condensed table-bordered">
                                <tr class="active">
                                    <th><strong>Indicador</strong></th>
                                    <th><strong>Valor</strong></th>
                                </tr>
                                <tr>
                                    <td>U.F.</td>
                                    <td>$<asp:Label ID="LblUf" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>U.T.M.</td>
                                    <td>$<asp:Label ID="LblUtm" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Dolar</td>
                                    <td>$<asp:Label ID="LblDolar" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>Euro</td>
                                    <td>$<asp:Label ID="LblEuro" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div class="widget widget-table action-table">
                        <div class="widget-header">
                            <i class="icon-time"></i>
                            <h3>Tiempo</h3>
                        </div>
                        <div class="widget-content">
                            <div id="cont_c6677e970a6b2844c5b2e7cbb5bf3e92">
                                <script type="text/javascript" async src="https://www.meteored.cl/wid_loader/c6677e970a6b2844c5b2e7cbb5bf3e92"></script>
                            </div>

                            <div id="cont_aa02044f70157f91f2bc66527aa1302a">
                                <script type="text/javascript" async src="https://www.meteored.cl/wid_loader/aa02044f70157f91f2bc66527aa1302a"></script>
                            </div>
                        </div>
                    </div>
                </div>
            </div>




            <asp:Button ID="btnActivarPopUp" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="mdlInformacion" BackgroundCssClass="modalBackground" runat="server" PopupControlID="pnlInformacion" TargetControlID="btnActivarPopUp" BehaviorID="_mdlInformacion">
            </asp:ModalPopupExtender>
            <asp:Panel ID="pnlInformacion" runat="server" Style="display: none; background: white; width: 40%; height: auto">
                <%--MODALPOPUP CON BOOTSTRAP--%>
                <div class="modal">
                    <div class="modal-header">
                        <button class="close" data-dismiss="modal" aria-hidden="true">x</button>
                        <h3 id="myModalLabel">Informacion</h3>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
                <%--MODALPOPUP CON BOOTSTRAP--%>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
