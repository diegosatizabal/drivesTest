using System;
using System.Collections.Generic;

namespace DiskManager.InputValidation
{
    public class DataValidator : IDataValidator
    {
        public int[] used { get; private set; }
        public int[] total { get; private set; }
        public string errorDescription { get; private set; }

        public bool validateInputData(string usedStr, string totalStr)
        {
            List<int> usedValues = new List<int>();
            List<int> totalValues = new List<int>();
            string[] parts;
            int x = 01;

            if (String.IsNullOrWhiteSpace(usedStr) || String.IsNullOrWhiteSpace(totalStr))
            {
                errorDescription = "Invalid arguments";
                return false;
            }

            parts = usedStr.Split(',');
            foreach (string onePart in parts)
            {
                if (String.IsNullOrWhiteSpace(onePart))
                {
                    errorDescription = "Invalid value in disk usage array";
                    return false;
                }
                if (!int.TryParse(onePart, out x))
                {
                    errorDescription = $"Value in disk usage array is not an integer value: {onePart}";
                    return false;
                }
                if (x < 0 || x > 1000)
                {
                    errorDescription = $"Value in disk usage array is out of admisible range (1-1000): {onePart}";
                    return false;
                }

                usedValues.Add(x);
            }

            parts = totalStr.Split(',');
            foreach (string onePart in parts)
            {
                if (String.IsNullOrWhiteSpace(onePart))
                {
                    errorDescription = "Invalid value in disk capacity array";
                    return false;
                }
                if (!int.TryParse(onePart, out x))
                {
                    errorDescription = $"Value in disk capacity array is not an integer value: {onePart}";
                    return false;
                }
                if (x < 0 || x > 1000)
                {
                    errorDescription = $"Value in disk capacity array is out of admisible range (1-1000): {onePart}";
                    return false;
                }

                totalValues.Add(x);
            }

            if (usedValues.Count != totalValues.Count)
            {
                errorDescription = $"Disk capacity array has not the same lenght as usage array: {totalValues.Count.ToString()} not equal to {usedValues.Count.ToString()}";
                return false;
            }

            used = usedValues.ToArray();
            total = totalValues.ToArray();

            return true;
        }
    }
}
