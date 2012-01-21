using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;

namespace Polendamus.Services
{
    public class Scrapping
    {
        public String GetHtml(String url)
        {
            WebClient myWebClient = new WebClient();
            // Recogemos el codigo html en el buffer.
            byte[] myDataBuffer = myWebClient.DownloadData(url);
            string download = Encoding.ASCII.GetString(myDataBuffer);

            //Devolvemos el html.
            return download;
        }
    }
}