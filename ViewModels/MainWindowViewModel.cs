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
        public static string? gamedir = "F:\\keke";

    }


}
