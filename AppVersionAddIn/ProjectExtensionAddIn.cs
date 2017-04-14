using System;
using MonoDevelop.Projects;

namespace AppVersion
{
	public class ProjectExtensionAddIn : DotNetProjectExtension
	{
	protected override System.Threading.Tasks.Task<TargetEvaluationResult> OnRunTarget(MonoDevelop.Core.ProgressMonitor monitor, string target, ConfigurationSelector configuration, TargetEvaluationContext context)
		{
			DotNetProjectConfiguration conf = (DotNetProjectConfiguration)Project.GetConfiguration(configuration);
			MonoDevelop.Core.LoggingService.LogInfo("ProjectExtensionAddIn - Configuration: " + conf.Name);
			MonoDevelop.Core.LoggingService.LogInfo("ProjectExtensionAddIn - Platform: " + conf.Platform);
			MonoDevelop.Core.LoggingService.LogInfo("ProjectExtensionAddIn - conf.TargetFramework.Name: " + conf.TargetFramework.Name);
			MonoDevelop.Core.LoggingService.LogInfo("ProjectExtensionAddIn - conf.TargetRuntime.DisplayName: " + conf.TargetRuntime.DisplayName);
			MonoDevelop.Core.LoggingService.LogInfo("ProjectExtensionAddIn - Project.Name: " + Project.Name);
			MonoDevelop.Core.LoggingService.LogInfo("ProjectExtensionAddIn - Target: " + target);

			// Update project version if not the same as solution version
			if (target.Equals("Build"))
			{
				if (Project.Version.Equals(Project.ParentSolution.Version) == false) 
				{
					Project.Version = Project.ParentSolution.Version;
				}

				// load version propfile

				if (Project.TargetFramework.Id.Identifier.Equals("MonoAndroid")) {
					// update Android Manifest 
					// update AssemblyInfo
				}
				if (Project.TargetFramework.Id.Identifier.Equals("Xamarin.iOS")) {
					// update Info.plist 
					// update AssemblyInfo
				}
				if (Project.TargetFramework.Id.Identifier.Equals(".NETPortable")) {
					// update AssemblyInfo
				}
			}
			 
			return base.OnRunTarget(monitor, target, configuration, context);
		}	
	}
}
