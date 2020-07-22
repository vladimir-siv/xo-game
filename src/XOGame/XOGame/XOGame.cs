using System;
using System.Windows.Forms;

namespace XOGame
{
	public partial class XOGame : Form
	{
		private PlayerChooser ChoosePlayers = new PlayerChooser();

		private PlayerType Player1Type = PlayerType.None;
		private PlayerType Player2Type = PlayerType.None;
		private char[,] Table = new char[3, 3];
		private Label[,] DisplayTable = new Label[3, 3];
		private char OnTurn = 'X';

		private bool IsAIOnTurn => OnTurn == 'X' && Player1Type == PlayerType.AI || OnTurn == 'O' && Player2Type == PlayerType.AI;

		public XOGame()
		{
			InitializeComponent();

			DisplayTable[0, 0] = lbl00;
			DisplayTable[0, 1] = lbl01;
			DisplayTable[0, 2] = lbl02;
			DisplayTable[1, 0] = lbl10;
			DisplayTable[1, 1] = lbl11;
			DisplayTable[1, 2] = lbl12;
			DisplayTable[2, 0] = lbl20;
			DisplayTable[2, 1] = lbl21;
			DisplayTable[2, 2] = lbl22;
		}

		#region Start/End Events

		private void XOGame_Shown(object sender, EventArgs e)
		{
			NewGame();
		}

		#endregion

		#region Game setup logic

		private void ResetTable()
		{
			for (var i = 0; i < 3; ++i)
				for (var j = 0; j < 3; ++j)
					Table[i, j] = ' ';
		}
		private void SyncDisplayTable()
		{
			for (var i = 0; i < 3; ++i)
				for (var j = 0; j < 3; ++j)
					DisplayTable[i, j].Text = Table[i, j].ToString();
		}
		private void NewGame()
		{
			(PlayerType, PlayerType)? players = null;
			do players = ChoosePlayers.Choose(); while (players == null);
			Player1Type = players.Value.Item1;
			Player2Type = players.Value.Item2;
			ResetTable();
			SyncDisplayTable();
			OnTurn = 'X';
			if (IsAIOnTurn) AIDelay.Start();
		}

		#endregion

		#region Game loop logic

		#region Controls

		private void SwitchTurn()
		{
			if (OnTurn == 'X') OnTurn = 'O';
			else OnTurn = 'X';
		}
		private string ApplyTurn(int i, int j)
		{
			if (i < 0 || i >= 3) return "Invalid row.";
			if (j < 0 || j >= 3) return "Invalid column.";

			if (Table[i, j] != ' ') return "Field is not empty.";

			Table[i, j] = OnTurn;
			DisplayTable[i, j].Text = OnTurn.ToString();

			if (CheckIsEnd()) return "#END";
			SwitchTurn();
			if (IsAIOnTurn) AIDelay.Start();

			return null;
		}
		private bool CheckIsEnd()
		{
			// Check rows
			for (var i = 0; i < 3; ++i)
			{
				if (Table[i, 0] != ' ' && Table[i, 0] == Table[i, 1] && Table[i, 1] == Table[i, 2])
				{
					MessageBox.Show($"Winner is: {Table[i, 0]}!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
					NewGame();
					return true;
				}
			}

			// Check columns
			for (var i = 0; i < 3; ++i)
			{
				if (Table[0, i] != ' ' && Table[0, i] == Table[1, i] && Table[1, i] == Table[2, i])
				{
					MessageBox.Show($"Winner is: {Table[0, i]}!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
					NewGame();
					return true;
				}
			}

			// Check diagonals
			if (Table[0, 0] != ' ' && Table[0, 0] == Table[1, 1] && Table[1, 1] == Table[2, 2])
			{
				MessageBox.Show($"Winner is: {Table[0, 0]}!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
				NewGame();
				return true;
			}
			if (Table[0, 2] != ' ' && Table[0, 2] == Table[1, 1] && Table[1, 1] == Table[2, 0])
			{
				MessageBox.Show($"Winner is: {Table[0, 2]}!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
				NewGame();
				return true;
			}

			// Check tie
			var hasEmptyField = false;
			for (var i = 0; !hasEmptyField && i < 3; ++i)
				for (var j = 0; !hasEmptyField && j < 3; ++j)
					hasEmptyField = Table[i, j] == ' ';

			if (!hasEmptyField)
			{
				MessageBox.Show("Game is TIE!", "Game End", MessageBoxButtons.OK, MessageBoxIcon.Information);
				NewGame();
				return true;
			}

			return false;
		}

		#endregion

		#region Human

		private void Field_Click(object sender, EventArgs e)
		{
			if (IsAIOnTurn) return;

			var field = (Label)sender;

			var i = Convert.ToInt32(field.Name[3]) - 48;
			var j = Convert.ToInt32(field.Name[4]) - 48;

			var result = ApplyTurn(i, j);
			if (result == "#END") return;
			if (result != null) MessageBox.Show(result, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		#endregion

		#region AI

		private void AIDelay_Tick(object sender, EventArgs e)
		{
			AIDelay.Stop();


		}

		#endregion

		#endregion
	}
}
