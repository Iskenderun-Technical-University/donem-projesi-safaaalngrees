using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using student_managment_system;

namespace student_management_system
{
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
            showDepartments();
        }

        private void showDepartments()
        {
            string query = "SELECT * FROM DepartmentTb1";
            Departmentslist.DataSource = Functions.GetData(query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text == "" || DetailsTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string dName = DepNameTb.Text;
                    string details = DetailsTb.Text;
                    string query = "INSERT INTO DepartmentTb1 (DepName, DepDetails) VALUES (@DepName, @DepDetails)";
                    var parameters = new Dictionary<string, object>()
                    {
                        { "@DepName", dName },
                        { "@DepDetails", details }
                    };
                    Functions.SetData(query, parameters);
                    showDepartments();
                    MessageBox.Show("Department Added!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Departmentslist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepNameTb.Text = Departmentslist.SelectedRows[0].Cells[1].Value.ToString();
            DetailsTb.Text = Departmentslist.SelectedRows[0].Cells[2].Value.ToString();
            if (DepNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Departmentslist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (DepNameTb.Text == "" || DetailsTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {
                try
                {
                    string dName = DepNameTb.Text;
                    string details = DetailsTb.Text;
                    string query = "UPDATE DepartmentTb1 SET DepName = @DepName, DepDetails = @DepDetails WHERE DepId = @DepId";
                    var parameters = new Dictionary<string, object>()
                    {
                        { "@DepName", dName },
                        { "@DepDetails", details },
                        { "@DepId", key }
                    };
                    Functions.SetData(query, parameters);
                    showDepartments();
                    MessageBox.Show("Department Updated!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private int key = 0;
    }
}