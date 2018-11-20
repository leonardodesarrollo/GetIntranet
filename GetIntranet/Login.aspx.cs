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
    public partial class Login : System.Web.UI.Page
    {
        Datos dal = new Datos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    TxtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dal.getBuscarUsuario(null, TxtUsuario.Value, TxtPassword.Value,"1").Tables[0];
                if (dt.Rows.Count == 0)
                {
                    mdlInformacion.Show();
                    lblInformacion.Text = "Nombre de usuario y/o contraseña no valida.";
                    return;
                }
                else
                {
                    string idUsuario = "";
                    string nomUsuario = "";
                    string idPerfil = "";
                    string perfil = "";
                    string usuario = "";
                    string activo = string.Empty;
                    string idSucursal = string.Empty;
                    string email = string.Empty;

                    foreach (DataRow item in dt.Rows)
                    {
                        idUsuario = item["IdUsuario"].ToString();
                        usuario = item["Usuario"].ToString();
                        idPerfil = item["IdPerfil"].ToString();
                        perfil = item["Perfil"].ToString();
                        nomUsuario = item["Nombre"].ToString();
                        activo = item["Activo"].ToString();
                        idSucursal = item["IdSucursal"].ToString();
                        email = item["Email"].ToString();

                        Session["variableUsuario"] = usuario;
                        
                        Session["variablePerfil"] = perfil;
                        Session["variableIdPerfil"] = idPerfil;
                        Session["variableIdUsuario"] = idUsuario;
                        Session["variableFechaSession"] = DateTime.Now.ToString("G");
                        Session["variableNomUsuario"] = nomUsuario;
                        
                        Session["variableIdSucursal"] = idSucursal;
                        Session["variableEmail"] = email;

                        if (activo == "1")
                        {
                            Response.Redirect("NoticiasNew.aspx");
                        }
                        else
                        {
                            mdlInformacion.Show();
                            lblInformacion.Text = "El usuario no se encuentra activo. Favor comunicarse con el administrador.";
                            return;
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
    }
}