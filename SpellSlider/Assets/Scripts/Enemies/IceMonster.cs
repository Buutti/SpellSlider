using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMonster : Enemy {

    void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        enemyPatterns = new List<SpellPattern>();
        enemyPatterns.Add(new SpellPattern
        {
            Lines = new List<PatternLine>()
                    {
                        PatternLine.TwoSix,
                        PatternLine.TwoFour,
                        PatternLine.SixEight,
                        PatternLine.FourEight
                    }
        });
    }
}
