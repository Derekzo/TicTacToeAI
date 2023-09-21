# TicTacToeAI

I have made this project to win a old bet of mine in the university days.

For the game "TicTacToe", there is an AI with a MiniMax algorithm to win or draw every play. For more on the algorithm: https://en.wikipedia.org/wiki/Minimax

This is a famous problem with many solutions on the Internet. Some have few lines of code, maybe even more performant and a better graphic: https://codepen.io/garbot/pen/bWLGGL

The difference with my solution and others is the reading easibility. Having few lines of code in a fast language (C..) is the optimum for production, but not for teaching or designing. The problem I got on the university was to explain the algorithm to people.

I have realized the solution iteratively: at first, I generated every grid and, for the winners' ancestors, counted how many winners there are for every sign (X and O). After that, I considered every player must assume the opponent would play the best play possible. Minimax is the algorithm of choice for that.

Since the game is simple, not as Chess or similar, I created and saved every possible grid, to have more speed, with a brute force approach. At the first run, 5 minutes are needed to write them all.

The interesting part of this computational game theory project is the analysis can be divided in 2 parts: 1) coding of the game rules. 2) analysis of the moves graph withouting considering the rules anymore.
