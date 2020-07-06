using System;

namespace Blueberry.WPF.VisualizationStructures
{
    public struct HarvestPerDayStructure
    {
        public string Key { get; set; }
        public float Value { get; set; }

        public HarvestPerDayStructure(DateTime key, float value)
        {
            Key = key.ToShortDateString();
            Value = value;
        }
    }
}