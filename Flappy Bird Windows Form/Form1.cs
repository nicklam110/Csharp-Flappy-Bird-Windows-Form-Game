using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
    public partial class Form1 : Form
    {


        int pipeSpeed = 5; //speed that the pipes move across the screen
        int gravity = 5; //how fast the bird moves up and down
        int score = 0; //score of the game based on how many pipes the player passes through
        bool gameover = false; //sets the gameover boolean to start at false
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {

            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;
            scoreText2.Text = "Score: " + score;


            //Whenever the pipes move past the screen they reset and come around again

            if(pipeBottom.Left < -150)
            {
                pipeBottom.Left = 400;
                score++;
            }
            if(pipeTop.Left < -180)
            {
                pipeTop.Left = 550;
                score++;
            }



            //Whenever the bird touches the pipes or the ground the game ends 

            if(flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                    flappyBird.Bounds.IntersectsWith(ground.Bounds)
                    )
            {
                endGame();
            }


            //Difficulty Increase as the player attains a better score

            if(score == 0)
            {
                pipeSpeed = 5;
            }

            if(score > 5)
            {
                pipeSpeed = 15; 
            }

            if(score > 10)
            {
                pipeSpeed = 25;
            }

            if(score > 20)
            {
                pipeSpeed = 35;
            }

            if(score > 30)
            {
                pipeSpeed = 45;
            }

            if(score > 40)
            {
                pipeSpeed = 55;
            }



            //Prevents the player from cheating by moving the bird above the pipes at the top of the screen

            if(flappyBird.Top < -25)
            {
                endGame();
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            //Whenever the spacebar is pressed the bird moves up 
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }


        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {

            //Whenever the spacebar is not held or pressed, the bird falls down
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }

            //When the R key is pressed when the "endGame()" method is called, the game will restart by calling the "startGame()" method
            if (e.KeyCode == Keys.R && gameover == true)
            {
                startGame();
            }

        }

        //Method to start the game, sets all boundaries in their default positions and resets the score
        private void startGame()
        {
            score = 0;
            scoreText.SetBounds(8, 378, 105, 19);
            flappyBird.SetBounds(67, 141, 45, 38);
            pipeTop.SetBounds(301, 0, 50, 122);
            pipeBottom.SetBounds(253, 228, 44, 119);
            gameTimer.Start();
            gameover = false;
        }


        //Function that stops the game timer and displays a game over text on the screen
        private void endGame()
        { 
            gameTimer.Stop();
            gameover = true;
            scoreText.Top = 0;
            scoreText2.Text = " Game Over, Press R to Try Again";
        }

        private void pipeBottom_Click(object sender, EventArgs e)
        {

        }

        private void flappyBird_Click(object sender, EventArgs e)
        {

        }
    }
}
