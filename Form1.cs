using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrosswordPOE_Team
{
    public partial class CrosswordForm : Form
    {
        TextBox[,] textBoxes;
        char[,] correctLettersArr;

        Color black = Color.Black;
        Color white = Color.White;
        Color green = Color.LimeGreen;
        Color red = Color.Red;

        // Reminder: comment what you did!!!

        /* Set up:
         * ✔ 2D textbox array of the 25 textboxes
         * [no boolean array] check the colour in double for loop
         * ✔ parrelel char array of correct letters
         * ✔ throw away symbol ඞ
         * ✔ update all the colours using the function they asked for in the POE (ChangeTextBoxStatus())
         * 
         * Show hint BTN:
         * loop through the 2d TextBox array
         * check if !BackColor = Color.Black == valid spot for hint
         * make selected TextBox Black, and the ForeColor = Color.White
         * 
         * Check Guess BTN:
         * double for loop through the TextBoxes and chek against the coresponding character, if !BackColor = Color.Black
         * if correct Color.LimeGreen
         * else Color.Red
         * 
         * Optional additions:
         * counter for counter for correct letters.
         * if all letters correct unhide a hidden victory msg
         * play again button
         * 
         */
        public CrosswordForm()
        {
            InitializeComponent();
        }

        private void CrosswordForm_Load(object sender, EventArgs e)
        {
            textBoxes = new TextBox[,]
            {
                { tile00, tile01, tile02, tile03, tile04 },
                { tile10, tile11, tile12, tile13, tile14 },
                { tile20, tile21, tile22, tile23, tile24 },
                { tile30, tile31, tile32, tile33, tile34 },
                { tile40, tile41, tile42, tile43, tile44 }
            };
            // ඞ is a garbage char, its never intended to be typed, but rather denotes a black tile that should not be typed in.
            correctLettersArr = new char[,]
            {
                { 'ඞ', 'ඞ', 'ඞ', 'ඞ', 'ඞ' },
                { 'ඞ', 'ඞ', 'ඞ', 'ඞ', 'ඞ' },
                { 'ඞ', 'ඞ', 'ඞ', 'ඞ', 'ඞ' },
                { 'ඞ', 'ඞ', 'ඞ', 'ඞ', 'ඞ' },
                { 'ඞ', 'ඞ', 'ඞ', 'ඞ', 'ඞ' }
            };

            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    if (correctLettersArr[i, j] == 'ඞ')
                    {
                        //sets all the tiles black that should be.
                        ChangeTextBoxStatus(textBoxes[i, j], black);

                        //makes it so that the player cannot type in the textbox once it is black.
                        textBoxes[i, j].ReadOnly = true;
                    }
                    else
                    {
                        //sets all the tiles white that should be.
                        ChangeTextBoxStatus(textBoxes[i, j], white);

                        //makes it so that the player can type in the white tiles
                        textBoxes[i, j].ReadOnly = false;
                    }
                }
            }

        }

        private void hintButton_Click(object sender, EventArgs e)
        {

        }

        private void guessButton_Click(object sender, EventArgs e)
        {

        }
        private void resetButton_Click(object sender, EventArgs e)
        {

        }

        private void ChangeTextBoxStatus(TextBox tb, Color col)
        {
            tb.BackColor = col;
        }
    }
}
