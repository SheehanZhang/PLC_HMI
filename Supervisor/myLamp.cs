using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class myLamp : UserControl
    {
        
        // 默认：灯处于“关闭”状态时的外观
        private Color centerColorOff = Color.Gainsboro;
        private Color edgeColorOff = Color.DarkGray;

        // 默认：灯处于“开启”状态时的外观
        private Color centerColorOn = Color.Yellow;
        private Color edgeColorOn = Color.Red;

        // 记录当前中心/边缘色（随 IsOn 改变）
        private Color centerColor;
        private Color edgeColor;

        private bool isOn; // 控制灯的开关

        [Browsable(true)]
        [Category("Appearance")]
        [Description("灯是否处于开启状态")]
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                if (isOn)
                {
                    CenterColor = centerColorOn;
                    EdgeColor = edgeColorOn;
                }
                else
                {
                    CenterColor = centerColorOff;
                    EdgeColor = edgeColorOff;
                }
                this.Invalidate(); // 重绘控件
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("灯中心颜色")]
        public Color CenterColor
        {
            get { return centerColor; }
            set
            {
                centerColor = value;
                this.Invalidate(); // 改完颜色后刷新控件
            }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("灯周围的颜色")]
        public Color EdgeColor
        {
            get { return edgeColor; }
            set
            {
                edgeColor = value;
                this.Invalidate(); // 改完颜色后刷新控件
            }
        }
        [Browsable(true)]
        [Category("Appearance")]
        [Description("灯处于关闭状态时的中心颜色")]
        public Color CenterColorOff
        {
            get { return centerColorOff; }
            set { centerColorOff = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("灯处于关闭状态时的周围颜色")]
        public Color EdgeColorOff
        {
            get { return edgeColorOff; }
            set { edgeColorOff = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("灯处于开启状态时的中心颜色")]
        public Color CenterColorOn
        {
            get { return centerColorOn; }
            set { centerColorOn = value; }
        }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("灯处于开启状态时的周围颜色")]
        public Color EdgeColorOn
        {
            get { return edgeColorOn; }
            set { edgeColorOn = value; }
        }


        public myLamp()
        {
            InitializeComponent();
            // 设置支持双缓冲等样式，减少闪烁
            this.SetStyle(ControlStyles.UserPaint
                        | ControlStyles.AllPaintingInWmPaint
                        | ControlStyles.OptimizedDoubleBuffer
                        | ControlStyles.ResizeRedraw, true);
            this.UpdateStyles();

            // 可以给个默认尺寸
            this.Size = new Size(60, 60);

            // 默认为关闭状态
            IsOn = false;

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // （1）让控件形状变成圆形
            using (GraphicsPath circlePath = new GraphicsPath())
            {
                circlePath.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new Region(circlePath);
            }

            // （2）填充椭圆的放射渐变（中心颜色 -> 四周颜色）
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(0, 0, this.Width, this.Height);
                using (PathGradientBrush pthGrBrush = new PathGradientBrush(path))
                {
                    pthGrBrush.CenterColor = this.CenterColor;
                    pthGrBrush.SurroundColors = new Color[] { this.EdgeColor };
                    e.Graphics.FillEllipse(pthGrBrush, 0, 0, this.Width, this.Height);
                }
            }
        }

        private void Lamp_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
