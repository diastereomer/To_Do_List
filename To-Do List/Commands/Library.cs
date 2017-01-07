using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using To_Do_List.Views;
using To_Do_List.ViewModels;
using System.Windows.Forms;

namespace To_Do_List.Commands
{
    internal class Library
    {
        internal bool CanLogin(object view, ViewModel viewModel)
        {
            LogIn login = view as LogIn;
            string userName = login.Username.Text;
            string passWord = login.Password.Password;
            return (viewModel.Model.Users.Where(s => s.UserName == userName && s.Password == passWord).Count()>0);
        }
        internal bool CanRegister(object view, ViewModel viewModel)
        {
            LogIn login = view as LogIn;
            bool x = (login.PassWordR.Password == login.PassWordRM.Password);
            if (!x)
            {
                System.Windows.Forms.MessageBox.Show("PassWord do not match!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return x;
        }
        internal void Register(object view, ViewModel viewModel)
        {
            LogIn login = view as LogIn;
            viewModel.Model.Users.Add(new Models.User()
            {
                UserFullName = login.FullName.Text,
                UserName = login.UserNameR.Text,
                Password = login.PassWordR.Password,
                IsActive = true,
                UserGroup = login.UserGroup.Text
            });
            viewModel.Model.SaveChanges();
        }
    }
    
}
