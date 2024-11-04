using System.IO;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using SDL2;
using TestEmu.Components;
using static SDL2.SDL;

namespace TestEmu
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string filePath = "../../../Roms/Pokemon - Yellow Version (UE) [C][!].gbc";
            string filePath = "../../../Roms/Pokemon - Yellow Version - Special Pikachu Edition (USA, Europe) (GBC,SGB Enhanced).gb";
            //string filePath = "../../../Roms/Frogger (USA).gb";
            //string filePath = "../../../Roms/Yannick Noah Tennis (France).gb";
            //string filePath = "../../../Roms/Street Fighter II (USA) (SGB Enhanced).gb";
            //string filePath = "../../../Roms/Goukaku Boy GOLD - Shikakui Atama o Maruku Suru - Kanji no Tatsujin (Japan) (Special Edition).gb";

            //var reader = new GameBoyCartridgeHexReaderEager(filePath);
            //reader.PrintHeaderInformation();
            //reader.GetBytesBetweenHexadecimal("0x14B", "0x14B");

            Console.ReadKey();

            var emulator = new GameBoyEmulator(filePath);

            /*using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                string hexStart = "0x144";  // Hexadecimal starting position
                string hexEnd = "0x145";    // Hexadecimal ending position

                int start = Convert.ToInt32(hexStart, 16);  // Convert hex to decimal
                int end = Convert.ToInt32(hexEnd, 16);
                int length = end - start + 1;

                byte[] data;
                fileStream.Seek(start, SeekOrigin.Begin);
                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    data = reader.ReadBytes(length);

                }
                string asciiString = Encoding.ASCII.GetString(data);

                //foreach (var b in data)
                //{
                //    Console.WriteLine($"{b:X2} ");
                //}
                Console.WriteLine(asciiString);
                Console.ReadKey();
            }
            /*IntPtr window;
            IntPtr renderer;

            window = SDL.SDL_CreateWindow(
                "Display Bitmap",
                SDL.SDL_WINDOWPOS_UNDEFINED,
                SDL.SDL_WINDOWPOS_UNDEFINED,
                640,
                480,
                SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
            );

            if (window == IntPtr.Zero)
            {
                Console.WriteLine($"Failed to create window: {SDL.SDL_GetError()}");
                Console.ReadKey();
                return;
            }

            renderer = SDL.SDL_CreateRenderer(
                window, 
                -1, 
                SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED
            );

            if (renderer == IntPtr.Zero)
            {
                SDL.SDL_DestroyWindow(window);
                Console.WriteLine($"Failed to create renderer: {SDL.SDL_GetError()}");
                Console.ReadKey();
                return;
            }

            string hexData = "CEED6666CC0D000B03730083000C000D0018111F8889000EDCCC6EE6DDDDD999BBBB67636E0EECCCCDDDCC9999FBBB9333E";
            byte[] pixelData = new byte[hexData.Length / 2];

            int width = 8; // Example width, adjust as needed
            int height = pixelData.Length / width;
            int[] rgbaData = new int[width * height];

            for (int i = 0; i < pixelData.Length; i++)
            {
                pixelData[i] = Convert.ToByte(hexData.Substring(i * 2, 2), 16);
            }

            IntPtr unmanagedPointer = Marshal.AllocHGlobal(rgbaData.Length * sizeof(int));
            Marshal.Copy(rgbaData, 0, unmanagedPointer, rgbaData.Length);

            IntPtr surface = SDL.SDL_CreateRGBSurfaceFrom(
                unmanagedPointer,
                width,
                height,
                32, // bits per pixel
                width * 4, // pitch, 4 bytes per pixel
                0x00FF0000, // R mask
                0x0000FF00, // G mask
                0x000000FF, // B mask
                0xFF000000  // A mask
            );

            if (surface == IntPtr.Zero)
            {
                Console.WriteLine("Unable to create surface. Error: " + SDL.SDL_GetError());
                return;
            }

            IntPtr texture = SDL.SDL_CreateTextureFromSurface(renderer, surface);
            if (texture == IntPtr.Zero)
            {
                Console.WriteLine("Unable to create texture. Error: " + SDL.SDL_GetError());
                return; // Include proper error handling or cleanup
            }

            SDL.SDL_Rect dstRect = new SDL.SDL_Rect
            {
                x = 100, // Center the texture on the screen
                y = 100,
                w = width * 10,  // Scale up the texture for visibility
                h = height * 10
            };

            try
            {
                bool running = true;
                while (running)
                {
                    SDL.SDL_RenderClear(renderer);  // Clear the previous frame
                    //SDL.SDL_RenderCopy(renderer, texture, IntPtr.Zero, IntPtr.Zero);

                    SDL.SDL_RenderCopy(renderer, texture, IntPtr.Zero, ref dstRect);

                    SDL.SDL_RenderPresent(renderer);  // Update the screen

                    while (SDL.SDL_PollEvent(out var sdlEvent) != 0)
                    {
                        if (sdlEvent.type == SDL.SDL_EventType.SDL_QUIT)
                        {
                            running = false;
                        }
                    }
                }
            }
            finally
            {
                Marshal.FreeHGlobal(unmanagedPointer);
                SDL.SDL_DestroyTexture(texture);
                SDL.SDL_FreeSurface(surface);
                SDL.SDL_DestroyRenderer(renderer);
                SDL.SDL_DestroyWindow(window);
                SDL.SDL_Quit();
            }*/
        }
    }
}
