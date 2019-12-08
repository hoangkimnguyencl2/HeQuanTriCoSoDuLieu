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
    public partial class FrAddNhanVien : Form
    {        
        BLAdd Them = new BLAdd();
        BLLoadData LoadData = new BLLoadData();
        BLLinhTinh lt = new BLLinhTinh();
        string err;
        
        SqlConnection conn = new SqlConnection(QuanLyTheGioiDiDong.Properties.Settings.Default.TheGioiDiDongConnectionString);
        public FrAddNhanVien()
        {
            InitializeComponent();
        }
        
        private void BtnAdd_Click(object sender, EventArgs e)
        {          
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn Có Chắc Không !!!? ", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
            {
                int AccID = lt.getAccID(cbbAccID.Text, ref err);

                if (rdbNam.Checked == true)
                {
                    try
                    {
                       
                        Them.InsertEmployee1(txtTenNhanVien.Text, rdbNam.Text, Convert.ToInt32(txtLuong.Text) ,cbbNhom.Text, AccID, ref err);
                        MessageBox.Show("Thêm Thành Công!!!");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Thêm Lỗi !!!");
                    }
                }   
                else
                {
                    try
                    { 
                        Them.InsertEmployee1(txtTenNhanVien.Text, rdbNu.Text, Convert.ToInt32(txtLuong.Text), cbbNhom.Text, AccID, ref err);
                        MessageBox.Show("Thêm Thành Công!!!");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Thêm Lỗi !!!");
                    }
                }          
            }
            else
            {
                    MessageBox.Show("Quit");
                    this.Close();
            }

        }

        private void FrAddNhanVien_Load(object sender, EventArgs e)
        {
            LoadData.GetGroups(dataGridView1, ref err);

            int a = dataGridView1.Rows.Count;
            
            for (int i = 0; i < a -1; i++)
            {
                cbbNhom.Items.Add(dataGridView1.Rows[i].Cells[1].Value);
            }
            LoadData.GetAcc(dataGridView1, ref err);

            int b = dataGridView1.Rows.Count;
            for (int i = 0; i < b - 1; i++)
            {
                cbbAccID.Items.Add(dataGridView1.Rows[i].Cells[1].Value);
            }
        }
       
    }
}
