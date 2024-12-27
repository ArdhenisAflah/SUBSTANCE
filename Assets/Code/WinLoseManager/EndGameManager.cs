using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    private List<LevelObj> pointTarget;
    public GameObject subscountObj;
    [SerializeField] ScriptableObjectsLevelInformation levelInfo;
    
    void Start()
    {
        //    get level current objective losse
        pointTarget = levelInfo.LevelObjectives;
        SubstanceCounter.OnCountedSubstance +=  CheckObjectiveLose;
        //    get level current objective for spawn limit good substance bro
        SubstanceCounter.OnSpawnGoodCountObject += SpawnLimitAndCheckFinal;
        
    }

    void CheckObjectiveLose(int IsSubstance, int howManyfinish)
    {
        // bad substance lose checking
        if(IsSubstance == 0 && howManyfinish == pointTarget[0].badSubstanceMax)
        {
            Debug.Log("LOSE"); 
            Time.timeScale = 0;
        }
    }

    void SpawnLimitAndCheckFinal(int howManyGoodSpawn)
    {   
        //collect data how many good substance spawn
        //Jika stock spawn good habis maka stop game
        if(howManyGoodSpawn >= pointTarget[0].goodSubstanceStock)
        {
            // Stop any spawn
            levelInfo.isStoppedSpawn = true;
            StartCoroutine(checkWinorLose());
        }
    }

    IEnumerator checkWinorLose()
    {
        // tunggu yang spawn masuk gerbang semua
        yield return new WaitForSeconds(10);
        // get substanve counter class
        SubstanceCounter subscount = subscountObj.GetComponent<SubstanceCounter>();
        if(subscount.counterA >= pointTarget[0].goodSubstancePassGrade)
            {
                Debug.Log("WIN GOOD HABIS");
                Time.timeScale = 0;
            }else
            {
                Debug.Log("LOSE GOOD HABIS");
                Time.timeScale = 0;
            }
    }
}
