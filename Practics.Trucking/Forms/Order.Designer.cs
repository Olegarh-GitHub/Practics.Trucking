namespace Practics.Trucking.Forms
{
    partial class Order
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
            this._allProductsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this._productsCountLabel = new System.Windows.Forms.Label();
            this._totalSumLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this._addressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _allProductsPanel
            // 
            this._allProductsPanel.AutoScroll = true;
            this._allProductsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._allProductsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._allProductsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._allProductsPanel.Location = new System.Drawing.Point(0, 0);
            this._allProductsPanel.Name = "_allProductsPanel";
            this._allProductsPanel.Size = new System.Drawing.Size(426, 450);
            this._allProductsPanel.TabIndex = 1;
            // 
            // _productsCountLabel
            // 
            this._productsCountLabel.AutoSize = true;
            this._productsCountLabel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._productsCountLabel.Location = new System.Drawing.Point(432, 9);
            this._productsCountLabel.Name = "_productsCountLabel";
            this._productsCountLabel.Size = new System.Drawing.Size(254, 20);
            this._productsCountLabel.TabIndex = 2;
            this._productsCountLabel.Text = "Количество товаров к перевозке:";
            // 
            // _totalSumLabel
            // 
            this._totalSumLabel.AutoSize = true;
            this._totalSumLabel.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._totalSumLabel.Location = new System.Drawing.Point(432, 280);
            this._totalSumLabel.Name = "_totalSumLabel";
            this._totalSumLabel.Size = new System.Drawing.Size(242, 23);
            this._totalSumLabel.TabIndex = 3;
            this._totalSumLabel.Text = "Итоговая сумма перевозки:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(356, 61);
            this.button1.TabIndex = 4;
            this.button1.Text = "Подтверждение заказа";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _addressLabel
            // 
            this._addressLabel.AutoSize = true;
            this._addressLabel.Font = new System.Drawing.Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._addressLabel.Location = new System.Drawing.Point(432, 318);
            this._addressLabel.MaximumSize = new System.Drawing.Size(350, 0);
            this._addressLabel.Name = "_addressLabel";
            this._addressLabel.Size = new System.Drawing.Size(149, 23);
            this._addressLabel.TabIndex = 5;
            this._addressLabel.Text = "Адрес доставки:";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._addressLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._totalSumLabel);
            this.Controls.Add(this._productsCountLabel);
            this.Controls.Add(this._allProductsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _allProductsPanel;
        private System.Windows.Forms.Label _productsCountLabel;
        private System.Windows.Forms.Label _totalSumLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label _addressLabel;
    }
}