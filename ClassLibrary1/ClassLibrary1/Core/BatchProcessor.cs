using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary1.Core
{
    /// <summary>
    /// Processes multiple images, each with its own pipeline.
    /// </summary>
    public sealed class BatchProcessor
    {
        public IReadOnlyList<ImageData> Process(IReadOnlyList<(ImageData image, ImagePipeline pipeline)> work)
        {
            if (work == null) throw new ArgumentNullException(nameof(work));
            var results = new List<ImageData>(work.Count);
            foreach (var (image, pipeline) in work)
            {
                results.Add(pipeline.Execute(image));
            }
            return results;
        }
    }
}


