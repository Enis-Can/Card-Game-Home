using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    GameObject GameCtrl;
    SpriteRenderer spriteRenderer;
    public Sprite[] front;
    public Sprite back;
    public int frontIndex;
    public bool isTwoMatch = false;

    public void OnMouseDown()
    {
        if (isTwoMatch == false)
        {
            if (spriteRenderer.sprite == back)
            {
                if (!GameCtrl.GetComponent<GameController>().isTwoFaceUp())
                {
                    spriteRenderer.sprite = front[frontIndex];
                    GameCtrl.GetComponent<GameController>().openFace(frontIndex);
                    isTwoMatch = GameCtrl.GetComponent<GameController>().isTwoMatch();
                    if (isTwoMatch)
                    {
                        GameObject.FindWithTag("Flipped").GetComponent<MainObject>().isTwoMatch = true;
                    }
                    gameObject.tag = "Flipped";
                    if (isTwoMatch)
                    {
                        unflip();
                    }
                    else if (GameCtrl.GetComponent<GameController>().isTwoFaceUp())
                    {
                        spriteRenderer.sprite = back;
                        GameObject.FindWithTag("Flipped").GetComponent<MainObject>().spriteRenderer.sprite = back;
                        unflip();
                    }
                }
            }
            else if (spriteRenderer.sprite == front[frontIndex])
            {
                spriteRenderer.sprite = back;
                GameCtrl.GetComponent<GameController>().closeFace(frontIndex);
                gameObject.tag = "Untagged";
            }
        }
    }
    private void Awake()
    {

        GameCtrl = GameObject.Find("GameManager");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void unflip()
    {
        gameObject.tag = "Untagged";
        GameObject.FindWithTag("Flipped").tag = "Untagged";
        GameCtrl.GetComponent<GameController>().facesUp[0] = -1;
        GameCtrl.GetComponent<GameController>().facesUp[1] = -2;
    }
}
