using System;
using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;

namespace UnitSystem
{
    public abstract class Unit : MonoBehaviour
    {
        public string Name;
        private UnitMovement _unitMovement;
    }
}