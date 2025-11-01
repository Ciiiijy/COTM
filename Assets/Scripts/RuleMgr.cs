using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class RuleMgr : MonoBehaviour
{
    public static RuleMgr I;
    public float speed=1;


    private void Awake()
    {
        I = this;
    }

    //public bool WalkLeft;
    private bool canRule;

    public void CanRule(bool value)
    {
        canRule = value;
    }

    #region All the Forbidden Rules.
    bool isFaceLeft = false;
    void Forbid_MoveLeft()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            isFaceLeft = true;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            isFaceLeft = false;
        }

        if (isFaceLeft)
        {
            //print($"Facing Left.==> {Time.deltaTime}");
            DeSanValue();
        }
    }

    void DeSanValue()
    {
        if (UIMgr.I.pnl_sanity.GetCurrentSanityValue() < 0.01f) return;

        //Calculate:Time.deltaTime

        float f = UIMgr.I.pnl_sanity.GetCurrentSanityValue() - (Time.deltaTime / 10);
        
        print(f);
        if (f < 0.3f)
        {
            UIMgr.I.ui_onTheMountain.pnl_death.AnimWarning();
        }
        if (f<0.01f)
        {
            //Play dead anim. and sth else (UI notice).
            f = 0f;
            UIMgr.I.ui_onTheMountain.pnl_death.Show();
            UIMgr.I.ui_onTheMountain.pnl_death.AnimDeath();
        }
        

        //Set the result of the Sanity.


        UIMgr.I.pnl_sanity.SetSanity(f*speed);
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        if (canRule == false) return;

        Forbid_MoveLeft();
    }
}
