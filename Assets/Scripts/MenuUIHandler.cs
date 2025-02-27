using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    private string playerName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void SaveName(string entry)
    {
        MenuManager.SaveName(entry);
        Debug.Log(entry);
    }
}
