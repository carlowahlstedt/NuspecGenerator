using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuspecGenerator
{
    public class PullCord
    {
        public string ID { get; set; }
        public Version VersionNumber { get; set; }
        public string Authors { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public Uri ProjectUrl { get; set; }
        public Uri LicenseUrl { get; set; }
        public List<Dependency> Dependencies { get; set; } = new List<Dependency>();

        public string Yank()
        {
            Validate();

            var nuspec = new StringBuilder();
            nuspec.AppendLine($"<? xml version=\"1.0\" encoding=\"utf-8\" ?>");
            nuspec.AppendLine($"<package>");
            nuspec.AppendLine($"  <metadata>");
            nuspec.AppendLine($"    <id>{ID}</id>");
            nuspec.AppendLine($"    <version>{VersionNumber}</version>");
            if (Authors != null)
            {
                nuspec.AppendLine($"    <authors>{Authors}</authors>");
            }
            if (Description != null)
            {
                nuspec.AppendLine($"    <description>{Description}</description>");
            }
            if (Language != null)
            {
                nuspec.AppendLine($"    <language>{Language}</language>");
            }
            if (ProjectUrl != null)
            {
                nuspec.AppendLine($"    <projectUrl>{ProjectUrl}</projectUrl>");
            }
            if (LicenseUrl != null)
            {
                nuspec.AppendLine($"    <licenseUrl>{LicenseUrl}</licenseUrl>");
            }
            if (Dependencies.Count < 0)
            {
                nuspec.AppendLine($"    <dependencies>");
                foreach (var item in Dependencies)
                {
                    if (string.IsNullOrWhiteSpace(item.ID))
                    {
                        continue;
                    }

                    var dependencyLine = $"      <dependency id = \"{item.ID}\"";
                    if (item.VersionNumber != null)
                    {
                        dependencyLine += $" version =\"{item.VersionNumber}\"";
                    }
                    dependencyLine += " />";

                    nuspec.AppendLine(dependencyLine);
                }
                nuspec.AppendLine($"    </dependencies>");
            }
            nuspec.AppendLine($"  </metadata>");
            nuspec.AppendLine($"</package>");

            return nuspec.ToString();
        }

        void Validate()
        {
            var error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(ID))
            {
                error.AppendLine(nameof(ID));
            }
            if (VersionNumber == null)
            {
                error.AppendLine(nameof(VersionNumber));
            }

            var errorOutput = error.ToString();
            if (!string.IsNullOrWhiteSpace(errorOutput))
            {
                throw new NotImplementedException(errorOutput);
            }
        }
    }
}


//<? xml version="1.0" encoding="utf-8"?>
//<package>
//  <metadata>
//    <id>sample</id>
//    <version>1.2.3</version>
//    <authors>Kim Abercrombie, Franck Halmaert</authors>
//    <description>Sample exists only to show a sample.nuspec file.</description>
//    <language>en-US</language>
//    <projectUrl>http://xunit.codeplex.com/</projectUrl>
//    <licenseUrl>http://xunit.codeplex.com/license</licenseUrl>
//    <dependencies>
//      <dependency id = "another-package" version="3.0.0" />
//      <dependency id = "yet-another-package" />
//    </ dependencies >
//  </metadata>
//</package>



