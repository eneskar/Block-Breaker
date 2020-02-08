using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip explode;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    Level level;
    GameStatus gameStatus;

    [SerializeField] int timesHit;  //TODO only serialized for debug purposes

    private void Start(){
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameStatus>();
        if(tag == "Breakable"){
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(tag == "Breakable"){
            timesHit++;
            if(timesHit >= maxHits){
                DestroyBlock();
            } else{
                ShowNextHitSprite();
            }
            
        }
        
    }

    private void DestroyBlock(){
        Destroy(gameObject);
        TriggerSparklesVFX();
        AudioSource.PlayClipAtPoint(explode, Camera.main.transform.position);
        level.BlockDestroyed();
        gameStatus.AddToScore();
    }

    private void TriggerSparklesVFX(){
        Vector3 blockPosition = transform.position;
        blockPosition.z = transform.position.z - 1;
        GameObject sparkle = Instantiate(blockSparkleVFX,blockPosition,transform.rotation);
        Destroy(sparkle, 1f);
    }

    private void ShowNextHitSprite(){
        int spriteIndex = timesHit -1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; 
    }

}
