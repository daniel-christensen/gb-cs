﻿using System.Security;

namespace TestEmu.Components.Cartridge
{
    /// <summary>
    /// Implementation of mainly what's documented here: https://gbdev.io/pandocs/The_Cartridge_Header.html
    /// </summary>
    internal static class GameBoyCartridgeHeader
    {
        // Fallback to at least print something if no codes are matched
        internal static readonly string UnknownString = "UNKNOWN";

        // Title is a serious of ASCII characters
        internal static readonly int TitleStartHexLocation = 0x0134;
        internal static readonly int TitleEndHexLocation = 0x143;

        // Manufacturer Code is a series of ASCII characters
        internal static readonly int ManufacturerCodeStartHexLocation = 0x13f;
        internal static readonly int ManufacturerCodeEndHexLocation = 0x142;

        // CGB Flag is a single byte hex code
        internal static readonly int CGBFlagHexLocation = 0x143;
        internal static readonly Dictionary<int, string> CGBFlag = new Dictionary<int, string>()
        {
            { 0x80, "Non-CGB Mode" },
            { 0xC0, "CGB-Mode" }
        };

        // Destination Code is a single byte hex code
        internal static readonly int DestinationCodeHexLocation = 0x14A;
        internal static readonly Dictionary<int, string> DestinationCode = new Dictionary<int, string>()
        {
            { 0x00, "Japan (and possibly overseas)" },
            { 0x01, "Overseas only" }
        };

        // New Licensee Code is a 2 byte ASCII string
        internal static readonly int NewLicenseeCodeStartHexLocation = 0x144;
        internal static readonly int NewLicenseeCodeEndHexLocation = 0x145;
        internal static readonly Dictionary<string, string> NewLicenseeCode = new Dictionary<string, string>()
        {
            { "00", "None" },
            { "01", "Nintendo Research & Development 1"},
            { "08", "Capcom" },
            { "13", "EA (Electronic Arts" },
            { "18", "Hudson Soft" },
            { "19", "B-AI" },
            { "20", "KSS" },
            { "22", "Planning Office WADA" },
            { "24", "PCM Complete" },
            { "25", "San-X" },
            { "28", "Kemco" },
            { "29", "SETA Corporation" },
            { "30", "Viacom" },
            { "31", "Nintendo" },
            { "32", "Bandai" },
            { "33", "Ocean Software/Acclaim Entertainment" },
            { "34", "Konami" },
            { "35", "HectorSoft" },
            { "37", "Taito" },
            { "38", "Hudson Soft" },
            { "39", "Banpresto" },
            { "41", "Ubi Soft" },
            { "42", "Atlus" },
            { "44", "Malibu Interative" },
            { "46", "Angel" },
            { "47", "Bullet-Proof Software" },
            { "49", "Irem" },
            { "50", "Absolute" },
            { "51", "Acclaim Entertainment" },
            { "52", "Activision" },
            { "53", "Sammy USA Corporation" },
            { "54", "Konami" },
            { "55", "Hi Tech Expressions" },
            { "56", "LJN" },
            { "57", "Matchbox" },
            { "58", "Mattel" },
            { "59", "Milton Bradley Company" },
            { "60", "Titus Interactive" },
            { "61", "Virgin Games Ltd." },
            { "64", "Lucasfilm Games" },
            { "67", "Ocean Software" },
            { "69", "EA (Electronic Arts)" },
            { "70", "Infogrames" },
            { "71", "Interplay Entertainment" },
            { "72", "Broderbund" },
            { "73", "Sculptured Software" },
            { "75", "The Sales Curve Limited" },
            { "78", "THQ" },
            { "79", "Accolade" },
            { "80", "Misawa Entertainment" },
            { "83", "locz" },
            { "86", "Tokuma Shoten" },
            { "87", "Tsukuda Original" },
            { "91", "Chunsoft Co." },
            { "92", "Video System" },
            { "93", "Ocean Software/Acclaim Entertainment" },
            { "95", "Varie" },
            { "96", "Yonezawa/s'pal"},
            { "97", "Kaneko" },
            { "99", "Pack-In-Video" },
            { "9C", "Imagineer" },
            { "9H", "Bottom Up" },
            { "A4", "Konami (Yu-Gi-Oh!)" },
            { "BL", "MTO" },
            { "DK", "Kodansha" }
        };

