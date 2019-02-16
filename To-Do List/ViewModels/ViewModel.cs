using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Models;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq.Expressions;
namespace To_Do_List.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ModelEntities _model;

        public ModelEntities Model
        {
            get { return _model; }
            set
            {
                if (this._model != value)
                {
                    this._model = value;
                    this.OnPropertyChanged("Model");
                }
            }
        }
        public List<string> UserGroups
        {
            get { return _model.Users.Select(s => s.UserGroup).Distinct().ToList(); }
        }
        public List<string> Users
        {
            get { return _model.Users.Select(s => s.UserName).Distinct().ToList() ; }
            
        }
        private List<Item> _items;
        public List<Item> Items
        {
            get { return _items; }
            set
            {
                if (this._items != value)
                {
                    this._items = value;
                    this.OnPropertyChanged("Items");
                }
            }
        }
        public List<string> Categories
        {
            get { return _model.Categories.Select(s=>s.CategoryDesc).ToList(); }
        }
        

        public Expression<Func<User, bool>> userExpression=null;
        public Expression<Func<Item, bool>> itemExpression = null;
        public ICommand UserRelate { get; private set; }
        public ICommand ItemRelated { get; private set; }

        public ICommand ItemRelated1 { get; private set; }
        public ViewModel(ModelEntities model, ICommand userRelate=null, ICommand itemRelated=null, ICommand itemRelated1 = null)
        {
            
            _model = model;
            UserRelate = userRelate;
            ItemRelated = itemRelated;
            ItemRelated1 = itemRelated1;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public List<User> GetUsers(Expression<Func<User,bool>> criteria=null)
        {
            if (criteria == null)
            {
                return _model.Users.ToList();
            }
            else
            return _model.Users.Where(criteria).ToList();
        }
        public void GetItems()
        {
            if (itemExpression == null)
            {
                Items= _model.Items.ToList();
            }
            else
                Items= _model.Items.Where(itemExpression).ToList();
        }
    }
}
