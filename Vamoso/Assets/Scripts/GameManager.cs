using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	Board m_board;
	PlayerManager m_player;

	bool m_hasLevelStarted = false;
	public bool HasLevelSelected { get { return m_hasLevelStarted; } set { m_hasLevelStarted = value; } }

	bool m_isGamePlaying = false;
	public bool IsGamePlaying { get { return m_isGamePlaying; } set { m_isGamePlaying = value; } }

	bool m_isGameOver = false;
	public bool IsGameOver { get { return m_isGameOver; } set { m_isGameOver = value; } }

	bool m_hasLevelFinished = false;
	public bool HasLevelFinished { get { return m_hasLevelFinished; } set { m_hasLevelFinished = value; } }

	public float delay = 1f;

	void Awake()
	{
		m_board = Object.FindObjectOfType<Board> ().GetComponent<Board> ();
		m_player = Object.FindObjectOfType<PlayerManager> ().GetComponent<PlayerManager> ();
	}
	// Use this for initialization
	void Start () {
		if(m_player != null && m_board != null)
		{
			StartCoroutine ("RunGameLoop");
		}
		else
		{
			Debug.LogWarning ("GAMEMANAGER Error: no player or board found!");
		}
	}

	IEnumerator RunGameLoop()
	{
		yield return StartCoroutine ("StartLevelRoutine");
		yield return StartCoroutine ("PlayLevelRoutine");
		yield return StartCoroutine ("EndLevelRoutine");
	}

	IEnumerator StartLevelRoutine()
	{
		yield return null;
	}

	IEnumerator PlayLevelRoutine()
	{
		yield return null;
	}

	IEnumerator EndLevelRoutine()
	{
		yield return null;
	}
}
