using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairChecker : MonoBehaviour
{
    private ClickSquare m_SelectionA;
    private ClickSquare m_SelectionB;

    private bool paused = false;
    private float pauseTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            pauseTime += Time.deltaTime;
            if (pauseTime > 0.5f)
            {
                paused = false;

                if (m_SelectionA.value == m_SelectionB.value)
                {
                    Destroy(m_SelectionA.gameObject);
                    m_SelectionA = null;

                    Destroy(m_SelectionB.gameObject);
                    m_SelectionB = null;
                }
                else
                {
                    m_SelectionA.FlipBack();
                    m_SelectionA = null;

                    m_SelectionB.FlipBack();
                    m_SelectionB = null;
                }
            }
        }

        if (m_SelectionA != null
            && m_SelectionB != null
            && m_SelectionA.m_CardState == ClickSquare.CardState.shown
            && m_SelectionB.m_CardState == ClickSquare.CardState.shown
            && !paused)
        {
            paused = true;
            pauseTime = 0.0f;
        }
    }

    public void SelectCard(ClickSquare clickSquare)
    {
        if (m_SelectionA == null)
        {
            m_SelectionA = clickSquare;
        }
        else
        {
            m_SelectionB = clickSquare;
        }
    }
}
