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
    public partial class FrRevenue : Form
    {
        public FrRevenue()
        {
            InitializeComponent();
        }
        BLLinhTinh LT = new BLLinhTinh();
        BLLoadData LoadData = new BLLoadData();
        string err;
        private void BtnOK_Click(object sender, EventArgs e)
        {
            int month = Convert.ToInt32(txtMonth.Text);
            int money = LT.Revenue(month,ref err);
            label2.Text = money.ToString() + "  $";
            label2.Visible = true;
            LoadData.GetBillMonth(dgvRevenue, month, ref err);
        }


    }
}
