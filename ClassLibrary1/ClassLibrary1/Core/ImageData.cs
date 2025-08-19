using System;

namespace ClassLibrary1
{
    /// <summary>
    /// Lightweight, immutable image-like data structure used for simulation/testing.
    /// Stores a textual history to show which effects were executed.
    /// </summary>
    public sealed class ImageData
    {
        public ImageData(string name, int width, int height, string history)
        {
            Name = name;
            Width = width;
            Height = height;
            History = history;
        }

        public string Name { get; }
        public int Width { get; }
        public int Height { get; }
        public string History { get; }

        public ImageData With(int? width = null, int? height = null, string? appendHistory = null)
        {
            var newWidth = width ?? Width;
            var newHeight = height ?? Height;
            var newHistory = string.IsNullOrWhiteSpace(appendHistory) ? History : (History + " -> " + appendHistory);
            return new ImageData(Name, newWidth, newHeight, newHistory);
        }

        public override string ToString()
        {
            return $"{Name} [{Width}x{Height}] :: {History}";
        }
    }
}


