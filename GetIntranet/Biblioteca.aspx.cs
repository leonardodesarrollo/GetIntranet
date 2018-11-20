using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using DAL;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Configuration;
using AegisImplicitMail;
using System.Net.Mail;
using System.ComponentModel;

namespace GetIntranet
{
    public partial class Biblioteca : System.Web.UI.Page
    {
        Datos dal = new Datos();
        public string carpeta = "biblioteca/";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(Page);
                scriptManager.RegisterPostBackControl(btnGrabar);
                btnGrabar.Attributes.Add("OnClick", string.Format("this.disabled = true; {0};", ClientScript.GetPostBackEventReference(btnGrabar, null)));
                

                if (!this.Page.IsPostBack)
                {

                    HtmlGenericControl tabContact = Master.FindControl("LiBiblioteca") as HtmlGenericControl;
                    tabContact.Attributes.Add("class", "active");

                    string idPerfil = Session["variableIdPerfil"].ToString();
                    string idUsuario = Session["variableIdUsuario"].ToString();

                    DataSet ds = new DataSet();
                    if (idPerfil == "1")
                    {
                        ds = dal.getBuscarNodo();
                    }
                    else
                    {

                        ds = dal.getBuscarNodoPorPerfil(idPerfil);

                    }
                    Session["paginaActual"] = "Biblioteca.aspx";
                    
                    CrearNodosDelPadre(0, null, tvwMenuCarga, idPerfil, ds);
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void tvwMenuCarga_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                string idPerfil = Session["variableIdPerfil"].ToString();
                string path = tvwMenuCarga.SelectedNode.ValuePath.Replace("/", " / ");
                hfIdSeccion.Value = tvwMenuCarga.SelectedNode.Value;

                DataTable dt = dal.GetBuscarSeccionPorPerfilPorSeccion(idPerfil, hfIdSeccion.Value).Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    string permisoUpload=item["UPLOAD"].ToString();
                    if (permisoUpload=="1")
                    {
                        BtnNuevoArchivo.Visible = true;
                    }
                    else
                    {
                        BtnNuevoArchivo.Visible = false;
                    }
                }

                TreeNode node = this.tvwMenuCarga.SelectedNode;
                String pathStr = node.Text;
                int idNodo = Convert.ToInt32(hfIdSeccion.Value);
                //node.Text="<font color = green>" + node.Text + "</font>";
                string separator = "\\";

                tvwMenuCarga.PathSeparator = Convert.ToChar(separator);

                while (node.Parent != null)
                {
                    pathStr = node.Parent.Text + " " + this.tvwMenuCarga.PathSeparator + " " + pathStr;
                    node = node.Parent;
                }

                lblPath.Text = pathStr;

                buscar();

                //string idPerfil = Session["variablePerfil"].ToString();
                //if (idPerfil == "1")
                //{
                //    ltvFotografia.DataSource = dal.getBuscarFotografias("", hfIdSeccion.Value, idPerfil);
                //    ltvFotografia.DataBind();
                //}
                //else
                //{
                //    ltvFotografia.DataSource = dal.getBuscarFotografias("", hfIdSeccion.Value, null);
                //    ltvFotografia.DataBind();
                //}
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        public void CrearNodosDelPadre(int indicePadre, TreeNode nodePadre, TreeView tvw, string idPerfil, DataSet ds)
        {
            // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
            
            //ds = dal.getBuscarNodoPorUsuario(idUsuario);

            DataView dataViewHijos = new DataView(ds.Tables[0]);
            dataViewHijos.RowFilter = ds.Tables[0].Columns["ID_SECCION_PADRE"].ColumnName + " = " + indicePadre;

            // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = dataRowCurrent["NOM_SECCION"].ToString().Trim();
                nuevoNodo.Value = dataRowCurrent["ID_SECCION"].ToString().Trim();

                //nuevoNodo.Value = dataRowCurrent["NOM_SECCION"].ToString().Trim();

                // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
                // del primer nivel que no dependen de otro nodo.
                if (nodePadre == null)
                {
                    tvw.Nodes.Add(nuevoNodo);
                }
                // se añade el nuevo nodo al nodo padre.
                else
                {
                    nodePadre.ChildNodes.Add(nuevoNodo);
                    //nodePadre.Nodes.Add(nuevoNodo);
                }
                // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
                CrearNodosDelPadre(Int32.Parse(dataRowCurrent["ID_SECCION"].ToString()), nuevoNodo, tvw, idPerfil, ds);
            }
        }
        protected void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (hfIdSeccion.Value == string.Empty)
                {
                    lblInformacion.Text = "¡Favor seleccionar una carpeta del costado izquierdo!";
                    mdlInformacion.Show();

                    return;
                }

