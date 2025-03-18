using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCs : MonoBehaviour
{
    Dictionary<string, GameObject> dic_NPCs = new Dictionary<string, GameObject>();

    public GameObject rui;


    public void Init()
    {
        Show();

        dic_NPCs.Add("Rui",rui);


        foreach (var item in dic_NPCs.Values)
        {
            item.SetActive(false);
        }

    }

    public GameObject GetNpc(string name) 
    {
       return dic_NPCs[name];
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
