using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScene : MonoBehaviour
{
    public GameObject frenchObject;
    public GameObject englishObject;
    public GameObject touchObject;

    public void CornMazeLogoClick()
    {
        Application.LoadLevel("Game");
    }

    public void CitrouillevilleLogoClick()
    {
        Application.LoadLevel("Citrouilleville Info");
    }

    public void FrenchClick()
    {
        SplashScene.gameplayLang = "french";
    }

    public void EnglishClick()
    {
        SplashScene.gameplayLang = "english";
    }

    private void Start()
    {
        StartCoroutine("Delay");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.7f);

        frenchObject.SetActive(true);
        englishObject.SetActive(true);
        touchObject.SetActive(true);
    }
}
