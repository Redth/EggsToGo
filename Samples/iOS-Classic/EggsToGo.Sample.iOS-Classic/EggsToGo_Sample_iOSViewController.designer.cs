// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace EggsToGo.Sample.iOS
{
	[Register ("EggsToGo_Sample_iOSViewController")]
	partial class EggsToGo_Sample_iOSViewController
	{
		[Outlet]
		MonoTouch.UIKit.UILabel labelLastCommand { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (labelLastCommand != null) {
				labelLastCommand.Dispose ();
				labelLastCommand = null;
			}
		}
	}
}
