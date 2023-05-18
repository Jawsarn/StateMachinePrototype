using UnityEngine.Events;

namespace Game.Events
{
    public class GameEvents
    {
        public static UnityEvent BootingFinished = new UnityEvent();
        public static UnityEvent PlayGame = new UnityEvent();
        public static UnityEvent GoToMenu = new UnityEvent();
    }
}
