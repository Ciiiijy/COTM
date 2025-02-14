using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Chat : MonoBehaviour
{
    public static UI_Chat I;
    public float duration;
    public TextMeshProUGUI name_TMP;
    public TextMeshProUGUI line_TMP;
    public Button btnNext;

    public List<string> chatList;
    public int index = 0;

    bool isFinished = true;

    public void Init()
    {
        I = this;

        btnNext.onClick.AddListener(() =>
        {
            PlayOneLineInTyping();
        });

        SetList(LineBooks.I.list_OnTheBus);

        name_TMP.text = string.Empty;
        line_TMP.text = string.Empty;
        Hide();
    }


    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void SetList(List<string> list)
    {
        chatList = list;
    }

    private void PlayOneLineInTyping()
    {
        
        if (!isFinished) return;

        //[1].Pick up one line from the dialogue script.p

        string str = chatList[index];
        index++;

        string[] strArray = str.Split('|');
        name_TMP.text = strArray[0];
        string oneLine = strArray[1];

        //[2].Play it.
        StartCoroutine(TypeWrite(oneLine));
    }

    private IEnumerator TypeWrite(string str)
    {
        isFinished = false;

        bool isCharComplete = false;
        line_TMP.text = str;
        line_TMP.ForceMeshUpdate();
        TMP_TextInfo text_info = line_TMP.textInfo;
        int total = text_info.characterCount;
        int current = 0;
        while (!isCharComplete)
        {
            if (current > total)
            {
                current = total;
                yield return new WaitForSecondsRealtime(0.1f);
                isCharComplete = true;
            }
            line_TMP.maxVisibleCharacters = current;
            current += 1;
            yield return new WaitForSecondsRealtime(duration);
        }
        isFinished = true;
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
