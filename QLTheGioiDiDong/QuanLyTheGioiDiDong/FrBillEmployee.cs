using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTheGioiDiDong.BS_Layer;
using System.Windows.Forms;

namespace QuanLyTheGioiDiDong
{
    public partial class FrBillEmployee : Form
    {
        public int EmployeeID;
        string err;
        public FrBillEmployee()
        {
            InitializeComponent();
        }
        BLLoadData LoadData = new BLLoadData();

        private void FrBillEmployee_Load(object sender, EventArgs e)
        {
            LoadData.LoadEmployeeBill(dataGridView1, EmployeeID, ref err);
        }
    }
}
