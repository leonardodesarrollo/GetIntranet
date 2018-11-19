<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="GetIntranet.Usuarios" %>

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
            <li class="active">Usuarios</li>
                </ol>
            </section>

            <div class="row">
                <div class="span12">
                    <div class="widget widget-nopad">
                        <div class="widget-header">
                            <i class=" icon-user"></i>
                            <h3>Usuarios</h3>
                            <div class="pull-right">
                                <asp:LinkButton ID="btnNuevoUsuario" OnClick="btnNuevoUsuario_Click" runat="server" CssClass="btn btn-primary "><i class="icon-plus icon-white"></i>Agregar Usuario</asp:LinkButton>
                            </div>

                        </div>
                        <div class="widget-content">
                            <asp:GridView ID="grvUsuarios" runat="server" CssClass="table table-bordered table-hover table-condensed small"
                                 OnRowDataBound="grvUsuarios_RowDataBound" BorderColor="Transparent" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Login">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsuario" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Teléfono">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTelefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cargo">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdCargo" runat="server" Visible="false" Text='<%# Bind("IdCargo") %>'></asp:Label>
                                            <asp:Label ID="lblCargo" runat="server" Visible="true" Text='<%# Bind("Cargo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sucursal">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdSucursal" runat="server" Visible="false" Text='<%# Bind("IdSucursal") %>'></asp:Label>
                                            <asp:Label ID="lblSucursal" runat="server" Visible="true" Text='<%# Bind("Sucursal") %>'></asp:Label>
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
            <asp:ModalPopupExtender ID="MdlAgregarUsuario" BackgroundCssClass="modalBackground" runat="server" PopupControlID="PnlAgregarUsuario" TargetControlID="Button1" BehaviorID="_MdlAgregarUsuario">
            </asp:ModalPopupExtender>
            <asp:Panel ID="PnlAgregarUsuario" runat="server" Style="display: none; background: white; width: 100%; height: auto">
                <%--MODALPOPUP CON BOOTSTRAP--%>
                <div class="modal">
                    <div class="modal-header">
                        <button class="close" data-dismiss="modal" aria-hidden="true">x</button>
                        <h3>Usuario</h3>
                    </div>
                    <div class="modal-body">

                        <div class="row">
                            <div class="span6">
                                <asp:HiddenField ID="hfIdUsuario" runat="server" />
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon1">Nombres</span>
                                    <asp:TextBox ID="TxtNombres" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon2">Login</span>
                                    <asp:TextBox ID="TxtUsuario" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon3">Clave</span>
                                    <asp:TextBox ID="TxtClave" TextMode="Password" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="span6">
                                <span class="input-group-addon" id="basic-addon4">Cargo</span>
                                <asp:DropDownList ID="DdlCargo" runat="server" CssClass="form-control input-sm" OnDataBound="DdlCargo_DataBound">
                                </asp:DropDownList>
                            </div>
                            <div class="span6">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon9">Teléfono</span>
                                    <asp:TextBox ID="TxtTelefono" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon5">Email</span>
                                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control input-sm"></asp:TextBox>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon6">Perfil</span>
                                    <asp:DropDownList ID="DdlPerfil" runat="server" CssClass="form-control input-sm" OnDataBound="DdlPerfil_DataBound">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon7">Sucursal</span>
                                    <asp:DropDownList ID="DdlSucursal" runat="server" CssClass="form-control input-sm" OnDataBound="DdlSucursal_DataBound">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="input-group">
                                    <span class="input-group-addon" id="basic-addon8">Activo</span>
                                    <asp:DropDownList ID="DdlActivo" runat="server" CssClass="form-control input-sm">
                                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>


                        </div>
                        <!-- /controls -->
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="BtnGrabarUsuario" OnClick="BtnGrabarUsuario_Click" Text="Guardar" CssClass="btn btn-success" runat="server" />
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
