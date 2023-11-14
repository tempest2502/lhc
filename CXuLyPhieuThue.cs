using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CXuLyPhieuThue
    {
        private Dictionary<string,CPhieuThue> dsPT;
        private static readonly BinaryFormatter bf = new BinaryFormatter();
        public CXuLyPhieuThue()
        {
            dsPT = new Dictionary<string, CPhieuThue>();
        }
        public List<CPhieuThue> LayDSPhieuThue()
        {
            return dsPT.Values.ToList();
        }
        public CPhieuThue tim(string mapt)
        {
            if (dsPT.ContainsKey(mapt))
                return new CPhieuThue(dsPT[mapt]);
            return null;
        }
        public void them(CPhieuThue pt)
        {
            if (dsPT.ContainsKey(pt.MaPT) == null)
                dsPT.Add(pt.MaPT,pt);
        }
        
        public void Xoa(string mapt)
        {
            if (dsPT.ContainsKey(mapt) != null)
                dsPT.Remove(mapt);

        }
        public void Sua(CPhieuThue update)
        {
            if (dsPT.ContainsKey(update.MaPT) != null)
                dsPT[update.MaPT] = update;
            
        }
        public bool docFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                dsPT = (Dictionary<string, CPhieuThue>)bf.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool LuuFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                bf.Serialize(fs, dsPT);
                fs.Close();
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
