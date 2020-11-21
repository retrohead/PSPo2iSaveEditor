namespace apPatcherApp.Properties
{
    using System;
    using System.CodeDom.Compiler;
    using System.Configuration;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    [CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = ((Settings) Synchronized(new Settings()));

        public static Settings Default =>
            defaultInstance;

        [DefaultSettingValue(""), UserScopedSetting, DebuggerNonUserCode]
        public string NFOTheme
        {
            get => 
                (string) this["NFOTheme"];
            set => 
                this["NFOTheme"] = value;
        }

        [DebuggerNonUserCode, UserScopedSetting, DefaultSettingValue("")]
        public string NFOSize
        {
            get => 
                (string) this["NFOSize"];
            set => 
                this["NFOSize"] = value;
        }

        [UserScopedSetting, DefaultSettingValue("0"), DebuggerNonUserCode]
        public int Collection_W
        {
            get => 
                (int) this["Collection_W"];
            set => 
                this["Collection_W"] = value;
        }

        [DebuggerNonUserCode, DefaultSettingValue("0"), UserScopedSetting]
        public int Collection_H
        {
            get => 
                (int) this["Collection_H"];
            set => 
                this["Collection_H"] = value;
        }

        [DebuggerNonUserCode, DefaultSettingValue("0"), UserScopedSetting]
        public int Collection_Col1
        {
            get => 
                (int) this["Collection_Col1"];
            set => 
                this["Collection_Col1"] = value;
        }

        [DefaultSettingValue("0"), UserScopedSetting, DebuggerNonUserCode]
        public int Collection_Col2
        {
            get => 
                (int) this["Collection_Col2"];
            set => 
                this["Collection_Col2"] = value;
        }

        [DebuggerNonUserCode, DefaultSettingValue("0"), UserScopedSetting]
        public int Collection_Col3
        {
            get => 
                (int) this["Collection_Col3"];
            set => 
                this["Collection_Col3"] = value;
        }

        [DefaultSettingValue("0"), UserScopedSetting, DebuggerNonUserCode]
        public int Collection_Col4
        {
            get => 
                (int) this["Collection_Col4"];
            set => 
                this["Collection_Col4"] = value;
        }
    }
}

