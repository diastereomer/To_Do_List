using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.ViewModels;
using System.Windows.Forms;
using System.Linq.Expressions;
using To_Do_List.Models;


namespace To_Do_List.Commands
{
    public class SelectionCommand
    {
        public DelegateCommand Command { get; private set; }
        public ViewModel ViewModel { get; set; }
        internal object _view;
        public SelectionCommand(object view)
        {
            _view = view;
            this.Command = new DelegateCommand(this.Execute, this.CanExec);
        }

        public void Execute(object unused)
        {
            Library library = new Library();
            Expression<Func<Item, bool>> x = library.GetCriteria(_view);
            ViewModel.itemExpression = x;
            ViewModel.GetItems();
        }

        public bool CanExec(object unused)
        {
            return true;
        }
    }
}
