﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Wale.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {// give the mutex a  unique name
        private const string MutexName = "WaleWindowsAudioLoudnessEqualizer";
        //private const string MutexModi = "RS";
        // declare the mutex
        private readonly Mutex _mutex;
        // overload the constructor
        bool createdNew, StartRequire = true;
        public App()
        {
            // overloaded mutex constructor which outs a boolean
            // telling if the mutex is new or not.
            // see http://msdn.microsoft.com/en-us/library/System.Threading.Mutex.aspx
            _mutex = new Mutex(true, MutexName, out createdNew);
            if (!createdNew)
            {
                Console.WriteLine("Acquiring.");
                if (!_mutex.WaitOne(3000))
                {
                    StartRequire = false;
                    // if the mutex already exists, notify and quit
                    MessageBox.Show("The Wale is already breathing");
                    Application.Current.Shutdown(0);
                }
            }

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            if (!StartRequire) return;
            // overload the OnStartup so that the main window 
            // is constructed and visible

            //foreach (string arg in e.Args) { Console.WriteLine(arg); }

            //JDPack.FileLog.SetWorkDirectory(System.IO.Path.Combine(Environment.ExpandEnvironmentVariables("%appdata%"), "WaleAudioControl"));
            string path=(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WaleAudioControl"));
            JDPack.FileLog.SetWorkDirectory(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WaleAudioControl"));
            JDPack.FileLog.Open("WaleLog");
            JDPack.FileLog.Erase(7);
            JDPack.FileLog.Log($"Wale {AppVersion.Version}.{AppVersion.SubVersion}");
            JDPack.FileLog.Log(path);

            int UICreation = 0;
            try
            {
                MainWindow mw = new MainWindow();
                UICreation = 1;
                mw.Show();
                UICreation = 2;
            }
            catch (Exception uice) { JDPack.FileLog.Log($"Failed to create and show UI on stage {UICreation}, {uice.ToString()}"); }
        }
        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            JDPack.FileLog.Log($"{e.Exception.Message} {e.Exception.StackTrace}");
            // Prevent default unhandled exception processing
            //e.Handled = true;
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _mutex.ReleaseMutex();
            base.OnExit(e);
        }

    }
}
