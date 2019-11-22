﻿using Jarrus.Event;
using Jarrus.Games;
using Jarrus.Games.Enums;
using Jarrus.Games.Exceptions;
using Jarrus.TTT.Enums;

namespace Jarrus.TTT
{
    public class TicTacToeGame : TurnBasedGame
    {
        public TicTacToeGame() : base(2)
        {
            State = new State();
        }

        public override void Process(EventAction gameMove)
        {
            var move = (Action)gameMove;
            var state = (State)State;

            var validation = move.GetValidationType(State);
            if (validation != Validation.VALID) { throw new InvalidMoveException(validation.ToString()); }

            state.Set(move.Position, move.GetSymbol());
        }

        public override bool IsComplete()
        {
            var state = (State)State;
            var winner = State.GetWinningPlayer();
            return winner != Seat.NONE || state.GetEmptySpaces() == 0;
        }

        public override string ToString() { return State.ToString(); }
    }
}