        // Old Licensee Code is a single byte Hex code
        internal static readonly int OldLicenseeCodeHexLocation = 0x14B;
        internal static readonly int NewLicenseeCodeIndicationValue = 0x33;
        internal static readonly Dictionary<int, string> OldLicenseeCode = new Dictionary<int, string>()
        {
            { 0x00, "None" },
            { 0x01, "Nintendo" },
            { 0x08, "Capcom" },
            { 0x09, "HOT-B" },
            { 0x0A, "Jaleco" },
            { 0x0B, "Coconuts Japan" },
            { 0x0C, "Elite Systems" },
            { 0x13, "EA (Electronic Arts)" },
            { 0x18, "Hudson Soft" },
            { 0x19, "ITC Entertainment" },
            { 0x1A, "Yanoman" },
            { 0x1D, "Japan Clary" },
            { 0x1F, "Virgin Games Ltd." },
            { 0x24, "PCM Complete" },
            { 0x25, "San-X" },
            { 0x28, "Kemco" },
            { 0x29, "SETA Corporation" },
            { 0x30, "Intogrames" },
            { 0x31, "Nintendo" },
            { 0x32, "Bandai" },
            { 0x33, "NEW LICENSEE CODE" },
            { 0x34, "Konami" },
            { 0x35, "HectorSoft" },
            { 0x38, "Capcom" },
            { 0x39, "Banpresto" },
            { 0x3C, ".Entertainment i" },
            { 0x3E, "Gremlin" },
            { 0x41, "Ubi Soft" },
            { 0x42, "Atlus" },
            { 0x44, "Malibu Interactive" },
            { 0x46, "Angel" },
            { 0x47, "Spectrum Holoby" },
            { 0x49, "Irem" },
            { 0x4A, "Virgin Games Ltd." },
            { 0x4D, "Malibu Interactive" },
            { 0x4F, "U.S. Gold" },
            { 0x50, "Absolute" },
            { 0x51, "Acclaim Entertainment" },
            { 0x52, "Activision" },
            { 0x53, "Sammy USA Corporation" },
            { 0x54, "GameTek" },
            { 0x55, "Park Place" },
            { 0x56, "LJN" },
            { 0x57, "Matchbox" },
            { 0x59, "Milton Bradley Company" },
            { 0x5A, "Mindscape" },
            { 0x5B, "Romstar" },
            { 0x5C, "Naxat Soft" },
            { 0x5D, "Tradewest" },
            { 0x60, "Titus Interactive" },
            { 0x61, "Virgin Games Ltd." },
            { 0x67, "Ocean Software" },
            { 0x69, "EA (Electronic Arts)" },
            { 0x6E, "Elite Systems" },
            { 0x6F, "Electro Brain" },
            { 0x70, "InfoGrames" },
            { 0x71, "Interplay Entertainment" },
            { 0x72, "Broderbund" },
            { 0x73, "Sculptured Software" },
            { 0x75, "The Sales Curve Limited" },
            { 0x78, "THQ" },
            { 0x79, "Accolade" },
            { 0x7A, "Triffix Entertainment" },
            { 0x7C, "Microprose" },
            { 0x7F, "Kemco" },
            { 0x80, "Kisawa Entertainment" },
            { 0x83, "Lozc" },
            { 0x86, "Tokuma Shoten" },
            { 0x8B, "Bullet-Proof Software" },
            { 0x8C, "Vic Tokai" },
            { 0x8E, "Ape" },
            { 0x8F, "I'Max" },
            { 0x91, "Chunsoft Co." },
            { 0x92, "Video System" },
            { 0x93, "Tsubaraya Productions" },
            { 0x95, "Varie" },
            { 0x96, "Yonezawa/S'Pal" },
            { 0x97, "Kemco" },
            { 0x99, "Arc" },
            { 0x9A, "Nihon Bussan" },
            { 0x9B, "Tecmo" },
            { 0x9C, "Imagineer" },
            { 0x9D, "Banpresto" },
            { 0x9F, "Nova" },
            { 0xA1, "Hori Electric" },
            { 0xA2, "Bandai" },
            { 0xA4, "Konami" },
            { 0xA6, "Kawada" },
            { 0xA7, "Takara" },
            { 0xA9, "Technos Japan" },
            { 0xAA, "Broderbund" },
            { 0xAC, "Toei Animation" },
            { 0xAD, "Toho" },
            { 0xAF, "Namco" },
            { 0xB0, "Acclaim Entertainment" },
            { 0xB1, "ASCII Corporation or Nexsoft" },
            { 0xB2, "Bandai" },
            { 0xB4, "Square Enix" },
            { 0xB6, "HAL Laboratory" },
            { 0xB7, "SNK" },
            { 0xB9, "Pony Canyon" },
            { 0xBA, "Culture Brain" },
            { 0xBB, "Sunsoft" },
            { 0xBD, "Sony Imagesoft" },
            { 0xBF, "Sammy Corporation" },
            { 0xC0, "Taito" },
            { 0xC2, "Kemco" },
            { 0xC3, "Square" },
            { 0xC4, "Tokuma Shoten" },
            { 0xC5, "Data East" },
            { 0xC6, "Tonkinhouse" },
            { 0xC8, "Koei" },
            { 0xC9, "UFL" },
            { 0xCA, "Ultra" },
            { 0xCB, "Yap" },
            { 0xCC, "Use Corporation" },
            { 0xCD, "Meldac" },
            { 0xCE, "Pony Canyon" },
            { 0xCF, "Angel" },
            { 0xD0, "Taito" },
            { 0xD1, "Sofel" },
            { 0xD2, "Quest" },
            { 0xD3, "Sigma Enterprises" },
            { 0xD4, "ASK Kodansha Co." },
            { 0xD6, "Naxat Soft" },
            { 0xD7, "Copya System" },
            { 0xD9, "Banpresto" },
            { 0xDA, "Tomy" },
            { 0xDB, "LJN" },
            { 0xDD, "NCS" },
            { 0xDE, "Human" },
            { 0xDF, "Altron" },
            { 0xE0, "Jaleco" },
            { 0xE1, "Towa Chiki" },
            { 0xE2, "Yutaka" },
            { 0xE3, "Varie" },
            { 0xE5, "Epcoh" },
            { 0xE7, "Athena" },
            { 0xE8, "Asmik Ace Entertainment" },
            { 0xE9, "Natsume" },
            { 0xEA, "King Records" },
            { 0xEB, "Atlus" },
            { 0xEC, "Epic/Sony Records" },
            { 0xEE, "IGS" },
            { 0xF0, "A Wave" },
            { 0xF3, "Extreme Entertainment" },
            { 0xFF, "LJN" }
        };

