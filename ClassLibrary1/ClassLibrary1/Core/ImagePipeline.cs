using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Core
{
    /// <summary>
    /// Represents a sequence of effects to apply to an image.
    /// </summary>
    public sealed class ImagePipeline
    {
        private readonly IReadOnlyList<EffectDescriptor> _effects;

        public ImagePipeline(IEnumerable<EffectDescriptor> effects)
        {
            _effects = effects?.ToList() ?? throw new ArgumentNullException(nameof(effects));
        }

        public ImageData Execute(ImageData input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            ImageData current = input;
            foreach (var descriptor in _effects)
            {
                current = descriptor.Effect.Apply(current, descriptor.ParameterValue);
            }
            return current;
        }
    }
}


