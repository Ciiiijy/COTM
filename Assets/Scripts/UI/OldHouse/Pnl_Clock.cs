using DG.Tweening;
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
    public GameObject clockPointer;
    public GameObject clockFront910;
    public GameObject clockBack;
    public GameObject clockBackOpen;
    public GameObject eyeballGroup;
    public GameObject monologue_NeedMoveChair;
    public Image clockBackCover;
    public Image eyeBallDetail;

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
        clockPointer?.gameObject.SetActive(false);
        clockFront910?.gameObject.SetActive(false);
        clockBack?.gameObject.SetActive(false);
        eyeballGroup?.gameObject.SetActive(false);

        Shutdown_NeedMoveChair.onClick.AddListener(() =>
        {
            monologue_NeedMoveChair.SetActive(false);

            GameMgr.I.oldHouse.crd.ShowItemsCollider();
        });

        btn_adjusttime.onClick.AddListener(() => //³öÍ¼»»³ÉÐý×ª
        {
            btn_lookotherside?.gameObject.SetActive(false);
            btn_adjusttime?.gameObject.SetActive(false);
            clockBack?.gameObject.SetActive(false);
            
            AnimRotatePointer();

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
                clockPointer?.gameObject.SetActive(true);
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
                clockPointer.gameObject.SetActive(false);
                btn_checkdetail.gameObject.SetActive(false);

                clockBack.gameObject.SetActive(true);
                mechanicsHint.gameObject.SetActive(true);
            }
            else
            {
                btn_lookotherside?.gameObject.SetActive(false);
                btn_adjusttime?.gameObject.SetActive(false);
                clockFront?.gameObject.SetActive(false);
                clockPointer?.gameObject.SetActive(false);
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
                mechanicsHint.gameObject?.SetActive(false);
                looksDifferent.gameObject?.SetActive(false);

                AnimCoverGone();
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

        btn_takeitaway?.onClick.AddListener(() => //ÑÛÖéÍùÏÂ×¹
        {
            btn_takeitaway?.gameObject?.SetActive(false);
            GameMgr.I.oldHouse.characterBack.gameObject.SetActive(false);
            GameMgr.I.oldHouse.clock.gameObject.SetActive(false);

            AnimTakeEyeBall();
            //Player.I.gameObject.SetActive(true);
            //GameMgr.I.oldHouse.clock910.gameObject.SetActive(true);
            //GameMgr.I.oldHouse.getEyeball = true;

            GameMgr.I.oldHouse.crd.ShowItemsCollider();
        });
    }

    public void TryShowClock()
    {
        Show();
        this.gameObject.SetActive(true);

        if (GameMgr.I.oldHouse.canSetClock)
        {
            clockFront.gameObject.SetActive(true);
            clockPointer.gameObject.SetActive(true);
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

    private void AnimCoverGone(System.Action onComplete = null)
    {
        print("Remove the cover.");

        DOTween.Sequence()
            .Append(clockBackCover.DOFade(1, 0.00001f))

            .Append(clockBackCover.transform.DOLocalMoveX(-82f, 2f))
            .Join(clockBackCover.DOFade(0, 3f))

            .AppendCallback(() =>
            {
                btn_checkdetail.gameObject.SetActive(true);
            });
    }

    private void AnimTakeEyeBall(System.Action onComplete = null)
    {
        print("Take the eyeball away.");

        DOTween.Sequence()
            .Append(eyeBallDetail.DOFade(1, 0.00001f))

            .Append(eyeBallDetail.transform.DOLocalMoveY(-247f, 2f))
            .Join(eyeBallDetail.DOFade(0, 3f))

            .AppendCallback(() =>
            {
                Player.I.gameObject.SetActive(true);
                GameMgr.I.oldHouse.clock910.gameObject.SetActive(true);
                GameMgr.I.oldHouse.getEyeball = true;
            });
    }

    private void AnimRotatePointer(System.Action onComplete = null)
    {
        print("Put the eyeball into the eye socket.");

        DOTween.Sequence()
            //.Append(eyeball1.transform.DOLocalMoveX(168f, 1f))
            .Append(clockPointer.transform.DOLocalRotate(new Vector3(0, 0, 0), 1f, RotateMode.Fast))
            .AppendCallback(() =>
            {
                btn_lookotherside.gameObject.SetActive(true);
                GameMgr.I.oldHouse.trueTime = true;
            });
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }
    void Show() 
    {
        this.gameObject.SetActive(true);
        GameMgr.I.oldHouse.crd.HideItemsCollider();
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
