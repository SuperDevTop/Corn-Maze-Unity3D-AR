using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GPSLine
{
    private float startX;
    private float startY;
    private float endX;
    private float endY;

    public float StartX
    {
        get { return startX; }
        set { startX = value; }
    }

    public float StartY
    {
        get { return startY; }
        set { startY = value; }
    }

    public float EndX
    {
        get { return endX; }
        set { endX = value; }
    }

    public float EndY
    {
        get { return endY; }
        set { endY = value; }
    }
}
