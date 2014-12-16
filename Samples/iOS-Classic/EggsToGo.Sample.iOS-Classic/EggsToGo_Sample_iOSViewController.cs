using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace EggsToGo.Sample.iOS
{
	public partial class EggsToGo_Sample_iOSViewController : UIViewController
	{
		public EggsToGo_Sample_iOSViewController () : base ("EggsToGo_Sample_iOSViewController", null)
		{
		}

		EggsToGo.Easter easter;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			easter = new Easter (this.View, new EggsToGo.KonamiCode (), new EggsToGo.MortalKombatCode ());

			easter.CommandDetected += cmd => InvokeOnMainThread(() => labelLastCommand.Text = cmd.Value);

			easter.EggDetected += (egg) => {

				var av = new UIAlertView("Cheater!", "You used the " + egg.Name + " Code!", null, "OK", null);
				av.Show();

			};
		}
	}
}

