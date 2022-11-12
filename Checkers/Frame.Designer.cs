namespace Checkers
{
    partial class Frame
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.board1 = new Checkers.Board();
            this.SuspendLayout();
            // 
            // board1
            // 
            this.board1.Location = new System.Drawing.Point(3, 0);
            this.board1.MaximumSize = new System.Drawing.Size(512, 512);
            this.board1.MinimumSize = new System.Drawing.Size(512, 512);
            this.board1.Name = "board1";
            this.board1.Size = new System.Drawing.Size(512, 512);
            this.board1.TabIndex = 0;
            // 
            // Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(518, 515);
            this.Controls.Add(this.board1);
            this.MaximizeBox = false;
            this.Name = "Frame";
            this.Text = "Test";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Board board1;
    }
}

