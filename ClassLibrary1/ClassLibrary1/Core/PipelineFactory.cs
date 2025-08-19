using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Configuration;

namespace ClassLibrary1.Core
{
    /// <summary>
    /// Builds pipelines from a configuration object and a set of available effects.
    /// </summary>
    public static class PipelineFactory
    {
        public static ImagePipeline FromConfig(PluginConfig config, IEnumerable<IImageEffect> available)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (available == null) throw new ArgumentNullException(nameof(available));

            var effectById = available.ToDictionary(e => e.Id, StringComparer.OrdinalIgnoreCase);
            var descriptors = new List<EffectDescriptor>();
            foreach (var selection in config.Effects)
            {
                if (string.IsNullOrWhiteSpace(selection.EffectId)) continue;
                if (!effectById.TryGetValue(selection.EffectId, out var effect))
                {
                    continue;
                }
                descriptors.Add(new EffectDescriptor(effect, selection.Parameter));
            }
            return new ImagePipeline(descriptors);
        }
    }
}


