using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using Unity.Notifications.Android;

public class GameEngine : MonoBehaviour
{
    public static GameEngine Instance;
    public GameObject wolfPrefab;
    public GameObject cloudPrefab;
    public GameObject witchPrefab;
    public GameObject cornPrefab;
    public GameObject pumkinPrefab;
    public GameObject strawberryPrefab;
    public GameObject sCrownPrefab;
    public GameObject sPrefab;
    public GameObject pCrownPrefab;
    public GameObject pPrefab;
    public GameObject cCrownPrefab;
    public GameObject cPrefab;
    public GameObject targetGameObject;
    public DatabaseReference refGPS;
    public Camera ARCamera;
    public GameObject wolfAvatar;
    public GameObject cloudAvatar;
    public GameObject witchAvatar;
    public GameObject cornAvatar;
    public GameObject pumkinAvatar;
    public GameObject strawberryAvatar;
    public GameObject startGatePrefab;
    public GameObject endGatePrefab;
    public GameObject canvas;
    public GameObject[] snapChat;
    public GameObject[] snapRandomChat;
    public Image healthBar;
    public Text killedEnemyCountText;
    public int killedEnemyCount;
    public static bool isType;
    public Transform originTransform;
    public GameObject[] alerts;
    public GameObject NotificationText;


    public GameObject sCrownPrefab0;
    GameObject strawberryPrefab0;
    public GameObject pCrownPrefab0;
    GameObject pumkinPrefab0;
    public GameObject cCrownPrefab0;
    GameObject cornPrefab0;
    GameObject sPrefab0;
    GameObject cPrefab0;
    GameObject pPrefab0;
    GameObject startGatePrefab0;
    GameObject endGatePrefab0;
    GameObject refGameObject;
    string strValue;
    float gpsX;
    float gpsY;
    bool isGameStart;
    bool isFirstGamePlay;
    bool isInFrontGate;
    bool isInEndGate;
    bool isInGateDialog;
    bool isExitDialog;
    bool isMeetStrawberryKing;
    bool isMeetStrawberryKingDialog;
    bool isMeetCornKingDialog;
    bool isMeetPumkinDialog;
    bool isFindStrawberryCrown;
    bool isCornCrown;
    bool isPumkinCrown;
    bool isCreateStrawberryCrown;
    public static bool isCreatStrawberryKing;
    bool isCreateCornCrown;
    bool isCreatePumkinCrown;
    bool isCreateCornCharacter;
    bool isCreatePumkinCharacter;
    public static bool isFindPumkinCrown;
    public static bool isFindeCornCrown;
    bool isAllFound;
    bool isGameEnd;
    bool isPassedArc;
    bool isChanagableMessage;
    bool isOnlyOneTime;
    public bool isFirstMeetWolf;
    public bool isFirstMeetCloud;
    public bool isFirstMeetWitch;
    bool isSCrownDialog;
    bool isCCrownDialog;
    bool isPCrownDialog;
    public bool isSCrownClick;
    public bool isCCrownClick;
    public bool isPCrownClick;
    bool isReachedCorn;

    int playgroundScale = 20;
    int findCharacterCount;
    int currentEventDialogCount;
    float distance = 5f;

    public float latitude;
    public float longitude;

    public bool UseFakeLocation;

    [HideInInspector]
    public bool isRunning = true;

    [HideInInspector]
    public LocationServiceStatus ServiceStatus = LocationServiceStatus.Stopped;

    public Text latitudeText;
    public Text longitudeText;

    string Screen_Shot_File_Name;
    bool Shot_Taken;

    bool isWolfCreate;
    bool isWithchCreate;
    bool isCloudCreate;

    void Awake()
    {
        Instance = this;
    }

