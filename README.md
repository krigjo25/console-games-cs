# C# Console Games

## Overview
`console-games-cs` is a collection of simple console-based games written in C#.
The project is designed to demonstrate basic game development concepts and provide a fun way to practice C# programming.

The project was created as an assignment for [Get Academy](https://getacademy.no)<br>
Please respect and keep
the [Academic Honesty Integerty](https://ctl.columbia.edu/resources-and-technology/resources/academic-integrity/) in
mind.<br>

## Games Included
1. **Crocks Game**: A game where the player guesses if one number is greater than, equal to, or less than another number.
2. **Guess The Number Game**: A game where the player tries to guess a randomly generated number within a specified range.

## Features
- Multiple games in one project.
- Dynamic difficulty adjustment based on player performance.
- Simple and intuitive console-based user interface.
- Easy to extend with new games.

## Requirements
- Visual Studio 2019 > / Rider 2020.3 >
- .NET Core 8.0

## Installation
1. Clone the repository
2. ```shell script
   git clone https://github.com/krigjo25/Console-StudentManagementSystem-cs
   ```
3. Open the project in Visual Studio
4. Run the project
5. Done!

### Example
```sh
prompt :
Press an Integer to select one of the following Games.
1. Crocks Game
2. Guess The Number
s. Shows current stats (inside a game )
0, ESC, q  to quit the game

input : 1
// Initializing the Crocks Game

input : s
// Initializing the current stats

input : 2
// Initializing Guess The Game

input : s
// Initializing the current stats

input : esc (q)
// Exits the game with an exit status of 0

```

### Playing the Games
- Follow the on-screen instructions to play each game.
- Use the specified keys to make your guesses or view your stats.

## Game Rules

### Crocks Game
- The game will generate two random numbers.
- You need to guess if the first number is greater than, equal to, or less than the second number.
- Use the keys `=`, `>`, `<` to make your guess.
- Use the key `s` to view your current stats.
- Use the key `q` to quit the game.

### Guess The Number Game
- The game will generate a random number within a specified range.
- You need to guess the number.
- If you guess correctly, you gain a point and the difficulty increases.
- If you guess incorrectly, you lose a life.

Based on level the difficulty may vary, but the user gets a hint if the user types in a less or greater than answer.

## License
This application is under [GNU v.3](./LICENCE)

## Notes from the developer
Created with love for programming, thanks for reading.
I hope you'll have a beautiful day as you are!,<br>
@krigjo25
