using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPattern : IEquatable<SpellPattern>{
    
    List<PatternLine> Lines { get; set; }

    public SpellPattern()
    {
        Lines = new List<PatternLine>();        
    }
    public SpellPattern(List<SpellLine> spellLines) {
        Lines = new List<PatternLine>();
        foreach(SpellLine spellLine in spellLines) {
            Lines.Add(new PatternLine(spellLine));
        }
    }

    public override string ToString()
    {
        string str = "";
        foreach(PatternLine line in Lines) {
            str += string.Format("[({0},{1})->({2},{3})] ", line.Start.x, line.Start.y,
            line.End.x, line.End.y);
        }
        return str;
    }

    public bool Equals(SpellPattern spellPattern) {
        int lineCount;
        int otherCount;
        bool areEqual = true;
        if(Lines.Count != spellPattern.Lines.Count) {
            return false;
        }
        foreach (PatternLine line in Lines) 
        {
            lineCount = Lines.FindAll(delegate (PatternLine patternLine) { return line.Equals(patternLine); }).Count; 
            otherCount = spellPattern.Lines.FindAll(delegate (PatternLine patternLine) { return line.Equals(patternLine); }).Count;

            if(lineCount != otherCount) {
                areEqual = false;
            }
        }

        return areEqual;
    }

}

public class PatternLine : IEquatable<PatternLine> {
    public Vector2 Start;
    public Vector2 End;

    public PatternLine(SpellLine spellLine) {
        Start = spellLine.Start.Position;
        End = spellLine.End.Position;
    }

    public bool Equals(PatternLine patternLine) 
    {
        if(Start == patternLine.Start &&
            End == patternLine.End) { return true; }
        else if(Start == patternLine.End &&
            End == patternLine.Start) { return true; }
        return false;
    }
}




