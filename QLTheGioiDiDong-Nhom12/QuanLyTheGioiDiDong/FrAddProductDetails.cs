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
    public partial class FrAddProductDetails : Form
    {
        public int IDType;

        public FrAddProductDetails()
        {
            InitializeComponent();
        }
        BLAdd Them = new BLAdd();
        BLLoadData Loaddata = new BLLoadData();
        string err;
       
        private void BtnLayAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*jpg; *.jpeg; *.gif; *.bmp;)|*.png; *.jpg; *.gif; *.bmp;";
            if(open.ShowDialog() == DialogResult.OK)
            {
                txtAnh.Text = open.FileName;
                ptbAnh.BackgroundImage = new Bitmap(open.FileName);
       
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn Có Chắc Không !!!? ", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    Them.InsertProduct(IDType, txtProductName.Text, txtAnh.Text, txtMauSac.Text, Convert.ToInt32(txtProductCost.Text), ref err);
                    MessageBox.Show("Thêm thành công!!!");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Thêm lỗi rồi !!! ");
                    
                }
            }
            else
            {
                MessageBox.Show("Quit");
                this.Close();
    
            }
        }

        private void FrAddProductDetails_Load(object sender, EventArgs e)
        {
            Loaddata.GetProductTypes(dataGridView1, ref err);
            int a = dataGridView1.Rows.Count;
            for(int i = 0; i < a - 1;i++)
            {
                cbbTypeID.Items.Add(dataGridView1.Rows[i].Cells[0].Value);
            }
        }

        private void CbbTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            QuanLyTheGioiDiDongDataContext MyContext = new QuanLyTheGioiDiDongDataContext();
            IDType = Convert.ToInt32(MyContext.GetIDType(cbbTypeID.Text));
        }
    }
}
