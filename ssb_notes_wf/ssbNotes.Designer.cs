namespace ssb_notes_wf
{
    partial class ssbNotes
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
            this.bgInformation = new System.Windows.Forms.PictureBox();
            this.characterInformations = new System.Windows.Forms.RichTextBox();
            this.characterPicture = new System.Windows.Forms.PictureBox();
            this.cmdSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bgInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // bgInformation
            // 
            this.bgInformation.BackColor = System.Drawing.Color.Transparent;
            this.bgInformation.BackgroundImage = global::ssb_notes_wf.Properties.Resources.bgInfo;
            this.bgInformation.Location = new System.Drawing.Point(0, -2);
            this.bgInformation.Name = "bgInformation";
            this.bgInformation.Size = new System.Drawing.Size(133, 77);
            this.bgInformation.TabIndex = 0;
            this.bgInformation.TabStop = false;
            this.bgInformation.Visible = false;
            this.bgInformation.Click += new System.EventHandler(this.bgInformation_Click);
            // 
            // characterInformations
            // 
            this.characterInformations.Location = new System.Drawing.Point(395, 12);
            this.characterInformations.Name = "characterInformations";
            this.characterInformations.Size = new System.Drawing.Size(305, 406);
            this.characterInformations.TabIndex = 1;
            this.characterInformations.Text = "";
            this.characterInformations.Visible = false;
            this.characterInformations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.characterInformations_KeyDown);
            // 
            // characterPicture
            // 
            this.characterPicture.BackColor = System.Drawing.Color.Transparent;
            this.characterPicture.BackgroundImage = global::ssb_notes_wf.Properties.Resources.bgInfo;
            this.characterPicture.Location = new System.Drawing.Point(52, 12);
            this.characterPicture.Name = "characterPicture";
            this.characterPicture.Size = new System.Drawing.Size(286, 406);
            this.characterPicture.TabIndex = 2;
            this.characterPicture.TabStop = false;
            this.characterPicture.Visible = false;
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(625, 424);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(75, 23);
            this.cmdSend.TabIndex = 3;
            this.cmdSend.Text = "Valider";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Visible = false;
            // 
            // ssbNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(10, 40);
            this.BackgroundImage = global::ssb_notes_wf.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(768, 461);
            this.Controls.Add(this.cmdSend);
            this.Controls.Add(this.characterPicture);
            this.Controls.Add(this.characterInformations);
            this.Controls.Add(this.bgInformation);
            this.Name = "ssbNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ssb notes";
            this.Load += new System.EventHandler(this.ssbNotes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ssbNotes_KeyDown);
            this.Resize += new System.EventHandler(this.ssbNotes_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.bgInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bgInformation;
        private System.Windows.Forms.RichTextBox characterInformations;
        private System.Windows.Forms.PictureBox characterPicture;
        private System.Windows.Forms.Button cmdSend;
    }
}

