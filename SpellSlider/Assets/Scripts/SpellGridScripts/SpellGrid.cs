﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellGrid : MonoBehaviour
{

    bool IsActive;
    List<SpellButton> ActivatedButtons;
    List<SpellLine> SpellLines;
    SpellButton LastActive = null;
    SpellPattern LastPattern;
    


    public Material lineMaterial;
    public Text SpellText;


    private void Start()
    {
        IsActive = false;
        ActivatedButtons = new List<SpellButton>();
        SpellLines = new List<SpellLine>();
        LastPattern = new SpellPattern();
    }


    public void SpellButtonActivate(SpellButton sender)
    {

        if(LastActive != null) {
            Debug.Log("Last active begin: " + LastActive.Position);
        }
        // Button has not been activated before -> activate and add lines if LastActive not null
        if (sender.touchCount == 0)
        {
            // Activate new button
            sender.GetComponent<SpriteRenderer>().color = Color.red;
            sender.Activated = true;
            sender.touchCount++;
            ActivatedButtons.Add(sender);

            if (LastActive != null)
            {
                SpellLine newLine = new SpellLine(LastActive, sender);
                newLine.DrawLines(lineMaterial, 0);
                SpellLines.Add(newLine);
            }
        }

        // Button has been activated before
        else if(LastActive != null && LastActive.Position != sender.Position)
        {
            SpellLine newLine = new SpellLine(LastActive, sender);
            // Check if SpellLines already contains created line
            int lineCount = SpellLines.FindAll(delegate (SpellLine spellLine) { return spellLine.Equals(newLine); }).Count;
            if (lineCount == 0)
            {
                // Line not found in spell lines -> deaw and add line
                newLine.DrawLines(lineMaterial, lineCount);
                SpellLines.Add(newLine);
            }
            else if(lineCount == 1){
                // Line already found in SpellLines
                // Get index of existing line
                int index = SpellLines.IndexOf(newLine);
                // Destroy existing line renderer
                SpellLines[index].DestroyRenderedLines();
                // Add new line to spell lines and draw double line
                newLine.DrawLines(lineMaterial, lineCount);
                SpellLines.Add(newLine);
            }
        }
        
        //
        if(LastActive == null) {
            LastActive = sender;
        }
        else if(LastActive.Position != sender.Position) {
            LastActive = sender;
        }
        Debug.Log("Last active end: " + LastActive.Position);
    }


    public void TouchActivate()
    {
        Debug.Log("Grid active!");
        IsActive = true;
    }

    public SpellPattern TouchEnd()
    {
        IsActive = false;
        LastActive = null;
        SpellPattern spellPattern = new SpellPattern(SpellLines);
        if(spellPattern.Equals(LastPattern)){
            SpellText.text = "\n MATCH!";
        }
        else {
            SpellText.text = "NO MATCH";
        }
        ResetButtons();
        DestroyLines();
        ActivatedButtons = new List<SpellButton>();
        SpellLines = new List<SpellLine>();
        
        LastPattern = spellPattern;
        return spellPattern;

    }

    private void ResetButtons()
    {
        foreach (SpellButton button in ActivatedButtons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.white;
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