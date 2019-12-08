using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using QuanLyTheGioiDiDong.BS_Layer;

namespace QuanLyTheGioiDiDong
{
    public partial class FrDetailProduct : Form
    {
        SqlConnection conn = new SqlConnection(QuanLyTheGioiDiDong.Properties.Settings.Default.TheGioiDiDongConnectionString);
        BLLoadData LoadData = new BLLoadData();
        BLLinhTinh LT = new BLLinhTinh();
        public int ProductID;
        public int EmployeeID;
        string err;


        public FrDetailProduct()
        {
            InitializeComponent();
        }
       
        public void LoadProduct()
        {
            LoadData.GetProductTheoID(dataGridView1,ProductID,ref err);
            label1.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            label4.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            lbGiaTien.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
        }
        public void LoadImg()
        {
            string Link = LoadData.GetProductImg(ProductID, ref err);
            ProductImg.Image = Image.FromFile(Link);
            Bitmap BM = LT.ScaleImage(ProductImg.Image, 240, 200);
            ProductImg.Image = BM;
        }
       
        private void FrDetailProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
            LoadImg();

        }

        private void BtnSell_Click(object sender, EventArgs e)
        {
            FrSellProduct frSell = new FrSellProduct();
            frSell.ProductID = ProductID;
            frSell.EmployeeID = EmployeeID;
            frSell.Visible = true;
            this.Visible = false;
        }

        private void lbGiaTien_Click(object sender, EventArgs e)
        {

        }
    }
}
