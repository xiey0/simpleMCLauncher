using Avalonia.Controls;
using Avalonia.Media;
using mcMVVM.ViewModels;
using System.Drawing;
using System.Threading;

namespace mcMVVM.Views
{
    public partial class About : Window
    {
        public About()
        {
            DataContext = new ViewModels.AboutWindowViewModel(); // Finally binds the MainWindow ViewModel to the About Window. jesus christ. 
            Avalonia.Media.IBrush whitebrush = new SolidColorBrush(Avalonia.Media.Color.FromRgb(255, 255, 255));
            Avalonia.Media.IBrush blackbrush = new SolidColorBrush(Avalonia.Media.Color.FromRgb(0, 0, 0));
            InitializeComponent();
            if (ActualThemeVariant.ToString() == "Dark")
            {

                    Border.BorderBrush = whitebrush;

            }
            else
            {
                Border.BorderBrush = blackbrush;
            }

            
        }
        
    }
}
