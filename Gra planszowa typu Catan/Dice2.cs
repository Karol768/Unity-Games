using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice2 : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public bool rolling;
    public int finalSide;
    public static bool roll;

	private void Start ()
     {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}

    void Update()
    {
        if(roll == true)
        {
            RollDice2();
            roll = false;
        }
    }

    private IEnumerator RollTheDice()
    {
        rolling = true;
        int randomDiceSide = 0;
        finalSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.1f);
        }
        finalSide = randomDiceSide + 1;
        rolling = false;

        ReadDices.d2 = true;
    }

    public void RollDice2()
    {
        if(rolling == false)
        StartCoroutine(RollTheDice());
    }
}
