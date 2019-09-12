using System;

using Caliburn.Micro;

using KolkoKrzyzyk.UWP.EventHandlers;
using KolkoKrzyzyk.UWP.Helpers;

using Windows.UI.Xaml.Media.Imaging;

namespace KolkoKrzyzyk.UWP.ViewModels
{
    public class CameraViewModel : Screen
    {
        private BitmapImage _photo;

        public BitmapImage Photo
        {
            get { return _photo; }
            set { Set(ref _photo, value); }
        }

        public void OnPhotoTaken(CameraControlEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Photo))
            {
                Photo = new BitmapImage(new Uri(args.Photo));
            }
        }
    }
}
