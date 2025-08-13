using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnl_Altar : MonoBehaviour
{


    public void ShowAltar()
    {
        //clockFront.gameObject.SetActive(false);
        //clockBack.gameObject.SetActive(false);

        this.gameObject.SetActive(true);
        UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
        GameMgr.I.player.CanMove(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
