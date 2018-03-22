using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionGUI : MonoBehaviour
{
    int screenX, screenY;
    int aspectX = 16, aspectY = 9;
    private MENU menuState;
    private int selectedCharacter;
    public int maxCharAmount = 8;

    [Header("GUI Styling")]
    int blanknotedollarboitestingdontuseme = 0;


    //Menu Selector
    public enum MENU
    {
        LOGIN = 0,
        SIGNUP = 1,
        GAME = 2
    };

    void Update()
    {
        screenX = Screen.width / aspectX;
        screenY = Screen.height / aspectY;
    }
    void OnGUI()
    {
        GUI.Box(new Rect(screenX * 10, screenY * 0, screenX * 5, screenY * 10), "");
        for (int i = 0; i < 8; i++)
        {
            if(GUI.Button(new Rect(screenX * 10.25f, (screenY * 0.75f) + i * screenY, screenX * 4.5f, screenY * 1f), ""))
            {

            }
        }
    }
}
