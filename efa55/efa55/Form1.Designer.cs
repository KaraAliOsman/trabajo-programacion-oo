namespace efa55
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewPersonas;
        private System.Windows.Forms.TextBox txtNombreCrear;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label lblNombreCrear;
        private System.Windows.Forms.Label lblNombreEliminar;
        private System.Windows.Forms.TextBox txtNombreEliminar;
        private System.Windows.Forms.Button btnEliminar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            lblNombreCrear = new Label();
            txtNombreCrear = new TextBox();
            btnCrear = new Button();
            lblNombreEliminar = new Label();
            txtNombreEliminar = new TextBox();
            btnEliminar = new Button();
            dataGridViewPersonas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPersonas).BeginInit();
            SuspendLayout();
            // 
            // lblNombreCrear
            // 
            lblNombreCrear.AutoSize = true;
            lblNombreCrear.Location = new Point(138, 17);
            lblNombreCrear.Name = "lblNombreCrear";
            lblNombreCrear.Size = new Size(111, 15);
            lblNombreCrear.TabIndex = 0;
            lblNombreCrear.Text = "Nombre para Crear:";
            // 
            // txtNombreCrear
            // 
            txtNombreCrear.Location = new Point(118, 39);
            txtNombreCrear.Margin = new Padding(3, 2, 3, 2);
            txtNombreCrear.Name = "txtNombreCrear";
            txtNombreCrear.Size = new Size(165, 23);
            txtNombreCrear.TabIndex = 1;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(155, 76);
            btnCrear.Margin = new Padding(3, 2, 3, 2);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(82, 22);
            btnCrear.TabIndex = 2;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // lblNombreEliminar
            // 
            lblNombreEliminar.AutoSize = true;
            lblNombreEliminar.Location = new Point(456, 17);
            lblNombreEliminar.Name = "lblNombreEliminar";
            lblNombreEliminar.Size = new Size(126, 15);
            lblNombreEliminar.TabIndex = 3;
            lblNombreEliminar.Text = "Nombre para Eliminar:";
            // 
            // txtNombreEliminar
            // 
            txtNombreEliminar.Location = new Point(445, 39);
            txtNombreEliminar.Margin = new Padding(3, 2, 3, 2);
            txtNombreEliminar.Name = "txtNombreEliminar";
            txtNombreEliminar.Size = new Size(148, 23);
            txtNombreEliminar.TabIndex = 4;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(477, 76);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(82, 22);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dataGridViewPersonas
            // 
            dataGridViewPersonas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPersonas.Location = new Point(10, 113);
            dataGridViewPersonas.Margin = new Padding(3, 2, 3, 2);
            dataGridViewPersonas.Name = "dataGridViewPersonas";
            dataGridViewPersonas.RowHeadersWidth = 51;
            dataGridViewPersonas.RowTemplate.Height = 29;
            dataGridViewPersonas.Size = new Size(691, 283);
            dataGridViewPersonas.TabIndex = 6;
            dataGridViewPersonas.CellValueChanged += dataGridViewPersonas_CellValueChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 405);
            Controls.Add(dataGridViewPersonas);
            Controls.Add(btnEliminar);
            Controls.Add(txtNombreEliminar);
            Controls.Add(lblNombreEliminar);
            Controls.Add(btnCrear);
            Controls.Add(txtNombreCrear);
            Controls.Add(lblNombreCrear);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Gestor de Personas SQLite (.NET 8)";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewPersonas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}