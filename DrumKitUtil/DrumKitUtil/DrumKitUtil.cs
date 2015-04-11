using System.Collections.Generic;
using System.Text;

namespace DrumKitUtil
{
    public class DrumKit
    {
        private string _baseUrl;
        private int _drumPack;
        private Dictionary<string, int> _soundMap;

        public DrumKit(string url, int drumPack = 0)
        {
            this._baseUrl = url;
            this._drumPack = drumPack;
            this._soundMap = new Dictionary<string, int>
            {
                {"bass_drum",       35},
                {"snare_drum",      40},
                {"tom_drum",        48},
                {"crash_cymbal",    49},
                {"hihat_cymbal",    46},
                {"cowbell",         56}
            };
        }

        private void SendNote(Note note)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();

            webClient.Headers.Add("content-type", "application/json");//set your header here, you can add multiple headers
            webClient.UploadData(_baseUrl + "/max/midi", "POST", Encoding.Default.GetBytes("{\"midi_value\": " + note.MidiValue + ", \"velocity\": " + note.Velocity + ", \"duration\": " + note.Duration + "}"));
        }

        private void ChangeChannel(int newChannel)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();

            webClient.Headers.Add("content-type", "application/json");//set your header here, you can add multiple headers
            webClient.UploadData(_baseUrl + "/max/midi", "POST", Encoding.Default.GetBytes("{\"channel\": " + newChannel + "}"));
        }

        public void PlayBassDrum(int velocity, int duration)
        {
            SendNote(new Note(_soundMap["bass_drum"], velocity, duration));
        }

        public void PlaySnareDrum(int velocity, int duration)
        {
            SendNote(new Note(_soundMap["snare_drum"], velocity, duration));
        }

        public void PlayTom(int velocity, int duration)
        {
            SendNote(new Note(_soundMap["tom_drum"], velocity, duration));
        }

        public void PlayCowbell(int velocity, int duration)
        {
            SendNote(new Note(_soundMap["cowbell"], velocity, duration));
        }

        public void PlayCrashCymbol(int velocity, int duration)
        {
            SendNote(new Note(_soundMap["crash_cymbal"], velocity, duration));
        }

        public void PlayHiHat(int velocity, int duration)
        {
            SendNote(new Note(_soundMap["hihat_cymbal"], velocity, duration));
        }

        public void ChangeDrumPack(int newChannel)
        {
            ChangeChannel(newChannel);
        }

        private class Note
        {
            public Note(int midiValue, int velocity, int duration)
            {
                this.MidiValue = midiValue;
                this.Velocity = velocity;
                this.Duration = duration;
            }

            public int MidiValue { get; set; }

            public int Velocity { get; set; }

            public int Duration { get; set; }
        }
    }
}
