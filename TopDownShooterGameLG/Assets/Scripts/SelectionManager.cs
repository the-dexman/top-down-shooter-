using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public Button startButton;
    public Button creditsButton;
    public Button quitButton;
    public Button creditsBackButton;
    private Button[] mainMenuButtons = new Button[3];
    private Button currentButton;
    public GameObject selectionMarker;
    public GameObject creditsScreen;
    public int currentButtonID = 0;
    public EventSystem eventSystem;
    public int selectorOffset = 500;


    // Start is called before the first frame update
    void Start()
    {
        mainMenuButtons[0] = startButton;
        mainMenuButtons[1] = creditsButton;
        mainMenuButtons[2] = quitButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentButtonID == mainMenuButtons.Length - 1)
            {
                currentButtonID = 0;
            }
            else
            {
                currentButtonID += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentButtonID == 0)
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

        if (creditsScreen.activeInHierarchy)
        {
            currentButton = creditsBackButton;
            currentButtonPos = creditsBackButton.gameObject.transform.position;
            
        }

        selectionMarker.transform.position = new Vector3(currentButtonPos.x - selectorOffset, currentButtonPos.y, currentButtonPos.z);
            
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentButton.onClick.Invoke();
            
        }
    }
}
