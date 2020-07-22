using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
	public class MiniMaxAI
	{
		public char[,] CurrentState { get; set; } = null;
		public char MaxPlayer { get; set; } = ' ';

		public void SetState(char[,] state, char player)
		{
			CurrentState = state;
			MaxPlayer = player;
		}

		private int? CheckEnd(char[,] Table)
		{
			// Check rows
			for (var i = 0; i < 3; ++i)
			{
				if (Table[i, 0] != ' ' && Table[i, 0] == Table[i, 1] && Table[i, 1] == Table[i, 2])
				{
					if (Table[i, 0] == MaxPlayer) return 1;
					else return -1;
				}
			}

			// Check columns
			for (var i = 0; i < 3; ++i)
			{
				if (Table[0, i] != ' ' && Table[0, i] == Table[1, i] && Table[1, i] == Table[2, i])
				{
					if (Table[0, i] == MaxPlayer) return 1;
					else return -1;
				}
			}

			// Check diagonals
			if (Table[0, 0] != ' ' && Table[0, 0] == Table[1, 1] && Table[1, 1] == Table[2, 2])
			{
				if (Table[0, 0] == MaxPlayer) return 1;
				else return -1;
			}
			if (Table[0, 2] != ' ' && Table[0, 2] == Table[1, 1] && Table[1, 1] == Table[2, 0])
			{
				if (Table[0, 2] == MaxPlayer) return 1;
				else return -1;
			}

			// Check tie
			var hasEmptyField = false;
			for (var i = 0; !hasEmptyField && i < 3; ++i)
				for (var j = 0; !hasEmptyField && j < 3; ++j)
					hasEmptyField = Table[i, j] == ' ';

			if (!hasEmptyField)
			{
				return 0;
			}

			return null;
		}

		private LinkedList<(char[,], int, int)> CreateNextStates(char[,] state, char player)
		{
			var nextStates = new LinkedList<(char[,], int, int)>();

			for (var i = 0; i < 3; ++i)
			{
				for (var j = 0; j < 3; ++j)
				{
					if (state[i, j] == ' ')
					{
						var newPossibleState = (char[,])state.Clone();
						newPossibleState[i, j] = player;
						nextStates.AddLast((newPossibleState, i, j));
					}
				}
			}

			return nextStates;
		}

		public (int, int) NextTurn
		{
			get
			{
				int i = 0, j = 0;

				do
				{
					var rng = new Random();
					i = rng.Next(0, 3);
					j = rng.Next(0, 3);
				}
				while (CurrentState[i, j] != ' ');

				return (i, j);
			}
		}
	}
}
