using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 调色板
{
    public class 调色板 : Form
    {
        private PictureBox Color_Panel_Main;
        private Label Color_Show;
        private Label label48;
        private Label label49;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private TextBox E_Box;
        private TextBox S_Box;
        private TextBox L_Box;
        private TextBox B_Box;
        private TextBox G_Box;
        private TextBox R_Box;
        private PictureBox pictureBox2;

        public 调色板()
        {
            InitializeComponent();
            MainMouseFlag = false;
            var bm = new Bitmap(Color_Panel_Main.Width, Color_Panel_Main.Height);
            using(Graphics gr = Graphics.FromImage(bm))
            {
                float step = (float)Color_Panel_Main.Width / 255 / 6;
                int sum = 0;
                int count = 0;
                float r = 255, g = 0, b = 0;
                float width = step, height = Color_Panel_Main.Height / 128;
                for (int i = 0; i < 255 * 6; i++)
                {
                    switch (count)
                    {
                        case 0:
                            g = g + 1 > 255 ? 255 : g + 1;
                            break;
                        case 1:
                            r = r - 1 < 0 ? 0 : r - 1;
                            break;
                        case 2:
                            b = b + 1 > 255 ? 255 : b + 1;
                            break;
                        case 3:
                            g = g - 1 < 0 ? 0 : g - 1;
                            break;
                        case 4:
                            r = r + 1 > 255 ? 255 : r + 1;
                            break;
                        case 5:
                            b = b - 1 < 0 ? 0 : b - 1;
                            break;
                    }
                    sum++;
                    if (255 == sum)
                    {
                        sum = 0;
                        count++;
                    }
                    float stepr = (r - 128 == 0 ? 0 : r - 128) / Color_Panel_Main.Height;
                    float stepg = (g - 128 == 0 ? 0 : g - 128) / Color_Panel_Main.Height;
                    float stepb = (b - 128 == 0 ? 0 : b - 128) / Color_Panel_Main.Height;
                    int red = (int)r, green = (int)g, blue = (int)b;
                    for (int j = 0; j < Color_Panel_Main.Height; j++)
                    {
                        //Color color = Color.FromArgb(255, (int)(j * stepr) > 255 ? 255 : (int)(j * stepr), (int)(j * stepg) > 255 ? 255 : (int)(j * stepg), (int)(j * stepb) > 255 ? 255 : (int)(j * stepb));
                        red = (int)(r - j * stepr);
                        red = red < 0 ? 0 : red > 255 ? 255 : red;
                        green = (int)(g - j * stepg);
                        green = green < 0 ? 0 : green > 255 ? 255 : green;
                        blue = (int)(b - j * stepb);
                        blue = blue < 0 ? 0 : blue > 255 ? 255 : blue;
                        Color color = Color.FromArgb(255, red, green, blue);
                        //Color color = Color.FromArgb(255, (int)r, (int)g, (int)b);
                        gr.DrawLine(new Pen(color, 1), i * step, j * 1, (i + 1) * step, j * 1);
                    }
                }
                gr.Save();
            }
            Color_Panel_Main.Image = bm;
            R_Box.Text = "0";
            G_Box.Text = "0";
            B_Box.Text = "0";
        }

        private void InitializeComponent()
        {
            this.Color_Panel_Main = new System.Windows.Forms.PictureBox();
            this.Color_Show = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.E_Box = new System.Windows.Forms.TextBox();
            this.S_Box = new System.Windows.Forms.TextBox();
            this.L_Box = new System.Windows.Forms.TextBox();
            this.B_Box = new System.Windows.Forms.TextBox();
            this.G_Box = new System.Windows.Forms.TextBox();
            this.R_Box = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Color_Panel_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Color_Panel_Main
            // 
            this.Color_Panel_Main.Location = new System.Drawing.Point(30, 23);
            this.Color_Panel_Main.Name = "Color_Panel_Main";
            this.Color_Panel_Main.Size = new System.Drawing.Size(174, 153);
            this.Color_Panel_Main.TabIndex = 49;
            this.Color_Panel_Main.TabStop = false;
            this.Color_Panel_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Color_Panel_Main_MouseDown);
            this.Color_Panel_Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Color_Panel_Main_MouseMove);
            this.Color_Panel_Main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Color_Panel_Main_MouseUp);
            // 
            // Color_Show
            // 
            this.Color_Show.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Color_Show.Location = new System.Drawing.Point(28, 185);
            this.Color_Show.Name = "Color_Show";
            this.Color_Show.Size = new System.Drawing.Size(45, 36);
            this.Color_Show.TabIndex = 50;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(32, 230);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(58, 24);
            this.label48.TabIndex = 51;
            this.label48.Text = "颜色";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(94, 185);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(82, 24);
            this.label49.TabIndex = 52;
            this.label49.Text = "色调：";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(79, 209);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(106, 24);
            this.label50.TabIndex = 53;
            this.label50.Text = "饱和度：";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(91, 233);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(82, 24);
            this.label51.TabIndex = 54;
            this.label51.Text = "亮度：";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(183, 233);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(58, 24);
            this.label52.TabIndex = 57;
            this.label52.Text = "蓝：";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(183, 209);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(58, 24);
            this.label53.TabIndex = 56;
            this.label53.Text = "绿：";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(183, 185);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(58, 24);
            this.label54.TabIndex = 55;
            this.label54.Text = "红：";
            // 
            // E_Box
            // 
            this.E_Box.Location = new System.Drawing.Point(141, 182);
            this.E_Box.Name = "E_Box";
            this.E_Box.Size = new System.Drawing.Size(31, 35);
            this.E_Box.TabIndex = 58;
            // 
            // S_Box
            // 
            this.S_Box.Location = new System.Drawing.Point(141, 206);
            this.S_Box.Name = "S_Box";
            this.S_Box.Size = new System.Drawing.Size(31, 35);
            this.S_Box.TabIndex = 59;
            // 
            // L_Box
            // 
            this.L_Box.Location = new System.Drawing.Point(141, 230);
            this.L_Box.Name = "L_Box";
            this.L_Box.Size = new System.Drawing.Size(31, 35);
            this.L_Box.TabIndex = 60;
            // 
            // B_Box
            // 
            this.B_Box.Location = new System.Drawing.Point(218, 230);
            this.B_Box.Name = "B_Box";
            this.B_Box.Size = new System.Drawing.Size(34, 35);
            this.B_Box.TabIndex = 63;
            this.TextChanged += new EventHandler(this.G_Box_Change);
            // 
            // G_Box
            // 
            this.G_Box.Location = new System.Drawing.Point(218, 206);
            this.G_Box.Name = "G_Box";
            this.G_Box.Size = new System.Drawing.Size(34, 35);
            this.G_Box.TabIndex = 62;
            this.TextChanged += new EventHandler(this.G_Box_Change);
            // 
            // R_Box
            // 
            this.R_Box.Location = new System.Drawing.Point(218, 182);
            this.R_Box.Name = "R_Box";
            this.R_Box.Size = new System.Drawing.Size(34, 35);
            this.R_Box.TabIndex = 61;
            this.KeyPress += new KeyPressEventHandler(this.R_Box_Change);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(218, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 153);
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            // 
            // 调色板
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(307, 315);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.B_Box);
            this.Controls.Add(this.G_Box);
            this.Controls.Add(this.R_Box);
            this.Controls.Add(this.L_Box);
            this.Controls.Add(this.S_Box);
            this.Controls.Add(this.E_Box);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.Color_Show);
            this.Controls.Add(this.Color_Panel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "调色板";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑颜色";
            this.Click += new EventHandler(SetColor_OK_Form);
            ((System.ComponentModel.ISupportInitialize)(this.Color_Panel_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #region MainColor
        private Point p;
        private bool MainMouseFlag;

        private void Color_Panel_Main_MouseDown(object sender, MouseEventArgs e)
        {
            MainMouseFlag = true;
            Cursor = Cursors.Cross;
            p = e.Location;
            GetColor();
        }
        private void Color_Panel_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (MainMouseFlag)
            {
                GetColor();
                p = e.Location;
            }
        }
        private void Color_Panel_Main_MouseUp(object sender, MouseEventArgs e)
        {
            MainMouseFlag = false;
            Cursor = Cursors.Default;
        }

        private void SetColor_OK_Form(object sender, EventArgs e)
        {
            if ("" == R_Box.Text)
                R_Box.Text = "0";
            if ("" == G_Box.Text)
                G_Box.Text = "0";
            if ("" == B_Box.Text)
                B_Box.Text = "0";
            SetColor_Show();
        }

        private void R_Box_Change(object sender, KeyPressEventArgs e)
        {
            if ('\n' == e.KeyChar)
            {
                if ("" == R_Box.Text)
                    R_Box.Text = "0";
                SetColor_Show();
            }
        }
        private void G_Box_Change(object sender, EventArgs e)
        {
            if ("" == G_Box.Text)
                G_Box.Text = "0";
            SetColor_Show();
        }
        private void B_Box_Change(object sender, EventArgs e)
        {
            if ("" == B_Box.Text)
                B_Box.Text = "0";
            SetColor_Show();
        }

        private void GetColor()
        {
            int r = 0, g = 0, b = 0;
            int x = (p.X < 0 ? 0 : p.X > Color_Panel_Main.Width ? Color_Panel_Main.Width - 1 : p.X) * 255 * 6 / Color_Panel_Main.Width;
            int count = x / 255;
            int offect = x % 255;
            switch (count)
            {
                case 0:
                    r = 255;
                    g = offect;
                    break;
                case 1:
                    g = 255;
                    r = 255 - offect;
                    break;
                case 2:
                    g = 255;
                    b = offect;
                    break;
                case 3:
                    b = 255;
                    g = 255 - offect;
                    break;
                case 4:
                    r = offect;
                    b = 255;
                    break;
                case 5:
                    r = 255;
                    b = 255 - offect;
                    break;
            }

            float stepr = (float)(r - 127 == 0 ? 0 : r - 127) / Color_Panel_Main.Height;
            float stepg = (float)(g - 127 == 0 ? 0 : g - 127) / Color_Panel_Main.Height;
            float stepb = (float)(b - 127 == 0 ? 0 : b - 127) / Color_Panel_Main.Height;

            float red = Math.Abs(r - (p.Y < 0 ? 0 : p.Y > Color_Panel_Main.Height ? Color_Panel_Main.Height : p.Y) * stepr);
            float green = Math.Abs(g - (p.Y < 0 ? 0 : p.Y > Color_Panel_Main.Height ? Color_Panel_Main.Height : p.Y) * stepg);
            float blue = Math.Abs(b - (p.Y < 0 ? 0 : p.Y > Color_Panel_Main.Height ? Color_Panel_Main.Height : p.Y) * stepb);

            R_Box.Text = ((int)red).ToString();
            G_Box.Text = ((int)green).ToString();
            B_Box.Text = ((int)blue).ToString();

            

            SetColor_Show();
        }
        private void SetColor_Show()
        {
            int red = 0, green = 0, blue = 0;
            int.TryParse(R_Box.Text, out red);
            int.TryParse(G_Box.Text, out green);
            int.TryParse(B_Box.Text, out blue);
            Color_Show.BackColor = Color.FromArgb(255, red, green, blue);
        }
        #endregion

        public static byte GetRValue(uint rgb)
        {
            return (byte)rgb;
        }
        public static byte GetGValue(uint rgb)
        {
            return (byte)(((ushort)(rgb)) >> 8);
        }
        public static byte GetBValue(uint rgb)
        {
            return (byte)(rgb >> 16);
        }
    }
}
