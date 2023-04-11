// Bocchidesu-coctothorpe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Bocchidesu_coctothorpe.MainWindow
using NLog;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows;

namespace Bocchidesu_coctothorpe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }

        public Uri StartupUri { get; internal set; }

        public static bool PortInUse(int port)
        {
            bool inUse = true;
            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();
            IPEndPoint[] array = ipEndPoints;
            foreach (IPEndPoint endPoint in array)
            {
                if (endPoint.Port == port)
                {
                    inUse = false;
                    break;
                }
            }
            return inUse;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("nginx.exe").ToList().Count > 0)
                {
                    Process.Start("hosts.exe");
                    Process.Start("cmd.exe /c taskkill /f /im nginx.exe");
                    MessageBox.Show("关闭成功", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
                }
                else if (PortInUse(80))
                {
                    if (PortInUse(443))
                    {
                        if (OneDrive.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\ms.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (Pixiv.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\pixiv.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (ExHentai.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\exhentai.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (Steam.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\steam.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (Nyaa.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\nyaa.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (Discord.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\discord.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (GitHub.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\github.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (Gravatar.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\gravatar.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (DuckDuckGo.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\DuckDuckGo.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                        if (v2ex.IsChecked.Value)
                        {
                            Process.Start("cmd.exe /c type hosts\\v2ex.txt>>C:\\\\Windows\\System32\\drivers\\etc\\hosts");
                        }
                    }
                    else
                    {
                        MessageBox.Show("443端口被占用！请检查一下", "提示", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("80端口被占用！请检查一下", "提示", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "有一个错误QAQ，但可以发个发个issues");
                MessageBox.Show("出错啦(っ °Д °;)っ，去”logs/Bocchidesuxxx“看看是什么错误，发个issues也行", "出错啦(っ °Д °;)っ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static implicit operator System.Windows.Forms.Application(MainWindow v)
        {
            throw new NotImplementedException();
        }
    }
}