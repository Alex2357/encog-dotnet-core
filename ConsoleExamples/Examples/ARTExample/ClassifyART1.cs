//
// Encog(tm) Core v3.2 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2014 Heaton Research, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//   
// For more information on Heaton Research copyrights, licenses 
// and trademarks visit:
// http://www.heatonresearch.com/copyright
//
using System;
using System.Collections;
using ConsoleExamples.Examples;
using Encog.ML.Data.Specific;
using Encog.Neural.ART;
using Encog.Neural.Pattern;

namespace Encog.Examples.ARTExample
{
    public class ClassifyART1 : IExample
    {
        public const int INPUT_NEURONS = 2048;//5;
        public const int OUTPUT_NEURONS = 10;

        public String[] PATTERN = {
            "http://dummydomain.com.au/our-range/tools",
            "http://dummydomain.com.au/our-range/tools/power-tools",
            "http://dummydomain.com.au/our-range/tools/hand-tools",
            "http://dummydomain.com.au/product/73694",
            "http://dummydomain.com.au/product/38245",
            "http://dummydomain.com.au/product/28246",
            "http://dummydomain.com.au/product/37246",
            "http://dummydomain.com.au/product/18246",
            "http://dummydomain.com.au/product/39251",
            "http://dummydomain.com.au/product/39252",
            "http://dummydomain.com.au/product/39253",
            "http://dummydomain.com.au/product/39254",
            "http://dummydomain.com.au/our-range/tools/power-tools/cordless-drills",
            "http://dummydomain.com.au/our-range/tools/power-tools/power-saws",
            "http://dummydomain.com.au/our-range/tools/hand-tools/tool-storage",
            "http://dummydomain.com.au/our-range/tools/power-tools/power-cleaning",
            "http://dummydomain.com.au/our-range/tools/power-tools/sanders",
            "http://dummydomain.com.au/our-range/tools/power-tools/air-compressors",
            "http://dummydomain.com.au/our-range/tools/power-tools/generators",
            "http://dummydomain.com.au/our-range/tools/hand-tools/sockets-spanners-and-tool-kits",
            "http://dummydomain.com.au/our-range/tools/power-tools/cordless-skins",
            "http://dummydomain.com.au/product/38246",
            "http://dummydomain.com.au/product/43246",
            "http://dummydomain.com.au/product/38246",
            "http://dummydomain.com.au/our-range/tools/power-tools/corded-drills",
            "http://dummydomain.com.au/our-range/tools/hand-tools/measuring-tools",
            "http://dummydomain.com.au/product/39255",
            "http://dummydomain.com.au/our-range/tools/power-tools/cordless-accessories",
            "http://dummydomain.com.au/product/39256",
            "http://dummydomain.com.au/our-range/tools/hand-tools",
            "http://dummydomain.com.au/our-range/tools/hand-tools/saws-knives-and-blades",
            "http://dummydomain.com.au/our-range/tools/hand-tools/safety-equipment-and-workwear",
            "http://dummydomain.com.au/our-range/tools/hand-tools/clamps-pliers-and-vices",
                //                      "   O ",
                //                      "  O O",
                //                      "    O",
                //                      "  O O",
                //                      "    O",
                //                      "  O O",
                //                      "    O",
                //                      " OO O",
                //                      " OO  ",
                //                      " OO O",
                //                      " OO  ",
                //                      "OOO  ",
                //                      "OO   ",
                //                      "O    ",
                //                      "OO   ",
                //                      "OOO  ",
                //                      "OOOO ",
                //                      "OOOOO",
                //                      "O    ",
                //                      " O   ",
                //                      "  O  ",
                //                      "   O ",
                //                      "    O",
                //                      "  O O",
                //                      " OO O",
                //                      " OO  ",
                //                      "OOO  ",
                //                      "OO   ",
                //                      "OOOO ",
                //                      "OOOOO"

                //,
                //                      "   O ",
                //                      "  O O",
                //                      "    O",
                //                      "  O O",
                //                      "    O",
                //                      "  O O",
                //                      "    O",
                //                      " OO O",
                //                      " OO  ",
                //                      " OO O",
                //                      " OO  ",
                //                      "OOO  ",
                //                      "OO   ",
                //                      "O    ",
                //                      "OO   ",
                //                      "OOO  ",
                //                      "OOOO ",
                //                      "OOOOO",
                //                      "O    ",
                //                      " O   ",
                //                      "  O  ",
                //                      "   O ",
                //                      "    O",
                //                      "  O O",
                //                      " OO O",
                //                      " OO  ",
                //                      "OOO  ",
                //                      "OO   ",
                //                      "OOOO ",
                //                      "OOOOO"

                                  };

        private IExampleInterface app;
        private bool[][] input;

        public static ExampleInfo Info
        {
            get
            {
                var info = new ExampleInfo(
                    typeof (ClassifyART1),
                    "art1-classify",
                    "Classify Patterns with ART1",
                    "Uses an ART1 neural network to classify input patterns into groups.  The ART1 network learns these groups as it is presented with items to classify.");
                return info;
            }
        }

        #region IExample Members

        public void Execute(IExampleInterface app)
        {
            this.app = app;
            SetupInput2();
            var pattern = new ART1Pattern();
            pattern.InputNeurons = INPUT_NEURONS;
            pattern.OutputNeurons = OUTPUT_NEURONS;
            var network = (ART1) pattern.Generate();


            for (int i = 0; i < PATTERN.Length; i++)
            {
                var dataIn = new BiPolarMLData(input[i]);
                var dataOut = new BiPolarMLData(OUTPUT_NEURONS);
                network.Compute(dataIn, dataOut);
                if (network.HasWinner)
                {
                    app.WriteLine(PATTERN[i] + " - " + network.Winner);
                }
                else
                {
                    app.WriteLine(PATTERN[i] + " - new Input and all Classes exhausted");
                }
            }
        }

        #endregion

        public void SetupInput()
        {
            input = new bool[PATTERN.Length][];
            for (int n = 0; n < PATTERN.Length; n++)
            {
                input[n] = new bool[INPUT_NEURONS];
                for (int i = 0; i < INPUT_NEURONS; i++)
                {
                    input[n][i] = (PATTERN[n][i] == 'O');
                }
            }
        }

        public void SetupInput2()
        {
            input = new bool[PATTERN.Length][];
            for (int n = 0; n < PATTERN.Length; n++)
            {
                var bytes = GetBytes(PATTERN[n]);
                var bitArray = new BitArray(bytes);
                input[n] = new bool[INPUT_NEURONS];
                bitArray.CopyTo(input[n], 0);
            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }
}
