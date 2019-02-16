using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.ViewModels;
using To_Do_List.Views;

namespace To_Do_List.Commands
{
    class UpdateItemCommand
    {
        public DelegateCommand Command { get; private set; }
        public ViewModel ViewModel { get; set; }
        internal object _view;
        public UpdateItemCommand(object view)
        {
            _view = view;
            this.Command = new DelegateCommand(this.Execute, this.CanExec);
        }

        public void Execute(object unused)
        {
            Library library = new Library();
            library.Update(_view, ViewModel);
        }

        public bool CanExec(object unused)
        {
            return true;
        }
    }
}
