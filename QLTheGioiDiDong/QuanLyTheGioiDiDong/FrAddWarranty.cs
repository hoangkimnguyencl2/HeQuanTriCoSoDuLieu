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
    public partial class FrAddWarranty : Form
    {
        public int EmployeeID;
        string err;
        public FrAddWarranty()
        {
            InitializeComponent();
        }
        BLAdd A = new BLAdd();
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                A.InsertWarranty(Convert.ToInt32(txtBillID.Text), txtProblemProduct.Text, DTP.Value, EmployeeID, ref err);
                MessageBox.Show("Thêm thành công !!!");
                this.Visible = false;
            }
            catch
            {
                MessageBox.Show("Thêm thất bại !!!");
            }
        }
    }
}
