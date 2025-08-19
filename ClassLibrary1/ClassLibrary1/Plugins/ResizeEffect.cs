using System;
using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Plugins
{
    /// <summary>
    /// Dummy resize: expects integer size (width), keeps aspect ratio by adjusting height proportionally.
    /// </summary>
    public sealed class ResizeEffect : IImageEffect
    {
        public string Id => "com.example.effects.resize";
        public string Name => "Resize";
        public string Description => "Resizes the image width to the given pixels (dummy).";
        public PluginParameterDefinition? Parameter => new PluginParameterDefinition("width", "Width (px)", PluginParameterKind.Integer, 1, 10000);

        public ImageData Apply(ImageData input, object? parameterValue)
        {
            int width = input.Width;
            if (parameterValue is int i) width = i;
            else if (parameterValue is string s && int.TryParse(s, out var parsed)) width = parsed;

            if (width <= 0) width = input.Width;
            double ratio = (double)width / input.Width;
            int newHeight = (int)Math.Round(input.Height * ratio);
            return input.With(width, newHeight, $"Resize(width={width})");
        }
    }
}


