using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] Level level;
    [SerializeField] GameObject BlockVFX;
    [SerializeField] int MaxHits=1;
    [SerializeField] Sprite[] HitSprites;
    int SpriteIndex;
    int Hits;
    public void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag != "Solid")
        {
            level.CountBrokenBlocks();
        }
    }
    private void triggerEffects()
    {   
        GameObject sparkles = Instantiate(BlockVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   if (tag == "Solid")
        {
            MaxHits--;
            Hits++;
            if (MaxHits==0)
            {
                Destroy(gameObject);
                level.ReduceBlockCount();
                triggerEffects();
            }
            else {
                SpriteIndex = Hits - 1; //array index
                GetComponent<SpriteRenderer>().sprite = HitSprites[SpriteIndex];
            }
        }
        else
        {
            Destroy(gameObject);
            level.ReduceBlockCount();
            triggerEffects();
        }
    }
}  
