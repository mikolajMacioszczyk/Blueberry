using System;

namespace Blueberry.WPF.VisualizationStructures
{
    public class RealizedStatsStructure
    {
        public string Key { get; }
        public float Value { get; }

        public RealizedStatsStructure(DateTime key, float value)
        {
            Key = key.ToShortDateString();
            Value = value;
        }
    }
}