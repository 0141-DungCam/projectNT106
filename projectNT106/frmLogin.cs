﻿using System;
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

namespace projectNT106
{
    public partial class frmLogin : Form
    {
        private TcpClient tcpClient;

        private frmLogin clientform;
        private string to;
        private StreamReader sReader;
        private StreamWriter sWriter;
        private Thread clientThread;
        private int serverPort = 8000;
        private bool stopTcpClient = true;

        public frmMenu FrmMenu;
        
        private string username;
        private string idPhong = "";
        private string[] arrU;
        private delegate void SafeUpdateIncomeMsg(string user, int iCase);

        private frmPlay FrmPlay;
       
        public frmLogin()
        {
            InitializeComponent();
            ButtonConfig();
        }

        private void frmLogin_Shown(Object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                stopTcpClient = false;
                this.tcpClient = new TcpClient();
                this.tcpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), serverPort));
                this.sWriter = new StreamWriter(tcpClient.GetStream());
                this.sWriter.AutoFlush = true;
                sWriter.WriteLine(Data.CurrentUser.Username);
                clientThread = new Thread(this.ClientRecv);
                clientThread.Start();
                username = Data.CurrentUser.Username;
                FrmMenu = new frmMenu();
                FrmMenu.getUsername(Data.CurrentUser.Username);
                FrmMenu.getfmrlg(this);
                FrmMenu.Show();
                this.Hide();              
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show(sockEx.Message, "Network error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void sendFrmPlay(frmPlay frm)
        {
            FrmPlay = frm;
        }
        private void UpdateChatHistoryThreadSafe(string text)
        {
            
        }
        public void SendMSG(string code, string username, string idphong,string MSG)
        {    
            try
            {
                string msg = code+"/"+username+"/"+idphong+"/"+MSG;
                sWriter.WriteLine(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void sendformlg()
        {
            
        }
        public void senDoFrom(string code, string username, string idphong, string MSG)
        {
            if (string.IsNullOrEmpty(MSG))
            {
                return;
            }
            SendMSG(code, username, idphong, MSG);
        }
        public string sendIDtoForm()
        {
            return idPhong;    
        }
        public string sendnameOtheruser(string name)
        {
            return name;
        }
        public string[] sendAllnameOtheruser()
        {
            return arrU;
        }
        private void check(string data)
        {
            string[]arr = data.Split('/');
            Console.WriteLine(data);

            if(arr[0]=="0")
            {
                if (arr[1] == username)
                {
                    idPhong=arr[2];
                   
                   //FrmMenu.showFrmChoiaddphong(arr[2]);
                }
            }   
            else if(arr[0]=="1")
            {
                arrU=arr[3].Split(':');
                if(arr[1]==username)
                {// FrmMenu.getAllUserinRoom(idPhong,arrU);
                    idPhong = arr[2];
                }
                else
                {
                    if(arr[2]==idPhong)
                    {
                        FrmMenu.getNameuserother(arr[1]);
                    }
                }
            }
            else if (arr[0] == "2")
            {
                  string msgToForm = "";
                 if (idPhong == arr[2])
                 {
                    msgToForm = "2" + ":"+ arr[1]+":"+arr[3];
                    FrmMenu.sendMSG(msgToForm);
                 }
            }
            else if (arr[0] == "3")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "3" + ":" + arr[1] + ":" + arr[3]+":"+arr[4];
                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "5")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "5" + ":" + arr[1] + ":" + arr[3] ;
                    
                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "4")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "4" + ":" + arr[1] + ":" + arr[3];

                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "6")
            {
                
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    
                    msgToForm = "6" + ":" + arr[1] + ":" + arr[3] ;
                   
                    FrmMenu.sendMSG(msgToForm);
                }
            }
            else if (arr[0] == "7")
            {
                string msgToForm = "";
                if (idPhong == arr[2])
                {
                    msgToForm = "7" + ":" + arr[1] + ":" + arr[3] ;
                    FrmMenu.sendMSG(msgToForm);
                }
            }
        }
        /*public void test(string s)
        {
            txbName.Text = s;
        }*/
        private void ClientRecv()
        {
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            try
            {
                while (!stopTcpClient)
                {
                    Application.DoEvents();
                    string data = sr.ReadLine();
                   
                    if (data == "")
                    {
                        continue;
                    }
                    check(data);                
                }              
            }
            catch (SocketException sockEx)
            {
                tcpClient.Close();
                sr.Close();

            }
        }
        private void Form1_Close(object sender, FormClosingEventArgs e)
        {

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Thread animationThread = new Thread(() => PlayButtonAnimation(btnReturn));
            animationThread.Start();
            animationThread.Join();
            /*DialogResult = DialogResult.OK;
            this.Close();*/
        }

        private void ButtonConfig()
        {
            /*CenterControl(button);*/
            btnReturn.BringToFront();
            SetControlImage(btnReturn, Animation.UI_Flat_Button_Small_Press_01a1);
            btnReturn.ForeColor = Color.Transparent;
            btnReturn.BackColor = Color.Transparent;
        }

        private void PlayButtonAnimation(Button button)
        {
            int delay = 70;
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a2);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a3);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a4);
            Thread.Sleep(delay);
            SetControlImage(button, Animation.UI_Flat_Button_Small_Press_01a1);
        }

        private void SetControlImage(Control control, Image image)
        {
            control.BackgroundImage = new Bitmap(image, control.Size);
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
 }

        

    

