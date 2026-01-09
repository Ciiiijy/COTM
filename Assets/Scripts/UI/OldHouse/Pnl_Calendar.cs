using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Calendar : MonoBehaviour
{
    public Button btn_lookclosely;
    public GameObject detailGroup;
    public TextMeshProUGUI txtMP;

    public void Init()
    {
        Hide();

        detailGroup?.gameObject.SetActive(false);

        btn_lookclosely.onClick.AddListener(() =>
        {
            //GameMgr.I.oldHouse.crd.HideItemsCollider();

            detailGroup?.gameObject.SetActive(true);
            btn_lookclosely.gameObject.SetActive(false);
            txtMP.text = "The handwritten numbers on the calendar seem to represent time. If I could set <color=#ffa500ff>the paused clock</color> to this time, what might happen?";
        });
    }

    //private void LookCloselyCilked()
    //{

    //}
    public void ShowCalendar()
    {
        detailGroup.gameObject.SetActive(false);
        btn_lookclosely.gameObject.SetActive(true);

        this.gameObject.SetActive(true);
        UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
        GameMgr.I.player.CanMove(false);

        GameMgr.I.oldHouse.crd.HideItemsCollider();
    }

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