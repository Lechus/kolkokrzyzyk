using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Caliburn.Micro;

using KolkoKrzyzyk.UWP.Core.Models;
using KolkoKrzyzyk.UWP.Core.Services;
using KolkoKrzyzyk.UWP.Helpers;
using KolkoKrzyzyk.UWP.Services;
using KolkoKrzyzyk.UWP.Views;

namespace KolkoKrzyzyk.UWP.ViewModels
{
    public class ContentGridViewModel : Screen
    {
        private readonly INavigationService _navigationService;
        private readonly IConnectedAnimationService _connectedAnimationService;

        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public ContentGridViewModel(INavigationService navigationService, IConnectedAnimationService connectedAnimationService)
        {
            _navigationService = navigationService;
            _connectedAnimationService = connectedAnimationService;
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            var data = await SampleDataService.GetContentGridDataAsync();
            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        //public void OnItemSelected(SampleOrder clickedItem)
        //{
        //    if (clickedItem != null)
        //    {
        //        _connectedAnimationService.SetListDataItemForNextConnectedAnimation(clickedItem);
        //        _navigationService.Navigate(typeof(ContentGridDetailPage), clickedItem.OrderID);
        //    }
        //}
    }
}
