using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ipaddress = Request.Form["attack_ip"];
        if(ipaddress!=null)
        {
            File.Delete(@"~/config/save.txt");
            StreamWriter sw = File.AppendText(@"~/config/save.txt");
            sw.Write(ipaddress + Environment.NewLine);
            sw.Flush();
            sw.Close();
        }
        else
        {
            Thread.Sleep(60000);
        }
    }
}