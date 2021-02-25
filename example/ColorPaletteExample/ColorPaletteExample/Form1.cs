using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 调色板;

namespace ColorPaletteExample
{
    public partial class 调色板示例程序 : Form
    {
        public 调色板示例程序()
        {
            InitializeComponent();
        }

        private void OpenColorPalette_Click(object sender, EventArgs e)
        {
            调色板.调色板 ColorPalette = new 调色板.调色板();
            ColorPalette.ShowDialog();
        }
    }
}
