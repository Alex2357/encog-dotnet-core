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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ConsoleExamples.Examples;
using Encog.Bot.Browse.Range;
using Encog.Engine.Network.Activation;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.ML.Train;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Propagation;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Util.KMeans;

namespace Encog.Examples.XOR
{
    public class ProductUrlBackPropagation : IExample
    {
        public String[] URLS =
        {
//string.Join(@"""," + "\r\n" + @"""", crawlerContext.Context.Pages.Select(p => p.Url).ToList())
            "http://www.dummydomain2.com/bosch-14-4v-cordless-drill-driver-kit_p6200119",
            "http://www.dummydomain2.com/installation-licensing",
            "http://www.dummydomain2.com/gift-card-scam-warning",
            "http://www.dummydomain2.com/diy-advice/planners-and-calculators",
            "http://www.dummydomain2.com/about-us/our-actions",
            "http://www.dummydomain2.com/our-range/brands/d/dorf",
            "http://www.dummydomain2.com/diy-advice/home-improvement/tools-and-skills/how-to-sharpen-a-chainsaw",
            "http://www.dummydomain2.com/paint-partner-270mm-paint-roller-kit_p1560133",
            "http://www.dummydomain2.com/our-range/brands/h/hpm",
            "http://www.dummydomain2.com/register?ReturnURL=%2F",
            "http://www.dummydomain2.com/sitemap",
            "http://www.dummydomain2.com/diy-advice/home-improvement/walls/stud-walls/how-to-build-a-stud-wall",
            "http://www.dummydomain2.com/dulux-6l-white-ceiling-paint_p1370199",
            "http://www.dummydomain2.com/ryobi-4v-li-ion-cordless-screwdriver_p6210120",
            "http://www.dummydomain2.com/gerni-2-1kw-super-145-3-plus-high-pressure-cleaner_p6270618",
            "http://www.dummydomain2.com/our-range/tools/power-tools/power-cleaning",
            "http://www.dummydomain2.com/aeg-18v-li-ion-cordless-hammer-drill-skin-only_p6210356",
            "http://www.dummydomain2.com/estwing-560g-20oz-vinyl-grip-claw-hammer_p5560192",
            "http://www.dummydomain2.com/diy-advice/home-improvement",
            "http://www.dummydomain2.com/login?ReturnURL=%2F",
            "http://www.dummydomain2.com/our-range/brands",
            "http://www.dummydomain2.com/makita-18v-lxt-mobile-brushless-hammer-drive-drill_p6240306",
            "http://www.dummydomain2.com/our-range/brands/m/makita",
            "http://www.dummydomain2.com/diy-advice/paint",
            "http://www.dummydomain2.com/our-range/brands/a/aeg",
            "http://www.dummydomain2.com/our-range/brands/s/sabco",
            "http://www.dummydomain2.com/graham-brown-jazz-white-silver-52cm-x-10m-wallpaper_p1661168",
            "http://www.dummydomain2.com/our-range/outdoor-living/barbecue",
            "http://www.dummydomain2.com/our-range/building-hardware",
            "http://www.dummydomain2.com/our-range/kitchen",
            "http://www.dummydomain2.com/our-services/in-store",
            "http://www.dummydomain2.com/about-us",
            "http://www.dummydomain2.com/kincrome-51-piece-1-2-drive-imperial-metric-socket-set_p6110238",
            "http://www.dummydomain2.com/our-services/in-home/kitchen-design",
            "http://www.dummydomain2.com/login?ReturnURL=%2Fkarcher-hd-5-11-c-professional-high-pressure-cleaner_p6270485",
            "http://www.dummydomain2.com/makita-18v-impact-wrench-skin-only_p6240157",
            "https://www.dummydomain2.com/register",
            "http://www.dummydomain2.com/our-range/brands/i/irwin",
            "http://www.dummydomain2.com/stores",
            "http://www.dummydomain2.com/our-services/in-home",
            "http://www.dummydomain2.com/our-range/brands/s/selleys",
            "http://www.dummydomain2.com/diy-advice",
            "http://www.dummydomain2.com/diy-advice/flooring",
            "http://www.dummydomain2.com/diy-advice/home-improvement/walls/how-to-install-masonry-fixings",
            "http://www.dummydomain2.com/wish-lists/detail",
            "http://www.dummydomain2.com/returns",
            "http://www.dummydomain2.com/wagner-w670-finespray-paint-sprayer_p1560228",
            "http://www.dummydomain2.com/stores/vic/mentone",
            "http://www.dummydomain2.com/our-services/in-store/special-orders",
            "http://www.dummydomain2.com/diy-advice/rooms",
            "http://www.dummydomain2.com/our-range/brands/h/hume-doors-timber",
            "http://www.dummydomain2.com/our-range/tools/power-tools/cordless-drills",
            "http://www.dummydomain2.com/our-range/brands/b/bosch",
            "http://www.dummydomain2.com/our-range/lighting-electrical",
            "http://www.dummydomain2.com/karcher-2100w-k5-premium-home-kit-car-kit-deluxe-high-pressure-cleaner_p6270702",
            "http://www.dummydomain2.com/our-services/in-store/hire-shop",
            "http://www.dummydomain2.com/our-range/bathroom-plumbing",
            "http://www.dummydomain2.com/our-range/tools/hand-tools",
            "http://www.dummydomain2.com/our-range/brands/n/nylex",
            "http://www.dummydomain2.com/about-us/in-the-community",
            "http://www.dummydomain2.com/gift-ideas/gift-cards",
            "http://www.dummydomain2.com/ryobi-250w-150mm-bench-grinder_p6210389",
            "http://www.dummydomain2.com/our-range/outdoor-living",
            "http://www.dummydomain2.com/our-range/building-hardware/building-construction",
            "http://www.dummydomain2.com/whats-new",
            "http://www.dummydomain2.com/diy-advice/kitchen",
            "http://www.dummydomain2.com/hire-shop-terms-conditions",
            "http://www.dummydomain2.com/diy-advice/home-improvement/concrete/how-to-remove-a-concrete-slab",
            "http://www.dummydomain2.com/terms%20of%20use",
            "http://www.dummydomain2.com/our-range/brands/d/dulux",
            "http://www.dummydomain2.com/catalogue",
            "http://www.dummydomain2.com/gerni-2-1kw-super-145-3-works-high-pressure-cleaner_p6270619",
            "http://www.dummydomain2.com/online-shopping-terms",
            "http://www.dummydomain2.com/store-entry-information",
            "http://www.dummydomain2.com/disney-cars-racetrack-52cm-x-10m-wallpaper_p1661912",
            "http://www.dummydomain2.com/superfresco-easy-monaco-52cm-x-10m-paintable-wallpaper_p1710115",
            "http://www.dummydomain2.com/register?ReturnURL=%2Faeg-18v-li-ion-cordless-hammer-drill-skin-only_p6210356",
            "http://www.dummydomain2.com/dremel-8220-1-28-10-8v-lithium-ion-cordless-rotary-tool_p6280071",
            "http://www.dummydomain2.com/register?ReturnURL=%2Fkarcher-hd-5-11-c-professional-high-pressure-cleaner_p6270485",
            "http://www.dummydomain2.com/our-range/brands/p/pope",
            "http://www.dummydomain2.com/our-services/in-home/garage-doors-installation",
            "http://www.dummydomain2.com/our-range/brands/m/matador",
            "http://www.dummydomain2.com/diy-advice/garden/planting-and-growing/how-to-prune-trees",
            "http://www.dummydomain2.com/our-range/brands/k/karcher",
            "http://www.dummydomain2.com/our-range",
            "http://www.dummydomain2.com/diy-advice/home-improvement/tiles/how-to-drill-into-tiles",
            "http://www.dummydomain2.com/our-services/in-store/colour-matching",
            "http://www.dummydomain2.com/diy-advice/outdoor",
            "http://www.dummydomain2.com/our-range/tools",
            "http://www.dummydomain2.com/our-range/tools/tool-accessories",
            "http://www.dummydomain2.com/our-range/brands/d/dux",
            "http://www.dummydomain2.com/our-range/brands/p/philips",
            "http://www.dummydomain2.com/makita-450w-jigsaw_p6240068",
            "http://www.dummydomain2.com/diy-advice/home-improvement/tiles/how-to-remove-grout",
            "http://www.dummydomain2.com/our-range/outdoor-living/swimming-pools-spa",
            "http://www.dummydomain2.com/our-range/garden",
            "http://www.dummydomain2.com/dewalt-18v-li-ion-xr-bare-brushless-high-torque-impact-wrench_p6260328",
            "http://www.dummydomain2.com/our-range/brands/b/british-paints",
            "http://www.dummydomain2.com/our-range/outdoor-living/outdoor-furniture",
            "http://www.dummydomain2.com/taubmans-3-in-1-500ml-sealer-primer-undercoat_p1540362",
            "http://www.dummydomain2.com/diy-advice/home-improvement/tools-and-skills/how-to-choose-tools-for-your-toolbox",
            "http://www.dummydomain2.com/our-services",
            "http://www.dummydomain2.com/diy-advice/home-decor",
            "http://www.dummydomain2.com/our-range/brands/e/esky",
            "http://www.dummydomain2.com/our-range/brands/t/taubmans",
            "http://www.dummydomain2.com/irwin-quick-grip-4-piece-mini-clamp-set_p5860055",
            "http://www.dummydomain2.com/our-services/in-home/custom-blinds",
            "http://www.dummydomain2.com/our-services/in-home/door-installation",
            "http://www.dummydomain2.com/our-range/storage-cleaning",
            "http://www.dummydomain2.com/our-range/brands/r/ryobi",
            "http://www.dummydomain2.com/karcher-hd-5-11-c-professional-high-pressure-cleaner_p6270485",
            "http://www.dummydomain2.com/our-services/in-home/custom-benchtops",
            "http://www.dummydomain2.com/special-orders-terms-conditions",
            "http://www.dummydomain2.com/about-us/contractor-induction",
            "http://www.dummydomain2.com/our-range/brands/g/gainsborough",
            "http://www.dummydomain2.com/diy-advice/bathroom",
            "http://www.dummydomain2.com/join-our-team",
            "http://www.dummydomain2.com/our-range/building-hardware/door-window-gate-hardware",
            "http://www.dummydomain2.com/about-us/for-our-suppliers",
            "http://www.dummydomain2.com/yourstore",
            "http://www.dummydomain2.com/our-services/in-home/carpet-installation",
            "http://www.dummydomain2.com/our-range/brands/l/lockwood",
            "http://www.dummydomain2.com/our-range/brands/s/sidchrome",
            "http://www.dummydomain2.com/returns/recalls",
            "http://www.dummydomain2.com/our-range/tools/power-tools",
            "http://www.dummydomain2.com/our-range/tools/power-tools/power-cleaning/electric-pressure-cleaners",
            "http://www.dummydomain2.com/diy-advice/flooring/tiles/how-to-remove-floor-tiles",
            "http://www.dummydomain2.com/our-range/brands/c/cyclone",
            "http://www.dummydomain2.com/aeg-18v-brushless-hammer-drill-skin-only_p6230162",
            "http://www.dummydomain2.com/our-range/garden/plants",
            "http://www.dummydomain2.com/our-range/garden/landscaping",
            "http://www.dummydomain2.com/contact-us",
            "http://www.dummydomain2.com/privacy-statement",
            "http://www.dummydomain2.com/gift-ideas",
            "http://www.dummydomain2.com/diy-advice/outdoor/decking/how-to-stain-a-deck",
            "http://www.dummydomain2.com/spring-4l-flat-white-interior-paint_p1400910",
            "http://www.dummydomain2.com/diy-advice/outdoor/decking/how-to-sand-a-deck",
            "http://www.dummydomain2.com/dewalt-18v-xr-brushless-impact-driver-skin_p6260287",
            "http://www.dummydomain2.com/diy-advice/kids",
            "http://www.dummydomain2.com/login?ReturnURL=%2Faeg-18v-li-ion-cordless-hammer-drill-skin-only_p6210356",
            "http://www.dummydomain2.com/our-services/in-home/colour-consultant",
            "http://www.dummydomain2.com/diy-advice/garden",
            "http://www.dummydomain2.com/diy-advice/sustainability",
            "http://www.dummydomain2.com/price-guarantee",
            "http://www.dummydomain2.com/our-services/in-home/air-conditioning-installation",
            "http://www.dummydomain2.com/our-range/tools/power-tools/cordless-drills/cordless-drill-skins",
            "http://www.dummydomain2.com/our-services/in-home/hot-water-installation",
            "http://www.dummydomain2.com/karcher-2100w-2100psi-k5-car-high-pressure-cleaner-kit_p6270701",
            "http://www.dummydomain2.com/our-range/brands/c/caroma",
            "http://www.dummydomain2.com/our-range/paint-decorating",
            "http://www.dummydomain2.com/trade"
        };

