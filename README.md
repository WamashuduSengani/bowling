# Bowling rules
The game consists of 10 frames. In each frame the player has two rolls to knock
down 10 pins. The score for the frame is the total number of pins knocked down,
plus bonuses for strikes and spares.

A spare is when the player knocks down all 10 pins in two rolls. The bonus for that
frame is the number of pins knocked down by the next roll.
A strike is when the player knocks down all 10 pins on his first roll. The frame is
then completed with a single roll. The bonus for that frame is the value of the
next two rolls.

In the tenth frame a player who rolls a spare or strike is allowed to roll the extra
balls to complete the frame. However no more than three balls can be rolled in
tenth frame.

#How to run for Ubuntu

1.Clone this repository to your machine locally https://github.com/WamashuduSengani/bowling.git

2. cd to the repo you have cloned locally

3. cd into BowlingGame

4. if you are running from a linux machine
   `Install mono-complete. In all currently supported versions of Ubuntu open the terminal and type:
    sudo apt install mono-complete`
    
5.Then once installation is complete run this command
   `mcs -out:Program.exe Programe.cs`
   
6. Then run `mono Program.exe`

#How to run for Windows

1.Clone this repository to your machine locally https://github.com/WamashuduSengani/bowling.git

2. cd to the repo you have cloned locally

3. cd into BowlingGame

4. 
