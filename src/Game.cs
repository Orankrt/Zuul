using System;

class Game
{
	// Private fields
	private Parser parser;
	private Player player;

	// Constructor
	public Game()
	{
		parser = new Parser();
		player = new Player();
		CreateRooms();
	}

	// Initialise the Rooms (and the Items)
	private void CreateRooms()
	{
		// Create the rooms
		//##################################################################################################################
		// ROOMS LIST
		//##################################################################################################################
		Room patientRoom = new Room("in the patient room where you woke up",
		("The bed is dirty, and the sheets are crumpled. The air smells bad, a mix of medicine and something rotten. The heart monitor is off, and medical tools are scattered on the floor. The window blinds are half-open. This room was once safe, but now it feels abandoned and scary."));
		Room patientRoomWC = new Room("in the patient room's WC",
		("The WC is small and dirty."));
		Room patientRoomCorridor = new Room("in the corridor of the patient rooms", ("Wheelchairs are overturned, IV bags scattered across the floor. Something terrible has happened here, but you don’t know what. All you do know is that you shouldn’t stay here for long…"));
		Room receptionHall = new Room("in the reception hall.",
		(" The floor is covered in scattered papers, broken glass, and dried blood.  "));
		Room patientReception = new Room("in the patient reception",
		("The reception desk is empty and the lights are off, the only light that comes is from the outside. "));
		Room cafeteriaHall = new Room("in the cafeteria hall",
		("The walls are stained with handprints and graffiti. You also see some bullet shells on the ground. The smell of decay is strong, and the air is heavy. You can hear faint moans and shuffling coming from the other rooms. Most doors are open, but some are chained shut or barricaded with wooden planks. The words 'DO NOT OPEN, DEAD INSIDE' are spray-painted in large letters across one of the doors. Faint, guttural growls echo from behind it, sending chills down your spine. "));
		Room patientMainHall = new Room("in the main hall of the patient area",
		(" You see a elevator but there is no power in the buildin. So you have to use stairs or go back."));
		Room secondFloorStairs = new Room("in the second floor stairs",
		("The stairs are dark because there is no electricity but it's the only way down. So you have to lean against the wall and go down slowly. "));
		Room firstFloorStairs = new Room("in the first floor stairs",
		("The stairs are dark because there is no electricity but it's the only way up. So you have to lean against the wall and go up slowly."));
		Room mainHall = new Room("in the main hall of the hospital",
		("The main hall is vast and empty, with high ceilings that echo your every step. The floors are cracked and dirty, littered with discarded hospital equipment and broken furniture. Dim lights hang from the ceiling. The walls are marked with old bloodstains and peeling paint. A sense of abandonment fills the air. The silence is unsettling, broken only by distant, muffled sounds. "));
		Room operatingRoom = new Room("in the operating room",
		("The operating room is cold and sterile. The air is thick with the smell of antiseptic. The room is silent.. "));
		Room operatingRoomHall = new Room("in the hall of the operating rooms", ("The hall is warm and there is sunlight coming through all of the windows, you suddenly feel safe you close your eyes slowly and take a deep breath but as you open your eyes again you relize that the walls covered in mold and dried blood. The air is thick with the smell of decay."));
		Room exit = new Room("in the outside of the hospital",
		("When you go outside you see dozens of dead bodies lying on the ground and covered with sheets. You have no idea what happened, but the place is deserted and quiet. You realize that something really bad happened when you were in the coma..."));
		Room basementStairs = new Room("in the basement stairs",
		("The stairs are dark and damp. The air is thick with the smell of mold and decay. You can hear faint sounds coming from below, but you can't make out what they are. The stairs are steep and slippery, and you have to be careful not to fall. "));
		Room basementHall = new Room("in the basement hall",
		("The basement is dark and cold. The walls are damp and covered in mold and the air is thick with the smell of decay. You can hear faint sounds coming from a room all the way in the end of the hall, but you can't make out what they are. The only light comes from a window close to the ceiling. "));
		Room storageRoom = new Room("in the storage room",
		("The storage room is cramped and messy, with shelves of supplies coated in dust. Boxes lie broken on the floor, and the air smells damp and stale. The room is filled with the sound of rats scurrying and the occasional drip of water. "));
		Room morgue = new Room("in the morgue",
		("The morgue is cold and sterile, with rows of metal tables and body bags. The air is thick with the smell of formaldehyde. The room is silent, but you can't shake the feeling that you're being watched. "));

		//##################################################################################################################
		//##################################################################################################################


		// Initialise room exits
		//##################################################################################################################
		// ROOMS EXITS		
		//##################################################################################################################
		patientRoom.AddExit("east", patientRoomCorridor);
		patientRoom.AddExit("south", patientRoomWC);

		patientRoomWC.AddExit("north", patientRoom);

		patientRoomCorridor.AddExit("west", patientRoom);
		patientRoomCorridor.AddExit("south", receptionHall);

		receptionHall.AddExit("north", patientRoomCorridor);
		receptionHall.AddExit("west", patientReception);
		receptionHall.AddExit("east", cafeteriaHall);

		patientReception.AddExit("east", receptionHall);

		cafeteriaHall.AddExit("north", patientMainHall);
		cafeteriaHall.AddExit("west", receptionHall);
		// cafeteriaHall.AddExit("east", cafeteria);

		patientMainHall.AddExit("south", cafeteriaHall);
		patientMainHall.AddExit("north", secondFloorStairs);
		// mainHall.AddExit("west", elevator);

		secondFloorStairs.AddExit("south", patientMainHall);
		secondFloorStairs.AddExit("down", firstFloorStairs);

		firstFloorStairs.AddExit("up", secondFloorStairs);
		firstFloorStairs.AddExit("down", basementStairs);
		firstFloorStairs.AddExit("south", mainHall);

		basementStairs.AddExit("up", firstFloorStairs);
		basementStairs.AddExit("south", basementHall);

		basementHall.AddExit("north", basementStairs);
		basementHall.AddExit("east", storageRoom);
		basementHall.AddExit("west", morgue);

		storageRoom.AddExit("west", basementHall);

		morgue.AddExit("east", basementHall);

		mainHall.AddExit("north", firstFloorStairs);
		mainHall.AddExit("east", exit);
		mainHall.AddExit("south", operatingRoomHall);

		operatingRoomHall.AddExit("north", mainHall);
		operatingRoomHall.AddExit("west", operatingRoom);

		operatingRoom.AddExit("east", operatingRoomHall);

		exit.AddExit("west", mainHall);
		//##################################################################################################################
		//##################################################################################################################



		// Create your Items here
		//##################################################################################################################
		// ITEMS LIST
		//##################################################################################################################

		//Weapons
		//##############################
		Item scalpel = new Item(1, "A scalpel. It's small but very sharp and dangerous.");
		Item knife = new Item(2, "A kitchen knife. It's sharp and could be useful for self-defense.");
		Item crowbar = new Item(4, "A crowbar. It's heavy and sturdy, and it could be useful for breaking things.");
		Item pistol = new Item(4, "A pistol. It's worn, semi-automatic pistol, lightweight and scratched. .");
		//##############################

		//Light Sources
		//##############################
		// Item flashlight = new Item(3, "A flashlight. It's small and portable, but the batteries are almost dead.");
		//##############################

		//Medical Items
		//##############################
		Item medicineBottle = new Item(1, "A medicine bottle. It contains a small amount of medicine.");
		Item medKit = new Item(4, "A medical kit. It contains bandage, antiseptic, and some other medical supplies.");
		Item medicalBag = new Item(9, "A medical bag. It contains a lot of medicine, but it's too heavy.");
		//##############################

		//##################################################################################################################
		//##################################################################################################################


		// And add them to the Rooms
		// ...

		// Start game in the patient room
		player.CurrentRoom = patientRoom;
	}

