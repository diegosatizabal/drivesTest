using System.Linq;

namespace DiskManager.DrivesCalculation
{
    public class DiskSpace : IDiskSpace
    {
        private int[] _used;
        private int[] _total;
        private int _totalUsed;

        public int TotalUsedSpace { get; private set; }
        public int TotalAvailiableSpace { get; private set; }


        public int minDrives(int[] used, int[] total)
        {
            int n = 0;

            if (used == null || total == null)
                return -1;

            if (used.Length <= 0 || total.Length <= 0)
                return -1;

            _used = used;
            _total = total.OrderByDescending(c => c).ToArray();
            TotalUsedSpace = _used.Sum();
            TotalAvailiableSpace = _total.Sum();

            _totalUsed = TotalUsedSpace;
            while (_totalUsed > 0)
            {
                _totalUsed -= total[n++];
            }

            return n;
        }
    }
}
