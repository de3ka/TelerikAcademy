using System;

namespace School.Importer.Interfaces
{
    public interface IRandomGenerator
    {
        int GetRandomNumber(int min, int max);

        string GetRandomString(int minLength, int maxLength);

        DateTime GetRandomDate(DateTime start, DateTime end);
    }
}