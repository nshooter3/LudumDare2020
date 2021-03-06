﻿namespace GameManager
{
    using HarmonyQuest.Audio;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        //References to the prefabs we're gonna load into these objects later.
        public GameObject fmodHandler;
        public GameObject rewiredInputManager;
        public GameObject playerController;

        //The master list of all the objects that need to be updated, in order.
        private ObjectManager objectManager = new ObjectManager();

        private void PopulateUpdateQueue()
        {
            //Initialize all our one-of manageable objects that need to be in every scene.
            fmodHandler = Instantiate(fmodHandler);
            rewiredInputManager = Instantiate(rewiredInputManager);
            playerController = Instantiate(playerController);

            objectManager.AddManageableObject(fmodHandler.GetComponent<FmodFacade>());
            objectManager.AddManageableObject(fmodHandler.GetComponent<FmodMusicHandler>());
            objectManager.AddManageableObject(fmodHandler.GetComponent<FmodOnBeatAccuracyChecker>());
            objectManager.AddManageableObject(fmodHandler.GetComponent<FmodChordInterpreter>());
            objectManager.FindManageableObjectsInScene<FmodEventHandler>();

            objectManager.AddManageableObject(rewiredInputManager.GetComponent<RewiredPlayerInputManager>());

            objectManager.AddManageableObject(playerController.GetComponent<PlayerController>());

            objectManager.FindManageableObjectsInScene<BeatCommandPool>();
            objectManager.FindManageableObjectsInScene<RhythmTracker>();
            objectManager.FindManageableObjectsInScene<HitPool>();
            objectManager.FindManageableObjectsInScene<MissPool>();
            objectManager.FindManageableObjectsInScene<BeatNode>();
        }

        void Awake()
        {
            PopulateUpdateQueue();
            objectManager.OnAwake();
        }

        void Start()
        {
            objectManager.OnStart();
        }
        
        void Update()
        {
            objectManager.OnUpdate();
        }

        void LateUpdate()
        {
            objectManager.OnLateUpdate();
        }

        void FixedUpdate()
        {
            objectManager.OnFixedUpdate();
        }

        void Abort()
        {
            objectManager.OnAbort();
        }
    }
}
