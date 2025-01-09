using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogicScript : MonoBehaviour
{
    public GameObject vinylImage;
    public float rotationSpeed;
    public float buttonMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vinylImage.transform.Rotate(0, 0, rotationSpeed);
    }
    //begins: 807
    //end: 957
    public void onPlayButtonSelect()
    {
        SceneManager.LoadSceneAsync("Scenes/Battle");
        
    }
    public void onSettingsButtonSelect()
    {
        SceneManager.LoadSceneAsync("Scenes/Settings");
    }
    public void onQuitButtonSelect(Object button)
    {
        Application.Quit();
    }
}
