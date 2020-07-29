using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace falloutSolver
{
    public partial class Solver : Form
    {
        public List<TextBox> boxes;
        string guess;
        int tick = 0;
        Random rand = new Random();
        public Solver()
        {
            InitializeComponent();
            boxes = new List<TextBox>();
            boxes.Add(word0);
            boxes.Add(word1);
            boxes.Add(word2);
            boxes.Add(word3);
            boxes.Add(word4);
            boxes.Add(word5);
            boxes.Add(word6);
            boxes.Add(word7);
            boxes.Add(word8);
            boxes.Add(word9);
            boxes.Add(word10);
            boxes.Add(word11);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text.ToUpper();
            label1.Text += text + "\n";
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (TextBox textbox in boxes)
            {
                textbox.Text = "";
            }
            guess = "";
            tick = 0;
            guessDisplay.Text = "";
        }

        private void word9_TextChanged(object sender, EventArgs e)
        {

        }

        private void word8_TextChanged(object sender, EventArgs e)
        {

        }

        private void slv_Click(object sender, EventArgs e)
        {
            string[] words = new string[12];
            for (int i = 0; i < 12; i++)
            {
                words[i] = boxes[i].Text.ToUpper();
            }

            if (tick == 0)
            {
                int choice = rand.Next(0, words.Length - 1);
                guessDisplay.Text = words[choice];
                boxes[choice].Text = "";
                guess = words[choice];
            }
            else
            {
             /*
             * properties
             * list of words
             * number of characters in common with the answer
             * word that we guess
             * 
             * go through each word, and see how many matches per word
             * list of possible answers
             * randomly pick an answer
             * suggest an answer
             * remove the suggestion and impossible words
             */
                List<int> answers = new List<int>();
                int c = (int)corrNum.Value;
                //runs through the array of words, find matches by character and determine possible answers
                for (int i = 0; i < words.Length - 1; i++)
                {
                    int matches = 0;
                    //both are arrays to be used in the for loop for taking guesses in one bank, and words into another
                    char[] word1 = guess.ToCharArray(); //turns guess into an array of letters
                    char[] word2 = words[i].ToCharArray(); //turns the current index of words into an array of letters
                    if (word1.Length == word2.Length)
                    {
                        for (int b = 0; b < word1.Length; b++) //looks through each word and picks out characters that match in the array
                        {
                            if (word1[b] == word2[b])
                            {
                                matches++;
                            }
                        }
                        if (c == matches) //determines possible answers
                        {
                            answers.Add(i);
                        }
                        else
                        {
                            boxes[i].Text = "";
                        }
                    }
                }
                int choice = rand.Next(0, answers.Count);
                guessDisplay.Text = words[answers[choice]];
                guess = words[answers[choice]];
                boxes[answers[choice]].Text = "";
            }
            tick++;
        }

        private void Solver_Load(object sender, EventArgs e)
        {

        }

        private void guessDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
