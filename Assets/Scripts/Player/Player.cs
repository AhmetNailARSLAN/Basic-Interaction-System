using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp(GameObject gameObject)
    {
        gameObject.transform.SetParent(hand, false);

        gameObject.transform.localPosition = Vector3.zero;
    }


}
