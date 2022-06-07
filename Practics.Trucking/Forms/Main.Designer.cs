namespace Practics.Trucking.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this._tabControl = new System.Windows.Forms.TabControl();
            this._allProductsTabPage = new System.Windows.Forms.TabPage();
            this._allProductsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._myOrdersTabPage = new System.Windows.Forms.TabPage();
            this._pictureBoxUserPhoto = new System.Windows.Forms.PictureBox();
            this._exitLink = new System.Windows.Forms.LinkLabel();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._userAboutButton = new System.Windows.Forms.Button();
            this._offerOrderButton = new System.Windows.Forms.Button();
            this._myOrdersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._tabControl.SuspendLayout();
            this._allProductsTabPage.SuspendLayout();
            this._myOrdersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxUserPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._allProductsTabPage);
            this._tabControl.Controls.Add(this._myOrdersTabPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Left;
            this._tabControl.Location = new System.Drawing.Point(0, 0);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(623, 450);
            this._tabControl.TabIndex = 0;
            // 
            // _allProductsTabPage
            // 
            this._allProductsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this._allProductsTabPage.Controls.Add(this._allProductsPanel);
            this._allProductsTabPage.Location = new System.Drawing.Point(4, 24);
            this._allProductsTabPage.Name = "_allProductsTabPage";
            this._allProductsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._allProductsTabPage.Size = new System.Drawing.Size(615, 422);
            this._allProductsTabPage.TabIndex = 0;
            this._allProductsTabPage.Text = "Все продукты/сделать заказ";
            // 
            // _allProductsPanel
            // 
            this._allProductsPanel.AutoScroll = true;
            this._allProductsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._allProductsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._allProductsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._allProductsPanel.Location = new System.Drawing.Point(3, 3);
            this._allProductsPanel.Name = "_allProductsPanel";
            this._allProductsPanel.Size = new System.Drawing.Size(609, 416);
            this._allProductsPanel.TabIndex = 0;
            // 
            // _myOrdersTabPage
            // 
            this._myOrdersTabPage.BackColor = System.Drawing.SystemColors.Control;
            this._myOrdersTabPage.Controls.Add(this._myOrdersPanel);
            this._myOrdersTabPage.Location = new System.Drawing.Point(4, 24);
            this._myOrdersTabPage.Name = "_myOrdersTabPage";
            this._myOrdersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this._myOrdersTabPage.Size = new System.Drawing.Size(615, 422);
            this._myOrdersTabPage.TabIndex = 1;
            this._myOrdersTabPage.Text = "Мои заказы";
            // 
            // _pictureBoxUserPhoto
            // 
            this._pictureBoxUserPhoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_pictureBoxUserPhoto.BackgroundImage")));
            this._pictureBoxUserPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._pictureBoxUserPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._pictureBoxUserPhoto.Location = new System.Drawing.Point(629, 24);
            this._pictureBoxUserPhoto.Name = "_pictureBoxUserPhoto";
            this._pictureBoxUserPhoto.Size = new System.Drawing.Size(159, 163);
            this._pictureBoxUserPhoto.TabIndex = 1;
            this._pictureBoxUserPhoto.TabStop = false;
            // 
            // _exitLink
            // 
            this._exitLink.AutoSize = true;
            this._exitLink.Location = new System.Drawing.Point(683, 426);
            this._exitLink.Name = "_exitLink";
            this._exitLink.Size = new System.Drawing.Size(105, 15);
            this._exitLink.TabIndex = 2;
            this._exitLink.TabStop = true;
            this._exitLink.Text = "Покинуть аккаунт";
            this._exitLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._exitLink_LinkClicked);
            // 
            // _usernameLabel
            // 
            this._usernameLabel.AutoSize = true;
            this._usernameLabel.Location = new System.Drawing.Point(665, 190);
            this._usernameLabel.Name = "_usernameLabel";
            this._usernameLabel.Size = new System.Drawing.Size(85, 15);
            this._usernameLabel.TabIndex = 3;
            this._usernameLabel.Text = "Имя Фамилия";
            // 
            // _userAboutButton
            // 
            this._userAboutButton.Location = new System.Drawing.Point(629, 395);
            this._userAboutButton.Name = "_userAboutButton";
            this._userAboutButton.Size = new System.Drawing.Size(159, 23);
            this._userAboutButton.TabIndex = 4;
            this._userAboutButton.Text = "Подробнее об аккаунте";
            this._userAboutButton.UseVisualStyleBackColor = true;
            this._userAboutButton.Click += new System.EventHandler(this._userAboutButton_Click);
            // 
            // _offerOrderButton
            // 
            this._offerOrderButton.Location = new System.Drawing.Point(629, 366);
            this._offerOrderButton.Name = "_offerOrderButton";
            this._offerOrderButton.Size = new System.Drawing.Size(159, 23);
            this._offerOrderButton.TabIndex = 5;
            this._offerOrderButton.Text = "Оформить заказ";
            this._offerOrderButton.UseVisualStyleBackColor = true;
            this._offerOrderButton.Click += new System.EventHandler(this._offerOrderButton_Click);
            // 
            // _myOrdersPanel
            // 
            this._myOrdersPanel.AutoScroll = true;
            this._myOrdersPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._myOrdersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._myOrdersPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._myOrdersPanel.Location = new System.Drawing.Point(3, 3);
            this._myOrdersPanel.Name = "_myOrdersPanel";
            this._myOrdersPanel.Size = new System.Drawing.Size(609, 416);
            this._myOrdersPanel.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._offerOrderButton);
            this.Controls.Add(this._userAboutButton);
            this.Controls.Add(this._usernameLabel);
            this.Controls.Add(this._exitLink);
            this.Controls.Add(this._pictureBoxUserPhoto);
            this.Controls.Add(this._tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Грузоперевозки";
            this._tabControl.ResumeLayout(false);
            this._allProductsTabPage.ResumeLayout(false);
            this._myOrdersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxUserPhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _allProductsTabPage;
        private System.Windows.Forms.TabPage _myOrdersTabPage;
        private System.Windows.Forms.PictureBox _pictureBoxUserPhoto;
        private System.Windows.Forms.LinkLabel _exitLink;
        private System.Windows.Forms.Label _usernameLabel;
        private System.Windows.Forms.Button _userAboutButton;
        private System.Windows.Forms.FlowLayoutPanel _allProductsPanel;
        private System.Windows.Forms.Button _offerOrderButton;
        private System.Windows.Forms.FlowLayoutPanel _myOrdersPanel;
    }
}