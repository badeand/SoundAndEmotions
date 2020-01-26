using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class GameState : MonoBehaviour
    {
        public List<Category> categories = new List<Category>();
        public List<String> pickedUpSoundRecordingNames = new List<String>();
        public List<String> unCategorizedSoundRecordingNames = new List<String>();

        
    }
}