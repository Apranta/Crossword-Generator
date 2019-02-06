using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkripsiV2
{
    public partial class Form1 : Form
    {
        Grid grid;
        WordsDic dic = new WordsDic();
        List<string> words;
        Generator gen;
        double usedCount = 0;
        char[][] data;
        int row, column , ju = 0 , hitam = 0 , putih =0;
        String jawabanboard;
        public Form1(int row , int column)
        {
            InitializeComponent();
            //this.row = row;
            //this.column = column;
            do
            {
                grid = new Grid(row, column);
                words = new List<string>(dic.Dictionary.Keys);
                gen = new Generator(grid, words);
                usedCount = gen.generate();
                ju++;
                Console.WriteLine("score : " + usedCount);
            } while (usedCount < 0.2);
            this.row = grid.LastRow;
            this.column = grid.LastCol;
            //grid.show();
            if (ju > 20)
            {
                MessageBox.Show("Batas Maksimum telah tercapai", "Warning",
               MessageBoxButtons.OK, MessageBoxIcon.None);

            }
            else
            {

                this.show();
            }    
        }


        private void show()
        {
            Dictionary<int, List<string>> horizontalAnnex = gen.HorizontalAnnex;
            Dictionary<int, List<string>> verticalAnnex = gen.VerticalAnnex;
            List<int> list = new List<int>(horizontalAnnex.Keys);
            list = list.OrderBy(r => r).ToList();
            mendatar.Items.Add("Coor \t Question");
            foreach (int key in list)
            {
                foreach (string word in horizontalAnnex[key])
                {
                    mendatar.Items.Add((key + 1) + "\t" + dic.Dictionary[word]);
                }
            }

            List<int> list1 = new List<int>(verticalAnnex.Keys);
            list1 = list1.OrderBy(r => r).ToList();
            Menurun.Items.Add("Coor \t Question");
            foreach (int key in list1)
            {
                foreach (string word in verticalAnnex[key])
                {

                    Menurun.Items.Add((key+1) + "\t" + dic.Dictionary[word]);
                }
            }

            Console.WriteLine("Jumlah Perulangan = " + ju + " Nilai Fitness = " + usedCount);
            wordCount.Text = "Looping = " + ju + " Fitness Value = " + String.Format("{0:0.00}", usedCount);
            dataGridView1.ColumnCount = this.column;
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView1.ColumnHeadersVisible = false;
            //dataGridView1.RowHeadersVisible = false;
            
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersWidth = 55;

            for (int k = 0; k < this.row; k++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[k].Height = 35;
                ((DataGridViewTextBoxColumn)dataGridView1.Columns[k]).MaxInputLength = 1;
                dataGridView1.Rows[k].HeaderCell.Value = (k + 1).ToString();

            }
            for (int p = 0; p < this.row; p++)
            {
                for (int a = 0; a < this.column; a++)
                {
                    
                    dataGridView1.Columns[a].Width = 50;
                    dataGridView1.Columns[a].HeaderText = (a + 1).ToString();

                    if (grid.getValue(p, a) == ' ')
                    {
                        dataGridView1.Rows[p].Cells[a].ReadOnly = true;
                        dataGridView1.Rows[p].Cells[a].Style.BackColor = Color.Black;
                        dataGridView1.Rows[p].Cells[a].Style.ForeColor = Color.Black;
                        dataGridView1.Rows[p].Cells[a].Style.SelectionBackColor = Color.Black;
                        dataGridView1.Rows[p].Cells[a].Style.SelectionForeColor = Color.Black;
                        dataGridView1[a, p].Value = "0";
                        hitam++;
                    }
                    else
                    {
                        dataGridView1[a, p].Value = "";
                        putih++;
                    }
                        
                }
            }
            Console.WriteLine("hitam : " + hitam + " / Putih : " + putih);
            grid.show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private static void printAnnex(Dictionary<int, List<string>> annex, WordsDic dic)
        {

            List<int> list = new List<int>(annex.Keys);
            list = list.OrderBy(r => r).ToList(); ;

            //foreach (int key in list)
            //{

            //    Console.Write(key + " : ");
                
            //    foreach (string word in annex[key])
            //    {
            //        Console.Write(dic.Dictionary[word] + " | ");
            //    }

            //    Console.WriteLine();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool benar = false;
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    jawabanboard = dataGridView1[j,i].Value.ToString().ToUpper();
                    Console.Write(jawabanboard);
                    if (jawabanboard == "0")
                    {
                        continue;
                    }
                    else if (jawabanboard != Convert.ToString(grid.getValue(i, j)))
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        benar = false;
                    }
                    else if (jawabanboard == "")
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        benar = false;
                    }
                    else if(jawabanboard == Convert.ToString(grid.getValue(i, j)))
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        benar = true;
                    }
                }
                Console.WriteLine();
            }

            if (benar)
            {
                MessageBox.Show("Anda Benar", "Selamat",
                   MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Masih Ada Yang salah", "Warning",
                   MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void Mendatar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
