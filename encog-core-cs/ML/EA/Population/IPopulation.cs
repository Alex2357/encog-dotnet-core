﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.ML.EA.Genome;
using Encog.ML.EA.Species;

namespace Encog.ML.EA.Population
{
    /// <summary>
    /// Defines a population of genomes.
    /// </summary>
    public interface IPopulation: IMLMethod
    {
        /// <summary>
        /// Clear all genomes from this population.
        /// </summary>
        void Clear();

        /// <summary>
        /// Create a species.
        /// </summary>
        /// <returns>The newly created species.</returns>
        ISpecies CreateSpecies();

        /// <summary>
        /// Determine which species has the top genome.
        /// </summary>
        /// <returns>The species with the top genome.</returns>
        ISpecies DetermineBestSpecies();

        /// <summary>
        /// Flatten the species into a single list of genomes.
        /// </summary>
        /// <returns>The genomes that make up all species in the population.</returns>
        IList<IGenome> Flatten();

        /// <summary>
        /// The best genome in the population.
        /// </summary>
        IGenome BestGenome { get; set; }

        /// <summary>
        /// A factory used to create genomes.
        /// </summary>
        IGenomeFactory GenomeFactory { get; set; }

        /// <summary>
        /// The max size that an individual can become.
        /// </summary>
        int MaxIndividualSize { get; }

        /// <summary>
        /// The max population size.
        /// </summary>
        int PopulationSize { get; set; }

        /// <summary>
        /// The size of the population.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// The list of species.  
        /// </summary>
        IList<ISpecies> Species { get; }
    }
}
