using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using Microsoft.Win32;


namespace EMASDeviceConsoleService
{
    [RunInstaller(true)]
    public partial class Installer1 : Installer
    {
        public Installer1()
        {
            InitializeComponent();
            this.AfterInstall += new InstallEventHandler(Installer1_AfterInstall);

        }

        void Installer1_AfterInstall(object sender, InstallEventArgs e)
        {
            // Just trying to set the start as delayed start in the register.
            // I could not achieve this from the designer options
            using (RegistryKey serviceKey = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Services\EMAS Device Console", true))
            {
                serviceKey.SetValue("Start", 2);
                if (Environment.OSVersion.Version.Major >= 6)
                    serviceKey.SetValue("DelayedAutostart", 1, RegistryValueKind.DWord);
            }
        }
    }
}
