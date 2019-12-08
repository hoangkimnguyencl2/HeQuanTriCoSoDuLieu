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
    public partial class FrNhanVienBanHang : Form
    {
        public int EmployeeID;
        public string NameType;
        public FrNhanVienBanHang()
        {
            InitializeComponent();
        }
        BLLinhTinh LT = new BLLinhTinh();
        BLLoadData LoadData = new BLLoadData();
        string err;
        string EmployeeName;
        string GroupName;
        public void LayThongTinEmployee(int ID)
        {

            try
            {
                LT.GetInfoEmploy(ID, ref EmployeeName,ref GroupName, ref err);
                label2.Text = EmployeeName;
                label4.Text = GroupName;
            }
            catch
            {
                MessageBox.Show("Tài khoản này chưa liên kết với nhân viên nào !!! Thử lại sau");
                Form1 fr1 = new Form1();
                fr1.Visible = true;
                this.Close();
            }

        }
        //}      
        //public void CountProductType()
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("CountProductType", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;
        //    cmd.ExecuteNonQuery();
        //    Count = int.Parse(cmd.Parameters["@Count"].Value.ToString());
        //    conn.Close();

        //}
        //public void cbb()
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("LayProductType", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.ExecuteNonQuery();
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter spd = new SqlDataAdapter();
        //    spd.SelectCommand = cmd;
        //    spd.Fill(ds);
        //    for (int i = 0; i < Count; i++)
        //    {
        //        string NameType = Convert.ToString(ds.Tables[0].Rows[i][0]);
        //        cbbType.Items.Add(NameType);
        //    }
        //    conn.Close();
        //}
        //public void LayGroupName()
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("LayTenGroupTheoID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@GroupID", SqlDbType.Int).Value = GroupID;
        //    cmd.ExecuteNonQuery();
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter spd = new SqlDataAdapter();
        //    spd.SelectCommand = cmd;
        //    spd.Fill(ds);
        //    try
        //    {
        //        string groupName = Convert.ToString(ds.Tables[0].Rows[0][0]);
        //        label4.Text = groupName;
        //        conn.Close();
        //    }
        //    catch
        //    {
        //        conn.Close();
        //    }

        //}
        //public void LayIDGroup()
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("LayIDTheoTenGroupType", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@NameType", SqlDbType.VarChar).Value = NameType;
        //    cmd.ExecuteNonQuery();
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter spd = new SqlDataAdapter();
        //    spd.SelectCommand = cmd;
        //    spd.Fill(ds);
        //    try
        //    {
        //        IDType = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        //        conn.Close();
        //    }
        //    catch
        //    {
        //        conn.Close();
        //    }
        //}
        //public void LoadProduct()
        //{
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("LayProductTheoType", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@IDType", SqlDbType.Int).Value = IDType;
        //    DataTable dt = new DataTable();
        //    dt.Load(cmd.ExecuteReader());
        //    dgvProduct.DataSource = dt;
        //    conn.Close();
        //}

        private void FrNhanVien_Load(object sender, EventArgs e)
        {
            LayThongTinEmployee(EmployeeID);
            LoadData.GetProductTypes(dataGridView1, ref err);
            int a = dataGridView1.Rows.Count;
            cbbType.Items.Add("ALL");
            for (int i = 0; i < a - 1; i++)
            {
                cbbType.Items.Add(dataGridView1.Rows[i].Cells[0].Value);
            }
            //LayGroupName();
            //CountProductType();
            //cbb();


        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Visible = true;
            this.Visible = false;
        }

        private void CbbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameType = cbbType.Text;
            LoadData.GetProductTheoType(dgvProduct, NameType, ref err);
            txtMax.Clear();
            txtMin.Clear();
            
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            int r = dgvProduct.CurrentRow.Index;
            FrSellProduct frSell = new FrSellProduct();
            frSell.EmployeeID = EmployeeID;
            FrDetailProduct frDP = new FrDetailProduct();
            frDP.ProductID = Convert.ToInt32(dgvProduct.Rows[r].Cells[0].Value.ToString());
            frDP.EmployeeID = EmployeeID;
            frDP.Show();
        }

        private void BtnBill_Click(object sender, EventArgs e)
        {
            FrBillEmployee frbe = new FrBillEmployee();
            frbe.EmployeeID = EmployeeID;
            frbe.Show();
        }

        private void BtnSeach_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData.SeachBill(dgvProduct, Convert.ToInt32(txtSDT.Text), ref err);
                MessageBox.Show("tìm thấy");
            }
            catch
            {
                MessageBox.Show("ko co");
            }
        }

        private void BtnSeach2_Click(object sender, EventArgs e)
        {
            if(txtMin.Text == "")
            {
                LoadData.SeachProduct(dgvProduct, 0, Convert.ToInt32(txtMax.Text), cbbType.Text, ref err);
                dgvProduct.Columns[1].Width = 200;
                dgvProduct.Columns[2].Width = 200;
            }
            else if(txtMax.Text =="")
            {
                MessageBox.Show("Nhap So tien toi da ban muon mua!!!");
            }
            else
            {
                LoadData.SeachProduct(dgvProduct, Convert.ToInt32(txtMin.Text), Convert.ToInt32(txtMax.Text), cbbType.Text, ref err);
                dgvProduct.Columns[1].Width = 200;
                dgvProduct.Columns[2].Width = 200;
            }
        }
    }
}
