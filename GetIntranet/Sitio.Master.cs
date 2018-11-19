using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GetIntranet
{
    public partial class Sitio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["variableIdUsuario"] == null)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        Perfiles();
                    }
                }
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
            }

        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Session["variableUsuario"] = null;
                Session["variablePerfil"] = null;
                Session["variableIdPerfil"] = null;
                Session["variableIdUsuario"] = null;
                Session["variableFechaSession"] = null;
                Session["variableNomUsuario"] = null;
                Session["variableIdSucursal"] = null;
                Session["variableEmail"] = null;

                Session.Clear();
                Session.Abandon();

                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
            }
        }
        void Perfiles()
        {
            string idPerfil = Session["variableIdPerfil"].ToString();
            //if (idPerfil == "1")
            //{
            //    lblEmpresa.Text = "Tagor";

            //    liFacturacion.Visible = true;
            //}

            //if (idPerfil == "2")
            //{
            //    liAdministracion.Visible = false;
            //    liUsuarios.Visible = false;
            //    liMantenciones.Visible = false;
            //    liReporteTickets.Visible = false;
            //    liIngresarOT.Visible = false;
            //    lblEmpresa.Text = Session["variableEmpresa"].ToString();
            //}

            //if (idPerfil == "3")
            //{
            //    liAdministracion.Visible = true;
            //    liUsuarios.Visible = false;

            //    liMantenciones.Visible = true;
            //    liFacturacion.Visible = true;
            //    liFacturacion.Visible = true;
            //    liGeneraFacturacion.Visible = true;
            //    lblEmpresa.Text = Session["variableEmpresa"].ToString();
            //}

            //if (idPerfil == "4")
            //{
            //    liAdministracion.Visible = false;
            //    liUsuarios.Visible = false;
            //    liReportes.Visible = false;
            //    liReporteTickets.Visible = false;
            //    liMantenciones.Visible = false;

            //    lblEmpresa.Text = Session["variableEmpresa"].ToString();
            //}

            //if (idPerfil == "5")
            //{
            //    liAdministracion.Visible = false;
            //    liUsuarios.Visible = false;
            //    liReporteTickets.Visible = true;
            //    liMantenciones.Visible = false;

            //    lblEmpresa.Text = Session["variableEmpresa"].ToString();
            //}

            //if (idPerfil == "6")
            //{
            //    liAdministracion.Visible = true;
            //    liUsuarios.Visible = false;
            //    liReporteTickets.Visible = true;
            //    liMantenciones.Visible = true;
            //    liFacturacion.Visible = true;
            //    liGeneraFacturacion.Visible = true;
            //    lblEmpresa.Text = Session["variableEmpresa"].ToString();
            //}

        }
    }
}