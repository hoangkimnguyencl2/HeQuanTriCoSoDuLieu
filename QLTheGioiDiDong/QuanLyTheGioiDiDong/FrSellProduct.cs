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
    public partial class FrSellProduct : Form
    {
        public int ProductID;
        string err;
        public int EmployeeID;
        public int CustomerID;
        public string ProductName;
        public int ProductPrice;


        public FrSellProduct()
        {
            InitializeComponent();
            
        }
        BLLoadData LoadData = new BLLoadData();
        BLLinhTinh LT = new BLLinhTinh();
        BLAdd Add = new BLAdd();
        BLDelete D = new BLDelete();
        public void LoadImg()
        {
            string Link = LoadData.GetProductImg(ProductID,ref err);
            ProductImg.Image = Image.FromFile(Link);
            Bitmap bm = LT.ScaleImage(ProductImg.Image, 240, 200);
            ProductImg.Image = bm;           
        }

        private void FrSellProduct_Load(object sender, EventArgs e)
        {
            LoadImg();
            lbTien.Text = LT.getProductCost(ProductID, ref err).ToString();
            LoadData.GetProductTheoID(dataGridView1, ProductID, ref err);
            ProductName = dataGridView1.Rows[0].Cells[2].Value.ToString();
            ProductPrice = Convert.ToInt32(dataGridView1.Rows[0].Cells[4].Value.ToString());
       

        }

        private void BtnKT_Click(object sender, EventArgs e)
        {
            if(LT.getCustomerName(Convert.ToInt32(txtSDT.Text),ref err) == null)
            {
                MessageBox.Show("Chưa có khách hàng này!!!");
            }
            else
            {
               label3.Text = LT.getCustomerName(Convert.ToInt32(txtSDT.Text), ref err);
               txtSDT.Enabled = false;
            }
        }
     

        private void BtnSell_Click(object sender, EventArgs e)
        {
            CustomerID = LT.getCustomerID(Convert.ToInt32(txtSDT.Text), ref err);

            try
            {
                LT.SellProducts(ProductID,ref err);
                Add.InsertBills(EmployeeID, CustomerID, ProductName, ProductPrice, ProductID, ref err);              
                MessageBox.Show("Bán Thành Công!!!");
                this.Visible = false;
         
            }
            catch
            {
                MessageBox.Show("Lỗi không bán được !!! Thử lại sau");
            }
        }

        private void BtnNewCustomer_Click(object sender, EventArgs e)
        {
            FrAddCustomer frAC = new FrAddCustomer();
            frAC.SDT = txtSDT.Text;
            frAC.Show();

        }
    }
}
