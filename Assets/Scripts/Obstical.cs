using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstical : MonoBehaviour {

    BoxCollider2D m_Collider;
    Rigidbody2D m_Body;
    //Effector2D m_Effector;
    Vector2[] collitionPoints = new Vector2[2];

	// Use this for initialization
	void Start () {
        m_Collider = GetComponent<BoxCollider2D>();
        m_Body = gameObject.AddComponent<Rigidbody2D>();
        m_Body.bodyType = RigidbodyType2D.Static;
        //m_Effector = gameObject.AddComponent<Effector2D>();
        m_Collider.usedByEffector = true;
        
	}

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag.Contains("Player"))
        {
            var collisionNormal = collision.contacts[0].normal;
            var result = Vector2.Dot(collisionNormal, Vector2.up);
            if (Mathf.Abs(result) < 0.8)
            {
                collision.gameObject.GetComponent<DamagePlayer>().StartDamage();
            }
        }
    }
}
