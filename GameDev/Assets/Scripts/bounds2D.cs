using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounds2D
{

    public int x { get; set; }
    public int y { get; set; }
    public int width { get; set; }
    public int height { get; set; }

    public bounds2D() : this(0, 0, 0, 0) { }

    public bounds2D(int x, int y, int width, int height)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    public bool overlaps(bounds2D other)
    {
        return isHorizontalOverlap(other) && isVerticalOverlap(other);
    }

    public bool isHorizontalOverlap(bounds2D other)
    {
        return !(x > other.x + other.width || other.x > x + width);
    }

    public bool isVerticalOverlap(bounds2D other)
    {
        return !(y > other.y + other.height || other.y > y + height);
    }

    public bounds2D intersection(bounds2D other)
    {
        bounds2D ret = new bounds2D();
        ret.x = Mathf.Max(x, other.x);
        ret.y = Mathf.Max(y, other.y);
        ret.width = Mathf.Abs(ret.x - Mathf.Min(x + width, other.x + other.width));
        ret.height = Mathf.Abs(ret.y - Mathf.Min(y + height, other.y + other.height));
        return ret;
    }

    public bounds2D toLocal(bounds2D global)
    {
        bounds2D ret = new bounds2D();
        ret.x = global.x - x;
        ret.y = global.y - y;
        ret.width = global.width;
        ret.height = global.height;
        return ret;
    }

    public override string ToString()
    {
        return "(" + x + "," + y + "," + width + "," + height + ")";
    }

}

