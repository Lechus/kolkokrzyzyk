using KolkoKrzyzyk.UWP.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace KolkoKrzyzyk.UWP.Views
{
    public sealed partial class CameraPage : Page
    {
        public CameraPage()
        {
            InitializeComponent();
        }

        private CameraViewModel ViewModel
        {
            get { return DataContext as CameraViewModel; }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await cameraControl.InitializeCameraAsync();
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            await cameraControl.CleanupCameraAsync();
        }
    }
}
