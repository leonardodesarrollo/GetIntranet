<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Perfiles.aspx.cs" Inherits="GetIntranet.Perfiles" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <ol class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i>Home</a></li>
                    /
            <li><a href="#">Admin</a></li>
                    /
            <li class="active">Perfiles</li>
                </ol>
            </section>

            <div class="row">
                <div class="span12">
                    <div class="widget widget-nopad">
                        <div class="widget-header">
                            <i class=" icon-user"></i>
                            <h3>Perfiles</h3>
                            <div class="pull-right">
                                <asp:LinkButton ID="BtnNuevo" OnClick="BtnNuevo_Click" runat="server" CssClass="btn btn-primary "><i class="icon-plus icon-white"></i>Nuevo</asp:LinkButton>
                            </div>

                        </div>
                        <div class="widget-content">
                            <asp:GridView ID="GrvPerfiles" runat="server" CssClass="table table-bordered table-hover table-condensed small"
                                OnRowDataBound="GrvPerfiles_RowDataBound" BorderColor="Transparent" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="LblId" runat="server" Text='<%# Bind("IdPerfil") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Perfil">
                                        <ItemTemplate>
                                            <asp:Label ID="LblPerfil" runat="server" Text='<%# Bind("Perfil") %>'></asp:Label>
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

            <asp:Button ID="Button1" runat="server" Style="display: none" />
            <asp:ModalPopupExtender ID="MdlAgregar" BackgroundCssClass="modalBackground" runat="server" PopupControlID="PnlAgregar" TargetControlID="Button1" BehaviorID="_MdlAgregar">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PnlAgregar" runat="server" Style="display: none; background: white; width: 100%; height: auto">
                <%--MODALPOPUP CON BOOTSTRAP--%>
                <div class="modal">
                    <div class="modal-header">
                        <button class="close" data-dismiss="modal" aria-hidden="true">x</button>
                        <h3>Perfil</h3>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="span6">
                                <asp:HiddenField ID="hfIdPerfil" runat="server" />
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon2">ID Perfil</span>
                                    <asp:TextBox ID="TxtIdPerfil" runat="server" Enabled="false" CssClass="input-medium"></asp:TextBox>
                                </div>
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1">Nombres</span>
                                    <asp:TextBox ID="TxtNombres" runat="server" CssClass="input-medium"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!-- /controls -->
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnGrabar" OnClick="BtnGrabar_Click" Text="Guardar" CssClass="btn btn-success" runat="server" />
                        <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
                <%--MODALPOPUP CON BOOTSTRAP--%>
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


        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
