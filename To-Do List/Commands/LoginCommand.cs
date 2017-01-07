using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.ViewModels;
using System.Windows.Forms;
using System.Windows;
using To_Do_List.Commands;
namespace To_Do_List.Commands
{
    public class LoginCommand
    {
        public DelegateCommand Command { get; private set; }
        public ViewModel ViewModel { get; set; }
        internal object _view;
        public LoginCommand( object view)
        {
            _view = view;
            this.Command = new DelegateCommand(this.Execute, this.CanExec);
        }

        public void Execute(object unused)
        {
            Library library = new Library();
            if (library.CanLogin(_view, this.ViewModel))
            { }
            else System.Windows.Forms.MessageBox.Show("Username and Password do not match!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool CanExec(object unused)
        {
            return true;
        }
    }
}
