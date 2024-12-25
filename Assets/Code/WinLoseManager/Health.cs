using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private EndGameManager GameManager;
    private int HealthLevel;
    // Start is called before the first frame update
    void Start()
    {
        SubstanceCounter.OnCountedSubstance += VirusDamageUI;
        GameManager = GetComponent<EndGameManager>();
    }

    void OnDisable ()
    {
        SubstanceCounter.OnCountedSubstance += VirusDamageUI;
    }

    void VirusDamageUI(int substanceType, int howMany)
    {
        // get health per level ini
        HealthLevel = GameManager.Level;
        if(substanceType == 0)
        {
            // notifikasi UI
            Debug.Log("Darah berkurang");
        }
    }
}
