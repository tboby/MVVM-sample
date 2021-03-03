using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MVVM_exp
{
    public class MyListItemViewModel : ObservableObject
    {
        private int _myNumber;

        public int MyNumber
        {
            get => _myNumber;
            set => SetProperty(ref _myNumber, value);
        }

        private string _myString;

        public string MyString
        {
            get => _myString;
            set => SetProperty(ref _myString, value);
        }
    }
}
