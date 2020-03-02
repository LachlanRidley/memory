using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PairChecker : MonoBehaviour
{
    private ClickSquare m_SelectionA;
    private ClickSquare m_SelectionB;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
            // TODO check if valid match
            if (m_SelectionA.value == m_SelectionB.value)
            {
                Destroy(m_SelectionA.gameObject);
                Destroy(m_SelectionB.gameObject);
            }
            else
            {
                // TODO add a pause here
                m_SelectionA.FlipBack();
                m_SelectionA = null;

                m_SelectionB.FlipBack();
                m_SelectionB = null;
            }
        }
    }
}
