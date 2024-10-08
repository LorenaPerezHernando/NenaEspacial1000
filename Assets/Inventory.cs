using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
     public int flor;
     public int mush;
     public int hierba;
     public bool extraLife;

    public float nivel;

    private void Update()
    {
        if (flor >= 3 && mush >= 3 && hierba >= 3)
            nivel = 1.5f;
    }

}
