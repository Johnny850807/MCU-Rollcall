using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCR.adapters
{
    /// <summary>
    /// TTS interface which we expect to speak.
    /// </summary>
    public interface TTS 
    {
        bool isSpeaking();
        void stopSpeaking();
        void speak(List<string> words, int rate = 0);
        void speak(String word, int rate = 0);
    }
}
