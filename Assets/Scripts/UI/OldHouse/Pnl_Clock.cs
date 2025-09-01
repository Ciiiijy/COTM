using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Clock : MonoBehaviour
{
    public Button btn_adjusttime;
    public Button btn_lookotherside;
    public Button Shutdown_NeedMoveChair;
    public Button btn_takeoffcover;
    public Button btn_checkdetail;
    public Button btn_takeitaway;
    public GameObject clockFront;
    public GameObject clockBack;
    public GameObject clockBackOpen;
    public GameObject clockBackCover;
    public GameObject eyeballGroup;
    public GameObject monologue_NeedMoveChair;

    public void Init()
    {
        Hide();
        btn_adjusttime?.gameObject.SetActive(false);
        btn_lookotherside?.gameObject.SetActive(false);
        btn_checkdetail?.gameObject.SetActive(false);
        btn_takeitaway?.gameObject.SetActive(false);
        clockFront?.gameObject.SetActive(false);
        clockBack?.gameObject.SetActive(false);
        eyeballGroup?.gameObject.SetActive(false);

        btn_adjusttime.onClick.AddListener(() =>
        {
            //btn_lookotherside?.gameObject.SetActive(false);
            btn_adjusttime?.gameObject.SetActive(false);
        });

        btn_lookotherside.onClick.AddListener(() =>
        {
            btn_lookotherside?.gameObject.SetActive(false);
            btn_adjusttime?.gameObject.SetActive(false);
            clockFront?.gameObject.SetActive(false);

            clockBack?.gameObject.SetActive(true);
            btn_checkdetail?.gameObject.SetActive(true);
        });

        btn_takeoffcover?.onClick.AddListener(() =>
        {
            btn_takeoffcover?.gameObject.SetActive(false);
            clockBackCover?.gameObject.SetActive(false);

            btn_checkdetail.gameObject.SetActive(true);
        });

        btn_checkdetail?.onClick.AddListener(() =>
        {
            btn_checkdetail?.gameObject.SetActive(false);

            eyeballGroup.SetActive(true);
            btn_takeitaway?.gameObject.SetActive(true);
        });

        btn_takeitaway?.onClick.AddListener(() =>
        {
            btn_takeitaway?.gameObject?.SetActive(false);
        });

        Shutdown_NeedMoveChair.onClick.AddListener(() => 
        {
            monologue_NeedMoveChair.SetActive(false);
        });
    }

    public void TryShowClock()
    {
        Show();
        if (GameMgr.I.oldHouse.canSetClock)
        {
            //UIMgr.I.ui_oldHouse.btn_back.gameObject.SetActive(true);
            clockFront.gameObject.SetActive(true);
            btn_adjusttime?.gameObject.SetActive(true);
            btn_lookotherside?.gameObject.SetActive(true);

            this.gameObject.SetActive(true);
            UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
            GameMgr.I.player.CanMove(false);
        }
        else
        {
            UIMgr.I.ui_oldHouse.pnl_clock.monologue_NeedMoveChair.SetActive(true);
            Shutdown_NeedMoveChair.gameObject.SetActive(true);
            GameMgr.I.oldHouse.canMoveChair = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }
    void Show() 
    {
        this.gameObject.SetActive(true);
    }
    void Hide()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
