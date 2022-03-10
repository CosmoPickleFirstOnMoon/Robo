using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemData[] itemData;     //contains scriptable objects
    public Item[] itemObjects;      //contains game objects that will gets its data from itemData at runtime

    public static ItemManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
}
