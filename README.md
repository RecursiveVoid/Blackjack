# Blackjack Console Game

This is a simple console-based Blackjack game written in C# to demonstrate the advantages of the Model-View-Controller (MVC) design pattern. It uses a home-brew state machine to manage the game's state transitions.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [MVC Design Pattern](#mvc-design-pattern)
- [How to Play](#how-to-play)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This project is a basic implementation of the popular card game Blackjack. The primary goal is to illustrate how the MVC pattern can be applied in C# to separate the game's logic, user interface, and data management. Additionally, it features a simple state machine for controlling the flow of the game.

## Features

- Console-based gameplay with text-based interface.
- Player vs. Dealer, following standard Blackjack rules.
- State machine to handle game states (e.g., Start, Deal, PlayerTurn, DealerTurn, End).
- Demonstrates separation of concerns using the MVC pattern.
- Easy to extend and maintain due to its modular design.

## MVC Design Pattern

The game is structured around the MVC pattern:

- **Model**: Represents the game data and business logic (e.g., deck of cards, player hands, rules).
- **View**: Handles the user interface, displaying game information and reading player input.
- **Controller**: Manages communication between the Model and View, processes input, and updates the game state.

Using MVC in this project ensures that the game's logic is separated from the user interface, making the code more modular and easier to maintain.


## How to Play

1. The game starts with a welcome message and asks if you want to play a new game.
2. Cards are dealt to both the player and the dealer.
3. The player decides to "Hit" (get another card) or "Stand" (end their turn).
4. If the player's total exceeds 21, they "bust" and lose the game.
5. Once the player stands, the dealer takes their turn according to the game's rules.
6. The game determines the winner based on who is closer to 21 without going over.

## Contributing

Contributions are welcome! Feel free to submit a pull request or open an issue if you find bugs or have suggestions for improvements.

### Steps to Contribute

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push your branch and create a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
