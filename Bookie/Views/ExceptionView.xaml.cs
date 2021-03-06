﻿namespace Bookie.Views
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using ViewModels;

    /// <summary>
    ///     Interaction logic for ExceptionView.xaml
    /// </summary>
    public partial class ExceptionView
    {
        public ExceptionView()
        {
            InitializeComponent();
            ViewModel = new ExceptionViewModel();
            DataContext = ViewModel;
        }

        public ExceptionViewModel ViewModel { get; set; }

        private void Center()
        {
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.PreviousSize == e.NewSize)
                return;

            var w = SystemParameters.PrimaryScreenWidth;
            var h = SystemParameters.PrimaryScreenHeight;

            Left = (w - e.NewSize.Width)/2;
            Top = (h - e.NewSize.Height)/2;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (ViewModel.Fatal)
            {
                Environment.Exit(0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}