using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Numerics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace MaquinaVirtual
{
    public partial class Form1 : Form
    {
        private int[] M = new int[1024]; //Ver o tamanho da pilha
        private int[] P = new int[1024]; //Ver o tamanho da pilha
        private int s = -1,i=0;
        private int contLinha;
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
            
    }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contLinha = 0;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            s = -1;
            i = 0;

            
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               /* System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());  */ 


                using (TextFieldParser parser = new TextFieldParser(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, openFileDialog1.FileName)))
                {
                        // TextFieldParser parser2 = parser;
                        parser.Delimiters = new string[] { " ","," };
                        while (true)
                        {
                            string[] LineData = parser.ReadFields();


                            if (LineData == null)
                            {
                                break;
                            }
                            Console.WriteLine("{0} field(s)", LineData.Length);
    

                            if (LineData[0].Equals("ALLOC") || LineData[0].Equals("DALLOC"))
                            {
                                dataGridView1.Rows.Add(new object[] { contLinha, LineData[0], LineData[1], LineData[2] });
                            }
                            else if (LineData[0].Equals("LDC") || LineData[0].Equals("LDV") || LineData[0].Equals("STR") || LineData[0].Equals("JMP") || LineData[0].Equals("JMPF") || LineData[0].Equals("CALL"))
                            {
                                dataGridView1.Rows.Add(new object[] { contLinha, LineData[0], LineData[1] });
                            }
                            else
                            {
                                dataGridView1.Rows.Add(new object[] { contLinha, LineData[0] });
                            }
                            contLinha++;
                        }
                        
                }
                executarToolStripMenuItem.Enabled = true;
                //dataGridView3.Rows.Add(dataGridView1.Rows[1].Cells[2].Value);
                
                //MessageBox.Show(dataGridView1.Rows[1].Cells[2].Value.ToString());

                //sr.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void executarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows[0].Cells[1].Value.ToString().Equals("START"))
            {
                s = -1;
                for(int j = 1; j < contLinha; j++)
                {
                    switch (dataGridView1.Rows[j].Cells[1].Value.ToString())
                    {
                        case "ALLOC":
                            int m, k, n;

                            m = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                            n = Int32.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString());

                            dataGridView2.Rows.Add(m, n);

                            for (k = 0; k <= n - 1; k++)
                            {
                                s = s + 1;
                                M[s] = M[m + k];
                            }
                            break;

                        case "LDC":

                            n = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());

                            s = s + 1;
                            M[s] = n; //teoricamente "n" é "k"
                            break;

                        case "LDV":

                            n = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());

                            s = s + 1;
                            M[s] = M[n];
                            break;

                        case "ADD":

                            M[s - 1] = M[s - 1] + M[s];
                            s = s - 1;

                            break;

                        case "SUB":

                            M[s - 1] = M[s - 1] - M[s];
                            s = s - 1;
                            break;

                        case "MULT":

                            M[s - 1] = M[s - 1] * M[s];
                            s = s - 1;
                            break;

                        case "DIVI":

                            M[s - 1] = M[s - 1] / M[s];
                            s = s - 1;
                            break;

                        case "INV":

                            M[s] = -M[s];
                            break;

                        case "AND":

                            if (M[s - 1] == 1 && M[s] == 1)
                            {
                                M[s - 1] = 1;

                            }
                            else
                            {
                                M[s - 1] = 0;

                            }
                            s = s - 1;
                            break;

                        case "PRN":
                            dataGridView3.Rows.Add(M[s].ToString());
                            s = s - 1;
                            break;

                        case "OR":

                            if (M[s - 1] == 1 || M[s] == 1)
                            {
                                M[s - 1] = 1;

                            }
                            else
                            {
                                M[s - 1] = 0;

                            }
                            s = s - 1;
                            break;

                        case "NEG":

                            M[s] = 1 - M[s];
                            break;

                        case "CME":
                            if (M[s - 1] < M[s])
                            {
                                M[s - 1] = 1;

                            }
                            else
                            {
                                M[s - 1] = 0;

                            }
                            s = s - 1;
                            break;

                        case "CMA":
                            if (M[s - 1] > M[s])
                            {
                                M[s - 1] = 1;
                            }
                            else
                            {
                                M[s - 1] = 0;
                            }
                            s = s - 1;
                            break;

                        case "CEQ":
                            if (M[s - 1] == M[s])
                            {
                                M[s - 1] = 1;
                            }
                            else
                            {
                                M[s - 1] = 0;
                            }
                            s = s - 1;
                            break;

                        case "CDIF":
                            if (M[s - 1] != M[s])
                            {
                                M[s - 1] = 1;
                            }
                            else
                            {
                                M[s - 1] = 0;
                            }
                            s = s - 1;
                            break;

                        case "CMEQ":
                            if (M[s - 1] <= M[s])
                            {
                                M[s - 1] = 1;
                            }
                            else
                            {
                                M[s - 1] = 0;
                            }
                            s = s - 1;
                            break;

                        case "CMAQ":
                            if (M[s - 1] >= M[s])
                            {
                                M[s - 1] = 1;
                            }
                            else
                            {
                                M[s - 1] = 0;
                            }
                            s = s - 1;
                            break;

                        case "HLT": //observar
                            break;

                        case "STR":
                            n = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());

                            M[n] = M[s];
                            s = s - 1;
                            break;

                        case "JMP":
                            n = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                            i = n;
                            break;

                        case "JMPF":
                            n = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                            if(M[s] == 0)
                            {
                                i = n;
                            }
                            else
                            {
                                i = i + 1;
                            }
                            s = s - 1;
                            break;

                        case "NULL":
                            break;

                        case "RD": //ver isso auqi
                            MessageBox.Show("Entrada de dados requerida!");
                            textBox1.ReadOnly = false;
                            flag = false;
                            s = s + 1;
                            break;

                        case "DALLOC":
                            m = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
                            n = Int32.Parse(dataGridView1.Rows[j].Cells[3].Value.ToString());

                            dataGridView2.Rows.Add(m, n);

                            for (k = (n-1); k >= 0; k--)
                            {
                                M[m+k] = M[s];
                                s = s - 1;
                            }
                            break;

                        case "CALL":
                            n = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());

                            s = s + 1;
                            M[s] = i + 1;
                            i = n;
                            break;

                        case "RETURN":
                            n = Int32.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());

                            i = M[s];
                            s = s - 1;
                            break;

                    }

                }
            }
            else
            {
                MessageBox.Show("Programa sem a instrução START","ERRO",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            M[s] = Int32.Parse(textBox1.Text);
            dataGridView5.Rows.Add(textBox1.Text);
            textBox1.ReadOnly = true;
            flag = true;
        }
    }
}
