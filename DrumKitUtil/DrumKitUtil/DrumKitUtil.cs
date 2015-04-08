using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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

        private async Task SendNote(Note note)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    {"midi_value",  note.MidiValue.ToString()},
                    {"velocity",    note.Velocity.ToString()},
                    {"duration",    note.Duration.ToString()}
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(_baseUrl + "/max/midi", content);

                var responseString = await response.Content.ReadAsStringAsync();
            }
        }

        private async Task ChangeChannel(int newChannel)
        {
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    {"channel",  newChannel.ToString()}
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync(_baseUrl + "/max/channel", content);

                var responseString = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task PlayBassDrum(int velocity, int duration)
        {
            await SendNote(new Note(_soundMap["bass_drum"], velocity, duration));
        }

        public async Task PlaySnareDrum(int velocity, int duration)
        {
            await SendNote(new Note(_soundMap["snare_drum"], velocity, duration));
        }

        public async Task PlayTom(int velocity, int duration)
        {
            await SendNote(new Note(_soundMap["tom_drum"], velocity, duration));
        }

        public async Task PlayCowbell(int velocity, int duration)
        {
            await SendNote(new Note(_soundMap["cowbell"], velocity, duration));
        }

        public async Task PlayCrashCymbol(int velocity, int duration)
        {
            await SendNote(new Note(_soundMap["crash_cymbal"], velocity, duration));
        }

        public async Task PlayHiHat(int velocity, int duration)
        {
            await SendNote(new Note(_soundMap["hihat_cymbal"], velocity, duration));
        }

        public async Task ChangeDrumPack(int newChannel)
        {
            await ChangeChannel(newChannel);
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
