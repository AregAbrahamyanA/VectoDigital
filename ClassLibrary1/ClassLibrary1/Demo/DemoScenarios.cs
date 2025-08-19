    using System.Collections.Generic;
using ClassLibrary1.Abstractions;
using ClassLibrary1.Configuration;
using ClassLibrary1.Core;
using ClassLibrary1.Plugins;

namespace ClassLibrary1.Demo
{
    /// <summary>
    /// Provides a demo method to show the API with simulated image data.
    /// </summary>
    public static class DemoScenarios
    {
        public static IReadOnlyList<ImageData> RunSample()
        {
            var available = new IImageEffect[]
            {
                new ResizeEffect(),
                new BlurEffect(),
                new GrayscaleEffect()
            };

            // Image#1: resize to 100 pixels, add blur 2 pixels size
            var p1 = PipelineFactory.FromConfig(new PluginConfig
            {
                Effects =
                {
                    new PluginSelection { EffectId = "com.example.effects.resize", Parameter = 100 },
                    new PluginSelection { EffectId = "com.example.effects.blur", Parameter = 2 }
                }
            }, available);

            // Image#2: resize to 100 pixels
            var p2 = PipelineFactory.FromConfig(new PluginConfig
            {
                Effects =
                {
                    new PluginSelection { EffectId = "com.example.effects.resize", Parameter = 100 }
                }
            }, available);

            // Image#3: resize to 150 pixels, blur 5, grayscale
            var p3 = PipelineFactory.FromConfig(new PluginConfig
            {
                Effects =
                {
                    new PluginSelection { EffectId = "com.example.effects.resize", Parameter = 150 },
                    new PluginSelection { EffectId = "com.example.effects.blur", Parameter = 5 },
                    new PluginSelection { EffectId = "com.example.effects.grayscale" }
                }
            }, available);

            var images = new List<(ImageData, ImagePipeline)>
            {
                (new ImageData("Image#1", 1000, 800, "Start"), p1),
                (new ImageData("Image#2", 900, 600, "Start"), p2),
                (new ImageData("Image#3", 1200, 900, "Start"), p3)
            };

            var batch = new BatchProcessor();
            return batch.Process(images);
        }
    }
}


