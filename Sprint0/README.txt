

Controls:

W/Up/Space			->		Jump
D/Right				->		Move Mario right
A/Left				->		Move Mario Left
S/Down				->		Crouch
E/ B (Gamepad)		->		Throw Fireball in fire mario / Run
Q					->		Quit
R/Start				->		Reset Sprites (DOES NOT RESET LEVEL/GAME)
P					->		Pause
Esc					->		Password Entry Screen Toggle
Enter				->		Confirm Password
Backspace/Delete	->		delete characters in password


Notes:

 - > First pipe to the right of mario is the warp pipe

 - > Any Code in the folder OLD is outside of the project and not intended to be compiled

 - > According to our research, small mario grabbing a fire flower produces large mario, not fire mario

 - > Three warnings are currently being surpressed, one in the Level loader for cyclomatic complexity (file not graded)
	 and one in the main game file for "graphics" not being used (used by MonoGame, if we take this out, fails to boot)
	 and one in the Sprite.cs abstract class. Given the complexity often involved in the GetSourceRectangle() method, it seems
	 to be more readable if the function is implemented as a method rather than a property (we could just as easily name the method
	 CutOutSprite)


Passwords:

	- > All passwords are Titlecase with no spaces

	- > Passwords are either COSTUMES, GAMESTATES, or MUSIC

	- > **COSTUME CODES**

		- > See Codes.txt for costume codes (Codes are in CamelCase to be easy to read here, do not enter them this way)

	- > **GAME STATE CODES**
		
		- > "Enemycostumes"		-	Enemies are assigned random nintendo costumes
		- >	"Lowgravity"		-	Produces a low gravity environment
		- >	"Normalgravity"		-	Resets gravity
		- >	"Enemybox"			-	Enemies sometimes spawn out of blocks

	- >	**MUSIC CODES**
		
		- > "Mario"				-	Normal background music
		- >	"Thousand"			-	A road trip for the ages
		- >	"Skyrim"			-	I used to be a plumber like you, but then I took an arrow to the knee
		- >	"Dorifto"			-	NANI?!
		- >	"Numa"				-	An alternative background music
		- >	"Ninja"				-	
