<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="AgendaUsuarios.aspx.cs" Inherits="GetIntranet.AgendaUsuarios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- DataTables -->
    
    <link href="Assets/datatables/2/dataTables.bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <!-- Content Header (Page header) -->
            <section class="content-header">
                <ol class="breadcrumb">
                    <li><a href="#"><i class="icon-home"></i>Home</a></li>
                    /
                <li class="active">Agenda de Usuarios</li>
                </ol>
            </section>


            
            <div class="row">
                <div class="span12">
                    <div class="widget widget-nopad">
                        <div class="widget-header">
                            <i class=" icon-user"></i>
                            <h3>Agenda Usuarios</h3>
                            <div class="pull-right">
                                
                            </div>

                        </div>
                        <div class="widget-content">
                            <br />
                            <asp:GridView ID="grvUsuarios" runat="server" CssClass="table table-bordered table-condensed grillaDatatable" 
                                OnRowDataBound="grvUsuarios_RowDataBound" HeaderStyle-CssClass="alert-info" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" ClientIDMode="Static">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdUsuario" runat="server" Text='<%# Bind("IdUsuario") %>' Visible="true"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Login" Visible="false">
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
                                            
                                            <asp:HyperLink ID="hlTelefono" runat="server" Target="_blank" NavigateUrl='<%# "https://web.whatsapp.com/send?phone="+Eval("Telefono") %>' Text='<%# Eval("Telefono") %>' Font-Bold="true" ></asp:HyperLink>
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
