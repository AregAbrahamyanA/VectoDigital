using System;

namespace ClassLibrary1.Abstractions
{
    /// <summary>
    /// Contract for a single image effect plugin. Implementations should be stateless and thread-safe.
    /// </summary>
    public interface IImageEffect
    {
        /// <summary>
        /// Unique identifier for this effect (stable across versions). Recommended: reverse DNS or GUID.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Human-friendly name to be shown in a UI.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Short description of what the effect does.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Optional single parameter definition supported by this effect. Null means no parameter.
        /// </summary>
        PluginParameterDefinition? Parameter { get; }

        /// <summary>
        /// Applies the effect to the given image and returns a new image instance with the modification.
        /// Implementations in this coding exercise should only simulate changes (no real image processing).
        /// </summary>
        /// <param name="input">Input image-like object.</param>
        /// <param name="parameterValue">Optional parameter value matching <see cref="Parameter"/>.</param>
        /// <returns>A new image-like object with simulated changes recorded.</returns>
        ImageData Apply(ImageData input, object? parameterValue);
    }
}


