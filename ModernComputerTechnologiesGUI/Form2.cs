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
        private int numberN;
        private double[] arrayOfValuesX;
        private double[] arrayOfFunctions;
        Complex[] arrayOfComplexFunctions;

        private void button1_Click(object sender, EventArgs e) {

        }


        private void button2_Click(object sender, EventArgs e) {
            try {
                CreateGraphOfFunctionOriginalF(sender, e);
                string tmp = string.Empty;
                foreach (double item in arrayOfFunctions) {
                    tmp += $"({item}, )";
                }
                informationStringLabel.Text = tmp;
            } catch (Exception ex) {
                informationStringLabel.Text = $"Error: {ex.Message}.";
            }

        }


        private void button3_Click(object sender, EventArgs e) {
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
                informationStringLabel.Text = tmp;
            } catch (Exception ex) {
                informationStringLabel.Text = $"Error: {ex.Message}.";
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            if (this.checkBox1.Checked) {
                this.chart1.Series[0].Points.Clear();
                this.checkBox1.Checked = false;
            }
            if (this.checkBox2.Checked) {
                this.chart1.Series[1].Points.Clear();
                this.checkBox2.Checked = false;
            }
        }


        #region
        /// <summary>
        /// Построение графика f(x) до обнуления коэффициентов c
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateGraphOfFunctionOriginalF(object sender, EventArgs e) {
            this.chart1.Series[0].Points.Clear();
            try {
                numberN = Convert.ToInt32(numericUpDown1.Value);
                arrayOfValuesX = new double[numberN + 1];
                arrayOfFunctions = new double[numberN + 1];

                Helpers.CalcArrayOfValuesX(arrayOfValuesX, numberN);
                Helpers.CalcArrayOfFunctions(arrayOfValuesX, arrayOfFunctions, numberN);

                for (int j = 0; j < numberN + 1; j++) {
                    this.chart1.Series[0].Points.AddXY(arrayOfValuesX[j], arrayOfFunctions[j]);
                }
            } catch (Exception ex) {
                informationStringLabel.Text = $"Error: {ex.Message}.";
            }
        }
        private double[] modF;
        /// <summary>
        /// Построение графика f(x) после обнуления коэффициентов c
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateGraphOfFunctionModifiedF(object sender, EventArgs e) {
            this.chart1.Series[1].Points.Clear();
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
                    this.chart1.Series[1].Points.AddXY(arrayOfValuesX[j], modF[j]);
                }
            } catch (Exception ex) {
                informationStringLabel.Text = $"Error: {ex.Message}.";
            }
        }



        #endregion

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton1.Checked) {
                this.panel6.Enabled = true;
                this.panel6.Visible = true;
                this.panel7.Enabled = false;
                this.panel7.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton2.Checked) {
                this.panel7.Enabled = true;
                this.panel7.Visible = true;
                this.panel6.Enabled = false;
                this.panel6.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            if (this.checkBox3.Checked) {
                this.panel5.Enabled = true;
                this.panel5.Visible = true;
            } else {
                this.panel5.Enabled = false;
                this.panel5.Visible = false;
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton3.Checked) {
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton4.Checked) {
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e) {
            if (this.radioButton5.Checked) {
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            }
        }
    }
}
