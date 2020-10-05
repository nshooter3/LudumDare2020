namespace HarmonyQuest.Audio
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that allows us to access fmod event and param names by our own defined keys. This way if fmod event names or paths change, we need only update the FmodNameDictionary script.
    /// </summary>
    public class FmodDictionary
    {
        //Event name-to-fmod-path dictionary for Music.
        public Dictionary<string, string> fmodMusicEventDictionary = new Dictionary<string, string>()
        {
            //{ "", "" },
            { "BattleTheme", "event:/BattleTheme" },
        };

        //Event name-to-fmod-path dictionary for SFX. Used to generate our fmod event pools.
        public Dictionary<string, string> fmodSFXEventDictionary = new Dictionary<string, string>()
        {
            //{ "", "" },
            { "BossDeath", "event:/BossDeath" },
            { "Caution", "event:/Caution" },
            { "Fist", "event:/Fist" },
            { "Guard", "event:/Guard" },
            { "HitA", "event:/HitA" },
            { "HitB", "event:/HitB" },
            { "Miss", "event:/Miss" },
            { "PlayerDeath", "event:/PlayeDeath" },
            { "PlayerHurt", "event:/PlayerHurt" },
        };

        //Param name-to-fmod-name dictionary
        public Dictionary<string, string> fmodParamDictionary = new Dictionary<string, string>()
        {
            //{ "", "" },
            
        };
    }
}
