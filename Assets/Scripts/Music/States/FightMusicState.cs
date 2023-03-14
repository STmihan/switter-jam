using StateManagement;

namespace Music.States
{
    public class FightMusicState : StateBase<MusicData>
    {
        public override void Enter(StateMachine<MusicData> sm)
        {
            sm.Data.MusicSource.clip = sm.Data.MusicClip;
            sm.Data.MusicSource.Play();
        }
    }
}