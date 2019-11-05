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
    public partial class Themlienlac : Form
    {
        public Themlienlac()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Themlienlac_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            string path = Application.StartupPath + @"/lienlac.txt";
            List<DanhBa> tennhom = DanhBa.GetNhom();
            for (int i = 0; i < tennhom.Count; i++) {
               // MessageBox.Show(tennhom[i].TenNhom);
                if (txtNhom.Text.Equals(tennhom[i].TenNhom)) { 
                    k = 1;   
                }   
            }
            if(k==0)
            MessageBox.Show("Tên nhóm không có trong cơ sở!");
            else
            {
                String line = txtNhom.Text + "#" + txtTenGoi.Text + "#" + txtEmail.Text + "#" + txtSdt.Text+System.Environment.NewLine;
                File.AppendAllText(path, line, Encoding.UTF8);
                MessageBox.Show("Đã thêm thành công!");
                this.Close();
            }

        }
    }
}
