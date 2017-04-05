using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMonster : Enemy {

	public override void Initialize()
	{
		enemyPatterns = new List<SpellPattern>();
		enemyPatterns.Add(new SpellPattern
			{
				Lines = new List<PatternLine>()
				{
					PatternLine.OneTwo,
					PatternLine.OneEight,
					PatternLine.TwoThree,
					PatternLine.ThreeEight

				}
			});
	}
	// Use this for initialization
	void Start () {
		Initialize();
	}


}
