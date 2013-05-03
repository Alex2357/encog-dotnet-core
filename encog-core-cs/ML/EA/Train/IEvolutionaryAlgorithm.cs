﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.ML.EA.Opp.Selection;
using Encog.ML.EA.Genome;
using Encog.ML.EA.Population;
using Encog.Neural.Networks.Training;
using Encog.ML.EA.Codec;
using Encog.ML.EA.Species;
using Encog.ML.EA.Sort;
using Encog.ML.EA.Rules;
using Encog.ML.EA.Opp;
using Encog.ML.EA.Score;

namespace Encog.ML.EA.Train
{
    /// <summary>
    /// This interface defines the basic functionality of an Evolutionary Algorithm.
    /// An evolutionary algorithm is one that applies operations to a population of
    /// potential "solutions".
    /// </summary>
    public interface IEvolutionaryAlgorithm
    {
        /// <summary>
        /// Add an operation.
        /// </summary>
        /// <param name="probability">The probability of using this operator.</param>
        /// <param name="opp">The operator to add.</param>
        void AddOperation(double probability, IEvolutionaryOperator opp);

        /// <summary>
        /// Add a score adjuster. Score adjusters are used to adjust the adjusted
        /// score of a genome. This allows bonuses and penalties to be applied for
        /// desirable or undesirable traits.
        /// </summary>
        /// <param name="scoreAdjust">The score adjustor to add.</param>
        void AddScoreAdjuster(IAdjustScore scoreAdjust);

        /// <summary>
        /// Calculate the score for a genome.
        /// </summary>
        /// <param name="g">The genome to calculate the score for.</param>
        void CalculateScore(IGenome g);

        /// <summary>
        /// Called when training is finished. This allows the EA to properly shut
        /// down.
        /// </summary>
        void FinishTraining();

        /// <summary>
        /// Get the comparator that is used to choose the "true best" genome. This
        /// uses the real score, and not the adjusted score.
        /// </summary>
        IGenomeComparer BestComparer { get; set; }

        /// <summary>
        /// The current best genome. This genome is safe to use while the EA
        /// is running. Genomes are not modified. They simply produce
        /// "offspring".
        /// </summary>
        IGenome BestGenome { get; }

        /// <summary>
        /// The CODEC that is used to transform between genome and phenome.
        /// </summary>
        IGeneticCODEC CODEC { get; set; }

        /// <summary>
        /// The current score. This value should either be minimized or
        /// maximized, depending on the score function.
        /// </summary>
        double Error { get; }

        /// <summary>
        /// The current iteration number. Also sometimes referred to as
        /// generation or epoch.
        /// </summary>
        int IterationNumber { get; }

        /// <summary>
        /// The maximum size an individual genome can be. This is an
        /// arbitrary number defined by the genome. Lower numbers are less
        /// complex.
        /// </summary>
        int MaxIndividualSize { get; }

        /// <summary>
        /// The maximum number to try certain genetic operations. This
        /// prevents endless loops.
        /// </summary>
        int MaxTries { get; }

        /// <summary>
        /// The operators.
        /// </summary>
        OperationList Operators { get; }

        /// <summary>
        /// The population.
        /// </summary>
        IPopulation Population { get; set;  }

        /// <summary>
        /// The rules holder, contains rewrite and constraint rules.
        /// </summary>
        IRuleHolder Rules { get; set; }

        /// <summary>
        ///  The score adjusters. This allows bonuses and penalties to be
        /// applied for desirable or undesirable traits.
        /// </summary>
        IList<IAdjustScore> ScoreAdjusters { get; }

        /// <summary>
        /// The score function.
        /// </summary>
        ICalculateScore ScoreFunction { get; }

        /// <summary>
        /// The selection operator. Used to choose genomes.
        /// </summary>
        ISelectionOperator Selection { get; set; }

        /// <summary>
        /// Get the comparator that is used to choose the "best" genome for
        /// selection, as opposed to the "true best". This uses the adjusted score,
        /// and not the score.
        /// </summary>
        IGenomeComparer SelectionComparer { get; set; }

        /// <summary>
        /// True if exceptions that occur during genetic operations should be
        /// ignored.
        /// </summary>
        bool ShouldIgnoreExceptions { get; set;  }

        /// <summary>
        /// The speciation method.
        /// </summary>
        ISpeciation Speciation { get; set; }

        /// <summary>
        /// True if any genome validators should be applied.
        /// </summary>
        bool ValidationMode { get; set; }

        /// <summary>
        /// Perform a training iteration. Also called generations or epochs.
        /// </summary>
        void Iteration();
    }
}