                //if (txtEmail.Text == string.Empty)
                //{
                //    lblInformacion.Text = "El campo 'Email Para' es obligatorio.";
                //    mdlInformacion.Show();

                //    return;
                //}
                if (fuArchivo.HasFile)
                {
                    string idUsuario = Session["variableIdUsuario"].ToString();
                    string filepath = Server.MapPath(carpeta + hfIdSeccion.Value + "_" + fuArchivo.FileName);
                    string usuario = Session["variableUsuario"].ToString();

                    if (System.IO.File.Exists(filepath))
                    {
                        lblInformacion.Text = "El archivo ya existe. Sube un archivo con diferente nombre";
                        mdlInformacion.Show();
                        return;
                    }

                    fuArchivo.SaveAs(filepath);

                    string nombreOriginal = "";

                    if (txtNombreArchivo.Text == string.Empty)
                    {
                        nombreOriginal = fuArchivo.FileName;
                    }
                    else
                    {
                        nombreOriginal = txtNombreArchivo.Text; ;
                    }

                    string nombreArchivo = hfIdSeccion.Value + "_" + fuArchivo.FileName;

                    string email = txtEmail.Text;
                    string emailCC = txtEmailCC.Text;
                    string idBiblioteca = dal.SetIngresarBiblioteca(idUsuario, hfIdSeccion.Value, nombreArchivo, "", "", "1", nombreOriginal, txtDescripcion.Text, email, emailCC);
                    string nombreUsuario = "";
                    string apellidoUsuario = "";

                    DataTable dt = new DataTable();
                    dt = dal.getBuscarUsuario(idUsuario, null, null, null).Tables[0];
                    
                    foreach (DataRow item in dt.Rows)
                    {
                        nombreUsuario = item["NOMBRE"].ToString();
                        //apellidoUsuario = item["APELLIDO"].ToString();
                    }

                    if (email != string.Empty)
                    {
                        string asunto = ConfigurationManager.AppSettings.Get("asuntoEmail");
                        //string mensaje = ConfigurationManager.AppSettings.Get("mensajeEmail");
                        string mensaje = "El presente correo, es una notificación de nuestro Sistema de Carpeta Virtual SCV-UpCom. <br><br>";

                        mensaje += "<b>Con fecha :</b> " + DateTime.Now.ToString("G") + "";
                        mensaje += "<br> <b>Se encuentra disponible el archivo en la carpeta :</b> " + lblPath.Text + "/" + fuArchivo.FileName;
                        mensaje += "<br> <b>Subido por:</b> " + nombreUsuario + " " + apellidoUsuario + "<br><br>";

                        mensaje += ConfigurationManager.AppSettings.Get("mensajeEmail");

                        mensaje += "<br><br><br> Atentamente,";
                        mensaje += "<br><br> <b>Tagor</b>";
                        mensaje += "<br> http://www.tagor.cl";

                        asunto = asunto + txtNombreArchivo.Text + " (" + fuArchivo.FileName + ")";
                        EnviarEmailSSLImplicito(email, asunto, mensaje, emailCC);
                    }

                    buscar();
                    limpiar(this.Controls);

                }
                else
                {
                    lblInformacion.Text = "Favor seleccionar un archivo";
                    mdlInformacion.Show();
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }




        void buscar()
        {
            grvDetalleBiblioteca.DataSource = dal.GetBuscarBibliotecaPorIdTipo(hfIdSeccion.Value);
            grvDetalleBiblioteca.DataBind();
        }

        protected void grvDetalleBiblioteca_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton _imgVisualizar = (ImageButton)e.Row.FindControl("imgVisualizar");
                Label _lblNombreArchivo = (Label)e.Row.FindControl("lblNombreArchivo");
                ImageButton _imgEliminar = (ImageButton)e.Row.FindControl("imgEliminar");
                Label _lblUsuario = (Label)e.Row.FindControl("lblUsuario");

                //PERFILES

                string idPerfil = Session["variableIdPerfil"].ToString();
                string usuario = Session["variableUsuario"].ToString();

                if (idPerfil != "1")
                {
                    _imgEliminar.Visible = false;
                    
                    if (usuario == _lblUsuario.Text)
                    {
                        _imgEliminar.Visible = true;
                    }
                    else
                    {
                        _imgEliminar.Visible = false;
                    }
                }

                
                //FIN PERFILES

                string nombreArchivo = _lblNombreArchivo.Text;
                string tipoArchivo = nombreArchivo;
                tipoArchivo = tipoArchivo.Substring(tipoArchivo.LastIndexOf(".") + 1).ToLower();

