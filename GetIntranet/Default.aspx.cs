using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DAL;

namespace GetIntranet
{
    public partial class Default : System.Web.UI.Page
    {
        Datos dal = new Datos();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    HtmlGenericControl tabContact = Master.FindControl("LiDefault") as HtmlGenericControl;
                    tabContact.Attributes.Add("class", "active");

                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"https://www.mindicador.cl/api");
                    //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    //using (Stream stream = response.GetResponseStream())
                    //using (StreamReader reader = new StreamReader(stream))
                    //{
                    //    var json = reader.ReadToEnd();


                    //    //DataSet data = JsonConvert.DeserializeObject<DataSet>(json);
                    //    DataTable dt = Tabulate(json.ToString());
                    //}

                    string apiUrl = "https://www.mindicador.cl/api";
                    string jsonString = "{}";
                    WebClient http = new WebClient();
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    http.Headers.Add(HttpRequestHeader.Accept, "application/json");
                    jsonString = http.DownloadString(apiUrl);
                    var indicatorsObject = jss.Deserialize<Dictionary<string, object>>(jsonString);

                    Dictionary<string, Dictionary<string, string>> dailyIndicators = new Dictionary<string, Dictionary<string, string>>();

                    int i = 0;
                    foreach (var key in indicatorsObject.Keys.ToArray())
                    {
                        var item = indicatorsObject[key];

                        if (item.GetType().FullName.Contains("System.Collections.Generic.Dictionary"))
                        {
                            Dictionary<string, object> itemObject = (Dictionary<string, object>)item;
                            Dictionary<string, string> indicatorProp = new Dictionary<string, string>();

                            int j = 0;
                            foreach (var key2 in itemObject.Keys.ToArray())
                            {
                                indicatorProp.Add(key2, itemObject[key2].ToString());
                                j++;
                            }

                            dailyIndicators.Add(key, indicatorProp);
                        }
                        i++;
                    }

                    LblDolar.Text = dailyIndicators["dolar"]["valor"];
                    LblEuro.Text = dailyIndicators["euro"]["valor"];
                    LblUf.Text = dailyIndicators["uf"]["valor"];
                    LblUtm.Text = dailyIndicators["utm"]["valor"];


                    RptNoticias.DataSource = dal.GetBuscarNoticia(null);
                    RptNoticias.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblInformacion.Text = ex.Message;
                mdlInformacion.Show();
            }

        }

        public static DataTable Tabulate(string json)
        {
            var jsonLinq = JObject.Parse(json);

            // Find the first array using Linq
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            foreach (JObject row in srcArray.Children<JObject>())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);
                    }
                }

                trgArray.Add(cleanRow);
            }

            return JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        }
    }
}