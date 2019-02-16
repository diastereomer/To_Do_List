using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.ViewModels;

namespace To_Do_List.Commands
{
    public class AddItemCommand
    {
        public DelegateCommand Command { get; private set; }
        public ViewModel ViewModel { get; set; }
        internal object _view;
        public AddItemCommand(object view)
        {
            _view = view;
            this.Command = new DelegateCommand(this.Execute, this.CanExec);
        }

        public void Execute(object unused)
        {
            Library library = new Library();
            library.Add(_view, ViewModel);
        }

        public bool CanExec(object unused)
        {
            return true;
        }
    }
}
