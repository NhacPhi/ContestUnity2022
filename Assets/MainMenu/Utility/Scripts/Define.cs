using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    public static string NURSE = "Nurse";
    public static string MINE = "Mine";
    public static string KILLING_NURSE = "KillingNurse";
    public static string JOURNALIST = "Journalist";
    public static string EXPLODING_MINE = "ExplodingMine";
    public static string EXPLODING_BUILDING = "ExplodingBuilding";
    public static string AIR_CRAFT_CRASH = "AircraftCrash";
    public static string MAIN_MENU = "MainMenu";
}
public enum GameState
{
    START,
    INGAME,
    OUT_TIME,
    GAME_OVER,
    WAITING
}
public enum Level
{
    EASY,
    NORMAL,
    HARD
}
