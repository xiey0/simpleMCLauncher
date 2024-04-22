using Avalonia.Controls;
using System;
using System.Linq;

namespace mcMVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            VerList.ItemsSource = new string[]
            {
                "1.19.4", "1.20.1", "1.20.2", "1.20.4"
            }.OrderBy(x => x);
             
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Launch.Launcher(VerList.SelectedItem.ToString()!);
            
        }

        private void MenuItem_Click_1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItem_Click_2(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var ownerWindow = this;
            var window = new About();
            window.ShowDialog(ownerWindow);
        }

        private void Button_Click_3(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            VersionID.Content = VerList.SelectedItem;
        }

        private void Button_Click_4(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            GameDirDet.Content = ViewModels.MainWindowViewModel.GameDir.ToString();
        }
    }
}