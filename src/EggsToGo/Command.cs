using System;

namespace EggsToGo
{
	public class SwipeUpCommand : Command
	{
		public override string Value { get { return "UP"; } }
	}

	public class SwipeDownCommand : Command
	{
		public override string Value { get { return "DOWN"; } }
	}

	public class SwipeLeftCommand : Command
	{
		public override string Value { get { return "LEFT"; } }
	}

	public class SwipeRightCommand : Command
	{
		public override string Value { get { return "RIGHT"; } }
	}

	public class TapCommand : Command
	{
		public override string Value { get { return "TAP"; } }
	}

	public class LongTapCommand : Command
	{
		public override string Value { get { return "LONGTAP"; } }
	}

	public class KeyboardCommand : Command
	{
		public KeyboardCommand(char key)
		{
			KeyboardKey = key;
		}

		public char KeyboardKey { get; set; }
		public override string Value { get { return KeyboardKey.ToString(); } }
	}

	public abstract class Command
	{
		public abstract string Value { get; }

		public override bool Equals (object obj)
		{
			var cmd = obj as Command;

			if (cmd == null)
				return false;

			return cmd.Value.Equals (this.Value);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public static SwipeUpCommand SwipeUp()
		{
			return new SwipeUpCommand();
		}

		public static SwipeDownCommand SwipeDown()
		{
			return new SwipeDownCommand();
		}

		public static SwipeLeftCommand SwipeLeft()
		{
			return new SwipeLeftCommand();
		}

		public static SwipeRightCommand SwipeRight()
		{
			return new SwipeRightCommand();
		}

		public static TapCommand Tap()
		{
			return new TapCommand();
		}

		public static LongTapCommand LongTap()
		{
			return new LongTapCommand();
		}

		public static KeyboardCommand Keyboard(char key)
		{
			return new KeyboardCommand(key);
		}

	}
}