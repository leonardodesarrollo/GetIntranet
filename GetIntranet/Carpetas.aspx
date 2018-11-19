<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Carpetas.aspx.cs" Inherits="GetIntranet.Carpetas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .treeNode {
            transition: all .3s;
            padding: 12px 5px;
            text-align: center;
            /*width: 100%;*/
            margin: 0;
            min-width: 250px !important;
            border: 2px solid #8e44ad;
            text-decoration: none !important;
            color: black;
            /*color:blue;
            font:14px Arial, Sans-Serif;*/
        }

        .rootNode {
            font-size: 18px;
            /*width:100%;*/
            border-bottom: Solid 1px black;
            color: #337ab7;
        }

        .leafNode {
            border: Dotted 2px black;
            padding: 10px;
            background-color: #eeeeee;
            font-weight: bold;
        }

        .selectNode {
            background-color: Black;
            border: Dotted 2px black;
            font-weight: bold;
            color: #fff;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Content Header (Page header) -->
    <ol class="breadcrumb">
        <li><a href="#"><i class="icon-home"></i>Home</a></li>
        /
            <li class="active">Carpetas</li>
    </ol>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="span4">
                    <div class="widget widget-table action-table">
                        <div class="widget-header">
                            <i class="icon-file"></i>
                            <h3>Carpetas</h3>
                        </div>
                        <div class="widget-content">
                            <asp:TreeView ID="tvwMenuCarga" runat="server" OnSelectedNodeChanged="tvwMenuCarga_SelectedNodeChanged"
                                Font-Size="Small" ExpandDepth="1" CssClass="table table-condensed">
                            </asp:TreeView>
                        </div>
                    </div>
                </div>

                <div class="span8">
                    <asp:Panel ID="pnlUsuarios" runat="server" DefaultButton="btnBuscar">
                        <div class="widget widget-table action-table">
                            <div class="widget-header">
                                <i class="icon-file"></i>
                                <h3>Carpetas</h3>
                            </div>
                            <div class="widget-content">
                                <table class="table table-condensed small">
                                    <tr class="active">
                                        <td width="200px">
                                            <asp:TextBox ID="txtBuscar" runat="server" Width="200px" CssClass="form-control input-sm" placeholder="Buscar"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-sm" Text="Buscar" OnClick="btnBuscar_Click" />
                                        </td>
                                        <td>
                                            <asp:Button ID="btnNuevaSeccion" runat="server" Text="Nueva Carpeta" CssClass="btn btn-success btn-sm" OnClick="btnNuevaSeccion_Click" />
                                        </td>
                                    </tr>
                                    <tr class="active">
                                        <td colspan="3">
                                            <strong>Carpeta</strong>
                                            <asp:Label ID="lblSeccion" runat="server" Text="Seleccionar Carpeta" CssClass="label label-danger"></asp:Label>
                                        </td>

                                    </tr>
                                </table>

                                <asp:GridView ID="grvSeccion" runat="server" CssClass="table table-bordered table-condensed"
                                    AutoGenerateColumns="false" AllowPaging="True"  PageSize="20"  OnRowDataBound="paginacion_RowDataBound" HeaderStyle-BackColor="Control">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id Carpeta">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdSeccion" runat="server" Text='<%# Bind("ID_SECCION") %>'></asp:Label>
                                                <asp:Label ID="lblIdUsuario" runat="server" Visible="false" Text='<%# Bind("ID_USUARIO") %>'></asp:Label>
                                                <asp:Label ID="lblUsuario" runat="server" Visible="false" Text='<%# Bind("USUARIO") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre Carpeta">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombreSeccion" runat="server" Text='<%# Bind("NOM_SECCION") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="14%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="BtnEditar" OnClick="BtnEditar_Click" runat="server" CssClass="btn btn-xs btn-warning" ToolTip="Editar Registro"><span class="icon-edit"></span></asp:LinkButton>
                                                <asp:LinkButton ID="BtnEliminar" OnClick="BtnEliminar_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');" ToolTip="Eliminar Registro" runat="server" CssClass="btn btn-xs btn-danger"><span class=" icon-trash"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                    <PagerTemplate>
                                        <div>
                                            <div style="float: left">
                                                <asp:ImageButton ID="imgFirst" runat="server"
                                                    ImageUrl="~/assets/img/grid/first.gif" OnClick="imgFirst_Click"
                                                    Style="height: 15px" title="Navegación: Ir a la Primera Pagina" Width="26px" />
                                                <asp:ImageButton ID="imgPrev" runat="server"
                                                    ImageUrl="~/assets/img/grid/prev.gif" OnClick="imgPrev_Click"
                                                    title="Navegación: Ir a la Pagina Anterior" Width="26px" />
                                                <asp:ImageButton ID="imgNext" runat="server"
                                                    ImageUrl="~/assets/img/grid/next.gif" OnClick="imgNext_Click"
                                                    title="Navegación: Ir a la Siguiente Pagina" Width="26px" />
                                                <asp:ImageButton ID="imgLast" runat="server"
                                                    ImageUrl="~/assets/img/grid/last.gif" OnClick="imgLast_Click"
                                                    title="Navegación: Ir a la Ultima Pagina" Width="26px" />
                                            </div>
                                            <div style="float: right">
                                                Página
                                <asp:Label ID="lblPagina" runat="server"></asp:Label>
                                                de
                                <asp:Label ID="lblTotal" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </PagerTemplate>
                                </asp:GridView>
                            </div>

                        </div>

                    </asp:Panel>


                    <asp:Button ID="btnAgregarSeccionMDL" runat="server" Style="display: none" />
                    <asp:ModalPopupExtender ID="mdlAgregarSeccion" CancelControlID="btnCancelar" BackgroundCssClass="modalBackground" runat="server" PopupControlID="pnlAgregar" TargetControlID="btnAgregarSeccionMDL" BehaviorID="_mdlAgregarSeccion">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlAgregar" runat="server" CssClass="panel" Style="background: white; width: 60%; height: auto; display: none">
                        <%--MODALPOPUP CON BOOTSTRAP--%>

                        <div class="modal">
                            <div class="modal-header">
                                <button id="btnCancelar" class="close" runat="server" data-dismiss="modal">
                                    ×
                                </button>
                                <strong>
                                    <asp:Label ID="lblAgregarSeccion" runat="server" Text=""></asp:Label></strong>
                            </div>

                            <asp:HiddenField ID="hfIdSeccion" runat="server" />
                            <asp:HiddenField ID="hfIdSeccionPadre" runat="server" />
                            <table class="table table-condensed small">
                                <tr class="active">
                                    <td><strong>
                                        <asp:Label ID="lblSeccionPadre" runat="server" Text="Carpeta" Visible="true"></asp:Label>
                                        <asp:Label ID="lblIdSeccion" runat="server" Text="Id Carpeta" Visible="false"></asp:Label>
                                    </strong>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNombreSeccion" runat="server" Text="" Visible="false"></asp:Label>

                                        <asp:Label ID="lblSeccion2" runat="server" Text="Seleccionar Carpeta" CssClass="label label-danger"></asp:Label>
                                        <asp:DropDownList ID="ddlNodoPadre" Visible="false" runat="server" CssClass="form-control input-sm" Width="200px"
                                            OnSelectedIndexChanged="ddlNodoPadre_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="True">
                                            <asp:ListItem Value="0">Root</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr class="active">
                                    <td><strong>Nombre</strong>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNombre" runat="server" Width="150px" CssClass="form-control input-sm"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvTxtNombre" runat="server"
                                            ErrorMessage="¡Favor de ingresar el nombre!"
                                            ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="formularioIngreso">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            <div id="divvsdfv" runat="server" visible="false">
                                <fieldset runat="server" id="fsSeccionHijos">
                                    <strong>Sub Carpeta</strong>

                                    <asp:GridView ID="grvNodoHijo" runat="server" CssClass="table table-bordered table-hover table-condensed small" AutoGenerateColumns="false">

                                        <Columns>
                                            <asp:TemplateField HeaderText="Nombre Carpeta">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombreSeccionHijo" runat="server" Text='<%# Bind("NOM_SECCION") %>'></asp:Label>
                                                    <asp:Label ID="lblIdSeccionHijo" runat="server" Visible="false" Text='<%# Bind("ID_SECCION") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="7%">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgEliminar" runat="server" ImageUrl="~/assets/img/delete.png" OnClick="imgEliminarHijo_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');" ToolTip="Eliminar" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                </fieldset>
                            </div>

                            <div class="modal-footer">
                                <asp:Button ID="btnModificar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-sm" OnClick="btnModificar_Click" />
                                <asp:Button ID="btnAgregar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-sm" OnClick="btnAgregar_Click" ValidationGroup="formularioIngreso" />
                            </div>
                            <%--MODALPOPUP CON BOOTSTRAP--%>
                        </div>

                    </asp:Panel>




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




                </div>

            </div>



        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
