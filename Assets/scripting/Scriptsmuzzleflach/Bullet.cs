using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public Sprite muzzleFlash;
    public int framesToFlash = 3;
    public float destroyTime = 3;

    private SpriteRenderer spriteRend;
    private Sprite defaultSprite;
   

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        defaultSprite = spriteRend.sprite;

        StartCoroutine(FlashMuzzleFlash());
        StartCoroutine(TimedDestruction());
    }

    IEnumerator FlashMuzzleFlash()
    {

        spriteRend.sprite = muzzleFlash;

        for(int i = 0; i < framesToFlash; i++)
        {
            yield return 0;
        }

        spriteRend.sprite = defaultSprite;

    }

    IEnumerator TimedDestruction()
    {
        yield return new WaitForSeconds(destroyTime);

     
    }


	
}
