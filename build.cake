#tool nuget:?package=NUnit.ConsoleRunner&version=3.7.0
#addin nuget:?package=Cake.Android.SdkManager&version=2.0.1

var sln = "./EggsToGo.sln";
var nuspec = "./EggsToGo.nuspec";

var target = Argument ("target", "all");
var configuration = Argument ("configuration", "Release");

var NUGET_VERSION = Argument("APPVEYOR_BUILD_VERSION", Argument("nugetversion", EnvironmentVariable ("APPVEYOR_BUILD_VERSION") ?? "0.9999"));

var ANDROID_HOME = EnvironmentVariable ("ANDROID_HOME") ?? 
    (IsRunningOnWindows () ? "C:\\Program Files (x86)\\Android\\android-sdk\\" : "");

Task ("prereq").Does (() => {
    var s = new AndroidSdkManagerToolSettings { SdkRoot = ANDROID_HOME, SkipVersionCheck = true };

    AcceptLicenses (s);

    AndroidSdkManagerUpdateAll (s);

    AcceptLicenses (s);

    AndroidSdkManagerInstall (new [] { "platforms;android-15", "platforms;android-24" }, s);
});


Task ("libs").IsDependentOn ("prereq").Does (() => 
{
	NuGetRestore (sln);
	MSBuild (sln, c => c.Configuration = configuration);
});

Task ("nuget").IsDependentOn ("libs").Does (() => 
{
	NuGetPack (nuspec, new NuGetPackSettings { 
		Verbosity = NuGetVerbosity.Detailed,
		Version = NUGET_VERSION
	});	
});

Task ("all").IsDependentOn("nuget");

RunTarget (target);