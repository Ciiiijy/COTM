using DG.Tweening;
using System;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class DarkCurtain : MonoBehaviour
{
    public static DarkCurtain I;

    public Image darkImg;
    Color transparency = new Color(0, 0, 0, 0);
    public void Init()
    {
        I = this;
        
        Show();
        darkImg.color = transparency;
        darkImg.gameObject.SetActive(false);
    }
    Sequence sq;

    public void ChangeScene(Action close, Action open, float duration = 1.5f, float hodlOn = 1f)
    {
        sq.Kill();

        darkImg.color = transparency;
        darkImg.gameObject.SetActive(true);

        sq = DOTween.Sequence()
            .Append(darkImg.DOFade(1, duration))
            .InsertCallback(duration + 0.1f, () => { close(); })
            .InsertCallback(duration + 0.1f, () => { open(); })
            .AppendInterval(hodlOn)
            .Append(darkImg.DOFade(0, duration))
            .AppendCallback(() => { darkImg.gameObject.SetActive(false); });
    }

    void Show() { gameObject.SetActive(true); }
    void Hide() { gameObject.SetActive(false); }
}
