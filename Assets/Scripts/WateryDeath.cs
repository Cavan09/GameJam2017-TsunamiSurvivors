using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class WateryDeath : MonoBehaviour
{
    BoxCollider2D Deathbox;

    private void Start()
    {
        Deathbox = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("Player"))
        {
            //Debug.Log("Player is in the house!");
            if (collision is BoxCollider2D)
            {
                if (IsSubmerged(collision.gameObject.GetComponent<BoxCollider2D>()))
                {
                    Debug.Log("DIE!");
                    collision.gameObject.GetComponent<PlatformerCharacter2D>().Drowning();
                }
            }
        }
    }

    private bool IsSubmerged(Collider2D collision)
    {
        Bounds enterableBounds = Deathbox.bounds;
        Bounds enteringBounds = collision.bounds;

        Vector2 center = enteringBounds.center;
        Vector2 extents = enteringBounds.extents;
        Vector2[] enteringVerticles = new Vector2[4];

        enteringVerticles[0] = new Vector2(center.x + extents.x, center.y + extents.y);
        enteringVerticles[1] = new Vector2(center.x - extents.x, center.y + extents.y);
        enteringVerticles[2] = new Vector2(center.x + extents.x, center.y - extents.y);
        enteringVerticles[3] = new Vector2(center.x - extents.x, center.y - extents.y);

        foreach (Vector2 verticle in enteringVerticles)
        {
            if (!enterableBounds.Contains(verticle))
            {
                return false;
            }
        }
        return true;
    }
}
