﻿namespace Param_ItemNamespace.ViewModels
{
    public class wts.ItemNameDetailViewModel : Screen
    {
//{[{
        private readonly INavigationService _navigationService;
//}]}

        public SampleOrder Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

//{[{
        public wts.ItemNameDetailViewModel(IConnectedAnimationService connectedAnimationService, INavigationService navigationService)
        {
            _connectedAnimationService = connectedAnimationService;
            _navigationService = navigationService;
        }

        public void GoBack()
        {
            if (_navigationService.CanGoBack)
            {
                _navigationService.GoBack();
            }
        }
//}]}
    }
}
