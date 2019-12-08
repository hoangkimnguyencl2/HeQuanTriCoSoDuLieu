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
    public partial class Form1 : Form
    {

        BLdangnhap DN = new BLdangnhap();
        BLLinhTinh LT = new BLLinhTinh();
        public Form1()
        {
            InitializeComponent();
        }
        int EmployeeID;
        string err;
        string EmployeeName;
        string EmployeeGroup;
       
        
        private void DichuyenTheGioiDiDong_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            Color randomcolor = Color.FromArgb(rd.Next(256), rd.Next(256), rd.Next(256));
            this.lbtgdd.ForeColor = randomcolor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.DichuyenTheGioiDiDong.Start();
           
            
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (DN.Login(txtUserName.Text, txtPassword.Text, cbbPolicy.Text, EmployeeID) != 0 && cbbPolicy.Text == "Admin")
            {
                MessageBox.Show("Đăng nhập thành công!!!");
                FrQuanTriAdmin frAdmin = new FrQuanTriAdmin();
                frAdmin.Visible = true;
                this.Visible = false;

            }
            else if (DN.Login(txtUserName.Text, txtPassword.Text, cbbPolicy.Text, EmployeeID) != 0 && cbbPolicy.Text == "Nhan Vien")
            {
                MessageBox.Show("Đăng nhập thành công!!!");
                EmployeeID = LT.GetEmployID(txtUserName.Text, txtPassword.Text, cbbPolicy.Text, ref err);
                LT.GetInfoEmploy(EmployeeID,ref EmployeeName,ref EmployeeGroup, ref err);
                if (EmployeeGroup == "Ban Hang")
                {
                    FrNhanVienBanHang frNV = new FrNhanVienBanHang();
                    frNV.EmployeeID = EmployeeID;
                    frNV.Visible = true;
                    this.Visible = false;
                }
                else if(EmployeeGroup =="Ky Thuat")
                {
                    FrNhanVienKyThuat FrKT = new FrNhanVienKyThuat();
                    FrKT.EmployeeID = EmployeeID;
                    FrKT.Visible = true;
                    this.Visible = false;
                }
                
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!!");
            }



            //conn.Open();
            //SqlCommand cmd = new SqlCommand("DangNhap", conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@UserName", SqlDbType.VarChar).Value = txtUserName.Text;
            //cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = txtPassword.Text;
            //cmd.Parameters.AddWithValue("@Policy", SqlDbType.VarChar).Value = cbbPolicy.Text;
            //cmd.ExecuteNonQuery();
            //DataSet ds = new DataSet();
            //SqlDataAdapter spd = new SqlDataAdapter();
            //spd.SelectCommand = cmd;
            //spd.Fill(ds);
            //conn.Close();

            //if (ds.Tables[0].Rows.Count > 0 && cbbPolicy.SelectedIndex == 0 )
            //{
            //    MessageBox.Show("DangNhapThanhCong!");
            //    FrQuanTriAdmin frqtadm = new FrQuanTriAdmin();
            //    frqtadm.Visible = true;
            //    this.Visible = false;
            //}
            //else if(ds.Tables[0].Rows.Count > 0 && cbbPolicy.SelectedIndex == 2)
            //{
            //    int AccountID = LayThongTinUser();
            //    MessageBox.Show("DangNhapThanhCong!");
            //    FrNhanVien frnv = new FrNhanVien();
            //    frnv.EmployeeAcc = AccountID;
            //    frnv.Visible = true;
            //    this.Visible = false;
            //}
            //else
            //{
            //    MessageBox.Show("DangNhapThatBai!");
            //}
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chbShowPasswd_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowPasswd.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = true;
            }
            else
                txtPassword.UseSystemPasswordChar = false;
        }
    }
}
