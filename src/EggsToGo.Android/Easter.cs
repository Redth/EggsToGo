using System;
using System.Linq;
using Android.App;
using Android.Views;
using System.Collections.Generic;

namespace EggsToGo
{
	public class Easter : EasterBase
	{
		GestureDetector gestureDetector;
		GestureRecognizer gestureRecognizer;

		public Easter (params Egg[] eggs) : base(eggs)
		{
			gestureRecognizer = new GestureRecognizer (this);
			gestureDetector = new GestureDetector (gestureRecognizer);
		}
			
		public void OnTouchEvent(MotionEvent e)
		{
			gestureDetector.OnTouchEvent (e);
		}
	}
}

