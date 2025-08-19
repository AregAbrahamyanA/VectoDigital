using System;

namespace ClassLibrary1.Abstractions
{
    /// <summary>
    /// Describes the single optional parameter supported by an image effect plugin.
    /// </summary>
    public sealed class PluginParameterDefinition
    {
        public PluginParameterDefinition(string id, string displayName, PluginParameterKind kind, object? min = null, object? max = null)
        {
            Id = id;
            DisplayName = displayName;
            Kind = kind;
            Min = min;
            Max = max;
        }

        public string Id { get; }
        public string DisplayName { get; }
        public PluginParameterKind Kind { get; }
        public object? Min { get; }
        public object? Max { get; }
    }

    public enum PluginParameterKind
    {
        None = 0,
        Integer,
        Decimal,
        Enum,
        Text
    }
}


