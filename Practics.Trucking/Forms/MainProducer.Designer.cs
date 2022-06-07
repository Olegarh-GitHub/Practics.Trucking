namespace Practics.Trucking.Forms
{
    partial class MainProducer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProducer));
            this._userAboutButton = new System.Windows.Forms.Button();
            this._usernameLabel = new System.Windows.Forms.Label();
            this._exitLink = new System.Windows.Forms.LinkLabel();
            this._pictureBoxUserPhoto = new System.Windows.Forms.PictureBox();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._allProductsTabPage = new System.Windows.Forms.TabPage();
            this._allProductsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._myOrdersTabPage = new System.Windows.Forms.TabPage();
            this._myOrdersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._addProduct = new System.Windows.Forms.Button();
            this._approveOrders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxUserPhoto)).BeginInit();
            this._tabControl.SuspendLayout();
            this._allProductsTabPage.SuspendLayout();
            this._myOrdersTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // _userAboutButton
            // 
            this._userAboutButton.Location = new System.Drawing.Point(635, 395);
            this._userAboutButton.Name = "_userAboutButton";
            this._userAboutButton.Size = new System.Drawing.Size(159, 23);
            this._userAboutButton.TabIndex = 9;
            this._userAboutButton.Text = "Подробнее об аккаунте";
            this._userAboutButton.UseVisualStyleBackColor = true;
            this._userAboutButton.Click += new System.EventHandler(this._userAboutButton_Click);
            // 
            // _usernameLabel
            // 
            this._usernameLabel.AutoSize = true;
            this._usernameLabel.Location = new System.Drawing.Point(671, 190);
            this._usernameLabel.Name = "_usernameLabel";
            this._usernameLabel.Size = new System.Drawing.Size(85, 15);
            this._usernameLabel.TabIndex = 8;
            this._usernameLabel.Text = "Имя Фамилия";
            // 
            // _exitLink
            // 
            this._exitLink.AutoSize = true;
            this._exitLink.Location = new System.Drawing.Point(689, 426);
            this._exitLink.Name = "_exitLink";
            this._exitLink.Size = new System.Drawing.Size(105, 15);
            this._exitLink.TabIndex = 7;
            this._exitLink.TabStop = true;
            this._exitLink.Text = "Покинуть аккаунт";
            this._exitLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this._exitLink_LinkClicked_1Async);
            // 
            // _pictureBoxUserPhoto
            // 
            this._pictureBoxUserPhoto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_pictureBoxUserPhoto.BackgroundImage")));
            this._pictureBoxUserPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._pictureBoxUserPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._pictureBoxUserPhoto.Location = new System.Drawing.Point(635, 24);
            this._pictureBoxUserPhoto.Name = "_pictureBoxUserPhoto";
            this._pictureBoxUserPhoto.Size = new System.Drawing.Size(159, 163);
            this._pictureBoxUserPhoto.TabIndex = 6;
            this._pictureBoxUserPhoto.TabStop = false;
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
            this._tabControl.TabIndex = 5;
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
            this._allProductsTabPage.Text = "Добавить продукт";
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
            this._myOrdersTabPage.Text = "Подтвердить заказы";
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
            // _addProduct
            // 
            this._addProduct.Location = new System.Drawing.Point(635, 366);
            this._addProduct.Name = "_addProduct";
            this._addProduct.Size = new System.Drawing.Size(159, 23);
            this._addProduct.TabIndex = 10;
            this._addProduct.Text = "Добавить продукт";
            this._addProduct.UseVisualStyleBackColor = true;
            this._addProduct.Click += new System.EventHandler(this._addProduct_Click);
            // 
            // _approveOrders
            // 
            this._approveOrders.Location = new System.Drawing.Point(635, 337);
            this._approveOrders.Name = "_approveOrders";
            this._approveOrders.Size = new System.Drawing.Size(159, 23);
            this._approveOrders.TabIndex = 11;
            this._approveOrders.Text = "Подтвердить заказы";
            this._approveOrders.UseVisualStyleBackColor = true;
            this._approveOrders.Click += new System.EventHandler(this._approveOrders_Click);
            // 
            // MainProducer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._approveOrders);
            this.Controls.Add(this._addProduct);
            this.Controls.Add(this._userAboutButton);
            this.Controls.Add(this._usernameLabel);
            this.Controls.Add(this._exitLink);
            this.Controls.Add(this._pictureBoxUserPhoto);
            this.Controls.Add(this._tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainProducer";
            this.Text = "Грузоперевозки (режим предпринимателя)";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxUserPhoto)).EndInit();
            this._tabControl.ResumeLayout(false);
            this._allProductsTabPage.ResumeLayout(false);
            this._myOrdersTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _userAboutButton;
        private System.Windows.Forms.Label _usernameLabel;
        private System.Windows.Forms.LinkLabel _exitLink;
        private System.Windows.Forms.PictureBox _pictureBoxUserPhoto;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _allProductsTabPage;
        private System.Windows.Forms.TabPage _myOrdersTabPage;
        private System.Windows.Forms.Button _addProduct;
        private System.Windows.Forms.FlowLayoutPanel _allProductsPanel;
        private System.Windows.Forms.FlowLayoutPanel _myOrdersPanel;
        private System.Windows.Forms.Button _approveOrders;
    }
}