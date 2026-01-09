using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Drawer : MonoBehaviour
{
    public Image eyeball1;
    public GameObject eyeball2;
    public GameObject doll;
    public GameObject backpack;
    public GameObject drawer;
    public GameObject monologue_NoEyeball;
    public GameObject monologue_drag;
    public GameObject monologue_wrong;
    public GameObject monologue_script;
    public GameObject monologue_hint;
    public TextMeshProUGUI NoEyeballLine;
    public Button btn_openBackpack;
    public Button Shutdown_NoEyeball;
    public Button Shutdown_drag;
    public Button Shutdown_wrong;
    public Button Shutdown_script;
    public Button btn_putEyeball;
    public Button btn_changeOrder;
    public Button btn_getScript;
    public Button btn_takeScript;
    public Button btn_nottakeScript;
    public Button darkBack;
    public Image mouth;
    public Image script;

    public void Init()
    {
        mouth.canvas.sortingOrder = 3;

        Hide();
        eyeball1?.gameObject.SetActive(false);
        eyeball2?.gameObject.SetActive(false);
        doll?.gameObject.SetActive(false);
        script?.gameObject.SetActive(false);
        backpack?.gameObject.SetActive(false);
        drawer?.gameObject.SetActive(false);

        monologue_NoEyeball?.gameObject.SetActive(false);
        monologue_drag?.gameObject.SetActive(false);
        monologue_wrong?.gameObject.SetActive(false);
        monologue_script?.gameObject.SetActive(false);
        monologue_hint?.gameObject.SetActive(false);
        darkBack?.gameObject.SetActive(false);

        btn_openBackpack?.gameObject.SetActive(false);
        btn_putEyeball?.gameObject.SetActive(false);
        btn_changeOrder?.gameObject.SetActive(false);
        btn_getScript?.gameObject.SetActive(false);
        btn_takeScript?.gameObject.SetActive(false);
        btn_nottakeScript?.gameObject.SetActive(false);

        mouth.gameObject.SetActive(false);

        //ADD BUTTON LISTENER

        //Update();

        Shutdown_NoEyeball.onClick.AddListener(() =>
        {
            if (GameMgr.I.oldHouse.getEyeball)
            {
                monologue_NoEyeball.gameObject.SetActive(false);
                btn_openBackpack?.gameObject.SetActive(true);

                GameMgr.I.oldHouse.crd.ShowItemsCollider();
            }
            else
            {
                this.gameObject.SetActive(false);

                GameMgr.I.oldHouse.crd.ShowItemsCollider();
            }
        });

        btn_openBackpack.onClick.AddListener(() =>
        {
            btn_openBackpack?.gameObject.SetActive(false);

            backpack.gameObject.SetActive(true);
            eyeball1.gameObject.SetActive(true);
            monologue_drag.gameObject.SetActive(true);

            eyeball1.transform.localPosition = new Vector3(-690f, 305f);
        });

        Shutdown_drag.onClick.AddListener(() =>
        {
            monologue_drag.gameObject.SetActive(false);

            eyeball1.canvas.sortingOrder = 5;
            btn_putEyeball.gameObject.SetActive(true);
        });

        btn_putEyeball.onClick.AddListener(() =>
        {
            backpack.gameObject.SetActive(false);
            btn_putEyeball.gameObject.SetActive(false);
            monologue_drag.gameObject.SetActive(false);

            AnimPutEyeball();
        });

        Shutdown_wrong.onClick.AddListener(() =>
        {
            monologue_wrong.gameObject.SetActive(false);
            btn_changeOrder.gameObject.SetActive(true);
        });

        btn_changeOrder.onClick.AddListener(() =>
        {
            btn_changeOrder.gameObject.SetActive(false);

            AnimChangeEye();
        });

        Shutdown_script.onClick.AddListener(() =>
        {
            monologue_script.gameObject.SetActive(false);

            btn_getScript.gameObject.SetActive(true);
            script.transform.localPosition = new Vector3(-370f, 714f);
        });

        btn_getScript.onClick.AddListener(() =>
        {
            btn_getScript.gameObject.SetActive(false);

            darkBack.gameObject.SetActive(true);
            AnimTakeScript();
            script.gameObject.SetActive(true);
        });

        darkBack.onClick.AddListener(() =>
        {
            GameMgr.I.oldHouse.getScript = true;
            this.gameObject.SetActive(false);
        });
    }

    public void ShowDrawer()
    {
        drawer.gameObject.SetActive(true);
        doll.gameObject.SetActive(true);
        eyeball2.gameObject.SetActive(true);
        monologue_NoEyeball.gameObject.SetActive(true);
        mouth.gameObject.SetActive(true);
        eyeball2.transform.localPosition = new Vector3(-71f, 243f);

        this.gameObject.SetActive(true);
        //UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
        GameMgr.I.player.CanMove(false);

        GameMgr.I.oldHouse.crd.HideItemsCollider();
    }

    private void AnimChangeEye(System.Action onComplete = null)
    {
        print("Change eyes.");

        DOTween.Sequence()
            .Append(mouth.DOFade(0, 0.00001f))

            //.Append(eyeball1.transform.DORotate(new Vector3(0f, 0f, 180f), 2f, RotateMode.WorldAxisAdd))
            .Append(eyeball1.transform.DOLocalMoveX(168f, 1f))
            .Append(eyeball2.transform.DOLocalMoveX(20f, 2f))

            .Append(eyeball1.transform.DOLocalMoveY(395f, 0.5f))
            .Append(eyeball1.transform.DOLocalMoveX(-210f, 0.5f))
            .Append(eyeball1.transform.DOLocalMoveY(244f, 0.5f))
            .Append(eyeball1.transform.DOLocalMoveX(-71f, 0.5f))

            .AppendInterval(0.5f)
            .Append(mouth.DOFade(1, 1f))
            .AppendInterval(1f)
            .AppendCallback(() =>
            {
                monologue_script.gameObject.SetActive(true);
            });
    }

    private void AnimPutEyeball(System.Action onComplete = null)
    {
        print("Put the eyeball into the eye socket.");

        DOTween.Sequence()
            .Append(eyeball1.transform.DOLocalMoveX(168f, 1f))
            .Append(eyeball1.transform.DOLocalMoveY(243f, 0.5f))
            .Append(eyeball1.transform.DOLocalMoveX(20f, 0.5f))

            .AppendCallback(() =>
            {
                monologue_wrong.gameObject.SetActive(true);
            });
    }

    private void AnimTakeScript(System.Action onComplete = null)
    {
        print("Put the eyeball into the eye socket.");

        DOTween.Sequence()
            .Append(script.DOFade(0, 0.00001f))

            .Append(script.transform.DOLocalMoveY(145f, 1f))
            .Join(script.DOFade(1, 1.5f))

            .AppendCallback(() =>
            {
                monologue_hint.gameObject.SetActive(true);
                btn_takeScript?.gameObject.SetActive(true);
                btn_nottakeScript?.gameObject.SetActive(true);
                eyeball1.canvas.sortingOrder = 1;
            });
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMgr.I.oldHouse.getEyeball)
        {
            NoEyeballLine.text = "The doll is missing one eye and is trying to find the lost eyeball.";
        }
        else
        {
            NoEyeballLine.text = "The doll is missing one eye and is trying to find the lost eyeball. You need to get the eyeball first.";
        }
    }
}
