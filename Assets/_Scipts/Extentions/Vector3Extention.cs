using UnityEngine;

public static class Vector3Extention
{
    public static Vector3 Round(Vector3 vector)
    {
        var x = Mathf.RoundToInt(vector.x);
        var y = Mathf.RoundToInt(vector.y);
        var z = Mathf.RoundToInt(vector.z);

        return new Vector3(x, y, z);
    }
    
    
}