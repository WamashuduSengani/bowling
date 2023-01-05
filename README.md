# Description 

A console based Bowling Game built using C# and is fully unittested. The game allows the user to input the
number of pins knocked down on the first bowl and also on the second bowl.


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

# How to run for Ubuntu

1. Clone this repository to your machine locally https://github.com/WamashuduSengani/bowling.git

2. cd to the repo you have cloned locally which is named "bowling"

3. Then when you are inside the repo cd into BowlingGame

4. if you are running from a linux machine
   `Install mono-complete. Open the terminal and type:
    sudo apt install mono-complete`

5. Then run `mono Program.exe` then the bowling game will start.

# How to run for MacOs

1. Clone this repository to your machine locally https://github.com/WamashuduSengani/bowling.git

2. cd to the repo you have cloned locally which is named "bowling"

3. Then when you are inside the repo cd into "BowlingGame"

4. Download and install Mono https://www.mono-project.com/download/stable/#download-mac

5. Then in your terminal run this command `mono Program.exe` then bowling game will start
 
# How to run for windows

1. Clone this repository to your machine locally https://github.com/WamashuduSengani/bowling.git

2. Open the repo you have cloned locally which is named "bowling" with Visual Studio 

3. Once you are inside the repo on a folder named `BowlingGame`

4. Click on Program.cs and press run in Visual Studio then Bowling Game will start