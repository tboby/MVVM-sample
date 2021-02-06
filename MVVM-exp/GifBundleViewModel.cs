using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MVVM_exp.Models;

namespace MVVM_exp
{
    public class GifBundleViewModel : ObservableObject
    {
        private GIF _currentGif;

        public GIF CurrentGIF
        {
            get => _currentGif;
            set => SetProperty(ref _currentGif, value);
        }

        public ICommand NextImageCommand { get; }

        private GifBundle _gifBundle;
        public GifBundleViewModel()
        {
            _gifBundle = new GifBundle();
            NextImageCommand = new RelayCommand(NextImage);
            CurrentGIF = _gifBundle.GIFs[0];
        }

        public void NextImage()
        {
            var currentIndex = _gifBundle.GIFs.IndexOf(CurrentGIF);
            if (currentIndex + 1 >= _gifBundle.GIFs.Count)
            {
                CurrentGIF = _gifBundle.GIFs[0];
            }
            else
            {
                CurrentGIF = _gifBundle.GIFs[currentIndex + 1];
            }
        }
    }
}
