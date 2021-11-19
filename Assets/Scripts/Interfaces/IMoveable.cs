using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    //Interface for a move method


    /// <summary>
    /// Returns a bool wether or not this object can move to said position,
    ///  and then moves the object on its grid
    /// </summary>
    /// <param name="position"></param>
    /// <returns>bool</returns>
    bool Move(Vector2Int _position);
}
