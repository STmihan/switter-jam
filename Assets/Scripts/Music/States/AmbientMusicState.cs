using StateManagement;

namespace Music.States
{
    public class AmbientMusicState : StateBase<MusicData>
    {
        public override void Enter(StateMachine<MusicData> sm)
        {
            if (sm.Data.MusicSource.clip == sm.Data.AmbientClip) return;
            sm.Data.MusicSource.clip = sm.Data.AmbientClip;
            sm.Data.MusicSource.Play();
        }
    }
}