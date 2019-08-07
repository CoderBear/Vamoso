using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Vector3 offscreenOffset = new Vector3(0f, 10f, 0f);

    Board m_board;

    public float deathDelay = 0f;
    public float offscreenDelay = 1f;

    public float iTweenDelay = 0f;
    public iTween.EaseType easeType = iTween.EaseType.easeInOutQuint;
    public float moveTime = 0.5f;

    private void Awake()
    {
        m_board = FindObjectOfType<Board>().GetComponent<Board>();
    }

    public void MoveOffBoard(Vector3 target)
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "x", target.x,
            "y", target.y,
            "z", target.z,
            "delay", iTweenDelay,
            "easetype", easeType,
            "time", moveTime
        ));
    }

    public void Die()
    {
        StartCoroutine(DieRoutine());
    }
    
    IEnumerator DieRoutine()
    {
        yield return new WaitForSeconds(deathDelay);

        Vector3 offScreenPos = transform.position + offscreenOffset;

        MoveOffBoard(offScreenPos);

        yield return new WaitForSeconds(moveTime + offscreenDelay);

        if(m_board.capturePositions.Count != 0 && m_board.CurrentCpturePosition < m_board.capturePositions.Count)
        {
            Vector3 capturePos = m_board.capturePositions[m_board.CurrentCpturePosition].position;
            transform.position = capturePos + offscreenOffset;

            MoveOffBoard(capturePos);

            yield return new WaitForSeconds(moveTime);

            m_board.CurrentCpturePosition++;
            m_board.CurrentCpturePosition = Mathf.Clamp(m_board.CurrentCpturePosition, 0, m_board.capturePositions.Count - 1);
        }
    }
}
