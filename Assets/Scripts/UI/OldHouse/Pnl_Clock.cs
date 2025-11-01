using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Pnl_Clock : MonoBehaviour
{
    public Button btn_adjusttime;
    public Button btn_lookotherside;
    public Button Shutdown_NeedMoveChair;
    public Button btn_takeoffcover;
    public Button btn_checkdetail;
    public Button btn_takeitaway;
    public Button btn_back;
    public TextMeshProUGUI mechanicsHint;
    public TextMeshProUGUI looksDifferent;
    public GameObject clockFront;
    public GameObject clockFront910;
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
        btn_back?.gameObject.SetActive(false);
        mechanicsHint?.gameObject.SetActive(false);
        looksDifferent?.gameObject.SetActive(false);
        clockFront?.gameObject.SetActive(false);
        clockFront910?.gameObject.SetActive(false);
        clockBack?.gameObject.SetActive(false);
        eyeballGroup?.gameObject.SetActive(false);

        Shutdown_NeedMoveChair.onClick.AddListener(() =>
        {
            monologue_NeedMoveChair.SetActive(false);
        });

        btn_adjusttime.onClick.AddListener(() =>
        {
            btn_lookotherside?.gameObject.SetActive(false);
            btn_adjusttime?.gameObject.SetActive(false);
            clockFront?.gameObject.SetActive(false);
            clockBack?.gameObject.SetActive(false);

            //btn_back.gameObject.SetActive(true);
            btn_lookotherside.gameObject.SetActive(true);
            clockFront910.gameObject.SetActive(true);
            GameMgr.I.oldHouse.trueTime = true;
            //btn_back.transform.localPosition = new Vector3(351f, 120f);

        });

        btn_back.onClick.AddListener(() =>
        {
            btn_back?.gameObject.SetActive(false);
            if (GameMgr.I.oldHouse.trueTime)
            {
                mechanicsHint.gameObject.SetActive(false);

                btn_lookotherside.gameObject.SetActive(true);
                btn_lookotherside.transform.localPosition = new Vector3(351f, 120f);
            }
            else
            {
                mechanicsHint.gameObject.SetActive(false);
                clockBack.gameObject.SetActive(false);

                clockFront.gameObject.SetActive(true);
                btn_adjusttime?.gameObject.SetActive(true);
                btn_lookotherside.gameObject.SetActive(true);
                btn_lookotherside.transform.localPosition = new Vector3(351f, -40f);
            }
        });

        btn_lookotherside.onClick.AddListener(() =>
        {
            if (GameMgr.I.oldHouse.trueTime)
            {
                btn_lookotherside?.gameObject.SetActive(false);
                btn_adjusttime?.gameObject.SetActive(false);
                clockFront?.gameObject.SetActive(false);
                btn_checkdetail.gameObject.SetActive(false);

                clockBack.gameObject.SetActive(true);
                mechanicsHint.gameObject.SetActive(true);
            }
            else
            {
                btn_lookotherside?.gameObject.SetActive(false);
                btn_adjusttime?.gameObject.SetActive(false);
                clockFront?.gameObject.SetActive(false);
                btn_checkdetail.gameObject.SetActive(false);

                clockBack.gameObject.SetActive(true);
                looksDifferent.gameObject.SetActive(true);
            }
            //Update();
        });

        btn_takeoffcover?.onClick.AddListener(() =>
        {
            if (GameMgr.I.oldHouse.trueTime)
            {
                btn_takeoffcover?.gameObject.SetActive(false);
                clockBackCover?.gameObject.SetActive(false);
                mechanicsHint.gameObject?.SetActive(false);
                looksDifferent.gameObject?.SetActive(false);

                btn_checkdetail.gameObject.SetActive(true);
            }
            else
            {
                //btn_takeoffcover?.gameObject.SetActive(false);
                //mechanicsHint.gameObject?.SetActive(false);
                looksDifferent?.gameObject.SetActive(false);

                btn_back.gameObject.SetActive(true);
                mechanicsHint.gameObject.SetActive(true);
                btn_back.transform.localPosition = new Vector3(351f, -139f);
            }
        });

        btn_checkdetail?.onClick.AddListener(() =>
        {
            btn_checkdetail?.gameObject.SetActive(false);

            eyeballGroup.SetActive(true);
            btn_takeitaway.gameObject.SetActive(true);
        });

        btn_takeitaway?.onClick.AddListener(() =>
        {
            btn_takeitaway?.gameObject?.SetActive(false);
            GameMgr.I.oldHouse.characterBack.gameObject.SetActive(false);
            GameMgr.I.oldHouse.clock.gameObject.SetActive(false);

            Player.I.gameObject.SetActive(true);
            GameMgr.I.oldHouse.clock910.gameObject.SetActive(true);
            GameMgr.I.oldHouse.getEyeball = true;
        });
    }

    public void TryShowClock()
    {
        Show();
        this.gameObject.SetActive(true);

        if (GameMgr.I.oldHouse.canSetClock)
        {
            clockFront.gameObject.SetActive(true);
            btn_adjusttime?.gameObject.SetActive(true);
            btn_lookotherside?.gameObject.SetActive(true);

            GameMgr.I.oldHouse.trueTime = false;
            btn_lookotherside.transform.localPosition = new Vector3(351f, -40f);

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
        //this.gameObject.SetActive(true);
        //GameMgr.I.oldHouse.crd.HideItemsCollider();

    }
    void Hide()
    {
        this.gameObject.SetActive(false);
        //GameMgr.I.oldHouse.characterBack.gameObject.SetActive(false);
        //Player.I.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMgr.I.oldHouse.trueTime)
        {
            mechanicsHint.text = "Where is the sound coming from? Is there something hidden inside the clock? But where can hide things?";
        }
        else
        {
            mechanicsHint.text = "It seems the mechanism is here, but it can't be opened.<br><br>Should the time be adjusted to match the time sketched on the calendar first?";
        }
    }
}
