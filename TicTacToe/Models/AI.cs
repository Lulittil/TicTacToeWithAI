using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Models
{
    class AI
    {
        PlayDesk AIst;
        PlayDesk Plst;

        Game _gameForm;

        public AI(Game game)
        {
            _gameForm = game;
            AIst = _gameForm.AIst;
            Plst = _gameForm.PlSt;
        }

        public void MakeAIMove()
        {
            bool nthng = false;

            //PlayForWin();
        }

        //private void PlayForWin();
    }
}
