<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Permisos.aspx.cs" Inherits="GetIntranet.Permisos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function RadioCheck(rb) {
            var gv = document.getElementById("<%=GrvPerfiles.ClientID%>");
            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;
            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "radio") {
                    if (rbs[i].checked && rbs[i] != rb) {
                        rbs[i].checked = false;
                        break;
                    }
                }
            }
        }


        function OnTreeClick(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            if (isChkBoxClick) {
                var parentTable = GetParentByTagName("table", src);
                var nxtSibling = parentTable.nextSibling;
                //check if nxt sibling is not null & is an element node
                if (nxtSibling && nxtSibling.nodeType == 1) {
                    //if node has children    
                    if (nxtSibling.tagName.toLowerCase() == "div") {
                        //check or uncheck children at all levels
                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
                    }
                }
                //check or uncheck parents at all levels
                CheckUncheckParents(src, src.checked);
            }
        }

        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input");
            var childChkBoxCount = childChkBoxes.length;
            for (var i = 0; i < childChkBoxCount; i++) {
                childChkBoxes[i].checked = check;
            }
        }

        function CheckUncheckParents(srcChild, check) {
            var parentDiv = GetParentByTagName("div", srcChild);
            var parentNodeTable = parentDiv.previousSibling;
            var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");

            if (parentNodeTable) {
                var checkUncheckSwitch;
                //checkbox checked 
                if (check) {
                    var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                    if (isAllSiblingsChecked)
                        checkUncheckSwitch = true;

                    else
                        parentNodeTable.checked = true;
                    //var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                    if (inpElemsInParentTable.length > 0) {
                        var parentNodeChkBox = inpElemsInParentTable[0];
                        parentNodeChkBox.checked = true;

                        //do the same recursively
                        CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                    }
                    return; //do not need to check parent if any(one or more) child not checked
                }
                else //checkbox unchecked
                {
                    checkUncheckSwitch = false;
                }

                //       var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                //       if(inpElemsInParentTable.length > 0)
                //       {
                //           var parentNodeChkBox = inpElemsInParentTable[0];
                //           //parentNodeChkBox.checked = checkUncheckSwitch;
                //           //do the same recursively
                //          CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                //      }

                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0];
                    //parentNodeChkBox.checked = checkUncheckSwitch;
                    parentNodeChkBox.checked = true;
                    //do the same recursively
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                }
            }
        }

        function AreAllSiblingsChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) {
                    //check if the child node is an element node
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        //if any of sibling nodes are not checked, return false
                        if (!prevChkBox.checked) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //utility function to get the container of an element by tagname
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                parent = parent.parentNode;
            }
            return parent;
        }


        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows
                        //row.style.backgroundColor = "aqua";
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked
                        //uncheck all checkboxes
                        //and change rowcolor back to original
                        if (row.rowIndex % 2 == 0) {
                            //Alternating Row Color
                            //row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>


    <ol class="breadcrumb">
        <li><a href="#">Inicio</a></li>
        <li><a href="#">Administración</a></li>
        <li class="active">Permisos</li>
    </ol>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">
                
                <div class="span2">
                    <div class="widget widget-table action-table">
                        <div class="widget-header">
                            <i class="icon-user"></i>
                            <h3>Perfiles</h3>
                        </div>
                        <div class="widget-content">
                            <asp:GridView ID="GrvPerfiles" runat="server" HeaderStyle-CssClass="active" CssClass="table table-bordered table-hover table-condensed small" AutoGenerateColumns="false" ClientIDMode="Static">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="3%">
                                    <%--                            <HeaderTemplate>
                                <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);"/>
                            </HeaderTemplate>--%>
                                    <ItemTemplate>
                                        <%--<asp:CheckBox ID="chkSeleccionar" Visible="false" runat="server" oncheckedchanged="chkSeleccionar_CheckedChanged" AutoPostBack="true"/>--%>
                                        <asp:RadioButton ID="rbtnSeleccionar" AutoPostBack="true" OnCheckedChanged="chkSeleccionar_CheckedChanged" runat="server" onclick="RadioCheck(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID Perfil">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdPerfil" runat="server" Text='<%# Bind("IdPerfil") %>' Visible="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Perfil">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPerfil" runat="server" Text='<%# Bind("Perfil") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        </div>
                        
                    </div>
                </div>
                <div class="span5">
                    <div class="widget widget-table action-table">
                        <div class="widget-header">
                            <i class="icon-folder-open"></i>
                            <h3>Carpetas - Permiso de Download</h3>
                        </div>
                        <div class="widget-content">
                            <asp:TreeView ID="tvwMenuCarga" ShowCheckBoxes="All" runat="server"
                                OnSelectedNodeChanged="tvwMenuCarga_SelectedNodeChanged"
                                Font-Size="Small" ExpandDepth="1">
                            </asp:TreeView>
                        </div>
                    </div>
                </div>
                <div class="span5">
                    <div class="widget widget-table action-table">
                        <div class="widget-header">
                            <i class="icon-folder-open"></i>
                            <h3>Carpetas - Permiso de Upload</h3>
                        </div>
                        <div class="widget-content">
                            <asp:TreeView ID="tvwUpload" ShowCheckBoxes="All" runat="server"
                                OnSelectedNodeChanged="tvwUpload_SelectedNodeChanged" 
                                Font-Size="Small" ExpandDepth="1">
                            </asp:TreeView>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="span6">
                </div>
                <div class="span6">
                    <br />
                    <asp:Button ID="btnAgregar" runat="server" Text="Guardar" CssClass="btn btn-danger btn-sm" OnClick="btnAgregar_Click" />
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
