<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Biblioteca.aspx.cs" Inherits="GetIntranet.Biblioteca" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Content Header (Page header) -->
    <ol class="breadcrumb">
        <li><a href="#"><i class="icon-home"></i>Home</a></li>
        /
            <li class="active">Biblioteca</li>
    </ol>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

            <div class="row">
                <div class="span4">
                    <div class="widget widget-table action-table">
                        <div class="widget-header">
                            <i class="icon-file"></i>
                            <h3>Carpetas</h3>
                        </div>
                        <div class="widget-content">
                            <asp:TreeView ID="tvwMenuCarga" runat="server" OnSelectedNodeChanged="tvwMenuCarga_SelectedNodeChanged" ShowExpandCollapse="True"
                                Font-Size="Small" ExpandDepth="2" CssClass="table table-condensed">
                            </asp:TreeView>
                        </div>
                    </div>
                </div>
                <div class="span8">
                    <asp:Panel ID="pnlMostrarCargaArchivoBiblioteca" runat="server" DefaultButton="btnGrabar">
                        <div class="widget widget-table action-table">
                            <div class="widget-header">
                                <i class="icon-file"></i>
                                <h3>Modulo Carga Archivo
                                    <asp:Label ID="lblPath" runat="server" Text="Seleccione carpeta" CssClass="text-info label label-success"></asp:Label>
                                </h3>
                                <asp:Button ID="BtnNuevoArchivo" runat="server" CssClass="btn btn-success" Text="Nuevo" Visible="false" OnClick="BtnNuevoArchivo_Click" />
                            </div>
                            <div class="widget-content">

                                <table class="table table-condensed" runat="server" visible="false" id="TablaIngresoArchivo">
                                    <tr>
                                        <td>
                                            <label class="control-label" for="txtNombreArchivo">Nombre</label>
                                            <asp:TextBox ID="txtNombreArchivo" runat="server" CssClass="form-control span2"></asp:TextBox>
                                            <asp:HiddenField ID="hfIdSeccion" runat="server" />
                                        </td>
                                        <td colspan="3">
                                            <label class="control-label" for="txtDescripcion">Descripción</label>
                                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control span5"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="control-label" for="txtDescripcion">Email Para</label>
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                            <label class="control-label" for="txtDescripcion">Email CC</label>
                                            <asp:TextBox ID="txtEmailCC" runat="server" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                            <label class="control-label" for="txtDescripcion">Archivo</label>
                                            <asp:FileUpload ID="fuArchivo" runat="server" CssClass="form-control" />
                                           <%-- <input id="inputFile" runat="server" type="file"  class="input-medium"/>--%>
                                            
                                        </td>

                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Button ID="btnGrabar" runat="server" CssClass=" btn btn-danger"
                                                Text="Guardar" OnClick="btnGrabar_Click" />
                                            <asp:Button ID="BtnCancelar" runat="server" CssClass="btn"
                                                Text="Cancelar" OnClick="BtnCancelar_Click" />
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>
                    </asp:Panel>

                    <asp:GridView ID="grvDetalleBiblioteca" HeaderStyle-CssClass="active" runat="server"
                        CssClass="table t table-bordered table-hover table-condensed " AutoGenerateColumns="false"
                        OnRowDataBound="grvDetalleBiblioteca_RowDataBound" EmptyDataText="No se encontraron registros asociados">
                        <Columns>
                            <asp:TemplateField HeaderText="Archivo">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgVisualizar" CausesValidation="False" runat="server" Visible="true" ImageUrl="~/assets/img/file_manager.png" ToolTip="Seleccionar" OnClick="imgVisualizar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreArchivo" runat="server" Text='<%# Bind("ARCHIVO") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblId" runat="server" Visible="false" Text='<%# Bind("ID") %>'></asp:Label>
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("NOMBRE") %>' Visible="true" ToolTip='<%# Bind("EMAIL") %>'></asp:Label>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("EMAIL") %>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblEmailCC" runat="server" Text='<%# Bind("EMAIL_CC") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Descripción">
                                <ItemTemplate>
                                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Bind("DESCRIPCION") %>' Visible="true"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha Ingreso">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaIngreso" runat="server" Text='<%# Bind("FECHA") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Usuario Ingreso">
                                <ItemTemplate>
                                    <asp:Label ID="lblUsuario" runat="server" Text='<%# Bind("LOGIN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reenviar Email" Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbtnReenviarEmail" CssClass="btn btn-success btn-xs" runat="server"
                                        OnClick="lbtnReenviarEmail_Click"><i aria-hidden="true" class="glyphicon glyphicon-envelope"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnEliminar" OnClick="BtnEliminar_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');" ToolTip="Eliminar Registro" runat="server" CssClass="btn btn-xs btn-danger"><span class=" icon-trash"></span></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>



            

    <%--MODALPOPUP CON BOOTSTRAP--%>
    <asp:Button ID="Button1" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="mdlImagen" BackgroundCssClass="modalBackground" runat="server" PopupControlID="pnlImagen" TargetControlID="Button1">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlImagen" runat="server" CssClass="panel" Style="background: white; width: auto; height: auto; overflow: auto; display: none">
        <div class="modal">
            <div class="modal-header">
                <asp:Button ID="btnCerrarImagen" CssClass="close" runat="server" Text="x" OnClick="imgCerrar_Click" Visible="false" />
                <button class="close" data-dismiss="modal" aria-hidden="true">x</button>
                <h3 id="myModalLabel">Imagen</h3>
            </div>
            <div class="modal-body">
                <div class="pagination-centered">
                    <asp:Image ID="imgFoto" CssClass="img-rounded" Width="100%" runat="server" ImageAlign="Middle"  />
                </div>
            </div>
            <div class="modal-footer">
                <button class="btn" data-dismiss="modal" aria-hidden="true">Cerrar</button>
            </div>
        </div>


    </asp:Panel>




    <asp:Button ID="btnActivarPopUp" runat="server" Style="display: none" />
    <asp:ModalPopupExtender ID="mdlInformacion" BackgroundCssClass="modalBackground" runat="server" PopupControlID="pnlInformacion" TargetControlID="btnActivarPopUp">
    </asp:ModalPopupExtender>
    <asp:Panel ID="pnlInformacion" runat="server" CssClass="panel" Style="display: none; background: white; width: 40%; height: auto">
        <%--MODALPOPUP CON BOOTSTRAP--%>
    

        <div class="modal">
            <div class="modal-header">
                <button class="close" data-dismiss="modal" aria-hidden="true">x</button>
                <h3 id="myModalInformacion">Informacion</h3>
            </div>
            <div class="modal-body">
                <asp:Label ID="lblInformacion" runat="server" Text=""></asp:Label>
            </div>
            <div class="modal-footer">
                <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
            </div>
        </div>
    </asp:Panel>

            
        </ContentTemplate>
      
    </asp:UpdatePanel>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
