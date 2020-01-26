using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class Category 
    {
        public string Name;
        public List<string> SoundRecordingNames = new List<string>();
    }
}