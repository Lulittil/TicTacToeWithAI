using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Models
{
    public enum Modes
    {
        WithPlayer,
        WithAI,
        AItoAI,
    }

    public enum WhichStep
    {
        FirstPlayer,
        SecondPlayer,
        AI,
        FirstPlayerWithAI,
        AI_2,
    }

    public enum IsAIMove
    {
        AIMove,
        NextStep, //if one of algorithms not work
    }

    public enum PlayDesk
    {
        Player =1,
        AI = 10,
        Null =0,
    }

    
}
