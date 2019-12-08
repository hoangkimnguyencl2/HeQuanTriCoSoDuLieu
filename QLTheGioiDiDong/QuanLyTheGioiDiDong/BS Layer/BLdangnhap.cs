using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLyTheGioiDiDong.BS_Layer

{
    public class BLdangnhap
    {
        QuanLyTheGioiDiDongDataContext MyContext = new QuanLyTheGioiDiDongDataContext();

        public int Login(string username, string password , string policy ,int? EmployeeID)
        {
            MyContext.DangNhap(username, password, policy,ref EmployeeID);

            return Convert.ToInt32(EmployeeID);
           
        }

    }
}
