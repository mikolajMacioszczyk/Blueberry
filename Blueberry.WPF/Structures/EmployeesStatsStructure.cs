using Blueberry.DLL.Models;

namespace Blueberry.WPF.VisualizationStructures
{
    public struct EmployeesStatsStructure
    {
        public Employee Key { get; }
        public float Value { get; }

        public EmployeesStatsStructure(Employee key, float value)
        {
            Key = key;
            Value = value;
        }
    }
}