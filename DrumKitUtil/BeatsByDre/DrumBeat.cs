using System;
using DrumKitUtil;

namespace BeatsByDre
{
    public class DrumBeat
    {
        public int Velocity { get; set; }
        public int DurationMs { get; set; }
        // TODO: I'm not sure how we're representing the Mya models yet
        // public Model Image { get; set; }
        public InstrumentType Instrument { get; set; }

        public DrumBeat(InstrumentType beatType, int durationMs, int velocity = 127)
        {
            Instrument = beatType;
            DurationMs = durationMs;
            Velocity = velocity;
        }

        public void Play()
        {
            if (HasInstrument())
            {
                DrumMachine.GetInstance().Play(Instrument, DurationMs, Velocity);
            }
        }

        public bool HasInstrument()
        {
            return !Instrument.Equals(InstrumentType.None);
        }

        public void Clear()
        {
            Instrument = InstrumentType.None;
        }

        public enum InstrumentType
        {
            None, BassDrum, SnareDrum, TomDrum, CrashCymbal, HiHatCymbal, Cowbell
        }
    }
}