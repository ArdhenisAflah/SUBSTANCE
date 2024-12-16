using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstanceSpawner : MonoBehaviour
{
    public Transform spawnPosition;
    private float timeUntilSpawn;

    [SerializeField] float minimumTimeSpawn;
    [SerializeField] float maximumTimeSpawn;
    // Start is called before the first frame update
    //create mini update loop with ienumerator
    void Start()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <= 0){
            GameObject substance = SubstancePool.SharedInstance.GetSubstance();
            substance.transform.position = spawnPosition.position;
            substance.SetActive(true);
            SetTimeUntilSpawn();
        }
        
    }

    void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumTimeSpawn,maximumTimeSpawn);
    }
}
