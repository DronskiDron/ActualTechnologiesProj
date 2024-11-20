using System;
using ActualTechnologies.Game.State.Entities;
using UnityEngine;

namespace ActualTechnologies.Game.State.Buildings
{
    [Serializable]
    public class BuildingEntity : Entity
    {
        public string TypeId;
        public Vector3Int Position;
        public int Level;
    }
}