                FileInfo fi = new FileInfo(Server.MapPath(carpeta + _lblNombreArchivo.Text));
                string extension = fi.Extension.ToString().ToLower();

                NameValueCollection imageExtensions = new NameValueCollection();
                imageExtensions.Add(".jpg", "image/jpeg");
                imageExtensions.Add(".gif", "image/gif");
                imageExtensions.Add(".png", "image/png");
                imageExtensions.Add(".tiff", "image/tiff");
                imageExtensions.Add(".bmp", "image/bmp");

                if (imageExtensions.AllKeys.Contains(extension))
                {
                    _imgVisualizar.ImageUrl = carpeta + _lblNombreArchivo.Text;
                    _imgVisualizar.Height = 32;
                }
                else
                {
                    ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                    scriptManager.RegisterPostBackControl(_imgVisualizar);
                }

                if (tipoArchivo == "xls")
                {
                    _imgVisualizar.ImageUrl = "assets/img/file_extension_xls.png";
                }
                if (tipoArchivo == "xlsx")
                {
                    _imgVisualizar.ImageUrl = "assets/img/file_extension_xls.png";
                }
                if (tipoArchivo == "doc")
                {
                    _imgVisualizar.ImageUrl = "assets/img/file_extension_doc.png";
                }
                if (tipoArchivo == "docx")
                {
                    _imgVisualizar.ImageUrl = "assets/img/file_extension_doc.png";
                }
                if (tipoArchivo == "rar")
                {
                    _imgVisualizar.ImageUrl = "assets/img/file_extension_rar.png";
                }
                if (tipoArchivo == "zip")
                {
                    _imgVisualizar.ImageUrl = "assets/img/file_extension_zip.png";
                }
                if (tipoArchivo == "pdf")
                {
                    _imgVisualizar.ImageUrl = "assets/img/file_extension_pdf.png";
                }
                
            }
        }


        protected void imgVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;

                Label _lblId = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblId");
                Label _lblNombreArchivo = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblNombreArchivo");

                string url = Server.MapPath(carpeta + _lblNombreArchivo.Text);

                FileInfo fi = new FileInfo(url);
                string extension = fi.Extension.ToString().ToLower();

                NameValueCollection imageExtensions = new NameValueCollection();
                imageExtensions.Add(".jpg", "image/jpeg");
                imageExtensions.Add(".gif", "image/gif");
                imageExtensions.Add(".png", "image/png");
                imageExtensions.Add(".tiff", "image/tiff");
                imageExtensions.Add(".bmp", "image/bmp");

                if (imageExtensions.AllKeys.Contains(extension))
                {
                    //ViewState["mdlId"] = 1;
                    imgFoto.ImageUrl = carpeta + _lblNombreArchivo.Text;
                    
                    mdlImagen.Show();
                }
                else
                {
                    Response.ContentType = extension;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fi.Name);
                    Response.TransmitFile(fi.FullName);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                //ViewState["mdlId"] = 0;
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void imgCerrar_Click(object sender, EventArgs e)
        {
            switch (Convert.ToString(ViewState["mdlId"]))
            {
                case "0":
                    mdlInformacion.Hide();
                    break;
                case "1":
                    //mdlDetalleBiblioteca.Show();
                    break;
                case "2":
                    mdlImagen.Show();
                    break;
            }
        }

        protected void lbtnReenviarEmail_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lbtn.NamingContainer;

                Label _lblEmail = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblEmail");
                Label _lblNombre = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblNombre");
                Label _lblNombreArchivo = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblNombreArchivo");
                Label _lblFechaIngreso = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblFechaIngreso");
                Label _lblUsuario = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblUsuario");
                Label _lblEmailCC = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblEmailCC");

                //string idCliente = Session["idCliente"].ToString();

                //string asunto = ConfigurationManager.AppSettings.Get("asuntoEmail");
                ////string mensaje = ConfigurationManager.AppSettings.Get("mensajeEmail");
                //string mensaje = "El presente correo, es una notificación de nuestro Sistema de Carpeta Virtual. <br><br>";

                //mensaje += "<b>Con fecha :</b> " + _lblFechaIngreso.Text + "";
                //mensaje += "<br> <b>Se encuentra disponible el archivo en la carpeta :</b> " + _lblNombreArchivo.Text;
                //mensaje += "<br> <b>Subido por:</b> " + _lblUsuario.Text + "<br><br>";

                //mensaje += ConfigurationManager.AppSettings.Get("mensajeEmail");

                //mensaje += "<br><br><br> Atentamente,";
                //mensaje += "<br><br> <b>UpCom Business & Service Center</b>";
                //mensaje += "<br> San Diego 283 Stgo";
                //mensaje += "<br> Prat 725 p6 Valparaíso";
                //mensaje += "<br> Fono 56 (2)  28407324";
                //mensaje += "<br> http://www.UpCom.cl";

                //asunto = asunto + _lblNombre.Text + " (" + _lblNombreArchivo.Text + ")";

                //enviarEmail(_lblEmail.Text, asunto, mensaje, _lblEmailCC.Text);

                lblInformacion.Text = "¡Correo enviado!";
                mdlInformacion.Show();
            }
            catch (Exception ex)
            {
                //ViewState["mdlId"] = 0;
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        public void EnviarEmailSSLImplicito(string email, string body, string sub, string rutaAdjunto)
        {
            var from = "notificaciones@tagor.cl";
            var host = "mail.tagor.cl";
            var user = "notificaciones@tagor.cl";
            var pass = "notificaciones123**";

            //Generate Message 
            var mymessage = new MimeMailMessage();
            mymessage.From = new MimeMailAddress(from);

            String[] AMailto = email.Split(';');
            foreach (String mail in AMailto)
            {
                mymessage.To.Add(new MailAddress(mail));
            }

            mymessage.Subject = sub;
            mymessage.Body = body;
            mymessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mymessage.HeadersEncoding = System.Text.Encoding.UTF8;
            mymessage.IsBodyHtml = true;
            mymessage.Priority = MailPriority.High;

            if (rutaAdjunto != string.Empty)
            {
                MimeAttachment adj = new MimeAttachment(System.Web.HttpContext.Current.Server.MapPath(rutaAdjunto));
                mymessage.Attachments.Add(adj);
            }

            //Create Smtp Client
            var mailer = new MimeMailer(host, 465);
            mailer.User = user;
            mailer.Password = pass;
            mailer.SslType = SslMode.Ssl;
            mailer.AuthenticationMode = AuthenticationType.Base64;

            //Set a delegate function for call back
            mailer.SendCompleted += compEvent;
            mailer.SendMailAsync(mymessage);
        }

        //Call back function
        private void compEvent(object sender, AsyncCompletedEventArgs e)
        {
            if (e.UserState != null)
                Console.Out.WriteLine(e.UserState.ToString());

            Console.Out.WriteLine("is it canceled? " + e.Cancelled);

            if (e.Error != null)
                Console.Out.WriteLine("Error : " + e.Error.Message);
        }

        void limpiar(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox)
                    ((TextBox)control).Text = string.Empty;
                else if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control is RadioButtonList)
                    ((RadioButtonList)control).ClearSelection();
                else if (control is CheckBoxList)
                    ((CheckBoxList)control).ClearSelection();
                else if (control is RadioButton)
                    ((RadioButton)control).Checked = false;
                else if (control is CheckBox)
                    ((CheckBox)control).Checked = false;
                else if (control.HasControls())
                    //Esta linea detécta un Control que contenga otros Controles
                    //Así ningún control se quedará sin ser limpiado.
                    limpiar(control.Controls);
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton img = (LinkButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;
                //string idCliente = Session["idCliente"].ToString();
                Label _lblId = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblId");
                Label _lblNombreArchivo = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblNombreArchivo");
                Label _lblFechaIngreso = (Label)grvDetalleBiblioteca.Rows[row.RowIndex].FindControl("lblFechaIngreso");

                DateTime FechaSubida = Convert.ToDateTime(_lblFechaIngreso.Text);

                dal.SetIngresarLog("192.168.35.240", Session["variableIdUsuario"].ToString(), _lblId.Text, _lblNombreArchivo.Text, FechaSubida.ToShortDateString(), "");
                dal.SetEliminarArchivoBiblioteca(_lblId.Text);
                File.Delete(Server.MapPath(carpeta + _lblNombreArchivo.Text));

                //Session["paginaActual"] = "Default.aspx";
                //string idUsuario = Session["variableIdUsuario"].ToString();
                //CrearNodosDelPadre(0, null, tvwMenuCarga, idUsuario);
                buscar();
            }
            catch (Exception ex)
            {
                //ViewState["mdlId"] = 0;
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void BtnNuevoArchivo_Click(object sender, EventArgs e)
        {
            txtNombreArchivo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtEmailCC.Text = string.Empty;

            //inputFile.Value = "";
            TablaIngresoArchivo.Visible = true;
        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            TablaIngresoArchivo.Visible = false;
        }
    }
}