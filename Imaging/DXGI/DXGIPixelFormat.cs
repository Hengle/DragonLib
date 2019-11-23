using JetBrains.Annotations;

namespace DragonLib.Imaging.DXGI
{
    [PublicAPI]
    public enum DXGIPixelFormat : uint
    {
        UNKNOWN = 0x00,
        R32G32B32A32_TYPELESS = 0x01,
        R32G32B32A32_FLOAT = 0x02,
        R32G32B32A32_UINT = 0x03,
        R32G32B32A32_SINT = 0x04,
        R32G32B32_TYPELESS = 0x05,
        R32G32B32_FLOAT = 0x06,
        R32G32B32_UINT = 0x07,
        R32G32B32_SINT = 0x08,
        R16G16B16A16_TYPELESS = 0x09,
        R16G16B16A16_FLOAT = 0x0A,
        R16G16B16A16_UNORM = 0x0B,
        R16G16B16A16_UINT = 0x0C,
        R16G16B16A16_SNORM = 0x0D,
        R16G16B16A16_SINT = 0x0E,
        R32G32_TYPELESS = 0x0F,
        R32G32_FLOAT = 0x10,
        R32G32_UINT = 0x11,
        R32G32_SINT = 0x12,
        R32G8X24_TYPELESS = 0x13,
        D32_FLOAT_S8X24_UINT = 0x14,
        R32_FLOAT_X8X24_TYPELESS = 0x15,
        X32_TYPELESS_G8X24_UINT = 0x16,
        R10G10B10A2_TYPELESS = 0x17,
        R10G10B10A2_UNORM = 0x18,
        R10G10B10A2_UINT = 0x19,
        R11G11B10_FLOAT = 0x1A,
        R8G8B8A8_TYPELESS = 0x1B,
        R8G8B8A8_UNORM = 0x1C,
        R8G8B8A8_UNORM_SRGB = 0x1D,
        R8G8B8A8_UINT = 0x1E,
        R8G8B8A8_SNORM = 0x1F,
        R8G8B8A8_SINT = 0x20,
        R16G16_TYPELESS = 0x21,
        R16G16_FLOAT = 0x22,
        R16G16_UNORM = 0x23,
        R16G16_UINT = 0x24,
        R16G16_SNORM = 0x25,
        R16G16_SINT = 0x26,
        R32_TYPELESS = 0x27,
        D32_FLOAT = 0x28,
        R32_FLOAT = 0x29,
        R32_UINT = 0x2A,
        R32_SINT = 0x2B,
        R24G8_TYPELESS = 0x2C,
        D24_UNORM_S8_UINT = 0x2D,
        R24_UNORM_X8_TYPELESS = 0x2E,
        X24_TYPELESS_G8_UINT = 0x2F,
        R8G8_TYPELESS = 0x30,
        R8G8_UNORM = 0x31,
        R8G8_UINT = 0x32,
        R8G8_SNORM = 0x33,
        R8G8_SINT = 0x34,
        R16_TYPELESS = 0x35,
        R16_FLOAT = 0x36,
        D16_UNORM = 0x37,
        R16_UNORM = 0x38,
        R16_UINT = 0x39,
        R16_SNORM = 0x3A,
        R16_SINT = 0x3B,
        R8_TYPELESS = 0x3C,
        R8_UNORM = 0x3D,
        R8_UINT = 0x3E,
        R8_SNORM = 0x3F,
        R8_SINT = 0x40,
        A8_UNORM = 0x41,
        R9G9B9E5_SHAREDEXP = 0x43,
        R8G8_B8G8_UNORM = 0x44,
        G8R8_G8B8_UNORM = 0x45,
        BC1_TYPELESS = 0x46,
        BC1_UNORM = 0x47,
        BC1_UNORM_SRGB = 0x48,
        BC2_TYPELESS = 0x49,
        BC2_UNORM = 0x4A,
        BC2_UNORM_SRGB = 0x4B,
        BC3_TYPELESS = 0x4C,
        BC3_UNORM = 0x4D,
        BC3_UNORM_SRGB = 0x4E,
        BC4_TYPELESS = 0x4F,
        BC4_UNORM = 0x50,
        BC4_SNORM = 0x51,
        BC5_TYPELESS = 0x52,
        BC5_UNORM = 0x53,
        BC5_SNORM = 0x54,
        B5G6R5_UNORM = 0x55,
        B5G5R5A1_UNORM = 0x56,
        B8G8R8A8_UNORM = 0x57,
        B8G8R8X8_UNORM = 0x58,
        R10G10B10_XR_BIAS_A2_UNORM = 0x59,
        B8G8R8A8_TYPELESS = 0x5A,
        B8G8R8A8_UNORM_SRGB = 0x5B,
        B8G8R8X8_TYPELESS = 0x5C,
        B8G8R8X8_UNORM_SRGB = 0x5D,
        BC6H_TYPELESS = 0x5E,
        BC6H_UF16 = 0x5F,
        BC6H_SF16 = 0x60,
        BC7_TYPELESS = 0x61,
        BC7_UNORM = 0x62,
        BC7_UNORM_SRGB = 0x63,
        B4G4R4A4_UNORM = 0x73,
        P208 = 0x82,
        V208 = 0x83,
        V408 = 0x84,
        DXGI_END,
        FORCE_UINT = 0xFFFF_FFFF
    }
}
