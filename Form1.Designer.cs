namespace NewRedimensionadorImagem
{
    partial class Form1
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
            this.btnRedimensionar = new System.Windows.Forms.Button();
            this.lblPastaOrigem = new System.Windows.Forms.Label();
            this.lblPastaDestino = new System.Windows.Forms.Label();
            this.txtPastaOrigem = new System.Windows.Forms.TextBox();
            this.txtPastaDestino = new System.Windows.Forms.TextBox();
            this.ckbSubstituirArquivos = new System.Windows.Forms.CheckBox();
            this.ckbIncluirSubPasta = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnRedimensionar
            // 
            this.btnRedimensionar.Location = new System.Drawing.Point(16, 155);
            this.btnRedimensionar.Name = "btnRedimensionar";
            this.btnRedimensionar.Size = new System.Drawing.Size(589, 39);
            this.btnRedimensionar.TabIndex = 0;
            this.btnRedimensionar.Text = "Redimensionar";
            this.btnRedimensionar.UseVisualStyleBackColor = true;
            this.btnRedimensionar.Click += new System.EventHandler(this.btnRedimensionar_Click);
            // 
            // lblPastaOrigem
            // 
            this.lblPastaOrigem.AutoSize = true;
            this.lblPastaOrigem.Location = new System.Drawing.Point(13, 13);
            this.lblPastaOrigem.Name = "lblPastaOrigem";
            this.lblPastaOrigem.Size = new System.Drawing.Size(70, 13);
            this.lblPastaOrigem.TabIndex = 1;
            this.lblPastaOrigem.Text = "Pasta Origem";
            // 
            // lblPastaDestino
            // 
            this.lblPastaDestino.AutoSize = true;
            this.lblPastaDestino.Location = new System.Drawing.Point(13, 93);
            this.lblPastaDestino.Name = "lblPastaDestino";
            this.lblPastaDestino.Size = new System.Drawing.Size(73, 13);
            this.lblPastaDestino.TabIndex = 2;
            this.lblPastaDestino.Text = "Pasta Destino";
            // 
            // txtPastaOrigem
            // 
            this.txtPastaOrigem.Location = new System.Drawing.Point(16, 30);
            this.txtPastaOrigem.Name = "txtPastaOrigem";
            this.txtPastaOrigem.Size = new System.Drawing.Size(589, 20);
            this.txtPastaOrigem.TabIndex = 3;
            // 
            // txtPastaDestino
            // 
            this.txtPastaDestino.Location = new System.Drawing.Point(16, 110);
            this.txtPastaDestino.Name = "txtPastaDestino";
            this.txtPastaDestino.Size = new System.Drawing.Size(589, 20);
            this.txtPastaDestino.TabIndex = 4;
            // 
            // ckbSubstituirArquivos
            // 
            this.ckbSubstituirArquivos.AutoSize = true;
            this.ckbSubstituirArquivos.Location = new System.Drawing.Point(16, 56);
            this.ckbSubstituirArquivos.Name = "ckbSubstituirArquivos";
            this.ckbSubstituirArquivos.Size = new System.Drawing.Size(113, 17);
            this.ckbSubstituirArquivos.TabIndex = 5;
            this.ckbSubstituirArquivos.Text = "Substituir Arquivos";
            this.ckbSubstituirArquivos.UseVisualStyleBackColor = true;
            this.ckbSubstituirArquivos.CheckedChanged += new System.EventHandler(this.ckbSubstituirArquivos_CheckedChanged);
            // 
            // ckbIncluirSubPasta
            // 
            this.ckbIncluirSubPasta.AutoSize = true;
            this.ckbIncluirSubPasta.Location = new System.Drawing.Point(135, 56);
            this.ckbIncluirSubPasta.Name = "ckbIncluirSubPasta";
            this.ckbIncluirSubPasta.Size = new System.Drawing.Size(111, 17);
            this.ckbIncluirSubPasta.TabIndex = 6;
            this.ckbIncluirSubPasta.Text = "Incluir Sub Pastas";
            this.ckbIncluirSubPasta.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 211);
            this.Controls.Add(this.ckbIncluirSubPasta);
            this.Controls.Add(this.ckbSubstituirArquivos);
            this.Controls.Add(this.txtPastaDestino);
            this.Controls.Add(this.txtPastaOrigem);
            this.Controls.Add(this.lblPastaDestino);
            this.Controls.Add(this.lblPastaOrigem);
            this.Controls.Add(this.btnRedimensionar);
            this.Name = "Form1";
            this.Text = "New Redimensionador de Imagens";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRedimensionar;
        private System.Windows.Forms.Label lblPastaOrigem;
        private System.Windows.Forms.Label lblPastaDestino;
        private System.Windows.Forms.TextBox txtPastaOrigem;
        private System.Windows.Forms.TextBox txtPastaDestino;
        private System.Windows.Forms.CheckBox ckbSubstituirArquivos;
        private System.Windows.Forms.CheckBox ckbIncluirSubPasta;
    }
}

