using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;


// runtimeconfig.template.json replaces App.Config based AppContext configuration
// App.config is still used for WPF's old style configuration switches (BaseCompatibilityPreferences class, for e.g.)

namespace Wpf_AppCompat_Quirks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window , INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected override void OnDpiChanged(DpiScale oldDpi, DpiScale newDpi)
        {
            Debug.WriteLine("dpichanged");
            base.OnDpiChanged(oldDpi, newDpi);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"ShouldThrowOnCopyOrCutFailure: {FrameworkCompatibilityPreferences.ShouldThrowOnCopyOrCutFailure}");
            ShouldThrowOnCopyOrCutFailure = FrameworkCompatibilityPreferences.ShouldThrowOnCopyOrCutFailure.ToString();

            if (AppContext.TryGetSwitch("Switch.System.Windows.DoNotScaleForDpiChanges", out bool doNotScaleForDpiChanges))
            {
                DoNotScaleForDpiChanges = doNotScaleForDpiChanges.ToString();
            }

            Debug.WriteLine($"DoNotScaleForDpiChanges: {DoNotScaleForDpiChanges}");
        }

        private string _shouldThrowOnCopyOrCutFailure = "Undefined";
        public string ShouldThrowOnCopyOrCutFailure
        {
            get => _shouldThrowOnCopyOrCutFailure;
            set
            {
                _shouldThrowOnCopyOrCutFailure = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShouldThrowOnCopyOrCutFailure)));
            }
        }

        private string _doNotScaleForDpiChanges = "Undefined";
        public string DoNotScaleForDpiChanges
        {
            get => _doNotScaleForDpiChanges;
            set
            {
                _doNotScaleForDpiChanges = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DoNotScaleForDpiChanges)));
            }
        }
    }
}
