namespace DragonLib.IO;

public sealed class NullBuffer : IMemoryBuffer {
	public int Length => 0;
	public ReadOnlySpan<byte> Span => ReadOnlySpan<byte>.Empty;
	public byte this[int offset] => 0;

	public void Dispose() { }
}
