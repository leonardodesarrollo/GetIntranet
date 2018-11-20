<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" ValidateRequest="false"
    EnableEventValidation="false"
    AutoEventWireup="true"
    CodeBehind="NoticiasNew.aspx.cs" Inherits="GetIntranet.NoticiasNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ol class="breadcrumb">
        <li><a href="#"><i class="icon-home"></i>Home</a></li>
        /
            <li><a href="#">Admin</a></li>
        /
            <li class="active">Ingreso de Noticias</li>
    </ol>


    <div class="row">

        <div class="span12">
            <div class="widget widget-nopad">
                <div class="widget-header">
                    <i class=" icon-user"></i>
                    <h3>Noticia</h3>
                    <asp:HiddenField ID="hfIdNoticia" runat="server" />
                </div>
                <div class="widget-content">
                    <fieldset class="form-horizontal">
                        <br />
                        <div class="control-group">
                            <label class="control-label" for="username">Titulo</label>
                            <div class="controls">
                                <input type="text" class="span6" id="TxtTitulo" runat="server" value="Titulo">
                                <p class="help-block">El titulo de la Noticia</p>
                            </div>
                            <!-- /controls -->
                        </div>
                        <!-- /control-group -->
                        <div class="control-group">
                            <label class="control-label">Noticia</label>
                            <div class="controls">
                                <asp:TextBox ID="txtEditor" ClientIDMode="Static" runat="server" Height="199px" TextMode="MultiLine" CssClass="span6"></asp:TextBox>
                            </div>
                        </div>
                        <!-- /controls -->
                        <!-- /form-actions -->
                    </fieldset>
                    <div class="form-actions">
                        <asp:Button ID="BtnGrabar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="BtnGrabar_Click" />
                        <button class="btn">Cancel</button>
                    </div>
                </div>
                <!-- /control-group -->





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




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <!-- froala editor -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css">
    <link href="Content/froala_editor.css" rel="stylesheet" />
    <script src="Content/jquery-1.10.2.min.js"></script>
    <script src="Content/froala_editor.min.js"></script>
    <script src="Content/es_es.js"></script>

    <script type="text/javascript">
        $(function () {
            $('#txtEditor').editable({
                buttons: ["bold", "italic", "underline", "strikeThrough", "fontFamily",
                    "fontSize", "color", "formatBlock", "align", "insertOrderedList",
                    "insertUnorderedList", "outdent", "indent", "selectAll", "createLink",
                    "insertImage", "undo", "redo", "html", "inserthorizontalrule"],
                inlineMode: false,
                preloaderSrc: 'Content/img/preloader.gif',
                allowedImageTypes: ["jpeg", "jpg", "png"],
                height: 400,
                language: "es_es",
                fontList: ["Tahoma, Geneva", "Arial, Helvetica", "Impact, Charcoal"],
                autosave: true,
                autosaveInterval: 2500,
                saveURL: 'FroalaHandler.ashx',
                saveParams: { postId: "123" },
                spellcheck: true,
                plainPaste: true,
                imageButtons: ["removeImage", "replaceImage", "linkImage","floatImageLeft","floatImageNone","floatImageRight"],

                imageUploadURL: 'FroalaHandler.ashx',
                imageParams: { postId: "123" },
                enableScript: false
            });
        });
    </script>

    <%--        <script>
        $(function () {
            $.FroalaEditor.DefineIcon('imageInfo', { NAME: 'info' });
            $.FroalaEditor.RegisterCommand('imageInfo', {
                title: 'Info',
                language: 'es',
                focus: false,
                undo: false,
                refreshAfterCallback: false,
                callback: function () {
                    var $img = this.image.get();
                    alert($img.attr('src'));
                }
            });

            $('#txtEditor').froalaEditor({
                language: 'es',
                imageUploadURL: 'FroalaHandler.ashx',
                imageEditButtons: ['imageReplace', 'imageAlign', 'imageRemove', '|', 'imageLink', 'linkOpen', 'linkEdit', 'linkRemove', '-', 'imageDisplay', 'imageStyle', 'imageAlt', 'imageSize']
            })
        });
  </script>--%>




    <%--       <script>
    $(function() {
      $('#txtEditor').froalaEditor({
        // Set the image upload URL.
          imageEditButtons: ['imageDisplay', 'imageAlign', 'imageInfo', 'imageRemove'],
          imageButtons: ["removeImage", "replaceImage", "linkImage"],
        imageUploadURL: 'FroalaHandler.ashx',
        imageParams: { postId: "123" },
        imageUploadParams: {
          postId: '123'
        }
      })
    });
  </script>--%>
</asp:Content>
