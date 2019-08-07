﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerDeath))]
public class PlayerManager : TurnManager
{
	public PlayerMover playerMover;
	public PlayerInput playerInput;

	public UnityEvent deathEvent;

	protected override void Awake()
	{
		base.Awake();

		playerMover = GetComponent<PlayerMover> ();
		playerInput = GetComponent<PlayerInput> ();
		playerInput.InputEnabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(playerMover.isMoving || m_gameManager.CurrentTurn != Turn.Player)
		{
			return;
		}

		playerInput.GetKeyInput ();

		if(playerInput.V == 0)
		{
			if (playerInput.H < 0)
			{
				playerMover.MoveLeft ();
			}
			else if (playerInput.H > 0)
			{
				playerMover.MoveRight ();
			}
		}
		else if(playerInput.H == 0)
		{
			if (playerInput.V > 0)
			{
				playerMover.MoveForward ();
			}
			else if (playerInput.V < 0)
			{
				playerMover.MoveBackward ();
			}
		}
	}

	public void Die()
	{
		if(deathEvent != null)
		{
			deathEvent.Invoke();
		}
	}
}
