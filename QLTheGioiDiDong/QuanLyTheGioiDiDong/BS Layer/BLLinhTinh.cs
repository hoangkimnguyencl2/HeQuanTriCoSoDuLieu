using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTheGioiDiDong.BS_Layer
{
    public class BLLinhTinh
    {
        QuanLyTheGioiDiDongDataContext MyContext = new QuanLyTheGioiDiDongDataContext();
        public void GetInfoEmploy(int ID ,ref string EmployeeName,ref string GroupName,ref string err)
        {
            MyContext.GetInfoEmployees(ID,ref EmployeeName,ref GroupName);
        }
        public int GetEmployID(string username, string password, string policy,ref string err)
        {
            return Convert.ToInt32(MyContext.GetEmployeeID(username, password, policy));
           
        }
        public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);
            return bmp;
        }
        public string getCustomerName(int PhoneNumber,ref string err)
        {
            return MyContext.GetCustomerName(PhoneNumber);
        }
        public int getCustomerID(int PhoneNumber, ref string err)
        {
            return Convert.ToInt32(MyContext.GetCustomerID(PhoneNumber));
        }
        public int getProductCost(int ID, ref string err)
        {
            return Convert.ToInt32(MyContext.GetProductCost(ID));
        }
        public int getGroupID(string GroupName, ref string err)
        {
            return Convert.ToInt32(MyContext.GetGroupID(GroupName));
        }
        public int getAccID(string NameAcc, ref string err)
        {
            return Convert.ToInt32(MyContext.GetAccID(NameAcc));
        }
        public void SellProducts(int ID, ref string err)
        {
            MyContext.SellProduct(ID);
        }
        public DateTime dt()
        {
            return Convert.ToDateTime(MyContext.GetDay());
        }
        public void BackWarranty(int WarrantyID, ref string err)
        {
            MyContext.BackWarranty(WarrantyID);
        }
        public int Revenue(int month,ref string err)
        {
            return Convert.ToInt32(MyContext.Revenue(month));
        }

    }
}
