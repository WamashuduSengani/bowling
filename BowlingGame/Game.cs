using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {

        //Number of Rolls
        private int[] rolls = new int[21];

        int currentRoll = 0;
        private bool isSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        }

        private bool isStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public void Roll(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                rolls[currentRoll++] = pins[i];
            }
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (isSpare(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 2];
                    frameIndex += 2;
                }
                else if (isStrike(frameIndex))
                {
                    score += 10 + rolls[frameIndex + 1] + rolls[frameIndex + 2];
                    frameIndex++;
                }
                else
                {
                    score += rolls[frameIndex] + rolls[frameIndex + 1];
                    frameIndex += 2;
                }

            }

            return score;
        }



        public void simulatePlayer()
        {

            int frameScore = 0,
                prevFrame = 0,
                prevFrameTwo = 0,
                bowlOneInput,
                bowlTwoInput = 0,
                frame = 1,
                totalScore = 0,
                extraFrame;

            bool strike = false,
                strikeTwo = false,
                spare = false;


            String bow1OneScore = "",
                   finalScore = "",
                   bowlTwoScore = "",
                   previousFrameTwo = "",
                   previousFrameThree = "",
                   frameNumber = "";


            for (; frame <= 10; frame++)
            {
                Console.WriteLine("Please enter your bowling scores for Frame {0}:", frame);

                //BowlOne 
                do
                {
                    Console.Write("Bowl 1:");
                    bowlOneInput = int.Parse(Console.ReadLine());
                } while (bowlOneInput > 10 || bowlOneInput < 0); //checks for valid bowlOne input

                //Add extra points if previous frame is spare
                if (spare == true)
                {
                    prevFrame = 10 + bowlOneInput;
                    spare = false;
                    totalScore = prevFrame + totalScore;
                    finalScore = Game.finalScore(totalScore, finalScore);

                }

                //Second Strike with Bowl one iput being a 10
                if (strikeTwo == true && bowlOneInput == 10)
                {
                    prevFrameTwo = 30;
                    totalScore = prevFrameTwo + totalScore;
                    finalScore = Game.finalScore(totalScore, finalScore);
                }
                //Second Strike with Bowl one iput being not being a 10
                if (strikeTwo == true && bowlOneInput != 10)
                {
                    strikeTwo = false;
                    prevFrameTwo = 10 + 10 + bowlOneInput;
                    totalScore = prevFrameTwo + totalScore;
                    finalScore = Game.finalScore(totalScore, finalScore);
                }

                if (strike == true && bowlOneInput == 10)
                {
                    strikeTwo = true;
                    prevFrameTwo = 20;
                }

                //Ensure no strike (10/X) on first bowl
                if (bowlOneInput < 10)
                {
                    //BowlTwo
                    do
                    {
                        Console.Write("Bowl 2:");
                        bowlTwoInput = int.Parse(Console.ReadLine());
                    } while (bowlTwoInput > (10 - bowlOneInput) || bowlTwoInput < 0);

                    if (bowlOneInput + bowlTwoInput == 10)
                    {
                        spare = true;
                        bow1OneScore += "  " + bowlOneInput;
                        bowlTwoScore += "  / ";
                    }

                    if (strikeTwo == true && frame == 10)
                    {
                        prevFrameTwo = 10 + 10 + bowlTwoInput;
                        totalScore = prevFrameTwo + totalScore;
                        finalScore = Game.finalScore(totalScore, finalScore);
                        strikeTwo = false;
                    }

                    if (strike == true && bowlOneInput != 10)
                    {
                        strike = false;
                        prevFrame = 10 + bowlOneInput + bowlTwoInput;
                        totalScore = totalScore + prevFrame;
                        finalScore = Game.finalScore(totalScore, finalScore);
                    }

                    if (spare != true && strike != true && strikeTwo != true)
                    {
                        frameScore = bowlOneInput + bowlTwoInput;
                        totalScore = totalScore + frameScore;
                        finalScore = Game.finalScore(totalScore, finalScore);
                        if (frame != 10)
                        {
                            bow1OneScore += "  " + bowlOneInput;
                            bowlTwoScore += "  " + bowlTwoInput;
                        }
                        else
                        {
                            bow1OneScore += "  " + bowlOneInput;
                            bowlTwoScore += "  " + bowlTwoInput;
                        }

                    }
                }
                else
                {
                    strike = true;
                    prevFrame = 10;
                    if (frame != 10)
                    {
                        bow1OneScore += "   X ";
                        bowlTwoScore += "   ";
                    }

                }
                if (frame == 10 && strike == true)
                {
                    do
                        bowlTwoInput = int.Parse(Console.ReadLine());
                    while (bowlTwoInput < 0 || bowlTwoInput > 10);

                    if (strikeTwo == true)
                    {
                        prevFrameTwo = 10 + 10 + bowlTwoInput;
                        totalScore = prevFrameTwo + totalScore;
                        finalScore = Game.finalScore(totalScore, finalScore);
                        strikeTwo = false;
                    }
                }

                if (frame == 10 && (spare == true || strike == true))
                {
                    do
                        extraFrame = int.Parse(Console.ReadLine());
                    while (extraFrame < 0 || extraFrame > 10);
                    if (strike == true)
                    {
                        prevFrame = 10 + bowlTwoInput + extraFrame;
                        totalScore = totalScore + prevFrame;
                        finalScore = Game.finalScore(totalScore, finalScore);
                        if (bowlTwoInput == 10)
                            previousFrameTwo = "  X ";
                        else
                            previousFrameTwo += bowlTwoInput;
                        if (extraFrame == 10)
                            previousFrameThree = "  X ";
                        else
                            previousFrameThree += extraFrame;
                        bow1OneScore += "  X " + previousFrameTwo + previousFrameThree;
                        bowlTwoScore += "   ";

                    }
                    else
                    {
                        if (extraFrame == 10)
                            previousFrameThree = "  X ";
                        else
                            previousFrameThree += extraFrame;
                        if (bowlTwoInput + extraFrame == 10 && extraFrame != 10)
                            previousFrameThree = " / ";
                        else
                            previousFrameThree += extraFrame;
                        totalScore = totalScore + 10 + extraFrame;
                        finalScore = Game.finalScore(totalScore, finalScore);
                        bow1OneScore += bowlOneInput + " / ";
                        bowlTwoScore += previousFrameThree;

                    }
                }
                frameNumber += frame + "    ";

            }
            Console.WriteLine("\n\t When scoring 'X' indicates a strike(10) and '/' indicates a spare!");
            Console.WriteLine("\n\t Frame     " + frameNumber);
            Console.WriteLine("\n\t Bowl 1  " + bow1OneScore);
            Console.WriteLine("\n\t Bowl 2  " + bowlTwoScore);
            Console.WriteLine("\n\t Score     " + finalScore);
            Console.ReadLine();
        }


        static int length(int intg)
        {
            int length = 1;
            if (intg / 10 > 0)
                length = 2;
            if (intg / 100 > 0)
                length = 3;
            return length;
        }

        //scores space indenting
        static String finalScore(int total, String scores)
        {
            if (length(total) == 1)
                scores += total + "   ";
            else if (length(total) == 2)
                scores += total + "   ";
            if (length(total) == 3)
                scores += total + "  ";
            return scores;
        }


    }
}
