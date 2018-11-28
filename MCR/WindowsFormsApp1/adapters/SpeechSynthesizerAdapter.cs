using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace MCR.adapters
{
    /// <summary>
    /// The adapter to the c# built-in TTS,
    /// but it's not holding an instance, it creates and disposes an instance in every speech.
    /// </summary>
    public class SpeechSynthesizerAdapter : TTS
    {
        public InstalledVoice voice { get; set; }
        private SpeechSynthesizer nowUsingSynthesizer;
        public bool speaking { get; set; } = false;

        public SpeechSynthesizerAdapter()
        {
            initVoice();
        }

        private void initVoice()
        {
            using (var temp = new SpeechSynthesizer())
            {
                var voiceInfos = temp.GetInstalledVoices();
                int i = 0;
                int randNum = new Random().Next(0, voiceInfos.Count - 1);
                foreach (var voiceInfo in voiceInfos)
                    if (i++ == randNum)
                        this.voice = voiceInfo;
            }
        }

        public void speak(List<string> words, int rate = 0)
        {
            speaking = true;
            using (nowUsingSynthesizer = new SpeechSynthesizer())
            {
                nowUsingSynthesizer.Rate = rate;
                var promptBuilder = new PromptBuilder();
                foreach (var w in words)
                {
                    promptBuilder.AppendText(w);
                    promptBuilder.AppendBreak();
                }
                nowUsingSynthesizer.Speak(promptBuilder);
            }
            speaking = false;
        }

        public void speak(string word, int rate=0)
        {
            speaking = true;
            using (nowUsingSynthesizer = new SpeechSynthesizer())
            {
                nowUsingSynthesizer.Rate = 1;
                nowUsingSynthesizer.Speak(word);
            }
            speaking = false;
        }

        public bool isSpeaking()
        {
            return speaking;
        }

        public void stopSpeaking()
        {
            if (nowUsingSynthesizer != null && speaking)
                nowUsingSynthesizer.Pause();
            speaking = false;
        }
    }
}
