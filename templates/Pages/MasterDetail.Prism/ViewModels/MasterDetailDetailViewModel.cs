﻿using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using Param_ItemNamespace.Models;
using Param_ItemNamespace.Services;

namespace Param_ItemNamespace.ViewModels
{
    public class MasterDetailDetailViewModel : ViewModelBase
    {
        private const string NarrowStateName = "NarrowState";
        private const string WideStateName = "WideState";

        private readonly INavigationService navigationService;
        private readonly ISampleDataService sampleDataService;

        public ICommand StateChangedCommand { get; }

        private SampleOrder item;

        public SampleOrder Item
        {
            get { return item; }
            set { SetProperty(ref item, value); }
        }

        public MasterDetailDetailViewModel(INavigationService navigationService, ISampleDataService sampleDataService)
        {
            this.navigationService = navigationService;
            this.sampleDataService = sampleDataService;
            StateChangedCommand = new DelegateCommand<VisualStateChangedEventArgs>(OnStateChanged);
        }

        public async override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            long orderId = (long)e.Parameter;
            var data = await sampleDataService.GetSampleModelDataAsync();
            Item = data.FirstOrDefault(x => x.OrderId == orderId);
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
            if (args.OldState.Name == NarrowStateName && args.NewState.Name == WideStateName)
            {
                navigationService.GoBack();
            }
        }
    }
}
