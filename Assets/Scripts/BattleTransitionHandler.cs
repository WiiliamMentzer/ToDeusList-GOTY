using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BattleCore{
    public class BattleTransitionHandler : MonoBehaviour
    {
        private Vector3 startPosition;

        [field: SerializeField] 
        public float timeRemaining = 30;
        public bool battleStart = false;
        public bool battleFinish = false;
        private Vector3 loopPosition { get; set; }
        
        void Start()
        {
            startPosition = transform.localPosition;
            timeRemaining = 5;
        }

        // Update is called once per frame
        void Update()
        {
            if (battleStart == false){
                if (timeRemaining > 0)
                {
                    transform.Translate(new Vector3(100 * Time.deltaTime, 0 ,0));
                    timeRemaining -= Time.deltaTime;
                } else {
                    battleStart = true;
                    timeRemaining = 5;
                }
            }
            if (battleFinish == true){
                if (timeRemaining > 0)
                {
                    transform.Translate(new Vector3(-75 * Time.deltaTime, 0 ,0));
                    timeRemaining -= Time.deltaTime;
                } else {
                    return;
                }
            }
        }
    }
}