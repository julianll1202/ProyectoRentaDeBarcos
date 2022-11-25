namespace ProyectoRentaDeBarcos
{
    partial class NuevaRenta
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.agregar_btn = new System.Windows.Forms.Button();
            this.fecha_in = new System.Windows.Forms.DateTimePicker();
            this.fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.lb_clientes = new System.Windows.Forms.ListBox();
            this.lb_barcos = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(156, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 24);
            this.label9.TabIndex = 93;
            this.label9.Text = "Nueva renta";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(328, 13);
            this.label8.TabIndex = 92;
            this.label8.Text = "Llene los campos con la información correspondiente al nueva renta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 91;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(329, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "No. de cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "No. de barco";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Fecha de finalizacion de viaje";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(7, 71);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(120, 13);
            this.label.TabIndex = 82;
            this.label.Text = "Fecha de Inicio de viaje";
            this.label.Click += new System.EventHandler(this.label_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(453, 138);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 79;
            this.cancel_btn.Text = "Cancelar";
            this.cancel_btn.UseVisualStyleBackColor = true;
            // 
            // agregar_btn
            // 
            this.agregar_btn.Location = new System.Drawing.Point(363, 138);
            this.agregar_btn.Name = "agregar_btn";
            this.agregar_btn.Size = new System.Drawing.Size(75, 23);
            this.agregar_btn.TabIndex = 78;
            this.agregar_btn.Text = "Agregar";
            this.agregar_btn.UseVisualStyleBackColor = true;
            this.agregar_btn.Click += new System.EventHandler(this.agregar_btn_Click);
            // 
            // fecha_in
            // 
            this.fecha_in.CustomFormat = "YYYY-MM-DD";
            this.fecha_in.Location = new System.Drawing.Point(160, 69);
            this.fecha_in.Name = "fecha_in";
            this.fecha_in.Size = new System.Drawing.Size(153, 20);
            this.fecha_in.TabIndex = 95;
            this.fecha_in.ValueChanged += new System.EventHandler(this.fecha_in_ValueChanged);
            // 
            // fecha_fin
            // 
            this.fecha_fin.CustomFormat = "YYYY-MM-DD";
            this.fecha_fin.Location = new System.Drawing.Point(160, 94);
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.Size = new System.Drawing.Size(153, 20);
            this.fecha_fin.TabIndex = 96;
            // 
            // lb_clientes
            // 
            this.lb_clientes.FormattingEnabled = true;
            this.lb_clientes.Location = new System.Drawing.Point(408, 69);
            this.lb_clientes.Name = "lb_clientes";
            this.lb_clientes.Size = new System.Drawing.Size(120, 17);
            this.lb_clientes.TabIndex = 97;
            // 
            // lb_barcos
            // 
            this.lb_barcos.FormattingEnabled = true;
            this.lb_barcos.Location = new System.Drawing.Point(408, 97);
            this.lb_barcos.Name = "lb_barcos";
            this.lb_barcos.Size = new System.Drawing.Size(120, 17);
            this.lb_barcos.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "label1";
            // 
            // NuevaRenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 173);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_barcos);
            this.Controls.Add(this.lb_clientes);
            this.Controls.Add(this.fecha_fin);
            this.Controls.Add(this.fecha_in);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.agregar_btn);
            this.Name = "NuevaRenta";
            this.Text = "NuevaRenta";
            this.Load += new System.EventHandler(this.NuevaRenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button agregar_btn;
        private System.Windows.Forms.DateTimePicker fecha_in;
        private System.Windows.Forms.DateTimePicker fecha_fin;
        private System.Windows.Forms.ListBox lb_clientes;
        private System.Windows.Forms.ListBox lb_barcos;
        private System.Windows.Forms.Label label1;
    }
}