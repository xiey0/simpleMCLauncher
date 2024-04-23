using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Controls.Templates;
using mcMVVM.ViewModels;
using MsBox.Avalonia;
using System;
using System.Diagnostics;
using System.Linq;

namespace mcMVVM.Views
{
    public partial class MainWindow : Window
    {
        Avalonia.Controls.TextBox namefield;
        public MainWindow()
        {
            InitializeComponent();
            VerList.ItemsSource = new string[]
            {
                "1.19.4", "1.20.1", "1.20.2", "1.20.4"
            }.OrderBy(x => x);
            VerList.SelectedIndex = 0;
           if(CResIsEnable.IsChecked == true)
            {
                MCWidth.IsEnabled = true;
                MCHeight.IsEnabled = true;

            }
            else if(CResIsEnable.IsChecked == false)
            {
                MCWidth.IsEnabled = false;
                MCHeight.IsEnabled = false;
            }
           if(RBOffline.IsChecked == true)
            {
                OfflineUI.IsVisible = true;

            }else if(RBOffline.IsChecked == false)
            {
                OfflineUI.IsVisible = false;

            }
        }


        private  int testIfValidResNum(string i)
        {
            try
            {
                int.Parse(i);
            }
            catch(Exception e)
            {
                showMsgbox(1);
                return 255;
            }
            return 0;

        }
        private async void showMsgbox(int Mode)
        {
            if (Mode == 1)
            {
                var box = MessageBoxManager.GetMessageBoxStandard("错误", "非法分辨率", MsBox.Avalonia.Enums.ButtonEnum.Ok);
                var result = await box.ShowAsync(); ;

            }
        }
        
        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (CResIsEnable.IsChecked == true)
            {
                if (testIfValidResNum(MCWidth.Text) == 255 || testIfValidResNum(MCHeight.Text) == 255)
                {
                    return;
                }

            }
                
            
            
            
            try
            {
                if(CResIsEnable.IsChecked == true) {
                    if(isFullscreen.IsChecked == true)
                    {
                        Launch.Launcher(NameField.Text, true,VerList.SelectedItem.ToString(), ViewModels.MainWindowViewModel.GameDir, int.Parse(MCWidth.Text), int.Parse(MCHeight.Text));

                    }
                    else
                    {
                        Launch.Launcher(NameField.Text, false, VerList.SelectedItem.ToString(), ViewModels.MainWindowViewModel.GameDir, int.Parse(MCWidth.Text), int.Parse(MCHeight.Text));

                    }


                }
                else
                {
                    if (isFullscreen.IsChecked == true)
                    {
                        Launch.Launcher(true, NameField.Text,VerList.SelectedItem.ToString(), ViewModels.MainWindowViewModel.GameDir);

                    }
                    else
                    {
                        Launch.Launcher(false, NameField.Text, VerList.SelectedItem.ToString(), ViewModels.MainWindowViewModel.GameDir);


                    }



                }

            }
            catch (System.NullReferenceException ex)
            {
                MainWindowViewModel.DebugConsole += ex.ToString();

                MainWindowViewModel.DebugConsole += "Failed.";
            }
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
            try
            {
                GameDirDet.Content = ViewModels.MainWindowViewModel.GameDir;

            }
            catch (System.NullReferenceException ex) {
                Console.WriteLine(ex.ToString());
            }
        }

        private void RadioButton_Unchecked_5(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OfflineUI.IsVisible = false;

        }

        private void RadioButton_Checked_6(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OfflineUI.IsVisible = true;
        }

        private void CheckBox_Checked_7(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MCWidth.IsEnabled = true;
            MCHeight.IsEnabled = true;
        }

        private void CheckBox_Unchecked_8(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MCWidth.IsEnabled = false;
            MCHeight.IsEnabled = false;

        }

    }
}