namespace DiskManager.InputValidation
{
    public interface IDataValidator
    {
        string errorDescription { get; }
        int[] used { get; }
        int[] total { get; }
        bool validateInputData(string used, string total);
    }
}