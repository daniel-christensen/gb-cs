using TestEmu.Components;

namespace TestEmu
{
    internal class GameBoyEmulator
    {
        public bool IsRunning { get; private set; }

        public GameBoyCartridgeHexReaderEager CartridgeReader { get; }

        public GameBoyCPU CPU { get; }

        public GameBoyEmulator(string filePath)
        {
            CartridgeReader = new GameBoyCartridgeHexReaderEager(filePath);
            CPU = new GameBoyCPU();
        }
    }
}
