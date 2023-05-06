using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_management_system
{
    
    public partial class students : Form
    {
        Functions con;
        public students()
        {
            InitializeComponent();
            con = new Functions();
            showStudents();
            GetDepartment();

        }
        private void showStudents()
        {
            string Query = "select * from studentTb1";
            Studentslist.DataSource = Functions.GetData(Query);
        }
        private void GetDepartment()
        {
            string Query = "select * from DepartmentTb1";
            DepCb.DisplayMember = Functions.GetData(Query).Columns["DepName"].ToString();
            DepCb.ValueMember = Functions.GetData(Query).Columns["DepId"].ToString();
            DepCb.DataSource = Functions.GetData(Query);
        }
        private void clear()
        {
            StNameTb.Text = "";
            StPhoneTb.Text = "";
            StParentTb.Text = "";
            StAddTb.Text = "";
            GenCb.SelectedIndex = -1;
        }
        private void AddBtn_Click(object sender, EventArgs e)
        {
             if (StNameTb.Text == "" || StPhoneTb.Text == "" ||StParentTb.Text == "" ||StAddTb.Text == "" || DepCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1 )
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = StPhoneTb.Text;
                    string Parent = StParentTb.Text;
                    string Address = StAddTb.Text;
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "insert into StudentTb1 values ('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, TName, Gender,Phone,Parent,Address,Dep);
                    Functions.SetData(Query);
                    showStudents();
                    MessageBox.Show("Student Added !!!");
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;

        private void Studentslist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           StNameTb.Text = Studentslist.SelectedRows[0].Cells[1].Value.ToString();
           GenCb.SelectedItem = Studentslist.SelectedRows[0].Cells[2].Value.ToString();
           StPhoneTb.Text = Studentslist.SelectedRows[0].Cells[3].Value.ToString();
           StParentTb.Text = Studentslist.SelectedRows[0].Cells[4].Value.ToString();
           StAddTb.Text = Studentslist.SelectedRows[0].Cells[5].Value.ToString();
           DepCb.SelectedItem = Studentslist.SelectedRows[0].Cells[2].Value.ToString();

            if (StNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Studentslist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "" || StPhoneTb.Text == "" || StParentTb.Text == "" || StAddTb.Text == "" || DepCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = StPhoneTb.Text;
                    string Parent = StParentTb.Text;
                    string Address = StAddTb.Text;
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "Update StudentTb1 set StName = '{0}',StGen = '{1}',StPhone = '{2}',StParent = '{3}',StAdd = '{4}',StDepartment = {5} where StCode ={6}";
                    Query = string.Format(Query, TName, Gender, Phone, Parent, Address, Dep,key);
                    Functions.SetData(Query);
                    showStudents();
                    MessageBox.Show("Student Updated !!!");
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
         if(key == 0)
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string TName = StNameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Phone = StPhoneTb.Text;
                    string Parent = StParentTb.Text;
                    string Address = StAddTb.Text;
                    int Dep = Convert.ToInt32(DepCb.SelectedValue.ToString());
                    string Query = "Delete from StudentTb1 where StCode ={0}";
                    Query = string.Format(Query, key);
                    Functions.SetData(Query);
                    showStudents();
                    MessageBox.Show("Student Delete !!!");
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DepLb1_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }

        private void DashboardLb1_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Close();
        }

        private void label24_Click(object sender, EventArgs e)
        {
          Login Obj = new Login();
            Obj.Show();
            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void DepIb1_Click(object sender, EventArgs e)
        {
            Departments Obj = new Departments();
            Obj.Show();
            this.Close();
        }
    }
}
