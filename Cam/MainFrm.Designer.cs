namespace Cam
{
    partial class MainFrm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoSource = new AForge.Controls.VideoSourcePlayer();
            this.SuspendLayout();
            // 
            // videoSource
            // 
            this.videoSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoSource.Location = new System.Drawing.Point(0, 0);
            this.videoSource.Name = "videoSource";
            this.videoSource.Size = new System.Drawing.Size(304, 201);
            this.videoSource.TabIndex = 0;
            this.videoSource.Text = "videoSourcePlayer1";
            this.videoSource.VideoSource = null;
            this.videoSource.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoSource_MouseClick);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 201);
            this.Controls.Add(this.videoSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainFrm";
            this.Text = "Cam";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSource;
    }
}

