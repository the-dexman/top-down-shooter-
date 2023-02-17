using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseSelectionManager : MonoBehaviour
{
    public Button resumeButton;
    public Button menuButton;
    private Button[] mainMenuButtons = new Button[2];
    private Button currentButton;
    public GameObject selectionMarker;
    public int currentButtonID = 0;
    public EventSystem eventSystem;
    public int selectorOffset = 500;

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode EnterKey;

    //image files
    public GameObject[] mainMenuImages;


    // Start is called before the first frame update
    void Start()
    {
        mainMenuButtons[0] = resumeButton;
        mainMenuButtons[1] = menuButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(downKey))
        {
            if (currentButtonID == mainMenuButtons.Length - 1) //if on exit, set to start
            {

                
                currentButtonID = 0;

            }
            else
            {
                currentButtonID += 1;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(upKey))
        {
            if (currentButtonID == 0)//if on start then make to exit
            {
                currentButtonID = mainMenuButtons.Length - 1;
            }
            else
            {
                currentButtonID -= 1;

            }
        }
        currentButton = mainMenuButtons[currentButtonID];
        Vector3 currentButtonPos = currentButton.gameObject.transform.position;

        selectionMarker.transform.position = new Vector3(selectionMarker.transform.position.x, currentButtonPos.y, currentButtonPos.z);
            
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(EnterKey))
        {
            currentButton.onClick.Invoke();
            
        }
    }
}
