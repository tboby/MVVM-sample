using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MVVM_exp
{
    public class MyListViewModel : ObservableObject
    {
        private ObservableCollection<MyListItemViewModel> _myItems;

        public ObservableCollection<MyListItemViewModel> MyItems
        {
            get => _myItems;
            set => SetProperty(ref _myItems, value);
        }

        public MyListViewModel()
        {
            MyItems = new ObservableCollection<MyListItemViewModel>();
            MyItems.Add(new MyListItemViewModel(){MyNumber = 5, MyString = "Five"});
            MyItems.Add(new MyListItemViewModel(){MyNumber = 8, MyString = "Eight"});
        }
    }
}
