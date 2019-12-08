using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTheGioiDiDong.BS_Layer
{
    public class BLUndo
    {
        QuanLyTheGioiDiDongDataContext MyContext = new QuanLyTheGioiDiDongDataContext();
        public void Undo(string Type, ref string err)
        {
            MyContext.spUndo(Type);
        }
    }
}
