using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Photo : MonoBehaviour
{
    public GameObject FamilyPhoto;
    public TextMeshProUGUI contextText;

    public void Init()
    {
        Hide();
        FamilyPhoto?.gameObject.SetActive(false);
        contextText?.gameObject.SetActive(false);
    }

    public void ShowPhoto()
    {
        FamilyPhoto.gameObject.SetActive(true);
        contextText.gameObject.SetActive(true);

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
