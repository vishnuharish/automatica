﻿using System;
using System.Collections.Generic;
using System.Text;
using P3.Knx.Core.DPT.Base;

namespace P3.Knx.Core.DPT.Dpt7
{
    internal class Dpt7003TypeTranslator : Dpt7Translator
    {
        public override string[] Ids => new[] { "7.003" };

        public override object ConvertFromBusValue(int value)
        {
            return (double)value / 100;
        }

        public virtual ushort ConvertToBusValueInternal(decimal value)
        {
            var busValue = value * 100;

            if (busValue > ushort.MaxValue)
            {
                return ushort.MaxValue;
            }

            return (ushort)busValue;
        }

        public override byte[] ToDataPoint(object value)
        {
            var input = GetValueAsDecimal(value);


            if (!input.HasValue)
            {
                throw new ToDataPointException("value has invalid type");
            }

            var shortValue = ValidateMinMax(ConvertToBusValueInternal(input.Value));

            var dataPoint = BitConverter.GetBytes(shortValue);

            return dataPoint;
        }
    }
}
