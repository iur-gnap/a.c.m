using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using DX10COMLib = DX10SDKADAPTORLib;
using System.Runtime.InteropServices;

namespace DX10ExAppCSharp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public class frmDX10Example : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnConnect;
        private IContainer components;
        private System.Windows.Forms.StatusBar staDX10;
        private System.Windows.Forms.StatusBarPanel panDX10Status;
        private System.Windows.Forms.Button btnDatum;
        private System.Windows.Forms.StatusBarPanel panML10Status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtReading;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.TextBox txtBeamLoss;
        private System.Windows.Forms.TextBox txtPreheat;
        private System.Windows.Forms.TextBox txtUnstable;
        private System.Windows.Forms.ProgressBar prgSigStrength;
        private System.Windows.Forms.Panel panSigStrength;
        private System.Windows.Forms.RadioButton radLinearRetro;
        private System.Windows.Forms.RadioButton radLinearPlane;
        private System.Windows.Forms.RadioButton radAngular;
        private System.Windows.Forms.RadioButton radStraightnessShort;
        private System.Windows.Forms.RadioButton radStraightnessLong;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCompensation;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grpMatTemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAirTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAirTemp;
        private System.Windows.Forms.TextBox txtPressure;
        private System.Windows.Forms.TextBox txtHumidity;
        private System.Windows.Forms.Label lblPressure;
        private System.Windows.Forms.Label lblHumidity;
        private System.Windows.Forms.TextBox txtMatTemp1;
        private System.Windows.Forms.TextBox txtMatTemp2;
        private System.Windows.Forms.TextBox txtMatTemp3;
        private System.Windows.Forms.Label lblMatTemp1;
        private System.Windows.Forms.Label lblMatTemp2;
        private System.Windows.Forms.Label lblMatTemp3;

        private System.Windows.Forms.StatusBarPanel panEC10Status;
        private System.Windows.Forms.GroupBox grpTPIN;
        private System.Windows.Forms.TextBox txtTPINReading;
        private System.Windows.Forms.Label label7;
        private System.Drawing.Icon icoError;
        private System.Windows.Forms.RadioButton radSyncTPIN;
        private System.Windows.Forms.RadioButton radAsyncTPIN;

		 //private DX10COMLib.RenishawDX10Class dx10;
		 private DX10COMLib.DX10AdaptorClass dx10;
        
        public frmDX10Example()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDX10Example));
            icoError = ((System.Drawing.Icon)(resources.GetObject("panDX10Status.Icon")));

            //dx10 = new DX10COMLib.RenishawDX10Class();
				dx10 = new DX10COMLib.DX10AdaptorClass();
				dx10.DX10StatusChanged += new DX10COMLib._IRenishawDX10Events_DX10StatusChangedEventHandler(dx10_DX10StatusChanged); 
            dx10.ML10Updated += new DX10COMLib._IRenishawDX10Events_ML10UpdatedEventHandler(dx10_ML10Updated);
            dx10.ML10StatusChanged += new DX10COMLib._IRenishawDX10Events_ML10StatusChangedEventHandler(dx10_ML10StatusChanged);
            dx10.EC10Updated += new DX10COMLib._IRenishawDX10Events_EC10UpdatedEventHandler(dx10_EC10Updated);
            dx10.EC10StatusChanged += new DX10COMLib._IRenishawDX10Events_EC10StatusChangedEventHandler(dx10_EC10StatusChanged);

            txtBeamLoss.Visible = false;
            txtUnstable.Visible = false;
            txtPreheat.Visible = false;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }

                dx10.Disconnect();
                Marshal.FinalReleaseComObject(dx10);
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDX10Example));
            this.btnConnect = new System.Windows.Forms.Button();
            this.staDX10 = new System.Windows.Forms.StatusBar();
            this.panDX10Status = new System.Windows.Forms.StatusBarPanel();
            this.panML10Status = new System.Windows.Forms.StatusBarPanel();
            this.panEC10Status = new System.Windows.Forms.StatusBarPanel();
            this.btnDatum = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCompensation = new System.Windows.Forms.TextBox();
            this.txtUnstable = new System.Windows.Forms.TextBox();
            this.txtPreheat = new System.Windows.Forms.TextBox();
            this.txtBeamLoss = new System.Windows.Forms.TextBox();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.txtReading = new System.Windows.Forms.Label();
            this.panSigStrength = new System.Windows.Forms.Panel();
            this.prgSigStrength = new System.Windows.Forms.ProgressBar();
            this.radLinearRetro = new System.Windows.Forms.RadioButton();
            this.radLinearPlane = new System.Windows.Forms.RadioButton();
            this.radAngular = new System.Windows.Forms.RadioButton();
            this.radStraightnessShort = new System.Windows.Forms.RadioButton();
            this.radStraightnessLong = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.grpMatTemp = new System.Windows.Forms.GroupBox();
            this.lblMatTemp3 = new System.Windows.Forms.Label();
            this.txtMatTemp3 = new System.Windows.Forms.TextBox();
            this.lblMatTemp2 = new System.Windows.Forms.Label();
            this.txtMatTemp2 = new System.Windows.Forms.TextBox();
            this.lblMatTemp1 = new System.Windows.Forms.Label();
            this.txtMatTemp1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAirTemp = new System.Windows.Forms.TextBox();
            this.lblAirTemp = new System.Windows.Forms.Label();
            this.txtPressure = new System.Windows.Forms.TextBox();
            this.txtHumidity = new System.Windows.Forms.TextBox();
            this.lblPressure = new System.Windows.Forms.Label();
            this.lblHumidity = new System.Windows.Forms.Label();
            this.grpTPIN = new System.Windows.Forms.GroupBox();
            this.radAsyncTPIN = new System.Windows.Forms.RadioButton();
            this.radSyncTPIN = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTPINReading = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.panDX10Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panML10Status)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panEC10Status)).BeginInit();
            this.panel1.SuspendLayout();
            this.panSigStrength.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.grpMatTemp.SuspendLayout();
            this.grpTPIN.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(584, 432);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 40);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // staDX10
            // 
            this.staDX10.Location = new System.Drawing.Point(0, 479);
            this.staDX10.Name = "staDX10";
            this.staDX10.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.panDX10Status,
            this.panML10Status,
            this.panEC10Status});
            this.staDX10.ShowPanels = true;
            this.staDX10.Size = new System.Drawing.Size(686, 22);
            this.staDX10.TabIndex = 1;
            // 
            // panDX10Status
            // 
            this.panDX10Status.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.panDX10Status.Icon = ((System.Drawing.Icon)(resources.GetObject("panDX10Status.Icon")));
            this.panDX10Status.Name = "panDX10Status";
            this.panDX10Status.Text = "DX10 not connected";
            this.panDX10Status.Width = 389;
            // 
            // panML10Status
            // 
            this.panML10Status.Name = "panML10Status";
            this.panML10Status.Width = 140;
            // 
            // panEC10Status
            // 
            this.panEC10Status.Name = "panEC10Status";
            this.panEC10Status.Width = 140;
            // 
            // btnDatum
            // 
            this.btnDatum.Enabled = false;
            this.btnDatum.Location = new System.Drawing.Point(584, 334);
            this.btnDatum.Name = "btnDatum";
            this.btnDatum.Size = new System.Drawing.Size(96, 40);
            this.btnDatum.TabIndex = 4;
            this.btnDatum.Text = "&Datum";
            this.btnDatum.Click += new System.EventHandler(this.btnDatum_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtCompensation);
            this.panel1.Controls.Add(this.txtUnstable);
            this.panel1.Controls.Add(this.txtPreheat);
            this.panel1.Controls.Add(this.txtBeamLoss);
            this.panel1.Controls.Add(this.txtMode);
            this.panel1.Controls.Add(this.txtUnits);
            this.panel1.Controls.Add(this.txtReading);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(688, 128);
            this.panel1.TabIndex = 6;
            // 
            // txtCompensation
            // 
            this.txtCompensation.BackColor = System.Drawing.Color.Black;
            this.txtCompensation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCompensation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompensation.ForeColor = System.Drawing.Color.Red;
            this.txtCompensation.Location = new System.Drawing.Point(412, 104);
            this.txtCompensation.Name = "txtCompensation";
            this.txtCompensation.ReadOnly = true;
            this.txtCompensation.Size = new System.Drawing.Size(128, 15);
            this.txtCompensation.TabIndex = 11;
            this.txtCompensation.TabStop = false;
            this.txtCompensation.Text = "compensation:";
            // 
            // txtUnstable
            // 
            this.txtUnstable.BackColor = System.Drawing.Color.Black;
            this.txtUnstable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnstable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnstable.ForeColor = System.Drawing.Color.Red;
            this.txtUnstable.Location = new System.Drawing.Point(8, 56);
            this.txtUnstable.Name = "txtUnstable";
            this.txtUnstable.ReadOnly = true;
            this.txtUnstable.Size = new System.Drawing.Size(56, 15);
            this.txtUnstable.TabIndex = 10;
            this.txtUnstable.TabStop = false;
            this.txtUnstable.Text = "Unstable";
            // 
            // txtPreheat
            // 
            this.txtPreheat.BackColor = System.Drawing.Color.Black;
            this.txtPreheat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPreheat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreheat.ForeColor = System.Drawing.Color.Red;
            this.txtPreheat.Location = new System.Drawing.Point(8, 80);
            this.txtPreheat.Name = "txtPreheat";
            this.txtPreheat.ReadOnly = true;
            this.txtPreheat.Size = new System.Drawing.Size(56, 15);
            this.txtPreheat.TabIndex = 9;
            this.txtPreheat.TabStop = false;
            this.txtPreheat.Text = "Preheat";
            // 
            // txtBeamLoss
            // 
            this.txtBeamLoss.BackColor = System.Drawing.Color.Black;
            this.txtBeamLoss.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBeamLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBeamLoss.ForeColor = System.Drawing.Color.Red;
            this.txtBeamLoss.Location = new System.Drawing.Point(8, 104);
            this.txtBeamLoss.Name = "txtBeamLoss";
            this.txtBeamLoss.ReadOnly = true;
            this.txtBeamLoss.Size = new System.Drawing.Size(112, 15);
            this.txtBeamLoss.TabIndex = 8;
            this.txtBeamLoss.TabStop = false;
            this.txtBeamLoss.Text = "Beam obstructed";
            // 
            // txtMode
            // 
            this.txtMode.BackColor = System.Drawing.Color.Black;
            this.txtMode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMode.ForeColor = System.Drawing.Color.Red;
            this.txtMode.Location = new System.Drawing.Point(174, 104);
            this.txtMode.Name = "txtMode";
            this.txtMode.ReadOnly = true;
            this.txtMode.Size = new System.Drawing.Size(176, 15);
            this.txtMode.TabIndex = 7;
            this.txtMode.TabStop = false;
            this.txtMode.Text = "mode:";
            // 
            // txtUnits
            // 
            this.txtUnits.BackColor = System.Drawing.Color.Black;
            this.txtUnits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnits.ForeColor = System.Drawing.Color.Red;
            this.txtUnits.Location = new System.Drawing.Point(632, 104);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.ReadOnly = true;
            this.txtUnits.Size = new System.Drawing.Size(48, 15);
            this.txtUnits.TabIndex = 6;
            this.txtUnits.TabStop = false;
            this.txtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtReading
            // 
            this.txtReading.BackColor = System.Drawing.Color.Black;
            this.txtReading.Font = new System.Drawing.Font("Verdana", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReading.ForeColor = System.Drawing.Color.Red;
            this.txtReading.Location = new System.Drawing.Point(0, 0);
            this.txtReading.Name = "txtReading";
            this.txtReading.Size = new System.Drawing.Size(672, 117);
            this.txtReading.TabIndex = 3;
            this.txtReading.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panSigStrength
            // 
            this.panSigStrength.BackColor = System.Drawing.SystemColors.Control;
            this.panSigStrength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panSigStrength.Controls.Add(this.prgSigStrength);
            this.panSigStrength.Location = new System.Drawing.Point(0, 128);
            this.panSigStrength.Name = "panSigStrength";
            this.panSigStrength.Size = new System.Drawing.Size(688, 40);
            this.panSigStrength.TabIndex = 7;
            // 
            // prgSigStrength
            // 
            this.prgSigStrength.Location = new System.Drawing.Point(6, 6);
            this.prgSigStrength.Maximum = 31;
            this.prgSigStrength.Name = "prgSigStrength";
            this.prgSigStrength.Size = new System.Drawing.Size(674, 24);
            this.prgSigStrength.TabIndex = 4;
            // 
            // radLinearRetro
            // 
            this.radLinearRetro.Appearance = System.Windows.Forms.Appearance.Button;
            this.radLinearRetro.Enabled = false;
            this.radLinearRetro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radLinearRetro.Location = new System.Drawing.Point(463, 168);
            this.radLinearRetro.Name = "radLinearRetro";
            this.radLinearRetro.Size = new System.Drawing.Size(80, 40);
            this.radLinearRetro.TabIndex = 9;
            this.radLinearRetro.Text = "Linear (retro)";
            this.radLinearRetro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLinearRetro.CheckedChanged += new System.EventHandler(this.MeasurementMode_Changed);
            // 
            // radLinearPlane
            // 
            this.radLinearPlane.Appearance = System.Windows.Forms.Appearance.Button;
            this.radLinearPlane.Enabled = false;
            this.radLinearPlane.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radLinearPlane.Location = new System.Drawing.Point(383, 168);
            this.radLinearPlane.Name = "radLinearPlane";
            this.radLinearPlane.Size = new System.Drawing.Size(80, 40);
            this.radLinearPlane.TabIndex = 11;
            this.radLinearPlane.Text = "Linear (plane)";
            this.radLinearPlane.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLinearPlane.CheckedChanged += new System.EventHandler(this.MeasurementMode_Changed);
            // 
            // radAngular
            // 
            this.radAngular.Appearance = System.Windows.Forms.Appearance.Button;
            this.radAngular.Enabled = false;
            this.radAngular.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radAngular.Location = new System.Drawing.Point(303, 168);
            this.radAngular.Name = "radAngular";
            this.radAngular.Size = new System.Drawing.Size(80, 40);
            this.radAngular.TabIndex = 12;
            this.radAngular.Text = "Angular";
            this.radAngular.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radAngular.CheckedChanged += new System.EventHandler(this.MeasurementMode_Changed);
            // 
            // radStraightnessShort
            // 
            this.radStraightnessShort.Appearance = System.Windows.Forms.Appearance.Button;
            this.radStraightnessShort.Enabled = false;
            this.radStraightnessShort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radStraightnessShort.Location = new System.Drawing.Point(223, 168);
            this.radStraightnessShort.Name = "radStraightnessShort";
            this.radStraightnessShort.Size = new System.Drawing.Size(80, 40);
            this.radStraightnessShort.TabIndex = 13;
            this.radStraightnessShort.Text = "Straightness (short)";
            this.radStraightnessShort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radStraightnessShort.CheckedChanged += new System.EventHandler(this.MeasurementMode_Changed);
            // 
            // radStraightnessLong
            // 
            this.radStraightnessLong.Appearance = System.Windows.Forms.Appearance.Button;
            this.radStraightnessLong.Enabled = false;
            this.radStraightnessLong.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radStraightnessLong.Location = new System.Drawing.Point(143, 168);
            this.radStraightnessLong.Name = "radStraightnessLong";
            this.radStraightnessLong.Size = new System.Drawing.Size(80, 40);
            this.radStraightnessLong.TabIndex = 14;
            this.radStraightnessLong.Text = "Straightness (long)";
            this.radStraightnessLong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radStraightnessLong.CheckedChanged += new System.EventHandler(this.MeasurementMode_Changed);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Air temperature";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pressure";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Humidity";
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(584, 384);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(96, 40);
            this.btnReset.TabIndex = 23;
            this.btnReset.Text = "&Reset";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grpMatTemp
            // 
            this.grpMatTemp.Controls.Add(this.lblMatTemp3);
            this.grpMatTemp.Controls.Add(this.txtMatTemp3);
            this.grpMatTemp.Controls.Add(this.lblMatTemp2);
            this.grpMatTemp.Controls.Add(this.txtMatTemp2);
            this.grpMatTemp.Controls.Add(this.lblMatTemp1);
            this.grpMatTemp.Controls.Add(this.txtMatTemp1);
            this.grpMatTemp.Controls.Add(this.label6);
            this.grpMatTemp.Controls.Add(this.label5);
            this.grpMatTemp.Controls.Add(this.label4);
            this.grpMatTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMatTemp.Location = new System.Drawing.Point(12, 336);
            this.grpMatTemp.Name = "grpMatTemp";
            this.grpMatTemp.Size = new System.Drawing.Size(216, 128);
            this.grpMatTemp.TabIndex = 26;
            this.grpMatTemp.TabStop = false;
            this.grpMatTemp.Text = "Material temperature";
            // 
            // lblMatTemp3
            // 
            this.lblMatTemp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatTemp3.Location = new System.Drawing.Point(168, 92);
            this.lblMatTemp3.Name = "lblMatTemp3";
            this.lblMatTemp3.Size = new System.Drawing.Size(20, 16);
            this.lblMatTemp3.TabIndex = 43;
            this.lblMatTemp3.Text = "°C";
            // 
            // txtMatTemp3
            // 
            this.txtMatTemp3.BackColor = System.Drawing.Color.White;
            this.txtMatTemp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatTemp3.Location = new System.Drawing.Point(116, 88);
            this.txtMatTemp3.Name = "txtMatTemp3";
            this.txtMatTemp3.ReadOnly = true;
            this.txtMatTemp3.Size = new System.Drawing.Size(48, 22);
            this.txtMatTemp3.TabIndex = 42;
            this.txtMatTemp3.TabStop = false;
            this.txtMatTemp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMatTemp2
            // 
            this.lblMatTemp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatTemp2.Location = new System.Drawing.Point(168, 59);
            this.lblMatTemp2.Name = "lblMatTemp2";
            this.lblMatTemp2.Size = new System.Drawing.Size(20, 16);
            this.lblMatTemp2.TabIndex = 41;
            this.lblMatTemp2.Text = "°C";
            // 
            // txtMatTemp2
            // 
            this.txtMatTemp2.BackColor = System.Drawing.Color.White;
            this.txtMatTemp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatTemp2.Location = new System.Drawing.Point(116, 56);
            this.txtMatTemp2.Name = "txtMatTemp2";
            this.txtMatTemp2.ReadOnly = true;
            this.txtMatTemp2.Size = new System.Drawing.Size(48, 22);
            this.txtMatTemp2.TabIndex = 40;
            this.txtMatTemp2.TabStop = false;
            this.txtMatTemp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblMatTemp1
            // 
            this.lblMatTemp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatTemp1.Location = new System.Drawing.Point(168, 27);
            this.lblMatTemp1.Name = "lblMatTemp1";
            this.lblMatTemp1.Size = new System.Drawing.Size(20, 16);
            this.lblMatTemp1.TabIndex = 39;
            this.lblMatTemp1.Text = "°C";
            // 
            // txtMatTemp1
            // 
            this.txtMatTemp1.BackColor = System.Drawing.Color.White;
            this.txtMatTemp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatTemp1.Location = new System.Drawing.Point(116, 24);
            this.txtMatTemp1.Name = "txtMatTemp1";
            this.txtMatTemp1.ReadOnly = true;
            this.txtMatTemp1.Size = new System.Drawing.Size(48, 22);
            this.txtMatTemp1.TabIndex = 38;
            this.txtMatTemp1.TabStop = false;
            this.txtMatTemp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Sensor 3";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Sensor 2";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Sensor 1";
            // 
            // txtAirTemp
            // 
            this.txtAirTemp.BackColor = System.Drawing.Color.White;
            this.txtAirTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAirTemp.Location = new System.Drawing.Point(128, 236);
            this.txtAirTemp.Name = "txtAirTemp";
            this.txtAirTemp.ReadOnly = true;
            this.txtAirTemp.Size = new System.Drawing.Size(48, 22);
            this.txtAirTemp.TabIndex = 27;
            this.txtAirTemp.TabStop = false;
            this.txtAirTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAirTemp.TextChanged += new System.EventHandler(this.txtAirTemp_TextChanged);
            // 
            // lblAirTemp
            // 
            this.lblAirTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirTemp.Location = new System.Drawing.Point(180, 239);
            this.lblAirTemp.Name = "lblAirTemp";
            this.lblAirTemp.Size = new System.Drawing.Size(20, 16);
            this.lblAirTemp.TabIndex = 29;
            this.lblAirTemp.Text = "°C";
            // 
            // txtPressure
            // 
            this.txtPressure.BackColor = System.Drawing.Color.White;
            this.txtPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPressure.Location = new System.Drawing.Point(128, 268);
            this.txtPressure.Name = "txtPressure";
            this.txtPressure.ReadOnly = true;
            this.txtPressure.Size = new System.Drawing.Size(48, 22);
            this.txtPressure.TabIndex = 30;
            this.txtPressure.TabStop = false;
            this.txtPressure.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtHumidity
            // 
            this.txtHumidity.BackColor = System.Drawing.Color.White;
            this.txtHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHumidity.Location = new System.Drawing.Point(128, 300);
            this.txtHumidity.Name = "txtHumidity";
            this.txtHumidity.ReadOnly = true;
            this.txtHumidity.Size = new System.Drawing.Size(48, 22);
            this.txtHumidity.TabIndex = 32;
            this.txtHumidity.TabStop = false;
            this.txtHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPressure
            // 
            this.lblPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPressure.Location = new System.Drawing.Point(180, 271);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(36, 16);
            this.lblPressure.TabIndex = 34;
            this.lblPressure.Text = "mbar";
            // 
            // lblHumidity
            // 
            this.lblHumidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumidity.Location = new System.Drawing.Point(180, 303);
            this.lblHumidity.Name = "lblHumidity";
            this.lblHumidity.Size = new System.Drawing.Size(36, 16);
            this.lblHumidity.TabIndex = 35;
            this.lblHumidity.Text = "%RH";
            // 
            // grpTPIN
            // 
            this.grpTPIN.Controls.Add(this.radAsyncTPIN);
            this.grpTPIN.Controls.Add(this.radSyncTPIN);
            this.grpTPIN.Controls.Add(this.label7);
            this.grpTPIN.Controls.Add(this.txtTPINReading);
            this.grpTPIN.Location = new System.Drawing.Point(280, 336);
            this.grpTPIN.Name = "grpTPIN";
            this.grpTPIN.Size = new System.Drawing.Size(252, 128);
            this.grpTPIN.TabIndex = 36;
            this.grpTPIN.TabStop = false;
            this.grpTPIN.Text = "TPIN";
            // 
            // radAsyncTPIN
            // 
            this.radAsyncTPIN.Appearance = System.Windows.Forms.Appearance.Button;
            this.radAsyncTPIN.AutoCheck = false;
            this.radAsyncTPIN.BackColor = System.Drawing.SystemColors.Control;
            this.radAsyncTPIN.Enabled = false;
            this.radAsyncTPIN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radAsyncTPIN.Location = new System.Drawing.Point(34, 24);
            this.radAsyncTPIN.Name = "radAsyncTPIN";
            this.radAsyncTPIN.Size = new System.Drawing.Size(92, 40);
            this.radAsyncTPIN.TabIndex = 6;
            this.radAsyncTPIN.Text = "Asynchronous";
            this.radAsyncTPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radAsyncTPIN.UseVisualStyleBackColor = false;
            this.radAsyncTPIN.Click += new System.EventHandler(this.radAsyncTPIN_Click);
            // 
            // radSyncTPIN
            // 
            this.radSyncTPIN.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSyncTPIN.AutoCheck = false;
            this.radSyncTPIN.Enabled = false;
            this.radSyncTPIN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radSyncTPIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSyncTPIN.Location = new System.Drawing.Point(126, 24);
            this.radSyncTPIN.Name = "radSyncTPIN";
            this.radSyncTPIN.Size = new System.Drawing.Size(92, 40);
            this.radSyncTPIN.TabIndex = 5;
            this.radSyncTPIN.Text = "Synchronous";
            this.radSyncTPIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSyncTPIN.Click += new System.EventHandler(this.radSyncTPIN_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Last reading";
            // 
            // txtTPINReading
            // 
            this.txtTPINReading.BackColor = System.Drawing.Color.White;
            this.txtTPINReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTPINReading.Location = new System.Drawing.Point(126, 88);
            this.txtTPINReading.Name = "txtTPINReading";
            this.txtTPINReading.ReadOnly = true;
            this.txtTPINReading.Size = new System.Drawing.Size(92, 22);
            this.txtTPINReading.TabIndex = 0;
            this.txtTPINReading.TabStop = false;
            this.txtTPINReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmDX10Example
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(686, 501);
            this.Controls.Add(this.grpTPIN);
            this.Controls.Add(this.lblHumidity);
            this.Controls.Add(this.lblPressure);
            this.Controls.Add(this.txtHumidity);
            this.Controls.Add(this.txtPressure);
            this.Controls.Add(this.lblAirTemp);
            this.Controls.Add(this.txtAirTemp);
            this.Controls.Add(this.grpMatTemp);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radStraightnessLong);
            this.Controls.Add(this.radStraightnessShort);
            this.Controls.Add(this.radAngular);
            this.Controls.Add(this.radLinearPlane);
            this.Controls.Add(this.radLinearRetro);
            this.Controls.Add(this.panSigStrength);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDatum);
            this.Controls.Add(this.staDX10);
            this.Controls.Add(this.btnConnect);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmDX10Example";
            this.Text = "DX10 SDK demo";
            ((System.ComponentModel.ISupportInitialize)(this.panDX10Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panML10Status)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panEC10Status)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panSigStrength.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.grpMatTemp.ResumeLayout(false);
            this.grpMatTemp.PerformLayout();
            this.grpTPIN.ResumeLayout(false);
            this.grpTPIN.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new frmDX10Example());
        }

        private void btnConnect_Click(object sender, System.EventArgs e)
        {
            string serNum = "";
            if (!dx10.Connect(ref serNum))
            {
                MessageBox.Show(this, "Failed to connect to a DX10", "DX10 Error");
            }
            else
            {
                panDX10Status.Text = "Connected to " + serNum;
                //btnConnect.Enabled = false;
                btnDatum.Enabled = true;
                btnReset.Enabled = true;
                radLinearPlane.Enabled = true;
                radLinearRetro.Enabled = true;
                radAngular.Enabled = true;
                radStraightnessLong.Enabled = true;
                radStraightnessShort.Enabled = true;
                radLinearRetro.Checked = true;

                radSyncTPIN.Enabled = true;
                radAsyncTPIN.Enabled = true;

                dx10_EC10Updated(dx10);
                DX10COMLib.EC10_STATUS_CODES status = DX10COMLib.EC10_STATUS_CODES.EC10_NOT_RESPONDING;
                status = dx10.EC10Status;

                dx10_EC10StatusChanged(dx10, dx10.EC10Status);
            }
        }

        private void btnDatum_Click(object sender, System.EventArgs e)
        {
            try
            {
                dx10.Datum();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(this, ex.Message, "DX10 Error");
            }
        }

        private void dx10_DX10StatusChanged(object obj, DX10COMLib.DX10_STATUS_CODES newVal)
        {
            DX10COMLib.IRenishawDX10 idx10 = obj as DX10COMLib.IRenishawDX10;
            if (newVal == DX10COMLib.DX10_STATUS_CODES.DX10_CONNECTED)
            {
                panDX10Status.Text = "Connected to " + idx10.DX10SerialNumber;
                panDX10Status.Icon = null;

                radLinearPlane.Enabled = true;
                radLinearRetro.Enabled = true;
                radAngular.Enabled = true;
                radStraightnessLong.Enabled = true;
                radStraightnessShort.Enabled = true;

                radSyncTPIN.Enabled = true;
                radAsyncTPIN.Enabled = true;

                btnDatum.Enabled = true;
                btnReset.Enabled = true;
            }
            else
            {
                panDX10Status.Text = "DX10 disconnected";
                panML10Status.Text = "";
                panEC10Status.Text = "";

                panDX10Status.Icon = icoError;
                panML10Status.Icon = null;
                panEC10Status.Icon = null;
                ModifyDROColour(System.Drawing.Color.Red);
                txtReading.Text = "";

                radLinearPlane.Enabled = false;
                radLinearRetro.Enabled = false;
                radAngular.Enabled = false;
                radStraightnessLong.Enabled = false;
                radStraightnessShort.Enabled = false;

                radSyncTPIN.Enabled = false;
                radAsyncTPIN.Enabled = false;

                btnDatum.Enabled = false;
                btnReset.Enabled = false;
            }
        }

        private void dx10_ML10Updated(object obj)
        {
            DX10COMLib.IRenishawDX10 idx10 = obj as DX10COMLib.IRenishawDX10;
            short sigStr = idx10.SignalStrength;
            prgSigStrength.Value = sigStr;

            if (sigStr < 4)
            {
                panSigStrength.BackColor = System.Drawing.Color.Red;
            }
            else if (sigStr < 12)
            {
                panSigStrength.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                panSigStrength.BackColor = System.Drawing.Color.Green;
            }

            DX10COMLib.COUNT_STATUS_CODES status;
            double dReading = idx10.GetLaserMeasurement(out status) * 1000;

            if ((status & DX10COMLib.COUNT_STATUS_CODES.COUNT_ERROR) != 0)
            {
                ModifyDROColour(System.Drawing.Color.Red);
            }
            else
            {
                ModifyDROColour(System.Drawing.Color.LimeGreen);
            }

            if ((status & DX10COMLib.COUNT_STATUS_CODES.COUNT_TPIN_OCCURRED) != 0)
            {
                txtTPINReading.Text = dReading.ToString("F6");
            }

            txtReading.Text = dReading.ToString("F6");
            CheckMeasurementMode();
        }

        private void ModifyDROColour(System.Drawing.Color col)
        {
            txtReading.ForeColor = col;
            txtUnits.ForeColor = col;
            txtMode.ForeColor = col;
            txtCompensation.ForeColor = col;
        }

        private void dx10_ML10StatusChanged(object obj, DX10COMLib.ML10_STATUS_CODES newVal)
        {
            if ((newVal & DX10COMLib.ML10_STATUS_CODES.ML10_NOT_RESPONDING) != 0)
            {
                ModifyDROColour(System.Drawing.Color.Red);
                panML10Status.Text = "ML10 not responding";
                panML10Status.Icon = icoError;
                radAsyncTPIN.Checked = false;
                radSyncTPIN.Checked = false;
            }
            else if ((newVal & DX10COMLib.ML10_STATUS_CODES.ML10_LASER_FAIL) != 0)
            {
                ModifyDROColour(System.Drawing.Color.Red);
                panML10Status.Text = "ML10 failed";
                panML10Status.Icon = icoError;
                radAsyncTPIN.Checked = false;
                radSyncTPIN.Checked = false;
            }
            else
            {
                panML10Status.Text = "ML10 on";
                panML10Status.Icon = null;
               
                txtUnstable.Visible = ((newVal & DX10COMLib.ML10_STATUS_CODES.ML10_LASER_UNSTABLE) != 0);
                txtPreheat.Visible = ((newVal & DX10COMLib.ML10_STATUS_CODES.ML10_PREHEAT) != 0);
                txtBeamLoss.Visible = ((newVal & DX10COMLib.ML10_STATUS_CODES.ML10_BEAM_LOSS) != 0);

                bool bTPINSet = ((newVal & DX10COMLib.ML10_STATUS_CODES.ML10_TPIN_SELECTED) != 0);
                if (bTPINSet)
                {
                    radSyncTPIN.Checked = true;
                    radAsyncTPIN.Checked = false;
                }
                else
                {
                    radAsyncTPIN.Checked = true;
                    radSyncTPIN.Checked = false;
                }

                CheckMeasurementMode();
            }
        }

        private void dx10_EC10StatusChanged(object obj, DX10COMLib.EC10_STATUS_CODES newVal)
        {
            if ((newVal & DX10COMLib.EC10_STATUS_CODES.EC10_NOT_RESPONDING) != 0)
            {
                panEC10Status.Text = "EC10 not responding";
                panEC10Status.Icon = icoError;
            }
            else
            {
                panEC10Status.Text = "EC10 on";
                panEC10Status.Icon = null;
            }
        }

        private void CheckMeasurementMode()
        {
            uint status = (uint) dx10.ML10Status;
            const uint modeMask = (uint) DX10COMLib.ML10_STATUS_CODES.ML10_MEASUREMENT_MODE;
            DX10COMLib.MEASUREMENT_MODES eMode = (DX10COMLib.MEASUREMENT_MODES)((status & modeMask) >> 20);

            switch (eMode)
            {
                case DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_ANGULAR:
                {
                    txtMode.Text = "mode: angular";
                    txtUnits.Text = "mrads";
                }
                    break;
                case DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_LINEAR_PLANE:
                {
                    txtMode.Text = "mode: linear (plane mirror)";
                    txtUnits.Text = "mm";
                }
                    break;
                case DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_LINEAR_RETRO:
                {
                    txtMode.Text = "mode: linear (retro-reflector)";
                    txtUnits.Text = "mm";
                }
                    break;
                case DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_STRAIGHTNESS_LONG:
                {
                    txtMode.Text = "mode: straightness (long)";
                    txtUnits.Text = "mm";
                }
                    break;
                case DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_STRAIGHTNESS_SHORT:
                {
                    txtMode.Text = "mode: straightness (short)";
                    txtUnits.Text = "mm";
                }
                    break;
                default:
                {
                    txtMode.Text = "mode:";
                    txtUnits.Text = "";
                }
                    break;
            }

            UpdateCompText();
        }

        private void UpdateCompText()
        {
            string strCompText;

            switch (dx10.AutoCompensationMode)
            {
                case DX10COMLib.AUTO_COMPENSATION_MODES.AUTO_COMPENSATION_AIR:
                {
                    strCompText = "compensation: air";
                }
                    break;
                case DX10COMLib.AUTO_COMPENSATION_MODES.AUTO_COMPENSATION_FULL:
                {
                    strCompText = "compensation: full";
                }
                    break;
                case DX10COMLib.AUTO_COMPENSATION_MODES.AUTO_COMPENSATION_OFF:
                {
                    strCompText = "compensation: off";
                }
                    break;
                default:
                {
                    strCompText = "compensation:";
                }
                    break;
            }

            txtCompensation.Text = strCompText;
        }

        private void MeasurementMode_Changed(object sender, System.EventArgs e)
        {
            RadioButton rad = sender as RadioButton;
            if (!rad.Checked)
                return;

            try
            {
                if (radLinearPlane.Checked)
                {
                    dx10.MeasurementMode = DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_LINEAR_PLANE;
                    dx10.AutoCompensationMode = DX10COMLib.AUTO_COMPENSATION_MODES.AUTO_COMPENSATION_FULL;
                }
                else if (radLinearRetro.Checked)
                {
                    dx10.MeasurementMode = DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_LINEAR_RETRO;
                    dx10.AutoCompensationMode = DX10COMLib.AUTO_COMPENSATION_MODES.AUTO_COMPENSATION_FULL;
                }
                else if (radAngular.Checked)
                {
                    dx10.MeasurementMode = DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_ANGULAR;
                    dx10.ResetCompensation();
                }
                else if (radStraightnessLong.Checked)
                {
                    dx10.MeasurementMode = DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_STRAIGHTNESS_LONG;
                    dx10.ResetCompensation();
                }
                else if (radStraightnessShort.Checked)
                {
                    dx10.MeasurementMode = DX10COMLib.MEASUREMENT_MODES.MEASUREMENT_STRAIGHTNESS_SHORT;
                    dx10.ResetCompensation();
                }

                CheckMeasurementMode();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(this, ex.Message, "DX10 Error");
            }
        }

        private void dx10_EC10Updated(object obj)
        {
            DX10COMLib.IRenishawDX10 idx10 = obj as DX10COMLib.IRenishawDX10;
            
            DX10COMLib.SENSOR_STATUS_CODES status;
            string errorText;
            double dValue;

            dValue = idx10.GetAirTemp(out status);
            txtAirTemp.Text = dValue.ToString("F1");
            errorText = GetSensorErrorString(status);
            errorProvider1.SetError(lblAirTemp, errorText);

            dValue = idx10.GetPressure(out status) / 100;
            txtPressure.Text = dValue.ToString("F1");
            errorText = GetSensorErrorString(status);
            errorProvider1.SetError(lblPressure, errorText);

            dValue = idx10.GetHumidity(out status);
            txtHumidity.Text = dValue.ToString("F1");
            errorText = GetSensorErrorString(status);
            errorProvider1.SetError(lblHumidity, errorText);

            dValue = idx10.GetMatTemp(1, out status);
            txtMatTemp1.Text = dValue.ToString("F1");
            errorText = GetSensorErrorString(status);
            errorProvider1.SetError(lblMatTemp1, errorText);

            dValue = idx10.GetMatTemp(2, out status);
            txtMatTemp2.Text = dValue.ToString("F1");
            errorText = GetSensorErrorString(status);
            errorProvider1.SetError(lblMatTemp2, errorText);

            dValue = idx10.GetMatTemp(3, out status);
            txtMatTemp3.Text = dValue.ToString("F1");
            errorText = GetSensorErrorString(status);
            errorProvider1.SetError(lblMatTemp3, errorText);
        }

        private string GetSensorErrorString(DX10COMLib.SENSOR_STATUS_CODES status)
        {
            string strError = "";

            switch (status)
            {
                case DX10COMLib.SENSOR_STATUS_CODES.SENSOR_BAD_READING:
                {
                    strError = "Bad reading received";
                }
                    break;
                case DX10COMLib.SENSOR_STATUS_CODES.SENSOR_FAILED:
                {
                    strError = "Sensor failed";
                }
                    break;
                case DX10COMLib.SENSOR_STATUS_CODES.SENSOR_NOT_CONNECTED:
                {
                    strError = "Sensor not connected";
                }
                    break;
                case DX10COMLib.SENSOR_STATUS_CODES.SENSOR_OK:
                {
                    strError = "";
                }
                    break;
                default:
                {
                    strError = "Unexpected error";
                }
                    break;
            }

            return strError;
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            try
            {
                dx10.ResetDatalink();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(this, ex.Message, "DX10 Error");
            }
        }

        private void radAsyncTPIN_Click(object sender, System.EventArgs e)
        {
            try
            {
                radAsyncTPIN.Checked = true;
                dx10.ClearTPIN();      
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(this, ex.Message, "DX10 Error");
                radAsyncTPIN.Checked = false;
            }
        }

        private void radSyncTPIN_Click(object sender, System.EventArgs e)
        {
            try
            {
                radSyncTPIN.Checked = true;
                dx10.SetTPIN();
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MessageBox.Show(this, ex.Message, "DX10 Error");
                radSyncTPIN.Checked = false;
            }
        }

        private void txtAirTemp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
