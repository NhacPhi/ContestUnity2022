using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
public class TipContet : MonoBehaviour
{
    public List<GameObject> contents;

    public List<Node> nodes;

    public int currentContentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentContentIndex = 0;
        foreach(GameObject ob in contents)
        {
            ob.gameObject.SetActive(false);
        }
        contents[currentContentIndex].gameObject.SetActive(true);
        nodes[currentContentIndex].ActiveNode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextContentPopup()
    {
        if(currentContentIndex < contents.Count - 1)
        {
            nodes[currentContentIndex].InactiveNode();
            contents[currentContentIndex].gameObject.SetActive(false);
            currentContentIndex++;
            contents[currentContentIndex].gameObject.SetActive(true);
            nodes[currentContentIndex].ActiveNode();
        }
    }
    public void BackContetPopup()
    {
        if(currentContentIndex > 0)
        {
            nodes[currentContentIndex].InactiveNode();
            contents[currentContentIndex].gameObject.SetActive(false);
            currentContentIndex--;
            contents[currentContentIndex].gameObject.SetActive(true);
            nodes[currentContentIndex].ActiveNode();
        }

    }
    public void ResetContent()
    {
        nodes[currentContentIndex].InactiveNode();
        contents[currentContentIndex].gameObject.SetActive(false);
        currentContentIndex = 0;
        contents[currentContentIndex].gameObject.SetActive(true);
        nodes[currentContentIndex].ActiveNode();
    }
}
