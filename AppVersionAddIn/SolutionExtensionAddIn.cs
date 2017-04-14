using System;
using MonoDevelop.Projects;
using System.IO;

namespace AppVersion
{
	public class SolutionExtensionAddIn : SolutionExtension
 	{
		protected override System.Threading.Tasks.Task<BuildResult> Build(MonoDevelop.Core.ProgressMonitor monitor, ConfigurationSelector configuration, OperationContext operationContext)
		{
			SolutionConfiguration conf = Solution.GetConfiguration(configuration);
			MonoDevelop.Core.LoggingService.LogInfo("SolutionExtensionAddIn conf: " + conf.Name);
			MonoDevelop.Core.LoggingService.LogInfo("SolutionExtensionAddIn Solution.Version: " + Solution.Version);

			// load version propfile 
			VersionProfile versionProfile = null;
			var fileName = Solution.BaseDirectory + Path.DirectorySeparatorChar + "AppVersion.prop";
			if (!File.Exists(fileName))
			{
				versionProfile = VersionProfile.Create();
				var s = versionProfile.Serialized;
				File.WriteAllText(fileName, s);
			}
			else
			{
				var content = File.ReadAllText(fileName);
				versionProfile = VersionProfile.Create(content);
			}

			if (versionProfile != null && !versionProfile.Version.Equals(Solution.Version))
			{
				
				versionProfile.IncrementPatch();
				Solution.Version = versionProfile.Version;
				File.WriteAllText(fileName, versionProfile.Serialized);
				Solution.UserProperties.SetValue("AppVersion", versionProfile);
				Solution.SaveUserProperties();
			}

			return base.Build(monitor, configuration, operationContext);
		}
	}
}
