namespace UI
{
    partial class Field
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Field));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAddVertex = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddEdge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelXOfPoint = new System.Windows.Forms.Label();
            this.labelYOfPoint = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonMoveVertex = new System.Windows.Forms.Button();
            this.buttonShortestWay = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Linen;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(24, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(950, 635);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // buttonAddVertex
            // 
            this.buttonAddVertex.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddVertex.Location = new System.Drawing.Point(995, 203);
            this.buttonAddVertex.Name = "buttonAddVertex";
            this.buttonAddVertex.Size = new System.Drawing.Size(140, 70);
            this.buttonAddVertex.TabIndex = 1;
            this.buttonAddVertex.Text = "Add Vertex";
            this.buttonAddVertex.UseVisualStyleBackColor = true;
            this.buttonAddVertex.Click += new System.EventHandler(this.buttonAddVertex_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSelect.Location = new System.Drawing.Point(995, 280);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(140, 70);
            this.buttonSelect.TabIndex = 2;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(1141, 280);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(140, 70);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAddEdge
            // 
            this.buttonAddEdge.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddEdge.Location = new System.Drawing.Point(1141, 204);
            this.buttonAddEdge.Name = "buttonAddEdge";
            this.buttonAddEdge.Size = new System.Drawing.Size(140, 70);
            this.buttonAddEdge.TabIndex = 4;
            this.buttonAddEdge.Text = "Add Edge";
            this.buttonAddEdge.UseVisualStyleBackColor = true;
            this.buttonAddEdge.Click += new System.EventHandler(this.buttonAddEdge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1214, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "0";
            // 
            // labelXOfPoint
            // 
            this.labelXOfPoint.AutoSize = true;
            this.labelXOfPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelXOfPoint.Location = new System.Drawing.Point(1214, 60);
            this.labelXOfPoint.Name = "labelXOfPoint";
            this.labelXOfPoint.Size = new System.Drawing.Size(67, 38);
            this.labelXOfPoint.TabIndex = 6;
            this.labelXOfPoint.Text = "null";
            // 
            // labelYOfPoint
            // 
            this.labelYOfPoint.AutoSize = true;
            this.labelYOfPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelYOfPoint.Location = new System.Drawing.Point(1214, 98);
            this.labelYOfPoint.Name = "labelYOfPoint";
            this.labelYOfPoint.Size = new System.Drawing.Size(67, 38);
            this.labelYOfPoint.TabIndex = 7;
            this.labelYOfPoint.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(999, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "number of edge:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(1099, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "point x:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1099, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "point y:";
            // 
            // buttonMoveVertex
            // 
            this.buttonMoveVertex.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMoveVertex.Location = new System.Drawing.Point(1141, 356);
            this.buttonMoveVertex.Name = "buttonMoveVertex";
            this.buttonMoveVertex.Size = new System.Drawing.Size(140, 70);
            this.buttonMoveVertex.TabIndex = 12;
            this.buttonMoveVertex.Text = "Move Vertex";
            this.buttonMoveVertex.UseVisualStyleBackColor = true;
            this.buttonMoveVertex.Click += new System.EventHandler(this.buttonMoveVertex_Click);
            // 
            // buttonShortestWay
            // 
            this.buttonShortestWay.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonShortestWay.Location = new System.Drawing.Point(995, 356);
            this.buttonShortestWay.Name = "buttonShortestWay";
            this.buttonShortestWay.Size = new System.Drawing.Size(140, 70);
            this.buttonShortestWay.TabIndex = 13;
            this.buttonShortestWay.Text = "Shortest Way";
            this.buttonShortestWay.UseVisualStyleBackColor = true;
            this.buttonShortestWay.Click += new System.EventHandler(this.buttonShortestWay_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(995, 432);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(140, 70);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLoad.Location = new System.Drawing.Point(1141, 432);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(140, 70);
            this.buttonLoad.TabIndex = 14;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // Field
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1302, 673);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonShortestWay);
            this.Controls.Add(this.buttonMoveVertex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelYOfPoint);
            this.Controls.Add(this.labelXOfPoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAddEdge);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonAddVertex);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Field";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "курсач";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Field_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Field_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddVertex;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAddEdge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelXOfPoint;
        private System.Windows.Forms.Label labelYOfPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonMoveVertex;
        private System.Windows.Forms.Button buttonShortestWay;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
    }
}

