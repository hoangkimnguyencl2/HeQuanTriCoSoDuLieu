using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTheGioiDiDong.BS_Layer
{
    public class BLDelete
    {
        QuanLyTheGioiDiDongDataContext MyContext = new QuanLyTheGioiDiDongDataContext();

        public void Delete(string Type, int ID,string NameType, ref string err)
        {
            MyContext.spDelete(Type, ID, NameType);
        }


    }
}
