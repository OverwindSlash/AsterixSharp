using AsterixCore;
using Cat062PacketParser.DataItems.SubFields;
using Cat062PacketParser.DataItems.SubFields.I062290;
using Utils;

namespace Cat062PacketParser.DataItems;

public class I062290SystemTrackUpdateAges : ExtentableDataItem
{
    public const int MaxSystemTrackUpdateAgesLength = 2;

    #region PrimarySubfield
    public bool HasTrk { get; private set; }
    public bool HasPsr { get; private set; }
    public bool HasSsr { get; private set; }
    public bool HasMds { get; private set; }
    public bool HasAds { get; private set; }
    public bool HasEs { get; private set; }
    public bool HasVdl { get; private set; }
    public bool Fx1 { get; private set; }

    public bool HasUat { get; private set; }
    public bool HasLop { get; private set; }
    public bool HasMlt { get; private set; }
    public bool Fx2 { get; private set; }
    #endregion
    
    #region Subfields
    public I062290Sf1TrackAge TrackAge { get; private set; }
    public I062290Sf2PsrAge PsrAge { get; private set; }
    public I062290Sf3SsrAge SsrAge { get; private set; }
    public I062290Sf4ModeSAge ModeSAge { get; private set; }
    public I062290Sf5AdscAge AdscAge { get; private set; }
    public I062290Sf6EsAge EsAge { get; private set; }
    public I062290Sf7VdlAge VdlAge { get; private set; }
    public I062290Sf8UatAge UatAge { get; private set; }
    public I062290Sf9LoopAge LoopAge { get; private set; }
    public I062290Sf10MultilaterationAge MultilaterationAge { get; private set; }
    #endregion

    public I062290SystemTrackUpdateAges(byte[] buffer, int offset)
    {
        Name = "I062/290, System Track Update Ages";
        IsMandatory = false;
        
        ParseExtentableData(MaxSystemTrackUpdateAgesLength, buffer, offset);
        offset += Length;

        ExtractSubFieldFlag();

        if (HasTrk)
        {
            TrackAge = new I062290Sf1TrackAge(buffer, offset);
            offset += TrackAge.Length;
            Length += TrackAge.Length;
        }

        if (HasPsr)
        {
            PsrAge = new I062290Sf2PsrAge(buffer, offset);
            offset += PsrAge.Length;
            Length += PsrAge.Length;
        }

        if (HasSsr)
        {
            SsrAge = new I062290Sf3SsrAge(buffer, offset);
            offset += SsrAge.Length;
            Length += SsrAge.Length;
        }

        if (HasMds)
        {
            ModeSAge = new I062290Sf4ModeSAge(buffer, offset);
            offset += ModeSAge.Length;
            Length += ModeSAge.Length;
        }

        if (HasAds)
        {
            AdscAge = new I062290Sf5AdscAge(buffer, offset);
            offset += AdscAge.Length;
            Length += AdscAge.Length;
        }

        if (HasEs)
        {
            EsAge = new I062290Sf6EsAge(buffer, offset);
            offset += EsAge.Length;
            Length += EsAge.Length;
        }

        if (HasVdl)
        {
            VdlAge = new I062290Sf7VdlAge(buffer, offset);
            offset += VdlAge.Length;
            Length += VdlAge.Length;
        }

        if (HasUat)
        {
            UatAge = new I062290Sf8UatAge(buffer, offset);
            offset += UatAge.Length;
            Length += UatAge.Length;
        }

        if (HasLop)
        {
            LoopAge = new I062290Sf9LoopAge(buffer, offset);
            offset += LoopAge.Length;
            Length += LoopAge.Length;
        }

        if (HasMlt)
        {
            MultilaterationAge = new I062290Sf10MultilaterationAge(buffer, offset);
            offset += MultilaterationAge.Length;
            Length += MultilaterationAge.Length;
        }
    }

    private void ExtractSubFieldFlag()
    {
        HasTrk = BitOperations.GetBit(RawData, 0);
        HasPsr = BitOperations.GetBit(RawData, 1);
        HasSsr = BitOperations.GetBit(RawData, 2);
        HasMds = BitOperations.GetBit(RawData, 3);
        HasAds = BitOperations.GetBit(RawData, 4);
        HasEs = BitOperations.GetBit(RawData, 5);
        HasVdl = BitOperations.GetBit(RawData, 6);
        Fx1 = BitOperations.GetBit(RawData, 7);
        if (!Fx1) return;
        
        HasUat = BitOperations.GetBit(RawData, 8);
        HasLop = BitOperations.GetBit(RawData, 9);
        HasMlt = BitOperations.GetBit(RawData, 10);
        BitOperations.GetBit(RawData, 11);
        BitOperations.GetBit(RawData, 12);
        BitOperations.GetBit(RawData, 13);
        BitOperations.GetBit(RawData, 14);
        Fx2 = BitOperations.GetBit(RawData, 15);
        if (!Fx2) return;
    }
}