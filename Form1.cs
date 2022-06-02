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
    /* Set up:
     * 2D textbox array of the 25 textboxes
     * [no boolean array] check the colour in double for loop
     * parrelel char array of correct letters
     * throw away symbol ඞ
     * update all the colours using the function they asked for in the POE (ChangeTextBoxStatus())
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
    public partial class CrosswordForm : Form
    {
        public CrosswordForm()
        {
            InitializeComponent();
        }
    }
}
