using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private CXuLyPhieuThue xuly = new CXuLyPhieuThue();
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            xuly.them(new CPhieuThue("pt01", DateTime.Today, new DateTime(2023, 11, 9), "Cong", KieuLoaiPhong.A));
            xuly.them(new CPhieuThue("pt02", DateTime.Today, new DateTime(2023, 11, 10), "Hai", KieuLoaiPhong.B));
            xuly.them(new CPhieuThue("pt03", DateTime.Today, new DateTime(2023, 11, 11), "Hau", KieuLoaiPhong.C));
            xuly.them(new CPhieuThue("pt04", DateTime.Today, new DateTime(2023, 11, 12), "Ban", KieuLoaiPhong.D));
            hienthi();
        }
        private void hienthi()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = xuly.LayDSPhieuThue();
            dgvPT.DataSource = bs;
            clear();
        }
        private void clear()
        {
            txtMaPT.Text = "";
            dtpNgayBD.Value = dtpNgayKT.Value = DateTime.Today;
            txtTenKH.Text = "";
            rbtA.Checked = true;
        }
        private KieuLoaiPhong GetLoaiPhong()
        {
            if (rbtA.Checked)
                return KieuLoaiPhong.A;
            else if (rbtB.Checked)
                return KieuLoaiPhong.B;
            else if (rbtC.Checked)
                return KieuLoaiPhong.C;
            else
                return KieuLoaiPhong.D;
        }
        private void SetLoaiPhong(KieuLoaiPhong loaiPhong)
        {
            switch (loaiPhong)
            {
                case KieuLoaiPhong.A: rbtA.Checked = true; break;
                case KieuLoaiPhong.B: rbtB.Checked = true; break;
                case KieuLoaiPhong.C: rbtC.Checked = true; break;
                case KieuLoaiPhong.D: rbtD.Checked = true; break;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (xuly.tim(txtMaPT.Text) == null)
            {
                xuly.them(new CPhieuThue(txtMaPT.Text, dtpNgayBD.Value, dtpNgayKT.Value, txtTenKH.Text, GetLoaiPhong()));
                hienthi();
            }
            else MessageBox.Show("Ma bi trung");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPT.SelectedRows.Count == 0) return;
            int index = dgvPT.SelectedRows[0].Index;
            string mapt = dgvPT.Rows[index].Cells[0].Value.ToString();
            xuly.Xoa(mapt);
            hienthi();
        }

        private void dgvPT_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string mapt = dgvPT.Rows[e.RowIndex].Cells[0].Value.ToString();
            CPhieuThue pt = xuly.tim(mapt);
            txtMaPT.Text = pt.MaPT;
            txtTenKH.Text = pt.TenKH;
            dtpNgayBD.Value = pt.NgayBD;
            dtpNgayKT.Value = pt.NgayKT;
            SetLoaiPhong(pt.LoaiPhong);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvPT.SelectedRows.Count == 0) return;
            int index = dgvPT.SelectedRows[0].Index;
            string mapt = dgvPT.Rows[index].Cells[0].Value.ToString();
            CPhieuThue pt = xuly.tim(mapt);
            pt.NgayBD = dtpNgayBD.Value;
            pt.NgayKT = dtpNgayKT.Value;
            pt.TenKH = txtTenKH.Text;
            pt.LoaiPhong = GetLoaiPhong();
            xuly.Sua(pt);
            hienthi();
        }

        private void btnMoFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                if (xuly.docFile(openFileDialog1.FileName))
                {
                    hienthi();
                    MessageBox.Show("Doc File THANH CONG!");
                }
                else MessageBox.Show("Doc File THAT BAI!");
            }
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                if (xuly.LuuFile(saveFileDialog1.FileName))
                    MessageBox.Show("Luu File THANH CONG!");
            }
            else MessageBox.Show("Luu File THAT BAI!");
        }
    }
}
