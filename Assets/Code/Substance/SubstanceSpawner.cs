using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceSpawner : MonoBehaviour
{

    public float SubstanceTimeUntilSpawn;
    public float BadSubstanceTimeUntilSpawn;

    [SerializeField] float SubstanceMinimumTimeSpawn;
    [SerializeField] float SubstanceMaximumTimeSpawn;

    [SerializeField] float BadSubstanceMinimumTimeSpawn;
    [SerializeField] float BadSubstanceMaximumTimeSpawn;

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
                yield return new WaitForSeconds(SubstanceTimeUntilSpawn);
                GameObject substance = SubstancePool.SharedInstance.GetSubstance();
                substance.SetActive(true);
            }
            else
            {
                yield return new WaitForSeconds(BadSubstanceTimeUntilSpawn);
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

        SubstanceTimeUntilSpawn = Random.Range(SubstanceMinimumTimeSpawn,SubstanceMaximumTimeSpawn);
        BadSubstanceTimeUntilSpawn = Random.Range(BadSubstanceMinimumTimeSpawn, BadSubstanceMaximumTimeSpawn);
    }
}
