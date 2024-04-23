using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Server
{
    public partial class Form1 : Form
    {
        private Thread listenThread;
        private TcpListener tcpListener;
        private bool stopChatServer = true;
        private readonly int _serverPort = 8000;
        private Dictionary<string, TcpClient> dict = new Dictionary<string, TcpClient>();
        List<Phong> DSPhong=new List<Phong>();
        private IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
        private List<Phong> dsPhong=new List<Phong>();

        public Form1()
        {
            InitializeComponent();
           
        }
        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(new IPEndPoint(iPAddress, _serverPort));
                tcpListener.Start();

                while (!stopChatServer)
                {
                    //Application.DoEvents();
                    TcpClient _client = tcpListener.AcceptTcpClient();

                    StreamReader sr = new StreamReader(_client.GetStream());
                    StreamWriter sw = new StreamWriter(_client.GetStream());
                    sw.AutoFlush = true;
                    string username = sr.ReadLine();
                    if (username == null)
                    {
                        sw.WriteLine("Please pick a username");
                    }
                    else
                    {
                        if (!dict.ContainsKey(username))
                        {
                            Thread clientThread = new Thread(() => this.ClientRecv(username, _client));
                            dict.Add(username, _client);
                            clientThread.Start();
                        }
                        else
                        {
                            sw.WriteLine("Username already exist, pick another one");
                        }
                    }

                }
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            if (stopChatServer)
            
                stopChatServer = false;
                listenThread = new Thread(this.Listen);
                listenThread.Start();
        }
        
        private int AddPhong(string username)
        {
            Random r=new Random();
            int id = r.Next(1000, 9999);
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            string[] chuong =new string[16] ;
            for(int i = 0; i < 16;i++)
            {
                chuong[i] = "";
            }
            Phong phong= new Phong("",list);
            phong.Id=id.ToString();

            list.Add(username);
            phong.users = list;
            phong.luotThaiXN = "";
            phong.status = false;
            phong.luotDanhCo = "";
            phong.DsUserSS = list2;
            phong.DichXD = 0;
            phong.DichV = 0;
            phong.DichD = 0;
            phong.DichXL = 0;
            
            phong.QuanLyChuong = chuong;
            
            DSPhong.Add(phong);
            
           
            return id;
        }
        private  string getAllUserInRoom(Phong phong)
        {
            string s = "";
            foreach (string u in phong.users)
            {
               
                s = s + u + ":";
            }
            
            return s;
        }
        private string checkPhong(string id, string uname)
        {
            string s = "";
            foreach(Phong p in DSPhong)
            {
                if(p.Id==id)
                {
                    s = getAllUserInRoom(p);
                    p.users.Add(uname);
                    return p.Id+"/"+s+uname;
                }    
            }    
            return "";
        }
        private int findPhong(string id)
        {
            for(int i=0;i<DSPhong.Count;i++)
            {
                if (id == DSPhong[i].Id)
                    return i;
            }
            return -1;
        }
        private bool CheckSanSang(int i, string user)
        {
         
            if(DSPhong[i].users.Count>1)
            {
                return true;
            }
            return false;
        }
        private void setupBanco(int i)
        {
            for(int k=0;k<(DSPhong[i].users.Count*4);k++)
            {                              
                    if(k >= 0 && k <= 3)
                    {
                        DSPhong[i].QuanLyChuong[k] = "b" + (k+1);
                    }
                    else if(k >= 4 && k <= 7)
                    {
                        DSPhong[i].QuanLyChuong[k] = "r" + (k -3);
                    }
                    else if (k >= 8 && k <= 11)
                    {
                        DSPhong[i].QuanLyChuong[k] = "y" + (k - 7);
                    }
                    else if (k >= 12 && k <= 15)
                    {
                        DSPhong[i].QuanLyChuong[k] = "g" + (k - 11);
                    }                                  
            }
            string[] arr = new string[57];
            for(int k=1;k<57;k++)
            {
                arr[k] = "";
            }    
            DSPhong[i].QuanLyBanCo = arr;
            DSPhong[i].HanhDong = "lac";
             
        }
        private void DoiLuotChoi(int i, int numU)
        {
            DSPhong[i].HanhDong = "lac";

            if (numU < DSPhong[i].users.Count-1 )
            {
                DSPhong[i].luotThaiXN = DSPhong[i].users[numU + 1];
                
            }
            else
            {
                DSPhong[i].luotThaiXN = DSPhong[i].users[0];
            }
        }
        private bool ktNguaTrongChuong(int i,int u)
        {
            int dem = 4;
            for(int j=u+u*3;j<u+u*3+4;j++)
            {
                if (DSPhong[i].QuanLyChuong[j] == "")
                    dem--;
            }
            if (u == 0)
                dem += DSPhong[i].DichXD;
            if (u == 1)
                dem += DSPhong[i].DichD;
            if (u == 2)
                dem += DSPhong[i].DichV;
            if (u == 3)
                dem += DSPhong[i].DichXL;
            if (dem < 4)
                return true;
            return false;
        }
        private int timUserHT(int i, string name)
        {
            for (int j = 0; j < DSPhong[i].users.Count; j++)
                if (name == DSPhong[i].users[j])
                    return j;
            return -1;
        }
        private string kiemTraDuongDi(int x,int i,string uname)
        {
            int numU = timUserHT(i, uname);
            
            if(x==6||x==1)
            {
                DSPhong[i].HanhDong = "danh";
                DSPhong[i].luotDanhCo = uname;
                return "y";
            }
            else
            {
                if(ktNguaTrongChuong(i,numU))
                {
                    DSPhong[i].HanhDong = "danh";
                    DSPhong[i].luotDanhCo = uname;
                   
                    return "y";
                }
                else
                {
                   DoiLuotChoi(i, numU);
                    
                    return DSPhong[i].luotThaiXN;
                }

            }
            return "";
            /*if (x != 1 && x != 6)
            {
                if (uname == DSPhong[i].users[(DSPhong[i].users.Count - 1)])
                {
                    DSPhong[i].luotThaiXN = DSPhong[i].users[0];
                   
                }
                else
                DSPhong[i].luotThaiXN = DSPhong[i].users[DSPhong[i].users.BinarySearch(uname) + 1];

                
                if (DSPhong[i].users.BinarySearch(uname) == 0)
                    for (int j = 0; j < 4; j++)
                    {
                        if (DSPhong[i].QuanLyChuong[j] == "")
                        {
                            DSPhong[i].luotDanhCo = uname;
                            return "y";
                        }
                    }
               else if (DSPhong[i].users.BinarySearch(uname) == 1)
                    for (int j = 4; j < 8; j++)
                    {
                        if (DSPhong[i].QuanLyChuong[j] == "")
                        {
                            DSPhong[i].luotDanhCo = uname;
                            return "y";
                        }
                    }
                else if (DSPhong[i].users.BinarySearch(uname) == 2)
                    for (int j = 8; j < 12; j++)
                    {
                        if (DSPhong[i].QuanLyChuong[j] == "")
                        {
                            DSPhong[i].luotDanhCo = uname;
                            return "y";
                        }
                    }
               else if (DSPhong[i].users.BinarySearch(uname) == 3)
                    for (int j = 12; j < 16; j++)
                    {
                        if (DSPhong[i].QuanLyChuong[j] == "")
                        {
                            DSPhong[i].luotDanhCo =uname;
                            return "y";
                        }
                    }

                return DSPhong[i].luotThaiXN;

            }
            else
            {
                DSPhong[i].luotDanhCo = uname;
                return "y";
            }
            return "";*/
        }
        private int kiemTraChuong(string co,int i)
        {
            for(int j = 0; j <DSPhong[i].QuanLyChuong.Length; j++)
            {

                if (DSPhong[i].QuanLyChuong[j] == co)
                {
                   
                    return j;
                }                                 
            }           
            return -1;
        }
        private string KiemTraDanhCo(int i, string co)
        {          
            if(DSPhong[i].XiNgau==1|| DSPhong[i].XiNgau == 6)
            {               
                int k = kiemTraChuong(co, i);
                if (k!=-1)
                {
                    DSPhong[i].HanhDong = "lac";                   
                    if(k>=0&&k<4)
                    {                      
                        string s = DSPhong[i].QuanLyBanCo[29];
                        if (s.Length==0)
                        {
                            DSPhong[i].QuanLyBanCo[29] = co;
                            DSPhong[i].QuanLyChuong[k] = "";
                           
                           
                            return co;
                        }    
                    }
                    else if (k >= 4 && k < 8)
                    {
                        if (DSPhong[i].QuanLyBanCo[43].Length == 0)
                        {
                            DSPhong[i].QuanLyBanCo[43] = co;
                            DSPhong[i].QuanLyChuong[k] = "";
                            return co;
                        }
                    }
                    else if (k >= 8 && k < 12)
                    {
                        if (DSPhong[i].QuanLyBanCo[1].Length == 0)
                        {
                            DSPhong[i].QuanLyBanCo[1] = co;
                            DSPhong[i].QuanLyChuong[k] = "";
                            return co;
                        }
                    }
                    else if (k >= 12 && k < 16)
                    {
                        if (DSPhong[i].QuanLyBanCo[15].Length == 0)
                        {
                            DSPhong[i].QuanLyBanCo[15] = co;
                            DSPhong[i].QuanLyChuong[k] = "";
                            return co;
                        }
                    }
                }                       
            }
            else
            {

            }
            return "";
        }
        private string timMauU(int numU)
        {
            if (numU == 0)
                return "b";
            else if (numU == 1)
                return "r";
            else if (numU == 2)
                return "y";
            else if (numU == 3)
                return "g";
            return "";
        }
        private string kiemTraDuoi56(int i,int n,int x,string mauU)
        {
            for (int j = x + 1; j < n; j++)
            {
                if (DSPhong[i].QuanLyBanCo[j] != "")
                {
                    return "";
                }
            }
            if (DSPhong[i].QuanLyBanCo[x + DSPhong[i].XiNgau] != "")
            {
                for (int j = 1; j < 5; j++)
                {
                    if (mauU + j == DSPhong[i].QuanLyBanCo[x + DSPhong[i].XiNgau])
                        return "";
                }
                capNhatbanCo(i, (DSPhong[i].QuanLyBanCo[x + DSPhong[i].XiNgau]));
                string location = "";
                location = DSPhong[i].QuanLyBanCo[x + DSPhong[i].XiNgau];
                DSPhong[i].QuanLyBanCo[x + DSPhong[i].XiNgau] = DSPhong[i].QuanLyBanCo[x];
                DSPhong[i].QuanLyBanCo[x] = "";
                return (x + DSPhong[i].XiNgau) + ":" + location + ":" + x;
            }
            DSPhong[i].QuanLyBanCo[x + DSPhong[i].XiNgau] = DSPhong[i].QuanLyBanCo[x];
            DSPhong[i].QuanLyBanCo[x] = "";
            string s = (x + DSPhong[i].XiNgau) + ":" + "" + ":" + x;
           
            return s;
        }
        private int KiemTraVeDich(int i,int n, string mauU,int x)
        {
            int dich = 0;
            switch (mauU)
            {
                case "b":
                    if(x<=28&&n>28)
                    {
                        DSPhong[i].QuanLyBanCo[x] = "";
                        DSPhong[i].DichXD += 1;
                        dich = DSPhong[i].DichXD;
                        return dich;
                    }
                    break;
                case "r":
                    if (x<=42&&n > 42)
                    {
                        DSPhong[i].QuanLyBanCo[x] = "";
                        DSPhong[i].DichD += 1;
                        dich = DSPhong[i].DichD;
                        return dich;
                    }
                    break;
                case "y":
                    if (x<=56&&n > 56)
                    {
                        DSPhong[i].QuanLyBanCo[x] = "";
                        DSPhong[i].DichV += 1;
                        dich = DSPhong[i].DichV;
                        return dich;
                    }
                    break;
                case "g":
                    if (x<=14&&n > 14)
                    {
                        DSPhong[i].QuanLyBanCo[x] = "";
                        DSPhong[i].DichXL += 1;
                        dich = DSPhong[i].DichXL;
                        return dich;
                    }
                    break;
            }   
            return -1;
        }
        private string KiemTraDoanDuong(int i,int x,int numU)
        {           
            string mauU = timMauU(numU);
            int n = x + DSPhong[i].XiNgau;
            int kt = KiemTraVeDich(i, n, mauU, x);
            if (kt == -1)
            {
                if (n <= 56)
                {
                    return kiemTraDuoi56(i, n, x, mauU);
                }
                else
                {                  
                    for (int j = x + 1; j < 57; j++)
                    {
                        if (DSPhong[i].QuanLyBanCo[j] != "")
                        {
                            return "";
                        }
                    }
                    for (int j = 1; j < n - 56; j++)
                    {
                        if (DSPhong[i].QuanLyBanCo[j] != "")
                        {

                            return "";
                        }
                    }
                    if (DSPhong[i].QuanLyBanCo[n - 56] != "")
                    {
                        for (int j = 1; j < 5; j++)
                        {
                            if (mauU + j == DSPhong[i].QuanLyBanCo[n - 56])
                                return "";
                        }
                        capNhatbanCo(i, (DSPhong[i].QuanLyBanCo[n - 56]));
                        DSPhong[i].QuanLyBanCo[n - 56] = DSPhong[i].QuanLyBanCo[x];
                        DSPhong[i].QuanLyBanCo[x] = "";
                        return (n - 56) + ":" + DSPhong[i].QuanLyBanCo[n - 56] + ":" + x;
                    }
                    DSPhong[i].QuanLyBanCo[n - 56] = DSPhong[i].QuanLyBanCo[x];
                    DSPhong[i].QuanLyBanCo[x] = "";
                    string s = (n - 56) + ":" + "" + ":" + x;

                    return s;
                }
            }
            else if(kt == 4)
            {
                return "win" + ":" + mauU + ":" + x;
            }
            else
            {
                return "dich" + ":" + mauU + ":" + x+":"+kt;
            }
        }
        void capNhatbanCo(int i,string co)
        {
            
            switch (co)
            {
                case "b1":
                    DSPhong[i].QuanLyBanCo[0] = co;
                    break;
                case "b2":
                    DSPhong[i].QuanLyBanCo[1] = co;
                    break;
                case "b3":
                    DSPhong[2].QuanLyBanCo[2] = co;
                    break;
                case "b4":

                    DSPhong[i].QuanLyBanCo[3] = co;
                    break;
                case "r1":
                    DSPhong[i].QuanLyBanCo[4] = co;
                    break;
                case "r2":
                    DSPhong[i].QuanLyBanCo[5] = co;
                    break;
                case "r3":
                    DSPhong[i].QuanLyBanCo[6] = co;
                    break;
                case "r4":
                    DSPhong[i].QuanLyBanCo[7] = co;
                    break;
                case "y1":
                    DSPhong[i].QuanLyBanCo[8] = co;
                    break;
                case "y2":
                    DSPhong[i].QuanLyBanCo[9] = co;
                    break;
                case "y3":
                    DSPhong[i].QuanLyBanCo[10] = co;
                    break;
                case "y4":
                    DSPhong[i].QuanLyBanCo[11] = co;
                    break;
                case "g1":
                    DSPhong[i].QuanLyBanCo[12] = co;
                    break;
                case "g2":
                    DSPhong[i].QuanLyBanCo[13] = co;
                    break;
                case "g3":
                    DSPhong[i].QuanLyBanCo[14] = co;
                    break;
                case "g4":
                    DSPhong[i].QuanLyBanCo[15] = co;
                    break;                  
            }
        }
        private int kiemtraCo(int i,int x)
        {
            string s = DSPhong[i].QuanLyBanCo[x];
            switch (s)
            {
                case "b1":
                case "b2":
                case "b3":
                case "b4":
                    return 0;
                case "r1":
                case "r2":
                case "r3":
                case "r4":
                    return 1;
                case "y1":
                case "y2":
                case "y3":
                case "y4":
                    return 2;
                case "g1":
                case "g2":
                case "g3":
                case "g4":
                    return 3;
            }
            return -1;
        }
        private string DanhCo(int i, string x,string name)
        {
            int numU = timUserHT(i,name);
            int co = kiemtraCo(i, int.Parse(x));
            if (co != numU)
                return "";
            string s =  KiemTraDoanDuong(i, int.Parse(x), numU);
            if (s != "")
            {
                if (DSPhong[i].XiNgau != 1 && DSPhong[i].XiNgau != 6)
                {
                    DoiLuotChoi(i, numU);
                    s += ":" + DSPhong[i].luotThaiXN;
                }
                s += ":" + "";
            }
            return s;
        }
       
        private string Check(string msg)
        {
            string[]arr = msg.Split('/');
            string code = arr[0];
            string username = arr[1];
            string idPhong = arr[2];
            try
            {
                if (code == "0")
                {
                    WriteTextSafe(username + " tạo phòng\n");
                    return 0 + "/" + username + "/" + AddPhong(username).ToString();
                }
                else if (code == "1")
                {
                    string k = "";
                    k = checkPhong(idPhong, username);
                    if (k != "")
                    {
                        WriteTextSafe(username + " vào phòng "+idPhong+"\n");
                        return 1 + "/" + username + "/" + k;
                    }
                }
                else if (code == "2")
                {
                    int i = -1;
                    i = findPhong(idPhong);

                    if (CheckSanSang(i, username))
                    {
                        setupBanco(i);
                        DSPhong[i].status = true;
                        string name = DSPhong[i].users[0];
                        DSPhong[i].luotThaiXN = name;
                                    ;
                        return 2 + "/" + username + "/" + idPhong + "/" + name;
                    }
                }
                else if (code == "3")
                {
                   
                    
                    int i = -1;
                    i = findPhong(idPhong);
                    if (DSPhong[i].HanhDong == "lac")
                    {
                        if (DSPhong[i].luotThaiXN == username)
                        {
                            Random random = new Random();
                            int Num = random.Next(0, 7);
                            DSPhong[i].XiNgau = Num;
                           if(Num>0&&Num<7)
                            {
                                WriteTextSafe(username + " đỗ xí ngầu được " + Num + " điểm\n");
                            }    
                           else if(Num==0)
                            {
                                WriteTextSafe(username + " đỗ xí ngầu được " + 1 + " điểm\n");
                            }
                           else
                            WriteTextSafe(username + " đỗ xí ngầu được " + 6 + " điểm\n");
                            switch (Num)
                            {
                                case 0:
                                    DSPhong[i].XiNgau = 1;
                                    return 3 + "/" + username + "/" + idPhong + "/" + 1 + "/" + kiemTraDuongDi(1, i, username);

                                case 1:
                                    return 3 + "/" + username + "/" + idPhong + "/" + 1 + "/" + kiemTraDuongDi(1, i, username);
                                case 2:
                                    return 3 + "/" + username + "/" + idPhong + "/" + 2 + "/" + kiemTraDuongDi(2, i, username);
                                case 3:
                                    return 3 + "/" + username + "/" + idPhong + "/" + 3 + "/" + kiemTraDuongDi(3, i, username);
                                case 4:
                                    return 3 + "/" + username + "/" + idPhong + "/" + 4 + "/" + kiemTraDuongDi(4, i, username);
                                case 5:
                                    return 3 + "/" + username + "/" + idPhong + "/" + 5 + "/" + kiemTraDuongDi(5, i, username);
                                case 6:
                                    return 3 + "/" + username + "/" + idPhong + "/" + 6 + "/" + kiemTraDuongDi(6, i, username);
                                default:
                                    DSPhong[i].XiNgau = 6;
                                    return 3 + "/" + username + "/" + idPhong + "/" + 6 + "/" + kiemTraDuongDi(6, i, username);
                            }
                        }
                    }
                    else
                    {
                        return "";
                    }
                }

                else if (code == "4")
                {
                    int i = -1;
                    i = findPhong(idPhong);
                    if (DSPhong[i].HanhDong == "danh")
                    {
                        if (DSPhong[i].luotDanhCo == username)
                        {
                            WriteTextSafe(username + " đưa ngựa ra chuồng\n");
                            return 4 + "/" + username + "/" + idPhong + "/" + KiemTraDanhCo(i, arr[3]);

                        }
                    }

                }
                else if (code == "5")
                {
                    return 5 + "/" + username + "/" + idPhong + "/" + arr[3];
                }
                else if (code == "6")
                {
                    int i = -1;
                    i = findPhong(idPhong);

                    if (DSPhong[i].HanhDong == "danh")
                    {

                        if (DSPhong[i].luotDanhCo == username)
                        {
                            string s = DanhCo(i, arr[3], username);
                           
                            if (s != "")
                            {
                                DSPhong[i].HanhDong = "lac";
                                WriteTextSafe(username + " đánh cờ ở vị trí " + arr[3] + "\n");
                                return 6 + "/" + username + "/" + idPhong + "/" + s;
                            }
                            return "";

                        }
                    }
                    
                }
                else if (code == "7")
                {
                    int i = -1;
                    i = findPhong(idPhong);
                    int numU=timUserHT(i,username);
                  
                    if (DSPhong[i].HanhDong == "danh")
                    {
                        if (DSPhong[i].luotDanhCo == username)
                        {
                            DSPhong[i].HanhDong = "lac";
                            DoiLuotChoi(i, numU);
                            WriteTextSafe(username + " bỏ lượt chơi.\n");
                            return 7 + "/" + username + "/" + idPhong + "/" + DSPhong[i].luotThaiXN;

                        }
                    }
                    else
                    {
                        if (DSPhong[i].luotThaiXN == username)
                        {
                            DSPhong[i].HanhDong = "lac";
                            DoiLuotChoi(i, numU);
                            return 7 + "/" + username + "/" + idPhong + "/" + DSPhong[i].luotThaiXN;

                        }
                    }
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            return "";
        }
        public void ClientRecv(string username, TcpClient tcpClient)
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopChatServer)
                {
                    Application.DoEvents();
                    string msg = sr.ReadLine();
                    string Msg = Check(msg);
                   
                    foreach (TcpClient otherClient in dict.Values)
                    {
                        StreamWriter sw = new StreamWriter(otherClient.GetStream());
                        sw.WriteLine(Msg); 
                        sw.AutoFlush = true;

                    }
                }
            }
            catch (SocketException sockEx)
            {
                tcpClient.Close();
                sr.Close();
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopChatServer = true;

            tcpListener.Stop();
            listenThread = null;

            Application.Exit();
        }

        private delegate void SafeCallDelegate(string text);

        private void WriteTextSafe(string text)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                var d = new SafeCallDelegate(WriteTextSafe);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                richTextBox1.Text += text;
            }
        }
    }
}
