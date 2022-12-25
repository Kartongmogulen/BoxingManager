using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomAttackFocus : MonoBehaviour
{
    public int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        randomInt = Random.Range(0, 2);
        GetComponent<player>().AttackFocus = (global::attackFocus)randomInt;
    }

    
}
