using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GETIPADDRESS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ipaddress = @"~/config/save.txt";
        string[] dkm1 = File.ReadAllLines(ipaddress);
        for(int i = 0; i < dkm1.Length; i++)
        {
            Response.Write(dkm1[i]);
        }
    }
}