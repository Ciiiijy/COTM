using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class Pnl_Sanity : MonoBehaviour
{
    public GameObject bg_slot;
    public RectTransform fillingImg;
    float currtValue;

    public void Init()
    {
        currtValue = 1;
        bg_slot.SetActive(true);
    }

    /// <summary>
    /// Set the Sanity to the target filling state.
    /// </summary>
    /// <param name="targetPercent">e.g. 0.8 means move to 80%.</param>
    public void SetSanity(float targetPercent) 
    {
        //DOTween.Sequence()
        //    .Append(fillingImg.DOScaleX(targetPercent,0.000002f));

        fillingImg.localScale = new Vector3(targetPercent, 1, 1);
        currtValue = targetPercent;
        print(targetPercent);
    }
    public float GetCurrentSanityValue() 
    {
        return currtValue;
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
