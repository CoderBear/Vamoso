using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour 
{
	public static float spacing = 2f;

	public static readonly Vector2[] directions = {
		new Vector2(spacing, 0f),
		new Vector2(-spacing, 0f),
		new Vector2(0f, spacing),
		new Vector2(0f, -spacing)
	};

	List<Node> m_allNodes = new List<Node> ();
	public List<Node> AllNodes { get { return m_allNodes; } }

	Node m_playerNode = new Node ();
	public Node PlayerNode { get { return m_playerNode; } }

	PlayerManager m_player;

	void Awake()
	{
		m_player = Object.FindObjectOfType<PlayerManager> ().GetComponent<PlayerManager> ();
		GetNodeList ();
	}

	public void GetNodeList()
	{
		Node[] nList = GameObject.FindObjectsOfType<Node> ();
		m_allNodes = new List<Node> (nList);
	}

	public Node FindNodeAt(Vector3 pos)
	{
		Vector2 boardCoord = Utility.Vector2Round (new Vector2 (pos.x, pos.z));
		return m_allNodes.Find (n => n.Coordinate == boardCoord);
	}

	public Node FindPlayerNode()
	{
		if(m_player != null && !m_player.playerMover.isMoving)
		{
			return FindNodeAt (m_player.transform.position);
		}
		return null;
	}

	public void UpdatePlayerNode()
	{
		m_playerNode = FindPlayerNode ();
	}
}
