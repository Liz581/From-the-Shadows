Overview: From The Shadows is a game where the player takes control of a shinobi on a revenge mission. When infiltrating, the player must maintain stealth but can use the shadows to their advantage. By submerging themselves into the shadows the player can move around without being seen however they must stay clear of light sources otherwise you will be thrown out of the shadows. The game is single player as multiplayer would make the game trivial. The target audience are for people that enjoy stealth games.

Story: As the son of the current shogun in Japan you have no fears of the current succession. One day however the general of Japan’s strongest samurai army kills your father and usurps the empire as shogun. As you begin to be filled with rage, you plot your vengeance to assassinate the usurper and take back what is yours by blood. What your enemies don’t know is that you are one of japan’s most elite shinobi and have been trained in the ancient ways.

Objective: The main objective is to infiltrate the shogun’s castle and assassinate him without being caught. As he has no heirs, the empire of Japan’s succession reverts back to you. While infiltrating you must not be caught otherwise the Onryo Guard, the shogun’s most elite warriors, will try and stop you before you can reach your target. You must use the shadows to maintain your stealth, but fear not if you do get caught or get thrown out of your shadow walk you do have ways to cause diversions and take out any problematic enemies.

Our demos are staged primarily in a small village at night. This is the best time for assassins, like our character, to carry out their missions so we felt a dim setting would add to the atmosphere. We used a big level design to give the player a chance to be creative on how to get around the guards in the village. 

We use lights attached to paper lanterns throughout the village to see.
We have fire particle effects in braziers to act as spotlights to know where to head for the objective.
Ethan wrote a waypoint script to allow for guards to follow set paths using navmeshes, and a controller for the guards to follow the waypoints moving over walkable terrain.
Jamil wrote the Mecanim for the walking guard that would be in the village and the Mecanim for the idle guards in the village. 
Lisset wrote the Mecanim that would be for the player when they move their character.

UI Design Improvements:
Lisset:
The health and mana bar in our canvas for the player were not usable for the player. In order to fix it we made our bar be 100/100 and would subtract 25 from the bar after each hit in order to give our player 4 lives essentially. This is a clarity principle.
The controls for our player are not visible for the player to see. We plan on fixing this by making a pause screen that will show you what the controls of the game are. This is a learnability principle.
Since our game is about exploring there isn’t any marker for where the player should go to continue the story. We made a few too many torches paths so we are working on creating a navigation system for the player so that they know which way to go. This is a Minimizing Error Possibilities principle.
Jamil:
Sounds would either be too loud or not heard at all so adjusted to linear rather than logarithmic so that it would be heard a set distance from the center of the sphere. This is a clarity Principle
Animations are still wonky trying to better them with more transitions in the FSM. This is minimizing the error principle.
Working on adding Kill animations and others to add the core gameplay loop.
Ethan:
The patrolling guards would still be in their walk animation even when stationary/turning around making it look weird. To be changed so they are in an idle animation when not moving. This is a clarity principle.
Objects that can be picked up by the player will be highlighted to stand out from their environment to signify to the player that it can be picked up, and isn’t just part of the environment. This is a clarity principle.
Currently the guard will clip into the player when chasing them, the stopping distance will be modified to create a more realistic result of the guard catching the player. This is a minimizing error possibilities principle as if the guard is clipping the player it will result in more health being taken from the player than should be.


Sounds Designed:
Background Music (This one was created to help set the scene as you start playing. The soundtrack was the hardest to settle on, but we went with a chill japanese-esk track that loops. Keeps a pretty relaxed yet tense vibe.  The soundtrack will change to more intense, edge of your seat, music when facing the boss of the game however, conveying to the player they aren’t coming upon just any ordinary enemy.)
Footsteps Sound (Created to be similar as if you are actually walking. Current sound is footsteps on grass since most of our plain is grass. )
Torches Burning (Created for the player to be immersed in the scene. Since the game takes place at night, torches are used as the main lighting source. Adding sound to them makes the world feel much more alive.)
Townspeople chatting (Created for the player to be immersed in the scene)
Many backing tracks were rejected due to being too “uplifting”, not fitting the proper vibe of the game.

Shader Design:
The first shader we added was wind. This was to recreate the effects of the night and how wind is easier to notice at night.
The second shader is water. The water before looked very matte and flat which is not like water at all so in order to give it more character the shader should be added. The shader gave us issues so currently it has yet to be in place but after some research we’re going to give it another shot with the same packages we wanted to use at first.
The third shader is …
