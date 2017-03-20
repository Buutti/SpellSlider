using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMonster : Enemy {

    public override void Initialize()
    {
        enemyPatterns = new List<SpellPattern>();
        enemyPatterns.Add(new SpellPattern
        {
            Lines = new List<PatternLine>()
                    {
                        PatternLine.OneFive,
                        PatternLine.OneFour,
                        PatternLine.ThreeFive,
                        PatternLine.ThreeSix,
                        PatternLine.FourSeven,
                        PatternLine.SixNine,
                        PatternLine.SevenEight,
                        PatternLine.EightNine
                    }
        });
    }
    // Use this for initialization
    void Start () {
        Initialize();
	}
	

}
