using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dangnhapjed
{
    public partial class Home : Form
    {
        private Button currenButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public Home()
        {
            InitializeComponent();
           random = new Random();
            btnCloseChidom.Visible = false;
            this.Text = string .Empty;
            this.ControlBox = false;
            this.MaximizedBounds =Screen.FromHandle(this.Handle).WorkingArea;   
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);


        private Color SelectThemecolor()
        {
            int index = random.Next(Themecolor.colorList.Count);
            while(tempIndex == index)
            {
              index=  random.Next(Themecolor.colorList.Count);
            }
            tempIndex = index;
            string color = Themecolor.colorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnsender)
        {
            if(btnsender != null) { 
             if(currenButton != (Button)btnsender)
                {
                    DisableButon();
                    Color color = SelectThemecolor();
                    currenButton = (Button)btnsender;
                    currenButton.BackColor = color;
                    currenButton.ForeColor = Color.Yellow;   
                    currenButton.Font =  new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                    panelTilebard.BackColor = color;
                    panelLogo.BackColor = Themecolor.ChangeColorBirght(color , -0.3);
                    Themecolor.primarycolor = color;
                    Themecolor.secondarycolor = Themecolor.ChangeColorBirght(color, -0.3);
                    btnCloseChidom.Visible = true;
                }
            
            }
        }
        private void DisableButon()
        {
            foreach (Control previousbtn in panelmenu.Controls)
            {
                if(previousbtn.GetType() == typeof(Button))
                {
                    previousbtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousbtn.ForeColor = Color.Gainsboro;
                    previousbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                    
                }
            }
        }
        private void OpenChildFrom(Form chidorm,object btnsender)
        {
            if (activeForm!= null) 
            { 
            
                activeForm.Close();
            
            
            }
            ActivateButton(btnsender);
            activeForm = chidorm;
            chidorm.TopLevel =false;
            chidorm.FormBorderStyle = FormBorderStyle.None;
            chidorm.Dock = DockStyle.Fill;
            this.panelDestop.Controls.Add(chidorm);
            this.panelDestop.Tag = chidorm;
            chidorm.BringToFront();
            chidorm.Show();
            labeHome.Text = chidorm.Text;

        }
       

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Froms.Homea(), sender);
        }

        private void btnThucdon_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Froms.ThucDona(), sender);
        }

        private void btnonlien_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Froms.DatbanonlineA(), sender);
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Froms.NhanvienA(), sender);
        }

        private void btntintuc_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Froms.tintucA(), sender);
        }

        private void btnAcount_Click(object sender, EventArgs e)
        {
            OpenChildFrom(new Froms.AcountA(), sender);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void labeHome_Click(object sender, EventArgs e)
        {

        }

        private void labelJolibee_Click(object sender, EventArgs e)
        {

        }

        private void panelTilebard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClosechidom_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseChidom_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
                
        }
             private void Reset() { 
            {
                DisableButon();
                labeHome.Text = "HOME";
                panelTilebard.BackColor = Color.FromArgb(255, 0, 0);
                panelLogo.BackColor = Color.FromArgb(39, 39, 58);
                currenButton = null;
                btnCloseChidom.Visible = false;
            }
        }

        private void panelTilebard_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112,0xf012,0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaxisize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void Minsize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
