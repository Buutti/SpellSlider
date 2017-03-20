using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandMonster : Enemy {

	// Use this for initialization
	void Start () {
        Initialize();
	}

    public override void Initialize()
    {
        enemyPatterns = new List<SpellPattern>();
        enemyPatterns.Add(new SpellPattern
        {
            Lines = new List<PatternLine>()
                    {
                        PatternLine.OneTwo,
                        PatternLine.OneFive,
                        PatternLine.TwoThree,
                        PatternLine.ThreeFive,
                        PatternLine.FiveSeven,
                        PatternLine.FiveNine,
                        PatternLine.SevenEight,
                        PatternLine.EightNine
                    }
        });
    }
}
