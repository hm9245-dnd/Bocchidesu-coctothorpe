using log4net;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows;

namespace Bocchidesu_coctothorpe
{
    public partial class MainWindow : Window
    {
        private static readonly ILog log = LogManager.GetLogger("mylogger");

        public MainWindow()
        {
            InitializeComponent();
        }

        public static void Killnginx()
        {
            Process process = new();
            ProcessStartInfo startInfo = new()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C taskkill /f /im nginx.exe",
                Verb = "runas"
            };
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            process.Close();
        }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("nginx").ToList().Count > 0)
                {
                    try
                    {
                        Process.Start("hosts.exe");
                        log.Info("the hosts.exe run success");
                    }
                    catch
                    {
                        log.Error("the hosts.exe run failed");
                        MessageBox.Show("(っ °Д °;)っ出了点错误，把日志发到Issues上,日志文件在logs/bocchidesu(最新日期).log", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    try
                    {
                        Killnginx();
                        log.Info("the nginx kill success");
                    }
                    catch
                    {
                        log.Error("the nginx kill failed");
                        MessageBox.Show("(っ °Д °;)っ出了点错误，把日志发到Issues上,日志文件在logs/bocchidesu(最新日期).log", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    MessageBox.Show("关闭成功", "提示", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    log.Info("close success！");
                }
                else if (PortInUse(80))
                {
                    if (PortInUse(443))
                    {
                        if (OneDrive.IsChecked.Value)
                        {
                            string conpath = txt.ms;//定义要获取的文件内容地址
                            getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                        }
                        if (Pixiv.IsChecked.Value)
                        {
                                string conpath = txt.pixiv;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                            
                        }
                        if (ExHentai.IsChecked.Value)
                        {
                                string conpath = txt.exhentai;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                            
                        }
                        if (Steam.IsChecked.Value)
                        {
                                string conpath = txt.steam;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                            
                        }
                        if (Nyaa.IsChecked.Value)
                        {
                                string conpath = txt.nyaa;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                            
                        }
                        if (Discord.IsChecked.Value)
                        {
                                string conpath = txt.discord;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                            
                        }
                        if (GitHub.IsChecked.Value)
                        {
                                string conpath = txt.github;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                            
                        }
                        if (Gravatar.IsChecked.Value)
                        {
                                string conpath = txt.gravatar;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                            
                        }
                        if (DuckDuckGo.IsChecked.Value)
                        {
                                string conpath = txt.duckduckgo;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                        }
                        if (v2ex.IsChecked.Value)
                        {
                                string conpath = txt.v2ex;//定义要获取的文件内容地址
                                getContentToFile(conpath);//将log.txt内容写入到自己的文件中`
                        }
                        try
                        {
                            Process.Start("nginx");
                            log.Info("the nginx start successful");
                        }
                        catch
                        {
                            log.Error("the 'nginx.exe' start failed,or the nginx,exe is lost");
                            MessageBox.Show("(っ °Д °;)っ出了点错误，把日志发到Issues上,日志文件在logs/bocchidesu(最新日期).log", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        Process.Start("nginx.exe");
                        MessageBox.Show("开启成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                        log.Info("start success");
                    }
                    else
                    {
                        MessageBox.Show("443端口被占用！请检查一下", "提示", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        log.Warn("the 443 port is using!");
                    }
                }
                else
                {
                    MessageBox.Show("80端口被占用！请检查一下", "提示", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    log.Warn("the 80 port is using!");
                }
            }
            catch
            {
                log.Error("port check failed!");
                MessageBox.Show("(っ °Д °;)っ出了点错误，把日志发到Issues上,日志文件在logs/bocchidesu(最新日期).log", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void getContentToFile(String conpath)
        {
            try
            {
                StreamWriter sw = File.AppendText(@"C:\Windows\System32\drivers\etc\hosts");
                sw.WriteLine(conpath.Trim());
                sw.Close();
            }
            catch
            {
                MessageBox.Show("读取内容到文件方法错误");
            }
        }
    }
}