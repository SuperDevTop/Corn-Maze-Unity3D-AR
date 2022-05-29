using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class CitrouillevilleInfo : MonoBehaviour
{    
    public Text timeText;
    public Text dateText;
    public Text placeContent;
    public Text gpsContent;
    public Text hourContent;
    public Text admissionContent;
    public Text aboutContent;
    public Text ticketContent;
    public GameObject shopContent;
    public GameObject activityContent;
    public DatabaseReference refDirection;
    public DatabaseReference refTicketURL;
    public DatabaseReference refGPS;
    public DatabaseReference refHours;
    public DatabaseReference refAdmission;
    public DatabaseReference refAbout;
    public DatabaseReference refTicket;
    public DatabaseReference refActivityImg;
    public DatabaseReference refActivityTitle;
    public DatabaseReference refProductImg;
    public DatabaseReference refProductTitle;
    public DatabaseReference refProductPrice;
    public GameObject shopGameObject;
    public GameObject activityGameObject;
    public Text[] text;    

    int productImgNumber = 0;
    int activityImgNumber = 0;
    int productTitleNumber = 0;
    int activityTitleNumber = 0;
    int productPriceNumber = 0;    
    string strValue;
    string ticketURL = "http://51.161.33.120/";
    bool isActivity;
    bool isShop;

    void Start()
    {
        Strings.AddString();
        //print(Strings.mainPanelE.Count);

        productImgNumber = 0;
        activityImgNumber = 0;
        productTitleNumber = 0;
        activityTitleNumber = 0;
        productPriceNumber = 0;
        
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://corn-maze-3fbdc.firebaseio.com/");

        // Get the root reference location of the database.

        refTicketURL = FirebaseDatabase.DefaultInstance.GetReference("Ticket_URL");

        refTicketURL.ChildAdded += TicketURLHandleChildAdded;

        refDirection = FirebaseDatabase.DefaultInstance.GetReference("Direction");

        refDirection.ChildAdded += DirectionHandleChildAdded;

        refGPS = FirebaseDatabase.DefaultInstance.GetReference("GPS");

        refGPS.ChildAdded += GPSHandleChildAdded;

        refHours = FirebaseDatabase.DefaultInstance.GetReference("Hours");

        refHours.ChildAdded += HourHandleChildAdded;

        refTicket = FirebaseDatabase.DefaultInstance.GetReference("Ticket");

        refTicket.ChildAdded += TicketHandleChildAdded;

        refAdmission = FirebaseDatabase.DefaultInstance.GetReference("Admission");

        refAdmission.ChildAdded += AdmissionHandleChildAdded;

        refAbout = FirebaseDatabase.DefaultInstance.GetReference("About");

        refAbout.ChildAdded += AboutHandleChildAdded;        

               

       

        /* if (SplashScene.registeredTime.Hour < 12)
         {
             timeText.text = "" + SplashScene.registeredTime.Hour + ":" + SplashScene.registeredTime.Minute + " AM";
         }
         else
         {
             if (SplashScene.registeredTime.Hour == 12)
             {
                 timeText.text = "" + SplashScene.registeredTime.Hour + ":" + SplashScene.registeredTime.Minute + " PM";
             }
             else
             {
                 timeText.text = "" + (SplashScene.registeredTime.Hour - 12) + ":" + SplashScene.registeredTime.Minute + " PM";
             }            
         }

         dateText.text = "" + SplashScene.registeredTime.Month + "/" + SplashScene.registeredTime.Day + "/" + SplashScene.registeredTime.Year;*/
    }

    void Update()
    {
        if (SplashScene.gameplayLang == "english")
        {
            print(Strings.mainPanelE.Count);

            for (int i = 0; i < text.Length; i++)
            {
                text[i].text = Strings.mainPanelE[i];
            }

        }
        else if (SplashScene.gameplayLang == "french")
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].text = Strings.mainPanelF[i];
            }
        }

        if (shopGameObject.active == true && !isShop)
        {
            isShop = true;
            refProductTitle = FirebaseDatabase.DefaultInstance.GetReference("Product_Title");

            refProductTitle.ChildAdded += PTitleHandleChildAdded;

            refProductPrice = FirebaseDatabase.DefaultInstance.GetReference("Product_Price");

            refProductPrice.ChildAdded += PPriceHandleChildAdded;

            refProductImg = FirebaseDatabase.DefaultInstance.GetReference("Product_Img");

            refProductImg.ChildAdded += PImgHandleChildAdded;
            
        }

        if (activityGameObject.active == true && !isActivity)
        {
            isActivity = true;
            refActivityTitle = FirebaseDatabase.DefaultInstance.GetReference("Activity_Title");

            refActivityTitle.ChildAdded += ATitleHandleChildAdded;

            refActivityImg = FirebaseDatabase.DefaultInstance.GetReference("Activity_Img");

            refActivityImg.ChildAdded += AImgHandleChildAdded;
        }
    }

    public void FrenchClick()
    {
        SplashScene.gameplayLang = "french";
    }

    public void EnglishClick()
    {
        SplashScene.gameplayLang = "english";
    }

    public void GetProductImage(string url, RawImage rawImage)
    {
        StartCoroutine(setProductImage(url, rawImage)); //balanced parens CAS
    }

    IEnumerator setProductImage(string url, RawImage rawImage)
    {
        WWW www = new WWW(url);
        while (!www.isDone)
        yield return null;

        print(url);
        rawImage.texture = www.texture;
        //productNumber++;
    }

    public void GetActivityImage(string url, RawImage rawImage)
    {
        StartCoroutine(setActivityImage(url, rawImage)); //balanced parens CAS
    }

    public void TicketClick()
    {
        Application.OpenURL(ticketURL);
    }

    IEnumerator setActivityImage(string url, RawImage rawImage)
    {
        WWW www = new WWW(url);
        while (!www.isDone)
            yield return null;

        print(url);
        rawImage.texture = www.texture;
        //activityNumber++;
    }

    void DirectionHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
               
        SpliString(args.Snapshot.GetRawJsonValue());
        placeContent.text = strValue;
    }

    void TicketURLHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        SpliString(args.Snapshot.GetRawJsonValue());

        if (args.Snapshot.ChildrenCount >= 1)
        {
            ticketURL = strValue;
        }
    }

    void GPSHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }        
        SpliString(args.Snapshot.GetRawJsonValue());
        gpsContent.text = strValue;
    }

    void HourHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        SpliString(args.Snapshot.GetRawJsonValue());
        hourContent.text = strValue;
    }

    void TicketHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        SpliString(args.Snapshot.GetRawJsonValue());
        ticketContent.text = strValue;
    }

    void AdmissionHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        SpliString(args.Snapshot.GetRawJsonValue());
        admissionContent.text = strValue;
    }

    void AboutHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        SpliString(args.Snapshot.GetRawJsonValue());
        aboutContent.text = strValue;
    }

    void AImgHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        activityImgNumber++;
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        //print(args.Snapshot.ChildrenCount);
        SpliString(args.Snapshot.GetRawJsonValue());

        GameObject.FindGameObjectsWithTag("Activity")[activityImgNumber - 1].GetComponentInChildren<RawImage>().enabled = true;
        GameObject.FindGameObjectsWithTag("Activity")[activityImgNumber - 1].GetComponentInChildren<Image>().enabled = true;
        GetActivityImage(strValue, GameObject.FindGameObjectsWithTag("Activity")[activityImgNumber - 1].GetComponentInChildren<RawImage>());
    }

    void ATitleHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        activityTitleNumber++;
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        SpliString(args.Snapshot.GetRawJsonValue());
        GameObject.FindGameObjectsWithTag("Activity")[activityTitleNumber - 1].GetComponentsInChildren<Text>()[0].enabled = true;
        GameObject.FindGameObjectsWithTag("Activity")[activityTitleNumber - 1].GetComponentsInChildren<Text>()[1].text = strValue;
    }

    void PImgHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        productImgNumber++;
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }

        //print(args.Snapshot.GetRawJsonValue());
        SpliString(args.Snapshot.GetRawJsonValue());
                       
        GameObject.FindGameObjectsWithTag("Product")[productImgNumber - 1].GetComponentInChildren<RawImage>().enabled = true;
        GameObject.FindGameObjectsWithTag("Product")[productImgNumber - 1].GetComponentInChildren<Image>().enabled = true;
        GetProductImage(strValue, GameObject.FindGameObjectsWithTag("Product")[productImgNumber - 1].GetComponentInChildren<RawImage>());
        
    }

    void PTitleHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        productTitleNumber++;
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        SpliString(args.Snapshot.GetRawJsonValue());
        
        GameObject.FindGameObjectsWithTag("Product")[productTitleNumber - 1].GetComponentsInChildren<Text>()[1].text = strValue;
    }

    void PPriceHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        productPriceNumber++;
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        SpliString(args.Snapshot.GetRawJsonValue());
        GameObject.FindGameObjectsWithTag("Product")[productPriceNumber - 1].GetComponentsInChildren<Text>()[0].enabled = true;
        GameObject.FindGameObjectsWithTag("Product")[productPriceNumber - 1].GetComponentsInChildren<Text>()[0].text = strValue;
        
    }

    public void BackButtonClick()
    {
        Application.LoadLevel("Home");
    }

    public void GamePlayButtonClick()
    {
        Application.LoadLevel("Game");
    }

    public void ShowGoogleMap()
    {
        #if UNITY_ANDROID
                Application.OpenURL("google.navigation:q=New+York+Time+Square");
        #elif UNITY_IOS
                Application.OpenURL("http://maps.apple.com/maps?saddr=Current+Location&daddr=New+York+Time+Square");
        #else
                Application.OpenURL("http://maps.google.com/maps?saddr=My+Location&daddr=New+York+Time+Square");
        #endif
    }

    public void SpliString(string str)
    {
        //char[] spearator = {':'};
        //string[] strlist = str.Split(spearator);        
        strValue = str.Substring(2, str.Length - 4);
        print(strValue);
    }
    
}
