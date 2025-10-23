using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Newtonsoft.Json;

namespace Supervisor
{
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
            LoadLogs();
        }

        private void LoadLogs()
        {
            dataGridView1.Columns.Add("Col0_No", "序号|No.");
            dataGridView1.Columns.Add("Col1_Time", "日期时间|Date&Time");
            dataGridView1.Columns.Add("Col2_Operator", "用户|User");
            dataGridView1.Columns.Add("Col3_Action", "操作内容|Action");

            dataGridView1.Columns[0].Width = 58;
            dataGridView1.Columns[1].Width = 168;
            dataGridView1.Columns[2].Width = 78;
            dataGridView1.Columns[3].Width = 900-58-168-78-18;


            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.CellPainting += DataGridView1_CellPainting;


            if (GlobalUser.Permission == 0 || GlobalUser.Permission == 1)
            {
                btn_ClearLog.Enabled = true;
            }
            else
            {
                btn_ClearLog.Enabled = false;
            }

            string sql = "SELECT id, logTime, userName, detail FROM Log ORDER BY logTime DESC"; // 获取所有日志按时间倒序排序
            DataSet ds = SQLiteHelper.ExecuteQuery(sql);

            DataTable dt = ds.Tables[0];

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dataGridView1.Columns[0].DataPropertyName = "id";
                dataGridView1.Columns[1].DataPropertyName = "logTime";
                dataGridView1.Columns[1].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"; // 设置日期时间格式
                dataGridView1.Columns[2].DataPropertyName = "userName";
                dataGridView1.Columns[3].DataPropertyName = "detail";
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            }
            else
            {
            }
        }

        private Point mPoint;
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }



        private void myCloseButton_Click(object sender, EventArgs e)
        {
            //LogHelper.WriteLog(GlobalUser.UserName, "退出系统", $"用户{GlobalUser.UserName}退出系统");
            this.Close();
        }

        private void myMinimizeButton_Click(object sender, EventArgs e)
        {

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 只处理 'detail' 列
            if (e.ColumnIndex == 3)  // 'detail' 列的索引是 3
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;  // 确保左对齐

            }
        }

        private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {

                using (Brush backBrush = new SolidBrush(Color.LightGray))
                {
                    e.Graphics.FillRectangle(backBrush, e.CellBounds);
                }

                e.PaintBackground(e.ClipBounds, false);
                
                string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                string chinese = "", english = "";
                if (!string.IsNullOrEmpty(headerText) && headerText.Contains("|"))
                {
                    string[] parts = headerText.Split('|');
                    chinese = parts[0];
                    english = parts[1];

                }

                using (Brush brush = new SolidBrush(e.CellStyle.ForeColor))
                {
                    System.Drawing.Rectangle rect1 = new System.Drawing.Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height / 2);
                    e.Graphics.DrawString(chinese, e.CellStyle.Font, brush, rect1, new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });

                    System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(e.CellBounds.X, e.CellBounds.Y + e.CellBounds.Height / 2, e.CellBounds.Width, e.CellBounds.Height / 2);
                    e.Graphics.DrawString(english, e.CellStyle.Font, brush, rect2, new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    });
                }

                e.Handled = true;
            }
        }

        private void btn_ClearLog_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MyMessageBox.Show("确定要清空所有日志吗", "Are you sure you want to delete?", MyMessageBoxType.Confirm);

            if (dialogResult == DialogResult.OK)
            {
                string sql = "DELETE FROM Log; update sqlite_sequence SET seq = 0 where name = 'Log'";
                int result = SQLiteHelper.ExecuteNonQuery(sql);
                if (result > 0)
                {
                    MyMessageBox.Show("删除成功", "Delete Successful", MyMessageBoxType.Info);
                    this.Close();
                    //LoadLogs();
                }
                else
                {
                    
                }
            } 
        }


        private void btn_ExportPDF_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtp_StartDate.Value.Date;
            DateTime endDate = dtp_EndDate.Value.Date;

            if (endDate < startDate)
            {
                MyMessageBox.Show("无效日期", "Invalid date", MyMessageBoxType.Info);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF文件|*.pdf", FileName = "Log.pdf" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    // 查询数据库
                    string sql = @"SELECT id, logTime, userName, detail 
                           FROM Log 
                           WHERE date(logTime) >= @startDate 
                             AND date(logTime) <= @endDate
                           ORDER BY logTime ASC";
                    var paramList = new List<System.Data.SQLite.SQLiteParameter>
            {
                new System.Data.SQLite.SQLiteParameter("@startDate", startDate.ToString("yyyy-MM-dd")),
                new System.Data.SQLite.SQLiteParameter("@endDate", endDate.ToString("yyyy-MM-dd"))
            };

                    DataSet ds = SQLiteHelper.ExecuteQuery(sql, paramList.ToArray());
                    if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    {
                        MyMessageBox.Show("无有效数据", "No Data", MyMessageBoxType.Info);
                        return;
                    }

                    DataTable dt = ds.Tables[0];

                    // 创建 PDF 文档
                    Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 80, 10); // 上边距加大，为页眉留出空间
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                    // 设置页眉事件
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "simhei.ttf");
                    BaseFont bfChinese = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontChinese = new iTextSharp.text.Font(bfChinese, 10);
                    iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bfChinese, 16, iTextSharp.text.Font.BOLD);


                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(bfChinese, 25, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontRight = new iTextSharp.text.Font(bfChinese, 10, iTextSharp.text.Font.NORMAL);
                    writer.PageEvent = new PdfHeader(fontTitle, fontRight);


                    doc.Open();

                    // 表格
                    PdfPTable table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    float[] widths = new float[] { 0.06f, 0.16f, 0.08f, 0.7f };
                    table.SetWidths(widths);

                    // 表头
                    string[] headers = { "序号|No.", "日期时间|Date&Time", "用户|User", "操作内容|Action" };
                    foreach (var header in headers)
                    {
                        string chinese = header, english = "";
                        if (header.Contains("|"))
                        {
                            var parts = header.Split('|');
                            chinese = parts[0];
                            english = parts[1];
                        }

                        PdfPCell cell = new PdfPCell(new Phrase(chinese + "\n" + english, fontChinese))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            BackgroundColor = new BaseColor(211, 211, 211),
                            Padding = 5
                        };
                        table.AddCell(cell);
                    }

                    // 数据行
                    int seq = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        table.AddCell(new PdfPCell(new Phrase(seq.ToString(), fontChinese)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(row["logTime"].ToString(), fontChinese)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(row["userName"].ToString(), fontChinese)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 5 });
                        table.AddCell(new PdfPCell(new Phrase(row["detail"].ToString(), fontChinese)) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5 });

                        seq++;
                    }

                    doc.Add(table);
                    doc.Close();

                    MyMessageBox.Show("导出成功", "Export Successful", MyMessageBoxType.Info);
                }
                catch (Exception ex)
                {
                    //MyMessageBox.Show("导出失败：" + ex.Message, "Export Failed", MyMessageBoxType.Error);
                }
            }
        }

        // 页眉事件类
        public class PdfHeader : PdfPageEventHelper
        {
            private iTextSharp.text.Font _fontTitle;
            private iTextSharp.text.Font _fontRight;
            private string _exportTime;

            public PdfHeader(iTextSharp.text.Font fontTitle, iTextSharp.text.Font fontRight)
            {
                _fontTitle = fontTitle;
                _fontRight = fontRight;
                _exportTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // 导出时间
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfContentByte cb = writer.DirectContent;
                float pageWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                float pageHeight = document.PageSize.Height - 30; // 顶部位置

                // 左侧标题
                float lineY = pageHeight - 40;
                ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT,
                    new Phrase("审计追踪记录 Audit Trail", _fontTitle),
                    document.LeftMargin, lineY+5, 0);

                // 右侧信息
                float rightX = document.PageSize.Width - document.RightMargin;
                ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT,
                    new Phrase(_exportTime, _fontRight),
                    rightX, pageHeight, 0);
                ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT,
                    new Phrase("温州万观科技有限公司", _fontRight),
                    rightX, pageHeight - 15, 0);
                ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT,
                    new Phrase("Wanguan Technology", _fontRight),
                    rightX, pageHeight - 30, 0);

                // 横线
                cb.MoveTo(document.LeftMargin, pageHeight - 40);
                cb.LineTo(document.PageSize.Width - document.RightMargin, pageHeight - 40);
                cb.Stroke();
            }
        }




    }
}
