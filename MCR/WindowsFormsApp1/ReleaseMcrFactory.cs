using MCR.adapters;
using MCR.models.repositories;
using MCR.fileProcessors;
using System.Windows.Forms;
using MCR.models.tools;

namespace MCR
{
    /// <summary>
    /// The release version of factory.
    /// </summary>
    public class ReleaseMcrFactory : McrFactory
    {
        private CacheFileMcrRepositoryProxy cacheFileMcrRepositoryInstance;
        
        /// <returns>a singleton instance of repository</returns>
        public McrRepository createMcrRepository()
        {
            // We should maintain the singleton instance of cache repository
            // because its implementation needs the state of data synchronizing.
            if (cacheFileMcrRepositoryInstance == null)
            {
                FileProcessor baseFileProcessor = new TxtFileProcessor();
                FileProcessor rsaProcessor = new TextParsingDecorator(
                    baseFileProcessor, new RijndaelEncryptor());
                FileProcessor compressionProcessor = new TextParsingDecorator(
                    rsaProcessor, new CompressorImp());
                cacheFileMcrRepositoryInstance = new CacheFileMcrRepositoryProxy(
                                new ApringFileMcrRepository(
                                compressionProcessor));
            }
            return cacheFileMcrRepositoryInstance;
        }

        public TTS createTTS()
        {
            return new SpeechSynthesizerAdapter();
        }

        private NetStatesManager netStatesManager;
        public NetStatesManager getNetStatesManager()
        {
            return netStatesManager == null ? netStatesManager = new NetStatesManagerImp() : netStatesManager;
        }
    }
}
