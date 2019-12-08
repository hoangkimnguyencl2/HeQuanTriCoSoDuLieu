using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTheGioiDiDong.BS_Layer
{
    public class BLUpdate
    {
        QuanLyTheGioiDiDongDataContext MyContext = new QuanLyTheGioiDiDongDataContext();
        public void UpdateEmployee(int ID,int Salary,string GroupName, int EmployeeAcc,ref string err)
        {
            MyContext.UpdateEmployee(ID, Salary, GroupName, EmployeeAcc);
        }
        public void UpdateProducts(int ID, int ProductCost, string ProductColor, ref string err)
        {
            MyContext.UpdateProducts(ID, ProductCost, ProductColor);
        }

    }
}
