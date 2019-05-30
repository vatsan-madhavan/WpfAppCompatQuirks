// runtimeconfig.template.json replaces App.Config based AppContext configuration
// App.config is still used for WPF's old style configuration switches (BaseCompatibilityPreferences class, for e.g.)

namespace Wpf_AppCompat_Quirks
{
    public class CompatSwitchInformation
    {
        public string Class { get; set; }
        public string SwitchName { get; set; }
        public string DefaultValue { get; set; }
        public string SettingsSource { get; set; }
    }
}
