using MCR.adapters;
using MCR.models.repositories;
using MCR.models.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCR
{
    /// <summary>
    /// An implementation of abstract factory pattern, 
    /// for dependency injecting to all MCR modules. 
    /// </summary>
    public interface McrFactory
    {
        McrRepository createMcrRepository();
        TTS createTTS();
        NetStatesManager getNetStatesManager();
    }
}
