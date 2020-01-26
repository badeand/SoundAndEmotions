using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    
    public class Category : MonoBehaviour
    {
        public string Name;
        public HashSet<SoundRecording> SoundRecordings;
    }
}