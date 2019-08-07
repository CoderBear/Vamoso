using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public Vector3 directionToSearch = new Vector3(0f, 0f, 2f);

    Node m_nodeToSearch;
    Board m_board;

    bool m_foundPlayer = false;
    public bool FoundPlayer { get { return m_foundPlayer; } }

    void Awake()
    {
        m_board = FindObjectOfType<Board>().GetComponent<Board>();
    }

   public void UpdateSensor(Node enemyNode)
   {
       Vector3 worldDSpacePositionToSearch = transform.TransformVector(directionToSearch) + transform.position;

       if(m_board != null)
       {
           m_nodeToSearch = m_board.FindNodeAt(worldDSpacePositionToSearch);

           if(!enemyNode.LinkedNodes.Contains(m_nodeToSearch))
           {
               m_foundPlayer = false;
           }

           if(m_nodeToSearch == m_board.PlayerNode)
           {
               m_foundPlayer = true;
           }
       }
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
