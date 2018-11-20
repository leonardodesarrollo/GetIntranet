using System.IO;
using System.Web;
using System.Web.Script.Serialization;

namespace GetIntranet
{
    /// <summary>
    /// Descripción breve de FroalaHandler
    /// </summary>
    public class FroalaHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var body = context.Request.Form["body"];
            var postId = context.Request.Form["postId"];
            if (!string.IsNullOrWhiteSpace(body) && !string.IsNullOrWhiteSpace(postId))
            {
                //todo: save changes
                context.Response.ContentType = "text/plain";
                context.Response.Write("");
                context.Response.End();
            }

            var files = context.Request.Files;
            if (files.Keys.Count > 0)
            {
                foreach (string fileKey in files)
                {
                    var file = context.Request.Files[fileKey];
                    if (file == null || file.ContentLength == 0)
                        continue;

                    //todo: 
                    var fileName = Path.GetFileName(file.FileName);
                    var rootPath = context.Server.MapPath("~/Noticias/Imagenes/");
                    file.SaveAs(Path.Combine(rootPath, fileName));
                    
                    var json = new JavaScriptSerializer().Serialize(new { link = "Noticias/Imagenes/" + fileName });
                    // 
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(json);
                    context.Response.End();
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write("");
            context.Response.End();
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}