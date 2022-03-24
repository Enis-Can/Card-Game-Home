using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject CardSample;
    public static System.Random rand = new System.Random();
    public int random = 0;
    List<int> frontList = new List<int> {  };
    public int[] facesUp = { -1, -2 };
    public int Level;

    void Start()
    {
        //Kartlarýn oluþturulmasý
        float yWise = 2.3f;
        float xWise = -6.2f;
        Level = LevelHolder.Level;
        for (int i = 0; i < Level; i++)
        {
            frontList.Add(i);
            frontList.Add(i);
        }
        int cardCount = Level * 2;
        for (int i = 0; i < cardCount; i++)
        {
            random = rand.Next(0, (frontList.Count));
            var temporary = Instantiate(CardSample, new Vector3(xWise, yWise, 0), Quaternion.identity) as GameObject;
            temporary.GetComponent<MainObject>().frontIndex = frontList[random];
            frontList.Remove(frontList[random]);
            xWise = xWise + 4;
            if (i == (cardCount / 2 - 1))
            {
                yWise = -2.3f;
                xWise = -6.2f;
            }
        }

    }
    private void Awake()
    {
        Debug.Log(Level);
    }

    //Ýki kart açýk mý check
    public bool isTwoFaceUp()
    {
        bool check = false;
        if (facesUp[0] >= 0 && facesUp[1] >= 0)
        {
            check = true;
        }
        return check;
    }

    //Açýk kartlar eþ mi check
    public bool isTwoMatch()
    {
        bool check = false;
        if (facesUp[0] == facesUp[1])
        {
            facesUp[0] = -1;
            facesUp[1] = -2;
            check = true;
        }
        return check;
    }

    //Kart aç
    public void openFace(int face)
    {
        if (facesUp[0] == -1)
        {
            facesUp[0] = face;
        }
        else if (facesUp[1] == -2)
        {
            facesUp[1] = face;

        }

    }

    //Kart kapa
    public void closeFace(int face)
    {
        if (facesUp[0] == face)
        {
            facesUp[0] = -1;
        }
        if (facesUp[1] == face)
        {
            facesUp[1] = -2;
        }
    }

}