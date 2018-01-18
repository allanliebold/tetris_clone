# tetris_clone
A Tetris-like game made in Unity using C#.

Board.cs - Draws the board at the start of the game. Tracks whether spaces are occupied using an array of x and y coordinates, and checks if shapes are within the boundaries of the board. 

GameController.cs - Overall game logic. Uses the Board and Spawner scripts and their functions. Includes functions to start the game, determine game over state, and restart the game. 

Shapes.cs - Attached to shape objects. Defines movement and rotation functions and user input. 

Spawner. cs - Randomly selects shapes and instantiates them when called. 
