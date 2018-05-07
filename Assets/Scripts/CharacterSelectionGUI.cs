using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionGUI : MonoBehaviour
{
    //Character Selection
    private int selectedCharacter;
    public int maxCharAmount = 8;

    //Character Creation
    public int maxPoints = 10;
    public int pointsLeft;
    public int healthPoints;
    public int staminaPoints;
    public int powerPoints;

    //GUI
    public MENU menuState;
    public CLASS classSelected;
    public RACE raceSelected;
    public GENDER genderSelected;
    int screenX, screenY;
    int aspectX = 16, aspectY = 9;

    //Enums
    public enum MENU
    {
        LOAD = 0,
        CREATE = 1,
        GAME = 2
    };
    public enum CLASS
    {
        STANDARD = 0, // Nothing Special
        SPACEBOI = 1, // Wears Space gear
        FANTASYBOI = 2 // Wears revealing/oversized armour/gear (depends on gender)
    };
    public enum RACE
    {
        AMERICAN = 0, // Only Over Sized Gear is avaliable to wear
        RUSSIAN = 1, // Only Adidas Gear is avaliable to wear
        KOREAN = 2  // Only Samsung products are avaliable to wear
    };
    public enum GENDER
    {
        FEMALE = 0,
        MALE = 1,
        MYSTERY = 2
    };

    void Start()
    {
        /* Check if user has a character already to decide what menu to start on. */
    }

    void Update()
    {
        screenX = Screen.width / aspectX;
        screenY = Screen.height / aspectY;
    }
    void OnGUI()
    {
        GUI.Box(new Rect(screenX * 10, screenY * 0, screenX * 6, screenY * 10), "");
        if (menuState == MENU.LOAD)
        {
            for (int i = 0; i < 8; i++)
            {
                if (GUI.Button(new Rect(screenX * 10.25f, (screenY * 0.75f) + i * screenY, screenX * 4.5f, screenY * 1f), ""))
                {

                }
            }
        }
        else if (menuState == MENU.CREATE)
        {
            //Text
            GUI.Label(new Rect(screenX * 12.75f, screenY * 0.5f, screenX * 2, screenY * 1), "Class");
            GUI.Label(new Rect(screenX * 12.75f, screenY * 2f, screenX * 2, screenY * 1), "Race");
            GUI.Label(new Rect(screenX * 12.75f, screenY * 3.5f, screenX * 2, screenY * 1), "Gender");
            GUI.Label(new Rect(screenX * 12.75f, screenY * 5f, screenX * 2, screenY * 1), "Stats");
            //Buttons
            #region Class Selection
            if (GUI.Button(new Rect(screenX * 10f, screenY * 1f, screenX * 2, screenY * 1), "Standard"))
            {
                classSelected = CLASS.STANDARD;
            }
            if (GUI.Button(new Rect(screenX * 12f, screenY * 1f, screenX * 2, screenY * 1), "Astronaut"))
            {
                classSelected = CLASS.SPACEBOI;
            }
            if (GUI.Button(new Rect(screenX * 14f, screenY * 1f, screenX * 2, screenY * 1), "Knight"))
            {
                classSelected = CLASS.FANTASYBOI;
            }
            #endregion
            #region Race Selection
            if (GUI.Button(new Rect(screenX * 10f, screenY * 2.5f, screenX * 2, screenY * 1), "American"))
            {
                raceSelected = RACE.AMERICAN;
            }
            if (GUI.Button(new Rect(screenX * 12f, screenY * 2.5f, screenX * 2, screenY * 1), "Russian"))
            {
                raceSelected = RACE.RUSSIAN;
            }
            if (GUI.Button(new Rect(screenX * 14f, screenY * 2.5f, screenX * 2, screenY * 1), "Korean"))
            {
                raceSelected = RACE.KOREAN;
            }
            #endregion
            #region Gender Selection
            if (GUI.Button(new Rect(screenX * 10f, screenY * 4f, screenX * 2, screenY * 1), "Female"))
            {
                genderSelected = GENDER.FEMALE;
            }
            if (GUI.Button(new Rect(screenX * 12f, screenY * 4f, screenX * 2, screenY * 1), "Male"))
            {
                genderSelected = GENDER.MALE;
            }
            if (GUI.Button(new Rect(screenX * 14f, screenY * 4f, screenX * 2, screenY * 1), "Mystery"))
            {
                genderSelected = GENDER.MYSTERY;
            }
            #endregion
        }
        else if (menuState == MENU.GAME)
        {

        }
    }
}
