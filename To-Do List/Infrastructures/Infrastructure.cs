using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Models;
using To_Do_List.ViewModels;
using To_Do_List.Views;
using System.Windows;

namespace To_Do_List.Infrastructures
{
    public class Infrastructure
    {
        public Window View { get; private set; }
        public ViewModel ViewModel { get; private set; }
        public ModelEntities Entity { get; private set; }
        public Infrastructure(Window view, ViewModel viewModel, ModelEntities entity)
        {
            View = view;
            ViewModel = viewModel;
            Entity = entity;
        }
    }
}
