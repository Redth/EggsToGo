using System;
using Android.Views;

namespace EggsToGo
{
	internal class GestureRecognizer : Java.Lang.Object, GestureDetector.IOnGestureListener
	{
		const int MINIMUM_MOVEMENT_DISTANCE = 20;

		EasterBase Easter;

		public GestureRecognizer (EasterBase easter)
		{
			Easter = easter;
		}

		#region IOnGestureListener implementation
		public bool OnDown (MotionEvent e)
		{
			return false;
		}

		public bool OnFling (MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
		{
			float dx = e2.GetX() - e1.GetX();
			float dy = e2.GetY() - e1.GetY();

			if (Math.Abs((int) dx) <= MINIMUM_MOVEMENT_DISTANCE &&
			    Math.Abs((int) dy) <= MINIMUM_MOVEMENT_DISTANCE)
				return false;

			Command cmd = null;

			if (Math.Abs (dx) > Math.Abs (dy))
			{
				if (dx > 0)
					cmd = new SwipeRightCommand ();
				else
					cmd = new SwipeLeftCommand ();
			}
			else
			{
				if (dy > 0)
					cmd = new SwipeDownCommand ();
				else
					cmd = new SwipeUpCommand ();
			}

			if (cmd != null)
				Easter.AddCommand (cmd);

			return false;
		}

		public void OnLongPress (MotionEvent e)
		{
			Easter.AddCommand (new LongTapCommand ());
		}

		public bool OnScroll (MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
		{
			return false;
		}

		public void OnShowPress (MotionEvent e)
		{
		}

		public bool OnSingleTapUp (MotionEvent e)
		{
			Easter.AddCommand (new TapCommand ());

			return false;
		}
		#endregion
	}
}

