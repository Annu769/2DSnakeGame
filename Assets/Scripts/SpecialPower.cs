using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPower : MonoBehaviour
{
    public enum PowerUpsType
    {
        None,
        Speed,
        Slow,
        ScoreBooster
    }
    [SerializeField] PowerUpsType powerType;
     public PowerUpsType GetPowerUpsType()
    {
        return powerType;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Snake>() != null)
        {
            this.gameObject.SetActive(false);
        }
    }
}
