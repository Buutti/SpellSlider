using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class Extensions {

    /// <summary>
    /// Randomize a list of type T
    /// </summary>
    /// <typeparam name="T">Type of list elements</typeparam>
    /// <param name="list">List to be randomized</param>
    /// <param name="rnd">Random number generator</param>
    public static void Shuffle<T>(this IList<T> list, System.Random rnd)
    {
        for (var i = 0; i < list.Count; i++)
            list.Swap(i, rnd.Next(i, list.Count));
    }

    /// <summary>
    /// Swap two elements in a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">List containing the two elements</param>
    /// <param name="i">Index of the first list element</param>
    /// <param name="j">Index of the second list element</param>
    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}
