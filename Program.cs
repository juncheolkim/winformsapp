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
            // 서비스 컬렉션을 생성하여 의존성 주입을 위한 컨테이너 역할을 할 수 있도록 초기화.
            var services = new ServiceCollection();

            // 데이터베이스와 상호 작용하는 WinformDbContext를 등록.
            services.AddDbContext<WinformDbContext>();

            // 애플리케이션에서 주로 메인 폼(최상위 폼) 역할을 하는 경우, 일반적으로 애플리케이션의 라이프사이클 동안 유지되어야 함.
            // AddSingleton은 처음 요청될 때 한 번만 인스턴스를 생성하고, 이후의 모든 요청에 대해 동일한 인스턴스를 반환.
            services.AddSingleton<frmMain>();

            // AddTransient는 서비스를 등록할 때 해당 서비스가 요청될 때마다 매번 새로운 인스턴스를 생성하여 반환
            // DB Service를 Singleton 생명주기로 관리하는건 적합하지 않음. 서비스 요청한 생성해서 수행하고 반환하는게 맞음.
            services.AddTransient<IDatabase<GangnamguPopulation>, GangnamguPopulationService>();

            // 서비스 컬렉션에 등록된 모든 서비스를 실제로 생성하고 관리하는 ServiceProvider를 생성            
            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            // GetRequiredService<T> 메서드를 사용하여 컨테이너에서 frmMain 클래스의 인스턴스를 요청
            var frmMain = serviceProvider.GetRequiredService<frmMain>();

            // 생성한 frmMain 인스턴스를 Application 시작할 때 메인 윈도우로 표시
            Application.Run(frmMain);
        }
    }
}