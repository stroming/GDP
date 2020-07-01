using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace GDP
{
    public interface IStorage
    {
        void WriteYearAndValue(int year ,double value);
        void Read(int yearIndex, int valueIndex);
    }
}