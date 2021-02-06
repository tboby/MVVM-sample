using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MVVM_exp
{
    public class ImageControlViewModel : ObservableObject
    {
        public BitmapFrame CurrentBitmapFrame
        {
            get => _currentBitmapFrame;
            set => SetProperty(ref _currentBitmapFrame, value);
        }

        public int CurrentFrameIndex
        {
            get => _currentFrameIndex;
            set => SetProperty(ref _currentFrameIndex, value);
        }
        public ICommand ButtonCommand { get; set; }

        private GIF gif;
        private BitmapFrame _currentBitmapFrame;
        private int _currentFrameIndex;

        public ImageControlViewModel(GIF gif)
        {
            this.gif = gif;
            CurrentFrameIndex = 0;
            RedrawImage();
            ButtonCommand = new RelayCommand(() =>
            {
                if (CurrentFrameIndex + 1 == gif.Frames.Count)
                {
                    CurrentFrameIndex = 0;
                }
                else
                {
                    CurrentFrameIndex ++ ;
                }
                RedrawImage();
            });

        }

        public void RedrawImage()
        {
            CurrentBitmapFrame = gif.Frames.ElementAt(CurrentFrameIndex);
        }

    }
}
