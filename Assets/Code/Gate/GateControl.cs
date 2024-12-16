using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    public float valueToFade;
    public float scaleWhenClosed;
    public float scaleWhenOpened;
    public float duration;

    public Gate gate;
    void Awake()
    {
        gate = new Gate();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        gate.Name = "Laser I";
        gate.Description = "Gate manually opened and laser type";
        valueToFade = this.transform.localScale.y;
        gate.gt = this;
        gate.isSelected = false;
        // gateControl -> masukin ke gate -> di masukin list GateList
        GateManager.gateLists.Add(gate);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && valueToFade == scaleWhenClosed && gate.isSelected)
        {
            Debug.Log("OK OPENED");
            valueToFade = this.transform.localScale.y;
            StopAllCoroutines();
            StartCoroutine(FadeValue(scaleWhenOpened,duration));
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && valueToFade != scaleWhenClosed && gate.isSelected)
        {
            Debug.Log("OK CLOSED");
            valueToFade = this.transform.localScale.y;
            StopAllCoroutines();
            StartCoroutine(FadeValue(scaleWhenClosed,duration));
        }
        


        
    }

    void OnMouseDown()
    {
        // pilih gate yang mau di kontrol
        gate.isSelected = true;
        // set back gameobject colour to green a = 1
        Color currentWall = this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        currentWall.a = 1f;
        this.gameObject.GetComponent<SpriteRenderer>().color = currentWall;
        foreach(Gate gtc in GateManager.gateLists)
        {
            if(gtc.gt != this.gate.gt)
            {
                // Debug.Log("checking");
                //set previous wall (yang dibungkus class wrapper Gate isselected property to false
                gtc.isSelected = false;
                // previous wall colour
                Color previousWall = gtc.gt.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                previousWall.a = 0.5f;
                gtc.gt.gameObject.GetComponent<SpriteRenderer>().color = previousWall;
            }
        }

        
    }

  IEnumerator FadeValue(float targetValue, float duration)
    {
        float time = 0;
        float start = valueToFade;
 
        while (time < duration)
        {
            valueToFade = Mathf.Lerp(start, targetValue, time / duration);
            time += Time.deltaTime;
            transform.localScale = new Vector3(this.transform.localScale.x,valueToFade, this.transform.localScale.z);
            yield return null;
        }
 
        valueToFade = targetValue;
        Debug.Log("Done");
    }
}
