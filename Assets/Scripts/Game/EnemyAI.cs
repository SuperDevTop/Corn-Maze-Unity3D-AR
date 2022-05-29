using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public static EnemyAI Instance;
    public GameObject targetGameObject;
    public GameObject bloodEffect;    
    //public GameObject[] snapRandomChat;
    bool isDetectable;
    float angle;
    bool isAttack;
    bool isHit;
    bool isDie;
    int HitCount;

    bool isEnemyNearbyDialog;
    bool isEnemyFollowDialog;
    bool isEnemyDieDialog;
    bool isNearby;
    bool isFollow;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {                                    
        targetGameObject = GameObject.FindGameObjectWithTag("MainCamera");
        bloodEffect = GameObject.FindGameObjectWithTag("Blood");        
    }   

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) > 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 2000f)
        {
            this.GetComponent<Animation>().Play("Look");
        }

        if (Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) > 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 20f)
        {
            isEnemyNearbyDialog = true;
            isEnemyFollowDialog = false;
            isEnemyDieDialog = false;
        }
        else if (Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) > 3f)
        {
            isEnemyNearbyDialog = false;
            isEnemyFollowDialog = true;
            isEnemyDieDialog = false;
        }

        if (Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 10f && Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) > 1.5f)
        {
            isDetectable = true;
            isAttack = false;            
        }
        else
        {
            isDetectable = false;
            isAttack = false;
            
        }

        if (Vector3.Distance(this.gameObject.transform.position, targetGameObject.transform.position) < 1.5f)
        {
            isAttack = true;
            isDetectable = false;                       
        }

        if (isDetectable && !isHit)
        {
            bloodEffect.GetComponent<Image>().enabled = false;
            this.gameObject.transform.LookAt(targetGameObject.transform);
            this.GetComponent<Animation>().Play("Look");
            angle = Mathf.Atan((targetGameObject.transform.position.z - this.gameObject.transform.position.z) / (targetGameObject.transform.position.x - this.gameObject.transform.position.x)) * 180 / 3.14f;
            this.transform.position = new Vector3(this.gameObject.transform.position.x + 0.02f * Mathf.Cos(angle), 0, this.gameObject.transform.position.z + 0.02f * Mathf.Sin(angle));
            //print(this.transform.position.x);
            //print(this.transform.position.z);
            //StartCoroutine(MoveToTarget());
        }

        if (isAttack && !isHit)
        {            
            this.GetComponent<Animation>().Play("Attack");
            bloodEffect.GetComponent<Image>().enabled = true;
        }

        if (isHit && this.GetComponent<Animation>().isPlaying == false)
        {
            bloodEffect.GetComponent<Image>().enabled = false;
            isHit = false;
        }

        if (isDie && this.GetComponent<Animation>().isPlaying == false)
        {
            bloodEffect.GetComponent<Image>().enabled = false;
            Destroy(this.gameObject);
        }                
        //print("Detect:" + isDetectable);
        //print("Attack:" + isAttack);
    }

    IEnumerator MoveToTarget()
    {
        yield return new WaitForSeconds(0.1f);        
    }

    public void Hit()
    {
        if (isAttack && !isDie)
        {
            HitCount++;
            isHit = true;
            this.GetComponent<Animation>().Play("Hit");
            HealthBarHandler.Instance.SetHealthBarValue(1f - 0.1f * HitCount);
        }        
        else if (isEnemyFollowDialog && !isDie)
        {
            if (this.gameObject.tag == "Wolf")
            {
                int index = RandFunction.RandSelect(new List<int>() { 48, 49, 50 });
                GameEngine.Instance.snapRandomChat[3].SetActive(true);

                GameEngine.isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    GameEngine.Instance.snapRandomChat[3].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    GameEngine.Instance.snapRandomChat[3].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                }
            }
            else if (this.gameObject.tag == "Cloud")
            {
                int index = RandFunction.RandSelect(new List<int>() { 54, 55, 56 });
                GameEngine.Instance.snapRandomChat[4].SetActive(true);

                GameEngine.isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    GameEngine.Instance.snapRandomChat[4].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    GameEngine.Instance.snapRandomChat[4].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                }
            }
            else if (this.gameObject.tag == "Witch")
            {
                int index = RandFunction.RandSelect(new List<int>() { 60, 61});
                GameEngine.Instance.snapRandomChat[5].SetActive(true);

                GameEngine.isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    GameEngine.Instance.snapRandomChat[5].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    GameEngine.Instance.snapRandomChat[5].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                }
            }
        }

        if (HitCount == 10 && !isDie)
        {
            this.GetComponent<Animation>().Play("Die");                        
            isDie = true;
            isEnemyNearbyDialog = false;
            isEnemyFollowDialog = false;
            isEnemyDieDialog = true;
            GameEngine.Instance.healthBar.enabled = false;


            for (int i = 0; i < GameEngine.Instance.snapRandomChat.Length; i++)
            {
                GameEngine.Instance.snapRandomChat[i].SetActive(false);
            }

            if (this.gameObject.tag == "Wolf")
            {
                int index = RandFunction.RandSelect(new List<int>() { 51, 52, 53 });
                GameEngine.Instance.snapRandomChat[3].SetActive(true);

                GameEngine.isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    GameEngine.Instance.snapRandomChat[3].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    GameEngine.Instance.snapRandomChat[3].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                }
            }
            else if (this.gameObject.tag == "Cloud")
            {
                int index = RandFunction.RandSelect(new List<int>() { 57, 58, 59 });
                GameEngine.Instance.snapRandomChat[4].SetActive(true);

                GameEngine.isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    GameEngine.Instance.snapRandomChat[4].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    GameEngine.Instance.snapRandomChat[4].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                }
            }
            else if (this.gameObject.tag == "Witch")
            {
                int index = RandFunction.RandSelect(new List<int>() { 62, 63, 64 });
                GameEngine.Instance.snapRandomChat[5].SetActive(true);

                GameEngine.isType = true;

                if (SplashScene.gameplayLang == "english")
                {
                    GameEngine.Instance.snapRandomChat[5].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogE[index];
                }
                else if (SplashScene.gameplayLang == "french")
                {
                    GameEngine.Instance.snapRandomChat[5].GetComponentsInChildren<Text>()[0].text = Strings.randomDialogF[index];
                }
            }

            if (this.gameObject.tag == "Wolf")
            {
                GameEngine.Instance.wolfAvatar.SetActive(true);
            } 
            else if (this.gameObject.tag == "Cloud")
            {
                GameEngine.Instance.cloudAvatar.SetActive(true);
            }
            else if (this.gameObject.tag == "Witch")
            {
                GameEngine.Instance.witchAvatar.SetActive(true);
            }

            GameEngine.Instance.killedEnemyCount++;
            GameEngine.Instance.killedEnemyCountText.text = "" + GameEngine.Instance.killedEnemyCount;
        }         
    }
}
