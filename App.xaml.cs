﻿using System;
using System.Windows;
using GG.UserControls.Dialogs;

namespace GG
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };

            base.MainWindow = mainWindow;

            // Set up a global exception handler.
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            mainWindow.Show();
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            var dialog = new ConfirmDialog
            {
                Title = "Error occured",
                Message = unhandledExceptionEventArgs.ExceptionObject.ToString(),
                ButtonSet = ConfirmDialog.ButtonsSet.OK,
                MaxHeight = 640,
                MaxWidth = 800
            };

            dialog.ShowDialog();

            Environment.Exit(1);
        }
    }
}
