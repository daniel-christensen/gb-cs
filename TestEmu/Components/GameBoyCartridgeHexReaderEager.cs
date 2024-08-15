using System.Text;
using TestEmu.Components.Cartridge;

namespace TestEmu.Components
{
    internal class GameBoyCartridgeHexReaderEager : CartridgeHexReaderEager
    {
        private GameBoyCartridgeHexReaderEager(string filePath) : base(filePath) { }

        public static async Task<GameBoyCartridgeHexReaderEager> CreateAsync(string filePath)
        {
            var reader = new GameBoyCartridgeHexReaderEager(filePath);
            await reader.ReadAllBytesIntoMemoryAsync();
            return reader;
        }

        private bool IsOldLicensee => RawFile[GameBoyCartridgeHeader.OldLicenseeCodeHexLocation] 
            != GameBoyCartridgeHeader.NewLicenseeCodeIndicationValue;

        private string GetOldLicensee()
        {
            int key = GetByteAtHexadecimal(GameBoyCartridgeHeader.OldLicenseeCodeHexLocation);
            if (GameBoyCartridgeHeader.OldLicenseeCode.TryGetValue(key, out string? value))
                return value;
            return GameBoyCartridgeHeader.UnknownString;
        }

        private string GetNewLicensee()
        {
            byte[] entry = GetBytesBetweenHexadecimal(
                GameBoyCartridgeHeader.NewLicenseeCodeStartHexLocation,
                GameBoyCartridgeHeader.NewLicenseeCodeEndHexLocation
            );

            string key = Encoding.ASCII.GetString(entry);
            if (GameBoyCartridgeHeader.NewLicenseeCode.TryGetValue(key, out string? value))
                return value;
            return GameBoyCartridgeHeader.UnknownString;
        }
        
        private string GetDestination()
        {
            int key = GetByteAtHexadecimal(GameBoyCartridgeHeader.DestinationCodeHexLocation);
            if (GameBoyCartridgeHeader.DestinationCode.TryGetValue(key, out string? value))
                return value;
            return GameBoyCartridgeHeader.UnknownString;
        }
        
        private string GetTitle()
        {
            byte[] data = GetBytesBetweenHexadecimal(GameBoyCartridgeHeader.TitleStartHexLocation, GameBoyCartridgeHeader.TitleEndHexLocation);
            int zeroIndex = Array.IndexOf(data, (byte)0);
            string title = Encoding.ASCII.GetString(data, 0, zeroIndex == -1 ? data.Length : zeroIndex);
            return title;
        }

        private string GetManufacturerCode()
        {
            return GetASCIIBetweenHexadecimal(
                GameBoyCartridgeHeader.ManufacturerCodeStartHexLocation, 
                GameBoyCartridgeHeader.ManufacturerCodeEndHexLocation
            );
        }

        private string GetCGBFlag()
        {
            int key = GetByteAtHexadecimal(GameBoyCartridgeHeader.CGBFlagHexLocation);
            if (GameBoyCartridgeHeader.CGBFlag.TryGetValue(key, out string? value))
                return value;
            return GameBoyCartridgeHeader.UnknownString;
        }

        private string GetCartridgeType()
        {
            int key = GetByteAtHexadecimal(GameBoyCartridgeHeader.CartridgeTypeHexLocation);
            if (GameBoyCartridgeHeader.CartridgeType.TryGetValue(key, out string? value))
                return value;
            return GameBoyCartridgeHeader.UnknownString;
        }

        private string GetRomSize()
        {
            int key = GetByteAtHexadecimal(GameBoyCartridgeHeader.RomSizeHexLocation);
            if (GameBoyCartridgeHeader.RomSize.TryGetValue(key, out string? value))
                return value;
            return GameBoyCartridgeHeader.UnknownString;
        }

        private string GetRamSize()
        {
            int key = GetByteAtHexadecimal(GameBoyCartridgeHeader.RamSizeHexLocation);
            if (GameBoyCartridgeHeader.RamSize.TryGetValue(key, out string? value))
                return value;
            return GameBoyCartridgeHeader.UnknownString;
        }

        private string GetMaskRomVersionNumber()
        {
            return GetByteAtHexadecimal(GameBoyCartridgeHeader.MaskRomVersionNumberHexLocation).ToString();
        }

        private bool IsHeaderChecksumValid()
        {
            byte checksum = 0;
            for (ushort address = 0x0134; address <= 0x014C; address++)
                checksum = (byte)(checksum - RawFile[address] - 1);
            return GetByteAtHexadecimal(GameBoyCartridgeHeader.HeaderChecksumHexLocation) == checksum;
        }

        public string Destination => GetDestination();

        public string Licensee => IsOldLicensee ? GetOldLicensee() : GetNewLicensee();

        public string Title => GetTitle();

        public string ManufacturerCode => GetManufacturerCode();

        public string CGBFlag => GetCGBFlag();

        public string CartridgeType => GetCartridgeType();

        public string RomSize => GetRomSize();

        public string RamSize => GetRamSize();

        public string MaskRomVersionNumber => GetMaskRomVersionNumber();

        public string HeaderChecksumResult => IsHeaderChecksumValid() ? "Passed" : "Failed";

        public void PrintHeaderInformation()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Game Name: {Title}");
            Console.WriteLine($"Manufacturer Code: {ManufacturerCode}");
            Console.WriteLine($"CGB Flag: {CGBFlag}");
            Console.WriteLine($"Licensee: {Licensee}");
            Console.WriteLine($"Cartridge Type: {CartridgeType}");
            Console.WriteLine($"ROM Size: {RomSize}");
            Console.WriteLine($"RAM Size: {RamSize}");
            Console.WriteLine($"Destination: {Destination}");
            Console.WriteLine($"Mask ROM Version Number: {MaskRomVersionNumber}");
            Console.WriteLine($"Header Checksum: {HeaderChecksumResult}");
            Console.WriteLine("==========================");
        }
    }
}
