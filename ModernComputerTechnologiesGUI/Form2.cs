using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Numerics;
using System.Globalization;

namespace ModernComputerTechnologiesGUI {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        #region Initial Data // f_k: k=0,N-1
        private static int numberN = 10;
        private static int zeroingPercentage = 0;

        private static int scalingCoeff = 20;
        private Complex[] arrayOfComplexNum;

        private static double startOfInterval = 5;
        private static double endOfInterval = 10;

        private double[] arrayOfValuesX;
        private double[] arrayOfFuncValues;
        #endregion

        #region RadioButtons
        private void radioButton_caseForComplexF_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton_caseForComplexF.Checked) {
                this.panel_initCondForComplexF.Enabled = true;
                this.panel_initCondForComplexF.Visible = true;
                this.panel_initCondForRealF.Enabled = false;
                this.panel_initCondForRealF.Visible = false;
            }
        }
        private void radioButton_caseForRealF_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton_caseForRealF.Checked) {
                this.panel_initCondForRealF.Enabled = true;
                this.panel_initCondForRealF.Visible = true;
                this.panel_initCondForComplexF.Enabled = false;
                this.panel_initCondForComplexF.Visible = false;
            }
        }
        private void radioButton_chartsTypeSpline_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton_chartsTypeSpline.Checked) {
                this.chart_mainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                this.chart_mainChart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
        }
        private void radioButton_chartsTypeLine_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton_chartsTypeLine.Checked) {
                this.chart_mainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                this.chart_mainChart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
        }
        private void radioButton_chartsTypePoint_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton_chartsTypePoint.Checked) {
                this.chart_mainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                this.chart_mainChart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }
        }
        #endregion

        #region Buttons
        private void checkBox_chartscustom_CheckedChanged(object sender, EventArgs e) {
            if (this.checkBox_chartscustom.Checked) {
                this.panel_initChartsType.Enabled = true;
                this.panel_initChartsType.Visible = true;
            } else {
                this.panel_initChartsType.Enabled = false;
                this.panel_initChartsType.Visible = false;
                this.chart_mainChart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                this.chart_mainChart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
        }
        private void checkBox_debug_CheckedChanged(object sender, EventArgs e) {
            if (this.checkBox_debug.Checked) {
                this.button_testButton.Visible = true;
                this.button_testClearInfo.Visible = true;
            } else {
                this.button_testButton.Visible = false;
                this.button_testClearInfo.Visible = false;
            }
        }
        #endregion

        #region Buttons
        private void button_generateComplexNum_Click(object sender, EventArgs e) {    
            GenerateComplexNum();
        }
        private void button_plotChartOriginalF_Click(object sender, EventArgs e) {
            if (this.radioButton_caseForComplexF.Checked) {
                BuildChartOfOriginalComplexFunc();
            }
            if (this.radioButton_caseForRealF.Checked) {
                BuildChartOfOriginalRealFunc();
            }
        }
        private void button_plotChartModifiedF_Click(object sender, EventArgs e) {
            if (this.radioButton_caseForComplexF.Checked) {
                BuildChartOfModifiedComplexFunc();
            }
            if (this.radioButton_caseForRealF.Checked) {
                BuildChartOfModifiedRealFunc();
            }
        }
        private void button_deleteCharts_Click(object sender, EventArgs e) {
            if (this.checkBox_deleteChartsOfOriginalF.Checked) {
                this.chart_mainChart.Series[0].Points.Clear();
                this.checkBox_deleteChartsOfOriginalF.Checked = false;
            }
            if (this.checkBox_deleteChartsOfModifiedF.Checked) {
                this.chart_mainChart.Series[1].Points.Clear();
                this.checkBox_deleteChartsOfModifiedF.Checked = false;
            }
        }
        #endregion

        #region Test Buttons
        private void button_testButton_Click(object sender, EventArgs e) {
            this.label_infoString1.Text = $"...";
        }
        private void button_testClearInfo_Click(object sender, EventArgs e) {
            this.label_infoString1.Text = string.Empty;
            this.label_infoString2.Text = string.Empty;
        }
        #endregion

        #region Methods
        private void GenerateComplexNum() {
            numberN = (int)this.numericUpDown_numN.Value;
            arrayOfComplexNum = new Complex[numberN];

            scalingCoeff = (int)this.numericUpDown_ScalingCoeff.Value;
            arrayOfComplexNum = Helper.GenerateSortedComplexNumArray(numberN, scalingCoeff);
        }
        private void BuildChartOfOriginalComplexFunc() {
            this.chart_mainChart.Series[0].Points.Clear();
            foreach (Complex item in arrayOfComplexNum) {
                this.chart_mainChart.Series[0].Points.AddXY(item.Real, item.Imaginary);
            }
            #region debug BuildChartOfOriginalComplexFunc
            if (this.checkBox_debug.Checked) {
                string info1 = string.Empty;
                foreach (Complex item in arrayOfComplexNum) {
                    info1 += $"({item.Real}, {item.Imaginary}), ";
                }
                this.label_infoString1.Text = $"( Re( f ), Im( f ) ):\n{info1}";
            }
            #endregion
        }
        private void BuildChartOfModifiedComplexFunc() {
            this.chart_mainChart.Series[1].Points.Clear();
            zeroingPercentage = (int)this.numericUpDown_percent.Value;
            int numberOfZeroed = numberN * zeroingPercentage / 100;

            Complex[] arrayCoeffC = Helper.DFT(arrayOfComplexNum, numberN);
            Helper.ZeroingPercentageOfMinimumArrayValues(arrayCoeffC, numberN, numberOfZeroed);
            
            Complex[] arrayOfModifiedFunc = Helper.DFT(arrayCoeffC, numberN, true);                                                                     
            Complex[] sortedArrayOfModifiedFunc = ((Complex[])arrayOfModifiedFunc.Clone()).OrderBy(c => c.Real).ToArray();

            foreach (Complex item in sortedArrayOfModifiedFunc) {                                                                
                this.chart_mainChart.Series[1].Points.AddXY(item.Real, item.Imaginary);
            }
            #region debug BuildChartOfModifiedComplexFunc
            if (this.checkBox_debug.Checked) {
                string info2 = string.Empty;
                foreach (Complex item in arrayOfModifiedFunc) {
                    info2 += $"({item.Real}, {item.Imaginary}), ";
                }
                this.label_infoString2.Text = $"{nameof(numberOfZeroed)}={numberOfZeroed}. ( Re( f^ ), Im( f^ ) ):\n{info2}";
            }
            #endregion
        }
        private void BuildChartOfOriginalRealFunc() {
            this.chart_mainChart.Series[0].Points.Clear();
            numberN = (int)this.numericUpDown_numN.Value;
            startOfInterval = (double)this.numericUpDown_startOfInterval.Value;
            endOfInterval = (double)this.numericUpDown_endOfInterval.Value;
            
            arrayOfValuesX = new double[numberN];
            Helper.FillArrayOfValuesX(arrayOfValuesX, numberN, startOfInterval, endOfInterval);
            arrayOfFuncValues = new double[numberN];
            Helper.FillArrayOfFuncValues(arrayOfValuesX, arrayOfFuncValues, numberN);

            for (int j = 0; j < numberN ; j++) {
                this.chart_mainChart.Series[0].Points.AddXY(arrayOfValuesX[j], arrayOfFuncValues[j]);
            }
            #region debug BuildChartOfOriginalRealFunc
            if (this.checkBox_debug.Checked) {
                string info1 = string.Empty;
                for (int j = 0; j < numberN; j++) {
                    info1 += $"({arrayOfValuesX[j]}, {arrayOfFuncValues[j]}), ";
                }
                this.label_infoString1.Text = $"( x_k, f_k ):\n{info1}";
            }
            #endregion
        }
        private void BuildChartOfModifiedRealFunc() {
            this.chart_mainChart.Series[1].Points.Clear();
            zeroingPercentage = (int)this.numericUpDown_percent.Value;
            int numberOfZeroed = numberN * zeroingPercentage / 100;

            Complex[] arrayOfComplexFunc = new Complex[numberN];
            for (int j = 0; j < numberN; j++) {
                arrayOfComplexFunc[j] = (Complex)arrayOfFuncValues[j];
            }
            Complex[] arrayCoeffC = Helper.DFT(arrayOfComplexFunc, numberN);
            Helper.ZeroingPercentageOfMinimumArrayValues(arrayCoeffC, numberN, numberOfZeroed);

            Complex[] arrayOfModifiedComplexFunc = Helper.DFT(arrayCoeffC, numberN, true);
            Complex[] sortedArrayOfModifiedComplexFunc = ((Complex[])arrayOfModifiedComplexFunc.Clone()).OrderBy(c => c.Real).ToArray();

            for (int j = 0; j < numberN; j++) {
                this.chart_mainChart.Series[1].Points.AddXY(arrayOfValuesX[j], sortedArrayOfModifiedComplexFunc[j].Real);
            }
            #region debug BuildChartOfModifiedComplexFunc
            if (this.checkBox_debug.Checked) {
                string info2 = string.Empty;
                for (int j = 0; j < numberN; j++) {
                    info2 += $"({arrayOfValuesX[j]}, {sortedArrayOfModifiedComplexFunc[j].Real}), ";
                }
                this.label_infoString2.Text = $"{nameof(numberOfZeroed)}={numberOfZeroed}. ( x_k, f^_k ):\n{info2}";
            }
            #endregion
        }
        #endregion
    }
}
