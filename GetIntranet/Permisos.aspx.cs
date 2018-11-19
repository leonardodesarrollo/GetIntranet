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
    public partial class Permisos : System.Web.UI.Page
    {
        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DataSet ds = new DataSet();
                    ds = dal.getBuscarNodo();

                    CrearNodosDelPadre(0, null, tvwMenuCarga, ds);
                    CrearNodosDelPadre(0, null, tvwUpload, ds);
                    tvwMenuCarga.Attributes.Add("onclick", "OnTreeClick(event)");
                    tvwUpload.Attributes.Add("onclick", "OnTreeClick(event)");
                    BuscarPerfil();
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        void BuscarPerfil()
        {
            GrvPerfiles.DataSource = dal.GetBuscarPerfil(null);
            GrvPerfiles.DataBind();
        }

        protected void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                UnCheckArbol(tvwMenuCarga.Nodes, false);
                UnCheckArbol(tvwUpload.Nodes, false);
                
                DataTable dt = new DataTable();
                
                foreach (GridViewRow grd_Row in GrvPerfiles.Rows)
                {
                    RadioButton chk = (RadioButton)GrvPerfiles.Rows[grd_Row.RowIndex].FindControl("rbtnSeleccionar");
                    Label _lblIdPerfil = (Label)GrvPerfiles.Rows[grd_Row.RowIndex].FindControl("lblIdPerfil");

                    if (chk.Checked == true)
                    {
                        dt = dal.GetBuscarSeccionPorPerfilPorSeccion(_lblIdPerfil.Text, null).Tables[0];
                        foreach (DataRow item in dt.Rows)
                        {
                            string nodo = item["ID_SECCION"].ToString();
                            CheckArbol(tvwMenuCarga.Nodes, true, nodo);
                        }

                        dt.Clear();
                        dt = dal.GetBuscarSeccionPorPerfilPorSeccionPermisoUpload(_lblIdPerfil.Text, null).Tables[0];
                        foreach (DataRow item in dt.Rows)
                        {
                            string nodo = item["ID_SECCION"].ToString();
                            CheckArbol(tvwUpload.Nodes, true, nodo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        private void CheckArbol(TreeNodeCollection trNodeCollection, bool isCheck, string idSeccion)
        {
            foreach (TreeNode trNode in trNodeCollection)
            {
                if (idSeccion == trNode.Value)
                {
                    trNode.Checked = isCheck;
                }

                if (trNode.ChildNodes.Count > 0)
                    CheckArbol(trNode.ChildNodes, isCheck, idSeccion);
            }
        }

        private void UnCheckArbol(TreeNodeCollection trNodeCollection, bool isCheck)
        {
            foreach (TreeNode trNode in trNodeCollection)
            {
                trNode.Checked = isCheck;
                if (trNode.ChildNodes.Count > 0)
                {
                    UnCheckArbol(trNode.ChildNodes, isCheck);
                }
            }
        }
        protected void tvwMenuCarga_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                //string path = tvwMenuCarga.SelectedNode.ValuePath.Replace("/", " / ");
                //string idSeccion = tvwMenuCarga.SelectedNode.Value;
                //DataTable dt = new DataTable();
                //dt = dal.getBuscarSeccionPorUsuarioOUsuarioPorSeccion(null, idSeccion).Tables[0];

                //if (dt.Rows.Count > 0)
                //{
                //    foreach (DataRow item in dt.Rows)
                //    {
                //        string idUsuario = item["ID_USUARIO"].ToString();
                //        foreach (GridViewRow grd_Row in grvUsuarios.Rows)
                //        {
                //            //CheckBox chk = (CheckBox)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("chkSeleccionar");
                //            RadioButton chk = (RadioButton)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("rbtnSeleccionar");

                //            Label _lblIdUsuario = (Label)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("lblIdUsuario");

                //            if (idUsuario == _lblIdUsuario.Text)
                //            {
                //                chk.Checked = true;
                //                break;
                //            }
                //            else
                //            {
                //                chk.Checked = true;
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    foreach (GridViewRow grd_Row in grvUsuarios.Rows)
                //    {
                //        //CheckBox chk = (CheckBox)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("chkSeleccionar");
                //        RadioButton chk = (RadioButton)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("rbtnSeleccionar");
                //        //Label _lblIdUsuario = (Label)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("lblIdUsuario");
                //        chk.Checked = false;
                //    }
                //}
















                //TreeNode node = this.tvwMenuCarga.SelectedNode;
                //String pathStr = node.Text;
                //string separator = "\\";

                //tvwMenuCarga.PathSeparator = Convert.ToChar(separator);

                //while (node.Parent != null)
                //{
                //    pathStr = node.Parent.Text + " " + this.tvwMenuCarga.PathSeparator + " " + pathStr;
                //    node = node.Parent;
                //}

                //lblSeccion.Text = pathStr;
                //lblSeccion.CssClass = "alert alert-success";
                //string idPerfil = Session["variablePerfil"].ToString();

                //grvSeccion.DataSource = dal.getBuscarSeccionHijo(hfIdSeccion.Value);
                //grvSeccion.DataBind();


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

        public void CrearNodosDelPadre(int indicePadre, TreeNode nodePadre, TreeView tvw, DataSet ds)
        {
            // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
            

            DataView dataViewHijos = new DataView(ds.Tables[0]);
            dataViewHijos.RowFilter = ds.Tables[0].Columns["ID_SECCION_PADRE"].ColumnName + " = " + indicePadre;

            // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
            foreach (DataRowView dataRowCurrent in dataViewHijos)
            {
                TreeNode nuevoNodo = new TreeNode();
                nuevoNodo.Text = dataRowCurrent["NOM_SECCION"].ToString().Trim();
                nuevoNodo.Value = dataRowCurrent["ID_SECCION"].ToString().Trim();
                //nuevoNodo.ShowCheckBox = true;
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
                CrearNodosDelPadre(Int32.Parse(dataRowCurrent["ID_SECCION"].ToString()), nuevoNodo, tvw, ds);
            }


        }

        //public void CrearNodosDelPadre(int indicePadre, TreeNode nodePadre, TreeView tvw, string idPerfil)
        //{
        //    // Crear un DataView con los Nodos que dependen del Nodo padre pasado como parámetro.
        //    DataTable dt = new DataTable();
        //    if (idPerfil == "1")
        //    {
        //        dt = dal.getBuscarNodo().Tables[0];
        //    }
        //    else
        //    {
        //        dt = dal.getBuscarNodoPorPerfil(idPerfil).Tables[0];
        //    }

        //    //ds = dal.getBuscarNodoPorUsuario(idUsuario);
        //    DataView dataViewHijos = new DataView(dt);
        //    dataViewHijos.RowFilter = dt.Columns["ID_SECCION_PADRE"].ColumnName + " = " + indicePadre;

        //    // Agregar al TreeView los nodos Hijos que se han obtenido en el DataView.
        //    foreach (DataRowView dataRowCurrent in dataViewHijos)
        //    {
        //        int IdSeccion = Convert.ToInt32(dataRowCurrent["ID_SECCION"]);
        //        TreeNode nuevoNodo = new TreeNode();
        //        nuevoNodo.Text = dataRowCurrent["NOM_SECCION"].ToString().Trim();
        //        nuevoNodo.Value = IdSeccion.ToString();

        //        //nuevoNodo.Value = dataRowCurrent["NOM_SECCION"].ToString().Trim();

        //        // si el parámetro nodoPadre es nulo es porque es la primera llamada, son los Nodos
        //        // del primer nivel que no dependen de otro nodo.
        //        if (nodePadre == null)
        //        {
        //            tvw.Nodes.Add(nuevoNodo);
        //        }
        //        // se añade el nuevo nodo al nodo padre.
        //        else
        //        {
        //            nodePadre.ChildNodes.Add(nuevoNodo);
        //            //nodePadre.Nodes.Add(nuevoNodo);
        //        }
        //        // Llamada recurrente al mismo método para agregar los Hijos del Nodo recién agregado.
        //        CrearNodosDelPadre(IdSeccion, nuevoNodo, tvw, idPerfil);
        //    }
        //}

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow grd_Row in GrvPerfiles.Rows)
                {
                    //CheckBox chk = (CheckBox)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("chkSeleccionar");
                    RadioButton chk = (RadioButton)GrvPerfiles.Rows[grd_Row.RowIndex].FindControl("rbtnSeleccionar");
                    Label _lblIdPerfil = (Label)GrvPerfiles.Rows[grd_Row.RowIndex].FindControl("lblIdPerfil");

                    if (chk.Checked == true)
                    {
                        dal.SetEliminarSeccionesPorPerfil(_lblIdPerfil.Text);
                        foreach (TreeNode tn in tvwMenuCarga.CheckedNodes)
                        {
                            // Implement Your Code Here.
                            dal.SetIngresarSeccionesPorPerfil(_lblIdPerfil.Text, tn.Value);
                        }
                        
                        foreach (TreeNode tn in tvwUpload.CheckedNodes)
                        {
                            // Implement Your Code Here.
                            dal.SetIngresarSeccionesPorPerfilPermisoUpload(_lblIdPerfil.Text, tn.Value);
                        }
                    }
                }

                //foreach (GridViewRow grd_Row in GrvPerfiles.Rows)
                //{
                //    //CheckBox chk = (CheckBox)grvUsuarios.Rows[grd_Row.RowIndex].FindControl("chkSeleccionar");
                //    RadioButton chk = (RadioButton)GrvPerfiles.Rows[grd_Row.RowIndex].FindControl("rbtnSeleccionar");
                //    Label _lblIdPerfil = (Label)GrvPerfiles.Rows[grd_Row.RowIndex].FindControl("lblIdPerfil");

                //    if (chk.Checked == true)
                //    {
                //        foreach (TreeNode tn in tvwMenuCarga.CheckedNodes)
                //        {
                //            // Implement Your Code Here.
                //            dal.SetIngresarSeccionesPorPerfil(_lblIdPerfil.Text, tn.Value);
                //        }
                //    }
                //}
                //DataSet ds = new DataSet();
                //ds = dal.getBuscarNodo();
                //tvwMenuCarga.Nodes.Clear();
                //tvwUpload.Nodes.Clear();
                //CrearNodosDelPadre(0, null, tvwMenuCarga, ds);
                //CrearNodosDelPadre(0, null, tvwUpload, ds);
                //tvwMenuCarga.Attributes.Add("onclick", "OnTreeClick(event)");
                //tvwUpload.Attributes.Add("onclick", "OnTreeClick(event)");

                lblInformacion.Text = "¡Se actualizó correctamente!";
                mdlInformacion.Show();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void tvwUpload_SelectedNodeChanged(object sender, EventArgs e)
        {

        }
    }
}