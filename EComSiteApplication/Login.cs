using System;
using EComSiteRepository;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EComSiteApplication
{
    public partial class Login : Form
    {
        

        public Login()
        {
            InitializeComponent();
        }

        private void ExitBtnClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtnClicked(object sender, EventArgs e)
        {
           
            Admin a = new Admin();
            a.Username = this.idTBox.Text;
            a.Password = this.passTBox.Text;

            AdminRepository ar = new AdminRepository();
            if (ar.AdminLoginVerification(a))
            {
                
                AdminHome ah = new AdminHome(a);
                ah.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid ID or Password", "Login Failed");
            }

         
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
