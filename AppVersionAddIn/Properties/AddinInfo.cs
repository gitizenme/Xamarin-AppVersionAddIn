using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
	"AppVersionAddIn",
	Namespace = "AppVersionAddIn",
	Version = "1.0"
)]


/// The AddinName assembly attribute specifies the Name of your addin. 
/// The value that you provide here be the name that appears in the Addin Manager.
[assembly: AddinName("Update App Version on Build")]

/// The AddinCategory assembly attribute specifies the addin category of your addin.
/// This is the cateogory name in the Addin Manager that your addin will appear under/
[assembly: AddinCategory("IDE extensions")]

/// The AddinDescription assembly attribute should clearly describe what your addin does.
/// This is the value that appears under the name in the right-hand pane inside the addin manager when a user has selected your addin.
[assembly: AddinDescription("This addin will update the version information for all projects and optionally for iOS and Android app version.")]

/// The AddinAuthor assembly attribute states the author/owner of the addin
[assembly: AddinAuthor("gitizenme")]

/// The AddinUrl assembly attribute provides a link the user can click on to get more information about your addin.
/// This is the url that will open when the user clicks the "More Information" button in the Addin Manager.
[assembly: AddinUrl("https://github.com/gitizenme/Xamarin.AppVersionAddIn")]

