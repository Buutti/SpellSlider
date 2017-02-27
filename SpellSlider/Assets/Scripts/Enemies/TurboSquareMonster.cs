using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboSquareMonster : Enemy
{
    private void Awake()
    {
        enemyPatterns = new List<SpellPattern>();
        enemyPatterns.Add(new SpellPattern()
        {
            Lines = new List<PatternLine>()
                    {
                        PatternLine.OneTwo,
                        PatternLine.TwoThree,
                        PatternLine.ThreeSix,
                        PatternLine.SixNine,
                        PatternLine.EightNine,
                        PatternLine.SevenEight,
                        PatternLine.FourSeven,
                        PatternLine.OneFour,
                    }
        });
    }
}
