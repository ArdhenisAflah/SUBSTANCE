using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateAnim : MonoBehaviour
{
    private Animator anim;
    private GateManager gtm;
    private BoxCollider2D bcd;

    private bool isGateOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        bcd = GetComponent<BoxCollider2D>();
        GateManager.gateLists.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
       if(anim != null)
       {
        if(Input.GetButtonDown("Gate"+this.gameObject.name) && isGateOpen == false){
            anim.SetTrigger("TrOpen");
            isGateOpen = true;
            bcd.enabled = false;
        }else if(Input.GetButtonDown("Gate"+this.gameObject.name) && isGateOpen == true){
            anim.SetTrigger("TrClose");
            isGateOpen = false;
            bcd.enabled = true;
        }
        
       }
    }

}
