<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Noticias.aspx.cs" Inherits="GetIntranet.Noticias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ol class="breadcrumb">
        <li><a href="#"><i class="icon-home"></i>Home</a></li>
        /
            <li><a href="#">Admin</a></li>
        /
            <li class="active">Noticias</li>
    </ol>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="span12">
                    <div class="widget widget-nopad">
                        <div class="widget-header">
                            <i class=" icon-paperclip"></i>
                            <h3>Noticias</h3>
                            <div class="pull-right">
                                <asp:LinkButton ID="BtnNuevo" OnClick="BtnNuevo_Click" runat="server" CssClass="btn btn-primary "><i class="icon-plus icon-white"></i>Nuevo</asp:LinkButton>
                            </div>
                        </div>
                        <div class="widget-content">
                            <asp:GridView ID="GrvNoticias" runat="server" CssClass="table table-bordered table-hover table-condensed small"
                                OnRowDataBound="GrvNoticias_RowDataBound" BorderColor="Transparent" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="LblId" runat="server" Text='<%# Bind("ID_NOTICIA") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Titulo">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTitulo" runat="server" Text='<%# Bind("TITULO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Noticia">
                                        <ItemTemplate>
                                            <asp:Label ID="LblNoticia" runat="server" Text='<%# Bind("DESCRIPCION") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="F.Creación">
                                        <ItemTemplate>
                                            <asp:Label ID="LblFechaCreacion" runat="server" Text='<%# Bind("PUBLICADO") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="F.Edición">
                                        <ItemTemplate>
                                            <asp:Label ID="LblFechaEdicion" runat="server" Text='<%# Bind("UltimaFechaModificacion") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Acción">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEditar" OnClick="btnEditar_Click" runat="server" CssClass="btn btn-xs btn-warning" ToolTip="Editar Registro"><span class="icon-edit"></span></asp:LinkButton>
                                            <asp:LinkButton ID="btnEliminar" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');" ToolTip="Eliminar Registro" runat="server" CssClass="btn btn-xs btn-danger"><span class=" icon-trash"></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
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
