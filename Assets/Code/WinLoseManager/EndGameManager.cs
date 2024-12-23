using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField] int Level;
    private int[] pointTarget;

    private SubstanceCounter subscount;
    public GameObject subscountObj;
    
    void Start()
    {
        //    get level current objective lose
        pointTarget = LevelMission.objective[Level];
        SubstanceCounter.OnCountedSubstance +=  CheckObjectiveLose;
        //    get level current objective for spawn limit good substance bro
        SubstanceCounter.OnSpawnGoodCountObject += SpawnLimitAndCheckFinal;
        
    }

    void CheckObjectiveLose(int IsSubstance, int howManyfinish)
    {
        // bad substance lose checking
        if(IsSubstance == 0 && howManyfinish == pointTarget[0])
        {
            Debug.Log("LOSE");
            Time.timeScale = 0;
        }
    }

    void SpawnLimitAndCheckFinal(int howManyGoodSpawn)
    {   
        //collect data how many good substance spawn
        // int GoodSpawns = LevelSpawn.SpawnHowMany[Level];
        
        // Debug.Log("CALLED" + " " + howManyGoodSpawn);
        //Jika stock spawn good habis maka stop game
        if(howManyGoodSpawn >= 5)
        {
            // Stop any spawn
            LevelSign.isStoppedSpawn = true;
            StartCoroutine(checkWinorLose(howManyGoodSpawn));
        }
    }

    IEnumerator checkWinorLose(int howManyGoodSpawn)
    {
        // tunggu yang spawn masuk gerbang semua
        yield return new WaitForSeconds(10);
        // get substanve counter class
        SubstanceCounter subscount = subscountObj.GetComponent<SubstanceCounter>();
        if(subscount.counterA >= howManyGoodSpawn)
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
