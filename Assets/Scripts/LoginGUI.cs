using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginGUI : MonoBehaviour
{
    int screenX, screenY;
    int aspectX = 16, aspectY = 9;
    private MENU menuState;

    public string inputUsername;
    public string inputPassword;
    public string inputEmail;

    public string notify = "";

    private bool incorrectUsername;
    private bool incorrectPassword;
    private bool missingEmail;

    public float timer = 0;
    public float maxTime = 3f;



    [Header("GUI Styling")]
    public GUIStyle textfieldStyling = new GUIStyle();


    //Menu Selector
    public enum MENU
    {
        LOGIN = 0,
        SIGNUP = 1,
        GAME = 2
    };


    //GUI Elements
    void Update()
    {
        screenX = Screen.width / aspectX;
        screenY = Screen.height / aspectY;
        
    }
    void OnGUI()
    {
        textfieldStyling.fontSize = screenX / 3;

        if (menuState == MENU.LOGIN)
        {
            GUI.Box(new Rect(-screenX, 0, screenX * 20, screenY * 0.75f), ""); // Top Banner
            GUI.Box(new Rect(-screenX, screenY * 8.45f, screenX * 20, screenY * 0.75f), ""); // Bottom Banner
            GUI.Box(new Rect(screenX * 3, screenY * 0.75f, screenX * 5, screenY * 7.71f), ""); // Offcentered Text Area

            GUI.Box(new Rect(screenX * 3.25f, screenY * 2.75f, screenX * 4.5f, screenY * 0.5f), "Login");

            if (notify != "")
            {
                GUI.Box(new Rect(screenX * 3.25f, screenY * 2.25f, screenX * 4.5f, screenY * 0.5f), notify);
            }

            GUI.Label(new Rect(screenX * 3.25f, screenY * 3.75f, screenX * 4.5f, screenY * 0.5f), "Username");
            GUI.Label(new Rect(screenX * 3.25f, screenY * 4.75f, screenX * 4.5f, screenY * 0.5f), "Password");

            inputUsername = GUI.TextField(new Rect(screenX * 3.25f, screenY * 4f, screenX * 4.5f, screenY * 0.5f), inputUsername, 24, textfieldStyling);
            inputPassword = GUI.PasswordField(new Rect(screenX * 3.25f, screenY * 5f, screenX * 4.5f, screenY * 0.5f), inputPassword, "*"[0], 24, textfieldStyling);

            if (GUI.Button(new Rect(screenX * 3.25f, screenY * 5.75f, screenX * 2.25f, screenY * 0.5f), "Register"))
            {
                inputUsername = "";
                inputEmail = "";
                inputPassword = "";
                menuState = MENU.SIGNUP;
                notify = "";
            }
            if (GUI.Button(new Rect(screenX * 5.5f, screenY * 5.75f, screenX * 2.25f, screenY * 0.5f), "Login"))
            {
                notify = "";
                StartCoroutine(LoginUser(inputUsername, inputPassword));
            }



            GUI.Label(new Rect(screenX * 0.25f, screenY * 8.65f, screenX * 20, screenY * 0.5f), "NEWS: R A W R X D L O L L M F A O K D O T M A T E B O I K E K, PATCH 5.5.5.5.5.5.59: fixed nothing hahah jokes lmao");
        }
        else if (menuState == MENU.SIGNUP)
        {
            GUI.Box(new Rect(-screenX, 0, screenX * 20, screenY * 0.75f), ""); // Top Banner
            GUI.Box(new Rect(-screenX, screenY * 8.45f, screenX * 20, screenY * 0.75f), ""); // Bottom Banner
            GUI.Box(new Rect(screenX * 3, screenY * 0.75f, screenX * 5, screenY * 7.71f), ""); // Offcentered Text Area
            if (notify != "")
            {
                GUI.Box(new Rect(screenX * 3.25f, screenY * 2.25f, screenX * 4.5f, screenY * 0.5f), notify);
            }
            GUI.Box(new Rect(screenX * 3.25f, screenY * 2.75f, screenX * 4.5f, screenY * 0.5f), "Sign-Up");


            GUI.Label(new Rect(screenX * 3.25f, screenY * 3.75f, screenX * 4.5f, screenY * 0.5f), "Username");
            GUI.Label(new Rect(screenX * 3.25f, screenY * 4.75f, screenX * 4.5f, screenY * 0.5f), "Email");
            GUI.Label(new Rect(screenX * 3.25f, screenY * 5.75f, screenX * 4.5f, screenY * 0.5f), "Password");

            inputUsername = GUI.TextField(new Rect(screenX * 3.25f, screenY * 4f, screenX * 4.5f, screenY * 0.5f), inputUsername, 24, textfieldStyling);
            inputEmail = GUI.TextField(new Rect(screenX * 3.25f, screenY * 5f, screenX * 4.5f, screenY * 0.5f), inputEmail, textfieldStyling);
            inputPassword = GUI.PasswordField(new Rect(screenX * 3.25f, screenY * 6f, screenX * 4.5f, screenY * 0.5f), inputPassword, "*"[0], 24, textfieldStyling);

            if (GUI.Button(new Rect(screenX * 3.25f, screenY * 6.75f, screenX * 2.25f, screenY * 0.5f), "Back"))
            {
                inputUsername = "";
                inputEmail = "";
                inputPassword = "";
                notify = "";
                menuState = MENU.LOGIN;

            }
            if (GUI.Button(new Rect(screenX * 5.5f, screenY * 6.75f, screenX * 2.25f, screenY * 0.5f), "Register"))
            {
                notify = "";
                if (inputEmail != "" && inputPassword != "" && inputUsername != "")
                {
                    StartCoroutine(CreateUser(inputUsername, inputEmail, inputPassword));

                }
                else
                {
                    notify = "Please enter all required information!";
                }
            }
        }
        else if (menuState == MENU.GAME)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
    IEnumerator CreateUser(string _username, string _email, string _password)
    {
        string dataLocation = "http://localhost/loginsystem/insertuser.php";
        WWWForm user = new WWWForm();
        user.AddField("username_Post", _username);
        user.AddField("email_Post", _email);
        user.AddField("password_Post", _password);


        WWW databasecallback = new WWW(dataLocation, user);
        yield return databasecallback;
        Debug.Log(databasecallback.text);
        #region Notification
        if ((databasecallback.text == "User Already Exists" || databasecallback.text == "Email Already Exists"))
        {
            notify = databasecallback.text;
        }
        if (databasecallback.text == "User Already ExistsEmail Already Exists")
        {
            notify = "Account already Exists";
        }
        if (databasecallback.text == "Created User" || databasecallback.text == "Create First User")
        {
            inputUsername = "";
            inputEmail = "";
            inputPassword = "";
            menuState = MENU.LOGIN;
        }
        #endregion
    }
    IEnumerator LoginUser(string _username, string _password)
    {
        string dataLocation = "http://localhost/loginsystem/login.php";
        WWWForm user = new WWWForm();
        user.AddField("username_Post", _username);
        user.AddField("password_Post", _password);
        WWW databaseCallback = new WWW(dataLocation, user);
        yield return databaseCallback;
        Debug.Log(databaseCallback.text);
        if (databaseCallback.text == "Success")
        {
            notify = "Login Successful";
        }
        else if (databaseCallback.text == "Password Incorrect" || databaseCallback.text == "Username Incorrect")
        {
            notify = databaseCallback.text;
        }
    }
}
