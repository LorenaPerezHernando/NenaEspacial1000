using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class OnCollisionDestroy : MonoBehaviour
{
    public GameObject prefabPlant;
    public int posInitialGrowth;
    [SerializeField] bool plantFullyGrown;

    GrowPlant s_growPlant;

    private void Start()
    {
        GetComponent<GrowPlant>();
        // posInitialGrowth = s_growPlant.highPosY - s_growPlant.highPosY;
        posInitialGrowth = -1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && s_growPlant.fullyGrown == true)
        {
            StartCoroutine(CreateNewPlant());
        }
    }

    IEnumerator CreateNewPlant()
    {
        Instantiate(prefabPlant, new Vector3(transform.position.x, posInitialGrowth, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
