﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class ControlsMenu : MonoBehaviour
{
    public Canvas thisMenu;

    public Button button_1;
    public Button button_2;
    public Button button_3;
    public Button button_4;
    public Button button_5;
    public Button button_6;
    public Button button_7;
    public Button button_8;
    public Button button_9;

    // Start is called before the first frame update
    void Start()
    {
        if (thisMenu.enabled)
            thisMenu.enabled = false;
        button_1.GetComponent<Button>().onClick.AddListener(task_1);
        /*button_2.GetComponent<Button>().onClick.AddListener(task_2);
        button_3.GetComponent<Button>().onClick.AddListener(task_3);
        button_4.GetComponent<Button>().onClick.AddListener(task_4);
        button_5.GetComponent<Button>().onClick.AddListener(task_5);
        button_6.GetComponent<Button>().onClick.AddListener(task_6);
        button_7.GetComponent<Button>().onClick.AddListener(task_7);
        button_8.GetComponent<Button>().onClick.AddListener(task_8);
        button_9.GetComponent<Button>().onClick.AddListener(task_9);*/
    }

    void task_1()
    {
        //UnityEngine.Debug.Log("Back to main...");
        BoomBox.Play(SoundEnum.Sound.CLICK);
        thisMenu.enabled = false;
    }

    void task_2()
    {
    }

    void task_3()
    {
    }

    void task_4()
    {
    }

    void task_5()
    {
    }

    void task_6()
    {
    }

    void task_7()
    {
    }

    void task_8()
    {
    }

    void task_9()
    {
    }
}