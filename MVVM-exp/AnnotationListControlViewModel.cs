using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Gif.Core.Models;
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

        private GifBundleViewModel _gifBundleViewModel;
        private GIF CurrentGif => _gifBundleViewModel.CurrentGIF;

        public AnnotationListControlViewModel(GifBundleViewModel gifBundleViewModel)
        {
            _gifBundleViewModel = gifBundleViewModel;
            _annotations = CurrentGif.Annotations;
            _gifBundleViewModel.PropertyChanged += GifBundleViewModelOnPropertyChanged;
        }

        private void GifBundleViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var action = e.PropertyName switch
            {
                nameof(GifBundleViewModel.CurrentGIF) => (() => { Annotations = CurrentGif.Annotations;}),
                _ => (Action)(() => {})
            };
            action();
        }
    }
}
