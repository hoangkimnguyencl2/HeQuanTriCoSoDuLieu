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
    public partial class FrNhanVienKyThuat : Form
    {
        BLLinhTinh LT = new BLLinhTinh();
        public int EmployeeID;
        string err;
        string employeeName;
        string Groupname;
        public FrNhanVienKyThuat()
        {
            InitializeComponent();
        }
        BLLoadData LoadData = new BLLoadData();
        BLLinhTinh lt = new BLLinhTinh();
        private void FrNhanVienKyThuat_Load(object sender, EventArgs e)
        {
            LoadData.LoadWarranty(dgvWarranty, EmployeeID, ref err);
            LayThongTinEmployee(EmployeeID);
        }
        private void BtnWarranty_Click(object sender, EventArgs e)
        {
            FrAddWarranty FrAW = new FrAddWarranty();
            FrAW.EmployeeID = EmployeeID;
            FrAW.Show();
        }
        public void LayThongTinEmployee(int ID)
        {

            try
            {
                LT.GetInfoEmploy(ID, ref employeeName, ref Groupname, ref err);
                label2.Text = employeeName;
                label4.Text = Groupname;
            }
            catch
            {
                MessageBox.Show("Tài khoản này chưa liên kết với nhân viên nào !!! Thử lại sau");
                Form1 fr1 = new Form1();
                fr1.Visible = true;
                this.Close();
            }

        }
        private void BtnTraPhieu_Click(object sender, EventArgs e)
        {
            
            try
            {
                int r = dgvWarranty.CurrentRow.Index;
                lt.BackWarranty(Convert.ToInt32(dgvWarranty.Rows[r].Cells[0].Value), ref err);
                MessageBox.Show("Tra Thanh Cong!!!");
            }
            catch
            {
                MessageBox.Show("Loi roi !!!");
            }
        }

        private void BtnLoadData_Click(object sender, EventArgs e)
        {
            LoadData.LoadWarranty(dgvWarranty, EmployeeID, ref err);
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Visible = true;
            this.Visible = false;
        }
    }
}
