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
    public partial class frAddUser : Form
    {
        public frAddUser()
        {
            InitializeComponent();
        }
        BLAdd Them = new BLAdd();
        string err;
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if(txtMatKhau.Text != txtRepeatMatKhau.Text)
            {
                MessageBox.Show("Mật Khẩu Nhập Lại Không Đúng!!!");
            }
            else
            {
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn Có Chắc Không !!!? ", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    try
                    {
                        Them.InsertAccount(txtAcc.Text, txtMatKhau.Text, cbbQuyen.Text, ref err);
                        MessageBox.Show("Thêm thành công!!!");
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi Rồi !!");
                    }
                }
                else
                {
                    this.Close();
                }
                
            }
        }
    }
}
