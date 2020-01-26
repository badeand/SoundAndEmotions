using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace DefaultNamespace
{
    public class GameStateManager : MonoBehaviour
    {
        public List<SoundRecording> pickedUpSoundRecordings = new List<SoundRecording>();
        public List<CategoryContainer> categoryContainers;
        public List<SoundRecording> managedSoundRecordings = new List<SoundRecording>();


        private void Awake()
        {
            // SendUpdateToServer();
        }

        public void AddToPickedUpSoundRecordings(SoundRecording soundRecording)
        {
            pickedUpSoundRecordings.Add(soundRecording);
            SendUpdateToServer();
        }

        public void RemovedFromPickupedUpSoundRecordings(SoundRecording soundRecording)
        {
            pickedUpSoundRecordings.Remove(soundRecording);
            SendUpdateToServer();
        }

        public void SendUpdateToServer()
        {
            GameState gameState = new GameState();

            foreach (var soundRecording in pickedUpSoundRecordings)
            {
                gameState.pickedUpSoundRecordingNames.Add(soundRecording.Name);
            }

            List<SoundRecording> uncategrozed = new List<SoundRecording>();
            uncategrozed.AddRange(managedSoundRecordings);
            foreach (var categoryContainer in categoryContainers)
            {
                foreach (var r in categoryContainer.soundRecordings)
                {
                    uncategrozed.Remove(r);
                }
            }

            foreach (var _recording in uncategrozed)
            {
                gameState.unCategorizedSoundRecordingNames.Add(_recording.Name);
            }


            
            foreach (var categoryContainer in categoryContainers)
            {
                var category = new Category();
                category.Name = categoryContainer.categoryName;
                foreach (var soundRecording in categoryContainer.soundRecordings)
                {
                    category.SoundRecordingNames.Add(soundRecording.Name);
                }

                gameState.categories.Add(category);
            }

            StartCoroutine(Post("http://192.168.10.165:1880/gamestate", JsonUtility.ToJson(gameState)));
        }

        IEnumerator Post(string url, string bodyJsonString)
        {
            var request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
            request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            yield return request.SendWebRequest();
            Debug.Log("Status Code: " + request.responseCode);
        }
    }
}