        // Cartirdge Type is a singular hex value
        internal static readonly int CartridgeTypeHexLocation = 0x147;
        internal static readonly Dictionary<int, string> CartridgeType = new Dictionary<int, string>()
        {
            { 0x00, "ROM ONLY" },
            { 0x01, "MBC1" },
            { 0x02, "MBC1+RAM" },
            { 0x03, "MBC1+RAM+BATTERY" },
            { 0x05, "MBC2" },
            { 0x06, "MBC2+BATTERY" },
            { 0x08, "ROM+RAM" },
            { 0x09, "ROM+RAM+BATTERY" },
            { 0x0B, "MMM01" },
            { 0x0C, "MMM01+RAM" },
            { 0x0D, "MMM01+RAM+BATTERY" },
            { 0x0F, "MBC3+TIMER+BATTERY" },
            { 0x10, "MBC3+TIMER+RAM+BATTERY" },
            { 0x11, "MBC3" },
            { 0x12, "MBC3+RAM" },
            { 0x13, "MBC3+RAM+BATTERY" },
            { 0x19, "MBC5" },
            { 0x1A, "MBC5+RAM" },
            { 0x1B, "MBC5+RAM+BATTERY" },
            { 0x1C, "MBC5+RUMBLE" },
            { 0x1D, "MBC5+RUMBLE+RAM" },
            { 0x1E, "MBC5+RUMBLE+RAM+BATTERY" },
            { 0x20, "MBC6" },
            { 0x22, "MBC7+SENSOR+RUMBLE+RAM+BATTERY" },
            { 0xFC, "POCKET CAMERA" },
            { 0xFD, "BANDAI TAMA5" },
            { 0xFE, "HuC3" },
            { 0xFF, "HuC1+RAM+BATTERY" }
        };

        // Rom size is a singular hex value
        internal static readonly int RomSizeHexLocation = 0x148;
        internal static readonly Dictionary<int, string> RomSize = new Dictionary<int, string>()
        {
            { 0x00, "32 KiB - 2 Rom Banks (no banking)" },
            { 0x01, "64 KiB - 4 Rom Banks" },
            { 0x02, "128 KiB - 8 Rom Banks" },
            { 0x03, "256 KiB - 16 Rom Banks" },
            { 0x04, "512 KiB - 32 Rom Banks" },
            { 0x05, "1 MiB - 64 Rom Banks" },
            { 0x06, "2 MiB - 128 Rom Banks" },
            { 0x07, "4 MiB - 256 Rom Banks" },
            { 0x08, "8 MiB - 512 Rom Banks" },
            { 0x52, "1.1 MiB - 72 Rom Banks" },
            { 0x53, "1.2 MiB - 80 Rom Banks" },
            { 0x54, "1.5 MiB - 96 Rom Banks" }
        };

        // Ram Size is a singular hex value
        internal static readonly int RamSizeHexLocation = 0x149;
        internal static readonly Dictionary<int, string> RamSize = new Dictionary<int, string>()
        {
            { 0x00, "0 - No RAM" },
            { 0x01, "-" },
            { 0x02, "8 KiB - 1 bank" },
            { 0x03, "32 KiB - 4 banks of 8 KiB each" },
            { 0x04, "128 KiB - 16 banks of 8 KiB each" },
            { 0x05, "64 KiB - 8 banks of 8 KiB each" }
        };

        // Version number
        internal static readonly int MaskRomVersionNumberHexLocation = 0x14C;

        // Header Checksum verification byte
        internal static readonly int HeaderChecksumHexLocation = 0x14D;
    }
}