using System;
using System.Runtime.InteropServices;

namespace QuartzTypeLib 
{
    class TimeFormat
    {
        public static Guid None = new Guid(0,0,0,0,0,0,0,0,0,0,0);
        public static Guid FormatFrame = new Guid(0x7b785570, 0x8c82, 0x11cf, 0xbc, 0x0c, 0x00, 0xaa, 0x00, 0xac, 0x74, 0xf6);
        public static Guid FormatByte = new Guid(0x7b785571, 0x8c82, 0x11cf, 0xbc, 0x0c, 0x00, 0xaa, 0x00, 0xac, 0x74, 0xf6);
        public static Guid FormatSample = new Guid(0x7b785572, 0x8c82, 0x11cf, 0xbc, 0x0c, 0x00, 0xaa, 0x00, 0xac, 0x74, 0xf6);
        public static Guid FormatField = new Guid(0x7b785573, 0x8c82, 0x11cf, 0xbc, 0x0c, 0x00, 0xaa, 0x00, 0xac, 0x74, 0xf6);
        public static Guid MediaTime = new Guid(0x7b785574, 0x8c82, 0x11cf, 0xbc, 0x0c, 0x00, 0xaa, 0x00, 0xac, 0x74, 0xf6);
    }

    // Declare IMediaControl as a COM interface which 
    // derives from IDispatch interface:
    [Guid("56A868B1-0AD4-11CE-B03A-0020AF0BA770"), 
    InterfaceType(ComInterfaceType.InterfaceIsDual)] 
    interface IMediaControl   // Cannot list any base interfaces here 
    { 
        // Note that IUnknown Interface members are NOT listed here:

        void Run();

        void Pause();

        void Stop();

        void GetState( [In] int msTimeout, [Out] out int pfs);

        void RenderFile(
            [In, MarshalAs(UnmanagedType.BStr)] string strFilename);

        void AddSourceFilter( 
            [In, MarshalAs(UnmanagedType.BStr)] string strFilename, 
            [Out, MarshalAs(UnmanagedType.Interface)]
            out object ppUnk);

        [return: MarshalAs(UnmanagedType.Interface)] 
        object FilterCollection();

        [return: MarshalAs(UnmanagedType.Interface)] 
        object RegFilterCollection();
            
        void StopWhenReady(); 
    }
    [Guid("36b73880-c2c8-11cf-8b46-00805f6cef60"),
    InterfaceType(ComInterfaceType.InterfaceIsDual)]
    interface IMediaSeeking
    {

        // Returns the capability flags
        void GetCapabilities( [Out] out int pCapabilities );

        // And's the capabilities flag with the capabilities requested.
        // Returns S_OK if all are present, S_FALSE if some are present, E_FAIL if none.
        // *pCababilities is always updated with the result of the 'and'ing and can be
        // checked in the case of an S_FALSE return code.
        void CheckCapabilities( [In,Out] ref int pCapabilities );

        // returns S_OK if mode is supported, S_FALSE otherwise
        void IsFormatSupported([In] Guid pFormat);
        void QueryPreferredFormat([Out] out Guid pFormat);

        void GetTimeFormat([Out] out Guid pFormat);
        // Returns S_OK if *pFormat is the current time format, otherwise S_FALSE
        // This may be used instead of the above and will save the copying of the GUID
        void IsUsingTimeFormat([In] Guid pFormat);

        // (may return VFE_E_WRONG_STATE if graph is stopped)
        void SetTimeFormat([In] Guid pFormat);

        // return current properties
        void GetDuration([Out] out long pDuration);
        void GetStopPosition([Out] out long pStop);
        void GetCurrentPosition([Out] out long pCurrent);

        // Convert time from one format to another.
        // We must be able to convert between all of the formats that we say we support.
        // (However, we can use intermediate formats (e.g. MEDIA_TIME).)
        // If a pointer to a format is null, it implies the currently selected format.
        void ConvertTimeFormat([Out] out long pTarget, [In] Guid pTargetFormat,
                               [In] long Source, [In] Guid pSourceFormat );


        // Set current and end positions in one operation
        // Either pointer may be null, implying no change
        void SetPositions( [In,Out] ref long pCurrent, [In] int dwCurrentFlags,
                           [In,Out] ref long pStop, [In] int dwStopFlags );

        // Get CurrentPosition & StopTime
        // Either pointer may be null, implying not interested
        void GetPositions( [Out] out long pCurrent,
                           [Out] out long pStop );

        // Get earliest / latest times to which we can currently seek "efficiently".
        // This method is intended to help with graphs where the source filter has
        // a very high latency.  Seeking within the returned limits should just
        // result in a re-pushing of already cached data.  Seeking beyond these
        // limits may result in extended delays while the data is fetched (e.g.
        // across a slow network).
        // (NULL pointer is OK, means caller isn't interested.)
        void GetAvailable( [Out] out long pEarliest, [Out] out long pLatest );

        // Rate stuff
        void SetRate([In] double dRate);
        void GetRate([Out] out double pdRate);

        // Preroll
        void GetPreroll([Out] out long pllPreroll);
    }

    // Declare FilgraphManager as a COM coclass:
    [ComImport, Guid("E436EBB3-524F-11CE-9F53-0020AF0BA770")] 
    class FilgraphManager   // Cannot have a base class or
        // interface list here.
    { 
        // Cannot have any members here 
        // NOTE that the C# compiler will add a default constructor
        // for you (no parameters).
    }

}
