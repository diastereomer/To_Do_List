﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Models;
using To_Do_List.ViewModels;
using To_Do_List.Views;
using To_Do_List.Commands;

namespace To_Do_List.Infrastructures
{
    public class Factory
    {
        public Infrastructure Create(string function)
        {

            if (function == "login")
            {
                LogIn _view = new LogIn();
                ModelEntities _entity = new ModelEntities();
                LoginCommand loginCommand = new LoginCommand(_view);
                RegisterCommand registerCommand = new RegisterCommand(_view);
                ViewModel _viewModel = new ViewModel(_entity, loginCommand.Command, registerCommand.Command);
                loginCommand.ViewModel = _viewModel;
                registerCommand.ViewModel = _viewModel;
                return new Infrastructure(_view, _viewModel, _entity);
            }
            if (function == "item")
            {
                ItemViews _view = new ItemViews();
                ModelEntities _entity = new ModelEntities();
                LoginCommand loginCommand = new LoginCommand(_view);
                RegisterCommand registerCommand = new RegisterCommand(_view);
                ViewModel _viewModel = new ViewModel(_entity, loginCommand.Command, registerCommand.Command);
                loginCommand.ViewModel = _viewModel;
                registerCommand.ViewModel = _viewModel;
                return new Infrastructure(_view, _viewModel, _entity);
            }
            else return null;
        }
        public Infrastructure Create(ModelEntities entity, string function)
        {
            if (function == "item")
            {
                ItemViews _view = new ItemViews();
                SelectionCommand selectionCommand = new SelectionCommand(_view);
                UpdateItemCommand updateItemCommand = new UpdateItemCommand(_view);
                AddItemCommand addItemCommand = new AddItemCommand(_view);
                ViewModel _viewModel = new ViewModel(entity, selectionCommand.Command, updateItemCommand.Command, addItemCommand.Command);
                selectionCommand.ViewModel = _viewModel;
                updateItemCommand.ViewModel = _viewModel;
                addItemCommand.ViewModel = _viewModel;
                return new Infrastructure(_view, _viewModel, entity);
            }
            else return null;
        }
    }
}
