using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAlgorithm {
    class OldImplementation {
        internal static List<Double> DirectTransform(List<Double> SourceList) {
            if (SourceList.Count == 1)
                return SourceList;

            List<Double> RetVal = new List<Double>();
            List<Double> TmpArr = new List<Double>();

            for (int j = 0; j < SourceList.Count - 1; j += 2) {
                RetVal.Add((SourceList[j] - SourceList[j + 1]) / 2.0);
                TmpArr.Add((SourceList[j] + SourceList[j + 1]) / 2.0);
            }

            RetVal.AddRange(DirectTransform(TmpArr));

            return RetVal;
        }

        internal static List<Double> InverseTransform(List<Double> SourceList) {
            if (SourceList.Count == 1)
                return SourceList;

            List<Double> RetVal = new List<Double>();
            List<Double> TmpPart = new List<Double>();

            for (int i = SourceList.Count / 2; i < SourceList.Count; i++)
                TmpPart.Add(SourceList[i]);

            List<Double> SecondPart = InverseTransform(TmpPart);

            for (int i = 0; i < SourceList.Count / 2; i++) {
                RetVal.Add(SecondPart[i] + SourceList[i]);
                RetVal.Add(SecondPart[i] - SourceList[i]);
            }

            return RetVal;
        }
    }
}
