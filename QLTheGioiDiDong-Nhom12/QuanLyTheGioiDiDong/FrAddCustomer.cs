using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTheGioiDiDong.BS_Layer;

namespace QuanLyTheGioiDiDong
{
    public partial class FrAddCustomer : Form
    {
        BLAdd A = new BLAdd();
        public FrAddCustomer()
        {
            InitializeComponent();
        }
        public string SDT;
        string err;
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                A.InsertCustomer(txtTenKH.Text, Convert.ToInt32(SDT), ref err);
                MessageBox.Show("Them thanh cong!!!");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Them Loi!!!");
            }
        }

        private void FrAddCustomer_Load(object sender, EventArgs e)
        {
            txtSDT.Text = SDT;
        }
    }
}
