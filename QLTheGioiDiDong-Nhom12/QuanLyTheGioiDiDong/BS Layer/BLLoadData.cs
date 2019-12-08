using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTheGioiDiDong.BS_Layer
{
    public class BLLoadData
    {
        QuanLyTheGioiDiDongDataContext MyContext = new QuanLyTheGioiDiDongDataContext();
        public void GetEmployees(DataGridView dgv, ref string err)
        {
            dgv.DataSource = MyContext.GetEmployees();
        }
        public void GetGroups(DataGridView dgv, ref string err)
        {
            dgv.DataSource = MyContext.GetGroup();
        }
        public void GetProducts(DataGridView dgv, ref string err)
        {
            dgv.DataSource = MyContext.GetProduct();
        }
        public void GetProductAdministrator(DataGridView dgv, ref string err)
        {
            dgv.DataSource = MyContext.GetProductAdmin();
        }
        public void GetProductTypes(DataGridView dgv, ref string err)
        {
            dgv.DataSource = MyContext.GetProductType();
        }
        public void GetBills(DataGridView dgv, ref string err)
        {
            dgv.DataSource = MyContext.GetBill();
        }
        public void GetAcc(DataGridView dgv, ref string err)
        {
            dgv.DataSource = MyContext.GetAcc();
        }
        public void GetProductTheoType(DataGridView dgv,string type, ref string err)
        {
            dgv.DataSource = MyContext.GetProductTheoType(type);
        }
        public void GetProductTheoID(DataGridView dgv, int ID, ref string err)
        {
            dgv.DataSource = MyContext.GetProductTheoID(ID);
        }
        public string GetProductImg(int ID, ref string err)
        {
            return Convert.ToString(MyContext.FunctionLayImg(ID));
        }
        public void LoadEmployeeBill(DataGridView dgv, int EmployeeID , ref string err)
        {
            dgv.DataSource = MyContext.GetEmployeeBill(EmployeeID);
        }
        public void LoadWarranty(DataGridView dgv,int EmployeeID,ref string err)
        {
            dgv.DataSource = MyContext.GetWarranty_Employee(EmployeeID);
        }
        public void LoadCustomer(DataGridView dgv,ref string err)
        {
            dgv.DataSource = MyContext.GetCustomer();
        }
        public void SeachBill(DataGridView dgv,int PhoneNumber, ref string err)
        {
            dgv.DataSource = MyContext.seachindexseekcustomers(PhoneNumber);
        }
        public void Data(DataGridView dgv,string Type, ref string err)
        {
            dgv.DataSource = MyContext.GetData(Type);
        }
        public void SeachProduct(DataGridView dgv , int min, int max, string producttype, ref string err)
        {
            dgv.DataSource = MyContext.SeachProduct(min, max, producttype);
        }
        public void GetBillMonth(DataGridView dgv,int Month,ref string err)
        {
            dgv.DataSource = MyContext.GetBillMonth(Month);
        }
    }

}
