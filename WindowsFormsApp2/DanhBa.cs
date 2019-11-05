using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class DanhBa
    {
        public string TenNhom { get; set; }
        public string TenGoi { get; set; }
        public string Email { get; set; }
        public string SoDt { get; set; }
        public static List<DanhBa> GetNhom()
        {
            string path = Application.StartupPath + @"/TenNhom.txt";
            List<DanhBa> list = new List<DanhBa>();
            string[] line = File.ReadAllLines(path);
                for (int i = 0; i < line.Length; i++)
            {
                string[] vd = line[i].Split(new char[] { '#' });
                int check = 1;
                for(int j = 0; j < list.Count; j++) {
                    String tenNhom = list.ElementAt(j).TenNhom;
                    if (vd[0].Equals(tenNhom)) {
                        check = 0;
                        break;
                    }
                }
                if(check==1)
                    list.Add(new DanhBa { TenNhom = vd[0] });
            }
            return list;
        }

        public static List<DanhBa> getDanhBa(string Nhom)
        {
            string path = Application.StartupPath + @"/lienlac.txt";
            List<DanhBa> list = new List<DanhBa>();
            string[] line = File.ReadAllLines(path);
            for (int i = 0; i < line.Length; i++)
            {  
                string[] vd = line[i].Split(new char[] { '#' });
                if (vd[0].Equals(Nhom))
                    list.Add(new DanhBa { TenNhom = vd[0], TenGoi = vd[1], Email = vd[2], SoDt = vd[3] });
            }
            return list;
        }
        public static List<DanhBa> getDanhBaAll()
        {
            string path = Application.StartupPath + @"/lienlac.txt";
            List<DanhBa> list = new List<DanhBa>();
            string[] line = File.ReadAllLines(path);
            for (int i = 0; i < line.Length; i++)
            {

                string[] vd = line[i].Split(new char[] { '#' });
                    list.Add(new DanhBa { TenNhom = vd[0], TenGoi = vd[1], Email = vd[2], SoDt = vd[3] });
            }
            return list;
        }
    }
}
