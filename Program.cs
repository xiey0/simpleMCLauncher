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
        public static async void Launcher(string verid = "1.20.1")
        {
            OfflineAuthenticator offlineAuthenticator = new("Steve");
            var userProfile = offlineAuthenticator.Authenticate();
            LaunchConfig config = new LaunchConfig
            {
                Account = userProfile,
                GameWindowConfig = new GameWindowConfig
                {
                    Width = 1280,
                    Height = 800,
                    IsFullscreen = false
                },
                JvmConfig = new JvmConfig("C:\\Program Files\\Zulu\\zulu-17\\bin\\javaw.exe")
                {
                    MaxMemory = 4096,

                },
                IsEnableIndependencyCore = true
            };
            IGameResolver resolver = new GameResolver("F:\\keke");
            Launcher launcher = new(resolver, config);
            IGameProcessWatcher gameProcessWatcher = await launcher.LaunchAsync(verid);
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
