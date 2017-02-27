using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMonster : Enemy
{
    private void Awake()
    {
        enemyPatterns = new List<SpellPattern>();
        enemyPatterns.Add(new SpellPattern
        {
            Lines = new List<PatternLine>()
                    {
                        PatternLine.OneTwo,
                        PatternLine.TwoFive,
                        PatternLine.FourFive,
                        PatternLine.OneFour
                    }
        });
    }


}
