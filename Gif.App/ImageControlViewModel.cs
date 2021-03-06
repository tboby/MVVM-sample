﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Gif.Core.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Gif.App
{
    public class ImageControlViewModel : ObservableObject
    {
        private ImageSource _currentBitmapFrame;
        public ImageSource CurrentBitmapFrame
        {
            get => _currentBitmapFrame;
            set => SetProperty(ref _currentBitmapFrame, value);
        }

        private int _currentFrameIndex;
        public int CurrentFrameIndex
        {
            get => _currentFrameIndex;
            set => SetProperty(ref _currentFrameIndex, value);
        }
        public ICommand NextFrameCommand { get; }

        private string _newAnnotationText;
        public string NewAnnotationText
        {
            get => _newAnnotationText;
            set => SetProperty(ref _newAnnotationText, value);
        }

        public ICommand SaveAnnotationCommand { get; }

        private readonly GifBundleViewModel _gifBundleViewModel;
        private GIF CurrentGif => _gifBundleViewModel.CurrentGIF;

        public ImageControlViewModel(GifBundleViewModel gifBundleViewModel)
        {
            _gifBundleViewModel = gifBundleViewModel;
            NextFrameCommand = new RelayCommand(NextFrame);
            SaveAnnotationCommand = new RelayCommand(SaveAnnotation);
            gifBundleViewModel.PropertyChanged += GifBundleViewModelOnPropertyChanged;

            ResetImage();
        }

        private void GifBundleViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var action = e.PropertyName switch
            {
                nameof(GifBundleViewModel.CurrentGIF) => ResetImage,
                _ => (Action)(() => {})
            };
            action();
        }

        public void ResetImage()
        {
            CurrentFrameIndex = 0;
            RedrawImage();
        }

        public void RedrawImage()
        {
            var bitmapSource = CurrentGif.Frames.ElementAt(CurrentFrameIndex);
            var currentAnnotation = CurrentGif.Annotations.ElementAt(CurrentFrameIndex);

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

        public void SaveAnnotation()
        {
            CurrentGif.Annotations[CurrentFrameIndex] = NewAnnotationText;
            RedrawImage();
        }

        public void NextFrame()
        {
            if (CurrentFrameIndex + 1 == CurrentGif.Frames.Count)
            {
                CurrentFrameIndex = 0;
            }
            else
            {
                CurrentFrameIndex++;
            }
            RedrawImage();
        }

    }
}
