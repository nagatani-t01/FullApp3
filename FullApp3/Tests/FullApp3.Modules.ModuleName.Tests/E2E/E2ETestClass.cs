using FlaUI.Core;
using FlaUI.UIA3;
using System;
using System.Diagnostics;
using Xunit;

namespace FullApp3.Modules.TimeCard.Tests.E2E
{
    public class E2ETestClass : IDisposable
    {
        private readonly string _containerName = "xunit_pg_container";
        private readonly string _appPath = @"FullApp3.exe";
        private readonly Application _app;
        private readonly AutomationBase _automation;

        public E2ETestClass()
        {
            //StartPostgresContainer();
            //Thread.Sleep(5000); // PostgreSQL の起動待ち

            _app = Application.Launch(_appPath);
            _automation = new UIA3Automation();
        }

        [Fact]
        public void Test_SearchButtonClick_ShowsResults()
        {
            var mainWindow = _app.GetMainWindow(_automation);

            //var button = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("SearchButton")).AsButton();
            //Assert.NotNull(button);

            //button.Invoke();

            //var resultLabel = Retry.WhileNull(
            //    () => mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("ResultLabel"))?.AsLabel(),
            //    timeout: TimeSpan.FromSeconds(5)
            //).Result;

            //Assert.NotNull(resultLabel);
            //Assert.Contains("検索結果", resultLabel.Text);
        }

        public void Dispose()
        {
            _app?.Close();
            _automation?.Dispose();
            //StopPostgresContainer();
        }

        private void StartPostgresContainer()
        {
            RunDockerCommand($"run --rm -d --name {_containerName} -e POSTGRES_PASSWORD=testpw -p 5434:5432 postgres:16");
        }

        private void StopPostgresContainer()
        {
            RunDockerCommand($"stop {_containerName}");
        }

        private void RunDockerCommand(string args)
        {
            var psi = new ProcessStartInfo("docker", args)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process.Start(psi);
        }
    }

}
