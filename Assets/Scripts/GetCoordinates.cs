using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoordinates : MonoBehaviour
{
    public static GetCoordinates Instance;
    public float alpha;
    public float beta;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //print(Mathf.Atan(1));
        //print(MeasureDistance(45.25192522f, -74.30465933f, 45.25217242f, -74.30493051f));   

        alpha = Mathf.Atan(Mathf.Abs(45.25215997f - 45.25203097f) / Mathf.Abs(74.30477205f - 74.30492824f));
        //print(alpha);
        //print(GetPointInLine(45.25216886f, -74.30477276f, 45.25233876f, -74.30451992f).x);
        //beta = 180f / Mathf.PI * Mathf.Atan(MeasureDistance(45.25192522f, -74.30465933f, GetPointInLine(45.25216886f, -74.30477276f, 45.25233876f, -74.30451992f).x, -74.30465933f) / MeasureDistance(45.25192522f, -74.30465933f, 45.25192522f, GetPointInLine(45.25216886f, -74.30477276f, 45.25233876f, -74.30451992f).y));
        //print(beta);
    }

    // Update is called once per frame
    void Update()
    {
        //print(UnityEngine.Random.RandomRange(0, 1f));
    }

    public Vector2 InstantiateFixedPlace(float altitude, float longitude)
    {
        float x;
        float y;
        beta = Mathf.Atan(Mathf.Abs(altitude - 45.25217242f) / Mathf.Abs(Mathf.Abs(longitude) - 74.30493051f));

        if (altitude >= 45.25217242f)
        {
            print("UP");
            x = -72f + MeasureDistance(45.25217242f, -74.30493051f, altitude, longitude) * Mathf.Cos(alpha + beta);
            y = -72.4f + MeasureDistance(45.25217242f, -74.30493051f, altitude, longitude) * Mathf.Sin(alpha + beta);

            print("X:" + x);
            print("Y:" + y);
        }
        else
        {
            print("DOWN");
            x = -72f + MeasureDistance(45.25217242f, -74.30493051f, altitude, longitude) * Mathf.Cos(alpha - beta);
            y = -72.4f + MeasureDistance(45.25217242f, -74.30493051f, altitude, longitude) * Mathf.Sin(alpha - beta);

            print("X:" + x);
            print("Y:" + y);
        }

        return new Vector2(x, y);
    }

    public Vector2 GetPointInLine(GPSLine gpsLine)
    {
        float deltaX = gpsLine.EndX - gpsLine.StartX;
        float deltaY = gpsLine.EndY - gpsLine.StartY;

        float lat = gpsLine.StartX + deltaX * UnityEngine.Random.RandomRange(0, 1f);
        float lon = gpsLine.StartY + deltaY * UnityEngine.Random.RandomRange(0, 1f);

        print("LATX:" + lat);
        print("LATY:" + lon);

        return new Vector2(lat, lon);
    }

    public Vector2 InstantiateRandomPlace()
    {
        int index = UnityEngine.Random.RandomRange(0, 120);

        Vector2 vector = GetPointInLine(GPSLines.gpsLines[index]);
        float x;
        float y;
        beta = Mathf.Atan(Mathf.Abs(vector.x - 45.25217242f) / Mathf.Abs(Mathf.Abs( vector.y) - 74.30493051f));

        if (vector.x >= 45.25217242f)
        {
            print("UP");
            x = MeasureDistance(45.25217242f, -74.30493051f, vector.x, vector.y) * Mathf.Cos(alpha + beta);
            y = MeasureDistance(45.25217242f, -74.30493051f, vector.x, vector.y) * Mathf.Sin(alpha + beta);

            print("X:" + x);
            print("Y:" + y);
        }
        else
        {
            print("DOWN");
            x = MeasureDistance(45.25217242f, -74.30493051f, vector.x, vector.y) * Mathf.Cos(alpha - beta);
            y = - MeasureDistance(45.25217242f, -74.30493051f, vector.x, vector.y) * Mathf.Sin(alpha - beta);

            print("X:" + x);
            print("Y:" + y);
        }

        return new Vector2(x, y);
    }

    //public Vector2 GetPointInLine(float lat1, float lon1, float lat2, float lon2)
    //{
    //    float deltaX = lat2 - lat1;
    //    float deltaY = lon2 - lon1;

    //    float lat = lat1 + deltaX * UnityEngine.Random.RandomRange(0, 1f);
    //    float lon = lon1 + deltaY * UnityEngine.Random.RandomRange(0, 1f);

    //    print("LATX:" + lat);
    //    print("LATY:" + lon);
    //    return new Vector2(lat, lon);
    //}

    public float MeasureDistance(float lat1, float lon1, float lat2, float lon2)
    {
        float R = 6378.137f; // Radius of earth in KM
        float dLat = lat2 * Mathf.PI / 180f - lat1 * Mathf.PI / 180f;
        float dLon = lon2 * Mathf.PI / 180f - lon1 * Mathf.PI / 180f;
        float a = Mathf.Sin(dLat / 2f) * Mathf.Sin(dLat / 2f) +
        Mathf.Cos(lat1 * Mathf.PI / 180f) * Mathf.Cos(lat2 * Mathf.PI / 180f) * Mathf.Sin(dLon / 2f) * Mathf.Sin(dLon / 2f);
        float c = 2f * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1f - a));
        float d = R * c;
        return d * 1000f; // meters        
    }
}
