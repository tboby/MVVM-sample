using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MVVM_exp
{

    public class GIF
    {
        public IReadOnlyCollection<BitmapFrame> Frames { get; set; }

        public GIF(string filename)
        {
            LoadImage(filename);
        }
        public void LoadImage(string filename)
        {
            var image = new GifBitmapDecoder(new Uri(new FileInfo(filename).FullName), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            Frames = image.Frames;
        }
    }
}
