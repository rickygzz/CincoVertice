using System.Diagnostics;
using Xunit;

namespace CincoVertice.Utils.Tests
{
    public class DotNetPackageTest
    {
        public string output = string.Empty;

        [Fact]
        public async Task DotnetPackageVulnerabilityCheck()
        {
            // Arrange
            Process process = new Process();
            process.StartInfo.FileName = "dotnet";
            process.StartInfo.Arguments = "list package --vulnerable --include-transitive";
            process.StartInfo.WorkingDirectory = "B:\\Programming\\git\\CincoVertice\\dotnet\\"; //Environment.CurrentDirectory;

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            // Act
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            string errorOutput = process.StandardError.ReadToEnd();

            // Assert
            Assert.Contains(
                "The given project `CincoVertice.UI` has no vulnerable packages given the current sources.",
                output);

            Assert.Contains(
                "The given project `CincoVertice.Utils` has no vulnerable packages given the current sources.",
                output);
            Assert.Contains(
                "The given project `CincoVertice.Utils.Tests` has no vulnerable packages given the current sources.",
                output);
            Assert.Contains(
                "The given project `CincoVertice.WinAPI` has no vulnerable packages given the current sources.",
                output);
            Assert.Contains(
                "The given project `CincoVertice.UI.Controls` has no vulnerable packages given the current sources.",
                output);
            Assert.Contains(
                "The given project `CincoVertice.Food` has no vulnerable packages given the current sources.",
                output);
            Assert.Contains(
                "The given project `CincoVertice.Food.Tests` has no vulnerable packages given the current sources.",
                output);
        }

        void process_Exited(object? sender, EventArgs e)
        {
            output += "Exited";
        }

        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            // a line is writen to the out stream. you can use it like:
            output += e.Data;
        }

        void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // a line is writen to the out stream. you can use it like:
            output += e.Data;
        }
    }
}
