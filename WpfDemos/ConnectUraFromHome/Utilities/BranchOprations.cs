using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Utilities
{
    public class BranchOprations
    {
        public static List<Branch> GetBranchs()
        {
            var directories = GetlistOfDirectory();
            return directories.Select(item => new Branch {Name = item}).ToList();
        }

        public static IEnumerable<string> GetlistOfDirectory()
        {
            var directories = Directory.GetDirectories(@"D:\Vault")
                              .Select(Path.GetFileName)
                              .ToList();
            return directories;
        }

        public static string BuildBranch(string branchName)
        {
            return @"D:\Vault\" + branchName + @"\Scripts\DeveloperBuild\RunDeveloperBuild.bat";
        }

        private static void StartCommnadPromtInAdminMode()
        {
            var process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = BuildBranch(""),
                Verb = "runas"
            };
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}