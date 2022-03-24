using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scCard : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public int Value;
    public Sprite FrontFace;
    public Sprite BackFace;
    public bool IsFlipped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        
    }
    public void Flip()
    {
        if (IsFlipped)
        {
            spriteRenderer.sprite = BackFace;
            IsFlipped = false;
        }
        else if (!IsFlipped)
        {
            spriteRenderer.sprite = FrontFace;
            IsFlipped = true;
        }
    }
}
