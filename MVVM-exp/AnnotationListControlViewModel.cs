using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MVVM_exp
{
    public class AnnotationListControlViewModel : ObservableObject
    {
        private List<string> _annotations;

        public List<string> Annotations
        {
            get => _annotations;
            set => SetProperty(ref _annotations, value);
        }

        private GIF _gif;

        public AnnotationListControlViewModel(GIF gif)
        {
            _gif = gif;
            _annotations = gif.Annotations;
        }

        public string TabName => "Annotations";
    }
}
