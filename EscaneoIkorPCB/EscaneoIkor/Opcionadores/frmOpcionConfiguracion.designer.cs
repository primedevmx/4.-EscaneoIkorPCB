namespace EscaneoIkor.Opcionadores
{
    partial class frmOpcionConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpcionConfiguracion));
            this.label1 = new System.Windows.Forms.Label();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnServidorSqlServer = new System.Windows.Forms.Button();
            this.tspTittle = new System.Windows.Forms.ToolStrip();
            this.TSL_TITTLE = new System.Windows.Forms.ToolStripLabel();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMonitores = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRepositorios = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCuentasCorreo = new System.Windows.Forms.Button();
            this.tspTittle.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "[Servidor SqlServer]";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarios.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarios.Location = new System.Drawing.Point(268, 357);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(78, 20);
            this.lblUsuarios.TabIndex = 11;
            this.lblUsuarios.Text = "[Usuarios]";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackgroundImage = global::EscaneoIkor.Properties.Resources.edit_user_128;
            this.btnUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUsuarios.Location = new System.Drawing.Point(231, 225);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(156, 131);
            this.btnUsuarios.TabIndex = 10;
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnServidorSqlServer
            // 
            this.btnServidorSqlServer.BackgroundImage = global::EscaneoIkor.Properties.Resources.data_configuration_128;
            this.btnServidorSqlServer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnServidorSqlServer.Location = new System.Drawing.Point(36, 47);
            this.btnServidorSqlServer.Name = "btnServidorSqlServer";
            this.btnServidorSqlServer.Size = new System.Drawing.Size(156, 131);
            this.btnServidorSqlServer.TabIndex = 7;
            this.btnServidorSqlServer.UseVisualStyleBackColor = true;
            this.btnServidorSqlServer.Click += new System.EventHandler(this.btnServidorSqlServer_Click);
            // 
            // tspTittle
            // 
            this.tspTittle.BackgroundImage = global::EscaneoIkor.Properties.Resources.bgBlue2;
            this.tspTittle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tspTittle.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspTittle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSL_TITTLE,
            this.tsbCerrar});
            this.tspTittle.Location = new System.Drawing.Point(0, 0);
            this.tspTittle.Name = "tspTittle";
            this.tspTittle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tspTittle.Size = new System.Drawing.Size(718, 25);
            this.tspTittle.TabIndex = 6;
            // 
            // TSL_TITTLE
            // 
            this.TSL_TITTLE.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSL_TITTLE.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSL_TITTLE.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.TSL_TITTLE.Name = "TSL_TITTLE";
            this.TSL_TITTLE.Size = new System.Drawing.Size(237, 22);
            this.TSL_TITTLE.Text = "  Seleccione su opción en configuración <- ";
            // 
            // tsbCerrar
            // 
            this.tsbCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbCerrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsbCerrar.Image = global::EscaneoIkor.Properties.Resources.delete_32;
            this.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrar.Name = "tsbCerrar";
            this.tsbCerrar.Size = new System.Drawing.Size(23, 22);
            this.tsbCerrar.Click += new System.EventHandler(this.tsbCerrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(65, 357);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "[Monitores]";
            // 
            // btnMonitores
            // 
            this.btnMonitores.BackgroundImage = global::EscaneoIkor.Properties.Resources.timer_128;
            this.btnMonitores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMonitores.Location = new System.Drawing.Point(36, 225);
            this.btnMonitores.Name = "btnMonitores";
            this.btnMonitores.Size = new System.Drawing.Size(156, 131);
            this.btnMonitores.TabIndex = 19;
            this.btnMonitores.UseVisualStyleBackColor = true;
            this.btnMonitores.Click += new System.EventHandler(this.btnMonitores_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(455, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "[Repositorios]";
            // 
            // btnRepositorios
            // 
            this.btnRepositorios.BackgroundImage = global::EscaneoIkor.Properties.Resources.burn_folder_128;
            this.btnRepositorios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRepositorios.Location = new System.Drawing.Point(426, 47);
            this.btnRepositorios.Name = "btnRepositorios";
            this.btnRepositorios.Size = new System.Drawing.Size(156, 131);
            this.btnRepositorios.TabIndex = 17;
            this.btnRepositorios.UseVisualStyleBackColor = true;
            this.btnRepositorios.Click += new System.EventHandler(this.btnRepositorios_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(236, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "[Cuentas de Correo]";
            // 
            // btnCuentasCorreo
            // 
            this.btnCuentasCorreo.BackgroundImage = global::EscaneoIkor.Properties.Resources.gmail_login_128;
            this.btnCuentasCorreo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCuentasCorreo.Location = new System.Drawing.Point(231, 47);
            this.btnCuentasCorreo.Name = "btnCuentasCorreo";
            this.btnCuentasCorreo.Size = new System.Drawing.Size(156, 131);
            this.btnCuentasCorreo.TabIndex = 15;
            this.btnCuentasCorreo.UseVisualStyleBackColor = true;
            this.btnCuentasCorreo.Click += new System.EventHandler(this.btnCuentasCorreo_Click);
            // 
            // frmOpcionConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::EscaneoIkor.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(718, 500);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMonitores);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRepositorios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCuentasCorreo);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnServidorSqlServer);
            this.Controls.Add(this.tspTittle);
            this.Controls.Add(this.btnUsuarios);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOpcionConfiguracion";
            this.Text = " Seleccione su opción en Configuracion <-";
            this.tspTittle.ResumeLayout(false);
            this.tspTittle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspTittle;
        private System.Windows.Forms.ToolStripLabel TSL_TITTLE;
        private System.Windows.Forms.ToolStripButton tsbCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnServidorSqlServer;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMonitores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRepositorios;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCuentasCorreo;
    }
}