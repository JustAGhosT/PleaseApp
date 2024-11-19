﻿using PleaseApp.ViewModels;

namespace PleaseApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is MainViewModel viewModel)
            {
                viewModel.RefreshDataCommand.Execute(null);
            }
        }
    }
}
