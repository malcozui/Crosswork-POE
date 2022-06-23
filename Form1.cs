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
        char[,] crossword;
        string[] cluesDown;
        string[] cluesAcross;
        int whiteCellCount;

        //Our team consists of Malcom Joe Dos Santos Thonger (ST10074559) and Andre Booysen (ST10094507)
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
         * ✔ double for loop through the TextBoxes and chek against the coresponding character, if !BackColor = Color.Black
         * ✔ if correct Color.LimeGreen
         * ✔ else Color.Red
         * 
         * Optional additions:
         * counter for counter for correct letters.
         * if all letters correct unhide a hidden victory msg
         * ✔ play again button
         * 
         */
        public CrosswordForm()
        {
            InitializeComponent();
        }

        private void CrosswordForm_Load(object sender, EventArgs e)
        {
            winLbl.Visible = false;

            textBoxes = new TextBox[,]
            {
                { txtCell00, txtCell01, txtCell02, txtCell03, txtCell04 },
                { txtCell10, txtCell11, txtCell12, txtCell13, txtCell14 },
                { txtCell20, txtCell21, txtCell22, txtCell23, txtCell24 },
                { txtCell30, txtCell31, txtCell32, txtCell33, txtCell34 },
                { txtCell40, txtCell41, txtCell42, txtCell43, txtCell44 }
            };
            // ඞ is a garbage char, its never intended to be typed, but rather denotes a black tile that should not be typed in.
            crossword = new char[,]
            {
                { 'U', 'ඞ', 'ඞ', 'L', 'ඞ' },
                { 'S', 'O', 'N', 'I', 'C' },
                { 'ඞ', 'D', 'ඞ', 'G', 'O' },
                { 'N', 'I', 'G', 'H', 'T' },
                { 'O', 'N', 'ඞ', 'T', 'ඞ' }
            };
            cluesDown = new string[]
            {
                "Another word for \"we\"",  
                "To disagree",
                "Father of the Norse god Thor ",
                "Is necessary to see in darkness",
                "Where babies sleep"
            };
            cluesAcross = new string[]
            {
                "A popular game character created by SEGA",
                "The opposite of stay",
                "The time of day when you sleep",
                "The opposite of \"off\""
            };

            hintTextBox.Text = "Vertical clues:";
            hintTextBox.Text += Environment.NewLine;
            for (int i = 0; i < cluesDown.Length; i++)
            {
                hintTextBox.Text += $"{i + 1}. {cluesDown[i]}{Environment.NewLine}";
            }
            hintTextBox.Text += Environment.NewLine;
            hintTextBox.Text += "Horizontal clues:";
            hintTextBox.Text += Environment.NewLine;
            for (int i = 0; i < cluesAcross.Length; i++)
            {
                hintTextBox.Text += $"{i + 1}. {cluesAcross[i]}{Environment.NewLine}";
            }

            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    if (crossword[i, j] == 'ඞ')
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
                        whiteCellCount++;
                    }
                }
            }

        }

        private void hintButton_Click(object sender, EventArgs e)
        {
            ShowHint();
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            int correctCells = 0;
            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    //checks if the cell's correct letter is the garbage char or if it is empty, skips the selected cell when true.
                    if (crossword[i, j] == 'ඞ' || textBoxes[i, j].Text.Length == 0) continue;

                    if (textBoxes[i, j].Text[0] == crossword[i, j])
                    {
                        ChangeTextBoxStatus(textBoxes[i, j], green);
                        correctCells++;
                    }
                    else
                    {
                        ChangeTextBoxStatus(textBoxes[i, j], red);
                    }
                }
            }
            if (correctCells == whiteCellCount)
            {
                winLbl.Visible = true;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    textBoxes[i, j].Text = "";
                }
            }
            CrosswordForm_Load(sender, e);
        }

        private void ChangeTextBoxStatus(TextBox tb, Color col)
        {
            tb.BackColor = col;
        }

        private void ShowHint()
        {
            Random random = new Random();
            int randomX = 0;
            int randomY = 0;
            bool whiteCellFound = false;

            for (int i = 0; i < textBoxes.GetLength(0); i++)
            {
                for (int j = 0; j < textBoxes.GetLength(1); j++)
                {
                    if (textBoxes[i, j].BackColor == white)
                    {
                        whiteCellFound = true;
                    }
                }
            }



        }
    }
}
