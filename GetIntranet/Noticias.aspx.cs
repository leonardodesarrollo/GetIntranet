using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace GetIntranet
{
    public partial class Noticias : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
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
            GrvNoticias.DataSource = dal.GetBuscarNoticia(null);
            GrvNoticias.DataBind();
        }

        protected void BtnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("NoticiasNew.aspx?n=0");
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void GrvNoticias_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbtn = sender as LinkButton;
                GridViewRow row = (GridViewRow)lbtn.NamingContainer;
                Label _LblId = (Label)GrvNoticias.Rows[row.RowIndex].FindControl("LblId");

                Response.Redirect("NoticiasNew.aspx?n="+ _LblId.Text);

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

            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }
    }
}