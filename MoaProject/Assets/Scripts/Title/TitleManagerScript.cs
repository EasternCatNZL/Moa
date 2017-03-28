using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManagerScript : MonoBehaviour {

    public Image sign; //reference to sign
    public Sprite[] signs = new Sprite[2]; //array of images

    /*
     * button choice:
     * 0 = start
     * 1 = quit
     */
    int currentButton = 0; //int reference to currently selected button
    public bool canInput = false; //checks to see if input from controller axis allowed

	// Use this for initialization
	void Start () {
        //set can input when starting to true
        canInput = true;
	}
	
	// Update is called once per frame
	void Update () {
        ChangeChoice();
        CheckJoystickFree();
        GetSelection();
	}

    //changes the choice on start menu
    void ChangeChoice()
    {
        //check if player is allowed input
        if (canInput)
        {
            //checks if the joystick has recieved any input
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (currentButton == 0)
                {
                    //change seleceted button
                    currentButton = 1;
                    //change graphical output
                    sign.sprite = signs[1];
                }
                else if (currentButton == 1)
                {
                    //change seleceted button
                    currentButton = 0;
                    //change graphical output
                    sign.sprite = signs[0];
                }
                canInput = false;
            }
        }
    }

    //checks if the joystick input is free
    void CheckJoystickFree()
    {
        //if no input, then allow input to change state
        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            canInput = true;
        }
    }

    void GetSelection()
    {
        //check input for controller submit
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            //check which button is currently selected
            if (currentButton == 0)
            {
                //load into game scene
                SceneManager.LoadScene(1);
            }
            else if (currentButton == 1)
            {
                //quit application
                Application.Quit();
            }
        }
    }
}
