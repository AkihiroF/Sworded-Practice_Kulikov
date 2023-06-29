# **Table of classes**

| Class             | Assignment                                                                                                                                                                                                        | Category           |
|-------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------------|
| BattleRoyaleWalls | Determine which game mode is selected, and if battle royal mode is selected, then gradually reduce the playing area                                                                                               | Map                |
| BoostIndex        | Creates a random booster every n seconds. The countdown starts after raising the booster                                                                                                                          | Map                |
| BoostManager      | 1. Responsible for feedback when a booster is activated in the form of partials.<br/>2. Changes the characteristics depending on the booster.<br/>3. Determines how long the effect of the booster lasts          | Interactive object |
| BotMovement       | 1. Moving a character <br/> 2. Choosing Enemy Behavior   <br/> 3. Moving Enemies<br/> 4. Interaction with interactive objects<br/> 5. Interacting with units and getting damage + feedback                        | Person             |
| CountDownTimer    | 1. Informing the player about the amount of time until the end of the match<br/>2. Stopping the game when time runs out                                                                                           | UI                 |
| DamagableProp     | 1. Getting Damage<br/> 2. Feedback                                                                                                                                                                                | Health           |
| DamageSounder     | Plays a random sound from a list                                                                                                                                                                                  | Audio              |
| DamageTaker       | Spanning text with information about the received damage                                                                                                                                                          | UI                 |
| DamageVignette    | Disables the object on which it is located                                                                                                                                                                        | UI                 |
| GameUI            | 1. Enabling different screens<br/>2.Saving and issuing resources<br/>3.Enabling a certain kind of UI, depending on the game mode                                                                              | UI                 |
| GmgText           | 1. Text output<br/>2.Gradually change the transparency of the text, and remove the object when it reaches zero                                                                                                         | UI                 |
| Lightning         | 1. Dealing damage to a unit on contact<br/>2. Feedback                                                                                                                                                  | Health           |
| LoadingMenu       | 1. Saves the selected game mode<br/>2. Activates the desired download panel depending on the presence of Internet connection<br/>3. Maintains an Internet connection                                    | UI                 |
| Menu              | 1. Loading Skills<br/>2. Generating a player's nickname<br/>3. Saves parameter settings<br/>4. Resets progress or produces maximum resource values<br/> 5. Processing the purchase of skins, weapons, skills | UI                 |
| MenuBGanim        | Responsible for the background animation in the menu                                                                                                                                                                          | UI                 |
| MusicOff          | Loads the sound parameters, and turns it off if it is off in the parameters                                                                                                                                       | Audio              |
| PlayerFollower    | Moves the object to the player's position                                                                                                                                                                               | Person          |
| PlayerIndex       | Used to store some data                                                                                                                                                                        | Person          |
| PlayersList       | Adds players to the player rating                                                                                                                                                                               | UI                 |
| PlayerStats       | 1. Defines bot name<br/>2. Launches sounds and animations<br/>3. Works with health and damage<br/> 4. Slows down time<br/>5. Works with points and character level                                     | Person          |
| PointSpawner      | Creates a prefab at a random point on the map                                                                                                                                                                         | Map              |
| QualSettings      | Disables shadows, if this was specified in the settings                                                                                                                                                                | Map              |
| RotatingShield    | 1. Includes collider<br/>2. Turns the object<br/>3. Teleports the object to the position of another object                                                                                                           | Person          |
| SkillManager      | 1. Enables the selected skill to work <br/>2. Gives the bot a skill under certain conditions                                                                                                                       | Person          |
| SkillsMenu        | Generates a menu of skills and saves the player's selected skin                                                                                                                                                       | UI                 |
| SkinChanger       | Changes the visuals of bots                                                                                                                                                                                             | Person          |
| SmearEffect       | Changing the shader and vector in the material                                                                                                                                                                           | Person          |
| sorttest          | Sorts statistics                                                                                                                                                                                              | UI                 |
| SoundTimeScaler   | Adjusts the pitch of the sound                                                                                                                                                                                           | Audio              |
| SpawningPoint     | Repawns the object at a random location after n times of interaction                                                                                                                                          | Map              |
| SwordCollision    | Responsible for interacting with weapons and creating feedback                                                                                                                                                           | Person          |
| VibroSounder      | Plays a preset sound                                                                                                                                                                                       | Audio              |
| WeaponAssign      | 1. Handing weapons to a bot<br/>2. Attaching Weapons to Limbs                                                                                                                                                        | Person          |
| WorldRandom       | Turns on a random object from the list                                                                                                                                                                                | Карта              |
| HitColor          | Changes the color of partials                                                                                                                                                                                          | Person          |

# **Problems**

1. Variable names
2. Class names
3. Method names
4. Overcrowded classes

# **Refactoring** 

1. BotMovement
2. PlayerStats
3. GameUI