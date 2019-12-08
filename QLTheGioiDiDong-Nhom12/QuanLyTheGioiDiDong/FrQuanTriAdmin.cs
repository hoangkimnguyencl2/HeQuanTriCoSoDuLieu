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
using QuanLyTheGioiDiDong.BS_Layer;
namespace QuanLyTheGioiDiDong
{
    public partial class FrQuanTriAdmin : Form
    {
        string Type ;
        int dem = 0;
        string err;
        BLLoadData LoadData = new BLLoadData();
        BLDelete Xoa = new BLDelete();
        BLUndo Undo = new BLUndo();
        BLUpdate Update = new BLUpdate();
        BLLinhTinh lt = new BLLinhTinh();
        public FrQuanTriAdmin()
        {
            InitializeComponent();
        }
        private void FrQuanTriAdmin_Load(object sender, EventArgs e)
        {
            DateTime dt = lt.dt();
            label3.Text = label3.Text + "   "  + dt.Day.ToString() + "/" +dt.Month.ToString() + "/" + dt.Year.ToString();
            this.ChayGiamGiaHomNay.Start();
        }
        public void Nundo(string Type)
        {
            try
            {
                Undo.Undo(Type,ref err);
                
            }
            catch
            {
                MessageBox.Show("Undo Fail!!! ");
            }
       
        }      
        public void LoadGroup()
        {
            LoadData.GetGroups(dgvMain,ref err);
            dgvMain.Columns[0].Width = 200;
            dgvMain.Columns[1].Width = 300;
            int a = dgvMain.Rows.Count;
        }
        public void LoadEmployee()
        {   
             LoadData.GetEmployees(dgvMain, ref err);
            
        }
        public void LoadBill()
        {
            LoadData.GetBills(dgvMain, ref err);
        }
        public void LoadProducts()
        {

            LoadData.GetProductAdministrator(dgvMain, ref err);
            dgvMain.Columns[0].Width = 80;
            dgvMain.Columns[1].Width = 80;
        }
        public void LoadProductType()
        {
            LoadData.GetProductTypes(dgvMain, ref err);
            dgvMain.Columns[0].Width = 200;
            dgvMain.Columns[1].Width = 300;
        }
        private void ChayGiamGiaHomNay_Tick(object sender, EventArgs e)
        {
            this.label3.Location = new Point(this.label3.Location.X + 4, this.label3.Location.Y);
            Random rd = new Random();
            Color randomcolor = Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256));
            this.label3.ForeColor = randomcolor;
            if (this.label3.Location.X + this.label3.Width >= this.panel3.Location.X + this.panel3.Width + this.label3.Width)
            {
                this.label3.Location = new Point(this.panel3.Location.X - this.label3.Width, this.label3.Location.Y);
            }
   
        }
        public void Delete(string Type, int ID, String NameType)
        {

            DialogResult traloi;
            traloi = MessageBox.Show("Bạn Có Chắc Không !!!? ", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                try
                {
                    Xoa.Delete(Type, ID, NameType, ref err);
                    MessageBox.Show("Xóa thành công !!! LoadData để cập nhật dữ liệu");
                }
                catch
                {
                    MessageBox.Show("Xóa Lỗi Rồi!!!");
                }
            }
            else
            {
            }
        }
        public void UpdateEmployee(int EmployeeID, int Salary , string GroupName, int AccountID)
        {  
                try
                {
                    Update.UpdateEmployee(EmployeeID, Salary, GroupName, AccountID, ref err);
                    MessageBox.Show("Cập nhật thành công !!! LoadData để cập nhật dữ liệu");
                }
                catch
                {
                    MessageBox.Show("Lỗi Rồi!!!");

                }
        
        }
        public void UpdateProduct(int ProductID, int ProductCost,string ProductColor)
        {
            try
            {
                Update.UpdateProducts(ProductID, ProductCost, ProductColor, ref err);
                MessageBox.Show("Cập nhật thành công !!! LoadData để cập nhật dữ liệu");
            }
            catch
            {
                MessageBox.Show("Lỗi Rồi!!!");
            }

        }
        private void CbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cbbNhanVien.SelectedIndex == 0)
            {
                LoadEmployee();
                Type = "Employees";
                btnRevenue.Visible = false;
               
            }
            else if (this.cbbNhanVien.SelectedIndex == 1)
            {
                Type = "Groups";
                LoadGroup();
                btnRevenue.Visible = false;
                
            }
            else if (this.cbbNhanVien.SelectedIndex == 2)
            {
                LoadBill();
                Type = "Bills";
                btnRevenue.Visible = true;
            
            }
            cbbSanPham.Text = "";
        }
        private void CbbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbbSanPham.SelectedIndex == 0)
            {   
                LoadProducts();         
                Type = "Products";

            }
            else if (this.cbbSanPham.SelectedIndex == 1)
            {
                LoadProductType();
                Type = "ProductType";


            }
            else if (this.cbbSanPham.SelectedIndex == 2)
            {
                LoadData.LoadCustomer(dgvMain, ref err);
                Type = "Customer";
                dgvMain.Columns[1].Width = 150;
                dgvMain.Columns[2].Width = 200;
            }
            cbbNhanVien.Text = "";
            btnRevenue.Visible = false;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(Type == "Groups")
            {
                FrAddGroupNhanVien fraddgroup = new FrAddGroupNhanVien();
                fraddgroup.Show();
            }
            else if(Type == "Employees")
            {
                FrAddNhanVien fraddnv = new FrAddNhanVien();
                fraddnv.Show();
            }
            else if (Type == "Bills")
            {
                MessageBox.Show("Admin Không Thêm Bill!!!");
                
            }
            else if (Type == "Products")
            {
                FrAddProductDetails fraddproductdetails = new FrAddProductDetails();
                fraddproductdetails.Show();
            }
            else if(Type == "ProductType")
            {
                FrAddProductType fraddproducttype = new FrAddProductType();
                fraddproducttype.Show();
            }
            else if(Type == "Customer")
            {
                MessageBox.Show("Admin chỉ xem khách hàng!!!");
            }
        }
        private void BtnLoadData_Click(object sender, EventArgs e)
        {
            if(Type == "Groups")
            {
                LoadGroup();
            }
            else if(Type == "Employees")
            {
                LoadEmployee();
            }
            else if (Type == "Bills")
            {
                LoadBill();
            }
            else if (Type == "Products")
            {
                LoadProducts();
            }
            else if (Type == "ProductType")
            {
                LoadProductType();
            }
            else if (Type == "Customer")
            {
                LoadData.LoadCustomer(dgvMain,ref err);
                dgvMain.Columns[1].Width = 150;
                dgvMain.Columns[2].Width = 200;
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvMain.CurrentRow.Index;
            txt1.Text = dgvMain.Rows[r].Cells[0].Value.ToString();
            if (Type == "Groups")
            {
               Delete(Type,Convert.ToInt32(txt1.Text),null);
            }
            else if (Type == "Employees")
            {
               Delete(Type,Convert.ToInt32(txt1.Text),null);        
            }
            else if (Type == "Bills")
            {
                MessageBox.Show("không thực hiện tính năng này!!!");
            }
            else if (Type == "Products")
            {         
               Delete(Type,Convert.ToInt32(txt1.Text),null);
            }
            else if (Type == "ProductType")
            {
                Delete(Type, 0 , txt1.Text);
            }
            else if (Type == "Customer")
            {
                MessageBox.Show("Admin chỉ xem khách hàng!!!");
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {

            int r = dgvMain.CurrentRow.Index;
            if (Type == "Groups")
            {
                MessageBox.Show("Không chỉnh sửa Group!!!");
            }
            else if (Type == "Employees")
            {
                dem++;
                if (dem == 1) //lan click edit lan 1
                {
                    MessageBox.Show("Bạn chỉ được phép chỉnh Lương, Nhóm và Account của nhân viên!!!");
                    dgvMain.Rows[r].Cells[0].ReadOnly = true;
                    dgvMain.Rows[r].Cells[1].ReadOnly = true;
                    dgvMain.Rows[r].Cells[2].ReadOnly = true;
                    
                }
                else if (dem == 2) //lan click edit lan 2
                {  
                    int a = Convert.ToInt32(dgvMain.Rows[r].Cells[0].Value);
                    int b = Convert.ToInt32(dgvMain.Rows[r].Cells[3].Value);
                    string c = Convert.ToString(dgvMain.Rows[r].Cells[4].Value);
                    int d = Convert.ToInt32(dgvMain.Rows[r].Cells[5].Value);
                    UpdateEmployee(a, b, c , d);
                    dem = 0;
                }
              
            }
            else if (Type == "Bills")
            {
                MessageBox.Show("Không Chỉnh Sửa Bill!!!");
            }
            else if (Type == "Products")
            {
                dem++;
                if (dem == 1)
                {
                    MessageBox.Show("Bạn chỉ được phép chỉnh Giá tiền và Màu của sản phẩm!!!");
                    dgvMain.Rows[r].Cells[0].ReadOnly = true;
                    dgvMain.Rows[r].Cells[1].ReadOnly = true;
                    dgvMain.Rows[r].Cells[2].ReadOnly = true;
                }
                else if (dem == 2)
                {
                    int a = Convert.ToInt32(dgvMain.Rows[r].Cells[0].Value);
                    int b = Convert.ToInt32(dgvMain.Rows[r].Cells[4].Value);
                    string c = dgvMain.Rows[r].Cells[3].Value.ToString();
                    UpdateProduct(a, b ,c );
                    dem = 0;
                }
            }
            else if (Type == "ProductType")
            {
                MessageBox.Show("Không chỉnh sửa ProductTypes!!!");
            }
            else if(Type == "Customer")
            {
                MessageBox.Show("Admin chỉ xem khách hàng!!!");
            }
        }
        private void BtnUndo_Click(object sender, EventArgs e)
        {
            if (Type == "Groups")
            {
                Nundo(Type);
                LoadGroup();
            }
            else if (Type == "Employees")
            {
                Nundo(Type);
                LoadEmployee();
            }
            else if (Type == "Bills")
            {
                //Nundo(Type);
                LoadBill();
            }
            else if (Type == "Products")
            {
                Nundo(Type);
                LoadProducts();
            }
            else if (Type == "ProductType")
            {
                Nundo(Type);
                LoadProductType();
            }
            else if (Type == "Customer")
            {
                MessageBox.Show("Admin chỉ xem khách hàng!!!");
            }
        }
        private void BtnaddUser_Click(object sender, EventArgs e)
        {
            frAddUser fradd = new frAddUser();
            fradd.Show();
        }
        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Visible = true;
            this.Visible = false;
        }

        private void BtnRevenue_Click(object sender, EventArgs e)
        {
            FrRevenue frDT = new FrRevenue();
            frDT.Show();
        }
    }
}
