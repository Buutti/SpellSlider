using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonster : Enemy {

	public override void Initialize()
	{
		enemyPatterns = new List<SpellPattern>();
		enemyPatterns.Add(new SpellPattern
			{
				Lines = new List<PatternLine>()
				{
					PatternLine.TwoFour,
					PatternLine.TwoSix,
					PatternLine.FourSeven,
					PatternLine.SixNine,
					PatternLine.EightNine,
					PatternLine.SevenEight
				}
			});
	}
	// Use this for initialization
	void Start () {
		Initialize();
	}


}
