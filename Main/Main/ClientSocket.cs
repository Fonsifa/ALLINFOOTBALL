using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketDemo
{
    public partial class ClientSocket : Form
    {
        public ClientSocket()
        {
            InitializeComponent();
        }
        Socket socketSend;
        string ImageFile;
        private void bt_start_Click(object sender, EventArgs e)
        {
            try
            {
                //创建负责通讯的Socket
                //第一步创建一个开始监听的Socket
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //第二步创建Ip地址和端口号对象
                IPAddress ip = IPAddress.Parse(this.tb_IP.Text);
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(this.tb_Point.Text));
                socketSend.Connect(point);//通过ip 端口号定位一个要连接的服务器端

                Thread t = new Thread(Recive);
                t.IsBackground = true;
                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        //将接受到的内容显示出来
        private void AddContent(string content)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                rtb_log.AppendText(content + " ");
                rtb_log.AppendText("\r\n");
                rtb_log.Focus();//先获取焦点
                rtb_log.Select(rtb_log.TextLength, 0);//选中数据末尾0个字符
                rtb_log.ScrollToCaret();//将滚动条移动到当前位置
                                        //记录收到的字符个数
                                        //toolStripStatusLabel1.Text += (int.Parse(toolStripStatusLabel1.Text) + content.Length).ToString();
            }));
        }
        void Recive()
        {
            while (true)
            {
                try
                {
                    //客户端连接成功后，服务器接收客服端发送过来的数据

                    byte[] buffer = new byte[1024 * 1024 * 2];
                    //实际接收的有效字节
                    int r = socketSend.Receive(buffer);
                    if (r == 0)
                    {
                        break;
                    }
                    if (buffer[0] == 0)
                    {
                        string str = Encoding.UTF8.GetString(SocketHelper.Intanter.RemoveFbyte(buffer), 0, r - 1);
                        AddContent(str);
                    }
                    else if (buffer[0] == 1)
                    {
                        string ImageName = SocketHelper.Intanter.ShowImgByByte(SocketHelper.Intanter.RemoveFbyte(buffer));
                        AddCbItem(ImageName);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        //将接收的图片放到listview里面
        public void AddCbItem(string ItemName)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                ltb_Image.Items.Add(ItemName);
                SocketHelper.Intanter.IPItem.Add(ItemName);
            }));
        }
        private void bt_send_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = $"  " + this.tb_name.Text + " ：" + this.rtb_sendmsg.Text.Trim();
                socketSend.Send(SocketHelper.Intanter.SendMessageToClient(msg, SocketHelper.MessageType.news));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void bt_OpeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pt_Image.Image = Image.FromFile(fileDialog.FileName);
                ImageFile = fileDialog.FileName;
            }
        }
        private void bt_SendImage_Click(object sender, EventArgs e)
        {
            if (ImageFile != null && ImageFile != "")
            {

                socketSend.Send(SocketHelper.Intanter.SendMessageToClient(ImageFile, SocketHelper.MessageType.picture));
            }
            else
            {
                MessageBox.Show("未选择图片");
            }

        }

        private void ltb_Image_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ltb_Image.SelectedItem == null)
            {
                return;
            }
            string FileName = this.ltb_Image.SelectedItem.ToString();

            this.pt_Image.Image = Image.FromFile(Environment.CurrentDirectory + "\\Images\\" + FileName);// Image.FromFile(fileDialog.FileName);


        }
    }
}