    private IEnumerator StartLocationService()
    {
        ServiceStatus = LocationServiceStatus.Initializing;
        // Allow a fake location to be returned when testing on a device that doesn't have GPS
        if (UseFakeLocation)
        {
            Debug.Log(string.Format("Using fake GPS location lat:{0} lon:{1}", latitude, longitude));
            ServiceStatus = LocationServiceStatus.Running;
            yield break;
        }

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("user has not enabled gps");
            yield break;
        }

        // Wait for the GPS to start up so there's time to connect
        Input.location.Start();

        yield return new WaitForSeconds(5);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed Out");
            yield break;
        }

        // If gps hasn't started by now, just give up
        ServiceStatus = Input.location.status;
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        //Loop forever to get GPS updates
        while (isRunning)
        {
            yield return new WaitForSeconds(2);
            UpdateGPS();
        }
    }

    private void UpdateGPS()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            latitudeText.text = "" + latitude;
            longitudeText.text = "" + longitude;

            ServiceStatus = Input.location.status;

            Debug.Log(string.Format("Lat: {0} Long: {1}", latitude, longitude));
        }
        else
        {
            Debug.Log("GPS is " + Input.location.status);
        }
    }

    void Start()
    {
        StartCoroutine(StartLocationService());
        canvas.GetComponent<Image>().enabled = false;
        //startGatePrefab0 = Instantiate(startGatePrefab, new Vector3(UnityEngine.Random.RandomRange(0f,1f) * playgroundScale, 0f, UnityEngine.Random.RandomRange(0f, 1f) * playgroundScale), Quaternion.identity);
        //startGatePrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
        //startGatePrefab0.SetActive(true);

        //endGatePrefab0 = Instantiate(startGatePrefab, new Vector3(UnityEngine.Random.RandomRange(0f, 1f) * playgroundScale, 0f, UnityEngine.Random.RandomRange(0f, 1f) * playgroundScale), Quaternion.identity);
        //endGatePrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
        //endGatePrefab0.SetActive(false);        
        isReachedCorn = true;
        isGameStart = true;
        isInFrontGate = true;
    }

    void Update()
    {
        if (isCCrownClick)
        {
            isCCrownClick = false;
            CornCrownClick();
        }
        else if (isSCrownClick)
        {
            isSCrownClick = false;
            StrawberryCrownClick();
        }
        else if (isPCrownClick)
        {
            isPCrownClick = false;
            PumkinCrownClick();
        }

        if (isGameStart)
        {
            latitudeText.text = "" + Input.location.lastData.latitude;
            longitudeText.text = "" + Input.location.lastData.longitude;

            if (Input.location.lastData.latitude < 45.251944f + 0.00015f && latitude > 45.251944f - 0.00015f && Input.location.lastData.longitude > -74.304722f - 0.00015f && Input.location.lastData.longitude < -74.304722f + 0.00015f && isReachedCorn)
            {
                isReachedCorn = false;
                isWithchCreate = true;
                isWolfCreate = true;
                isCloudCreate = true;
                SkipButtonClick();
            }

                if (Input.location.lastData.latitude < 45.251944f + 0.00007f && latitude > 45.251944f - 0.00007f && Input.location.lastData.longitude > -74.304722f - 0.00007f && Input.location.lastData.longitude < -74.304722f + 0.00007f && isInFrontGate)
            {
                isInFrontGate = false;

                snapChat[0].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[0].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[1];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[0].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[1];
                }
            }

            if (Input.location.lastData.latitude < 45.251944f + 0.00005f && Input.location.lastData.latitude > 45.251944f - 0.00005f && Input.location.lastData.longitude > -74.304722f - 0.00005f && Input.location.lastData.longitude < -74.304722f + 0.00005f)
            {
                alerts[0].SetActive(true);
                StartCoroutine("ShowNotification");
                isGameStart = false;
                isPassedArc = true;
                originTransform = targetGameObject.transform;
                startGatePrefab0.SetActive(false);
            }
        }

        if (Input.location.lastData.latitude < 45.253267f + 0.0001f && Input.location.lastData.latitude > 45.253267f - 0.0001f && Input.location.lastData.longitude > -74.303175f - 0.0001f && Input.location.lastData.longitude < -74.303175f + 0.0001f && isWolfCreate)
        {
            isOnlyOneTime = false;
            isWolfCreate = false;
            wolfPrefab = Instantiate(wolfPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
            wolfPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
            healthBar.enabled = true;
            healthBar.fillAmount = 1;
            healthBar.color = Color.green;
        }

        if (GameObject.FindGameObjectsWithTag("Wolf").Length > 0 && !isFirstMeetWolf)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Wolf").Length; i++)
            {
                if (!isFirstMeetWolf && Vector3.Distance(GameObject.FindGameObjectsWithTag("Wolf")[i].transform.position, targetGameObject.transform.position) < 5f)
                {
                    refGameObject = GameObject.FindGameObjectsWithTag("Wolf")[i];
                    refGameObject.GetComponent<EnemyAI>().enabled = false;
                    refGameObject.GetComponent<Animation>().Play("Talk");
                    isFirstMeetWolf = true;
                    snapChat[1].SetActive(true);
                    isType = true;
                    currentEventDialogCount = 17;

                    if (SplashScene.gameplayLang == "english")
                    {
                        snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[17];

                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[17];
                    }
                }
            }
        }

        if (Input.location.lastData.latitude < 45.253119f + 0.00010f && Input.location.lastData.latitude > 45.253119f - 0.00010f && Input.location.lastData.longitude > -74.3015f - 0.00010f && Input.location.lastData.longitude < -74.3015f + 0.00010f && isCloudCreate)
        {
            isCloudCreate = false;
            isOnlyOneTime = false;
            cloudPrefab = Instantiate(cloudPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
            cloudPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
            healthBar.enabled = true;
            healthBar.fillAmount = 1;
            healthBar.color = Color.green;
        }

        if (GameObject.FindGameObjectsWithTag("Cloud").Length > 0 && !isFirstMeetCloud)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Cloud").Length; i++)
            {
                if (!isFirstMeetCloud && Vector3.Distance(GameObject.FindGameObjectsWithTag("Cloud")[i].transform.position, targetGameObject.transform.position) < 5f)
                {

                    refGameObject = GameObject.FindGameObjectsWithTag("Cloud")[i];
                    refGameObject.GetComponent<EnemyAI>().enabled = false;
                    refGameObject.GetComponent<Animation>().Play("Talk");
                    isFirstMeetCloud = true;
                    snapChat[5].SetActive(true);
                    isType = true;
                    currentEventDialogCount = 46;

                    if (SplashScene.gameplayLang == "english")
                    {
                        snapChat[5].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[46];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        snapChat[5].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[46];
                    }
                }
            }
        }

        if (Input.location.lastData.latitude < 45.252294f + 0.00010f && Input.location.lastData.latitude > 45.252294f - 0.00010f && Input.location.lastData.longitude > -74.302828f - 0.00010f && Input.location.lastData.longitude < -74.302828f + 0.00010f && isWithchCreate)
        {
            isOnlyOneTime = false;
            isWithchCreate = false;
            witchPrefab = Instantiate(witchPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
            witchPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
            healthBar.enabled = true;
            healthBar.fillAmount = 1;
            healthBar.color = Color.green;
        }

        if (GameObject.FindGameObjectsWithTag("Witch").Length > 0)
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Witch").Length; i++)
            {
                if (!isFirstMeetWitch && Vector3.Distance(GameObject.FindGameObjectsWithTag("Witch")[i].transform.position, targetGameObject.transform.position) < 5f)
                {

                    refGameObject = GameObject.FindGameObjectsWithTag("Witch")[i];
                    refGameObject.GetComponent<EnemyAI>().enabled = false;
                    refGameObject.GetComponent<Animation>().Play("Talk");
                    isFirstMeetWitch = true;
                    snapChat[6].SetActive(true);
                    isType = true;
                    currentEventDialogCount = 66;

                    if (SplashScene.gameplayLang == "english")
                    {
                        snapChat[6].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[66];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        snapChat[6].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[66];
                    }
                }
            }
        }

        if (isPassedArc)
        {
            if (Input.location.lastData.latitude < 45.252136f + 0.00015f && Input.location.lastData.latitude > 45.252136f - 0.0001f && Input.location.lastData.longitude > -74.304031f - 0.0001f && Input.location.lastData.longitude < -74.304031f + 0.0001f)
            {
                isPassedArc = false;
                isFirstGamePlay = true;
                //isWolfCreate = true;
                sPrefab0 = Instantiate(sPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0.5f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
                sPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
                sPrefab0.transform.LookAt(targetGameObject.transform);
                //sPrefab0.GetComponent<CharacterAI>().enabled = false;
                sPrefab0.GetComponent<Animation>().Play("Scared");
            }               
        }
        
        if (isFirstGamePlay)
        {
            if (Vector3.Distance(sPrefab0.transform.position, targetGameObject.transform.position) < 5f && !isCreateStrawberryCrown)
            {                
                isMeetStrawberryKingDialog = true;
                isCreateStrawberryCrown = true;                         

                snapChat[1].SetActive(true);
                isType = true;
                currentEventDialogCount = 2;

                if (SplashScene.gameplayLang == "english")
                {                    
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[2];
                    
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[2];
                }

                sPrefab0.GetComponent<Animation>().Play("Talk");
            }

            if (isMeetStrawberryKing)
            {
                if (Input.location.lastData.latitude < 45.253839f + 0.0001f && Input.location.lastData.latitude > 45.253839f - 0.0001f && Input.location.lastData.longitude > -74.302225f - 0.0001f && Input.location.lastData.longitude < -74.302225f + 0.0001f)
                {
                    isMeetStrawberryKing = false;
                    isCreatStrawberryKing = true;                    
                    sCrownPrefab0 = Instantiate(sCrownPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 1f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
                    sCrownPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
                }
            }

            if (isCreatStrawberryKing)
            {                              
                if (GameObject.FindGameObjectsWithTag("S_Crown").Length == 1)
                {
                    if (Vector3.Distance(sCrownPrefab0.transform.position, targetGameObject.transform.position) < 5f && GameObject.FindGameObjectsWithTag("S_Crown").Length == 1)
                    {
                        isFindStrawberryCrown = true;
                        isCreatStrawberryKing = false;

                        snapChat[1].SetActive(true);
                        isType = true;
                        currentEventDialogCount = 28;

                        if (SplashScene.gameplayLang == "english")
                        {
                            snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[28];
                        }
                        else if (SplashScene.gameplayLang == "french")
                        {
                            snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[28];
                        }

                        sPrefab0.GetComponent<Animation>().Play("Talk");
                    }
                }                
            }           
        }

       

        if (isCreateCornCharacter)
        {
            if (Input.location.lastData.latitude < 45.253989f + 0.00015f && Input.location.lastData.latitude > 45.253989f - 0.00015f && Input.location.lastData.longitude > -74.301192f - 0.00015f && Input.location.lastData.longitude < -74.301192f + 0.00015f && isOnlyOneTime)
            {
                isOnlyOneTime = false;
                cPrefab0 = Instantiate(cPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0.5f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
                cPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
                cPrefab0.transform.LookAt(targetGameObject.transform);
                //cPrefab0.GetComponent<CharacterAI>().enabled = false;
                cPrefab0.GetComponent<Animation>().Play("Scared");
                //isCloudCreate = true;
            }               
            

            if (Vector3.Distance(cPrefab0.transform.position, targetGameObject.transform.position) < 5f)
            {                
                isMeetCornKingDialog = true;
                isCreateCornCharacter = false;
                cPrefab0.GetComponent<Animation>().Play("Talk");
                //cPrefab0.gameObject.transform.LookAt(targetGameObject.transform);

                snapChat[3].SetActive(true);
                isType = true;
                currentEventDialogCount = 35;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[35];                    
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[35];
                }
            }
        }       

        if (isCreateCornCrown)
        {
            if (Input.location.lastData.latitude < 45.252994f + 0.0001f && Input.location.lastData.latitude > 45.252994f - 0.0001f && Input.location.lastData.longitude > -74.302472f - 0.0001f && Input.location.lastData.longitude < -74.302472f + 0.0001f)
            {
                isCreateCornCrown = false;
                cCrownPrefab0 = Instantiate(cCrownPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 1f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
                cCrownPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
            }                            
        }
        

        if (isFindeCornCrown)
        {                        
            if (GameObject.FindGameObjectsWithTag("C_Crown").Length == 1)
            {
                if (Vector3.Distance(cCrownPrefab0.transform.position, targetGameObject.transform.position) < 5f && GameObject.FindGameObjectsWithTag("C_Crown").Length == 1)
                {
                    isCornCrown = true;
                    snapChat[3].SetActive(true);
                    isType = true;
                    currentEventDialogCount = 53;

                    if (SplashScene.gameplayLang == "english")
                    {
                        snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[53];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[53];
                    }

                    cPrefab0.GetComponent<Animation>().Play("Talk");
                    isFindeCornCrown = false;
                }
            }
            
        }

        if (isCreatePumkinCharacter)
        {
            if (Input.location.lastData.latitude < 45.252461f + 0.00010f && Input.location.lastData.latitude > 45.252461f - 0.00010f && Input.location.lastData.longitude > -74.302633f - 0.00010f && Input.location.lastData.longitude < -74.302633f + 0.00010f && isOnlyOneTime)
            {
                isOnlyOneTime = false;
                pPrefab0 = Instantiate(pPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0.5f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
                pPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
                //pPrefab0.GetComponent<CharacterAI>().enabled = false;
                pPrefab0.transform.LookAt(targetGameObject.transform);
                pPrefab0.GetComponent<Animation>().Play("Scared");
                //isWithchCreate = true;
            }                
            

            if (Vector3.Distance(pPrefab0.transform.position, targetGameObject.transform.position) < 5f)
            {
                isMeetPumkinDialog = true;
                isCreatePumkinCharacter = false;
                snapChat[2].SetActive(true);
                isType = true;
                currentEventDialogCount = 58;                

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[58];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[58];
                }
                
            }
        }

        if (isCreatePumkinCrown)
        {
            if (Input.location.lastData.latitude < 45.251819f + 0.00010f && Input.location.lastData.latitude > 45.251819f - 0.00010f && Input.location.lastData.longitude > -74.303453f - 0.00010f && Input.location.lastData.longitude < -74.303453f + 0.00010f)
            {
                pCrownPrefab0 = Instantiate(pCrownPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 1f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
                pCrownPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
                isCreatePumkinCrown = false;
            }                           
        }

        if (isFindPumkinCrown)
        {            
            if (GameObject.FindGameObjectsWithTag("P_Crown").Length == 1)
            {
                if (Vector3.Distance(pCrownPrefab0.transform.position, targetGameObject.transform.position) < 5f && GameObject.FindGameObjectsWithTag("P_Crown").Length == 1)
                {
                    isPumkinCrown = true;
                    snapChat[2].SetActive(true);
                    isType = true;
                    currentEventDialogCount = 71;

                    if (SplashScene.gameplayLang == "english")
                    {
                        snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[71];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[71];
                    }

                    isFindPumkinCrown = false;                    
                }
            }           
        }

        if (findCharacterCount == 3 && isGameEnd == false)
        {
            isAllFound = true;
            endGatePrefab0.SetActive(true);
        }

        if (isAllFound)
        {
            if (Input.location.lastData.latitude < 45.251617f + 0.00007f && Input.location.lastData.latitude > 45.251617f - 0.00007f && Input.location.lastData.longitude > -74.304042f - 0.00007f && Input.location.lastData.longitude < -74.304042f + 0.00007f && !isInEndGate)
            {
                alerts[1].SetActive(true);
                StartCoroutine("ShowNotification");
                isInEndGate = true;
                isInGateDialog = true;
                snapChat[1].SetActive(true);
                isType = true;
                currentEventDialogCount = 80;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[80];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[80];
                }
            }        

            if (isExitDialog)
            {
                if (Input.location.lastData.latitude < 45.243333f + 0.00005f && Input.location.lastData.latitude > 45.243333f - 0.00005f && Input.location.lastData.longitude > -74.283889f - 0.00005f && Input.location.lastData.longitude < -74.283889f + 0.00005f)
                {
                    snapChat[0].SetActive(true);
                    isType = true;

                    if (SplashScene.gameplayLang == "english")
                    {
                        snapChat[0].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[89];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        snapChat[0].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[89];
                    }

                    isGameEnd = true;
                    isAllFound = false;
                    endGatePrefab0.SetActive(false);
                    pumkinPrefab0.GetComponent<CharacterAI>().enabled = false;
                    cornPrefab0.GetComponent<CharacterAI>().enabled = false;
                    strawberryPrefab0.GetComponent<CharacterAI>().enabled = false;                   
                    pumkinPrefab0.GetComponent<Animation>().Play("Jump");
                    cornPrefab0.GetComponent<Animation>().Play("Jump");
                    strawberryPrefab0.GetComponent<Animation>().Play("Jump");
                }
            }            
        }
    }

    public void SkipButtonClick()
    {                
        snapChat[0].SetActive(true);
        isType = true;

        if (SplashScene.gameplayLang == "english")
        {
            //print(snapChat[0].GetComponentsInChildren<Text>()[0].text);
            snapChat[0].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[0];
        }
        else if (SplashScene.gameplayLang == "french")
        {
            snapChat[0].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[0];
        }        
    }

    GameObject GetClosestEnemy(List<GameObject> enemies, GameObject fromThis)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = fromThis.transform.position;
        foreach (GameObject potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;
    }

    public void WolfTouch()
    {
        
    }

    void GPSHandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        SpliString(args.Snapshot.GetRawJsonValue());
        

        cloudPrefab = Instantiate(cloudPrefab, new Vector3(50f * Math.Abs(gpsX) /360f, 0, 50f * Math.Abs(gpsY) / 360f), Quaternion.identity);
        cloudPrefab.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
        cloudPrefab.SetActive(true);
    }

    public void SpliString(string str)
    {               
        strValue = str.Substring(2, str.Length - 4);
        char[] spearator = {','};
        string[] strlist = strValue.Split(spearator);

        gpsX = float.Parse(strlist[0].Substring(1, strlist[0].Length - 1));
        gpsY = float.Parse(strlist[1].Substring(0, strlist[1].Length - 1));

        
    }

    public void SnapChatClick()
    {
        isChanagableMessage = true;

        if (isMeetStrawberryKingDialog)
        {
            if (currentEventDialogCount > 15)
            {
                isMeetStrawberryKingDialog = false;
                snapChat[1].SetActive(false);
                isMeetStrawberryKing = true;
                sPrefab0.GetComponent<CharacterAI>().enabled = true;
                sPrefab0.GetComponent<Animation>().enabled = true;
                sPrefab0.GetComponent<Animation>().Play("Talk");
            }
            else
            {
                currentEventDialogCount++;
                snapChat[1].SetActive(true);

                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else if (isFirstMeetWolf)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 27)
            {
                snapChat[1].SetActive(false);
                refGameObject.GetComponent<EnemyAI>().enabled = true;                                   
            }
            else if (currentEventDialogCount == 18 || currentEventDialogCount == 26)
            {
                isType = true;

                snapChat[1].SetActive(false);
                snapChat[4].SetActive(true);

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[4].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[4].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else
            {
                snapChat[4].SetActive(false);
                snapChat[1].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else if (isFindStrawberryCrown)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 34)
            {
                snapChat[1].SetActive(false);                             
            }
            else
            {
                snapChat[1].SetActive(true);

                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else if (isMeetCornKingDialog)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 45)
            {
                snapChat[3].SetActive(false);
                isMeetCornKingDialog = false;
                cPrefab0.GetComponent<Animation>().Play("Laugh");
                isFindeCornCrown = true;
                isOnlyOneTime = true;                
                cPrefab0.GetComponent<CharacterAI>().enabled = true;               
                isCreateCornCrown = true;
            }
            else if (currentEventDialogCount == 36 || currentEventDialogCount == 39 || currentEventDialogCount == 41)
            {
                snapChat[1].SetActive(true);
                snapChat[3].SetActive(false);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else
            {
                snapChat[3].SetActive(true);
                snapChat[1].SetActive(false);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else if (isFirstMeetCloud)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 52)
            {
                snapChat[3].SetActive(false);
                refGameObject.GetComponent<EnemyAI>().enabled = true;                           
            }
            else if (currentEventDialogCount == 47)
            {
                snapChat[1].SetActive(true);
                snapChat[5].SetActive(false);

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 48)
            {
                snapChat[1].SetActive(false);
                snapChat[5].SetActive(true);

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[5].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[5].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else
            {
                snapChat[5].SetActive(false);
                snapChat[3].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else if (isCornCrown)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 57)
            {
                isFindeCornCrown = false;
                isCornCrown = false;
                snapChat[3].SetActive(false);                
            }
            else
            {
                snapChat[3].SetActive(true);

                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else if (isMeetPumkinDialog)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 65)
            {
                isMeetPumkinDialog = false;
                snapChat[2].SetActive(false);
                isCreatePumkinCrown = true;
                isFindPumkinCrown = true;
                isOnlyOneTime = true;
                pPrefab0.GetComponent<CharacterAI>().enabled = true;
                pPrefab0.GetComponent<Animation>().Play("Laugh");                
            }
            else if (currentEventDialogCount == 60)
            {
                snapChat[3].SetActive(true);
                snapChat[2].SetActive(false);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 63)
            {
                snapChat[3].SetActive(true);
                snapChat[2].SetActive(false);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 61)
            {
                snapChat[1].SetActive(true);
                snapChat[3].SetActive(false);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else
            {
                snapChat[2].SetActive(true);
                snapChat[1].SetActive(false);
                snapChat[3].SetActive(false);

                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else if (isFirstMeetWitch)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 70)
            {
                snapChat[1].SetActive(false);
                refGameObject.GetComponent<EnemyAI>().enabled = true;                
            }
            else if (currentEventDialogCount == 67)
            {
                snapChat[2].SetActive(true);
                snapChat[6].SetActive(false);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 69)
            {
                snapChat[6].SetActive(false);
                snapChat[3].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 70)
            {
                snapChat[3].SetActive(false);
                snapChat[1].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if(currentEventDialogCount == 68)
            {
                snapChat[2].SetActive(false);
                snapChat[6].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[6].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[68];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[6].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[68];
                }
            }
        }
        else if (isPumkinCrown)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 79)
            {
                isPumkinCrown = false;
                snapChat[2].SetActive(false);             
            }
            else if (currentEventDialogCount == 72)
            {
                snapChat[2].SetActive(false);
                snapChat[3].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 73)
            {
                snapChat[3].SetActive(false);
                snapChat[1].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 75)
            {
                snapChat[2].SetActive(false);
                snapChat[1].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 76)
            {
                snapChat[1].SetActive(false);
                snapChat[3].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else
            {
                snapChat[2].SetActive(true);
                snapChat[3].SetActive(false);
                snapChat[1].SetActive(false);

                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else if (isInGateDialog)
        {
            currentEventDialogCount++;

            if (currentEventDialogCount > 88)
            {
                isExitDialog = true;
                snapChat[2].SetActive(false);
            }
            else if (currentEventDialogCount == 82 || currentEventDialogCount == 84 || currentEventDialogCount == 88)
            {
                snapChat[3].SetActive(false);
                snapChat[2].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[2].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
            else if (currentEventDialogCount == 86)
            {
                snapChat[3].SetActive(false);
                snapChat[1].SetActive(true);
                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[1].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }            
            else
            {
                snapChat[3].SetActive(true);
                snapChat[2].SetActive(false);
                snapChat[1].SetActive(false);

                isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogE[currentEventDialogCount];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    snapChat[3].GetComponentsInChildren<Text>()[0].text = Strings.eventDialogF[currentEventDialogCount];
                }
            }
        }
        else
        {
            snapChat[0].SetActive(false);
        }

    }

    public void CaptureButtonClick()
    {
        NotificationText.SetActive(true);
        StartCoroutine("ShowNotification");
        Screen_Shot_File_Name = "Screenshot__" + System.DateTime.Now.ToString("__yyyy-MM-dd") + ".png";
        ScreenCapture.CaptureScreenshot(Screen_Shot_File_Name);
        Shot_Taken = true;

    }

    IEnumerator ShowNotification()
    {
        yield return new WaitForSeconds(3f);

        NotificationText.SetActive(false);
        alerts[0].SetActive(false);
        alerts[1].SetActive(false);

        if (Shot_Taken == true)
        {
            string Origin_Path = System.IO.Path.Combine(Application.persistentDataPath, Screen_Shot_File_Name);
            // This is the path of my folder.
            string Path = "/mnt/sdcard/DCIM/" + Screen_Shot_File_Name;
            if (System.IO.File.Exists(Origin_Path))
            {
                System.IO.File.Move(Origin_Path, Path);
                Shot_Taken = false;
            }
        }
            
    }

    public void StrawberryCrownClick()
    {
        Destroy(sPrefab0);
        Destroy(sCrownPrefab0);
        isFindStrawberryCrown = false;        
        isFirstGamePlay = false;
        isOnlyOneTime = true;
        strawberryPrefab0 = Instantiate(strawberryPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
        strawberryPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
        strawberryPrefab0.GetComponent<Animation>().Play("Crown");        
        strawberryAvatar.SetActive(false);
        findCharacterCount++;
        isCreateCornCharacter = true;
        isCreatStrawberryKing = false;
    }

    public void CornCrownClick()
    {
        Destroy(cPrefab0);
        Destroy(cCrownPrefab0);
        isOnlyOneTime = true;        
        cornPrefab0 = Instantiate(cornPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
        cornPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
        cornPrefab0.GetComponent<Animation>().Play("Crown");
        cornAvatar.SetActive(false);
        findCharacterCount++;
        isCreatePumkinCharacter = true;        
    }

    public void PumkinCrownClick()
    {
        Destroy(pPrefab0);
        Destroy(pCrownPrefab0);
        isOnlyOneTime = true;
        pumkinPrefab0 = Instantiate(pumkinPrefab, new Vector3(targetGameObject.transform.forward.x * distance + targetGameObject.transform.position.x, 0f, targetGameObject.transform.forward.z * distance + targetGameObject.transform.position.z), Quaternion.identity);
        pumkinPrefab0.transform.SetParent(GameObject.FindGameObjectWithTag("PlayGround").transform, false);
        pumkinPrefab0.GetComponent<Animation>().Play("Crown");
        pumkinAvatar.SetActive(false);
        findCharacterCount++;
    }
}
