using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HiTechManagementApp.GUI
{
    public partial class LoginForm : Form
    {
        User[] Users = new User[5];
        public void _init_()
        {
            Users[0] = new User("henry", 1, "henryb", "Henry", "Brown", "", "", 1, 1);
            Users[1] = new User("thomas", 2, "tomm", "Thomas", "Moore", "", "", 2, 1);
            Users[2] = new User("peter", 3, "peterw", "Peter", "Wang", "", "", 3, 1);
            Users[3] = new User("mary", 4, "maryb", "Mary", "Brown", "", "", 4, 1);
            Users[4] = new User("jennifer", 5, "jenb", "Jennifer", "Bouchard", "", "", 4, 1);
        }
        public LoginForm()
        {
            InitializeComponent();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            _init_();
            //if ((textBoxUsername.Text == "" ) && (textBoxPassword.Text == "Henry") )
            User[] login = Users.Where(u => u.UserName == textBoxUsername.Text && u.Password == textBoxPassword.Text).ToArray();
            if (login != null && login.Length > 0)
            {
                this.Hide();
                FormEmployee empForm = new FormEmployee();
                empForm.ShowDialog();
            }
        }
    }
}
