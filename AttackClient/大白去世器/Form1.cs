using System.Net;

namespace 大白去世器
{
    public partial class Form1 : Form
    {
        System.Timers.Timer GETSERVERIP = new System.Timers.Timer(60000);
        System.Timers.Timer ASA = new System.Timers.Timer(1);
        int a = 0;
        int time = 0;
        string assman = "";
        public Form1()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void GETSERVERIP_TIME(object sender,System.Timers.ElapsedEventArgs e)
        {
			//请求我个人接口
            string IPADDRESS;
            string sURL = "https://dabaiddos.draknightm.ml/GETIPADDRESS.aspx";
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
            textBox1.Text = IPADDRESS;
        }
        private void DDD_TIME(object sender,System.Timers.ElapsedEventArgs e)
        {
			//判断IP有没有发生变化代码
            string ip = textBox1.Text.Trim();
            if(ip!=assman)
            {
                assman = ip;
                if(textBox2.Text!=null)
                {
                    int time = 0;
                    time = Convert.ToInt32(textBox2.Text);
                    int wait = (time * 1000) - 1;
                    Thread.Sleep(wait);
					//此处往下为调用接口的代码，需要自行填写
                    //全局变量默认可以调用获取到的IP地址，此处代码纯自定义，配合对应API

                }
                else
                {
                    Thread.Sleep(180000);
					//此处往下为调用接口的代码，需要自行填写

                }
            }
            else
            {
				//检测到IP没有变化，自动执行暂停10秒重复检测
                Thread.Sleep(10000);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //这里需要手动添加一段调用API的代码，不然无法生效上面的操作，第一次是默认攻击，不存在等待时间（因为第一次开启直接比较的话会出现IP地址不变自动不攻击的情况）
            string mubiaoip = textBox1.Text.Trim();//直接使用这个变量

			if(a==0)
            {
                this.button1.Text = "关闭自动模式";
                a = 1;
                ASA.Enabled = true;
                ASA.Start();
            }
            else
            {
                this.button1.Text = "开启自动模式";
                a = 0;
                ASA.Enabled = false;
                ASA.Stop();
            }
        }

        [Obsolete]
        private void Form1_Load(object sender, EventArgs e)
        {
            GETSERVERIP.Elapsed += new System.Timers.ElapsedEventHandler(GETSERVERIP_TIME);
            GETSERVERIP.AutoReset = true;
            ASA.Elapsed += new System.Timers.ElapsedEventHandler(DDD_TIME);
            ASA.AutoReset = true;
            GETSERVERIP.Enabled = true;
            GETSERVERIP.Start();
        }
    }
}