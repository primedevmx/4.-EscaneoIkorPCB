namespace EscaneoIkor.Configuracion
{
    partial class frmConfiguracionRepositorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracionRepositorios));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnGuardarRepositorioXML = new System.Windows.Forms.Button();
            this.btnSeleccionarRepositorioDAT = new System.Windows.Forms.Button();
            this.txtRepositorio = new System.Windows.Forms.TextBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardarRepositorioExcel = new System.Windows.Forms.Button();
            this.btnSeleccionarRepositorioTXT = new System.Windows.Forms.Button();
            this.txtRepositorioExcel = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CHK_APP_RESP = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardarRepoSQL = new System.Windows.Forms.Button();
            this.btnSeleccionarRepositorioSQL = new System.Windows.Forms.Button();
            this.txtRespaldoSQL = new System.Windows.Forms.TextBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox7.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Transparent;
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.btnGuardarRepositorioXML);
            this.groupBox7.Controls.Add(this.btnSeleccionarRepositorioDAT);
            this.groupBox7.Controls.Add(this.txtRepositorio);
            this.groupBox7.Controls.Add(this.toolStrip4);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(753, 104);
            this.groupBox7.TabIndex = 28;
            this.groupBox7.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(10, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(408, 12);
            this.label16.TabIndex = 90;
            this.label16.Text = "->> Ingrese el directorio repositorio de .XMLs que el Sistema estará verificando " +
    "";
            // 
            // btnGuardarRepositorioXML
            // 
            this.btnGuardarRepositorioXML.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarRepositorioXML.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarRepositorioXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRepositorioXML.Location = new System.Drawing.Point(658, 63);
            this.btnGuardarRepositorioXML.Name = "btnGuardarRepositorioXML";
            this.btnGuardarRepositorioXML.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRepositorioXML.TabIndex = 89;
            this.btnGuardarRepositorioXML.Text = "Guard&ar";
            this.btnGuardarRepositorioXML.UseVisualStyleBackColor = false;
            this.btnGuardarRepositorioXML.Click += new System.EventHandler(this.btnGuardarRepositorio_Click);
            // 
            // btnSeleccionarRepositorioDAT
            // 
            this.btnSeleccionarRepositorioDAT.BackgroundImage = global::EscaneoIkor.Properties.Resources.google_web_search_32;
            this.btnSeleccionarRepositorioDAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSeleccionarRepositorioDAT.Location = new System.Drawing.Point(500, 54);
            this.btnSeleccionarRepositorioDAT.Name = "btnSeleccionarRepositorioDAT";
            this.btnSeleccionarRepositorioDAT.Size = new System.Drawing.Size(40, 40);
            this.btnSeleccionarRepositorioDAT.TabIndex = 11;
            this.btnSeleccionarRepositorioDAT.UseVisualStyleBackColor = true;
            this.btnSeleccionarRepositorioDAT.Click += new System.EventHandler(this.btnSeleccionarRepositorioDAT_Click);
            // 
            // txtRepositorio
            // 
            this.txtRepositorio.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRepositorio.Enabled = false;
            this.txtRepositorio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRepositorio.Location = new System.Drawing.Point(9, 65);
            this.txtRepositorio.Name = "txtRepositorio";
            this.txtRepositorio.Size = new System.Drawing.Size(476, 20);
            this.txtRepositorio.TabIndex = 10;
            // 
            // toolStrip4
            // 
            this.toolStrip4.BackgroundImage = global::EscaneoIkor.Properties.Resources.purpleBar1;
            this.toolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.tsbCerrar});
            this.toolStrip4.Location = new System.Drawing.Point(3, 16);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip4.Size = new System.Drawing.Size(747, 25);
            this.toolStrip4.TabIndex = 5;
            this.toolStrip4.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip4_ItemClicked);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel5.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(167, 22);
            this.toolStripLabel5.Text = "Repositorio de XMLs - SQL <- ";
            // 
            // tsbCerrar
            // 
            this.tsbCerrar.BackColor = System.Drawing.Color.Transparent;
            this.tsbCerrar.BackgroundImage = global::EscaneoIkor.Properties.Resources.delete_32;
            this.tsbCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsbCerrar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbCerrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsbCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrar.Name = "tsbCerrar";
            this.tsbCerrar.Size = new System.Drawing.Size(23, 22);
            this.tsbCerrar.Click += new System.EventHandler(this.tsbCerrar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnGuardarRepositorioExcel);
            this.groupBox1.Controls.Add(this.btnSeleccionarRepositorioTXT);
            this.groupBox1.Controls.Add(this.txtRepositorioExcel);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 101);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(10, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 12);
            this.label1.TabIndex = 90;
            this.label1.Text = "->> Ingrese el directorio repositorio de .EXCEL que el Sistema estará verificando" +
    " ";
            // 
            // btnGuardarRepositorioExcel
            // 
            this.btnGuardarRepositorioExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarRepositorioExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarRepositorioExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRepositorioExcel.Location = new System.Drawing.Point(658, 63);
            this.btnGuardarRepositorioExcel.Name = "btnGuardarRepositorioExcel";
            this.btnGuardarRepositorioExcel.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRepositorioExcel.TabIndex = 89;
            this.btnGuardarRepositorioExcel.Text = "Guard&ar";
            this.btnGuardarRepositorioExcel.UseVisualStyleBackColor = false;
            this.btnGuardarRepositorioExcel.Click += new System.EventHandler(this.btnGuardarRepositorioTXT_Click);
            // 
            // btnSeleccionarRepositorioTXT
            // 
            this.btnSeleccionarRepositorioTXT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarRepositorioTXT.BackgroundImage")));
            this.btnSeleccionarRepositorioTXT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSeleccionarRepositorioTXT.Location = new System.Drawing.Point(500, 54);
            this.btnSeleccionarRepositorioTXT.Name = "btnSeleccionarRepositorioTXT";
            this.btnSeleccionarRepositorioTXT.Size = new System.Drawing.Size(40, 40);
            this.btnSeleccionarRepositorioTXT.TabIndex = 11;
            this.btnSeleccionarRepositorioTXT.UseVisualStyleBackColor = true;
            this.btnSeleccionarRepositorioTXT.Click += new System.EventHandler(this.btnSeleccionarRepositorioTXT_Click);
            // 
            // txtRepositorioExcel
            // 
            this.txtRepositorioExcel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRepositorioExcel.Enabled = false;
            this.txtRepositorioExcel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRepositorioExcel.Location = new System.Drawing.Point(9, 65);
            this.txtRepositorioExcel.Name = "txtRepositorioExcel";
            this.txtRepositorioExcel.Size = new System.Drawing.Size(476, 20);
            this.txtRepositorioExcel.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::EscaneoIkor.Properties.Resources.GreenBar1;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(747, 25);
            this.toolStrip1.TabIndex = 5;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(132, 22);
            this.toolStripLabel1.Text = "Repositorio de Excel <- ";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.CHK_APP_RESP);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnGuardarRepoSQL);
            this.groupBox2.Controls.Add(this.btnSeleccionarRepositorioSQL);
            this.groupBox2.Controls.Add(this.txtRespaldoSQL);
            this.groupBox2.Controls.Add(this.toolStrip3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 205);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(753, 131);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            // 
            // CHK_APP_RESP
            // 
            this.CHK_APP_RESP.AutoSize = true;
            this.CHK_APP_RESP.Location = new System.Drawing.Point(15, 50);
            this.CHK_APP_RESP.Name = "CHK_APP_RESP";
            this.CHK_APP_RESP.Size = new System.Drawing.Size(109, 17);
            this.CHK_APP_RESP.TabIndex = 91;
            this.CHK_APP_RESP.Text = "Aplica Respaldo?";
            this.CHK_APP_RESP.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(10, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(423, 12);
            this.label2.TabIndex = 90;
            this.label2.Text = "->> Ingrese el directorio repositorio que el Sistema estará respaldando los archi" +
    "vos";
            // 
            // btnGuardarRepoSQL
            // 
            this.btnGuardarRepoSQL.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarRepoSQL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardarRepoSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRepoSQL.Location = new System.Drawing.Point(658, 88);
            this.btnGuardarRepoSQL.Name = "btnGuardarRepoSQL";
            this.btnGuardarRepoSQL.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarRepoSQL.TabIndex = 89;
            this.btnGuardarRepoSQL.Text = "Guard&ar";
            this.btnGuardarRepoSQL.UseVisualStyleBackColor = false;
            this.btnGuardarRepoSQL.Click += new System.EventHandler(this.btnGuardarRepoSQL_Click);
            // 
            // btnSeleccionarRepositorioSQL
            // 
            this.btnSeleccionarRepositorioSQL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarRepositorioSQL.BackgroundImage")));
            this.btnSeleccionarRepositorioSQL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSeleccionarRepositorioSQL.Location = new System.Drawing.Point(500, 79);
            this.btnSeleccionarRepositorioSQL.Name = "btnSeleccionarRepositorioSQL";
            this.btnSeleccionarRepositorioSQL.Size = new System.Drawing.Size(40, 40);
            this.btnSeleccionarRepositorioSQL.TabIndex = 11;
            this.btnSeleccionarRepositorioSQL.UseVisualStyleBackColor = true;
            this.btnSeleccionarRepositorioSQL.Click += new System.EventHandler(this.btnSeleccionarRepositorioSQL_Click);
            // 
            // txtRespaldoSQL
            // 
            this.txtRespaldoSQL.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtRespaldoSQL.Enabled = false;
            this.txtRespaldoSQL.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRespaldoSQL.Location = new System.Drawing.Point(9, 90);
            this.txtRespaldoSQL.Name = "txtRespaldoSQL";
            this.txtRespaldoSQL.Size = new System.Drawing.Size(476, 20);
            this.txtRespaldoSQL.TabIndex = 10;
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackgroundImage = global::EscaneoIkor.Properties.Resources.bgBlue2;
            this.toolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip3.Size = new System.Drawing.Size(747, 25);
            this.toolStrip3.TabIndex = 5;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(241, 22);
            this.toolStripLabel2.Text = "Repositorio de Respaldo de Volcado SQL <- ";
            // 
            // frmConfiguracionRepositorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EscaneoIkor.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(753, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfiguracionRepositorios";
            this.Text = "frmConfiguracionRepositorios";
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnGuardarRepositorioXML;
        private System.Windows.Forms.Button btnSeleccionarRepositorioDAT;
        private System.Windows.Forms.TextBox txtRepositorio;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardarRepositorioExcel;
        private System.Windows.Forms.Button btnSeleccionarRepositorioTXT;
        private System.Windows.Forms.TextBox txtRepositorioExcel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardarRepoSQL;
        private System.Windows.Forms.Button btnSeleccionarRepositorioSQL;
        private System.Windows.Forms.TextBox txtRespaldoSQL;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.CheckBox CHK_APP_RESP;
        private System.Windows.Forms.ToolStripButton tsbCerrar;
    }
}