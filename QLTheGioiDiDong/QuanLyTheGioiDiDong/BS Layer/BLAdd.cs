using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTheGioiDiDong.BS_Layer
{
   public class BLAdd
    {
        QuanLyTheGioiDiDongDataContext MyContext = new QuanLyTheGioiDiDongDataContext();
        public void InsertAccount(string UserName, string Password, string Policy, ref string err)
        {
            MyContext.InsertAccount(UserName, Password, Policy);
            
        }
        public void InsertEmployee(string EmployeeName , string sex,Decimal? Salary, int? GroupID,int? AccountID, ref string err)
        {
            MyContext.AddEmployee(EmployeeName, sex, Salary, GroupID, AccountID);
            
        }
        public void InsertEmployee1(string EmployeeName, string sex, Decimal? Salary, string GroupName, int? AccountID, ref string err)
        {
            MyContext.AddViewEmployee_EmployeeGroups(EmployeeName, sex, Salary, GroupName, AccountID);

        }
        public void InsertGroup(string GroupName, ref string err)
        {
            MyContext.AddGroup(GroupName);
        }
        public void InsertProductType(string NameType,int Number, ref string err)
        {
            MyContext.AddProductType(NameType, Number);

        }
        public void InsertProduct(int IDType, string ProductName,string ProductImg,string ProductColor,int ProductCost, ref string err)
        {
            MyContext.AddProduct(IDType, ProductName, ProductImg, ProductColor, ProductCost);
        }
        public void InsertBills(int EmployeeID, int CustomerID, string ProductName, int Price,int ProductID, ref string err)
        {
            MyContext.AddBill(EmployeeID, CustomerID, ProductName,  Price, ProductID);
        }
        public void InsertCustomer(string CustomerName,int CustomerPhone,ref string err)
        {
            MyContext.AddCustomer(CustomerName, CustomerPhone);
        }
        public void InsertWarranty(int BillID,string ProblemProduct,DateTime ReleaseDay ,int EmployeeID, ref string err)
        {
            MyContext.AddWarranty(BillID, ProblemProduct, ReleaseDay, EmployeeID);
        }

    }
}
