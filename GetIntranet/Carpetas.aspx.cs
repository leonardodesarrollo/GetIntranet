using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace GetIntranet
{
    public partial class Carpetas : System.Web.UI.Page
    {
        Datos dal = new Datos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    buscaNodo();
                    string idPerfil = Session["variableIdPerfil"].ToString();
                    DataTable dt = new DataTable();
                    if (idPerfil == "1")
                    {
                        dt = dal.getBuscarNodo().Tables[0];
                    }
                    else
                    {
                        dt = dal.getBuscarNodoPorPerfil(idPerfil).Tables[0];
                    }
                    CrearNodosDelPadre(0, null, tvwMenuCarga, idPerfil, dt);
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        public void CrearNodosDelPadre(int indicePadre, TreeNode nodePadre, TreeView tvw, string idPerfil, DataTable dt)
        {
            // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
            
            
            //ds = dal.getBuscarNodoPorUsuario(idUsuario);
            DataView dataViewHijos = new DataView(dt);
            dataViewHijos.RowFilter = dt.Columns["ID_SECCION_PADRE"].ColumnName + " = " + indicePadre;

            // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                int IdSeccion= Convert.ToInt32(dataRowCurrent["ID_SECCION"]);
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = dataRowCurrent["NOM_SECCION"].ToString().Trim();
                nuevoNodo.Value = IdSeccion.ToString();

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
                CrearNodosDelPadre(IdSeccion, nuevoNodo, tvw, idPerfil,dt);
            }
        }

        protected void tvwMenuCarga_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                string path = tvwMenuCarga.SelectedNode.ValuePath.Replace("/", " / ");
                hfIdSeccion.Value = tvwMenuCarga.SelectedNode.Value;
                hfIdSeccionPadre.Value = hfIdSeccion.Value;
                TreeNode node = this.tvwMenuCarga.SelectedNode;
                String pathStr = node.Text;
                string separator = "\\";

                tvwMenuCarga.PathSeparator = Convert.ToChar(separator);

                while (node.Parent != null)
                {
                    pathStr = node.Parent.Text + " " + this.tvwMenuCarga.PathSeparator + " " + pathStr;
                    node = node.Parent;
                }

                lblSeccion.Text = pathStr;
                lblSeccion2.Text = pathStr;
                
                DataTable dt = dal.getBuscarSeccionHijo(hfIdSeccion.Value).Tables[0];
                grvSeccion.DataSource = dt;
                grvSeccion.DataBind();


            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        public void buscaNodo()
        {
            try
            {
                ddlNodoPadre.Items.Clear();
                ddlNodoPadre.DataSource = dal.getBuscarSeccion(null);
                ddlNodoPadre.DataTextField = "NOM_SECCION";
                ddlNodoPadre.DataValueField = "ID_SECCION";
                ddlNodoPadre.DataBind();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void btnNuevaSeccion_Click(object sender, EventArgs e)
        {
            lblAgregarSeccion.Text = "Nueva Carpeta";
            btnModificar.Visible = false;
            btnAgregar.Visible = true;
            fsSeccionHijos.Visible = true;
            //ddlNodoPadre.Visible = true;
            lblSeccionPadre.Visible = true;
            lblNombreSeccion.Visible = false;
            lblIdSeccion.Visible = false;

            txtNombre.Text = string.Empty;

            buscaNodo();

            if (hfIdSeccion.Value == string.Empty)
            {
                lblInformacion.Text = "No se ha seleccionado ninguna carpeta";
                mdlInformacion.Show();
                return;
            }
            ddlNodoPadre.SelectedValue = hfIdSeccion.Value;

            mdlAgregarSeccion.Show();

        }


        protected void paginacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label _lblIdSeccion = (Label)e.Row.FindControl("lblIdSeccion");
                LinkButton _BtnEliminar = (LinkButton)e.Row.FindControl("BtnEliminar");
                Label _lblUsuario = (Label)e.Row.FindControl("lblUsuario");

                //PERFILES
                string usuario = Session["variableUsuario"].ToString();
                string perfil = Session["variableIdPerfil"].ToString();

               
                if (perfil == "2")
                {
                    if (usuario.ToUpper() == _lblUsuario.Text.ToUpper())
                    {
                        _BtnEliminar.Visible = true;
                    }
                    else
                    {
                        _BtnEliminar.Visible = false;
                    }
                }

                if (perfil == "3")
                {
                    _BtnEliminar.Visible = false;
                  
                }
                //FIN PERFILES
            }

            if (e.Row.RowType == DataControlRowType.Pager)
            {
                Label _lblPagina = (Label)e.Row.FindControl("lblPagina");
                Label _lblTotal = (Label)e.Row.FindControl("lblTotal");
                _lblPagina.Text = Convert.ToString(grvSeccion.PageIndex + 1);
                _lblTotal.Text = Convert.ToString(grvSeccion.PageCount);
            }
        }


        protected void imgEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //ddlNodoPadre.Visible = false;
                lblNombreSeccion.Visible = true;
                lblSeccionPadre.Visible = false;
                lblIdSeccion.Visible = true;
                btnAgregar.Visible = false;
                btnModificar.Visible = true;
                fsSeccionHijos.Visible = false;

                lblAgregarSeccion.Text = "Modificar Carpeta";
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;

                Label _lblIdSeccion = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblIdSeccion");
                Label _lblNombreSeccion = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblNombreSeccion");
                Label _lblIdObra = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblIdObra");
                Label _lblUbicacionGeografica = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblUbicacionGeografica");
                Label _lblIdCliente = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblIdCliente");

                lblNombreSeccion.Text = _lblIdSeccion.Text;
                hfIdSeccion.Value = _lblIdSeccion.Text;
                txtNombre.Text = _lblNombreSeccion.Text;


                //if (_lblIdCliente.Text != string.Empty)
                //{
                //    ddlCliente.SelectedValue = _lblIdCliente.Text;
                //}

                mdlAgregarSeccion.Show();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }

        }

        protected void imgEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;

                Label _lblIdSeccion = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblIdSeccion");

                dal.setEliminarSeccion(_lblIdSeccion.Text);
                //buscar();
                Response.Redirect("Carpetas.aspx");

            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }
        
        private void buscar()
        {
            try
            {

                grvSeccion.DataSource = dal.getBuscarSeccion(txtBuscar.Text);
                grvSeccion.DataBind();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }
        
        protected void imgFirst_Click(object sender, EventArgs e)
        {
            buscar();
            grvSeccion.PageIndex = 0;
            grvSeccion.DataBind();
        }

        protected void imgPrev_Click(object sender, EventArgs e)
        {
            buscar();
            if (grvSeccion.PageIndex != 0)
                grvSeccion.PageIndex--;
            grvSeccion.DataBind();
        }

        protected void imgNext_Click(object sender, EventArgs e)
        {
            buscar();
            if (grvSeccion.PageIndex != (grvSeccion.PageCount - 1))
                grvSeccion.PageIndex++;
            grvSeccion.DataBind();
        }

        protected void imgLast_Click(object sender, EventArgs e)
        {
            buscar();
            grvSeccion.PageIndex = grvSeccion.PageCount - 1;
            grvSeccion.DataBind();
        }


        protected void ddlNodoPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            buscarSeccionHijo(ddlNodoPadre.SelectedValue);
            mdlAgregarSeccion.Show();
        }

        private void buscarSeccionHijo(string idSeccionPadre)
        {
            try
            {
                grvNodoHijo.DataSource = dal.getBuscarSeccionHijo(idSeccionPadre);
                grvNodoHijo.DataBind();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        void BuscarSeccionHijoGrv(string idSeccionPadre)
        {
            grvSeccion.DataSource= dal.getBuscarSeccionHijo(idSeccionPadre);
            grvSeccion.DataBind();
        }

        protected void imgEliminarHijo_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;

                Label _lblIdSeccionHijo = (Label)grvNodoHijo.Rows[row.RowIndex].FindControl("lblIdSeccionHijo");

                dal.setEliminarSeccion(_lblIdSeccionHijo.Text);
                mdlAgregarSeccion.Show();
                buscar();
                buscaNodo();

                buscarSeccionHijo(ddlNodoPadre.SelectedValue);
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                dal.setModificarSeccion(lblNombreSeccion.Text, txtNombre.Text, null, ""/*ddlCliente.SelectedValue*/, null);
                BuscarSeccionHijoGrv(hfIdSeccionPadre.Value);
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //string valor = dal.getIngresarSeccion(txtNombre.Text, ddlNodoPadre.SelectedValue, null, ""/*ddlCliente.SelectedValue*/, null);
                string idUsuario = Session["variableIdUsuario"].ToString();
                string IdPerfil = Session["variableIdPerfil"].ToString();

                string valor = dal.getIngresarSeccion(txtNombre.Text, hfIdSeccion.Value, null, ""/*ddlCliente.SelectedValue*/, null, idUsuario);
                string id = dal.getBuscarMaxIdSeccion();

                if (valor == "1")
                {
                    lblInformacion.Text = "La Carpeta " + txtNombre.Text + " ya existe en la base de datos";
                    //imgAceptar.Visible = false;
                    mdlInformacion.Show();
                }
                else
                {
                    dal.setIngresarSeccionesPorPerfil(IdPerfil, id);
                    //buscar();
                    //buscarSeccionHijo(ddlNodoPadre.SelectedValue);
                    BuscarSeccionHijoGrv(hfIdSeccionPadre.Value);
                   
                    //Response.Redirect("Carpetas.aspx");
                    //lblInformacion.Text = "Se ingresó correctamente";
                    //imgAceptar.Visible = false;
                    //mdlInformacion.Show();

                }

            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }

        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        protected void imgAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //ddlNodoPadre.Visible = false;
                lblNombreSeccion.Visible = true;
                lblSeccionPadre.Visible = false;
                lblIdSeccion.Visible = true;
                btnAgregar.Visible = false;
                btnModificar.Visible = true;
                fsSeccionHijos.Visible = false;

                lblAgregarSeccion.Text = "Modificar Carpeta";

                LinkButton img = (LinkButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;

                Label _lblIdSeccion = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblIdSeccion");
                Label _lblNombreSeccion = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblNombreSeccion");
                Label _lblIdObra = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblIdObra");
                Label _lblUbicacionGeografica = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblUbicacionGeografica");
                Label _lblIdCliente = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblIdCliente");

                lblNombreSeccion.Text = _lblIdSeccion.Text;
                hfIdSeccion.Value = _lblIdSeccion.Text;
                txtNombre.Text = _lblNombreSeccion.Text;


                //if (_lblIdCliente.Text != string.Empty)
                //{
                //    ddlCliente.SelectedValue = _lblIdCliente.Text;
                //}

                mdlAgregarSeccion.Show();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton img = (LinkButton)sender;
                GridViewRow row = (GridViewRow)img.NamingContainer;

                Label _lblIdSeccion = (Label)grvSeccion.Rows[row.RowIndex].FindControl("lblIdSeccion");

                dal.setEliminarSeccion(_lblIdSeccion.Text);
                //buscar();
                //Response.Redirect("Carpetas.aspx");
                BuscarSeccionHijoGrv(hfIdSeccionPadre.Value);
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }
    }
}