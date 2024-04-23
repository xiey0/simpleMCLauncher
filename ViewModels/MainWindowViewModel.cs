using mcMVVM.Views;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.ComponentModel;

namespace mcMVVM.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
#pragma warning disable CA1822 // Mark members as static
        public static string Greeting => "Welcome to Avalonia!";

#pragma warning disable CA1822 // Mark members as static
        public static string GameDir {
            get => gamedir!;
            set { gamedir = value; }

        }
#pragma warning disable CA1822 // Mark members as static

        public static string DebugConsole
        {
            get => debugtext;
            set { debugtext = value ; }
        }
#pragma warning disable CA1822 // Mark members as static

        public static string? debugtext = "Debug\n";
#pragma warning disable CA1822 // Mark members as static

        public static string? gamedir = "F:\\keke";
#pragma warning disable CA1822 // Mark members as static

        public static bool? IsOffline
        {
            get => isoffline;
            set
            {
                isoffline= value; 
            }

        }
#pragma warning disable CA1822 // Mark members as static

        public static bool? isoffline = true;
    }


}
