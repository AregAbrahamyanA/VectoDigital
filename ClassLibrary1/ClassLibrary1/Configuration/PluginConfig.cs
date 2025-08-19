using System;
using System.Collections.Generic;

namespace ClassLibrary1.Configuration
{
    /// <summary>
    /// Minimal config models to demonstrate binding from any source (JSON, XML, in-memory, etc.).
    /// </summary>
    public sealed class PluginConfig
    {
        public List<PluginSelection> Effects { get; set; } = new();
    }

    public sealed class PluginSelection
    {
        public string EffectId { get; set; } = string.Empty;
        public object? Parameter { get; set; }
    }
}


