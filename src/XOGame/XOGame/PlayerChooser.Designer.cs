namespace XOGame
{
	partial class PlayerChooser
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbPlayer1 = new System.Windows.Forms.ComboBox();
			this.lblPlayer1 = new System.Windows.Forms.Label();
			this.lblPlayer2 = new System.Windows.Forms.Label();
			this.cbPlayer2 = new System.Windows.Forms.ComboBox();
			this.btnAccept = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbPLayer1
			// 
			this.cbPlayer1.FormattingEnabled = true;
			this.cbPlayer1.Items.AddRange(new object[] {
            "Human",
            "AI"});
			this.cbPlayer1.Location = new System.Drawing.Point(66, 17);
			this.cbPlayer1.Name = "cbPLayer1";
			this.cbPlayer1.Size = new System.Drawing.Size(121, 21);
			this.cbPlayer1.TabIndex = 1;
			// 
			// lblPlayer1
			// 
			this.lblPlayer1.AutoSize = true;
			this.lblPlayer1.Location = new System.Drawing.Point(12, 20);
			this.lblPlayer1.Name = "lblPlayer1";
			this.lblPlayer1.Size = new System.Drawing.Size(48, 13);
			this.lblPlayer1.TabIndex = 0;
			this.lblPlayer1.Text = "Player 1:";
			// 
			// lblPlayer2
			// 
			this.lblPlayer2.AutoSize = true;
			this.lblPlayer2.Location = new System.Drawing.Point(12, 54);
			this.lblPlayer2.Name = "lblPlayer2";
			this.lblPlayer2.Size = new System.Drawing.Size(48, 13);
			this.lblPlayer2.TabIndex = 2;
			this.lblPlayer2.Text = "Player 2:";
			// 
			// cbPlayer2
			// 
			this.cbPlayer2.FormattingEnabled = true;
			this.cbPlayer2.Items.AddRange(new object[] {
            "Human",
            "AI"});
			this.cbPlayer2.Location = new System.Drawing.Point(66, 51);
			this.cbPlayer2.Name = "cbPlayer2";
			this.cbPlayer2.Size = new System.Drawing.Size(121, 21);
			this.cbPlayer2.TabIndex = 3;
			// 
			// btnAccept
			// 
			this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAccept.Location = new System.Drawing.Point(12, 85);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(175, 23);
			this.btnAccept.TabIndex = 4;
			this.btnAccept.Text = "Accept";
			this.btnAccept.UseVisualStyleBackColor = true;
			// 
			// PlayerChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(199, 120);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.cbPlayer2);
			this.Controls.Add(this.lblPlayer2);
			this.Controls.Add(this.lblPlayer1);
			this.Controls.Add(this.cbPlayer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PlayerChooser";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Player Chooser";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbPlayer1;
		private System.Windows.Forms.Label lblPlayer1;
		private System.Windows.Forms.Label lblPlayer2;
		private System.Windows.Forms.ComboBox cbPlayer2;
		private System.Windows.Forms.Button btnAccept;
	}
}