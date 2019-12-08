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
    public partial class FrAddProductType : Form
    {
        public int count = 0;
        string err;
        public FrAddProductType()
        {
            InitializeComponent();
        }
        BLAdd Them = new BLAdd();
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn Có Chắc Không !!!? ", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    Them.InsertProductType(txtLoaiSanPham.Text, Convert.ToInt32(nud.Value), ref err);
                    MessageBox.Show("Thêm thành công!!!");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Them Loi Roi-_-");                 
                }
            }
            else
            {
                MessageBox.Show("Quit");
                this.Close();
            }
        }
    }
}
