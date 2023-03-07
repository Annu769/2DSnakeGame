using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
   public enum FoodType
    {
        none,
        MassGainer,
        MassBurner
    }
    [SerializeField] FoodType type;
    [SerializeField] BoxCollider2D spawnArea;
    // Start is called before the first frame update
   public FoodType GetFoodType()
    {
        return type;
    }

    // Update is called once per frame
   void FoodSpawn()
    {
        Bounds bounds = spawnArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.GetComponent<Snake>() != null )
        {
            FoodSpawn();
        }
    }
}
