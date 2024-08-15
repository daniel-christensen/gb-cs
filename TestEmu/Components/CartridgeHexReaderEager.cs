using System.Text;

namespace TestEmu.Components
{
    internal abstract class CartridgeHexReaderEager
    {
        public string FilePath { get; }
        protected byte[] RawFile { get; private set; } = Array.Empty<byte>();

        protected CartridgeHexReaderEager(string filePath)
        {
            FilePath = filePath;
        }

        protected async Task ReadAllBytesIntoMemoryAsync()
        {
            RawFile = await File.ReadAllBytesAsync(FilePath);
        }

        public byte[] GetBytesBetweenHexadecimal(int start, int end)
        {
            int length = end - start + 1;

            Span<byte> spannedData = new Span<byte>(RawFile, start, length);
            byte[] data = new byte[length];
            spannedData.CopyTo(data);

            return data;
        }

        public byte GetByteAtHexadecimal(int hex)
        {
            return GetBytesBetweenHexadecimal(hex, hex).FirstOrDefault();
        }

        public string GetASCIIBetweenHexadecimal(int start, int end)
        {
            return Encoding.ASCII.GetString(GetBytesBetweenHexadecimal(start, end));
        }

        public string GetASCIIAtHexadecimal(int hex)
        {
            return Encoding.ASCII.GetString(GetBytesBetweenHexadecimal(hex, hex));
        }
    }
}
