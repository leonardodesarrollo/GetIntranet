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
    public partial class Usuarios : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Comun comun = new Comun();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    comun.FillCargo(DdlCargo);
                    comun.FillPerfil(DdlPerfil);
                    comun.FillSucursal(DdlSucursal);
                    Buscar();
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        void Buscar()
        {
            DataTable dt = new DataTable();
            dt = dal.getBuscarUsuario(null,null,null,null).Tables[0];
            grvUsuarios.DataSource = dt;
            grvUsuarios.DataBind();
        }


        protected void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();

                hfIdUsuario.Value = "0";

                MdlAgregarUsuario.Show();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;

                Label _lblIdUsuario = (Label)grvUsuarios.Rows[row.RowIndex].FindControl("lblIdUsuario");
                hfIdUsuario.Value = _lblIdUsuario.Text;

                DataTable dt = new DataTable();
                dt = dal.getBuscarUsuario(_lblIdUsuario.Text, null, null, null).Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    TxtClave.Attributes.Add("Value", item["Password"].ToString());
                    TxtEmail.Text = item["Email"].ToString();
                    TxtNombres.Text = item["Nombre"].ToString();
                    TxtUsuario.Text = item["Usuario"].ToString();
                    TxtTelefono.Text= item["Telefono"].ToString();

                    DdlActivo.SelectedValue= item["Activo"].ToString();
                    if (!string.IsNullOrEmpty(item["IdCargo"].ToString()))
                    {
                        DdlCargo.SelectedValue = item["IdCargo"].ToString();
                    }
                    if (!string.IsNullOrEmpty(item["IdPerfil"].ToString()))
                    {
                        DdlPerfil.SelectedValue = item["IdPerfil"].ToString();
                    }
                    if (!string.IsNullOrEmpty(item["IdSucursal"].ToString()))
                    {
                        DdlSucursal.SelectedValue = item["IdSucursal"].ToString();
                    }
                }

                MdlAgregarUsuario.Show();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                dal.SetDelUsuario(Convert.ToInt32(hfIdUsuario.Value));
                Buscar();

                lblInformacion.Text = "usuario eliminado";
                mdlInformacion.Show();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void grvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        void Limpiar()
        {
            hfIdUsuario.Value = string.Empty;
            TxtClave.Text = string.Empty;
            TxtUsuario.Text = string.Empty;
            TxtNombres.Text = string.Empty;
            TxtEmail.Text = string.Empty;
            TxtTelefono.Text = string.Empty;
            DdlActivo.ClearSelection();
            DdlPerfil.ClearSelection();
            DdlSucursal.ClearSelection();
            DdlCargo.ClearSelection();
        }

        protected void BtnGrabarUsuario_Click(object sender, EventArgs e)
        {
            try
            {

                string usuario = TxtUsuario.Text;
                int IdUsuario = Convert.ToInt32(hfIdUsuario.Value);
                int? IdCargo = 0;
                int? IdPerfil = 0;
                int? IdSucursal = 0;
                Comun com = new Comun();
                if (DdlCargo.SelectedValue!="0")
                {
                    IdCargo = Convert.ToInt32(DdlCargo.SelectedValue);
                }
                else
                {
                    IdCargo = null;
                }
                if (DdlPerfil.SelectedValue != "0" )
                {
                    IdPerfil = Convert.ToInt32(DdlPerfil.SelectedValue);
                }
                else
                {
                    IdPerfil = null;
                }
                if (DdlSucursal.SelectedValue != "0")
                {
                    IdSucursal = Convert.ToInt32(DdlSucursal.SelectedValue);
                }
                else
                {
                    IdSucursal = null;
                }

                DataTable dt = dal.getBuscarUsuario(IdUsuario.ToString(), null, null, null).Tables[0];
                if (dt.Rows.Count==0)
                {
                    DataTable dtUsuario = new DataTable();
                    dtUsuario = dal.getBuscarUsuario(null, null, null, null).Tables[0];
                    List<int> levels = dtUsuario.AsEnumerable().Select(al => al.Field<int>("IdUsuario")).Distinct().ToList();
                    int min = levels.Min();
                    int max = levels.Max();

                    IdUsuario = max + 1;

                    dal.SetInUsuario(IdUsuario, usuario,
                    TxtNombres.Text, TxtTelefono.Text, TxtEmail.Text, null, IdSucursal,
                    IdCargo, IdPerfil, TxtClave.Text,
                    Convert.ToInt32(DdlActivo.SelectedValue));
                }
                else
                {
                    dal.SetUpUsuario(IdUsuario, usuario,
                    TxtNombres.Text, TxtTelefono.Text, TxtEmail.Text, null, IdSucursal,
                    IdCargo, IdPerfil, TxtClave.Text,
                    Convert.ToInt32(DdlActivo.SelectedValue));
                }

                Buscar();
                lblInformacion.Text = "Usuario grabado";
                mdlInformacion.Show();
                
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void DdlSucursal_DataBound(object sender, EventArgs e)
        {
            DdlSucursal.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void DdlPerfil_DataBound(object sender, EventArgs e)
        {
            DdlPerfil.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }

        protected void DdlCargo_DataBound(object sender, EventArgs e)
        {
            DdlCargo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione", "0"));
        }
    }
}