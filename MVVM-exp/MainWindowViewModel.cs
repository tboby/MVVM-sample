using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MVVM_exp
{
    public class MainWindowViewModel : ObservableObject
    {
        private ImageControlViewModel _imageControlViewModel;
        private AnnotationListControlViewModel _annotationListControlViewModel;
        public ICommand NextImageCommand { get; }

        public ImageControlViewModel ImageControlViewModel
        {
            get => _imageControlViewModel;
            set => SetProperty(ref _imageControlViewModel, value);
        }

        public AnnotationListControlViewModel AnnotationListControlViewModel
        {
            get => _annotationListControlViewModel;
            set => SetProperty(ref _annotationListControlViewModel, value);
        }


        public MainWindowViewModel()
        {
            var gif = new GifBundleViewModel();
            ImageControlViewModel = new ImageControlViewModel(gif);
            AnnotationListControlViewModel = new AnnotationListControlViewModel(gif);
            NextImageCommand = gif.NextImageCommand;
        }
    }
}
