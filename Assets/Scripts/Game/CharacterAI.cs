using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAI : MonoBehaviour
{
    public GameObject targetGameObject;
    bool isDetectable;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        targetGameObject = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        print(Vector2.Distance(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.z), new Vector2(targetGameObject.transform.position.x, targetGameObject.transform.position.z)));
        if (Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 1000f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) > 5f)
        {
            isDetectable = true;            
        }
        else
        {
            isDetectable = false;            

        }

        if (Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 5f)
        {           
            isDetectable = false;
        }

        if (isDetectable)
        {
            this.GetComponent<Animation>().Play("Scared");
            this.gameObject.transform.LookAt(targetGameObject.transform);
            //this.GetComponent<Animation>().Play("Scared");
            angle = Mathf.Atan((targetGameObject.transform.position.z - this.gameObject.transform.position.z) / (targetGameObject.transform.position.x - this.gameObject.transform.position.x)) * 180 / 3.14f;
            this.transform.position = new Vector3(this.gameObject.transform.position.x + 0.1f * Mathf.Cos(angle), 0, this.gameObject.transform.position.z + 0.1f * Mathf.Sin(angle));
            //print(this.transform.position.x);
            //print(this.transform.position.z);
            //StartCoroutine(MoveToTarget());
        }
    }

    public void CharacterClick()
    {
        this.GetComponent<Animation>().Play("Talk");

        for (int i = 0; i < GameEngine.Instance.snapRandomChat.Length; i++)
        {
            GameEngine.Instance.snapRandomChat[i].SetActive(false);
        }

        if (this.gameObject.tag == "Strawberry")
        {
            if (GameEngine.isCreatStrawberryKing)
            {
                if (Vector3.Distance(GameEngine.Instance.sCrownPrefab0.transform.position, targetGameObject.transform.position) > 3f && Vector3.Distance(GameEngine.Instance.sCrownPrefab0.transform.position, targetGameObject.transform.position) < 10f)
                {
                    int index = RandFunction.RandSelect(new List<int>() { 13, 14, 15 });
                    GameEngine.Instance.snapRandomChat[0].SetActive(true);

                    GameEngine.isType = true;

                    if (SplashScene.gameplayLang == "english")
                    {
                        GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                    }
                }
                else if (GameObject.FindGameObjectsWithTag("Wolf").Length > 0)
                {
                    for (int i = 0; i < GameObject.FindGameObjectsWithTag("Wolf").Length; i++)
                    {
                        if (Vector3.Distance(GameObject.FindGameObjectsWithTag("Wolf")[i].transform.position, targetGameObject.transform.position) > 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 20f)
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 4, 5, 6, 7, 8, 9 });
                            GameEngine.Instance.snapRandomChat[0].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }
                        else if (Vector3.Distance(GameObject.FindGameObjectsWithTag("Wolf")[i].transform.position, targetGameObject.transform.position) < 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) > 3f)
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 10, 11, 12 });

                            GameEngine.Instance.snapRandomChat[0].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }
                        else
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 0, 1, 2, 3 });
                            GameEngine.Instance.snapRandomChat[0].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }
                    }                    
                }
                else
                {
                    int index = RandFunction.RandSelect(new List<int>() { 0, 1, 2, 3 });
                    GameEngine.Instance.snapRandomChat[0].SetActive(true);

                    GameEngine.isType = true;

                    if (SplashScene.gameplayLang == "english")
                    {
                        GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        GameEngine.Instance.snapRandomChat[0].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                    }
                }

                
            }
        }
        else if (this.gameObject.tag == "Corn")
        {
            if (GameEngine.isFindeCornCrown)
            {
                if (Vector3.Distance(GameEngine.Instance.cCrownPrefab0.transform.position, targetGameObject.transform.position) > 3f && Vector3.Distance(GameEngine.Instance.cCrownPrefab0.transform.position, targetGameObject.transform.position) < 10f)
                {
                    int index = RandFunction.RandSelect(new List<int>() { 29, 30, 31 });
                    GameEngine.Instance.snapRandomChat[1].SetActive(true);

                    GameEngine.isType = true;

                    if (SplashScene.gameplayLang == "english")
                    {
                        GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                    }
                }
                else if (GameObject.FindGameObjectsWithTag("Cloud").Length > 0)
                {
                    for (int i = 0; i < GameObject.FindGameObjectsWithTag("Cloud").Length; i++)
                    {
                        if (Vector3.Distance(GameObject.FindGameObjectsWithTag("Cloud")[i].transform.position, targetGameObject.transform.position) > 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 20f)
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 20, 21, 22, 23, 24, 25 });
                            GameEngine.Instance.snapRandomChat[1].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }
                        else if (Vector3.Distance(GameObject.FindGameObjectsWithTag("Cloud")[i].transform.position, targetGameObject.transform.position) < 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) > 3f)
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 26, 27, 28 });

                            GameEngine.Instance.snapRandomChat[1].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }                       
                        else
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 16, 17, 18, 19 });
                            GameEngine.Instance.snapRandomChat[1].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }
                    }
                }
                else
                {
                    int index = RandFunction.RandSelect(new List<int>() { 16, 17, 18, 19 });
                    GameEngine.Instance.snapRandomChat[1].SetActive(true);

                    GameEngine.isType = true;

                    if (SplashScene.gameplayLang == "english")
                    {
                        GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        GameEngine.Instance.snapRandomChat[1].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                    }
                }
                
                
            }
        }
        else if (this.gameObject.tag == "Pumkin")
        {
            if (GameEngine.isFindPumkinCrown)
            {
                if (Vector3.Distance(GameEngine.Instance.pCrownPrefab0.transform.position, targetGameObject.transform.position) > 3f && Vector3.Distance(GameEngine.Instance.pCrownPrefab0.transform.position, targetGameObject.transform.position) < 10f)
                {
                    int index = RandFunction.RandSelect(new List<int>() { 45, 46, 47 });
                    GameEngine.Instance.snapRandomChat[2].SetActive(true);

                    GameEngine.isType = true;

                    if (SplashScene.gameplayLang == "english")
                    {
                        GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                    }
                }
                else if (GameObject.FindGameObjectsWithTag("Witch").Length > 0)
                {
                    for (int i = 0; i < GameObject.FindGameObjectsWithTag("Witch").Length; i++)
                    {
                        if (Vector3.Distance(GameObject.FindGameObjectsWithTag("Witch")[i].transform.position, targetGameObject.transform.position) > 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 20f)
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 36, 37, 38, 39, 40, 41 });
                            GameEngine.Instance.snapRandomChat[2].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }
                        else if (Vector3.Distance(GameObject.FindGameObjectsWithTag("Witch")[i].transform.position, targetGameObject.transform.position) < 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) > 3f)
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 42, 43, 44 });

                            GameEngine.Instance.snapRandomChat[2].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }                        
                        else
                        {
                            int index = RandFunction.RandSelect(new List<int>() { 32, 33, 34, 35 });
                            GameEngine.Instance.snapRandomChat[2].SetActive(true);

                            GameEngine.isType = true;

                            if (SplashScene.gameplayLang == "english")
                            {
                                GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                            }
                            else if (SplashScene.gameplayLang == "french")
                            {
                                GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                            }

                            break;
                        }
                    }
                }
                else
                {
                    int index = RandFunction.RandSelect(new List<int>() { 32, 33, 34, 35 });
                    GameEngine.Instance.snapRandomChat[2].SetActive(true);

                    GameEngine.isType = true;

                    if (SplashScene.gameplayLang == "english")
                    {
                        GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                    }
                    else if (SplashScene.gameplayLang == "french")
                    {
                        GameEngine.Instance.snapRandomChat[2].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                    }
                }                
            }
        }
    }
}
