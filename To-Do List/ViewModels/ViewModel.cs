using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Models;
using System.ComponentModel;
using System.Windows.Input;

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
        
        public ICommand UserRelate { get; private set; }
        public ICommand ItemRelated { get; private set; }
        public ViewModel(ModelEntities model, ICommand userRelate=null, ICommand itemRelated=null)
        {
            
            _model = model;
            UserRelate = userRelate;
            ItemRelated = itemRelated;
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

    }
}
