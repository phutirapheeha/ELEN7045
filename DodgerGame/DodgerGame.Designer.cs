namespace DodgerGame
{
    partial class DodgerGame
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
            this.components = new System.ComponentModel.Container();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // DodgerGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "DodgerGame";
            this.Text = "Dodger Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DodgerGame_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DodgerGame_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameTimer;
    }
}

