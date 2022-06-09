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
        private static int maxValueForRandom = 20;

        private static double startOfInterval = 5;
        private static double endOfInterval = 10;

        private Complex[] arrayOfComplexNum = new Complex[numberN];


        private double[] arrayOfValuesX;
        private double[] arrayOfFunc;
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

        #region Buttons
        private void button_generateComplexNum_Click(object sender, EventArgs e) {
            numberN = (int)this.numericUpDown_numN.Value;
            arrayOfComplexNum = new Complex[numberN];
            arrayOfComplexNum = Helper.GenerateSortedComplexNumArray(numberN, maxValueForRandom);
        }
        private void button_plotChartOriginalF_Click(object sender, EventArgs e) {
            if (this.radioButton_caseForComplexF.Checked) {
                BuildChartOfOriginalComplexFunc();
            }
            if (this.radioButton_caseForRealF.Checked) {

            }
        }
        private void button_plotChartModifiedF_Click(object sender, EventArgs e) {
            if (this.radioButton_caseForComplexF.Checked) {
                BuildChartOfModifiedComplexFunc();
            }
            if (this.radioButton_caseForRealF.Checked) {

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
            string tmp = string.Empty;
            foreach (Complex item in arrayOfComplexNum) {
                tmp += $"({item.Real}, {item.Imaginary}), ";
            }
            this.label_infoString1.Text = $"{nameof(numberN)}: {numberN}, lenArr = {arrayOfComplexNum.Length}\n{tmp}.";


        }




        private void button_testClearInfo_Click(object sender, EventArgs e) {
            this.label_infoString1.Text = string.Empty;
            this.label_infoString2.Text = string.Empty;
        }
        #endregion




        #region Build Charts
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
                this.label_infoString1.Text = $"len( f ): {arrayOfComplexNum.Length}\n{info1}";
            }
            #endregion
        }
        private void BuildChartOfModifiedComplexFunc() {
            this.chart_mainChart.Series[1].Points.Clear();
            numberN = (int)this.numericUpDown_numN.Value;
            zeroingPercentage = (int)this.numericUpDown_percent.Value;

            Complex[] arrayCoeffC = Helper.DFT((Complex[])arrayOfComplexNum.Clone(), numberN);
            int numberOfZeroed = numberN * zeroingPercentage / 100;

            #region case 2
            //// sorted
            //Complex[] sortedArrayCoeffC = ((Complex[])arrayCoeffC.Clone()).OrderBy(c => Math.Sqrt(Math.Pow(c.Real, 2) + Math.Pow(c.Imaginary, 2))).ToArray();

            //for (int j = 0; j < numberOfZeroed; j++) {
            //    sortedArrayCoeffC[j] = (Complex)0;
            //}
            #endregion
            #region case 3
            Tuple<Complex, int>[] tupleArrayCoeffC = new Tuple<Complex, int>[numberN];
            for (int j = 0; j < numberN; j++) {
                tupleArrayCoeffC[j] = new Tuple<Complex, int>(arrayCoeffC[j], j);
            }
            Tuple<Complex, int>[] sortedTupleArrayCoeffC = ((Tuple<Complex, int>[])tupleArrayCoeffC.Clone()).
                OrderBy(c => Math.Sqrt(Math.Pow(c.Item1.Real, 2) + Math.Pow(c.Item1.Imaginary, 2))).ToArray();
            for (int j = 0; j < numberOfZeroed; j++) {
                sortedTupleArrayCoeffC[j] = new Tuple<Complex, int>((Complex)0, sortedTupleArrayCoeffC[j].Item2);
            }
            tupleArrayCoeffC = ((Tuple<Complex, int>[])sortedTupleArrayCoeffC.Clone()).OrderBy(c => c.Item2).ToArray();
            for (int j = 0; j < numberN; j++) {
                arrayCoeffC[j] = tupleArrayCoeffC[j].Item1;
            }
            #endregion

            Complex[] arrayOfModComplexFunc = Helper.DFT((Complex[])arrayCoeffC.Clone(), numberN, true);                                    // case 1 / 3
            //Complex[] arrayOfModComplexFunc = Helper.DFT((Complex[])sortedArrayCoeffC.Clone(), numberN, true);                            // case 2                                 
            Complex[] sortedArrayOfModComplexFunc = ((Complex[])arrayOfModComplexFunc.Clone()).OrderBy(c => c.Real).ToArray();

            //foreach (Complex item in arrayOfModComplexFunc) {                                                                             // case 1 
            foreach (Complex item in sortedArrayOfModComplexFunc) {                                                                         // case 2 / 3
                this.chart_mainChart.Series[1].Points.AddXY(item.Real, item.Imaginary);
            }

            #region debug BuildChartOfModifiedComplexFunc

            if (this.checkBox_debug.Checked) {
                string info2 = string.Empty;
                foreach (Complex item in arrayOfModComplexFunc) {
                    info2 += $"({item.Real}, {item.Imaginary}), ";
                }
                this.label_infoString2.Text = $"len( f^ ): {arrayOfModComplexFunc.Length}\n{info2}";

                foreach (Complex item in arrayCoeffC) {
                    Console.Write($"({item.Real}, {item.Imaginary}), ");
                }
                Console.WriteLine($" - array coeff");
                foreach (Tuple<Complex, int> item in sortedTupleArrayCoeffC) {
                    Console.Write($"({item.Item1.Real}, {item.Item1.Imaginary}), ");
                }
                Console.WriteLine($" - sorted array coeff");
            }
            #endregion
        }

        #endregion




        #region Junk
        Complex[] arrayOfComplexFunctions;
        private double[] arrayOfFunctions;

        /// <summary>
        /// Построение графика f(x) до обнуления коэффициентов c
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateGraphOfFunctionOriginalF(object sender, EventArgs e) {
            this.chart_mainChart.Series[0].Points.Clear();
            try {

                numberN = (int)this.numericUpDown_numN.Value;
                arrayOfValuesX = new double[numberN + 1];
                arrayOfFunctions = new double[numberN + 1];

                Helper.CalcArrayOfValuesX(arrayOfValuesX, numberN);
                Helper.CalcArrayOfFunctions(arrayOfValuesX, arrayOfFunctions, numberN);

                for (int j = 0; j < numberN + 1; j++) {
                    this.chart_mainChart.Series[0].Points.AddXY(arrayOfValuesX[j], arrayOfFunctions[j]);
                }
            } catch (Exception ex) {
                this.label_infoString1.Text = $"Error: {ex.Message}.";
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
                Helper.BuildMatrixA(matrixA, numberN);

                /*Complex[]*/
                arrayOfComplexFunctions = new Complex[numberN + 1];

                for (int j = 0; j < numberN + 1; j++) {
                    arrayOfComplexFunctions[j] = (Complex)arrayOfFunctions[j];
                }
                Complex[] arrayOfCoeffC = new Complex[numberN + 1];

                Helper.CalcCoeffC(arrayOfCoeffC, matrixA, arrayOfComplexFunctions, numberN);

                modF = new double[numberN + 1];
                modF = Helper.Multiplication(arrayOfCoeffC, matrixA, numberN);

                for (int j = 0; j < numberN + 1; j++) {
                    this.chart_mainChart.Series[1].Points.AddXY(arrayOfValuesX[j], modF[j]);
                }
            } catch (Exception ex) {
                this.label_infoString1.Text = $"Error: {ex.Message}.";
            }
        }










        #endregion


    }
}
