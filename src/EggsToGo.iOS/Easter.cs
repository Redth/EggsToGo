using System;
using System.Linq;
using UIKit;

namespace EggsToGo
{
	public class Easter : EasterBase
	{
		UISwipeGestureRecognizer swipeUp;
		UISwipeGestureRecognizer swipeDown;
		UISwipeGestureRecognizer swipeLeft;
		UISwipeGestureRecognizer swipeRight;
		UITapGestureRecognizer tap;
		UILongPressGestureRecognizer longTap;


		public Easter (UIView viewForGestures, params Egg[] eggs) : base(eggs)
		{
			swipeUp = new UISwipeGestureRecognizer (() => AddCommand (new SwipeUpCommand()));
			swipeUp.Direction = UISwipeGestureRecognizerDirection.Up;
			viewForGestures.AddGestureRecognizer (swipeUp);

			swipeDown = new UISwipeGestureRecognizer (() => AddCommand (new SwipeDownCommand()));
			swipeDown.Direction = UISwipeGestureRecognizerDirection.Down;
			viewForGestures.AddGestureRecognizer (swipeDown);

			swipeLeft = new UISwipeGestureRecognizer (() => AddCommand (new SwipeLeftCommand()));
			swipeLeft.Direction = UISwipeGestureRecognizerDirection.Left;
			viewForGestures.AddGestureRecognizer (swipeLeft);

			swipeRight = new UISwipeGestureRecognizer (() => AddCommand (new SwipeRightCommand()));
			swipeRight.Direction = UISwipeGestureRecognizerDirection.Right;
			viewForGestures.AddGestureRecognizer (swipeRight);

			tap = new UITapGestureRecognizer (() => AddCommand (new TapCommand()));
			tap.NumberOfTapsRequired = 1;
			viewForGestures.AddGestureRecognizer (tap);

			longTap = new UILongPressGestureRecognizer (() => AddCommand (new LongTapCommand()));
			longTap.NumberOfTapsRequired = 1;
			viewForGestures.AddGestureRecognizer (longTap);
		}
	}
}

