using System;
using System.Collections.Generic;
using System.Linq;

namespace EggsToGo
{
	public abstract class Egg
	{
		public abstract string Name { get; }
		public abstract IEnumerable<IEnumerable<Command>> MatchingSequences { get; }

		public int BufferLengthRequired()
		{
			if (MatchingSequences == null || MatchingSequences.Count() <= 0)
				return 0;

			return (from m in MatchingSequences select m.Count()).Max ();
		}
	}

	public class CustomEgg : Egg
	{
		public CustomEgg(string name)
		{
			this.name = name;
		}

		public override string Name { get { return name; } }
		public override IEnumerable<IEnumerable<Command>> MatchingSequences { get { return sequences; } }

		List<List<Command>> sequences = new List<List<Command>>();
		string name = string.Empty;

		public CustomEgg WatchForSequence(params Command[] commands)
		{
			sequences.Add (commands.ToList ());
			return this;
		}	 
	}

	public class KonamiCode : Egg
	{
		public override string Name { get { return "Konami"; } }

		public override IEnumerable<IEnumerable<Command>> MatchingSequences 
		{
			get
			{
				return new List<List<Command>> () {
					new List<Command> () { 
						new SwipeUpCommand(), new SwipeUpCommand(), new SwipeDownCommand(),
						new SwipeDownCommand(), new SwipeLeftCommand(), new SwipeRightCommand(), new SwipeLeftCommand(),
						new SwipeRightCommand(), new TapCommand(), new TapCommand()
					},
					new List<Command> () { 
						new SwipeUpCommand(), new SwipeUpCommand(), new SwipeDownCommand(),
						new SwipeDownCommand(), new SwipeLeftCommand(), new SwipeRightCommand(), new SwipeLeftCommand(),
						new SwipeRightCommand(), new KeyboardCommand('b'), new KeyboardCommand('a')
					},
				};
			}
		}
	}

	public class MortalKombatCode : Egg
	{
		public override string Name { get { return "Mortal Kombat"; } }

		public override IEnumerable<IEnumerable<Command>> MatchingSequences 
		{
			get
			{
				return new List<List<Command>> () { 
					new List<Command>() {
						new SwipeDownCommand(), new SwipeUpCommand(), new SwipeDownCommand(),
						new SwipeDownCommand(), new SwipeLeftCommand(), new SwipeRightCommand(), new SwipeLeftCommand(),
						new SwipeRightCommand(), new TapCommand(), new TapCommand() 
					}
				};
			}
		}
	}
}