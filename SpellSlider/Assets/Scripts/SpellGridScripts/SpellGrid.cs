using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellGrid : MonoBehaviour
{
    List<SpellButton> ActivatedButtons;
    List<SpellLine> SpellLines;
    SpellButton LastActive = null;

    public AdventureView adventureView;
    public Material lineMaterial;
    public Text SpellText;


    private void Start()
    {
        ActivatedButtons = new List<SpellButton>();
        SpellLines = new List<SpellLine>();
    }


    public void SpellButtonActivate(SpellButton sender)
    {
		SpellLine newLine = null;
		if (LastActive != null) {
			newLine = new SpellLine (LastActive, sender);
			if (newLine.IsValid ()) 
			{
				// Button has not been activated before -> activate and add lines if LastActive not null
				if (sender.touchCount == 0)
				{
					// Activate new button
					sender.GetComponent<Image>().color = Color.red;
					sender.Activated = true;
					sender.touchCount++;
					ActivatedButtons.Add(sender);

					newLine.DrawLines (lineMaterial, 0);
					SpellLines.Add (newLine);
				}
				// Button has been activated before
				else if(LastActive.Position != sender.Position)
				{
					// Check if SpellLines already contains created line
					int lineCount = SpellLines.FindAll (delegate (SpellLine spellLine) {
						return spellLine.Equals (newLine);
					}).Count;
					if (lineCount == 0) {
						// Line not found in spell lines -> deaw and add line
						newLine.DrawLines (lineMaterial, lineCount);
						SpellLines.Add (newLine);
					} 
					else if (lineCount == 1) {
						// Line already found in SpellLines
						// Get index of existing line
						int index = SpellLines.IndexOf (newLine);
						// Destroy existing line renderer
						SpellLines [index].DestroyRenderedLines ();
						// Add new line to spell lines and draw double line
						newLine.DrawLines (lineMaterial, lineCount);
						SpellLines.Add (newLine);
					}
				}

				if(LastActive.Position != sender.Position) {
					LastActive = sender;
				}
			}
		} 
		else 
		{
			// Activate new button
			sender.GetComponent<Image>().color = Color.red;
			sender.Activated = true;
			sender.touchCount++;
			ActivatedButtons.Add(sender);
		}
        
        //
        if(LastActive == null) {
            LastActive = sender;
        }

    }


    public void TouchActivate()
    {
    }

    public SpellPattern TouchEnd()
    {
        LastActive = null;
        SpellPattern spellPattern = new SpellPattern(SpellLines);
        adventureView.PatternDrawn(spellPattern);
        ResetButtons();
        DestroyLines();
        ActivatedButtons = new List<SpellButton>();
        SpellLines = new List<SpellLine>();
        
        return spellPattern;

    }

    private void ResetButtons()
    {
        foreach (SpellButton button in ActivatedButtons)
        {
            button.GetComponent<Image>().color = Color.white;
            button.Activated = false;
            button.touchCount = 0;
        }        
    }

    private void DestroyLines() 
    {
        foreach(SpellLine line in SpellLines) {
            line.DestroyRenderedLines();
        }
    }
}
