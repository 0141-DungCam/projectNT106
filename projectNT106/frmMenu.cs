using System;
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
    public partial class frmMenu : Form
    {
        private string userName;
        private frmLogin FrmLogin;
        private frmPlay Frm1;
        
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            lbNameMN.Text = lbNameMN.Text+" "+ userName;
        }
        public void getAllUserinRoom()
        {
            Frm1 = new frmPlay(FrmLogin);
            Frm1.ABC(FrmLogin.sendIDtoForm(),userName,FrmLogin.sendAllnameOtheruser());
            Frm1.Show();
        }
        
       
        public string getUsername(string s)
        {
            userName = s;
            return userName;
        }
        public void getfmrlg(frmLogin frm)
        {
            FrmLogin = frm;
          
        }
        public void showFrmChoiaddphong()
       {
            Frm1 = new frmPlay(userName, FrmLogin.sendIDtoForm());
            Frm1.ABC(FrmLogin.sendIDtoForm());
            Frm1.Show();
            FrmLogin.sendFrmPlay(Frm1);
           
            Frm1.sendFormLG(FrmLogin);
        }
        private void btn_TaoPhong_Click(object sender, EventArgs e)
        {
            FrmLogin.SendMSG("0", userName, "","");

            showFrmChoiaddphong();
           
        }
       public void getNameuserother(string name)
        {
            Frm1.getNameOtheruser(name);
        }
        public void sendMSG(string msg)
        {
            Frm1.getMSG(msg);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Vao_Click(object sender, EventArgs e)
        {
            FrmLogin.SendMSG("1", userName, txbIDPhong.Text,"");
            getAllUserinRoom();

        }

        private void button3_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
