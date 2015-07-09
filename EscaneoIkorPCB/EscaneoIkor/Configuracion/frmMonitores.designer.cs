namespace EscaneoIkor.Configuracion
{
    partial class frmMonitores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitores));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsbCerrar = new System.Windows.Forms.ToolStripButton();
            this.timerMonitorConexion = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBTN_STOP_SQL = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.TSBTN_START_SQL = new System.Windows.Forms.ToolStripButton();
            this.tsbEstatusDaemon_SQL = new System.Windows.Forms.ToolStripLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar_SQLSERVER = new System.Windows.Forms.Button();
            this.numericCorreoSQL = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.timerMonitorConexionSQL = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMGExcel = new System.Windows.Forms.Button();
            this.numericEXCEL = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnMGXml = new System.Windows.Forms.Button();
            this.numericXML = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCorreoSQL)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEXCEL)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericXML)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackgroundImage = global::EscaneoIkor.Properties.Resources.bgBlue2;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.tsbCerrar});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip2.Size = new System.Drawing.Size(805, 25);
            this.toolStrip2.TabIndex = 6;
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(174, 22);
            this.toolStripLabel3.Text = "Configuración de Monitores <- ";
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
            this.tsbCerrar.Click += new System.EventHandler(this.tsbCerrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnGuardar_SQLSERVER);
            this.groupBox2.Controls.Add(this.numericCorreoSQL);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.toolStrip5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(805, 125);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "-->  SQL-SERVER ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(449, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 81);
            this.panel1.TabIndex = 94;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.toolStrip4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(353, 80);
            this.groupBox3.TabIndex = 95;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Monitor de la conexion ( Activar desde equipo remoto ). ";
            // 
            // toolStrip4
            // 
            this.toolStrip4.BackgroundImage = global::EscaneoIkor.Properties.Resources.bgBlue2;
            this.toolStrip4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.TSBTN_STOP_SQL,
            this.toolStripSeparator6,
            this.TSBTN_START_SQL,
            this.tsbEstatusDaemon_SQL});
            this.toolStrip4.Location = new System.Drawing.Point(3, 22);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip4.Size = new System.Drawing.Size(347, 55);
            this.toolStrip4.TabIndex = 12;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // TSBTN_STOP_SQL
            // 
            this.TSBTN_STOP_SQL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSBTN_STOP_SQL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.TSBTN_STOP_SQL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TSBTN_STOP_SQL.Image = global::EscaneoIkor.Properties.Resources.stop_481;
            this.TSBTN_STOP_SQL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSBTN_STOP_SQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBTN_STOP_SQL.Name = "TSBTN_STOP_SQL";
            this.TSBTN_STOP_SQL.Size = new System.Drawing.Size(52, 52);
            this.TSBTN_STOP_SQL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBTN_STOP_SQL.Click += new System.EventHandler(this.TSBTN_STOP_SQL_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // TSBTN_START_SQL
            // 
            this.TSBTN_START_SQL.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TSBTN_START_SQL.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.TSBTN_START_SQL.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TSBTN_START_SQL.Image = global::EscaneoIkor.Properties.Resources.start_48_wte;
            this.TSBTN_START_SQL.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSBTN_START_SQL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSBTN_START_SQL.Name = "TSBTN_START_SQL";
            this.TSBTN_START_SQL.Size = new System.Drawing.Size(52, 52);
            this.TSBTN_START_SQL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSBTN_START_SQL.Click += new System.EventHandler(this.TSBTN_START_SQL_Click);
            // 
            // tsbEstatusDaemon_SQL
            // 
            this.tsbEstatusDaemon_SQL.Font = new System.Drawing.Font("Segoe UI", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbEstatusDaemon_SQL.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tsbEstatusDaemon_SQL.Name = "tsbEstatusDaemon_SQL";
            this.tsbEstatusDaemon_SQL.Size = new System.Drawing.Size(0, 52);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(76, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 93;
            this.label2.Text = "-> Minutos";
            // 
            // btnGuardar_SQLSERVER
            // 
            this.btnGuardar_SQLSERVER.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar_SQLSERVER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar_SQLSERVER.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar_SQLSERVER.Location = new System.Drawing.Point(273, 84);
            this.btnGuardar_SQLSERVER.Name = "btnGuardar_SQLSERVER";
            this.btnGuardar_SQLSERVER.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar_SQLSERVER.TabIndex = 92;
            this.btnGuardar_SQLSERVER.Text = "Guard&ar";
            this.btnGuardar_SQLSERVER.UseVisualStyleBackColor = false;
            this.btnGuardar_SQLSERVER.Click += new System.EventHandler(this.btnGuardar_SQLSERVER_Click);
            // 
            // numericCorreoSQL
            // 
            this.numericCorreoSQL.Location = new System.Drawing.Point(33, 72);
            this.numericCorreoSQL.Name = "numericCorreoSQL";
            this.numericCorreoSQL.Size = new System.Drawing.Size(120, 20);
            this.numericCorreoSQL.TabIndex = 91;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(338, 12);
            this.label3.TabIndex = 90;
            this.label3.Text = "->> Ingrese el tiempo en minutos que el monitor estará verificando";
            // 
            // toolStrip5
            // 
            this.toolStrip5.BackgroundImage = global::EscaneoIkor.Properties.Resources.bgDark2;
            this.toolStrip5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4});
            this.toolStrip5.Location = new System.Drawing.Point(3, 16);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip5.Size = new System.Drawing.Size(799, 25);
            this.toolStrip5.TabIndex = 5;
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(383, 22);
            this.toolStripLabel4.Text = "Ejecución del monitor de conexión (correo electrónico) SQL SERVER<- ";
            // 
            // timerMonitorConexionSQL
            // 
            this.timerMonitorConexionSQL.Tick += new System.EventHandler(this.OnTimer_timerMonitorConexion_SQL_Event);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMGExcel);
            this.groupBox1.Controls.Add(this.numericEXCEL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.toolStrip3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(805, 121);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "-->  EXCEL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(76, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "-> Minutos";
            // 
            // btnMGExcel
            // 
            this.btnMGExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnMGExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMGExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMGExcel.Location = new System.Drawing.Point(273, 84);
            this.btnMGExcel.Name = "btnMGExcel";
            this.btnMGExcel.Size = new System.Drawing.Size(75, 23);
            this.btnMGExcel.TabIndex = 92;
            this.btnMGExcel.Text = "Guard&ar";
            this.btnMGExcel.UseVisualStyleBackColor = false;
            this.btnMGExcel.Click += new System.EventHandler(this.btnMGExcel_Click);
            // 
            // numericEXCEL
            // 
            this.numericEXCEL.Location = new System.Drawing.Point(33, 72);
            this.numericEXCEL.Name = "numericEXCEL";
            this.numericEXCEL.Size = new System.Drawing.Size(120, 20);
            this.numericEXCEL.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(10, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 12);
            this.label4.TabIndex = 90;
            this.label4.Text = "->> Ingrese el tiempo en minutos que el monitor estará verificando";
            // 
            // toolStrip3
            // 
            this.toolStrip3.BackgroundImage = global::EscaneoIkor.Properties.Resources.GreenBar1;
            this.toolStrip3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip3.Size = new System.Drawing.Size(799, 25);
            this.toolStrip3.TabIndex = 5;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(234, 22);
            this.toolStripLabel2.Text = "Ejecución del monitor de conexión - EXCEL";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnMGXml);
            this.groupBox4.Controls.Add(this.numericXML);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.toolStrip1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 271);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(805, 121);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "-->  XML";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(75, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 93;
            this.label5.Text = "-> Minutos";
            // 
            // btnMGXml
            // 
            this.btnMGXml.BackColor = System.Drawing.Color.Transparent;
            this.btnMGXml.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMGXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMGXml.Location = new System.Drawing.Point(273, 84);
            this.btnMGXml.Name = "btnMGXml";
            this.btnMGXml.Size = new System.Drawing.Size(75, 23);
            this.btnMGXml.TabIndex = 92;
            this.btnMGXml.Text = "Guard&ar";
            this.btnMGXml.UseVisualStyleBackColor = false;
            this.btnMGXml.Click += new System.EventHandler(this.btnMGXml_Click);
            // 
            // numericXML
            // 
            this.numericXML.Location = new System.Drawing.Point(33, 72);
            this.numericXML.Name = "numericXML";
            this.numericXML.Size = new System.Drawing.Size(120, 20);
            this.numericXML.TabIndex = 91;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(10, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(338, 12);
            this.label6.TabIndex = 90;
            this.label6.Text = "->> Ingrese el tiempo en minutos que el monitor estará verificando";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackgroundImage = global::EscaneoIkor.Properties.Resources.purpleBar2;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(799, 25);
            this.toolStrip1.TabIndex = 5;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(242, 22);
            this.toolStripLabel1.Text = "Ejecución del monitor de conexión - XML<- ";
            // 
            // frmMonitores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EscaneoIkor.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(805, 483);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMonitores";
            this.Text = "frmMonitores";
            this.Load += new System.EventHandler(this.frmMonitores_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCorreoSQL)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEXCEL)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericXML)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton tsbCerrar;
        private System.Windows.Forms.Timer timerMonitorConexion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuardar_SQLSERVER;
        private System.Windows.Forms.NumericUpDown numericCorreoSQL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.Timer timerMonitorConexionSQL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMGExcel;
        private System.Windows.Forms.NumericUpDown numericEXCEL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnMGXml;
        private System.Windows.Forms.NumericUpDown numericXML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TSBTN_STOP_SQL;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton TSBTN_START_SQL;
        private System.Windows.Forms.ToolStripLabel tsbEstatusDaemon_SQL;
    }
}