using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTech.Business;
using HiTech.Validation;

namespace HiTechManagementApp.GUI
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
        }

        private void buttonSaveEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            if ((Validator.IsValidId(textBoxEmployeeId.Text, 4)) &&
                 (Validator.IsValidName(textBoxFirstName.Text)) &&
                 (Validator.IsValidName(textBoxLastName.Text)) &&
                 (!(emp.IdExists(Convert.ToInt32(textBoxEmployeeId.Text)))))
            {

                emp.EmployeeId = Convert.ToInt32(textBoxEmployeeId.Text);
                emp.FirstName = textBoxFirstName.Text;
                emp.LastName = textBoxLastName.Text;
                emp.JobTitle = textBoxJobTitle.Text;             
                emp.SaveEmployee(emp);
                MessageBox.Show("Employee Info has been saved successfully.", "Confirmation");

            }
            else
            {
                string input = "";
                input = textBoxEmployeeId.Text.Trim();
                if (!Validator.IsValidId(input, 4))
                {
                    MessageBox.Show("Invalid Employee ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmployeeId.Clear();
                    textBoxEmployeeId.Focus();
                    return;
                }

                if (emp.IdExists(Convert.ToInt32(input)))
                {
                    MessageBox.Show("Employee ID already exists!", "Duplicate Employee ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxEmployeeId.Clear();
                    textBoxEmployeeId.Focus();
                    return;
                }


            }


        }

        private void buttonListAllEmployees_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
           List<Employee> listEmp = emp.GetEmployeeList();
            listViewEmployee.Items.Clear();

            foreach (Employee anEmp in listEmp)
            {
               
                ListViewItem item = new ListViewItem(anEmp.EmployeeId.ToString());
                item.SubItems.Add(anEmp.FirstName);
                item.SubItems.Add(anEmp.LastName);
                item.SubItems.Add(anEmp.JobTitle);
                listViewEmployee.Items.Add(item);
            }

        }

        private void buttonSearchEmployee_Click(object sender, EventArgs e)
        {
            //check search Option selected
            if (comboBoxSearchOption.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the search option.", "Missing search option", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //input data validation
            string input = "";
            input = textBoxInput.Text.Trim();
            if (!Validator.IsValidId(input, 4))
            {
                MessageBox.Show("Invalid Employee ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxInput.Clear();
                textBoxInput.Focus();
                return;
            }
            Employee emp = new Employee();
            emp = emp.SearchEmployee(Convert.ToInt32(input));
            if (emp != null)
            {
                
                textBoxEmployeeId.Text = emp.EmployeeId.ToString();
                textBoxFirstName.Text = emp.FirstName;
                textBoxLastName.Text = emp.LastName;
                textBoxJobTitle.Text = emp.JobTitle;
              
                buttonUpdateEmployee.Enabled = true;
                buttonDelete.Enabled = true;

            }
            else
            {
                MessageBox.Show("Employee not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxInput.Clear();
                textBoxInput.Focus();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
