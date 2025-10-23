using System;
using System.Drawing;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class myCloseButton : UserControl
    {
        // 初始背景设为浅灰色，鼠标悬浮时背景变红
        private Color defaultColor = Color.LightGray;
        private Color hoverColor = Color.Red;
        // 当前背景色
        private Color currentColor;
        // 状态标记
        private bool isHovered = false;
        private bool isPressed = false;

        public myCloseButton()
        {
            InitializeComponent();
            // 修改整体控件尺寸为 50×30
            this.Size = new Size(50, 30);
            currentColor = defaultColor;
            this.BackColor = defaultColor;

            // 绑定鼠标事件及绘制事件
            this.MouseEnter += myCloseButton_MouseEnter;
            this.MouseLeave += myCloseButton_MouseLeave;
            this.MouseDown += myCloseButton_MouseDown;
            this.MouseUp += myCloseButton_MouseUp;
            this.Paint += myCloseButton_Paint;
        }

        private void myCloseButton_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            if (!isPressed)
            {
                currentColor = hoverColor;
            }
            Invalidate();
        }

        private void myCloseButton_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            isPressed = false;
            currentColor = defaultColor;
            Invalidate();
        }

        private void myCloseButton_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            // 按下时保持红色背景
            currentColor = hoverColor;
            Invalidate();
        }

        private void myCloseButton_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            currentColor = isHovered ? hoverColor : defaultColor;
            Invalidate();
        }

        private void myCloseButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 绘制整个控件的背景
            using (SolidBrush brush = new SolidBrush(currentColor))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            // 如果处于按下状态，则在红色背景上绘制一层半透明的白色覆盖层（白雾效果）
            if (isPressed)
            {
                using (SolidBrush whiteOverlay = new SolidBrush(Color.FromArgb(100, Color.White)))
                {
                    g.FillRectangle(whiteOverlay, this.ClientRectangle);
                }
            }

            // 在中心构造一个 30×30 的正方形，用于绘制 X
            int squareSize = 30;
            int squareLeft = (this.Width - squareSize) / 2;
            int squareTop = (this.Height - squareSize) / 2;
            int margin = 10; // 在正方形内部的边距

            // X 的颜色：默认黑色，鼠标悬浮或按下时为白色
            Color xColor = (isHovered || isPressed) ? Color.White : Color.Black;
            using (Pen pen = new Pen(xColor, 2))
            {
                // 绘制从正方形内 margin 处到正方形内 (squareSize-margin) 处的两条交叉线
                g.DrawLine(pen, squareLeft + margin, squareTop + margin, squareLeft + squareSize - margin, squareTop + squareSize - margin);
                g.DrawLine(pen, squareLeft + squareSize - margin, squareTop + margin, squareLeft + margin, squareTop + squareSize - margin);
            }
        }
    }
}
