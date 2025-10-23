using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor
{
    public enum MyMessageBoxType
    {
        Info,
        Confirm
    }
    public partial class MyMessageBox : Form
    {
        private MyMessageBoxType _type;

        public MyMessageBox(String message_cn,String message_en, MyMessageBoxType type)
        {
            InitializeComponent();
            label_Message_CN.Text = message_cn;
            label_Message_CN.TextAlign = ContentAlignment.MiddleCenter;
            label_Message_CN.Left = (panel2.ClientSize.Width - label_Message_CN.Width) / 2;

            label_Message_EN.Text = message_en;
            label_Message_EN.TextAlign = ContentAlignment.MiddleCenter;
            label_Message_EN.Left = (panel2.ClientSize.Width - label_Message_EN.Width) / 2;
            btn_OK.Left= (panel2.ClientSize.Width - btn_OK.Width) / 2;

            //label_Message.AutoSize = false;
            _type = type;

            
            btn_OK.Click += (s, e) =>
            {
                if (_type == MyMessageBoxType.Confirm)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
                this.Close();
            };

            myCloseButton.Click += (s, e) =>
            {
                if(_type == MyMessageBoxType.Confirm)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                }
                this.Close();
                  
            };
        }

        public static DialogResult Show(string message_cn,string message_en, MyMessageBoxType type)
        {
            using (var box = new MyMessageBox(message_cn,message_en, type))
            {
                return box.ShowDialog();
            }
        }

        private Point mPoint = new Point();

        private void MyMessageBox_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void MyMessageBox_MouseMove(object sender, MouseEventArgs e)
        {


            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        
    }
}
    