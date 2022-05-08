using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

    public class SettingsVariable
    {
        public SettingsVariable(int defaultValue, int minimum, int maximum, string name, VariableType type)
        {
            Name = name;
            DefaultValue = defaultValue;
            Value = defaultValue;
            Minimum = minimum;
            Maximum = maximum;
            Type = type;
        }

        public SettingsVariable(SettingsVariable setingsVariable)
        {
            Name = setingsVariable.Name;
            DefaultValue = setingsVariable.DefaultValue;
            Value = setingsVariable.Value;
            Minimum = setingsVariable.Minimum;
            Maximum = setingsVariable.Maximum;
            Type = setingsVariable.Type;
        }

        public string Name { get; }
        public int Value { get; set; }
        public int DefaultValue { get; }
        public int Minimum { get; }
        public int Maximum { get; }
        public VariableType Type { get; }
    }

    public class Settings
    {
        public SettingsVariable[] SettingsVariables { get; }
        public SettingsVariable[] DefaultSettingsVariables { get; }
        public string SettingsFileName;
        
        public Settings()
        {
            SettingsVariables = new SettingsVariable[0];
            DefaultSettingsVariables = new SettingsVariable[0];
            SettingsFileName = "";
        }

        public Settings(SettingsVariable[] defaultSettings)
        {
            DefaultSettingsVariables = defaultSettings;
        }

        public Settings(SettingsVariable[] defaultSettings, string settingsFileName)
        {
            DefaultSettingsVariables = defaultSettings;
            SettingsFileName = settingsFileName;
            SettingsVariables = new SettingsVariable[defaultSettings.Length];
            SetSettingsVariables(DefaultSettingsVariables);
            //TryToLoadSettings();
        }

        public void TryToLoadSettings()
        {
            string json;
            bool result = File.Exists(SettingsFileName);
            //SetSettingsVariables(DefaultSettingsVatiables);
            if (File.Exists(SettingsFileName))
            {
                json = File.ReadAllText(SettingsFileName);
                int[] loadedValues = JsonConvert.DeserializeObject<int[]>(json);

                if (VerifySettings(loadedValues))
                {
                    SetSettingsVariables(loadedValues);
                    return;
                }
            }

            SaveSettings();
        }

        public void SaveSettings()
        {
            int[] settingsValues = GetSettingsValues();
            string json = JsonConvert.SerializeObject(settingsValues, Formatting.Indented);
            File.WriteAllText(SettingsFileName, json);
        }

        public void SaveSettings(int[] values)
        {
            string json = JsonConvert.SerializeObject(values, Formatting.Indented);
            File.WriteAllText(SettingsFileName, json);
        }

        public void UpdateSettings(int[] values)
        {
            SetSettingsVariables(values);
            SaveSettings(values);
        }

        public void ResetToDefault()
        {
            SetSettingsVariables(DefaultSettingsVariables);
        }

        public bool VerifySettings(int[] loadedValues)
        {
            if (loadedValues == null || loadedValues.Length != DefaultSettingsVariables.Length)
                return false;

            for (int i = 0; i < loadedValues.Length; i++)
            {
                if (loadedValues[i] < DefaultSettingsVariables[i].Minimum ||
                    loadedValues[i] > DefaultSettingsVariables[i].Maximum)
                    return false;
            }

            return true;
        }

        private void SetSettingsVariables(int[] loadedValues)
        {
            for (int i = 0; i < loadedValues.Length; i++)
            {
                SettingsVariables[i].Value = loadedValues[i];
            }
        }

        private void SetSettingsVariables(SettingsVariable[] settingsValues)
        {
            for (int i = 0; i < settingsValues.Length; i++)
            {
                SettingsVariables[i] = new SettingsVariable(settingsValues[i]);
            }
        }

        private int[] GetSettingsValues()
        {
            int[] values = new int[SettingsVariables.Length];

            for(int i = 0; i < values.Length; i++)
            {
                values[i] = SettingsVariables[i].Value;
            }

            return values;
        }
    }
}