	//  Main play routine. Loops until end of play.
	public void Play()
	{
		PrintWelcome();

		// Enter the main command loop. Here we repeatedly read commands and
		// execute them until the player wants to quit.
		bool finished = false;
		while (!finished)
		{
			Command command = parser.GetCommand();
			finished = ProcessCommand(command);
		}
		if (!player.IsAlive())
		{
			Console.WriteLine("You have died. Game Over.");
			Environment.Exit(0);
		}
		else
		{
			Console.WriteLine("Thank you for playing.");
		}
		Console.WriteLine("Press [Enter] to continue.");
		Console.ReadLine();
	}

	// Print out the opening message for the player.
	private void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to Zuul TWD!");
		Console.WriteLine("-----------------------------------------------");
		Console.WriteLine("As you open your eyes, you feel dizzy. The surroundings are silent… Too silent. Your mind is foggy, your body weak. You realize you’re in a hospital room. The last thing you remember is being shot while fighting criminals with your police colleagues.");
		Console.WriteLine("You try to get out of bed slowly, but you fail and fall to the floor. You slowly get up again.");
		Console.WriteLine("-----------------------------------------------");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine("-----------------------------------------------");
		Console.WriteLine();
		Console.WriteLine(player.CurrentRoom.GetLongDescription());
	}

	// Given a command, process (that is: execute) the command.
	// If this command ends the game, it returns true.
	// Otherwise false is returned.
	private bool ProcessCommand(Command command)
	{
		bool wantToQuit = false;

		if (command.IsUnknown())
		{
			Console.WriteLine("I don't know what you mean...");
			return wantToQuit; // false
		}

		switch (command.CommandWord)
		{
			case "help":
				PrintHelp();
				break;
			case "go":
				GoRoom(command);
				break;
			case "look":
				Look();
				break;
			case "status":
				ShowStatus();
				break;
			case "quit":
				wantToQuit = true;
				break;
		}

		return wantToQuit;
	}

	// ######################################
	// implementations of user commands:
	// ######################################

	// Print out some help information.
	// Here we print the mission and a list of the command words.
	private void PrintHelp()
	{
		Console.WriteLine("You are lost. You are alone.");
		Console.WriteLine("-----------------------------");
		Console.WriteLine();
		// let the parser print the commands
		parser.PrintValidCommands();
	}

	// Look around the current room.
	private void Look()
	{
		Console.WriteLine(player.CurrentRoom.RoomLongDescription());
	}

	// Try to go to one direction. If there is an exit, enter the new
	// room, otherwise print an error message.
	private void GoRoom(Command command)
	{
		if (!command.HasSecondWord())
		{
			// if there is no second word, we don't know where to go...
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;

		// Try to go to the next room.
		Room nextRoom = player.CurrentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to " + direction + "!");
			return;
		}
		player.Move(); // Decrease health when moving

		if (!player.IsAlive())
		{
			Console.WriteLine("You have died from your injuries while moving.");
			Environment.Exit(0); // End the game if player is dead
		}

		player.CurrentRoom = nextRoom;
		Console.WriteLine(player.CurrentRoom.GetLongDescription());

	}

	private void ShowStatus()
	{
		Console.WriteLine("============STATUS=============");
		Console.WriteLine(player.GetHealthStatus());
		Console.WriteLine("------------------------------");
		Console.WriteLine("Inventory: ");
		Console.WriteLine("------------------------------");
	}
}
