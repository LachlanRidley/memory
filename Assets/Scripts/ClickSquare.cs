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

    private int m_FlipStage = 0;
    private bool m_ToldPairChecker = false;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (m_FlipStage == 1 && m_Transform.localScale.x > 0f)
        {
            m_Transform.localScale -= new Vector3(0.08f, 0f);
        }
        else if (m_FlipStage == 1 && m_Transform.localScale.x <= 0f)
        {
            m_FlipStage = 2;
            m_SpriteRenderer.sprite = cardTexture;
        }
        else if (m_FlipStage == 2 && m_Transform.localScale.x < 2f)
        {
            m_Transform.localScale += new Vector3(0.08f, 0f);
        }
        else if (m_FlipStage == 2 && m_Transform.localScale.x >= 2f && !m_ToldPairChecker)
        {
            pairChecker.SelectCard(this);
            m_ToldPairChecker = true;
        }
        else if (m_FlipStage == 3 && m_Transform.localScale.x > 0f)
        {
            m_Transform.localScale -= new Vector3(0.08f, 0f);
        }
        else if (m_FlipStage == 3 && m_Transform.localScale.x <= 0f)
        {
            m_FlipStage = 4;
            m_SpriteRenderer.sprite = backTexture;
        }
        else if (m_FlipStage == 4 && m_Transform.localScale.x < 2f)
        {
            m_Transform.localScale += new Vector3(0.08f, 0f);
        }
        else if (m_FlipStage == 4 && m_Transform.localScale.x >= 2f)
        {
            m_FlipStage = 0;
        }
    }

    public void FlipBack()
    {
        if (m_FlipStage == 2)
        {
            m_FlipStage = 3;
            m_ToldPairChecker = false;
        }
    }
    void OnMouseDown()
    {
        if (m_FlipStage == 0)
        {
            m_FlipStage = 1;
        } else if (m_FlipStage == 2)
        {
            FlipBack();
        }
        
    }
}
