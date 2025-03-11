using System;

class Game
{
	// Private fields
	private Parser parser;
	private Room currentRoom;

	// Constructor
	public Game()
	{
		parser = new Parser();
		CreateRooms();
	}

	// Initialise the Rooms (and the Items)
	private void CreateRooms()
	{
		// Create the rooms
		Room patientRoom = new Room("in a patient room where you woke up",
		("The bed is dirty, and the sheets are crumpled. The air smells bad, a mix of medicine and something rotten. The heart monitor is off, and medical tools are scattered on the floor. The window blinds are half-open. This room was once safe, but now it feels abandoned and scary."));
		Room patientRoomWC = new Room("in the patient room's WC",
		("The WC is small and dirty."));
		Room patientRoomCorridor = new Room("in the corridor of the patient rooms", ("Wheelchairs are overturned, IV bags scattered across the floor. The electrical panels seem to be short-circuiting, occasionally sparking. Something terrible has happened here, but you don’t know what. All you do know is that you shouldn’t stay here for long…"));
		Room receptionHall = new Room("in a hall.",
		(" The floor is covered in scattered papers, broken glass, and dried blood.  "));
		Room patientReception = new Room("in the patient reception",
		("The reception desk is empty, and the computer screen is flickering. The lights are off, and the only light comes from the outside. "));
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
		Room exit = new Room("in the outside of the hospital",
		("When you go outside you see dozens of dead bodies lying on the ground and covered with sheets. You have no idea what happened, but the place is deserted and quiet. You realize that something really bad happened when you were in the coma..."));

		// Initialise room exits
		patientRoom.AddExit("east", patientRoomCorridor);
		patientRoom.AddExit("south", patientRoomWC);

		patientRoomWC.AddExit("north", patientRoom);

		patientRoomCorridor.AddExit("west", patientRoom);
		patientRoomCorridor.AddExit("south", receptionHall);

		receptionHall.AddExit("north", patientRoomCorridor);
		receptionHall.AddExit("east", patientReception);
		receptionHall.AddExit("west", cafeteriaHall);

		patientReception.AddExit("west", receptionHall);

		cafeteriaHall.AddExit("north", patientMainHall);
		cafeteriaHall.AddExit("east", receptionHall);
		// cafeteriaHall.AddExit("west", cafeteria);

		patientMainHall.AddExit("south", cafeteriaHall);
		patientMainHall.AddExit("north", secondFloorStairs);
		// mainHall.AddExit("west", elevator);

		secondFloorStairs.AddExit("south", patientMainHall);
		secondFloorStairs.AddExit("down", firstFloorStairs);

		firstFloorStairs.AddExit("up", secondFloorStairs);
		firstFloorStairs.AddExit("south", mainHall);

		mainHall.AddExit("north", firstFloorStairs);
		mainHall.AddExit("east", exit);
		// mainHall.AddExit("south", firstFloorHall);
		// mainHall.AddExit("west", elevator);

		exit.AddExit("west", mainHall);




		// Create your Items here

		//##############################
		// ITEMS
		//##############################

		//Weapons
		//##############################
		Item scalpel = new Item(1, "A scalpel. It's small but very sharp and dangerous.");
		Item knife = new Item(2, "A kitchen knife. It's sharp and could be useful for self-defense.");
		Item crowbar = new Item(4, "A crowbar. It's heavy and sturdy, and it could be useful for breaking things.");
		Item pistol = new Item(4, "A pistol. It's worn, semi-automatic pistol, lightweight and scratched. .");
		Item shotgun = new Item(8, "A shotgun. It's rusty pump-action shotgun, sturdy but weathered..");
		//##############################
		// Food Items
		//##############################
		Item apple = new Item(1, "An apple. It's sweet and tasty.");
		Item banana = new Item(1, "A banana. It's yellow and juicy.");
		Item sandwich = new Item(2, "A sandwich. It's made from bread and cheese.");
		Item juice = new Item(1, "A juice. It's sweet and refreshing.");
		Item waterBottle = new Item(2, "A water bottle. It's filled with clean water.");
		//##############################
		//Medical Items
		//##############################
		Item medicineBottle = new Item(1, "A medicine bottle. It contains a small amount of medicine.");
		Item medKit = new Item(4, "A medical kit. It contains bandages, antiseptic, and other medical supplies.");
		Item medicalBag = new Item(9, "A medical bag. It contains a lot of medicine, but it's too heavy to carry.");
		//##############################

		// And add them to the Rooms
		// ...

		// Start game outside
		currentRoom = patientRoom;
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
		Console.WriteLine("Thank you for playing.");
		Console.WriteLine("Press [Enter] to continue.");
		Console.ReadLine();
	}

	// Print out the opening message for the player.
	private void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to TWD!");
		Console.WriteLine("-----------------------------------------------");
		Console.WriteLine("As you open your eyes, you feel dizzy. The surroundings are silent… Too silent. Your mind is foggy, your body weak. You realize you’re in a hospital. The last thing you remember is being shot while fighting criminals with your police colleagues.");
		Console.WriteLine("You try to get out of bed slowly, but you fail and fall to the floor. You slowly get up again.");
		Console.WriteLine("-----------------------------------------------");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine("-----------------------------------------------");
		Console.WriteLine();
		Console.WriteLine(currentRoom.GetLongDescription());
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

	private void Look()
	{
		Console.WriteLine(currentRoom.RoomLongDescription());
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
		Room nextRoom = currentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to " + direction + "!");
			return;
		}

		currentRoom = nextRoom;
		Console.WriteLine(currentRoom.GetLongDescription());
	}
}
