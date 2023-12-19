using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dangnhapjed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=from1;Integrated Security=True");
            try
            {
                con.Open();
                string username = txttendangnhap1.Text;
                string password = txtMK1.Text;


                // Sửa câu truy vấn SQL
                string sql = "SELECT * FROM NguoiDung WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@TaiKhoan", username);
                cmd.Parameters.AddWithValue("@MatKhau", password);
               
                // Sử dụng ExecuteScalar thay vì ExecuteReader
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != null)
                {
                    MessageBox.Show("Đăng nhập thành công");
                    Home frm = new Home();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi kết nối: "+ ex.Message);
            }
        }

        private void linkquenMk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          Quenmatkhau frm = new Quenmatkhau();
            frm.ShowDialog();
        }

        private void linkDangky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangky frm = new Dangky();
            frm.ShowDialog();
        }
    }
}
