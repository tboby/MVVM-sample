using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
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
        public ImageSource CurrentBitmapFrame
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

        public string NewAnnotationText
        {
            get => _newAnnotationText;
            set => SetProperty(ref _newAnnotationText, value);
        }

        public ICommand SaveAnnotationCommand { get; set; }

        private GIF gif;
        private ImageSource _currentBitmapFrame;
        private int _currentFrameIndex;
        private string _newAnnotationText;

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
                    CurrentFrameIndex++;
                }
                RedrawImage();
            });
            SaveAnnotationCommand = new RelayCommand(() =>
            {
                gif.Annotations[CurrentFrameIndex] = NewAnnotationText;
                RedrawImage();
            });

        }

        public void RedrawImage()
        {
            var bitmapSource = gif.Frames.ElementAt(CurrentFrameIndex);
            var currentAnnotation = gif.Annotations.ElementAt(CurrentFrameIndex);

            var visual = new DrawingVisual();
            using (DrawingContext drawingContext = visual.RenderOpen())
            {
                drawingContext.DrawImage(bitmapSource, new Rect(0, 0, bitmapSource.PixelWidth, bitmapSource.PixelHeight));
                drawingContext.DrawText(
                    new FormattedText(currentAnnotation, CultureInfo.InvariantCulture, FlowDirection.LeftToRight,
                        new Typeface("Segoe UI"), 32, Brushes.Black, 1.0), new Point(0, 0));
            }
            CurrentBitmapFrame = new DrawingImage(visual.Drawing);
        }

    }
}
