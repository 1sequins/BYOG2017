using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Memory : MonoBehaviour {

    bool isCaptured;
    SpriteRenderer spriteRenderer;
    BoxCollider2D coll;

    [SerializeField]
    GameObject effects, fireball;

    [SerializeField]
    Image diaryImage;

	// Use this for initialization
	void Start () {
        isCaptured = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    public bool isMemoryCaptured()
    {
        return isCaptured;
    }

    public void captureMemory()
    {
        Color img = diaryImage.color;
        img.a = 0.25f;
        diaryImage.color = img;
        diaryImage.DOFade(0.0f, 1.0f);
        Instantiate(fireball, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
        isCaptured = true;
        spriteRenderer.enabled = false;
        coll.enabled = false;
        effects.SetActive(false);
        Door.collectedMemories.Add(this);
    }

    void OnTriggerEnter2D(Collider2D _coll)
    {
        if (_coll.tag == "Player") {
            captureMemory();
        }
    }
}
