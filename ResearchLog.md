# Research Log

[12/8/2022]
-------------
* 9:05AM - Added BattleScene UI mockup and started playing in objects into view

[MISSING LOGS]
* Added: Test Scene for new state script
* Researched: State Machine for BattleCore Extension (didnt apply until 12/19)

[12/17/2022]
-------------
[UI Development]
* 8AM - Looking into previous final fantasy games UI and begining to acquire assets.
* 9AM - Final Fantasy assets found and in GIMP trying to upscale/ re-use them
* 10AM - Did not work propely so had to make UI from scratch
* 11AM - Added UI for BattleUI used in TestScene
* 1PM - Buttons fully functioning within UI.
* 2PM - Error with Deprecated Unity UI and BattleCore base script
* 3PM - TextMeshPro Documentation Research

[12/18/2022]
-------------
[Sound Sourcing and Scripting]
* 8AM - Sourcing Final Fantasy Music through hardware emulation
* 9AM - Compiling Music to process in DAW
* 10AM - In DAW adding limiters and minor 
* 5PM - Exported Audio Files into .WAV for Unity importing
* 6PM - Imported Dancing Mad - P1 & P2 as assets and modified Test Scene
* 7PM - Researching WWise and Adaptive audio solutions
* 8PM - Researching Unity Sound documentation
* 10PM - Applied music to Test Scene to test audio track. Success.
* 11PM-  Crippling error with audio integration in BattleCore

[12/19/2022]
-------------
[Battle Core Updates]
* 12am - Re-Watching "How to code a simple state machine" to build off of BattleCore
* 1am - Applying State Machine to BattleCore and testing for compile errors
* 2am - Compile errors, commented out code to work during class today.
* 5am - Uploading research log (cannot upload all as some scripts and assets as they are blocked out on gitignore due to size issues.)

[12/20/2022]
-------------
[BattleCore Finished]
* 8AM - Began rewriting parts of BattleCore to check for any errors and begin start of Spells, commented out to not have compile errors.
* 9AM - Attack and Heal functions fully working - bug with attack and heal actions (can spam click and break the game, will need to fix)
* 10AM - Changing attack and heal values on both Heal and Attack to see what would be a reasonable ammount for length of gameplay
* 11AM - Fixed error when applying animation to ToDoList and it changing its position on the world level rather than model level.
* 1PM - Rebuilt UI to have "ff7-esque" theme to it.
* 2PM - Added new state "Player Transition" to later repurpose animations and to fix overall buf with multi presses of action button.
* 3PM - ReLengthen'd time between attacks to it gives you time to read attacks and whatever the UI will say in the dialogue section.
* 4PM - Began adding animation to Player, still WIP.
* 5PM-  Added various quips to player Healing in dialogue menu.

[12/21/2022]
-------------
[AI Day and Audio Implementation]
* 8AM - ToDoList AI whiteboarding session.
* 9AM - Decided to add AI to BattleSystem as thats where the attack originate in scripts. Began adding If Else for ToDoList Heal / Attack.
* 10AM - Added Run button to UI for funny quip.
* 11AM - Fixed bug with healing overhealing to values above.
* 1PM - Added fix for Fighter status to stay consistent between sessions, would be ok if it was multiple phases, Removed regardless and added BattleReset function.
* 2PM - Added alt attack quotes for ToDoList and Player as a "soft" AI.
* 3PM - Adding Audio Handler so separate script can handle audio in scenes.
* 4PM - Removed FF6 Music and replaced with one track "Birth of a God" from FF7 after compiling it in DAW.
* 5PM - Made song loopable in DAW, added to game to properly play. Need to add transitioner.

[12/22/2022]
-------------
[PRESENTATION DAY AND LAST MINUTE GRIND]
* 2AM -Began adding Engrage Mechanic to enemy and player.
* 3AM - Added debuff to FireSpell that cuts attack damage in half
* 4AM - Added Fireball to ToDoList AI so now they can fireball too.
* 5AM - Implemented Debuff status to Player as now they can be on fire too
* 6AM - Adding BattleTransitioner so i can use one script to handle switching scenes and battle transitions.
* 7AM - Finishing enrage. ToDeusList will nuke for damage and Player will fully heal, including debuff removal.
* 8AM - Added ways to remove debuff for both Player and Enemy in various ways. (including heals / Enrage bonus)
* 9AM - Added BattleTransitioner funcion to work with cubes so the opening is animated.
* 10AM - Trying to fix bug with closing cubes. Needs more work, will move onto building project.
* 11AM - Exporting to .exe application for Presentation
* 12PM - Errors with UI sizing and rebuilding project so it looks functional. :')
* 1:30PM - PRESENTATION TIME
[THANK YOU EVERYONE](https://youtu.be/Y6ljFaKRTrI)

[12/23/2022]
-------------
[Clean Up and Submission]
* 8AM - Explorting to WebGL. Series of bugs found and errors with UI implementation.
* 9AM - Uploaded to Itch.IO for testing purposed, still unfunctional.
* 10AM - Fixed error with cubes not closing correctly after battle is finished.
* 11AM - BattleTransition will now lead to Title Screen after battle completion and cubes are now successfully closed.
* 12PM - Began implementing audio fadeout when battle is completed.
* 1PM - Submitted to School with future plans.

[12/26/2022]
-------------
[Credits WIP]
* 8AM - Working on credits with new Credits scene.
* 9AM - Using previous scripts to create environment. Creating a png for thank you picture.
* 10AM - Choosing music is hard, adding various music tracks.

[12/28/2022]
-------------
[Slight bug fixes]
* 8AM - Fixed error with ToDoListWalkCycle not in legacy mode. By removing it entirely as its unused.
* 9AM - Erorr with audio handler not changing battle music not working. Kefka laugh will not randomly play anymore after removing part of ToDoList AI.
* 10AM - Fixed error with Engrage and Mana not resetting on session restart.
* 11AM - fixed UI for pc port, webGL still non functional.

[1/1/2023]
-------------
* [SpellBook Update started]
* 8AM - Added Spell script to hold series of information for spells.
* 9AM - Decided to go with adding spellbook script that will hold spell scripts that will be implemented into player so the player can choose multiple spells on the fly.
* 10AM - Cripling error with buttons, cannot activate anymore.
* 11AM - Fixed after searching for answers online, then only found out that i accidentally turned raycasting off.
* 12PM - (Printed ToDeusList shirts) not a real update.

[To-Do-List]
-------------
* -Animation OverHaul and Scripted Actions
* -To Do Phase 2 Model
* -Spell Book Update
* -AI tied to separate script for enemy actions instead of if else nest in EnemyTurn().
* -Credits Scene

[Main Issues with Project]
-------------
* -Importing and displaying various ammounts of spells based on chosen answers. (SpellBook Update)
* -Assets not uploading to GitHub so only major commit updates will be sent. Hence the research log.
* -Rebuilding some parts of BattleCore to Incorporate AI for enemies and adding spells properly without an if else nest on the system itself.

