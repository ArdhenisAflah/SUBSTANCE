using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceSpawner : MonoBehaviour
{

    public ScriptableObjectsLevelInformation levelInfo;

    private float SpawnBadorGood;
    // Start is called before the first frame update
    // UNCOMPLETE CODE (WARNING) FOR BAD AND GOOD SUBSTANCE
    void Start()
    {
        levelInfo.isStoppedSpawn = false;
        SetTimeUntilSpawn();
        StartCoroutine(SpawnEntity());
    }

    IEnumerator SpawnEntity()
    {
        while(levelInfo.isStoppedSpawn == false)
        {
            if(SpawnBadorGood <= 0.75)
            {
                yield return new WaitForSeconds(levelInfo.LevelTimeSpawns[0].SubstanceTimeUntilSpawn);
                GameObject substance = SubstancePool.SharedInstance.GetSubstance();
                substance.SetActive(true);
            }
            else
            {
                yield return new WaitForSeconds(levelInfo.LevelTimeSpawns[0].BadSubstanceTimeUntilSpawn);
                GameObject bdsubstance = SubstancePool.SharedInstance.GetBadSubstance();
                bdsubstance.SetActive(true);
            }
            SetTimeUntilSpawn();
        }
    }
    void SetTimeUntilSpawn()
    {
        // chance of getting bad or good substance
        SpawnBadorGood = Random.Range(0f, 1f);

        levelInfo.LevelTimeSpawns[0].SubstanceTimeUntilSpawn = Random.Range(levelInfo.LevelTimeSpawns[0].SubstanceMinimumTimeSpawn,levelInfo.LevelTimeSpawns[0].SubstanceMaximumTimeSpawn);
        levelInfo.LevelTimeSpawns[0].BadSubstanceTimeUntilSpawn = Random.Range(levelInfo.LevelTimeSpawns[0].BadSubstanceMinimumTimeSpawn, levelInfo.LevelTimeSpawns[0].BadSubstanceMaximumTimeSpawn);
    }
}
