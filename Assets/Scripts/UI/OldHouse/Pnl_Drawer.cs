using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Drawer : MonoBehaviour
{
    public GameObject eyeball1;
    public GameObject eyeball2;
    public GameObject doll;
    public GameObject mouth;
    public GameObject script;
    public GameObject backpack;
    public GameObject drawer;
    public GameObject monologue_NoEyeball;
    public GameObject monologue_drag;
    public GameObject monologue_wrong;
    //public GameObject monologue_script;
    public Button btn_openBackpack;
    public Button Shutdown_NoEyeball;
    public Button Shutdown_drag;
    public Button Shutdown_wrong;
    //public Button Shutdown_script;
    public Button btn_putEyeball;
    public Button btn_changeOrder;

    public void Init()
    {
        Hide();
        eyeball1?.gameObject.SetActive(false);
        eyeball2?.gameObject.SetActive(false);
        doll?.gameObject.SetActive(false);
        mouth?.gameObject.SetActive(false);
        script?.gameObject.SetActive(false);
        backpack?.gameObject.SetActive(false);
        drawer?.gameObject.SetActive(false);
        
        monologue_NoEyeball?.gameObject.SetActive(false);
        monologue_drag?.gameObject.SetActive(false);
        monologue_wrong?.gameObject.SetActive(false);
        //monologue_script?.gameObject.SetActive(false);

        btn_openBackpack?.gameObject.SetActive(false);
        btn_putEyeball?.gameObject.SetActive(false);
        btn_changeOrder?.gameObject.SetActive(false);

        //ADD BUTTON LISTENER

        Shutdown_NoEyeball.onClick.AddListener(() =>
        {
            monologue_NoEyeball.gameObject.SetActive(false);
            btn_openBackpack?.gameObject.SetActive(true);
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
            btn_putEyeball.gameObject.SetActive(true);
        });

        btn_putEyeball.onClick.AddListener(() =>
        {
            backpack.gameObject.SetActive(false);
            btn_putEyeball.gameObject.SetActive(false);
            monologue_drag.gameObject.SetActive(false);

            eyeball1.transform.localPosition = new Vector3(20f, 243f);
            monologue_wrong.gameObject.SetActive(true);
        });

        Shutdown_wrong.onClick.AddListener(() =>
        {
            monologue_wrong.gameObject.SetActive(false);
            btn_changeOrder.gameObject.SetActive(true);
        });

        btn_changeOrder.onClick.AddListener(() =>
        {
            btn_putEyeball.gameObject.SetActive(false);

            AnimChangeEye();

            //mouth.gameObject.SetActive(true);

            //monologue_script.gameObject.SetActive(true);
        });
    }

    public void ShowDrawer()
    {
        drawer.gameObject.SetActive(true);
        doll.gameObject.SetActive(true);
        eyeball2.gameObject.SetActive(true);
        monologue_NoEyeball.gameObject.SetActive(true);
        eyeball2.transform.localPosition = new Vector3(-71f, 243f);

        this.gameObject.SetActive(true);
        UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
        GameMgr.I.player.CanMove(false);
    }

    private void AnimChangeEye(System.Action onComplete = null)
    {
        print("Change eyes.");

        DOTween.Sequence()
            //.Append(eyeball1.transform.DORotate(new Vector3(0f,0f,180f),2f,RotateMode.WorldAxisAdd))
            //.Append(eyeball1.transform.DOLocalMoveX(171f, 1f))
            .Append(eyeball2.transform.DOLocalMoveX(20f, 2f));

            //.Append(eyeball1.transform.DOLocalMoveY(301f, 1f))
            //.Append(eyeball2.transform.DOLocalMoveY(142f, 1f))

            //.Append(eyeball1.transform.DOLocalMoveX(-213f, 1f))
            //.Append(eyeball2.transform.DOLocalMoveX(171f, 1f))

            //.Append(eyeball1.transform.DOLocalMoveY(243f, 1f))
            //.Append(eyeball2.transform.DOLocalMoveY(243f, 1f))

            //.Append(eyeball1.transform.DOLocalMoveX(-71f, 1f))
            //.Append(eyeball2.transform.DOLocalMoveX(20f, 1f));
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
        
    }
}
