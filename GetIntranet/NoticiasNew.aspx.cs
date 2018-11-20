using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;

namespace GetIntranet
{
    public partial class NoticiasNew : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string _IdNoticia = Convert.ToString(Request.QueryString["n"]);
                    if (_IdNoticia == null)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else if (_IdNoticia=="0")         
                    {
                        hfIdNoticia.Value = "0";
                    }
                    else
                    {
                        hfIdNoticia.Value = _IdNoticia;
                        BuscarNoticia(Convert.ToInt32(hfIdNoticia.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }
            
        }

        void BuscarNoticia(int idNoticia)
        {
            DataTable dt = new DataTable();
            dt = dal.GetBuscarNoticia(idNoticia).Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                TxtTitulo.Value = item["Titulo"].ToString();
                txtEditor.Text = item["Descripcion"].ToString();
            }
        }

        protected void BtnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdUsuario = Convert.ToInt32(Session["variableIdUsuario"]);
                string texto = txtEditor.Text;
                string titulo = TxtTitulo.Value;

                if (hfIdNoticia.Value=="0")
                {
                    dal.SetIngresarNoticia(null, titulo, null, texto, null, null, null, null, null, null, null, IdUsuario, IdUsuario, null, null);
                }
                else
                {
                    int IdNoticia = Convert.ToInt32(hfIdNoticia.Value);
                    dal.SetEditarNoticia(IdNoticia, null, titulo, null, texto, null, null, null, null, null, null, null, null, null, null, null);
                }


                lblInformacion.Text = "Noticia grabada correctamente.";
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