        public static ExampleInfo Info
        {
            get
            {
                var info = new ExampleInfo(
                    typeof(ProductUrlBackPropagation),
                    "ProductUrlBackPropagation",
                    "Product url testing",
                    "Product url training with backpropagation.");
                return info;
            }
        }

        #region IExample Members

        /// <summary>
        /// Program entry point.
        /// </summary>
        /// <param name="app">Holds arguments and other info.</param>
        public void Execute(IExampleInterface app)
        {
            // create a neural network, without using a factory
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(null, true, 512));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 512));
            
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 512));//Added one more layer to check if it would work better because without it it has few issues
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 512));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 1));
            network.Structure.FinalizeStructure();
            network.Reset();

            var urlsInput = new double[URLS.Length][];
            var urlsResult = new double[URLS.Length][];
            int i = 0;
            foreach (var url in URLS)
            {
                urlsInput[i] = new double[512];
                StringToDoubleArray(url, urlsInput[i]);
                var productUrl = Regex.IsMatch(url, @".*_p\d+");
                var d = !url.Contains("ReturnURL=") && productUrl ? 1.0 : 0;
                urlsResult[i] = new[] {d};
                i++;
            }
            // create training data
            IMLDataSet trainingSet = new BasicMLDataSet(urlsInput, urlsResult);

            // train the neural network using online (batch=1)
            Propagation train = new Backpropagation(network, trainingSet, 0.7, 0.3);
            train.BatchSize = 1;

            int epoch = 1;

            do
            {
                train.Iteration();
                Console.WriteLine(@"Epoch #" + epoch + @" Error:" + train.Error);
                epoch++;
            } while (train.Error > 0.0001);

            // test the neural network
            Console.WriteLine(@"Neural Network Results:");
            foreach (IMLDataPair pair in trainingSet)
            {
                IMLData output = network.Compute(pair.Input);
                var input = DoubleArrayToString(pair.Input);
                Console.WriteLine("Input=" + input
                                  + @", actual=" + output[0] + @",ideal=" + pair.Ideal[0]);
            }

            var res = network.Compute(new StringMLData("http://www.dummydomain2.com/login?ReturnURL=%2Faeg-18v-li-ion-cordless-hammer-drill-skin-only_p6210356"))[0];
            res = network.Compute(new StringMLData("http://www.dummydomain2.com/18v-li-ion-cordless-hammer-drill-skin-only_p6210356"))[0];
            res = network.Compute(new StringMLData("http://www.dummydomain2.com/bla-bla-18v-hjsdfj-dhg_p3473985"))[0];
            res = network.Compute(new StringMLData("http://www.dummydomain2.com/bla_p1"))[0];

        }

        private static string DoubleArrayToString(IMLData mlData)
        {
            var count = mlData.Count;
            var doubles = new double[count];
            mlData.CopyTo(doubles, 0, count);
            var input = new string(doubles.Select(d => (char) d).TakeWhile(c => c > 0).ToArray());
            return input;
        }

        private static void StringToDoubleArray(string url, double[] array)
        {
            var stringAsDoubleArray = url.Select(c => (double) c).ToArray();
            stringAsDoubleArray.CopyTo(array, 0);
        }

        #endregion
    }

    public class StringMLData : IMLData
    {
        public StringMLData(string input)
        {
            Input = input;
        }

        public string Input { get; private set; }

        public object Clone()
        {
            return new StringMLData(Input);
        }

        public ICentroid<IMLData> CreateCentroid()
        {
            throw new NotImplementedException();
        }

        public double this[int x]
        {
            get { return Input[x]; }
        }

        public int Count { get { return Input.Length; } }
        public void CopyTo(double[] target, int targetIndex, int count)
        {
            for (int i = 0; i < count && i < Input.Length; i++)
            {
                target[targetIndex + i] = Input[i];
            }
        }
    }
}
