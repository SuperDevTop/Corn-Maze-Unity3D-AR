using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EmailPassword : MonoBehaviour
{

    private FirebaseAuth auth;
    public InputField sUserNameInput, sPasswordInput;
    public InputField lUserNameInput, lPasswordInput;
    public GameObject panel1, panel2;
    FirebaseUser newUser;
    bool isSignup;
    bool isLogin;

    void Start()
    {
        auth = FirebaseAuth.DefaultInstance;
        //Just an example to save typing in the login form
        //UserNameInput.text = "demofirebase@gmail.com";
        //PasswordInput.text = "abcdefgh";
    }

    void Update()
    {
        if (isSignup)
        {
            isSignup = false;
            panel2.SetActive(true);
            panel1.SetActive(false);
        }

        if (isLogin)
        {
            isLogin = false;
            Application.LoadLevel("Home");
        }
    }

    public void SignupButtonClick()
    {
        Signup(sUserNameInput.text, sPasswordInput.text);
    }

    public void LoginButtonClick()
    {
        Login(lUserNameInput.text, lPasswordInput.text);
    }

    public void Signup(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            //Error handling
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0) { }
                    
                return;
            }

            isSignup = true;
            newUser = task.Result; // Firebase user has been created.            
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);                   
        });       
        
    }

    public void Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            //Error handling
            return;
        }

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
                if (task.Exception.InnerExceptions.Count > 0) { }
                    
                return;
            }

            isLogin = true;
            FirebaseUser user = task.Result;            
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                user.DisplayName, user.UserId);

            PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");                          
        });               

    }
}