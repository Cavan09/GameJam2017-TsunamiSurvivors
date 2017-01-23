using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class DamagePlayer : MonoBehaviour {

    public float m_DamagaTimer = 0;
    public float m_RecoverTimer = 0;
    private SpriteRenderer renderer;
    private Platformer2DUserControl control;
    private Color origColor;
    bool atOrigColor = true;
    Color currentColor;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        if(renderer == null)
        {
            renderer = GetComponentInChildren<SpriteRenderer>();
            currentColor = renderer.color;
        }
        currentColor = renderer.color;
        control = GetComponent<Platformer2DUserControl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (m_DamagaTimer > 0)
        {
            m_DamagaTimer -= 0.1f;
            renderer.color = Color.Lerp(currentColor, Color.red, Mathf.PingPong(Time.time * 10, 1f));
        }
        else if(m_DamagaTimer <= 0 && m_RecoverTimer > 0)
        {
            m_RecoverTimer -= 0.1f;
            renderer.color = Color.Lerp(currentColor, Color.white, Mathf.PingPong(Time.time * 10, 1f));
            control.enabled = true;
        }
        else if (m_DamagaTimer <= 0 && m_RecoverTimer <= 0)
        {
            renderer.color = currentColor;
        }
    }

    public void StartDamage()
    {
        ResetPlayer();
        control.enabled = false;
    }

    private void ResetPlayer()
    {
        m_DamagaTimer = 3;
        m_RecoverTimer = 3;
    }
}
