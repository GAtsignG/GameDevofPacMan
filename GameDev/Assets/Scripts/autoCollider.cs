using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoCollider : MonoBehaviour
{
    public Texture2D collisionMask;
    public bool pixelCollision;

    void Awake()
    {
        if (collisionMask == null)
        {
            collisionMask = GetComponent<SpriteRenderer>().sprite.texture;
        }
    }

    public bool collidesWith(autoCollider other)
    {
        if (pixelCollision)
        {
            return collision2D.collides(this, other);
        }
        return getBounds().overlaps(other.getBounds());
    }

    public bounds2D getBounds()
    {
        return new bounds2D(
            (int)transform.position.x - collisionMask.width * (int)transform.localScale.x / 2,
            (int)transform.position.y - collisionMask.height * (int)transform.localScale.y / 2,
            collisionMask.width * (int)transform.localScale.x,
            collisionMask.height * (int)transform.localScale.y);
    }
}
