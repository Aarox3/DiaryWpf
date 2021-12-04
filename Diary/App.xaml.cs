using Diary.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Diary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int minSplTime = 4000;

        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splash = new SplashScreen();
            splash.Show();
            Stopwatch timer = new Stopwatch();
            timer.Start();
            base.OnStartup(e);
            MainWindow main = new MainWindow();
            timer.Stop();
            int remainingTime = minSplTime - (int)timer.ElapsedMilliseconds;
            if (remainingTime > 0)
                Thread.Sleep(remainingTime);
            splash.Close();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var metroWindow = Current.MainWindow as MetroWindow;
            metroWindow.ShowMessageAsync("Nieoczekiwany  wyjątek",
                "Wystąpił nieoczekiwany wyjątek." + 
                Environment.NewLine +
                e.Exception.Message);

            e.Handled = true;
        }
    }
}
