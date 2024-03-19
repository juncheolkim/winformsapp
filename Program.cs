using Microsoft.Extensions.DependencyInjection;
using WinFormsAppMaster.Interfaces;
using WinFormsAppMaster.Models;
using WinFormsAppMaster.Services;

namespace WinFormsAppMaster
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ���� �÷����� �����Ͽ� ������ ������ ���� �����̳� ������ �� �� �ֵ��� �ʱ�ȭ.
            var services = new ServiceCollection();

            // �����ͺ��̽��� ��ȣ �ۿ��ϴ� WinformDbContext�� ���.
            services.AddDbContext<WinformDbContext>();

            // ���ø����̼ǿ��� �ַ� ���� ��(�ֻ��� ��) ������ �ϴ� ���, �Ϲ������� ���ø����̼��� ����������Ŭ ���� �����Ǿ�� ��.
            // AddSingleton�� ó�� ��û�� �� �� ���� �ν��Ͻ��� �����ϰ�, ������ ��� ��û�� ���� ������ �ν��Ͻ��� ��ȯ.
            services.AddSingleton<frmMain>();

            // AddTransient�� ���񽺸� ����� �� �ش� ���񽺰� ��û�� ������ �Ź� ���ο� �ν��Ͻ��� �����Ͽ� ��ȯ
            // DB Service�� Singleton �����ֱ�� �����ϴ°� �������� ����. ���� ��û�� �����ؼ� �����ϰ� ��ȯ�ϴ°� ����.
            services.AddTransient<IDatabase<GangnamguPopulation>, GangnamguPopulationService>();

            // ���� �÷��ǿ� ��ϵ� ��� ���񽺸� ������ �����ϰ� �����ϴ� ServiceProvider�� ����            
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            // GetRequiredService<T> �޼��带 ����Ͽ� �����̳ʿ��� frmMain Ŭ������ �ν��Ͻ��� ��û
            var frmMain = serviceProvider.GetRequiredService<frmMain>();

            // ������ frmMain �ν��Ͻ��� Application ������ �� ���� ������� ǥ��
            Application.Run(frmMain);
        }
    }
}