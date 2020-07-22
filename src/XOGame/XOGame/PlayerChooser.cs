using System;
using System.Windows.Forms;

namespace XOGame
{
	public partial class PlayerChooser : Form
	{
		public PlayerChooser()
		{
			InitializeComponent();
		}

		public (PlayerType, PlayerType)? Choose()
		{
			cbPlayer1.SelectedIndex = 0;
			cbPlayer2.SelectedIndex = 1;

			if (ShowDialog() != DialogResult.OK) return null;

			var player1 = (PlayerType)Enum.Parse(typeof(PlayerType), cbPlayer1.SelectedItem.ToString());
			var player2 = (PlayerType)Enum.Parse(typeof(PlayerType), cbPlayer2.SelectedItem.ToString());

			return (player1, player2);
		}
	}
}
