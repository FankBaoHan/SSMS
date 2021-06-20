using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSMS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());

            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "SINGLE_INSTANCE_MUTEX");
            if (!mutex.WaitOne(0, false)) //请求互斥体的所属权
            {
                mutex.Close();
                mutex = null;
            }
            if (mutex != null)
            {
                Application.Run(new LoginForm());
            }
            else
            {
                MessageBox.Show("程序已运行！");
            }
        }
    }
}
