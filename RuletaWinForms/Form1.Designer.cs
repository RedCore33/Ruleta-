namespace RuletaWinForms
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCreditos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnNombre;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.ComboBox cmbParidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAñadirApuesta;
        private System.Windows.Forms.ListBox lstApuestas;
        private System.Windows.Forms.Button btnGirar;
        private System.Windows.Forms.Panel pnlRuleta;
        private System.Windows.Forms.ListBox lstRanking;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblCreditos = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnNombre = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbParidad = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAñadirApuesta = new System.Windows.Forms.Button();
            this.lstApuestas = new System.Windows.Forms.ListBox();
            this.btnGirar = new System.Windows.Forms.Button();
            this.pnlRuleta = new System.Windows.Forms.Panel();
            this.lstRanking = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblCreditos
            // 
            this.lblCreditos.AutoSize = true;
            this.lblCreditos.Location = new System.Drawing.Point(20, 20);
            this.lblCreditos.Name = "lblCreditos";
            this.lblCreditos.Size = new System.Drawing.Size(70, 15);
            this.lblCreditos.TabIndex = 0;
            this.lblCreditos.Text = "Créditos: 25";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 45);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(80, 15);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Jugador: ";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(20, 70);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(70, 15);
            this.lblResultado.TabIndex = 2;
            this.lblResultado.Text = "Resultado: ";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 23);
            this.txtNombre.TabIndex = 3;
            // 
            // btnNombre
            // 
            this.btnNombre.Location = new System.Drawing.Point(230, 42);
            this.btnNombre.Name = "btnNombre";
            this.btnNombre.Size = new System.Drawing.Size(75, 23);
            this.btnNombre.TabIndex = 4;
            this.btnNombre.Text = "Confirmar";
            this.btnNombre.UseVisualStyleBackColor = true;
            this.btnNombre.Click += new System.EventHandler(this.btnNombre_Click);
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Número",
            "Color",
            "Par/Impar"});
            this.cmbTipo.Location = new System.Drawing.Point(20, 100);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(100, 23);
            this.cmbTipo.TabIndex = 5;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(130, 100);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(50, 23);
            this.txtValor.TabIndex = 6;
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Items.AddRange(new object[] {
            "Rojo",
            "Gris",
            "Verde"});
            this.cmbColor.Location = new System.Drawing.Point(190, 100);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(70, 23);
            this.cmbColor.TabIndex = 7;
            // 
            // cmbParidad
            // 
            this.cmbParidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParidad.FormattingEnabled = true;
            this.cmbParidad.Items.AddRange(new object[] {
            "Par",
            "Impar"});
            this.cmbParidad.Location = new System.Drawing.Point(270, 100);
            this.cmbParidad.Name = "cmbParidad";
            this.cmbParidad.Size = new System.Drawing.Size(70, 23);
            this.cmbParidad.TabIndex = 8;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(350, 100);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(50, 23);
            this.txtCantidad.TabIndex = 9;
            // 
            // btnAñadirApuesta
            // 
            this.btnAñadirApuesta.Location = new System.Drawing.Point(410, 100);
            this.btnAñadirApuesta.Name = "btnAñadirApuesta";
            this.btnAñadirApuesta.Size = new System.Drawing.Size(100, 23);
            this.btnAñadirApuesta.TabIndex = 10;
            this.btnAñadirApuesta.Text = "Añadir Apuesta";
            this.btnAñadirApuesta.UseVisualStyleBackColor = true;
            this.btnAñadirApuesta.Click += new System.EventHandler(this.btnAñadirApuesta_Click);
            // 
            // lstApuestas
            // 
            this.lstApuestas.FormattingEnabled = true;
            this.lstApuestas.ItemHeight = 15;
            this.lstApuestas.Location = new System.Drawing.Point(20, 130);
            this.lstApuestas.Name = "lstApuestas";
            this.lstApuestas.Size = new System.Drawing.Size(490, 64);
            this.lstApuestas.TabIndex = 11;
            // 
            // btnGirar
            // 
            this.btnGirar.Location = new System.Drawing.Point(20, 210);
            this.btnGirar.Name = "btnGirar";
            this.btnGirar.Size = new System.Drawing.Size(100, 30);
            this.btnGirar.TabIndex = 12;
            this.btnGirar.Text = "Girar Ruleta";
            this.btnGirar.UseVisualStyleBackColor = true;
            this.btnGirar.Click += new System.EventHandler(this.btnGirar_Click);
            // 
            // pnlRuleta
            // 
            this.pnlRuleta.Location = new System.Drawing.Point(130, 210);
            this.pnlRuleta.Name = "pnlRuleta";
            this.pnlRuleta.Size = new System.Drawing.Size(380, 220);
            this.pnlRuleta.TabIndex = 13;
            this.pnlRuleta.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlRuleta_Paint);
            // 
            // lstRanking
            // 
            this.lstRanking.FormattingEnabled = true;
            this.lstRanking.ItemHeight = 15;
            this.lstRanking.Location = new System.Drawing.Point(520, 20);
            this.lstRanking.Name = "lstRanking";
            this.lstRanking.Size = new System.Drawing.Size(150, 409);
            this.lstRanking.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.lstRanking);
            this.Controls.Add(this.pnlRuleta);
            this.Controls.Add(this.btnGirar);
            this.Controls.Add(this.lstApuestas);
            this.Controls.Add(this.btnAñadirApuesta);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbParidad);
            this.Controls.Add(this.cmbColor);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.btnNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCreditos);
            this.Name = "Form1";
            this.Text = "Ruleta WinForms";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
