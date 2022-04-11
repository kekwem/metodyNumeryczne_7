using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aproksymacja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string[] str = textBoxX.Text.Split(' ');
            double[] tablica_x = new double[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                tablica_x[i] = Convert.ToDouble(str[i]);
            }
            str = textBoxY.Text.Split(' ');
            double[] tablica_y = new double[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                tablica_y[i] = Convert.ToDouble(str[i]);
            }
            if (tablica_x.Length == tablica_y.Length)
            {
                double[,] tablica = new double[4, 5];
                tablica[0, 0] = tablica_x.Length;
                for (int i = 0; i < tablica_x.Length; i++)
                {
                    tablica[0, 1] += tablica_x[i];
                    tablica[0, 2] += Math.Pow(tablica_x[i], 2);
                    tablica[0, 3] += Math.Pow(tablica_x[i], 3);
                    tablica[0, 4] += tablica_y[i];
                }

                tablica[1, 0] = tablica[0, 1];
                tablica[1, 1] = tablica[0, 2];
                tablica[1, 2] = tablica[0, 3];
                for (int i = 0; i < tablica_x.Length; i++)
                {
                    tablica[1, 3] += Math.Pow(tablica_x[i], 4);
                    tablica[1, 4] += tablica_x[i] * tablica_y[i];
                }
                tablica[2, 0] = tablica[1, 1];
                tablica[2, 1] = tablica[1, 2];
                tablica[2, 2] = tablica[1, 3];
                for (int i = 0; i < tablica_x.Length; i++)
                {
                    tablica[2, 3] += Math.Pow(tablica_x[i], 5);
                    tablica[2, 4] += Math.Pow(tablica_x[i], 2) * tablica_y[i];
                }
                tablica[3, 0] = tablica[2, 1];
                tablica[3, 1] = tablica[2, 2];
                tablica[3, 2] = tablica[2, 3];
                for (int i = 0; i < tablica_x.Length; i++)
                {
                    tablica[3, 3] += Math.Pow(tablica_x[i], 6);
                    tablica[3, 4] += Math.Pow(tablica_x[i], 3) * tablica_y[i];
                }
                for (int i = 0; i < tablica.GetLength(0); i++)
                {
                    if (tablica[i, i] != 1)
                    {
                        double zm = tablica[i, i];
                        for (int j = 0; j < tablica.GetLength(1); j++)
                        {
                            tablica[i, j] /= zm;
                        }
                    }

                    for (int j = i + 1; j < tablica.GetLength(0); j++)
                    {
                        if (tablica[j, i] != 0)
                        {
                            double zm = tablica[j, i];
                            for (int n = 0; n < tablica.GetLength(1); n++)
                            {
                                tablica[j, n] -= tablica[i, n] * zm;
                            }
                        }
                    }

                }

                for (int i = tablica.GetLength(0) - 1; i >= 0; i--)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (tablica[j, i] != 0)
                        {
                            double zm = tablica[j, i];
                            for (int n = 0; n < tablica.GetLength(1); n++)
                            {
                                tablica[j, n] -= tablica[i, n] * zm;
                            }
                        }
                    }
                }
                label1.Text ="a_0 = " + tablica[0, tablica.GetLength(1) - 1];
                label2.Text = "a_1 = " + tablica[1, tablica.GetLength(1) - 1];
                label3.Text = "a_2 = " + tablica[2, tablica.GetLength(1) - 1];
                label4.Text = "a_3 = " + tablica[3, tablica.GetLength(1) - 1];
            }
        }
    }
}
