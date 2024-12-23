using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class SubstanceCounter : MonoBehaviour
{
    public int counterB;
    public int counterA;

    public int counterSpawnA;

    public static event Action<int, int> OnCountedSubstance;
    public static event Action<int> OnSpawnGoodCountObject;
    // Start is called before the first frame update
    void Start()
    {
        // for add both good and bad substance counter event
        BehaviourSubstance.OnFinishCountObject += CountSubstance;

        BehaviourSubstance.OnSpawnGoodCountObject += CountSpawnGood;
    }

    void OnDisable()
    {
        // unsubscribe for add both good and bad substance counter event
        BehaviourSubstance.OnFinishCountObject -= CountSubstance;

        BehaviourSubstance.OnSpawnGoodCountObject -= CountSpawnGood;
    }

    void CountSubstance(string tag)
    {
        if(tag != null)
        {
            if(tag.Equals("BadSubstance"))
            {
                counterB += 1;
                OnCountedSubstance?.Invoke(0, counterB);
            }
            if(tag.Equals("Substance"))
            {
                counterA += 1;
                OnCountedSubstance?.Invoke(1, counterA);
            }
        }
    }

    void CountSpawnGood()
    {
        counterSpawnA+=1;
        OnSpawnGoodCountObject?.Invoke(counterSpawnA);
    }
}
