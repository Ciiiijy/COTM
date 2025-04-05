using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCs : MonoBehaviour
{
    public Dictionary<string, NPC> dic_NPCs = new Dictionary<string, NPC>();
    
    public NPC rui;
    public NPC cishan;
    public NPC alex;



    public void Init()
    {
        ShowNPCs();

        dic_NPCs.Add("Rui",rui);
        dic_NPCs.Add("Cishan", cishan);
        dic_NPCs.Add("Alex", alex);



        foreach (var item in dic_NPCs.Values)
        {
            item.Init();
        }

    }

    public GameObject GetNpc(string name) 
    {
       return dic_NPCs[name].gameObject;
    }
    
    public void ShowNPCs() 
    {
        this.gameObject.SetActive(true);
    }
    public void HideNPCs() 
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
