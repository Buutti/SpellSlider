using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMonster : Enemy
{
    protected override SpellPattern SpellPattern
    {
        get
        {
            return new SpellPattern()
            {
                Lines = new List<PatternLine>()
                    {
                        PatternLine.OneTwo,
                        PatternLine.TwoFive,
                        PatternLine.FourFive,
                        PatternLine.OneFour
                    }
            };
        }
    }

    private void Start()
    {

    }
}
