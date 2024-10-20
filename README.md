# HiLo Game
## Game rules:
1. The system chooses a number between [Min; Max] (the mystery number)
2. The player proposes a number between [Min; Max]
3. If the player's proposal is not the mystery number, the system tells the player whether:
    - HI: the mystery number is > the player's guess
    - LO: the mystery number is < the player's guess
And the player plays again.
4. The goal of the game is to discover the mystery number in a minimum of iterations.

## Project
The project contains a Server and Client that communicates using SignalR and the server supports multiple clients.
