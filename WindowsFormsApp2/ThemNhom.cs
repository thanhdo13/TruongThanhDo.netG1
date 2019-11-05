using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ThemNhom : Form
    {
        public ThemNhom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            List<DanhBa> DB = DanhBa.GetNhom();
            string path = Application.StartupPath + @"/TenNhom.txt";
            for (int i = 0; i < DB.Count; i++)
            {
                if (txtTenNhom.Text.Equals(DB[i].TenNhom))
                {
                    k = 1;
                }
            }
            if (k == 1)
                MessageBox.Show("Tên Nhóm đã có trong cơ sở!");
            else
            {
                String line = txtTenNhom.Text + System.Environment.NewLine;
                File.AppendAllText(path, line, Encoding.UTF8);
                MessageBox.Show("Thêm nhóm thành công!");
                this.Close();
            }
        }
    }
}
