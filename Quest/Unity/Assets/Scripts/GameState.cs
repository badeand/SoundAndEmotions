using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class GameState : MonoBehaviour
    {
        
        
        public List<Category> Categories = new List<Category>();
        public List<String> PickedUpSoundRecordingNames = new List<String>();

        
    }
}