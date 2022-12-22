using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleCore {
    public class AudioHandler : MonoBehaviour
    {
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource toDoLaugh;
        [SerializeField] private BattleTransitionHandler CubeCheck;

        public bool laughTrack;

        void Start()
        {
            musicSource.Play();
        }

        // Update is called once per frame
        void Update()
        {
            if ( CubeCheck.battleFinish == true ){
                musicSource.volume -= 0.0000240f;
            }

            if (laughTrack == true){
                toDoLaugh.Play();
                laughTrack = false;
                Debug.Log("KefkaShouldBePlaying");
            }
        }
    }
}
