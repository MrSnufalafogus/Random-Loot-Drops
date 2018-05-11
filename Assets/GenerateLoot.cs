using Assets.Loot;
using Assets.Loot.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLoot : MonoBehaviour {

    private Item ranItem;
    public Sprite[] sprites;
    SpriteRenderer spr;

    // Use this for initialization
    void Start () {
         spr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ranItem = GenerateRandomItem();
            spr.sprite = null;
            if(ranItem != null)
            {
                if (ranItem.type != null)
                {
                    spr.sprite = sprites[ranItem.spriteIndex];
                }
            }
            Debug.Log(ranItem.type);
        }
	}

    private Item GenerateRandomItem()
    {
        System.Random r = new System.Random();
        switch (r.Next(0,2))
        {
            case 1:
                Debug.Log("Armor");
                return new Armor();
            case 2:
                Debug.Log("Loot");
                return new Loot();
        }
        return null;
    }
}
