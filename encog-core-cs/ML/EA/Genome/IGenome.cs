﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.ML.EA.Population;
using Encog.ML.EA.Species;

namespace Encog.ML.EA.Genome
{
    /// <summary>
    /// A genome is the basic blueprint for creating an phenome (organism) in Encog.
    /// Some genomes also function as phenomes.
    /// </summary>
    public interface IGenome : IMLMethod
    {
        /// <summary>
        /// Copy from the specified genome into this one.
        /// </summary>
        /// <param name="source">The source genome.</param>
        void Copy(IGenome source);

        /// <summary>
        /// Get the adjusted score, this considers old-age penalties and youth
        /// bonuses. If there are no such bonuses or penalties, this is the same as
        /// the score.
        /// </summary>
        double AdjustedScore { get; set; }

        /// <summary>
        /// The birth generation (or iteration).
        /// </summary>
        int BirthGeneration { get; set; }

        /// <summary>
        /// The population that this genome belongs to.
        /// </summary>
        IPopulation Population { get; set; }

        /// <summary>
        /// The score for this genome.
        /// </summary>
        double Score { get; set; }

        /// <summary>
        /// The size of this genome. This size is a relative number
        /// that indicates the complexity of the genome.
        /// </summary>
        int Size { get; }


        /// <summary>
        /// The species for this genome.
        /// </summary>
        ISpecies Species { get; set; }

    }
}
