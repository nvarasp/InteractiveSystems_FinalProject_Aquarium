# FINAL PROJECT: INTERACTIVE AQUARIUM
## UPF Interactive Systems Course 2019/2020

#### INTRODUCTION
The idea of this project is to create a virtual aquarium where the user interacts with the fishes in different ways.

The system goal is that people, specially children, learn and get more familiar with the sea ecosystem in a interactive and entertained way. So it can be used in any museum related to the sea, aquarium or sea lovers.

So we have developed an Aquarium where you are able to interact with fishes in different ways.


You need to run this project in Unity. We have used version *2019.3.7f1*.
#### SCENE CONTEXT
The introduction scene shows the instructions to know what each movement does. 
This scene has three buttons:

  -PLAY: it will send you to the game scene. You can go back to the intro screen by clicking scape.
  
  -CATALOG OF FISHES: in this screen you will learn information about the fishes. You can go back to the intro screen by clicking scape.
  
  -QUIT: this will close the application.
  
#### GAME SCENE
REPRESENTATIONS

In the screen you will see two red cubes that represent the wrists, two white cubes that represent the left and right side of the hip, and two black cubes that represent the knees. The nose is represented with a smiling emoji.

WHAT TO DO?
 
-When you bend down =  the *y position* of your nose is below *-100*:
the fishes will start to appear. There are two possible spawns: **Big Yellow Fish** and **Little White Fish**, which will appear randomly with the same probability.

-The yellow big fish will move randomly around the aquarium. If you touch it with both hands, its size decreases (for 2 seconds).

-The striped fish will move randomly around the aquarium. If you try to touch it with your wrists, it will escape from you speeding up.

-A shoal of fishes appears when you go to the left side with your nose, and disappear by going to the right. This shoal will follow the movement of your nose.

-Shaking the hip from side to side makes bubbles appear during 10 seconds, with a sound included.

-If you jump (one knee above y=-100 ) a shark goes through the screen with a scaring sound and all the fishes fall down and get destroyed. 



#### RESOURCES USED
PoseNet to OSC adaptation
https://github.com/tommymitch/posenetosc 

extOSC unity package
https://assetstore.unity.com/packages/tools/input-management/extosc-open-sound-control-72005

Follow the instructions to run PoseNet OSC and then run the Unity project

