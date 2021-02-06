using System;
using Gif.Core.Models;

namespace GifCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var gifBundle = new GifBundle();
            foreach (var gif in gifBundle.GIFs)
            {
                Console.Out.WriteLine($"Gif length {gif.Frames.Count}");
                for (int i = 0; i < gif.Annotations.Count; i++)
                {
                    Console.Out.WriteLine($"{i}: {gif.Annotations[i]}");
                }
            }
        }
    }
}
