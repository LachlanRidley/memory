using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSquare : MonoBehaviour
{
    public Sprite cardTexture;
    public Sprite backTexture;
    public int value;

    public PairChecker pairChecker;

    private SpriteRenderer m_SpriteRenderer;
    private Transform m_Transform;

    private float m_FullWidth;

    public CardState m_CardState = CardState.hidden;
    public bool destroyOnReveal = false;

    public float flipSpeed = 1f;

    public enum CardState
    {
        hidden, showing1, showing2, shown, hiding1, hiding2
    }

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Transform = GetComponent<Transform>();

        m_FullWidth = m_Transform.localScale.x;
    }

    void Update()
    {
        if (m_CardState == CardState.showing1 && m_Transform.localScale.x <= 0f)
        {
            m_SpriteRenderer.sprite = cardTexture;
            m_CardState = CardState.showing2;
        }
        else if (m_CardState == CardState.showing2 && m_Transform.localScale.x >= m_FullWidth)
        {
            m_CardState = CardState.shown;
        }
        else if (m_CardState == CardState.showing2)
        {
            m_Transform.localScale += new Vector3(flipSpeed, 0f);
        }
        else if (m_CardState == CardState.showing1)
        {
            m_Transform.localScale -= new Vector3(flipSpeed, 0f);
        }

        else if (m_CardState == CardState.hiding1 && m_Transform.localScale.x <= 0f)
        {
            m_SpriteRenderer.sprite = backTexture;
            m_CardState = CardState.hiding2;
        }
        else if (m_CardState == CardState.hiding2 && m_Transform.localScale.x >= m_FullWidth)
        {
            m_CardState = CardState.hidden;
        }
        else if (m_CardState == CardState.hiding2)
        {
            m_Transform.localScale += new Vector3(flipSpeed, 0f);
        }
        else if (m_CardState == CardState.hiding1)
        {
            m_Transform.localScale -= new Vector3(flipSpeed, 0f);
        }
    }

    public void FlipBack()
    {
        if (m_CardState == CardState.shown)
        {
            m_CardState = CardState.hiding1;
        }
    }

    void OnMouseDown()
    {
        if (m_CardState == CardState.hidden)
        {
            m_CardState = CardState.showing1;
            pairChecker.SelectCard(this);
        }
    }
}
