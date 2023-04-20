﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Bai4_Client_DM : Form
    {
        private int destPort;
        private NetworkStream nwStream;
        private string senderInfo = "";
        private string recptInfo = "";
        public Bai4_Client_DM()
        {
            InitializeComponent();
        }
        public Bai4_Client_DM(string nameTag, int port, NetworkStream stream, string recpt)
        {
            InitializeComponent();
            destPort = port;
            nwStream = stream;
            senderInfo = nameTag;
            recptInfo = recpt;
            titleLabel0.Text = "You are chatting with " + recptInfo;
            Text = recptInfo;
        }


        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "") return;
            string msg = textBox.Text;
            string packet = destPort.ToString() + "<" + senderInfo + ": " + msg;
            byte[] buffer = Encoding.Unicode.GetBytes(packet);
            nwStream.Write(buffer,0,buffer.Length);
            textBox.Clear();
        }

        private void Bai4_Client_DM_Load(object sender, EventArgs e)
        {
            /*
                Bên đây cần một task con chạy ngầm để liên tục lắng nghe tin nhắn dm khi form được mở
                Load form lên là cho chạy task đó
             */
        }
    }
}
