using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DAL;

namespace GetIntranet
{
    public partial class AgendaUsuarios : System.Web.UI.Page
    {
        Datos dal = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    HtmlGenericControl tabContact = Master.FindControl("LiAgendaUsuario") as HtmlGenericControl;
                    tabContact.Attributes.Add("class", "active");
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
            dt = dal.getBuscarUsuario(null, null, null, null).Tables[0];
            grvUsuarios.DataSource = dt;
            grvUsuarios.DataBind();
            grvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void grvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}