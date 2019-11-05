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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sqdNhom.AutoGenerateColumns = false;
            List<DanhBa> Nhom = DanhBa.GetNhom();
            sqdNhom.DataSource = Nhom;
            sqdTenNhom.AutoGenerateColumns = false;
            List<DanhBa> DB = DanhBa.getDanhBa(Nhom[0].TenNhom);
            sqdTenNhom.DataSource = DB;
            label5.Text = (string)DB[0].Email;
            label6.Text = (string)DB[0].SoDt;
            label7.Text = (string)DB[0].TenGoi;
        }

        private void sqdNhom_MouseClick(object sender, MouseEventArgs e)
        {
            sqdTenNhom.AutoGenerateColumns = false;
            if (DanhBa.getDanhBa((string)sqdNhom.CurrentCell.Value) != null) { 
            List<DanhBa> DB = DanhBa.getDanhBa((string)sqdNhom.CurrentCell.Value);
             sqdTenNhom.DataSource = DB;
                try { 
                label5.Text = (string)sqdTenNhom.CurrentRow.Cells[1].Value;
                label6.Text = (string)sqdTenNhom.CurrentRow.Cells[2].Value;
                label7.Text = (string)sqdTenNhom.CurrentRow.Cells[0].Value;
                }
                catch (Exception ) {
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                }
            }
          

           
        }

        private void sqdTenNhom_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void sqdTenNhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             
            label5.Text = (string)sqdTenNhom.CurrentRow.Cells[1].Value;
            label6.Text = (string)sqdTenNhom.CurrentRow.Cells[2].Value;
            label7.Text = (string)sqdTenNhom.CurrentRow.Cells[0].Value;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Themlienlac f = new Themlienlac();
            f.Show();
            sqdTenNhom.DataSource= DanhBa.getDanhBa((string)sqdNhom.CurrentCell.Value);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                String tengoi = (string)sqdTenNhom.CurrentRow.Cells[0].Value;
                string path = Application.StartupPath + @"/lienlac.txt";
                String[] lines = File.ReadAllLines(path);
                File.WriteAllText(path, "");
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] vd = lines[i].Split(new char[] { '#' });
                    if (vd[1].Equals(tengoi) == false)
                    {
                        String line = vd[0] + "#" + vd[1] + "#" + vd[2] + "#" + vd[3] + Environment.NewLine;
                        File.AppendAllText(path, line, Encoding.UTF8);
                    }
                    else
                    {

                    }
                }
               
            }
            else { }
            sqdTenNhom.DataSource = DanhBa.getDanhBa((string)sqdNhom.CurrentCell.Value);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            List<DanhBa> Nhom = DanhBa.GetNhom();
            sqdNhom.AutoGenerateColumns = false;
            sqdNhom.DataSource = Nhom;
            sqdTenNhom.AutoGenerateColumns = false;
            List<DanhBa> DB = DanhBa.getDanhBa((string)sqdNhom.CurrentCell.Value);
            sqdTenNhom.DataSource = DB;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ThemNhom f = new ThemNhom();
            f.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.OK)
            {
                String Tennhom = (string)sqdNhom.CurrentRow.Cells[0].Value;
                string path = Application.StartupPath + @"/TenNhom.txt";
                String[] lines = File.ReadAllLines(path);
                File.WriteAllText(path, "");
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] vd = lines[i].Split(new char[] { '#' });
                    if (vd[0].Equals(Tennhom) == false)
                    {
                        String line = vd[0]+Environment.NewLine;
                        File.AppendAllText(path, line, Encoding.UTF8);
                    }
                    else { }
                }

            }
            else { }
            List<DanhBa> Nhom = DanhBa.GetNhom();
            sqdNhom.DataSource = Nhom;

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            String tk=txtTimkiem.Text;
            List<DanhBa> DB = DanhBa.getDanhBa((string)sqdNhom.CurrentCell.Value);
            List<DanhBa> DB2 = new List<DanhBa>();
            
            //label6.Text = tk;
            //label7.Text = DB[0].TenGoi;
            for (int i = 0; i < DB.Count; i++)
            {
                if (DB[i].TenGoi.ToLower().Contains(tk.ToLower())==true)
                {
                    DB2.Add(new DanhBa {TenNhom=DB[i].TenNhom, TenGoi = DB[i].TenGoi, Email = DB[i].Email, SoDt = DB[i].SoDt });
                }
            }
            sqdTenNhom.DataSource = DB2;
        }
        
    }
}
