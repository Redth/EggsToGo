using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using EggsToGo;

namespace EggsToGo.Sample.Android
{
	[Activity (Label = "EggsToGo Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		TextView textViewLastCommand;

		EggsToGo.Easter easter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			textViewLastCommand = FindViewById<TextView> (Resource.Id.textViewLastCommand);

			var EasyEgg = new CustomEgg ("Easy").WatchForSequence (
				Command.SwipeUp (), Command.SwipeDown (), Command.Tap ());

			easter = new EggsToGo.Easter (new KonamiCode (), new MortalKombatCode (), EasyEgg);
			easter.CommandDetected += (command) => RunOnUiThread(() => textViewLastCommand.Text = command.Value);
			easter.EggDetected += (egg) => Toast.MakeText(this, "You've entered the " + egg.Name + " Code!", ToastLength.Long).Show();
		}

		public override bool OnTouchEvent (MotionEvent e)
		{
			//We must tell easter about the touche events
			easter.OnTouchEvent (e);

			return base.OnTouchEvent (e);
		}
	}
}


