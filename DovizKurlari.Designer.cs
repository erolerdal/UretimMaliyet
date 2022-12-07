namespace MaliyetProgram
{
    partial class DovizKurlari
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
            System.Windows.Forms.Label dovizIdLabel;
            System.Windows.Forms.Label dovizTipiLabel;
            System.Windows.Forms.Label dovizKuruLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DovizKurlari));
            System.Windows.Forms.Label label1;
            this.mALIYETDataSet3 = new MaliyetProgram.MALIYETDataSet3();
            this.dovizBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dovizTableAdapter = new MaliyetProgram.MALIYETDataSet3TableAdapters.DovizTableAdapter();
            this.tableAdapterManager = new MaliyetProgram.MALIYETDataSet3TableAdapters.TableAdapterManager();
            this.dovizBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.dovizBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dovizDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dovizIdTextBox = new System.Windows.Forms.TextBox();
            this.dovizTipiTextBox = new System.Windows.Forms.TextBox();
            this.dovizKuruTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            dovizIdLabel = new System.Windows.Forms.Label();
            dovizTipiLabel = new System.Windows.Forms.Label();
            dovizKuruLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mALIYETDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dovizBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dovizBindingNavigator)).BeginInit();
            this.dovizBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dovizDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dovizIdLabel
            // 
            dovizIdLabel.AutoSize = true;
            dovizIdLabel.Location = new System.Drawing.Point(8, 118);
            dovizIdLabel.Name = "dovizIdLabel";
            dovizIdLabel.Size = new System.Drawing.Size(49, 13);
            dovizIdLabel.TabIndex = 2;
            dovizIdLabel.Text = "Doviz Id:";
            // 
            // dovizTipiLabel
            // 
            dovizTipiLabel.AutoSize = true;
            dovizTipiLabel.Location = new System.Drawing.Point(8, 144);
            dovizTipiLabel.Name = "dovizTipiLabel";
            dovizTipiLabel.Size = new System.Drawing.Size(57, 13);
            dovizTipiLabel.TabIndex = 4;
            dovizTipiLabel.Text = "Doviz Tipi:";
            // 
            // dovizKuruLabel
            // 
            dovizKuruLabel.AutoSize = true;
            dovizKuruLabel.Location = new System.Drawing.Point(8, 170);
            dovizKuruLabel.Name = "dovizKuruLabel";
            dovizKuruLabel.Size = new System.Drawing.Size(62, 13);
            dovizKuruLabel.TabIndex = 6;
            dovizKuruLabel.Text = "Doviz Kuru:";
            // 
            // mALIYETDataSet3
            // 
            this.mALIYETDataSet3.DataSetName = "MALIYETDataSet3";
            this.mALIYETDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dovizBindingSource
            // 
            this.dovizBindingSource.DataMember = "Doviz";
            this.dovizBindingSource.DataSource = this.mALIYETDataSet3;
            // 
            // dovizTableAdapter
            // 
            this.dovizTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.DovizTableAdapter = this.dovizTableAdapter;
            this.tableAdapterManager.UpdateOrder = MaliyetProgram.MALIYETDataSet3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dovizBindingNavigator
            // 
            this.dovizBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.dovizBindingNavigator.BindingSource = this.dovizBindingSource;
            this.dovizBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.dovizBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.dovizBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.dovizBindingNavigatorSaveItem});
            this.dovizBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.dovizBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.dovizBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.dovizBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.dovizBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.dovizBindingNavigator.Name = "dovizBindingNavigator";
            this.dovizBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.dovizBindingNavigator.Size = new System.Drawing.Size(789, 25);
            this.dovizBindingNavigator.TabIndex = 0;
            this.dovizBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // dovizBindingNavigatorSaveItem
            // 
            this.dovizBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dovizBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("dovizBindingNavigatorSaveItem.Image")));
            this.dovizBindingNavigatorSaveItem.Name = "dovizBindingNavigatorSaveItem";
            this.dovizBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.dovizBindingNavigatorSaveItem.Text = "Save Data";
            this.dovizBindingNavigatorSaveItem.Click += new System.EventHandler(this.dovizBindingNavigatorSaveItem_Click);
            // 
            // dovizDataGridView
            // 
            this.dovizDataGridView.AutoGenerateColumns = false;
            this.dovizDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dovizDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dovizDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dovizDataGridView.DataSource = this.dovizBindingSource;
            this.dovizDataGridView.Location = new System.Drawing.Point(422, 12);
            this.dovizDataGridView.Name = "dovizDataGridView";
            this.dovizDataGridView.RowHeadersVisible = false;
            this.dovizDataGridView.Size = new System.Drawing.Size(355, 307);
            this.dovizDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DovizId";
            this.dataGridViewTextBoxColumn1.FillWeight = 50F;
            this.dataGridViewTextBoxColumn1.HeaderText = "DovizId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DovizTipi";
            this.dataGridViewTextBoxColumn2.FillWeight = 150F;
            this.dataGridViewTextBoxColumn2.HeaderText = "DovizTipi";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DovizKuru";
            this.dataGridViewTextBoxColumn3.FillWeight = 150F;
            this.dataGridViewTextBoxColumn3.HeaderText = "DovizKuru";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dovizIdTextBox
            // 
            this.dovizIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dovizBindingSource, "DovizId", true));
            this.dovizIdTextBox.Location = new System.Drawing.Point(76, 115);
            this.dovizIdTextBox.Name = "dovizIdTextBox";
            this.dovizIdTextBox.ReadOnly = true;
            this.dovizIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.dovizIdTextBox.TabIndex = 3;
            // 
            // dovizTipiTextBox
            // 
            this.dovizTipiTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dovizBindingSource, "DovizTipi", true));
            this.dovizTipiTextBox.Location = new System.Drawing.Point(76, 141);
            this.dovizTipiTextBox.Name = "dovizTipiTextBox";
            this.dovizTipiTextBox.Size = new System.Drawing.Size(100, 20);
            this.dovizTipiTextBox.TabIndex = 5;
            // 
            // dovizKuruTextBox
            // 
            this.dovizKuruTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dovizBindingSource, "DovizKuru", true));
            this.dovizKuruTextBox.Location = new System.Drawing.Point(76, 167);
            this.dovizKuruTextBox.Name = "dovizKuruTextBox";
            this.dovizKuruTextBox.Size = new System.Drawing.Size(100, 20);
            this.dovizKuruTextBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(109, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "INTERNET - Merkez Bankası Döviz Kurları";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox1.ForeColor = System.Drawing.Color.Yellow;
            this.textBox1.Location = new System.Drawing.Point(87, 239);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(259, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(142, 265);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 20);
            this.textBox2.TabIndex = 10;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(142, 291);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(161, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(111, 323);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(235, 13);
            label1.TabIndex = 12;
            label1.Text = "EURO ve DOLAR kurları Otomatik Çekilmektedir";
            // 
            // DovizKurlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(789, 354);
            this.Controls.Add(label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(dovizIdLabel);
            this.Controls.Add(this.dovizIdTextBox);
            this.Controls.Add(dovizTipiLabel);
            this.Controls.Add(this.dovizTipiTextBox);
            this.Controls.Add(dovizKuruLabel);
            this.Controls.Add(this.dovizKuruTextBox);
            this.Controls.Add(this.dovizDataGridView);
            this.Controls.Add(this.dovizBindingNavigator);
            this.Name = "DovizKurlari";
            this.Text = "DovizKurlari";
            this.Load += new System.EventHandler(this.DovizKurlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mALIYETDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dovizBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dovizBindingNavigator)).EndInit();
            this.dovizBindingNavigator.ResumeLayout(false);
            this.dovizBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dovizDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MALIYETDataSet3 mALIYETDataSet3;
        private System.Windows.Forms.BindingSource dovizBindingSource;
        private MALIYETDataSet3TableAdapters.DovizTableAdapter dovizTableAdapter;
        private MALIYETDataSet3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator dovizBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton dovizBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView dovizDataGridView;
        private System.Windows.Forms.TextBox dovizIdTextBox;
        private System.Windows.Forms.TextBox dovizTipiTextBox;
        private System.Windows.Forms.TextBox dovizKuruTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}