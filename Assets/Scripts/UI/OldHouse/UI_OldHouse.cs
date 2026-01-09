using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class UI_OldHouse : MonoBehaviour, SceneFunc
{
    public Button btn_L;
    public Button btn_R;
    public Button btn_back;
    private GameObject currentObj;
    public Pnl_Calendar pnl_calendar;
    public Pnl_Clock pnl_clock;
    public Pnl_Chair pnl_chair;
    public Pnl_Drawer pnl_drawer;
    public Pnl_Photo pnl_photo;
    public Pnl_Altar pnl_altar;

    public void Init()
    {
        btn_L?.gameObject.SetActive(false);
        btn_R?.gameObject.SetActive(false);
        btn_back?.gameObject.SetActive(false);


        pnl_calendar.Init();
        pnl_clock.Init();
        pnl_photo.Init();
        pnl_chair.Init();
        pnl_altar.Init();
        pnl_drawer.Init();

        Hide();

        btn_back.onClick.AddListener(() =>
        {
            btn_back.gameObject.SetActive(false);
            currentObj?.SetActive(false);
            GameMgr.I.player.CanMove(true);

            GameMgr.I.oldHouse.crd.ShowItemsCollider();
        });
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Player.I.playerMove.SetPlayerMove(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

   
    /// <summary>
    /// Let the button can shut down the current Object Detial Inspection.
    /// </summary>
    /// <param name="currentObj">The Obj you have shown.</param>

    //public void ShowClock()
    //{
    //    btn_cannotReach.gameObject.SetActive(true);

    //    if (Player.I.GetComponent<PlayerMove>())
    //    {
    //        btn_cannotReach.gameObject.SetActive(false);
    //    }
    //}

    public void ShowBtnBack(GameObject currentObj)
    {
        this.currentObj = currentObj;
        btn_back.gameObject.SetActive(true);
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
