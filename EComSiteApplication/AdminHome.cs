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
    public partial class AdminHome : Form
    {

        string id;
        int i;

        internal AdminRepository ar = new AdminRepository();
        EmployeeRepository er = new EmployeeRepository();

        internal Admin a = new Admin();

        List<Employee> EmployeeList = new List<Employee>();
        internal List<Admin> AdminList = new List<Admin>();



        public AdminHome()
        {
            InitializeComponent();
        }


        public AdminHome(Admin a)
        {
            InitializeComponent();
            this.a = a;

            LoadProfileInfo();

            AdminList = ar.GetAllAdmin();
            this.AdminGridView.DataSource = AdminList;
            AdminGridView.Columns[6].Visible = false;
            AdminGridView.Columns[7].Visible = false;

            EmployeeList = er.GetAllEmployee();
            this.EmployeeGridView.DataSource = EmployeeList;
            //EmployeeGridView.Columns[9].Visible = false;
            //EmployeeGridView.Columns[10].Visible = false;

            this.EmployeeGridView1.DataSource = EmployeeList;
            //EmployeeGridView1.Columns[9].Visible = false;
            //EmployeeGridView1.Columns[10].Visible = false;



            foreach (Employee empl in EmployeeList)
            {
                comboBox1.Items.Add(empl.ID);
            }



        }

        void LoadProfileInfo()
        {
            id = ar.getAdminId(a.Username);
            a = ar.GetAdmin(id);
            label16.Text = a.Name;
            label15.Text = a.ID;
            label14.Text = a.DOB;
            label13.Text = a.Gender;
            label12.Text = a.Email;
            label11.Text = a.ContactNo;
            label10.Text = a.Username;
            label9.Text = a.Password;


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }



        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "")
            { MessageBox.Show("Kindly Fill Up All The Fields!", "Error"); }

            else
            {
                Admin ad = new Admin();
                AdminRepository adRepo = new AdminRepository();

                ad.Name = this.textBox16.Text;
                ad.ID = this.textBox15.Text;
                ad.DOB = this.textBox14.Text;
                ad.Gender = this.textBox13.Text;
                ad.Email = this.textBox12.Text;
                ad.ContactNo = this.textBox11.Text;
                ad.Username = this.textBox10.Text;
                ad.Password = this.textBox9.Text;

                if (adRepo.Insert(ad))
                {
                    List<Admin> adlst = adRepo.GetAllAdmin();
                    this.AdminGridView.DataSource = adlst;

                    AdminGridView.Columns[6].Visible = false;
                    AdminGridView.Columns[7].Visible = false;

                    textBox16.Text = "";
                    textBox15.Text = "";
                    textBox14.Text = "";
                    textBox13.Text = "";
                    textBox12.Text = "";
                    textBox11.Text = "";
                    textBox10.Text = "";
                    textBox9.Text = "";


                }
                else
                {
                    MessageBox.Show("Insert Not Complete!", "Error");
                }

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox17.Text == "" || textBox18.Text == "" || textBox19.Text == "")
            { MessageBox.Show("Kindly Fill Up All The Fields!", "Error"); }

            else
            {
                Employee emp = new Employee();
                EmployeeRepository empRepo = new EmployeeRepository();

                emp.Name = this.textBox1.Text;
                emp.ID = this.textBox2.Text;
                emp.DOB = this.textBox3.Text;
                emp.Gender = this.textBox4.Text;
                emp.Email = this.textBox5.Text;
                emp.ContactNo = this.textBox6.Text;
                emp.Salary = Convert.ToDouble(this.textBox19.Text);
                emp.Type = this.textBox18.Text;
                emp.Address = this.textBox17.Text;
                emp.Username = this.textBox8.Text;
                emp.Password = this.textBox7.Text;

                if (empRepo.Insert(emp))
                {
                    List<Employee> emplst = empRepo.GetAllEmployee();
                    this.EmployeeGridView.DataSource = emplst;

                    //EmployeeGridView.Columns[9].Visible = false;
                    //EmployeeGridView.Columns[10].Visible = false;

                    this.EmployeeGridView1.DataSource = emplst;
                    //EmployeeGridView1.Columns[9].Visible = false;
                    //EmployeeGridView1.Columns[10].Visible = false;

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox17.Text = "";
                    textBox18.Text = "";
                    textBox19.Text = "";


                }
                else
                {
                    MessageBox.Show("Insert Not Complete!", "Error");
                }


            }
        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee em = new Employee();
            string s = comboBox1.SelectedItem.ToString();
            em = er.GetEmployee(s);

            textBox29.Text = em.Name;
            textBox28.Text = em.DOB;
            textBox27.Text = em.Gender;
            textBox26.Text = em.Email;
            textBox25.Text = em.ContactNo;
            textBox22.Text = em.Salary.ToString();
            textBox21.Text = em.Type;
            textBox20.Text = em.Address;
            textBox23.Text = em.Username;
            textBox24.Text = em.Password;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "" || textBox29.Text == "" || textBox28.Text == "" || textBox27.Text == "" || textBox26.Text == "" || textBox25.Text == "" || textBox24.Text == "" || textBox23.Text == "" || textBox22.Text == "" || textBox21.Text == "" || textBox21.Text == "")
            { MessageBox.Show("Kindly Choose An ID!", "Error"); }

            else
            {
                if (er.Delete(comboBox1.SelectedItem.ToString()))
                {
                    EmployeeList = er.GetAllEmployee();
                    this.EmployeeGridView.DataSource = EmployeeList;
                    //EmployeeGridView.Columns[9].Visible = false;
                    //EmployeeGridView.Columns[10].Visible = false;

                    this.EmployeeGridView1.DataSource = EmployeeList;
                    //EmployeeGridView1.Columns[9].Visible = false;
                    //EmployeeGridView1.Columns[10].Visible = false;


                    comboBox1.Items.Clear();

                    foreach (Employee empl in EmployeeList)
                    {
                        comboBox1.Items.Add(empl.ID);
                    }

                    textBox29.Text = "";
                    textBox28.Text = "";
                    textBox27.Text = "";
                    textBox26.Text = "";
                    textBox25.Text = "";
                    textBox24.Text = "";
                    textBox23.Text = "";
                    textBox22.Text = "";
                    textBox21.Text = "";
                    textBox20.Text = "";

                    MessageBox.Show("Deletion Complete!", "Success!!");

                }


                else
                {
                    MessageBox.Show("Deletion Not Complete!", "Error");
                }

            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "" || textBox29.Text == "" || textBox28.Text == "" || textBox27.Text == "" || textBox26.Text == "" || textBox25.Text == "" || textBox24.Text == "" || textBox23.Text == "" || textBox22.Text == "" || textBox21.Text == "" || textBox21.Text == "")
            { MessageBox.Show("Kindly Choose An ID!", "Error"); }

            else
            {
                Employee emp1 = new Employee();
                //emp1 = er.GetEmployee(comboBox1.SelectedItem.ToString());
                emp1.ID = comboBox1.SelectedItem.ToString();
                emp1.Name = textBox29.Text;
                emp1.DOB = textBox28.Text;
                emp1.Gender = textBox27.Text;
                emp1.Email = textBox26.Text;
                emp1.ContactNo = textBox25.Text;
                emp1.Salary = Convert.ToDouble(textBox22.Text);
                emp1.Type = textBox21.Text;
                emp1.Address = textBox20.Text;
                emp1.Username = textBox23.Text;
                emp1.Password = textBox24.Text; 

                if (er.Update(emp1))
                {
                    EmployeeList = er.GetAllEmployee();
                    this.EmployeeGridView.DataSource = EmployeeList;
                    //EmployeeGridView.Columns[9].Visible = false;
                    //EmployeeGridView.Columns[10].Visible = false;

                    this.EmployeeGridView1.DataSource = EmployeeList;
                    //EmployeeGridView1.Columns[9].Visible = false;
                    //EmployeeGridView1.Columns[10].Visible = false;


                    comboBox1.Items.Clear();
                    foreach (Employee empl in EmployeeList)
                    {
                        comboBox1.Items.Add(empl.ID);
                    }

                    textBox29.Text = "";
                    textBox28.Text = "";
                    textBox27.Text = "";
                    textBox26.Text = "";
                    textBox25.Text = "";
                    textBox24.Text = "";
                    textBox23.Text = "";
                    textBox22.Text = "";
                    textBox21.Text = "";
                    textBox20.Text = "";

                    MessageBox.Show("Update Complete!", "Success!!");
                }


                else
                {
                    MessageBox.Show("Updating Not Complete!", "Error");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminUpdateProfile aup = new AdminUpdateProfile(this);
            aup.Show();
        }
    }
}
    


