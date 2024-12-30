using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] ScriptableObjectsLevelInformation levelInfo;
    [SerializeField] UIManager uiManager;
    private int HealthLevel;
    public 
    // Start is called before the first frame update
    void Start()
    {
        SubstanceCounter.OnCountedSubstance += VirusDamageUI;
    }

    void OnDisable ()
    {
        SubstanceCounter.OnCountedSubstance += VirusDamageUI;
    }

    void VirusDamageUI(int substanceType, int howMany)
    {
        // get health per level ini
        HealthLevel = levelInfo.Level;
        if(substanceType == 0)
        {
            uiManager.OnBadEnter();
        }
        else if(substanceType == 1)
        {
            uiManager.OnGoodEnter();
        }
    }
}
