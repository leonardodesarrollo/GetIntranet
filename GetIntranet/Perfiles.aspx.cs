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
    public partial class Perfiles : System.Web.UI.Page
    {
        Datos dal = new Datos();
        Comun comun = new Comun();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
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

        void Limpiar()
        {
            TxtIdPerfil.Text = string.Empty;
            TxtNombres.Text = string.Empty;
            hfIdPerfil.Value = string.Empty;
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                hfIdPerfil.Value = "0";
                MdlAgregar.Show();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void GrvPerfiles_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar();
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                
                Label _LblId = (Label)GrvPerfiles.Rows[row.RowIndex].FindControl("LblId");

                hfIdPerfil.Value = _LblId.Text;
                int? IdPerfil = Convert.ToInt32(hfIdPerfil.Value);
                DataTable dt = new DataTable();
                dt = dal.GetBuscarPerfil(IdPerfil).Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    hfIdPerfil.Value = item["IdPerfil"].ToString();
                    TxtIdPerfil.Text = hfIdPerfil.Value;
                    TxtNombres.Text= item["Perfil"].ToString();
                }

                MdlAgregar.Show();
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
                LinkButton btn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label _LblId = (Label)GrvPerfiles.Rows[row.RowIndex].FindControl("LblId");
                dal.SetEliminarPerfil(Convert.ToInt32(_LblId.Text));

                BuscarPerfil();

                lblInformacion.Text = "Perfil eliminado!";
                mdlInformacion.Show();
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                string perfil = TxtNombres.Text;
                int IdPerfil = Convert.ToInt32(hfIdPerfil.Value);
                
                DataTable dt = dal.GetBuscarPerfil(IdPerfil).Tables[0];
                if (dt.Rows.Count == 0)
                {
                    DataTable dtPerfil = new DataTable();
                    dtPerfil = dal.GetBuscarPerfil(null).Tables[0];
                    List<int> levels = dtPerfil.AsEnumerable().Select(al => al.Field<int>("IdPerfil")).Distinct().ToList();
                    int min = levels.Min();
                    int max = levels.Max();

                    IdPerfil = max + 1;
                    dal.SetIngresarPerfil(IdPerfil, perfil);
                }
                else
                {
                    dal.SetEditarPerfil(IdPerfil, perfil);
                }
                
                BuscarPerfil();
                lblInformacion.Text = "perfil grabado";
                mdlInformacion.Show();

            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }
    }
}