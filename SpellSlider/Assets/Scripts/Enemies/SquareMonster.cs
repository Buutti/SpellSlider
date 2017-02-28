using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMonster : Enemy
{
    /// <summary>
    /// Set spell pattern and other instance variables
    /// </summary>
    public override void Initialize()
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

    private void Start()
    {
        Initialize();
    }

}
