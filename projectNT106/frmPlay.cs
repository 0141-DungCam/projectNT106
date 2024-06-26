﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projectNT106
{
    public partial class frmPlay : Form
    {
        private System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
        private string username;
        private string IDphong;

        private List<string> DSUser = new List<string>();
        //List<string> là một danh sách các chuỗi (string)

        private frmLogin FrmLogin;


        private string msg;
        private int counter = 30;
        private int time = 0;

        public frmPlay()
        {
            InitializeComponent();
        }
        
        public frmPlay(frmLogin frmLogin)
        {
            this.FrmLogin = frmLogin;
            InitializeComponent();
        }
       
        public frmPlay(string name, string idPhong, string[]arrU)
        {
            InitializeComponent();
            for (int i = 0; i < arrU.Length; i++)
            {
                DSUser.Add(arrU[i]);
            }
            reloadForm();
        }
        public frmPlay(string name, string idPhong)
        {
            InitializeComponent();
          
            username = name;
            IDphong = idPhong;
            DSUser.Add(name);
        }
        public void getNameOtheruser(string name)
        {
            DSUser.Add(name);
            if(DSUser.Count != 0)
            {
                addUsserInForm(name);
            }
        }
        public void sendFormLG(frmLogin frm)
        {
            FrmLogin = frm;
        }

        private void addUsserInForm(string name)
        {
            Invoke(new Action(() =>
            {
                string lbname = "lbun";
                Label lb = (Label)this.Controls.Find(lbname + DSUser.Count, false).FirstOrDefault() as Label;
                if (name == username)
                    WriteTextSafe(lb, name + " (you)");
                else
                    WriteTextSafe(lb, name);
            }
            ));
        }
        public void ABC(string id)
        {
            this.IDphong = id;
            WriteTextSafe(lbID, IDphong);
        }
        public void ABC(string id,string name, string[]arrU)
        {
            this.IDphong = id;
            username = name;
            for (int i = 0; i < arrU.Length; i++)
            {
                DSUser.Add(arrU[i]);
            }           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void getUsername(string name, string idPhong)
        {
            string uname;
            uname = name;
            IDphong= idPhong;
            DSUser.Add(uname);
        }      

        //kkkk 
        private void frmPlay_Load(object sender, EventArgs e)
        {
            //Cập nhật ngay mã id phòng là IDphong
            Invoke(new Action(() =>
            {
                WriteTextSafe(lbID, IDphong);
            }));
            reloadForm();
        }
        private void reloadForm()
        {
            SetButtonEnabledSafe(btnXiNgau, false);//Khóa nút lắc xí ngầu
            for (int i = 0; i < DSUser.Count; i++)//Duyệt danh sách các user và gán tên + tìm kiếm user "chính mình" rồi gán (you)
            {
                string name = "lbun";
                Label lb = (Label)this.Controls.Find(name + (i + 1), false).FirstOrDefault() as Label;

                //có các lbun1 2 3 4 đc tạo sẵn nhưng .Text chưa có gì. Lệnh trên có tác dụng tạo 1 label mới và cho nó bằng với label đag xét
                //.FirstOrDefault() được gọi để trả về phần tử đầu tiên trong mảng hoặc null nếu không tìm thấy phần tử nào.
                //as Label được sử dụng để ép kiểu phần tử tìm thấy là một Label. Nếu không tìm thấy Label, giá trị của lb sẽ là null.
                if (DSUser[i] == username)
                    WriteTextSafe(lb, DSUser[i] + " (you)");
                else
                    WriteTextSafe(lb, DSUser[i]);
            }
        }

        public void getMSG(string Msg)  //tạo tin nhắn gữi đi
        {
            //luotchoitimer.Stop();
            //counter = 30;                  
            string[] Do = Msg.Split(':');//chia Msg thành một mảng các phần tử dựa trên ký tự ':'

            if (Do[0] == "2")
            {
                WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[2]); /////Error
                WriteTextSafe(lbWork, "Thảy xí ngầu");
                
                if(Do[1] == username)
                {
                    SetButtonEnabledSafe(btnXiNgau, true);// bỏ khóa nút thảy xí ngầu
                }
                for ( int i = 0; i < DSUser.Count; i++ )
                {
                    for( int m = 0; m < 4; m++ ) 
                    {
                        if (i == 0)
                        {
                            string nameCtrol = "b";
                            PictureBox ptb=(PictureBox)this.Controls.Find(nameCtrol + (m + 1),false).FirstOrDefault()as PictureBox;
                            ptb.Image= new Bitmap(Application.StartupPath + "/HinhNgua/" + "xanhduong" + ".png");
                        }
                        else if (i == 1)
                        {
                            string nameCtrol = "r";
                            PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                            ptb.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + "do" + ".png");
                        }
                        else if (i == 2)
                        {
                            string nameCtrol = "y";
                            PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                            ptb.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + "vang" + ".png");
                        }
                        else if (i == 3)
                        {
                            string nameCtrol = "g";
                            PictureBox ptb = (PictureBox)this.Controls.Find(nameCtrol + (m + 1), false).FirstOrDefault() as PictureBox;
                            ptb.Image = new Bitmap(Application.StartupPath + "/HinhNgua/" + "xanhla" + ".png");
                        }
                    }                    
                }
            }
            else if(Do[0] == "3")
            {               
                switch(Do[2])
                {
                    case "1":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "1" + ".jpg");
                        break;
                    case "2":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "2" + ".jpg");
                        break;
                    case "3":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "3" + ".jpg");
                        break;
                    case "4":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "4" + ".jpg");
                        break;
                    case "5":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "5" + ".jpg");
                        break;
                    case "6":
                        imgXiNgau.Image = new Bitmap(Application.StartupPath + "/HinhXiNgau/" + "6" + ".jpg");
                        break;
                }
                if(Do[3] == "y")
                {
                    WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[1]);
                    WriteTextSafe(lbWork, "Đánh cờ");
                }
                else
                {
                    WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[3]);
                    WriteTextSafe(lbWork, "Thảy xí ngầu");
                    if (username == Do[1])
                        SetButtonEnabledSafe(btnXiNgau, false);
                    if (username == Do[3])
                    {
                        SetButtonEnabledSafe(btnXiNgau, true);
                    }
                }
                if(Do[2] != "6" && Do[1] != "1")
                {
                  
                }    
            }
            else if(Do[0] == "5")
            {
                string msg = "";
                if (Do[1] == username)
                    msg = username + " (you): " + Do[2];
                else 
                    msg= Do[1]+": "+Do[2];
                        WriteTextSafe(richTextBox1, msg+"\n");
            }    
            else if(Do[0]=="4")
            {
              
               
                if (Do[2]!="")
                {
                    string s = "";
                   switch (Do[2])
                    {
                        case "b1":
                        case "b2":
                        case "b3":
                        case "b4":
                            s = "29";
                            break;
                        case "r1":
                        case "r2":
                        case "r3":
                        case "r4":
                            s = "43";
                            break;
                        case "y1":
                        case "y2":
                        case "y3":
                        case "y4":
                            s = "1";
                            break;
                        case "g1":
                        case "g2":
                        case "g3":
                        case "g4":
                            s = "15";
                            break;
                    }
                    PictureBox ptb = (PictureBox)this.Controls.Find(Do[2], false).FirstOrDefault() as PictureBox;
                    PictureBox btn = (PictureBox)this.Controls.Find("btn"+s, false).FirstOrDefault() as PictureBox;
                    btn.Image = ptb.Image;
                    ptb.Image = null;
                    WriteTextSafe(lbWork, "Thảy xí ngầu");
                }               
            }
            else if (Do[0] == "6")
            {
                if (Do[2] != "")
                {
                    if (Do[3] != "")
                    {
                        if (Do[2] == "dich")
                        {
                            string btnDich = "";
                            PictureBox btn = (PictureBox)this.Controls.Find("btn" + Do[4], false).FirstOrDefault() as PictureBox;
                            if (Do[3] == "b")
                            {
                                btnDich = "dichXD";
                            }
                            else if (Do[3] == "r")
                            {
                                btnDich = "dichD";
                            }
                            else if (Do[3] == "y")
                            {
                                btnDich = "dichV";
                            }
                            else if (Do[3] == "g")
                            {
                                btnDich = "dichXL";
                            }
                            PictureBox btnMau = (PictureBox)this.Controls.Find(btnDich + Do[5], false).FirstOrDefault() as PictureBox;
                            btnMau.Image = btn.Image;
                            btn.Image = null;
                        }
                        else if (Do[2] == "win")
                        {
                            string btnDich = "";
                            PictureBox btn = (PictureBox)this.Controls.Find("btn" + Do[4], false).FirstOrDefault() as PictureBox;
                            if (Do[3] == "b")
                            {
                                btnDich = "dichXD";
                            }
                            else if (Do[3] == "r")
                            {
                                btnDich = "dichD";
                            }
                            else if (Do[3] == "y")
                            {
                                btnDich = "dichV";
                            }
                            else if (Do[3] == "g")
                            {
                                btnDich = "dichXL";
                            }
                            PictureBox btnMau = (PictureBox)this.Controls.Find(btnDich + "4", false).FirstOrDefault() as PictureBox;
                            btnMau.Image = btn.Image;
                            btn.Image = null;
                            MessageBox.Show("Chúc mừng người chơi "+Do[5] + " thắng");
                        }
                        else
                        {
                            PictureBox ptb = (PictureBox)this.Controls.Find(Do[3], false).FirstOrDefault() as PictureBox;
                            PictureBox btn = (PictureBox)this.Controls.Find("btn" + Do[2], false).FirstOrDefault() as PictureBox;
                            PictureBox btnl = (PictureBox)this.Controls.Find("btn" + Do[4], false).FirstOrDefault() as PictureBox;
                            ptb.Image = btn.Image;
                            btn.Image = btnl.Image;
                            btnl.Image = null;
                        }
                    }
                    else
                    {                      
                        PictureBox btn = (PictureBox)this.Controls.Find("btn" + Do[2], false).FirstOrDefault() as PictureBox;
                        PictureBox btnl = (PictureBox)this.Controls.Find("btn" + Do[4], false).FirstOrDefault() as PictureBox;
                        btn.Image = btnl.Image;
                        btnl.Image= null;
                    }
                }
                if(Do[5] !="")
                {
                    if(Do[5]!="1"&& Do[5] != "2"&& Do[5] != "3"&& Do[5] != "4")
                    WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[5]);
                    else
                        WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[6]);
                    WriteTextSafe(lbWork, "Thảy xí ngầu");
                        
                    if (username == Do[5])
                    {
                        SetButtonEnabledSafe(btnXiNgau, true);
                    }
                    else
                    SetButtonEnabledSafe(btnXiNgau, false);
                }    
            }
        
            else if(Do[0]=="7")
            {
                WriteTextSafe(lbluotchoi, "Lượt chơi: " + Do[2]);
                WriteTextSafe(lbWork, "Thảy xí ngầu");

                if (username == Do[2])
                {
                    SetButtonEnabledSafe(btnXiNgau, true);
                }
                else
                    SetButtonEnabledSafe(btnXiNgau, false);
                //counter = 30;              
            }
            try {luotchoitimer.Start(); }
            catch(Exception ex) { Console.WriteLine(ex.Message); }            
        }


        private void SendBtnBox(int x)
        {
            PictureBox ptb = (PictureBox)this.Controls.Find("btn"+x, false).FirstOrDefault() as PictureBox;
            if (ptb.Image != null)// xét xem vị trí của ô có chứa con cờ cá ngựa hay ko
            FrmLogin.SendMSG("6", username, IDphong, x.ToString());
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            FrmLogin.SendMSG("2",username,IDphong,"");
        }

        private void btnXiNgau_Click(object sender, EventArgs e)
        {            
            FrmLogin.SendMSG("3", username, IDphong,"" );
        }

        private void lbluotchoi_Click(object sender, EventArgs e)
        {

        }
       
        private void aTimer_Tick(object sender, EventArgs e)
        {
            counter--;

            if (counter == 0)

                aTimer.Stop();            
        }

        /*private delegate void SafeCallDelegate(string text);*/

        private void UpdateChatHistoryThreadSafe(string text)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            FrmLogin.senDoFrom("5", username, IDphong, textBox1.Text);
        }
        private void SendQuanCo(string co)
        {

        }
        private int timUser()
        {
            for(int i = 0; i < DSUser.Count; i++)
            {
                if(DSUser[i] == username)
                    return i;
            }    
            return -1;
        }
        private void SendPTBox(string co)
        {
            PictureBox ptb = (PictureBox)this.Controls.Find(co, false).FirstOrDefault() as PictureBox;
           int numUser = timUser();
           
            switch (co)
            {
                case "b1":
                case "b2":
                case "b3":
                case "b4":
                    if(numUser==0)
                    {
                        if (ptb.Image != null)
                            FrmLogin.SendMSG("4", username, IDphong, co);
                    }
                    break;
                case "r1":
                case "r2":
                case "r3":
                case "r4":
                    if (numUser == 1)
                    {
                        if (ptb.Image != null)
                            FrmLogin.SendMSG("4", username, IDphong, co);
                    }
                    break;
                case "y1":
                case "y2":
                case "y3":
                case "y4":
                    if (numUser == 2)
                    {
                        if (ptb.Image != null)
                            FrmLogin.SendMSG("4", username, IDphong, co);
                    }
                    break;
                case "g1":
                case "g2":
                case "g3":
                case "g4":
                    if (numUser == 3)
                    {
                        if (ptb.Image != null)
                            FrmLogin.SendMSG("4", username, IDphong, co);
                    }
                    break;

            }    
        }
        private void btn_BoLuot_Click(object sender, EventArgs e)           
        {           
            FrmLogin.SendMSG("7", username, IDphong,"");
        }

        private void frmPlay_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();
        }

        /////////////////////////////////
        private void b1_Click(object sender, EventArgs e)
        {
            SendPTBox("b1");
        }
        private void b2_Click(object sender, EventArgs e)
        {
            SendPTBox("b2");
        }
        private void b3_Click(object sender, EventArgs e)
        {
            SendPTBox("b3");
        }
        private void b4_Click(object sender, EventArgs e)
        {
            SendPTBox("b4");
        }
        private void r1_Click(object sender, EventArgs e)
        {
            SendPTBox("r1");
        }
        private void r2_Click(object sender, EventArgs e)
        {
            SendPTBox("r2");
        }
        private void r3_Click(object sender, EventArgs e)
        {
            SendPTBox("r3");
        }
        private void r4_Click(object sender, EventArgs e)
        {
            SendPTBox("r4");
        }
        private void y1_Click(object sender, EventArgs e)
        {
            SendPTBox("y1");
        }
        private void y2_Click(object sender, EventArgs e)
        {
            SendPTBox("y2");
        }
        private void y3_Click(object sender, EventArgs e)
        {
            SendPTBox("y3");
        }
        private void y4_Click(object sender, EventArgs e)
        {
            SendPTBox("y4");
        }
        private void g1_Click(object sender, EventArgs e)
        {
            SendPTBox("g1");
        }
        private void g2_Click(object sender, EventArgs e)
        {
            SendPTBox("g2");
        }
        private void g3_Click(object sender, EventArgs e)
        {
            SendPTBox("g3");
        }
        private void g4_Click(object sender, EventArgs e)
        {
            SendPTBox("g4");
        }
    
        private void btn29_Click(object sender, EventArgs e)
        {
            SendBtnBox(29);
        }
        private void btn43_Click(object sender, EventArgs e)
        {
            SendBtnBox(43);
        }       
        private void btn15_Click(object sender, EventArgs e)
        {
            SendBtnBox(15);
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            SendBtnBox(1);
        }
        private void btn2_Click(object sender, EventArgs e)
        {
            SendBtnBox(2);
        }
        private void btn3_Click(object sender, EventArgs e)
        {
            SendBtnBox(3);
        }
        private void btn4_Click(object sender, EventArgs e)
        {
            SendBtnBox(4);
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            SendBtnBox(5);
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            SendBtnBox(6);
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            SendBtnBox(7);
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            SendBtnBox(8);
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            SendBtnBox(9);
        }
        private void btn10_Click(object sender, EventArgs e)
        {
            SendBtnBox(10);
        }
        private void btn11_Click(object sender, EventArgs e)
        {
            SendBtnBox(11);
        }
        private void btn12_Click(object sender, EventArgs e)
        {
            SendBtnBox(12);
        }
        private void btn13_Click(object sender, EventArgs e)
        {
            SendBtnBox(13);
        }
        private void btn14_Click(object sender, EventArgs e)
        {
            SendBtnBox(14);
        }
        private void btn16_Click(object sender, EventArgs e)
        {
            SendBtnBox(16);
        }
        private void btn17_Click(object sender, EventArgs e)
        {
            SendBtnBox(17);
        }
        private void btn18_Click(object sender, EventArgs e)
        {
            SendBtnBox(18);
        }
        private void btn19_Click(object sender, EventArgs e)
        {
            SendBtnBox(19);
        }
        private void btn20_Click(object sender, EventArgs e)
        {
            SendBtnBox(20);
        }
        private void btn21_Click(object sender, EventArgs e)
        {
            SendBtnBox(21);
        }
        private void btn22_Click(object sender, EventArgs e)
        {
            SendBtnBox(22);
        }
        private void btn23_Click(object sender, EventArgs e)
        {
            SendBtnBox(23);
        }
        private void btn24_Click(object sender, EventArgs e)
        {
            SendBtnBox(24);
        }
        private void btn25_Click(object sender, EventArgs e)
        {
            SendBtnBox(25);
        }
        private void btn26_Click(object sender, EventArgs e)
        {
            SendBtnBox(26);
        }
        private void btn27_Click(object sender, EventArgs e)
        {
            SendBtnBox(27);
        }
        private void btn28_Click(object sender, EventArgs e)
        {
            SendBtnBox(28);
        }
        private void btn30_Click(object sender, EventArgs e)
        {
            SendBtnBox(30);
        }
        private void btn31_Click(object sender, EventArgs e)
        {
            SendBtnBox(31);
        }
        private void btn32_Click(object sender, EventArgs e)
        {
            SendBtnBox(32);
        }
        private void btn33_Click(object sender, EventArgs e)
        {
            SendBtnBox(33);
        }
        private void btn34_Click(object sender, EventArgs e)
        {
            SendBtnBox(34);
        }
        private void btn35_Click(object sender, EventArgs e)
        {
            SendBtnBox(35);
        }
        private void btn36_Click(object sender, EventArgs e)
        {
            SendBtnBox(36);
        }
        private void btn37_Click(object sender, EventArgs e)
        {
            SendBtnBox(37);
        }
        private void btn38_Click(object sender, EventArgs e)
        {
            SendBtnBox(38);
        }
        private void btn39_Click(object sender, EventArgs e)
        {
            SendBtnBox(39);
        }
        private void btn40_Click(object sender, EventArgs e)
        {
            SendBtnBox(40);
        }
        private void btn41_Click(object sender, EventArgs e)
        {
            SendBtnBox(41);
        }
        private void btn42_Click(object sender, EventArgs e)
        {
            SendBtnBox(42);
        }
        private void btn44_Click(object sender, EventArgs e)
        {
            SendBtnBox(44);
        }
        private void btn45_Click(object sender, EventArgs e)
        {
            SendBtnBox(45);
        }
        private void btn46_Click(object sender, EventArgs e)
        {
            SendBtnBox(46);
        }
        private void btn47_Click(object sender, EventArgs e)
        {
            SendBtnBox(47);
        }
        private void btn48_Click(object sender, EventArgs e)
        {
            SendBtnBox(48);
        }
        private void btn49_Click(object sender, EventArgs e)
        {
            SendBtnBox(49);
        }
        private void btn50_Click(object sender, EventArgs e)
        {
            SendBtnBox(50);
        }
        private void btn51_Click(object sender, EventArgs e)
        {
            SendBtnBox(51);
        }
        private void btn52_Click(object sender, EventArgs e)
        {
            SendBtnBox(52);
        }
        private void btn53_Click(object sender, EventArgs e)
        {
            SendBtnBox(53);
        }
        private void btn54_Click(object sender, EventArgs e)
        {
            SendBtnBox(54);
        }
        private void btn55_Click(object sender, EventArgs e)
        {
            SendBtnBox(55);
        }
        private void btn56_Click(object sender, EventArgs e)
        {
            SendBtnBox(56);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void luotchoitimer_Tick(object sender, EventArgs e)
        {
            counter--;           
            if (counter == 0)
            {
                luotchoitimer.Stop();
                FrmLogin.SendMSG("7", username, IDphong, "");
            }
        }

        public delegate void SafeCallDelegate(Control control, string text);

        private void WriteTextSafe(Control control, string text)
        {
            if (control is Label lb)
            {
                if (lb.InvokeRequired)
                {
                    var d = new SafeCallDelegate(WriteTextSafe);
                    this.Invoke(d, new object[] { control, text });
                }
                else
                {
                    lb.Text = text;
                }
            }
            if (control is RichTextBox rtxtbox)
            {
                if (rtxtbox.InvokeRequired)
                {
                    var d = new SafeCallDelegate(WriteTextSafe);
                    this.Invoke(d, new object[] { control, text });
                }
                else
                {
                    rtxtbox.Text += text;
                }
            }
        }

        private delegate void SetButtonEnabledDelegate(Button button, bool status);

        private void SetButtonEnabledSafe(Button button, bool status)
        {
            if (button.InvokeRequired)
            {
                var d = new SetButtonEnabledDelegate(SetButtonEnabledSafe);
                this.Invoke(d, new object[] { button, status });
            }
            else
            {
                button.Enabled = status;
            }
        }

    }
}
