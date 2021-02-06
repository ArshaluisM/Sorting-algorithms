using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sort
{
    public partial class Form1 : Form
    {
        int[] A = new int[10];
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
            for (int i = 1; i<=10; i++)
            {
                textBox1.Text += " " + i;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            textBox1.Text = "";
            for (int i = 0; i < 10; i++)
            {
                A[i] = r.Next(1, 10);
                textBox1.Text += " "+ A[i];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QuickSort(A, 0, A.Length-1);
            textBox2.Text = "";
            for (int i = 0; i < A.Length; i++)
            {
                textBox2.Text += " " + A[i];
            }
        }
        public void QuickSort(int[] A, int l, int r)
        {
            if (l >= r)
            {
                return;
            }
            int m = Partition(A, l, r);
            QuickSort(A, l, m - 1);
            QuickSort(A, m + 1, r);
        }
        public int Partition(int[] A, int l, int r)
        {
            int i = l - 1;
            for(int j = l; j<=r; j++)
            {
                if (A[j] <= A[r])
                {
                    Swap(A, j, i + 1);
                    i++;
                }
            }
            return i;
        }

        public void Swap(int[] A, int i, int j)
        {
            int k = A[i];
            A[i] = A[j];
            A[j] = k;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SelectionSort(A);
            textBox4.Text = "";
            for (int i = 0; i < A.Length; i++)
            {
                textBox4.Text += " " + A[i];
            }
        }
        public void SelectionSort(int[] A)
        {
            int m = 0;
            int l = A.Length;
            for(int i = 0; i < l - 1; i++)
            {
                m = i;
                for(int j = i + 1; j < l; j++)
                {
                    if (A[m] > A[j])
                    {
                        m = j;
                    }
                }
                if (m != i)
                {
                    Swap(A, m, i);
                }
            }
        }

        public int[] MergeSort(int[] A)
        {
            if (A.Length == 1)
            {
                return A;
            }
            int m = A.Length / 2;
            return Merge(MergeSort(A.Take(m).ToArray()), MergeSort(A.Skip(m).ToArray()));
        }
        public int[] Merge(int[] M1, int[] M2)
        {
            int k1 = 0, k2 = 0;
            int[] M = new int[M1.Length + M2.Length];
            for(int i =0; i < M.Length; i++)
            {
                if(k1< M1.Length && k2 < M2.Length)
                {
                    if (M1[k2] > M2[k2])
                    {
                        M[i] = M2[k2];
                        k2++;
                    }
                    else
                    {
                        M[i] = M1[k1];
                        k1++;
                    }
                }
                else
                {
                    if (k2 < M2.Length)
                    {
                        M[i] = M2[k2];
                        k2++;
                    }
                    else
                    {
                        M[i] = M1[k1];
                        k1++;
                    }
                }
            }
            return M;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            int[] M = MergeSort(A);
            for (int i = 0; i < M.Length; i++)
            {
                textBox3.Text += " " + M[i];
            }
        }
    }
}
