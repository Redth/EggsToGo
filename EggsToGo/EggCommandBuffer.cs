using System;
using System.Collections.Generic;
using System.Linq;

namespace EggsToGo
{
	class EggCommandBuffer
	{
		readonly object queueLock = new object();

		LinkedList<Command> buffer;

		public int Size { get; private set; }

		public EggCommandBuffer(int size)
		{
			Size = size;
			buffer = new LinkedList<Command> ();
		}

		public void Add(Command cmd)
		{
			lock (queueLock)
			{
				buffer.AddLast (cmd);

				while (buffer.Count > Size)
					buffer.RemoveFirst ();
			}
		}

		public void Clear()
		{
			lock (queueLock)
				buffer.Clear ();
		}


		public Command[] BufferedCommands
		{
			get 
			{
				lock (queueLock)
					return buffer.ToArray ();
			}
		}

		public IEnumerable<Egg> FindEggs(IEnumerable<Egg> eggs)
		{
			var matched = new List<Egg> ();

			var bufferedCmds = this.BufferedCommands;

			foreach (var egg in eggs)
			{
				foreach (var seq in egg.MatchingSequences)
				{
					if (seq.SequenceEqual (bufferedCmds.Skip (bufferedCmds.Length - seq.Count())))
					{
						matched.Add (egg);
						break;
					}
				}
			}

			return matched;
		}
	}
}