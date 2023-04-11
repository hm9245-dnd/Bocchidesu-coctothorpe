using System;

public class Class1
{
	public Class1()
	{
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isRuned;
            System.Threading.Mutex mutex = new System.Threading.Mutex(true, "OnlyRunOneInstance", out isRuned);
            if (isRuned)
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("程序已启动!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
