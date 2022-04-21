using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public enum VariableType
    {
        Int = 0,
        Double
    }

    public class OptionsVariable
    {
        public OptionsVariable(int defaultValue, int minimum, int maximum, string name, VariableType type)
        {
            Name = name;
            DefaultValue = defaultValue;
            Value = defaultValue;
            Minimum = minimum;
            Maximum = maximum;
            Type = type;
        }

        public string Name { get; }
        public int Value { get; set; }
        public int DefaultValue { get; }
        public int Minimum { get; }
        public int Maximum { get; }
        public VariableType Type { get; }
    }
}
