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

namespace ModernComputerTechnologiesGUI {
    public partial class Form2 : Form {
        public Form2() {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        

        #region buttons
        private void button_generateComplexNum_Click(object sender, EventArgs e) {

        }
        private void button_plotChartOriginalF_Click(object sender, EventArgs e) {
            try {
                CreateGraphOfFunctionOriginalF(sender, e);
                string tmp = string.Empty;
                foreach (double item in arrayOfFunctions) {
                    tmp += $"({item}, )";
                }
                label_infoString.Text = tmp;
            } catch (Exception ex) {
                label_infoString.Text = $"Error: {ex.Message}.";
            }

        }
        private void button_plotChartModifiedF_Click(object sender, EventArgs e) {
            try {
                CreateGraphOfFunctionModifiedF(sender, e);


                //informationStringLabel.Text = $"ArrayX lenght: {arrayOfValuesX.Length}\n ArrayX: {string.Join(", ", arrayOfValuesX)}";
                //arrayOfComplexFunctions = new Complex[numberN + 1];

                //for (int j = 0; j < numberN + 1; j++) {
                //    arrayOfComplexFunctions[j] = (Complex)arrayOfFunctions[j];
                //}

                string tmp = string.Empty;
                foreach (Complex item in modF) {
                    tmp += $"({item}, ";
                }
                label_infoString.Text = tmp;
            } catch (Exception ex) {
                label_infoString.Text = $"Error: {ex.Message}.";
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

        #region radioButtons
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


        private int numberN;
        private double[] arrayOfValuesX;
        private double[] arrayOfFunctions;
        Complex[] arrayOfComplexFunctions;

        #region Build charts
        /// <summary>
        /// Построение графика f(x) до обнуления коэффициентов c
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateGraphOfFunctionOriginalF(object sender, EventArgs e) {
            this.chart_mainChart.Series[0].Points.Clear();
            try {
                numberN = Convert.ToInt32(numericUpDown_numN.Value);
                arrayOfValuesX = new double[numberN + 1];
                arrayOfFunctions = new double[numberN + 1];

                Helpers.CalcArrayOfValuesX(arrayOfValuesX, numberN);
                Helpers.CalcArrayOfFunctions(arrayOfValuesX, arrayOfFunctions, numberN);

                for (int j = 0; j < numberN + 1; j++) {
                    this.chart_mainChart.Series[0].Points.AddXY(arrayOfValuesX[j], arrayOfFunctions[j]);
                }
            } catch (Exception ex) {
                label_infoString.Text = $"Error: {ex.Message}.";
            }
        }
        private double[] modF;
        /// <summary>
        /// Построение графика f(x) после обнуления коэффициентов c
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateGraphOfFunctionModifiedF(object sender, EventArgs e) {
            this.chart_mainChart.Series[1].Points.Clear();
            try {

                Complex[,] matrixA = new Complex[numberN + 1, numberN + 1];
                Helpers.BuildMatrixA(matrixA, numberN);

                /*Complex[]*/
                arrayOfComplexFunctions = new Complex[numberN + 1];

                for (int j = 0; j < numberN + 1; j++) {
                    arrayOfComplexFunctions[j] = (Complex)arrayOfFunctions[j];
                }
                Complex[] arrayOfCoeffC = new Complex[numberN + 1];

                Helpers.CalcCoeffC(arrayOfCoeffC, matrixA, arrayOfComplexFunctions, numberN);

                modF = new double[numberN + 1];
                modF = Helpers.Multiplication(arrayOfCoeffC, matrixA, numberN);

                for (int j = 0; j < numberN + 1; j++) {
                    this.chart_mainChart.Series[1].Points.AddXY(arrayOfValuesX[j], modF[j]);
                }
            } catch (Exception ex) {
                label_infoString.Text = $"Error: {ex.Message}.";
            }
        }



        #endregion

        
        

       
        
    }
}
