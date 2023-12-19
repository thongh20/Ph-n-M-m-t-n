using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dangnhapjed
{
    internal class Nguoi_Dung
    {
        private string TenTaiKhoan, MatKhau, Email, Phone,hoten;
        public Nguoi_Dung()
        {
            TenTaiKhoan = Email = Phone = hoten = MatKhau = " ";
        }
        public Nguoi_Dung(string hten, string email, string matkhau, string didong, string ten)
        {
            TenTaiKhoan = hten;
            MatKhau = matkhau;
            Email = email;
            Phone = didong;
            hoten = ten;
        }
        public bool kiemtradinhdangmatkhau() // tối thiểu 7 ký tự có cả chữ và số 
        {
             
            if(MatKhau.Length < 7)
            {
               return false;
            }
            
            
                bool kiemtrachu = false;    
                bool kiemtraso = false;
            for (int i = 0; i < MatKhau.Length; ++i)
            {
                if (kiemtrachu == true && kiemtraso == true)
                {
                    break;
                }
                if ((MatKhau[i] >= 'A' && MatKhau[i] <= 'Z') || (MatKhau[i] >= 'a' && MatKhau[i] <= 'z'))
                {
                    kiemtrachu = true;

                }
                if (MatKhau[i] >= '0' && MatKhau[i] <= '9')
                {
                    kiemtraso = true;
                }
            }

                    if (kiemtraso == false || kiemtrachu == false)
                    {
                        return false; //không hợp lệ
                    }
            return true; // hoàn toàn hợp lệ    
                }
           
                  
            }


        }
        
    

