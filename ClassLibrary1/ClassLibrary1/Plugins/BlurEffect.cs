using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Plugins
{
    /// <summary>
    /// Dummy blur: expects integer radius/size.
    /// </summary>
    public sealed class BlurEffect : IImageEffect
    {
        public string Id => "com.example.effects.blur";
        public string Name => "Blur";
        public string Description => "Applies a blur of the given radius (dummy).";
        public PluginParameterDefinition? Parameter => new PluginParameterDefinition("radius", "Radius (px)", PluginParameterKind.Integer, 0, 100);

        public ImageData Apply(ImageData input, object? parameterValue)
        {
            int radius = 0;
            if (parameterValue is int i) radius = i;
            else if (parameterValue is string s && int.TryParse(s, out var parsed)) radius = parsed;

            return input.With(appendHistory: $"Blur(radius={radius})");
        }
    }
}


