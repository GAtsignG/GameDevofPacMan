using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision2D
{

    private bool collision = false;
    public bool isCollision()
    {
        return collision;
    }

    private autoCollider a;
    private autoCollider b;

    bounds2D boundsA;
    bounds2D boundsB;

    private Color[] bitsA;
    private Color[] bitsB;

    public static bool collides(autoCollider a, autoCollider b)
    {
        return new collision2D(a, b).collision;
    }

    private collision2D(autoCollider a, autoCollider b)
    {
        this.a = a;
        this.b = b;
        boundsA = a.getBounds();
        boundsB = b.getBounds();
        checkCollsion();
    }

    private void checkCollsion()
    {
        if (texturesOverlap())
        {
            collision = perPixelCollision();
        }
    }

    private bool texturesOverlap()
    {
        return a.getBounds().overlaps(b.getBounds());
    }

    private bool perPixelCollision()
    {
        getBits();
        if (bitsA.Length != bitsB.Length)
        {
            Debug.LogError("Bits do not overlap");
            return false;
        }
        for (int i = 0; i < bitsA.Length; i++)
        {
            // If both colors are not transparent (the alpha channel is not 0), then there is a collision
            if (bitsA[i].a != 0 && bitsB[i].a != 0)
            {
                return true;
            }
        }
        return false;
    }

    private void getBits()
    {
        //Intersection of the two bounds in global space.
        bounds2D intersection = boundsA.intersection(boundsB);

        //Intersections in local space.
        bounds2D intersectionA = boundsA.toLocal(intersection);
        bounds2D intersectionB = boundsB.toLocal(intersection);

        bitsA = getBitArray(intersectionA, a.collisionMask);
        bitsB = getBitArray(intersectionB, b.collisionMask);
    }

    private static Color[] getBitArray(bounds2D section, Texture2D texture)
    {
        return texture.GetPixels(section.x, section.y, section.width, section.height);
    }

}
