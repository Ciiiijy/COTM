using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pnl_Temple : MonoBehaviour
{
    public void Init()
    {
        Hide();

    }

    public void ShowTemple()
    {
        this.gameObject.SetActive(true);
        UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
        GameMgr.I.player.CanMove(false);
    }

    // Start is called before the first frame update
    public void Hide()
    {
        this.gameObject.SetActive(false);
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
