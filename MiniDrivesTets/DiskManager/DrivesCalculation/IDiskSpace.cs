namespace DiskManager.DrivesCalculation
{
    public interface IDiskSpace
    {
        int TotalUsedSpace { get; }
        int TotalAvailiableSpace { get; }
        int minDrives(int[] used, int[] total);
    }
}