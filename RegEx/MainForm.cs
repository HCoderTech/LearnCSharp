using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegEx
{
    public partial class MainForm : Form
    {
        Dictionary<string, string> Errors = new Dictionary<string, string>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            string name_regex = @"^[A-Z][a-z]+\s[A-Z][a-z]+$";
            if(!RegexValidator.IsPatternMatch(name_regex, txtName.Text))
            {
                Errors["Name"] = "Name should have First Name and LastName, caps at the start and space in between";
            }
            else
            {
                if (Errors.ContainsKey("Name"))
                    Errors.Remove("Name");
            }

            ReloadValidations();
        }

        private void ReloadValidations()
        {
            txtValidationMessage.Text = "";
            string error = string.Empty;
            foreach(string key in Errors.Keys)
            {
                error += Errors[key] + "\n";
            }
            txtValidationMessage.Text = error;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            //+91 9776677888
            string phone_regex = @"^\+91[6789][0-9]{9}$";
            if (!RegexValidator.IsPatternMatch(phone_regex, txtPhone.Text))
            {
                Errors["Phone"] = "Phone number should start with +91 and should have 10 digits";
            }
            else
            {
                if (Errors.ContainsKey("Phone"))
                    Errors.Remove("Phone");
            }

            ReloadValidations();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string email_regex = @"^[A-Za-z0-9]{4,15}@[a-z]{4,10}\.(com|net)$";
            if (!RegexValidator.IsPatternMatch(email_regex, txtEmail.Text))
            {
                Errors["Email"] = ".com and .net emails are only valid";
            }
            else
            {
                if (Errors.ContainsKey("Email"))
                    Errors.Remove("Email");
            }

            ReloadValidations();
        }

        private void txtDOB_TextChanged(object sender, EventArgs e)
        {
            string dob_regex = @"^[0-9]{2}/[0-9]{2}/[0-9]{4}$";
            if (!RegexValidator.IsPatternMatch(dob_regex, txtDOB.Text))
            {
                Errors["DOB"] = "DOB not valid";
            }
            else
            {
                if (Errors.ContainsKey("DOB"))
                    Errors.Remove("DOB");
            }

            ReloadValidations();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string username_regex = @"^[A-Za-z0-9_]{5,15}$";
            if (!RegexValidator.IsPatternMatch(username_regex, txtUserName.Text))
            {
                Errors["username"] = "username not valid";
            }
            else
            {
                if (Errors.ContainsKey("username"))
                    Errors.Remove("username");
            }

            ReloadValidations();
        }

        private void txtValidationMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = RegexValidator.ExtractPattern(@"[A-Z][a-z]+\s", txtName.Text);
            txtValidationMessage.Text = firstName + "Registered";

            User user = new User();
            user.Name = txtName.Text;
            user.Phone = txtPhone.Text;
            user.UserName = txtUserName.Text;
            user.Email = txtEmail.Text;
            user.DOB = txtDOB.Text;
            user.SetUserID("123");
            user.Serialize("UserSaved.xml");
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            User user = User.Deserialze("UserSaved.xml");
            txtName.Text= user.Name;
            txtPhone.Text= user.Phone;
            txtUserName.Text= user.UserName;
            txtEmail.Text= user.Email;
            txtDOB.Text= user.DOB;
        }
    }
}
