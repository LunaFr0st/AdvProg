using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class LoginGUI : MonoBehaviour
{
    int screenX, screenY;
    int aspectX = 16, aspectY = 9;
    private MENU menuState;

    [Header("Inputs")]
    public string inputUsername;
    public string inputPassword;
    public string inputEmail;
    public string inputCode;
    public string eMail;
    [Header("Strings")]
    public string notify = "";
    private string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    [Header("Missing Info")]
    private bool incorrectUsername;
    private bool incorrectPassword;
    private bool missingEmail;

    public float timer = 0;
    public float maxTime = 3f;

    private bool sentEmail = false;
    private string backupEmail;
    private string confirmPass = "";
    public string encryptKey = "8C4EE";


    [Header("GUI Styling")]
    public GUIStyle textfieldStyling = new GUIStyle();
    

    //Menu Selector
    public enum MENU
    {
        LOGIN = 0,
        SIGNUP = 1,
        RESET = 2,
        NEWPASS = 3,
        GAME = 4,

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
        GUI.Box(new Rect(-screenX, 0, screenX * 20, screenY * 0.75f), ""); // Top Banner
        GUI.Box(new Rect(-screenX, screenY * 8.45f, screenX * 20, screenY * 0.75f), ""); // Bottom Banner
        GUI.Box(new Rect(screenX * 3, screenY * 0.75f, screenX * 5, screenY * 7.71f), ""); // Offcentered Text Area
        if (menuState == MENU.LOGIN)
        {
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
            if (GUI.Button(new Rect(screenX * 5.5f, screenY * 6.25f, screenX * 2.25f, screenY * 0.25f), "Forgot Password?"))
            {
                inputUsername = "";
                inputPassword = "";
                menuState = MENU.RESET;
                notify = "";
            }



            GUI.Label(new Rect(screenX * 0.25f, screenY * 8.65f, screenX * 20, screenY * 0.5f), "NEWS: R A W R X D L O L L M F A O K D O T M A T E B O I K E K, PATCH 5.5.5.5.5.5.59: fixed nothing hahah jokes lmao");
        }
        else if (menuState == MENU.SIGNUP)
        {
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
                ResetInputs();
                menuState = MENU.LOGIN;

            }
            if (GUI.Button(new Rect(screenX * 5.5f, screenY * 6.75f, screenX * 2.25f, screenY * 0.5f), "Register"))
            {
                notify = "";
                if (inputEmail.Contains("@") && inputEmail.Contains("."))
                {
                    if (inputEmail != "" && inputPassword != "" && inputUsername != "")
                    {
                        StartCoroutine(CreateUser(inputUsername, inputEmail, inputPassword));
                    }
                    else
                    {
                        notify = "Please enter all required information!";
                    }
                }
                else
                {
                    notify = "Email invalid";
                }
            }
        }
        else if (menuState == MENU.RESET)
        {
            if (notify != "")
            {
                GUI.Box(new Rect(screenX * 3.25f, screenY * 2.25f, screenX * 4.5f, screenY * 0.5f), notify);
            }
            GUI.Box(new Rect(screenX * 3.25f, screenY * 2.75f, screenX * 4.5f, screenY * 0.5f), "Forgot Password?");
            if (!sentEmail)
            {
                GUI.Label(new Rect(screenX * 3.25f, screenY * 3.75f, screenX * 4.5f, screenY * 0.5f), "Email");

                inputEmail = GUI.TextField(new Rect(screenX * 3.25f, screenY * 4f, screenX * 4.5f, screenY * 0.5f), inputEmail, 24, textfieldStyling);

                if (GUI.Button(new Rect(screenX * 3.25f, screenY * 4.75f, screenX * 4.5f, screenY * 0.5f), "Send Email"))
                {
                    backupEmail = inputEmail;
                    StartCoroutine(ResetUser(inputEmail));
                    sentEmail = true;
                }
            }
            else if (sentEmail)
            {
                GUI.Label(new Rect(screenX * 3.25f, screenY * 3.75f, screenX * 4.5f, screenY * 0.5f), "Reset Code");

                inputCode = GUI.TextField(new Rect(screenX * 3.25f, screenY * 4f, screenX * 4.5f, screenY * 0.5f), inputCode, 5, textfieldStyling);

                if (GUI.Button(new Rect(screenX * 3.25f, screenY * 4.75f, screenX * 4.5f, screenY * 0.5f), "Submit Code"))
                {
                    StartCoroutine(CheckCode(inputCode, inputEmail));
                }
            }

        }
        else if (menuState == MENU.NEWPASS)
        {
            if (notify != "")
            {
                GUI.Box(new Rect(screenX * 3.25f, screenY * 2.25f, screenX * 4.5f, screenY * 0.5f), notify);
            }
            GUI.Box(new Rect(screenX * 3.25f, screenY * 2.75f, screenX * 4.5f, screenY * 0.5f), "Reset Password");

            GUI.Label(new Rect(screenX * 3.25f, screenY * 3.75f, screenX * 4.5f, screenY * 0.5f), "Email");
            GUI.Label(new Rect(screenX * 3.25f, screenY * 4.75f, screenX * 4.5f, screenY * 0.5f), "New Password");
            GUI.Label(new Rect(screenX * 3.25f, screenY * 5.75f, screenX * 4.5f, screenY * 0.5f), "Confirm Password");

            GUI.Box(new Rect(screenX * 3.25f, screenY * 4f, screenX * 4.5f, screenY * 0.5f), inputEmail, textfieldStyling);
            inputPassword = GUI.PasswordField(new Rect(screenX * 3.25f, screenY * 5f, screenX * 4.5f, screenY * 0.5f), inputPassword, "*"[0], 24, textfieldStyling);
            confirmPass = GUI.PasswordField(new Rect(screenX * 3.25f, screenY * 6f, screenX * 4.5f, screenY * 0.5f), confirmPass, "*"[0], 24, textfieldStyling);

            if (GUI.Button(new Rect(screenX * 3.25f, screenY * 6.5f, screenX * 4.5f, screenY * 0.5f), "Set new Password"))
            {
                if (confirmPass == inputPassword)
                {
                    StartCoroutine(ResetPassword(confirmPass, inputEmail, inputCode));
                    confirmPass = "";
                    inputPassword = "";
                }
                else
                {
                    notify = "Passwords do not match!";
                    inputPassword = "";
                    confirmPass = "";
                }
            }
        }
        else if (menuState == MENU.GAME)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    void ResetInputs()
    {
        inputCode = "";
        inputEmail = "";
        inputPassword = "";
        inputUsername = "";
        sentEmail = false;
        confirmPass = "";
        notify = "";
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
            ResetInputs();
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
            menuState = MENU.GAME;
        }
        else if (databaseCallback.text == "Password Incorrect" || databaseCallback.text == "Username Incorrect")
        {
            notify = databaseCallback.text;
        }
    }
    IEnumerator ResetUser(string _email)
    {
        string dataLocation = "http://localhost/loginsystem/sendcode.php";
        string code = "";
        for (int i = 0; i < 5; i++)
        {
            int letter = Random.Range(0, characters.Length);
            code += characters[letter];
        }

        WWWForm user = new WWWForm();
        user.AddField("email_Post", _email);
        user.AddField("resetcode_Post", code);
        WWW databaseCallback = new WWW(dataLocation, user);
        yield return databaseCallback;

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("sqlunityclasssydney@gmail.com");
        mail.To.Add(_email);
        mail.Subject = "Account Reset Code";
        mail.Body = "Your reset code is: " + code;
        //Simple Mail Transfer Protocol
        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new NetworkCredential("sqlunityclasssydney@gmail.com", "sqlpassword") as ICredentialsByHost;
        smtpServer.EnableSsl = true;

        ServicePointManager.ServerCertificateValidationCallback = delegate
        (object s, X509Certificate cert, X509Chain chain, SslPolicyErrors policyErrors)
        { return true; };

        smtpServer.Send(mail);
        Debug.Log("Email Sent Successfully");
    }
    IEnumerator CheckCode(string _code, string _email)
    {
        string dataLocation = "http://localhost/loginsystem/checkcode.php";
        WWWForm user = new WWWForm();
        user.AddField("email_Post", _email);
        user.AddField("resetcode_Post", _code);
        WWW databaseCallback = new WWW(dataLocation, user);
        yield return databaseCallback;
        Debug.Log(databaseCallback.text);
        if (databaseCallback.text == "Success")
        {
            notify = "Code Successful";
            menuState = MENU.NEWPASS;
        }
        else if (databaseCallback.text == "Reset Code Incorrect")
        {
            notify = "Code Incorrect, Try again!";
        }
    }
    IEnumerator ResetPassword(string _password, string _email, string _code)
    {
        string dataLocation = "http://localhost/loginsystem/resetpassword.php";
        WWWForm user = new WWWForm();
        user.AddField("email_Post", _email);
        user.AddField("password_Post", _password);
        user.AddField("resetcode_Post", _code);
        WWW databaseCallback = new WWW(dataLocation, user);
        yield return databaseCallback;
        Debug.Log(databaseCallback.text);
        if (databaseCallback.text == "Password Changed")
        {
            notify = "Password Updated!";
            ResetInputs();
            menuState = MENU.LOGIN;
        }
        else if (databaseCallback.text == "error")
        {
            notify = "Failure!";
        }
    }

}
