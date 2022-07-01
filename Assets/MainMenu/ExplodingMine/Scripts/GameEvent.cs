using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace MiniGames.ExplodingMine
{
    public class GameEvent : MonoBehaviour
    {
        public static Action CheckAllSquareInGridCanBeActive;
        public static Action GameWon;
        public static Action GameOver;
        public static Action ChooseSquare;
    }
}

