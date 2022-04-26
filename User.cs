using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTechManagementApp.GUI
{
    public class User
    {
        public string UserName { get; set; }
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int JobId { get; set; }
        public int StatusId { get; set; }

        public User(string UserName, int EmployeeId, string Password, string FirstName, string LastName, string PhoneNumber, string Email, int JobId, int StatusId)
        {
            this.UserName = UserName;
            this.EmployeeId = EmployeeId;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.JobId = JobId;
            this.StatusId = StatusId;

        }



    }
}
