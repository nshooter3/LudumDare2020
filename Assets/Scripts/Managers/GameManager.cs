namespace GameManager
{
    using HarmonyQuest.Audio;
    using Manager;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        //References to the prefabs we're gonna load into these objects later.
        public GameObject FmodHandler;

        //The master list of all the objects that need to be updated, in order.
        private ObjectManager objectManager = new ObjectManager();

        private void PopulateUpdateQueue()
        {
            //Initialize all our one-of manageable objects that need to be in every scene.
            FmodHandler = Instantiate(FmodHandler);

            objectManager.AddManageableObject(FmodHandler.GetComponent<FmodFacade>());
            objectManager.AddManageableObject(FmodHandler.GetComponent<FmodMusicHandler>());
            objectManager.AddManageableObject(FmodHandler.GetComponent<FmodOnBeatAccuracyChecker>());
            objectManager.AddManageableObject(FmodHandler.GetComponent<FmodChordInterpreter>());
            objectManager.FindManageableObjectsInScene<FmodEventHandler>();

            objectManager.FindManageableObjectsInScene<BeatCommand>();
            objectManager.FindManageableObjectsInScene<BeatCommandPool>();

            objectManager.FindManageableObjectsInScene<RhythmTracker>();
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
