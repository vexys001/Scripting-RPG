using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCalculator : MonoBehaviour
{
    public float CalculateElement(GlobalEnums.Elements attackingElement, GlobalEnums.Elements defendingElement)
    {
        if (attackingElement == defendingElement)
        {
            return 0.1f;
        }

        if (attackingElement == GlobalEnums.Elements.FIRE && defendingElement == GlobalEnums.Elements.WATER
             || attackingElement == GlobalEnums.Elements.WATER && defendingElement == GlobalEnums.Elements.THUNDER
             || attackingElement == GlobalEnums.Elements.THUNDER && defendingElement == GlobalEnums.Elements.EARTH
             || attackingElement == GlobalEnums.Elements.EARTH && defendingElement == GlobalEnums.Elements.FIRE)
        {
            return 0.5f;
        }

        if (attackingElement == GlobalEnums.Elements.WATER && defendingElement == GlobalEnums.Elements.FIRE
             || attackingElement == GlobalEnums.Elements.THUNDER && defendingElement == GlobalEnums.Elements.WATER
             || attackingElement == GlobalEnums.Elements.EARTH && defendingElement == GlobalEnums.Elements.THUNDER
             || attackingElement == GlobalEnums.Elements.FIRE && defendingElement == GlobalEnums.Elements.EARTH)
        {
            return 2f;
        }

        return 1f;
    }
}
