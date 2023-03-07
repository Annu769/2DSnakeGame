using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapping : MonoBehaviour
{
    [SerializeField] BoxCollider2D GridArea;

    public Vector2Int ValidatePosition(Vector2Int Position)   
    {
        Bounds bounds = GridArea.bounds;
        if(Position.x < bounds.min.x)
        {
            Position.x =(int)bounds.max.x;
        }
      else if(Position.x  > bounds.max.x)
        {
            Position.x = (int)bounds.min.x;
        }
       else if(Position.y < bounds.min.y)
        {
            Position.y = (int)bounds.max.y;
        }
        else if(Position.y > bounds.max.y)
        {
            Position.y = (int)bounds.min.y;
        }
        return Position;
    }
}
