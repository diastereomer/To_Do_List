using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using To_Do_List.Views;
using To_Do_List.ViewModels;
using System.Windows.Forms;
using System.Data;
using To_Do_List.Models;
using System.Linq.Expressions;
using System.Windows.Controls;

namespace To_Do_List.Commands
{
    internal class Library
    {
        internal Models.User CanLogin(object view, ViewModel viewModel)
        {
            LogIn login = view as LogIn;
            string userName = login.Username.Text;
            string passWord = login.Password.Password;
            return (viewModel.Model.Users.Where(s => s.UserName == userName && s.Password == passWord).FirstOrDefault());
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
        internal void ViewList(Models.ModelEntities entity)
        {
            Infrastructures.Factory factory = new Infrastructures.Factory();
            Infrastructures.Infrastructure infrastructure = factory.Create(entity, "item");
            infrastructure.ViewModel.GetItems();
            infrastructure.View.DataContext = infrastructure.ViewModel;
            infrastructure.View.Show();
        }
        internal Expression<Func<Item, bool>> GetCriteria(object view)
        {
            ItemViews _view = (ItemViews)view;
            string category = _view.Category.SelectedValue == null ? null : _view.Category.SelectedValue.ToString();
            string userGroup = _view.UserGroup.SelectedValue == null ? null : _view.UserGroup.SelectedValue.ToString();
            string status = _view.Status.SelectedItem == null ? null: ((ComboBoxItem)(_view.Status.SelectedItem)).Content.ToString();
            string dueDate = _view.DueIn.SelectedItem== null? null:((ComboBoxItem)(_view.DueIn.SelectedItem)).Content.ToString();
            double diff = dueDate != null?Convert.ToDouble(dueDate.Substring(0, 2).Trim()):0.0000;
            DateTime endDate = (dueDate!=null )?DateTime.Now.AddDays(diff):DateTime.Now.AddDays(1000);
            // Func<Item, bool> func =
            return s =>
          ((category != null ? s.Category.CategoryDesc == category : true)
                 && (userGroup != null ? s.User.UserGroup == userGroup : true)
                 && (bool)(status != null ? (status == "IsStarted" ? s.IsStarted :
                 (status == "IsDone" ? s.IsDone : s.IsClosed)) : true)
                 && (dueDate != null ? s.DueDate <= endDate : true)
                 );

            //return new System.Linq.Expressions.Expression();
        }

        internal void Update(object view, ViewModel viewModel)
        {
            viewModel.Model.SaveChanges();
        }
        internal void Add(object view, ViewModel viewModel)
        {
            ItemViews _view = (ItemViews)view;
            string userName = _view.AddAssign.SelectedValue.ToString();
            int userID = viewModel.Model.Users.Where(s => s.UserName == userName).Select(t => t.UserID).First();
            string category = _view.AddCategory.SelectedValue.ToString();
            int categoryID = viewModel.Model.Categories.Where(s => s.CategoryDesc == category).Select(t => t.CategoryID).First();
            viewModel.Model.Items.Add(new Models.Item()
            {
                CategoryID = categoryID,
                ItemDesc = _view.AddItem.Text,
                AssignedTo = userID,
                DueDate = Convert.ToDateTime(_view.AddDueDate.Text)
            });
            viewModel.Model.SaveChanges();
            int itemid = viewModel.Model.Items.Select(t => t.ItemID).OrderByDescending(u=>u).First();
            viewModel.Model.SubItems.Add(new Models.SubItem()
            {
                ItemID = itemid,
                SubItemDesc = _view.AddSubItem1.Text
            });
            viewModel.Model.SaveChanges();
            viewModel.Model.SubItems.Add(new Models.SubItem()
            {
                ItemID = itemid,
                SubItemDesc = _view.AddSubItem2.Text
            });
            viewModel.Model.SaveChanges();
            viewModel.GetItems();
            }
    }
}
