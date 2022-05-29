using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public enum GameLevel
{
    Easy,
    Normal,
    Hard
}
public class GameScene : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject playerPrefab;
    public GameObject[] playerInfos;
    public Transform playerContent;
    public GameObject content;
    public static GameLevel gameLevel;
    public Text ageText;
    public Text[] text;
    public Text[] textPlayers;
    public Text[] textNames;
    public Text[] textAges;
    public Text[] textGameStory;
    public Text[] textHowTo;
    public Text[] textNext;
    public Text[] textSkip;
    int userCount;

    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
        }

        //SplashScene.gameplayLang = "english";
        Strings.AddString();

        if (SplashScene.gameplayLang == "english")
        {
            //print(Strings.mainPanelE.Count);

            for (int i = 0; i < text.Length; i++)
            {
                text[i].text = Strings.gamePanelE[i];
            }

            for (int i = 0; i < textPlayers.Length; i++)
            {
                textPlayers[i].text = Strings.playerInfoE[0];
            }

            for (int i = 0; i < textNames.Length; i++)
            {
                textNames[i].text = Strings.playerInfoE[1];
            }

            for (int i = 0; i < textAges.Length; i++)
            {
                textAges[i].text = Strings.playerInfoE[2];
            }

            for (int i = 0; i < textGameStory.Length; i++)
            {
                textGameStory[i].text = Strings.gamestoryE[i];
            }

            for (int i = 0; i < textHowTo.Length; i++)
            {
                textHowTo[i].text = Strings.howtoE[0];
            }

            for (int i = 0; i < textNext.Length; i++)
            {
                textNext[i].text = Strings.gamePanelE[6];
            }

            for (int i = 0; i < textSkip.Length; i++)
            {
                textSkip[i].text = Strings.howtoE[1];
            }

        }
        else if (SplashScene.gameplayLang == "french")
        {
            for (int i = 0; i < text.Length; i++)
            {
                text[i].text = Strings.gamePanelF[i];
            }

            for (int i = 0; i < textPlayers.Length; i++)
            {
                textPlayers[i].text = Strings.playerInfoF[0];
            }

            for (int i = 0; i < textNames.Length; i++)
            {
                textNames[i].text = Strings.playerInfoF[1];
            }

            for (int i = 0; i < textAges.Length; i++)
            {
                textAges[i].text = Strings.playerInfoF[2];
            }

            for (int i = 0; i < textGameStory.Length; i++)
            {
                textGameStory[i].text = Strings.gamestoryF[i];
            }

            for (int i = 0; i < textHowTo.Length; i++)
            {
                textHowTo[i].text = Strings.howtoF[0];
            }

            for (int i = 0; i < textNext.Length; i++)
            {
                textNext[i].text = Strings.gamePanelF[6];
            }

            for (int i = 0; i < textSkip.Length; i++)
            {
                textSkip[i].text = Strings.howtoF[1];
            }
        }
    }

    void Update()
    {                

        //print(122131);
        if (part2.active)
        {
            //print(1231231);
            if (Input.GetKeyDown("enter"))
            {                
                part2.SetActive(false);
                part3.SetActive(true);
            }
        }
    }

    public void AddPlayerInfo()
    {
        //content.GetComponent<VerticalLayoutGroup>().enabled = true;
        userCount++;
        //GameObject newPlayerContent = Instantiate(playerPrefab, playerContent);
        //newPlayerContent.transform.SetSiblingIndex(0);
        //newPlayerContent.GetComponentsInChildren<Text>()[0].text = "" + (userCount + 1);       
        playerInfos[userCount].SetActive(true);      
    }

    public void NextButtonClick()
    {
        if (System.Int32.Parse(ageText.text) < 5)
        {

        }
        else
        {
            if (System.Int32.Parse(ageText.text) >= 5 && System.Int32.Parse(ageText.text) <= 14)
            {
                gameLevel = GameLevel.Easy;
            }
            else if (System.Int32.Parse(ageText.text) < 17 && System.Int32.Parse(ageText.text) > 14)
            {
                gameLevel = GameLevel.Normal;
            }
            else if (System.Int32.Parse(ageText.text) > 16)
            {
                gameLevel = GameLevel.Hard;
            }

            part1.SetActive(false);
            part2.SetActive(true);
        }        
    }

    public void FrenchClick()
    {
        SplashScene.gameplayLang = "french";

        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = Strings.gamePanelF[i];
        }

        for (int i = 0; i < textPlayers.Length; i++)
        {
            textPlayers[i].text = Strings.playerInfoF[0];
        }

        for (int i = 0; i < textNames.Length; i++)
        {
            textNames[i].text = Strings.playerInfoF[1];
        }

        for (int i = 0; i < textAges.Length; i++)
        {
            textAges[i].text = Strings.playerInfoF[2];
        }

        for (int i = 0; i < textGameStory.Length; i++)
        {
            textGameStory[i].text = Strings.gamestoryF[i];
        }

        for (int i = 0; i < textHowTo.Length; i++)
        {
            textHowTo[i].text = Strings.howtoF[0];
        }

        for (int i = 0; i < textNext.Length; i++)
        {
            textNext[i].text = Strings.gamePanelF[6];
        }

        for (int i = 0; i < textSkip.Length; i++)
        {
            textSkip[i].text = Strings.howtoF[1];
        }
    }

    public void EnglishClick()
    {
        SplashScene.gameplayLang = "english";

        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = Strings.gamePanelE[i];
        }

        for (int i = 0; i < textPlayers.Length; i++)
        {
            textPlayers[i].text = Strings.playerInfoE[0];
        }

        for (int i = 0; i < textNames.Length; i++)
        {
            textNames[i].text = Strings.playerInfoE[1];
        }

        for (int i = 0; i < textAges.Length; i++)
        {
            textAges[i].text = Strings.playerInfoE[2];
        }

        for (int i = 0; i < textGameStory.Length; i++)
        {
            textGameStory[i].text = Strings.gamestoryE[i];
        }

        for (int i = 0; i < textHowTo.Length; i++)
        {
            textHowTo[i].text = Strings.howtoE[0];
        }

        for (int i = 0; i < textNext.Length; i++)
        {
            textNext[i].text = Strings.gamePanelE[6];
        }

        for (int i = 0; i < textSkip.Length; i++)
        {
            textSkip[i].text = Strings.howtoE[1];
        }
    }
}
