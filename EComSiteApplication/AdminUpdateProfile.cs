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
    public partial class AdminUpdateProfile : Form
    {

        AdminHome ah = new AdminHome ();
        AdminRepository ar = new AdminRepository();

        public AdminUpdateProfile(AdminHome ah)
        {
            InitializeComponent();

            this.ah = ah;

            textBox16.Text = ah.a.Name;
            textBox15.Text = ah.a.DOB;
            textBox14.Text = ah.a.Gender;
            textBox13.Text = ah.a.Email;
            textBox12.Text = ah.a.ContactNo;
            textBox11.Text = ah.a.Username;
            textBox10.Text = ah.a.Password;

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ( textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "")
            { MessageBox.Show("Kindly Fill Up All The Fields!", "Error"); }
            else
            {

                Admin admin = new Admin();

                List<Admin> adlst = new List<Admin>();

                admin.Name = textBox16.Text ;
                admin.ID = ah.a.ID ;
                admin.DOB = textBox15.Text ;
                admin.Gender = textBox14.Text ;
                admin.Email = textBox13.Text ;
                admin.ContactNo = textBox12.Text ;
                admin.Username = textBox11.Text ;
                admin.Password = textBox10.Text ;

                if(ar.Update(admin))
                {
                    ah.label16.Text = textBox16.Text;
                    ah.label14.Text = textBox15.Text;
                    ah.label13.Text = textBox14.Text;
                    ah.label12.Text = textBox13.Text;
                    ah.label11.Text = textBox12.Text;
                    ah.label10.Text = textBox11.Text;
                    ah.label9.Text = textBox10.Text;


                    ah.a.Name = textBox16.Text;
                    ah.a.ID = ah.a.ID;
                    ah.a.DOB = textBox15.Text;
                    ah.a.Gender = textBox14.Text;
                    ah.a.Email = textBox13.Text;
                    ah.a.ContactNo = textBox12.Text;
                    ah.a.Username = textBox11.Text;
                    ah.a.Password = textBox10.Text;






                    adlst = ar.GetAllAdmin();
                    this.ah.AdminGridView.DataSource = adlst;
                    ah.AdminGridView.Columns[6].Visible = false;
                    ah.AdminGridView.Columns[7].Visible = false;

                    this.Hide();

                    MessageBox.Show("Update Complete!", "Success!!!");
                }

                else
                {
                    MessageBox.Show("Update Failed!!!", "Error!");
                }

            }
        }
    }
}
