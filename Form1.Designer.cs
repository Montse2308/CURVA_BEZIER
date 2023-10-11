namespace curbadebezier
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.P1X = new System.Windows.Forms.TextBox();
            this.grafica = new System.Windows.Forms.Panel();
            this.P1Y = new System.Windows.Forms.TextBox();
            this.P2X = new System.Windows.Forms.TextBox();
            this.P2Y = new System.Windows.Forms.TextBox();
            this.P3X = new System.Windows.Forms.TextBox();
            this.P3Y = new System.Windows.Forms.TextBox();
            this.P4X = new System.Windows.Forms.TextBox();
            this.P4Y = new System.Windows.Forms.TextBox();
            this.actualizar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.actualizar);
            this.panel1.Controls.Add(this.P4Y);
            this.panel1.Controls.Add(this.P4X);
            this.panel1.Controls.Add(this.P3Y);
            this.panel1.Controls.Add(this.P3X);
            this.panel1.Controls.Add(this.P2Y);
            this.panel1.Controls.Add(this.P2X);
            this.panel1.Controls.Add(this.P1Y);
            this.panel1.Controls.Add(this.P1X);
            this.panel1.Controls.Add(this.grafica);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 442);
            this.panel1.TabIndex = 0;
            // 
            // P1X
            // 
            this.P1X.Location = new System.Drawing.Point(685, 39);
            this.P1X.Name = "P1X";
            this.P1X.Size = new System.Drawing.Size(100, 22);
            this.P1X.TabIndex = 1;
            this.P1X.TextChanged += new System.EventHandler(this.P1X_TextChanged);
            // 
            // grafica
            // 
            this.grafica.Location = new System.Drawing.Point(4, 4);
            this.grafica.Name = "grafica";
            this.grafica.Size = new System.Drawing.Size(617, 438);
            this.grafica.TabIndex = 0;
            this.grafica.Paint += new System.Windows.Forms.PaintEventHandler(this.grafica_Paint);
            // 
            // P1Y
            // 
            this.P1Y.Location = new System.Drawing.Point(685, 68);
            this.P1Y.Name = "P1Y";
            this.P1Y.Size = new System.Drawing.Size(100, 22);
            this.P1Y.TabIndex = 2;
            this.P1Y.TextChanged += new System.EventHandler(this.P1Y_TextChanged);
            // 
            // P2X
            // 
            this.P2X.Location = new System.Drawing.Point(685, 128);
            this.P2X.Name = "P2X";
            this.P2X.Size = new System.Drawing.Size(100, 22);
            this.P2X.TabIndex = 3;
            this.P2X.TextChanged += new System.EventHandler(this.P2X_TextChanged);
            // 
            // P2Y
            // 
            this.P2Y.Location = new System.Drawing.Point(685, 156);
            this.P2Y.Name = "P2Y";
            this.P2Y.Size = new System.Drawing.Size(100, 22);
            this.P2Y.TabIndex = 4;
            this.P2Y.TextChanged += new System.EventHandler(this.P2Y_TextChanged);
            // 
            // P3X
            // 
            this.P3X.Location = new System.Drawing.Point(685, 237);
            this.P3X.Name = "P3X";
            this.P3X.Size = new System.Drawing.Size(100, 22);
            this.P3X.TabIndex = 5;
            this.P3X.TextChanged += new System.EventHandler(this.P3X_TextChanged);
            // 
            // P3Y
            // 
            this.P3Y.Location = new System.Drawing.Point(685, 265);
            this.P3Y.Name = "P3Y";
            this.P3Y.Size = new System.Drawing.Size(100, 22);
            this.P3Y.TabIndex = 6;
            this.P3Y.TextChanged += new System.EventHandler(this.P3Y_TextChanged);
            // 
            // P4X
            // 
            this.P4X.Location = new System.Drawing.Point(685, 336);
            this.P4X.Name = "P4X";
            this.P4X.Size = new System.Drawing.Size(100, 22);
            this.P4X.TabIndex = 7;
            this.P4X.TextChanged += new System.EventHandler(this.P4X_TextChanged);
            // 
            // P4Y
            // 
            this.P4Y.Location = new System.Drawing.Point(685, 364);
            this.P4Y.Name = "P4Y";
            this.P4Y.Size = new System.Drawing.Size(100, 22);
            this.P4Y.TabIndex = 8;
            this.P4Y.TextChanged += new System.EventHandler(this.P4Y_TextChanged);
            // 
            // actualizar
            // 
            this.actualizar.Location = new System.Drawing.Point(672, 413);
            this.actualizar.Name = "actualizar";
            this.actualizar.Size = new System.Drawing.Size(75, 23);
            this.actualizar.TabIndex = 9;
            this.actualizar.Text = "Actualizar";
            this.actualizar.UseVisualStyleBackColor = true;
            this.actualizar.Click += new System.EventHandler(this.actualizar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox P1X;
        private System.Windows.Forms.Panel grafica;
        private System.Windows.Forms.TextBox P4Y;
        private System.Windows.Forms.TextBox P4X;
        private System.Windows.Forms.TextBox P3Y;
        private System.Windows.Forms.TextBox P3X;
        private System.Windows.Forms.TextBox P2Y;
        private System.Windows.Forms.TextBox P2X;
        private System.Windows.Forms.TextBox P1Y;
        private System.Windows.Forms.Button actualizar;
    }
}

