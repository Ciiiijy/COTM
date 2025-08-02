using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Calendar : MonoBehaviour
{
    public Button btn_lookclosely;
    public GameObject detailGroup;
    public TextMeshProUGUI TxtMP;
    //public TextMeshProUGUI txt_sssss;

    public void Init()
    {
        Hide();
        detailGroup?.gameObject.SetActive(false);

        btn_lookclosely.onClick.AddListener(() =>
        {
            detailGroup?.gameObject.SetActive(true);
            btn_lookclosely.gameObject.SetActive(false);
            TxtMP.text = "The handwritten numbers on the calendar seem to represent time. If I could set <color=#ffa500ff>the paused clock</color> to this time, what might happen?";
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
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
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
