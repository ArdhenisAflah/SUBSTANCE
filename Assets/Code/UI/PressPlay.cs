using System;
using UnityEngine;

public class PressPlay : MonoBehaviour
{
    public static event Action OnPressPlay;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // if(OnPressPlay != null)
            // {
            //     OnPressPlay();
            // }

            OnPressPlay?.Invoke();
        }
    }
}
