using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_exp.Models
{
    public class GifBundle
    {
        public List<GIF> GIFs { get; set; }

        public GifBundle()
        {
                GIFs = new List<GIF>();
                GIFs.Add(new GIF("recycle.gif"));
                GIFs.Add(new GIF("planet.gif"));
                GIFs.Add(new GIF("test.gif"));
        }
    }
}
