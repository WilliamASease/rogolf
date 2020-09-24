﻿using UnityEngine;

public class InputController
{
    private Game game;
	public Canvas console;

    public InputController(Game game)
    {
        this.game = game;
		console = (GameObject.Find("DevConsole")).GetComponent<Canvas>();
    }

    /// <summary>
    /// Check each relevant key.
    /// If it is being pressed, propogate key press as method call to game's state.
    /// 
    /// This is hard coded right now! Deal with it!
    /// </summary>
    public void Tick()
    {
		if (console.enabled) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            game.state.OnKeySpace();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            game.state.OnKeyUpArrow();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            game.state.OnKeyDownArrow();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            game.state.OnKeyRightArrow();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            game.state.OnKeyLeftArrow();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            game.state.OnKeyW();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            game.state.OnKeyA();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            game.state.OnKeyS();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            game.state.OnKeyD();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            game.state.OnKeyQ();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            game.state.OnKeyE();
        }
        if (Input.GetKeyDown(KeyCode.Return)) // Enter key
        {
            game.state.OnKeyReturn();
        }
    }
}
