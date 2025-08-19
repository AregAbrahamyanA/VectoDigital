using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Plugins
{
    /// <summary>
    /// Dummy grayscale: no parameter.
    /// </summary>
    public sealed class GrayscaleEffect : IImageEffect
    {
        public string Id => "com.example.effects.grayscale";
        public string Name => "Grayscale";
        public string Description => "Converts image to grayscale (dummy).";
        public PluginParameterDefinition? Parameter => null;

        public ImageData Apply(ImageData input, object? parameterValue)
        {
            return input.With(appendHistory: "Grayscale()");
        }
    }
}


