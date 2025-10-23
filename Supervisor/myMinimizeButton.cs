using System;
using System.Drawing;
using System.Windows.Forms;

namespace Supervisor
{
    public partial class myMinimizeButton : UserControl
    {
        // 背景颜色：默认为浅灰色，悬浮时变为稍深的灰色，按下时变为更深的灰色
        private Color defaultColor = Color.LightGray;
        private Color hoverColor = Color.FromArgb(190, 190, 190);
        private Color pressedColor = Color.FromArgb(160, 160, 160);
        private Color currentColor;

        private bool isHovered = false;
        private bool isPressed = false;

        public myMinimizeButton()
        {
            InitializeComponent();
            // 设置整体尺寸为 50×30
            this.Size = new Size(50, 30);
            currentColor = defaultColor;
            this.BackColor = defaultColor;

            // 绑定鼠标事件和绘制事件
            this.MouseEnter += myMinimizeButton_MouseEnter;
            this.MouseLeave += myMinimizeButton_MouseLeave;
            this.MouseDown += myMinimizeButton_MouseDown;
            this.MouseUp += myMinimizeButton_MouseUp;
            this.Paint += myMinimizeButton_Paint;
        }

        private void myMinimizeButton_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            if (!isPressed)
            {
                currentColor = hoverColor;
            }
            Invalidate();
        }

        private void myMinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;
            isPressed = false;
            currentColor = defaultColor;
            Invalidate();
        }

        private void myMinimizeButton_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            currentColor = pressedColor;
            Invalidate();
        }

        private void myMinimizeButton_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            currentColor = isHovered ? hoverColor : defaultColor;
            Invalidate();
        }

        private void myMinimizeButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 绘制整个控件的背景
            using (SolidBrush brush = new SolidBrush(currentColor))
            {
                g.FillRectangle(brush, this.ClientRectangle);
            }

            // 在控件中心构造一个 30×30 的区域作为图标区域
            int squareSize = 30;
            int squareLeft = (this.Width - squareSize) / 2;
            int squareTop = (this.Height - squareSize) / 2;

            // 绘制最小化符号：在该正方形内绘制一条水平线
            int margin = 10;
            int centerY = squareTop + squareSize / 2;
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawLine(pen, squareLeft + margin, centerY, squareLeft + squareSize - margin, centerY);
            }
        }
    }
}
