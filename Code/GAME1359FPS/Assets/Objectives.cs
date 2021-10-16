/* 

[ASSIGNMENT]
Your assignment for this week and next week is to build from scratch a simple First Person Shooter (FPS) game,
where the goal will be to shoot several different moving targets in a level. Your game will need to include
specific features listed below, which are broken down into several categories:

[PLAYER]
Your player should be controlled with WASD to strafe forward/back/left/right, and Spacebar to jump.
You should be able to look/aim with the mouse. Pressing the left mouse button should allow you to
shoot as long as you have ammo. Shooting should of course deplete the player's ammo.
The player should also have a variable to keep track of health.

[TARGETS]
Your scene/level should include at least 3 different moving targets for the player to shoot.
When shot, the targets should be destroyed. Once all the targets have been destroyed, the player has completed the level.

At least one of these targets should use animation to move, and at least one should use lerping/nodes.
Both of these are demonstrated in this week's videos!

[PICKUPS]
Include at least 1 instance of a pickup that refills the player's ammo somewhere in the level.

[HAZARDS]
Include at least 3 instances of an object in the level that will damage the player if
they are hit (make sure these are distinct from the targets and pickups).
You also need to include a Kill Zone/Line in case the player goes out of bounds

[LEVELS]
Include at least 3 scenes - a title screen/main menu, at least one level that demonstrates
the features of this assignment, and a game over/death scene for when the player dies or is victorious.
You may add additional levels/scenes if you'd like.

[UI]
The player's health and ammo should be visible to them, either with a bar or simply onscreen text.
The aforementioned title screen should include buttons to start the game and end the game, and
the game over scene should allow players to return to the title screen.

[SUBMISSION]
For this assignment, you'll not only submit your code using GitHub, but you'll also create and submit
a build of your game. I'll be demonstrating how to do this next week!
 
[HINTS]
-For shooting, you could instantiate a "bullet", or even use a raycast.
There's no right/wrong way to do this as long as it works :P

-The video demonstrates how to rotate the camera around the player, as well as how to look up/down, in third-person.
Consider what changes you might need to make so that the controls and camera feel natural in first-person.

-You don't have to be an artist or use high-end assets to make different objects look distinct.
Simply changing the color or basic shape can be enough!

[EXTRA FUN]
-This week's videos show a couple of different ways to add moving objects.
Perhaps you could use one of these techniques to make a moving platform? Or a door?

-If you make the moving targets shoot back at you, you would essentially have very simple enemies to fight..

 */
