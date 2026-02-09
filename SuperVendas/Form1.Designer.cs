namespace SuperVendas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Entrar = new Button();
            Usuario = new TextBox();
            Senha = new TextBox();
            SuspendLayout();
            // 
            // Entrar
            // 
            Entrar.Location = new Point(322, 233);
            Entrar.Name = "Entrar";
            Entrar.Size = new Size(94, 29);
            Entrar.TabIndex = 0;
            Entrar.Text = "Entrar";
            Entrar.UseVisualStyleBackColor = true;
            Entrar.Click += Entrar_Click;
            // 
            // Usuario
            // 
            Usuario.Location = new Point(230, 179);
            Usuario.Name = "Usuario";
            Usuario.Size = new Size(125, 27);
            Usuario.TabIndex = 1;
            // 
            // Senha
            // 
            Senha.Location = new Point(389, 179);
            Senha.Name = "Senha";
            Senha.Size = new Size(125, 27);
            Senha.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Senha);
            Controls.Add(Usuario);
            Controls.Add(Entrar);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Entrar;
        private TextBox Usuario;
        private TextBox Senha;
    }
}
