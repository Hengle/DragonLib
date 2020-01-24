namespace DragonLib.Audio.WAV
{
    public struct WAVEFormat
    {
        public int Magic { get; set; }
        public int Size { get; set; }
        public short Format { get; set; }
        public short Channels { get; set; }
        public int SampleRate { get; set; }
        public int ByteRate { get; set; }
        public short BlockAlign { get; set; }
        public short BitsPerSample { get; set; }
    }
}
