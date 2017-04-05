using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMonster : Enemy {

	public override void Initialize()
	{
		enemyPatterns = new List<SpellPattern>();
		enemyPatterns.Add(new SpellPattern
			{
				Lines = new List<PatternLine>()
				{
					PatternLine.OneTwo,
					PatternLine.OneFour,
					PatternLine.TwoThree,
					PatternLine.ThreeSix,
					PatternLine.FourFive,
					PatternLine.FiveSix,
					PatternLine.FiveEight
				}
			});
	}
	// Use this for initialization
	void Start () {
		Initialize();
	}


}
