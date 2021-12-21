namespace Pipes_and_Paths_Game
{
    partial class gamePage
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
            this.pictureBoxBotCards = new System.Windows.Forms.PictureBox();
            this.pictureBoxBoard = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonBegin = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.pictureBoxPlayerCards = new System.Windows.Forms.PictureBox();
            this.buttonEndTurn = new System.Windows.Forms.Button();
            this.radioButtonSmartBot = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBotCards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerCards)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBotCards
            // 
            this.pictureBoxBotCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBotCards.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxBotCards.Location = new System.Drawing.Point(115, 55);
            this.pictureBoxBotCards.Name = "pictureBoxBotCards";
            this.pictureBoxBotCards.Size = new System.Drawing.Size(360, 60);
            this.pictureBoxBotCards.TabIndex = 0;
            this.pictureBoxBotCards.TabStop = false;
            // 
            // pictureBoxBoard
            // 
            this.pictureBoxBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxBoard.Location = new System.Drawing.Point(136, 121);
            this.pictureBoxBoard.Name = "pictureBoxBoard";
            this.pictureBoxBoard.Size = new System.Drawing.Size(320, 400);
            this.pictureBoxBoard.TabIndex = 1;
            this.pictureBoxBoard.TabStop = false;
            this.pictureBoxBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxBoard_MouseClick);
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.SystemColors.Control;
            this.labelTitle.CausesValidation = false;
            this.labelTitle.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(323, 33);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Paths and Pipes Game";
            // 
            // buttonBegin
            // 
            this.buttonBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBegin.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonBegin.Location = new System.Drawing.Point(380, 9);
            this.buttonBegin.Name = "buttonBegin";
            this.buttonBegin.Size = new System.Drawing.Size(115, 39);
            this.buttonBegin.TabIndex = 3;
            this.buttonBegin.Text = "Begin";
            this.buttonBegin.UseVisualStyleBackColor = true;
            this.buttonBegin.Click += new System.EventHandler(this.buttonBegin_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonExit.Location = new System.Drawing.Point(501, 9);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(115, 39);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // pictureBoxPlayerCards
            // 
            this.pictureBoxPlayerCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPlayerCards.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBoxPlayerCards.Location = new System.Drawing.Point(115, 527);
            this.pictureBoxPlayerCards.Name = "pictureBoxPlayerCards";
            this.pictureBoxPlayerCards.Size = new System.Drawing.Size(360, 60);
            this.pictureBoxPlayerCards.TabIndex = 5;
            this.pictureBoxPlayerCards.TabStop = false;
            this.pictureBoxPlayerCards.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxPlayerCards_MouseClick);
            // 
            // buttonEndTurn
            // 
            this.buttonEndTurn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEndTurn.Font = new System.Drawing.Font("UD Digi Kyokasho NK-R", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonEndTurn.Location = new System.Drawing.Point(501, 67);
            this.buttonEndTurn.Name = "buttonEndTurn";
            this.buttonEndTurn.Size = new System.Drawing.Size(115, 39);
            this.buttonEndTurn.TabIndex = 6;
            this.buttonEndTurn.Text = "End Turn?";
            this.buttonEndTurn.UseVisualStyleBackColor = true;
            this.buttonEndTurn.Visible = false;
            this.buttonEndTurn.Click += new System.EventHandler(this.buttonEndTurn_Click);
            // 
            // radioButtonSmartBot
            // 
            this.radioButtonSmartBot.AutoSize = true;
            this.radioButtonSmartBot.Location = new System.Drawing.Point(259, 15);
            this.radioButtonSmartBot.Name = "radioButtonSmartBot";
            this.radioButtonSmartBot.Size = new System.Drawing.Size(115, 24);
            this.radioButtonSmartBot.TabIndex = 7;
            this.radioButtonSmartBot.TabStop = true;
            this.radioButtonSmartBot.Text = "Smart Bot?";
            this.radioButtonSmartBot.UseVisualStyleBackColor = true;
            // 
            // gamePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(628, 594);
            this.Controls.Add(this.radioButtonSmartBot);
            this.Controls.Add(this.buttonEndTurn);
            this.Controls.Add(this.pictureBoxPlayerCards);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonBegin);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBoxBoard);
            this.Controls.Add(this.pictureBoxBotCards);
            this.Name = "gamePage";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Page";
            this.Resize += new System.EventHandler(this.gamePage_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBotCards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBotCards;
        private System.Windows.Forms.PictureBox pictureBoxBoard;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonBegin;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.PictureBox pictureBoxPlayerCards;
        private System.Windows.Forms.Button buttonEndTurn;
        private System.Windows.Forms.RadioButton radioButtonSmartBot;
    }
}

