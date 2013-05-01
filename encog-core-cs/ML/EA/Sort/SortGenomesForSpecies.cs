﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.ML.EA.Genome;
using Encog.ML.EA.Train;

namespace Encog.ML.EA.Sort
{
    /// <summary>
    /// Sort the gnomes for species.  Sort first by score, second by birth generation.
    /// This favors younger genomes if scores are equal.
    /// </summary>
    public class SortGenomesForSpecies : IComparer<IGenome>
    {
        /// <summary>
        /// The trainer.
        /// </summary>
        private IEvolutionaryAlgorithm train;

        /// <summary>
        /// Construct the comparator.
        /// </summary>
        /// <param name="theTrain">The trainer.</param>
        public SortGenomesForSpecies(IEvolutionaryAlgorithm theTrain)
        {
            this.train = theTrain;
        }

        /// <inheritdoc/>
        public int Compare(IGenome g1, IGenome g2)
        {
            int result = this.train.SelectionComparer.Compare(g1, g2);

            if (result != 0)
            {
                return result;
            }

            return g2.BirthGeneration - g1.BirthGeneration;
        }
    }
}
