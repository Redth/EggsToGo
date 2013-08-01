using System;
using System.Linq;

namespace EggsToGo
{
	public abstract class EasterBase
	{
		public delegate void EggDetectedDelegate (Egg egg);
		public event EggDetectedDelegate EggDetected;

		public delegate void CommandDetectedDelegate (Command command);
		public event CommandDetectedDelegate CommandDetected;

		private EggCommandBuffer buffer;

		public Egg[] Eggs { get; private set; }
		public Command[] BufferedCommands 
		{ 
			get 
			{ 
				if (buffer == null)
					return null;

				return buffer.BufferedCommands;
			} 
		}

		public EasterBase (params Egg[] eggs)
		{
			Eggs = eggs;

			var size = (from e in eggs select e.BufferLengthRequired ()).Max ();

			buffer = new EggCommandBuffer (size);

		}

		internal void AddCommand(Command command)
		{
			buffer.Add (command);

			var evt = CommandDetected;
			if (evt != null)
				evt (command);

			var matched = buffer.FindEggs (Eggs);

			if (matched == null)
				return;

			foreach (var m in matched)
			{
				var evt2 = EggDetected;
				if (evt2 != null)
					evt2 (m);
			}
		}

	}
}