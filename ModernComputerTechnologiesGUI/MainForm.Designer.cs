
namespace ModernComputerTechnologiesGUI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel_choiceInitCond = new System.Windows.Forms.Panel();
            this.label_choiceInitCond = new System.Windows.Forms.Label();
            this.radioButton_caseForRealF = new System.Windows.Forms.RadioButton();
            this.radioButton_caseForComplexF = new System.Windows.Forms.RadioButton();
            this.button_generateComplexNum = new System.Windows.Forms.Button();
            this.numericUpDown_numN = new System.Windows.Forms.NumericUpDown();
            this.label_infoString = new System.Windows.Forms.Label();
            this.button_plotChartOriginalF = new System.Windows.Forms.Button();
            this.numericUpDown_percent = new System.Windows.Forms.NumericUpDown();
            this.panel_deleteCharts = new System.Windows.Forms.Panel();
            this.button_deleteCharts = new System.Windows.Forms.Button();
            this.label_deleteCharts = new System.Windows.Forms.Label();
            this.checkBox_deleteChartsOfModifiedF = new System.Windows.Forms.CheckBox();
            this.checkBox_deleteChartsOfOriginalF = new System.Windows.Forms.CheckBox();
            this.button_plotChartModifiedF = new System.Windows.Forms.Button();
            this.panel_initPercent = new System.Windows.Forms.Panel();
            this.label_initPercent = new System.Windows.Forms.Label();
            this.panel_initNumN = new System.Windows.Forms.Panel();
            this.label_initNumN = new System.Windows.Forms.Label();
            this.panel_initChartsType = new System.Windows.Forms.Panel();
            this.label_initChartsType = new System.Windows.Forms.Label();
            this.radioButton_chartsTypePoint = new System.Windows.Forms.RadioButton();
            this.radioButton_chartsTypeLine = new System.Windows.Forms.RadioButton();
            this.radioButton_chartsTypeSpline = new System.Windows.Forms.RadioButton();
            this.checkBox_chartscustom = new System.Windows.Forms.CheckBox();
            this.panel_initCondForComplexF = new System.Windows.Forms.Panel();
            this.numericUpDown_ScalingCoeff = new System.Windows.Forms.NumericUpDown();
            this.label_initScalingCoeff = new System.Windows.Forms.Label();
            this.panel_initCondForRealF = new System.Windows.Forms.Panel();
            this.numericUpDown_endOfInterval = new System.Windows.Forms.NumericUpDown();
            this.label_endOfInterval = new System.Windows.Forms.Label();
            this.numericUpDown_startOfInterval = new System.Windows.Forms.NumericUpDown();
            this.label_startOfInterval = new System.Windows.Forms.Label();
            this.label_funcDefArea = new System.Windows.Forms.Label();
            this.groupBox_initCond = new System.Windows.Forms.GroupBox();
            this.groupBox_plotCharts = new System.Windows.Forms.GroupBox();
            this.button_testClearInfo = new System.Windows.Forms.Button();
            this.button_testButton = new System.Windows.Forms.Button();
            this.groupBox_advancedSettings = new System.Windows.Forms.GroupBox();
            this.checkBox_debug = new System.Windows.Forms.CheckBox();
            this.chart_mainChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox_mainChartAndInfoPanel = new System.Windows.Forms.GroupBox();
            this.panel_infoPanel = new System.Windows.Forms.Panel();
            this.groupBox_leftPanel = new System.Windows.Forms.GroupBox();
            this.panel_choiceInitCond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_percent)).BeginInit();
            this.panel_deleteCharts.SuspendLayout();
            this.panel_initPercent.SuspendLayout();
            this.panel_initNumN.SuspendLayout();
            this.panel_initChartsType.SuspendLayout();
            this.panel_initCondForComplexF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ScalingCoeff)).BeginInit();
            this.panel_initCondForRealF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endOfInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startOfInterval)).BeginInit();
            this.groupBox_initCond.SuspendLayout();
            this.groupBox_plotCharts.SuspendLayout();
            this.groupBox_advancedSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainChart)).BeginInit();
            this.groupBox_mainChartAndInfoPanel.SuspendLayout();
            this.panel_infoPanel.SuspendLayout();
            this.groupBox_leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_choiceInitCond
            // 
            this.panel_choiceInitCond.Controls.Add(this.label_choiceInitCond);
            this.panel_choiceInitCond.Controls.Add(this.radioButton_caseForRealF);
            this.panel_choiceInitCond.Controls.Add(this.radioButton_caseForComplexF);
            this.panel_choiceInitCond.Location = new System.Drawing.Point(9, 16);
            this.panel_choiceInitCond.Name = "panel_choiceInitCond";
            this.panel_choiceInitCond.Size = new System.Drawing.Size(364, 74);
            this.panel_choiceInitCond.TabIndex = 2;
            // 
            // label_choiceInitCond
            // 
            this.label_choiceInitCond.AutoSize = true;
            this.label_choiceInitCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_choiceInitCond.Location = new System.Drawing.Point(10, 10);
            this.label_choiceInitCond.Name = "label_choiceInitCond";
            this.label_choiceInitCond.Size = new System.Drawing.Size(213, 18);
            this.label_choiceInitCond.TabIndex = 2;
            this.label_choiceInitCond.Text = "Choice of initial conditions:";
            // 
            // radioButton_caseForRealF
            // 
            this.radioButton_caseForRealF.AutoSize = true;
            this.radioButton_caseForRealF.Location = new System.Drawing.Point(186, 42);
            this.radioButton_caseForRealF.Name = "radioButton_caseForRealF";
            this.radioButton_caseForRealF.Size = new System.Drawing.Size(91, 21);
            this.radioButton_caseForRealF.TabIndex = 1;
            this.radioButton_caseForRealF.Text = "{f_k} \\in R";
            this.radioButton_caseForRealF.UseVisualStyleBackColor = true;
            this.radioButton_caseForRealF.CheckedChanged += new System.EventHandler(this.radioButton_caseForRealF_CheckedChanged);
            // 
            // radioButton_caseForComplexF
            // 
            this.radioButton_caseForComplexF.AutoSize = true;
            this.radioButton_caseForComplexF.Location = new System.Drawing.Point(44, 42);
            this.radioButton_caseForComplexF.Name = "radioButton_caseForComplexF";
            this.radioButton_caseForComplexF.Size = new System.Drawing.Size(90, 21);
            this.radioButton_caseForComplexF.TabIndex = 0;
            this.radioButton_caseForComplexF.Text = "{f_k} \\in C";
            this.radioButton_caseForComplexF.UseVisualStyleBackColor = true;
            this.radioButton_caseForComplexF.CheckedChanged += new System.EventHandler(this.radioButton_caseForComplexF_CheckedChanged);
            // 
            // button_generateComplexNum
            // 
            this.button_generateComplexNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_generateComplexNum.Location = new System.Drawing.Point(183, 7);
            this.button_generateComplexNum.Name = "button_generateComplexNum";
            this.button_generateComplexNum.Size = new System.Drawing.Size(174, 48);
            this.button_generateComplexNum.TabIndex = 3;
            this.button_generateComplexNum.Text = "Generate an array of complex numbers";
            this.button_generateComplexNum.UseVisualStyleBackColor = true;
            this.button_generateComplexNum.Click += new System.EventHandler(this.button_generateComplexNum_Click);
            // 
            // numericUpDown_numN
            // 
            this.numericUpDown_numN.Location = new System.Drawing.Point(246, 11);
            this.numericUpDown_numN.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_numN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_numN.Name = "numericUpDown_numN";
            this.numericUpDown_numN.Size = new System.Drawing.Size(76, 22);
            this.numericUpDown_numN.TabIndex = 5;
            this.numericUpDown_numN.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label_infoString
            // 
            this.label_infoString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_infoString.AutoSize = true;
            this.label_infoString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_infoString.Location = new System.Drawing.Point(20, 12);
            this.label_infoString.MinimumSize = new System.Drawing.Size(880, 65);
            this.label_infoString.Name = "label_infoString";
            this.label_infoString.Size = new System.Drawing.Size(880, 65);
            this.label_infoString.TabIndex = 6;
            // 
            // button_plotChartOriginalF
            // 
            this.button_plotChartOriginalF.Location = new System.Drawing.Point(149, 33);
            this.button_plotChartOriginalF.Name = "button_plotChartOriginalF";
            this.button_plotChartOriginalF.Size = new System.Drawing.Size(200, 30);
            this.button_plotChartOriginalF.TabIndex = 7;
            this.button_plotChartOriginalF.Text = "Plot the chart of original f";
            this.button_plotChartOriginalF.UseVisualStyleBackColor = true;
            this.button_plotChartOriginalF.Click += new System.EventHandler(this.button_plotChartOriginalF_Click);
            // 
            // numericUpDown_percent
            // 
            this.numericUpDown_percent.Location = new System.Drawing.Point(246, 44);
            this.numericUpDown_percent.Name = "numericUpDown_percent";
            this.numericUpDown_percent.Size = new System.Drawing.Size(76, 22);
            this.numericUpDown_percent.TabIndex = 8;
            // 
            // panel_deleteCharts
            // 
            this.panel_deleteCharts.Controls.Add(this.button_deleteCharts);
            this.panel_deleteCharts.Controls.Add(this.label_deleteCharts);
            this.panel_deleteCharts.Controls.Add(this.checkBox_deleteChartsOfModifiedF);
            this.panel_deleteCharts.Controls.Add(this.checkBox_deleteChartsOfOriginalF);
            this.panel_deleteCharts.Location = new System.Drawing.Point(9, 116);
            this.panel_deleteCharts.Name = "panel_deleteCharts";
            this.panel_deleteCharts.Size = new System.Drawing.Size(364, 123);
            this.panel_deleteCharts.TabIndex = 9;
            // 
            // button_deleteCharts
            // 
            this.button_deleteCharts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_deleteCharts.Location = new System.Drawing.Point(140, 46);
            this.button_deleteCharts.Name = "button_deleteCharts";
            this.button_deleteCharts.Size = new System.Drawing.Size(200, 60);
            this.button_deleteCharts.TabIndex = 4;
            this.button_deleteCharts.Text = "Delete charts";
            this.button_deleteCharts.UseVisualStyleBackColor = true;
            this.button_deleteCharts.Click += new System.EventHandler(this.button_deleteCharts_Click);
            // 
            // label_deleteCharts
            // 
            this.label_deleteCharts.AutoSize = true;
            this.label_deleteCharts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_deleteCharts.Location = new System.Drawing.Point(10, 13);
            this.label_deleteCharts.Name = "label_deleteCharts";
            this.label_deleteCharts.Size = new System.Drawing.Size(113, 18);
            this.label_deleteCharts.TabIndex = 3;
            this.label_deleteCharts.Text = "Delete charts:";
            // 
            // checkBox_deleteChartsOfModifiedF
            // 
            this.checkBox_deleteChartsOfModifiedF.AutoSize = true;
            this.checkBox_deleteChartsOfModifiedF.Location = new System.Drawing.Point(37, 84);
            this.checkBox_deleteChartsOfModifiedF.Name = "checkBox_deleteChartsOfModifiedF";
            this.checkBox_deleteChartsOfModifiedF.Size = new System.Drawing.Size(91, 21);
            this.checkBox_deleteChartsOfModifiedF.TabIndex = 1;
            this.checkBox_deleteChartsOfModifiedF.Text = "Modified f";
            this.checkBox_deleteChartsOfModifiedF.UseVisualStyleBackColor = true;
            // 
            // checkBox_deleteChartsOfOriginalF
            // 
            this.checkBox_deleteChartsOfOriginalF.AutoSize = true;
            this.checkBox_deleteChartsOfOriginalF.Location = new System.Drawing.Point(37, 47);
            this.checkBox_deleteChartsOfOriginalF.Name = "checkBox_deleteChartsOfOriginalF";
            this.checkBox_deleteChartsOfOriginalF.Size = new System.Drawing.Size(87, 21);
            this.checkBox_deleteChartsOfOriginalF.TabIndex = 0;
            this.checkBox_deleteChartsOfOriginalF.Text = "Original f";
            this.checkBox_deleteChartsOfOriginalF.UseVisualStyleBackColor = true;
            // 
            // button_plotChartModifiedF
            // 
            this.button_plotChartModifiedF.Location = new System.Drawing.Point(149, 83);
            this.button_plotChartModifiedF.Name = "button_plotChartModifiedF";
            this.button_plotChartModifiedF.Size = new System.Drawing.Size(200, 30);
            this.button_plotChartModifiedF.TabIndex = 2;
            this.button_plotChartModifiedF.Text = "Plot the chart of modified f";
            this.button_plotChartModifiedF.UseVisualStyleBackColor = true;
            this.button_plotChartModifiedF.Click += new System.EventHandler(this.button_plotChartModifiedF_Click);
            // 
            // panel_initPercent
            // 
            this.panel_initPercent.Controls.Add(this.label_initPercent);
            this.panel_initPercent.Controls.Add(this.numericUpDown_percent);
            this.panel_initPercent.Location = new System.Drawing.Point(9, 289);
            this.panel_initPercent.Name = "panel_initPercent";
            this.panel_initPercent.Size = new System.Drawing.Size(364, 76);
            this.panel_initPercent.TabIndex = 13;
            // 
            // label_initPercent
            // 
            this.label_initPercent.AutoSize = true;
            this.label_initPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_initPercent.Location = new System.Drawing.Point(13, 15);
            this.label_initPercent.Name = "label_initPercent";
            this.label_initPercent.Size = new System.Drawing.Size(264, 18);
            this.label_initPercent.TabIndex = 12;
            this.label_initPercent.Text = "Initializing the zeroing percentage:";
            // 
            // panel_initNumN
            // 
            this.panel_initNumN.Controls.Add(this.label_initNumN);
            this.panel_initNumN.Controls.Add(this.numericUpDown_numN);
            this.panel_initNumN.Location = new System.Drawing.Point(9, 96);
            this.panel_initNumN.Name = "panel_initNumN";
            this.panel_initNumN.Size = new System.Drawing.Size(364, 41);
            this.panel_initNumN.TabIndex = 14;
            // 
            // label_initNumN
            // 
            this.label_initNumN.AutoSize = true;
            this.label_initNumN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_initNumN.Location = new System.Drawing.Point(10, 11);
            this.label_initNumN.Name = "label_initNumN";
            this.label_initNumN.Size = new System.Drawing.Size(193, 18);
            this.label_initNumN.TabIndex = 11;
            this.label_initNumN.Text = "Initializing the number N:";
            // 
            // panel_initChartsType
            // 
            this.panel_initChartsType.Controls.Add(this.label_initChartsType);
            this.panel_initChartsType.Controls.Add(this.radioButton_chartsTypePoint);
            this.panel_initChartsType.Controls.Add(this.radioButton_chartsTypeLine);
            this.panel_initChartsType.Controls.Add(this.radioButton_chartsTypeSpline);
            this.panel_initChartsType.Enabled = false;
            this.panel_initChartsType.Location = new System.Drawing.Point(9, 41);
            this.panel_initChartsType.Name = "panel_initChartsType";
            this.panel_initChartsType.Size = new System.Drawing.Size(364, 69);
            this.panel_initChartsType.TabIndex = 7;
            this.panel_initChartsType.Visible = false;
            // 
            // label_initChartsType
            // 
            this.label_initChartsType.AutoSize = true;
            this.label_initChartsType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_initChartsType.Location = new System.Drawing.Point(10, 12);
            this.label_initChartsType.Name = "label_initChartsType";
            this.label_initChartsType.Size = new System.Drawing.Size(203, 18);
            this.label_initChartsType.TabIndex = 3;
            this.label_initChartsType.Text = "Initializing the charts type:";
            // 
            // radioButton_chartsTypePoint
            // 
            this.radioButton_chartsTypePoint.AutoSize = true;
            this.radioButton_chartsTypePoint.Checked = true;
            this.radioButton_chartsTypePoint.Location = new System.Drawing.Point(189, 41);
            this.radioButton_chartsTypePoint.Name = "radioButton_chartsTypePoint";
            this.radioButton_chartsTypePoint.Size = new System.Drawing.Size(61, 21);
            this.radioButton_chartsTypePoint.TabIndex = 2;
            this.radioButton_chartsTypePoint.TabStop = true;
            this.radioButton_chartsTypePoint.Text = "Point";
            this.radioButton_chartsTypePoint.UseVisualStyleBackColor = true;
            this.radioButton_chartsTypePoint.CheckedChanged += new System.EventHandler(this.radioButton_chartsTypePoint_CheckedChanged);
            // 
            // radioButton_chartsTypeLine
            // 
            this.radioButton_chartsTypeLine.AutoSize = true;
            this.radioButton_chartsTypeLine.Location = new System.Drawing.Point(119, 41);
            this.radioButton_chartsTypeLine.Name = "radioButton_chartsTypeLine";
            this.radioButton_chartsTypeLine.Size = new System.Drawing.Size(56, 21);
            this.radioButton_chartsTypeLine.TabIndex = 1;
            this.radioButton_chartsTypeLine.Text = "Line";
            this.radioButton_chartsTypeLine.UseVisualStyleBackColor = true;
            this.radioButton_chartsTypeLine.CheckedChanged += new System.EventHandler(this.radioButton_chartsTypeLine_CheckedChanged);
            // 
            // radioButton_chartsTypeSpline
            // 
            this.radioButton_chartsTypeSpline.AutoSize = true;
            this.radioButton_chartsTypeSpline.Location = new System.Drawing.Point(43, 41);
            this.radioButton_chartsTypeSpline.Name = "radioButton_chartsTypeSpline";
            this.radioButton_chartsTypeSpline.Size = new System.Drawing.Size(68, 21);
            this.radioButton_chartsTypeSpline.TabIndex = 0;
            this.radioButton_chartsTypeSpline.Text = "Spline";
            this.radioButton_chartsTypeSpline.UseVisualStyleBackColor = true;
            this.radioButton_chartsTypeSpline.CheckedChanged += new System.EventHandler(this.radioButton_chartsTypeSpline_CheckedChanged);
            // 
            // checkBox_chartscustom
            // 
            this.checkBox_chartscustom.AutoSize = true;
            this.checkBox_chartscustom.Location = new System.Drawing.Point(9, 14);
            this.checkBox_chartscustom.Name = "checkBox_chartscustom";
            this.checkBox_chartscustom.Size = new System.Drawing.Size(161, 21);
            this.checkBox_chartscustom.TabIndex = 0;
            this.checkBox_chartscustom.Text = "Charts customization";
            this.checkBox_chartscustom.UseVisualStyleBackColor = true;
            this.checkBox_chartscustom.CheckedChanged += new System.EventHandler(this.checkBox_chartscustom_CheckedChanged);
            // 
            // panel_initCondForComplexF
            // 
            this.panel_initCondForComplexF.Controls.Add(this.numericUpDown_ScalingCoeff);
            this.panel_initCondForComplexF.Controls.Add(this.label_initScalingCoeff);
            this.panel_initCondForComplexF.Controls.Add(this.button_generateComplexNum);
            this.panel_initCondForComplexF.Location = new System.Drawing.Point(9, 143);
            this.panel_initCondForComplexF.Name = "panel_initCondForComplexF";
            this.panel_initCondForComplexF.Size = new System.Drawing.Size(364, 62);
            this.panel_initCondForComplexF.TabIndex = 15;
            this.panel_initCondForComplexF.Visible = false;
            // 
            // numericUpDown_ScalingCoeff
            // 
            this.numericUpDown_ScalingCoeff.Location = new System.Drawing.Point(89, 16);
            this.numericUpDown_ScalingCoeff.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_ScalingCoeff.Name = "numericUpDown_ScalingCoeff";
            this.numericUpDown_ScalingCoeff.Size = new System.Drawing.Size(70, 22);
            this.numericUpDown_ScalingCoeff.TabIndex = 5;
            this.numericUpDown_ScalingCoeff.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label_initScalingCoeff
            // 
            this.label_initScalingCoeff.AutoSize = true;
            this.label_initScalingCoeff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_initScalingCoeff.Location = new System.Drawing.Point(10, 16);
            this.label_initScalingCoeff.Name = "label_initScalingCoeff";
            this.label_initScalingCoeff.Size = new System.Drawing.Size(68, 18);
            this.label_initScalingCoeff.TabIndex = 4;
            this.label_initScalingCoeff.Text = "Scaling:";
            // 
            // panel_initCondForRealF
            // 
            this.panel_initCondForRealF.Controls.Add(this.numericUpDown_endOfInterval);
            this.panel_initCondForRealF.Controls.Add(this.label_endOfInterval);
            this.panel_initCondForRealF.Controls.Add(this.numericUpDown_startOfInterval);
            this.panel_initCondForRealF.Controls.Add(this.label_startOfInterval);
            this.panel_initCondForRealF.Controls.Add(this.label_funcDefArea);
            this.panel_initCondForRealF.Location = new System.Drawing.Point(9, 211);
            this.panel_initCondForRealF.Name = "panel_initCondForRealF";
            this.panel_initCondForRealF.Size = new System.Drawing.Size(364, 69);
            this.panel_initCondForRealF.TabIndex = 16;
            this.panel_initCondForRealF.Visible = false;
            // 
            // numericUpDown_endOfInterval
            // 
            this.numericUpDown_endOfInterval.DecimalPlaces = 2;
            this.numericUpDown_endOfInterval.Location = new System.Drawing.Point(246, 39);
            this.numericUpDown_endOfInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_endOfInterval.Name = "numericUpDown_endOfInterval";
            this.numericUpDown_endOfInterval.Size = new System.Drawing.Size(76, 22);
            this.numericUpDown_endOfInterval.TabIndex = 4;
            this.numericUpDown_endOfInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label_endOfInterval
            // 
            this.label_endOfInterval.AutoSize = true;
            this.label_endOfInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_endOfInterval.Location = new System.Drawing.Point(186, 39);
            this.label_endOfInterval.Name = "label_endOfInterval";
            this.label_endOfInterval.Size = new System.Drawing.Size(38, 18);
            this.label_endOfInterval.TabIndex = 3;
            this.label_endOfInterval.Text = "End:";
            // 
            // numericUpDown_startOfInterval
            // 
            this.numericUpDown_startOfInterval.DecimalPlaces = 2;
            this.numericUpDown_startOfInterval.Location = new System.Drawing.Point(83, 39);
            this.numericUpDown_startOfInterval.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDown_startOfInterval.Name = "numericUpDown_startOfInterval";
            this.numericUpDown_startOfInterval.Size = new System.Drawing.Size(76, 22);
            this.numericUpDown_startOfInterval.TabIndex = 2;
            this.numericUpDown_startOfInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            // 
            // label_startOfInterval
            // 
            this.label_startOfInterval.AutoSize = true;
            this.label_startOfInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_startOfInterval.Location = new System.Drawing.Point(16, 39);
            this.label_startOfInterval.Name = "label_startOfInterval";
            this.label_startOfInterval.Size = new System.Drawing.Size(43, 18);
            this.label_startOfInterval.TabIndex = 1;
            this.label_startOfInterval.Text = "Start:";
            // 
            // label_funcDefArea
            // 
            this.label_funcDefArea.AutoSize = true;
            this.label_funcDefArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_funcDefArea.Location = new System.Drawing.Point(10, 10);
            this.label_funcDefArea.Name = "label_funcDefArea";
            this.label_funcDefArea.Size = new System.Drawing.Size(277, 18);
            this.label_funcDefArea.TabIndex = 0;
            this.label_funcDefArea.Text = "Initializing a function definition area:";
            // 
            // groupBox_initCond
            // 
            this.groupBox_initCond.Controls.Add(this.panel_initPercent);
            this.groupBox_initCond.Controls.Add(this.panel_choiceInitCond);
            this.groupBox_initCond.Controls.Add(this.panel_initNumN);
            this.groupBox_initCond.Controls.Add(this.panel_initCondForRealF);
            this.groupBox_initCond.Controls.Add(this.panel_initCondForComplexF);
            this.groupBox_initCond.Location = new System.Drawing.Point(11, 11);
            this.groupBox_initCond.Name = "groupBox_initCond";
            this.groupBox_initCond.Size = new System.Drawing.Size(382, 372);
            this.groupBox_initCond.TabIndex = 17;
            this.groupBox_initCond.TabStop = false;
            // 
            // groupBox_plotCharts
            // 
            this.groupBox_plotCharts.Controls.Add(this.button_testClearInfo);
            this.groupBox_plotCharts.Controls.Add(this.button_testButton);
            this.groupBox_plotCharts.Controls.Add(this.button_plotChartOriginalF);
            this.groupBox_plotCharts.Controls.Add(this.button_plotChartModifiedF);
            this.groupBox_plotCharts.Location = new System.Drawing.Point(11, 385);
            this.groupBox_plotCharts.Name = "groupBox_plotCharts";
            this.groupBox_plotCharts.Size = new System.Drawing.Size(381, 137);
            this.groupBox_plotCharts.TabIndex = 18;
            this.groupBox_plotCharts.TabStop = false;
            // 
            // button_testClearInfo
            // 
            this.button_testClearInfo.Location = new System.Drawing.Point(22, 83);
            this.button_testClearInfo.Name = "button_testClearInfo";
            this.button_testClearInfo.Size = new System.Drawing.Size(110, 30);
            this.button_testClearInfo.TabIndex = 9;
            this.button_testClearInfo.Text = "ClearInfo";
            this.button_testClearInfo.UseVisualStyleBackColor = true;
            this.button_testClearInfo.Visible = false;
            this.button_testClearInfo.Click += new System.EventHandler(this.button_testClearInfo_Click);
            // 
            // button_testButton
            // 
            this.button_testButton.Location = new System.Drawing.Point(22, 33);
            this.button_testButton.Name = "button_testButton";
            this.button_testButton.Size = new System.Drawing.Size(110, 30);
            this.button_testButton.TabIndex = 8;
            this.button_testButton.Text = "Test";
            this.button_testButton.UseVisualStyleBackColor = true;
            this.button_testButton.Visible = false;
            this.button_testButton.Click += new System.EventHandler(this.button_testButton_Click);
            // 
            // groupBox_advancedSettings
            // 
            this.groupBox_advancedSettings.Controls.Add(this.checkBox_debug);
            this.groupBox_advancedSettings.Controls.Add(this.panel_deleteCharts);
            this.groupBox_advancedSettings.Controls.Add(this.panel_initChartsType);
            this.groupBox_advancedSettings.Controls.Add(this.checkBox_chartscustom);
            this.groupBox_advancedSettings.Location = new System.Drawing.Point(11, 526);
            this.groupBox_advancedSettings.Name = "groupBox_advancedSettings";
            this.groupBox_advancedSettings.Size = new System.Drawing.Size(381, 250);
            this.groupBox_advancedSettings.TabIndex = 19;
            this.groupBox_advancedSettings.TabStop = false;
            // 
            // checkBox_debug
            // 
            this.checkBox_debug.AutoSize = true;
            this.checkBox_debug.Location = new System.Drawing.Point(199, 14);
            this.checkBox_debug.Name = "checkBox_debug";
            this.checkBox_debug.Size = new System.Drawing.Size(72, 21);
            this.checkBox_debug.TabIndex = 10;
            this.checkBox_debug.Text = "Debug";
            this.checkBox_debug.UseVisualStyleBackColor = true;
            this.checkBox_debug.CheckedChanged += new System.EventHandler(this.checkBox_debug_CheckedChanged);
            // 
            // chart_mainChart
            // 
            this.chart_mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_mainChart.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart_mainChart.Legends.Add(legend1);
            this.chart_mainChart.Location = new System.Drawing.Point(13, 15);
            this.chart_mainChart.Name = "chart_mainChart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.Legend = "Legend1";
            series1.Name = "Original f";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series2.Legend = "Legend1";
            series2.Name = "Modified f";
            this.chart_mainChart.Series.Add(series1);
            this.chart_mainChart.Series.Add(series2);
            this.chart_mainChart.Size = new System.Drawing.Size(919, 658);
            this.chart_mainChart.TabIndex = 0;
            this.chart_mainChart.Text = "1";
            // 
            // groupBox_mainChartAndInfoPanel
            // 
            this.groupBox_mainChartAndInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_mainChartAndInfoPanel.Controls.Add(this.panel_infoPanel);
            this.groupBox_mainChartAndInfoPanel.Controls.Add(this.chart_mainChart);
            this.groupBox_mainChartAndInfoPanel.Location = new System.Drawing.Point(420, 3);
            this.groupBox_mainChartAndInfoPanel.Name = "groupBox_mainChartAndInfoPanel";
            this.groupBox_mainChartAndInfoPanel.Size = new System.Drawing.Size(946, 784);
            this.groupBox_mainChartAndInfoPanel.TabIndex = 20;
            this.groupBox_mainChartAndInfoPanel.TabStop = false;
            // 
            // panel_infoPanel
            // 
            this.panel_infoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_infoPanel.Controls.Add(this.label_infoString);
            this.panel_infoPanel.Location = new System.Drawing.Point(13, 681);
            this.panel_infoPanel.Name = "panel_infoPanel";
            this.panel_infoPanel.Size = new System.Drawing.Size(919, 90);
            this.panel_infoPanel.TabIndex = 1;
            // 
            // groupBox_leftPanel
            // 
            this.groupBox_leftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox_leftPanel.Controls.Add(this.groupBox_initCond);
            this.groupBox_leftPanel.Controls.Add(this.groupBox_plotCharts);
            this.groupBox_leftPanel.Controls.Add(this.groupBox_advancedSettings);
            this.groupBox_leftPanel.Location = new System.Drawing.Point(10, 3);
            this.groupBox_leftPanel.Name = "groupBox_leftPanel";
            this.groupBox_leftPanel.Size = new System.Drawing.Size(404, 784);
            this.groupBox_leftPanel.TabIndex = 21;
            this.groupBox_leftPanel.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 796);
            this.Controls.Add(this.groupBox_leftPanel);
            this.Controls.Add(this.groupBox_mainChartAndInfoPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Drawing charts (nearsolt)";
            this.panel_choiceInitCond.ResumeLayout(false);
            this.panel_choiceInitCond.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_percent)).EndInit();
            this.panel_deleteCharts.ResumeLayout(false);
            this.panel_deleteCharts.PerformLayout();
            this.panel_initPercent.ResumeLayout(false);
            this.panel_initPercent.PerformLayout();
            this.panel_initNumN.ResumeLayout(false);
            this.panel_initNumN.PerformLayout();
            this.panel_initChartsType.ResumeLayout(false);
            this.panel_initChartsType.PerformLayout();
            this.panel_initCondForComplexF.ResumeLayout(false);
            this.panel_initCondForComplexF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ScalingCoeff)).EndInit();
            this.panel_initCondForRealF.ResumeLayout(false);
            this.panel_initCondForRealF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_endOfInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_startOfInterval)).EndInit();
            this.groupBox_initCond.ResumeLayout(false);
            this.groupBox_plotCharts.ResumeLayout(false);
            this.groupBox_advancedSettings.ResumeLayout(false);
            this.groupBox_advancedSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_mainChart)).EndInit();
            this.groupBox_mainChartAndInfoPanel.ResumeLayout(false);
            this.panel_infoPanel.ResumeLayout(false);
            this.panel_infoPanel.PerformLayout();
            this.groupBox_leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_choiceInitCond;
        private System.Windows.Forms.RadioButton radioButton_caseForRealF;
        private System.Windows.Forms.RadioButton radioButton_caseForComplexF;
        private System.Windows.Forms.Button button_generateComplexNum;
        private System.Windows.Forms.NumericUpDown numericUpDown_numN;
        private System.Windows.Forms.Label label_infoString;
        private System.Windows.Forms.Button button_plotChartOriginalF;
        private System.Windows.Forms.NumericUpDown numericUpDown_percent;
        private System.Windows.Forms.Panel panel_deleteCharts;
        private System.Windows.Forms.Button button_plotChartModifiedF;
        private System.Windows.Forms.CheckBox checkBox_deleteChartsOfModifiedF;
        private System.Windows.Forms.CheckBox checkBox_deleteChartsOfOriginalF;
        private System.Windows.Forms.Label label_deleteCharts;
        private System.Windows.Forms.Panel panel_initPercent;
        private System.Windows.Forms.Label label_initPercent;
        private System.Windows.Forms.Panel panel_initNumN;
        private System.Windows.Forms.Label label_initNumN;
        private System.Windows.Forms.Label label_choiceInitCond;
        private System.Windows.Forms.Panel panel_initChartsType;
        private System.Windows.Forms.CheckBox checkBox_chartscustom;
        private System.Windows.Forms.RadioButton radioButton_chartsTypePoint;
        private System.Windows.Forms.RadioButton radioButton_chartsTypeLine;
        private System.Windows.Forms.RadioButton radioButton_chartsTypeSpline;
        private System.Windows.Forms.Label label_initChartsType;
        private System.Windows.Forms.Panel panel_initCondForComplexF;
        private System.Windows.Forms.Panel panel_initCondForRealF;
        private System.Windows.Forms.Label label_funcDefArea;
        private System.Windows.Forms.Button button_deleteCharts;
        private System.Windows.Forms.NumericUpDown numericUpDown_endOfInterval;
        private System.Windows.Forms.Label label_endOfInterval;
        private System.Windows.Forms.NumericUpDown numericUpDown_startOfInterval;
        private System.Windows.Forms.Label label_startOfInterval;
        private System.Windows.Forms.GroupBox groupBox_initCond;
        private System.Windows.Forms.GroupBox groupBox_plotCharts;
        private System.Windows.Forms.GroupBox groupBox_advancedSettings;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_mainChart;
        private System.Windows.Forms.GroupBox groupBox_mainChartAndInfoPanel;
        private System.Windows.Forms.Panel panel_infoPanel;
        private System.Windows.Forms.Button button_testButton;
        private System.Windows.Forms.Button button_testClearInfo;
        private System.Windows.Forms.CheckBox checkBox_debug;
        private System.Windows.Forms.Label label_initScalingCoeff;
        private System.Windows.Forms.NumericUpDown numericUpDown_ScalingCoeff;
        private System.Windows.Forms.GroupBox groupBox_leftPanel;
    }
}