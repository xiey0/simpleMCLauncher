using Avalonia;
using System;
using MinecraftLaunch.Classes.Interfaces;
using MinecraftLaunch.Classes.Models.Launch;
using MinecraftLaunch.Components.Authenticator;
using MinecraftLaunch.Components.Launcher;
using MinecraftLaunch.Components.Resolver;
using MinecraftLaunch.Extensions;
using MinecraftLaunch.Utilities;
using System.Xml.Linq;
using mcMVVM.Views;
using mcMVVM.ViewModels;

namespace mcMVVM
{
    class Launch
    {

        
        public static async void Launcher(string name = "Steve", bool fullscreen = false, string gamefolderdir = "F:\\keke", string jdir = "C:\\Program Files\\Zulu\\zulu-17\\bin\\javaw.exe", string verid = "1.20.1")
        {
            OfflineAuthenticator offlineAuthenticator = new(name);
            var userProfile = offlineAuthenticator.Authenticate();
            LaunchConfig config = new LaunchConfig
            {
                Account = userProfile,
                GameWindowConfig = new GameWindowConfig
                {
                    Width = 1280,
                    Height = 800,
                    IsFullscreen = fullscreen
                },
                JvmConfig = new JvmConfig(jdir)
                {
                    MaxMemory = 4096,

                },
                IsEnableIndependencyCore = true
            };
            IGameResolver resolver = new GameResolver(gamefolderdir);
            Launcher launcher = new(resolver, config);
            IGameProcessWatcher gameProcessWatcher = await launcher.LaunchAsync(verid);
            
        }
        public static async void Launcher(string name, bool isFullscreen, string verid = "1.20.1", string gamefolder = "F:\\keke", int Width = 856, int Height = 482)
        {
            OfflineAuthenticator offlineAuthenticator = new(name);
            var userProfile = offlineAuthenticator.Authenticate();
            LaunchConfig config = new LaunchConfig
            {
                Account = userProfile,
                GameWindowConfig = new GameWindowConfig
                {
                    Width = Width,
                    Height = Height,
                    IsFullscreen = isFullscreen
                },
                JvmConfig = new JvmConfig("C:\\Program Files\\Zulu\\zulu-17\\bin\\javaw.exe")
                {
                    MaxMemory = 4096,

                },
                IsEnableIndependencyCore = true
            };
            IGameResolver resolver = new GameResolver(gamefolder);
            Launcher launcher = new(resolver, config);


            try
            {
                IGameProcessWatcher gameProcessWatcher = await launcher.LaunchAsync(verid);

            }
            catch (System.NullReferenceException e)
            {
                MainWindowViewModel.DebugConsole += @"e.ToString()";

            }


        }
        public static async void Launcher(bool isFullscreen, string name,  string verid = "1.20.1", string gamefolder = "F:\\keke", int Width = 856, int Height = 482)
        {
            OfflineAuthenticator offlineAuthenticator = new(name);
            var userProfile = offlineAuthenticator.Authenticate();
            LaunchConfig config = new LaunchConfig
            {
                Account = userProfile,
                GameWindowConfig = new GameWindowConfig
                {
                    Width = Width,
                    Height = Height,
                    IsFullscreen = isFullscreen
                },
                JvmConfig = new JvmConfig("C:\\Program Files\\Zulu\\zulu-17\\bin\\javaw.exe")
                {
                    MaxMemory = 4096,

                },
                IsEnableIndependencyCore = true
            };
            IGameResolver resolver = new GameResolver(gamefolder);
            Launcher launcher = new(resolver, config);


            try
            {
                IGameProcessWatcher gameProcessWatcher = await launcher.LaunchAsync(verid);

            }
            catch (System.NullReferenceException e)
            {
                MainWindowViewModel.DebugConsole += @"e.ToString()";

            }


        }

    }

    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}
