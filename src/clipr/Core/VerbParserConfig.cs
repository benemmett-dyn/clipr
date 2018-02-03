﻿
using clipr.IOC;
using clipr.Triggers;
using System.Collections.Generic;

namespace clipr.Core
{
    /// <summary>
    /// Parsing config for a verb, includes a way to "set" the resulting
    /// verb on the original options object.
    /// </summary>
    public interface IVerbParserConfig: IParserConfig
    {
        /// <summary>
        /// The name of the verb in question
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The description of the verb in question
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Store the verb on the options objcet.
        /// </summary>
        IValueStoreDefinition Store { get; }

        /// <summary>
        /// The verbs leading up to this config (used mostly for help generation)
        /// </summary>
        string[] PrecursorVerbs { get; set; }

        void AppendTriggers(IEnumerable<ITerminatingTrigger> triggers);
    }

    internal class VerbParserConfig<TVerb> : ParserConfig<TVerb>, IVerbParserConfig where TVerb : class 
    {
        public VerbParserConfig(IParserConfig internalParserConfig, IValueStoreDefinition store, ParserOptions options, IVerbFactory factory, string[] precursorVerbs) 
            : base(options, null, factory)
        {
            InternalParserConfig = internalParserConfig;
            Store = store;

            LongNameArguments = InternalParserConfig.LongNameArguments;
            ShortNameArguments = InternalParserConfig.ShortNameArguments;
            PositionalArguments = InternalParserConfig.PositionalArguments;
            Verbs = InternalParserConfig.Verbs;
            PostParseMethods = InternalParserConfig.PostParseMethods;
            RequiredMutuallyExclusiveArguments = InternalParserConfig.RequiredMutuallyExclusiveArguments;
            RequiredNamedArguments = InternalParserConfig.RequiredNamedArguments;
            PrecursorVerbs = precursorVerbs;
        }

        /// <inheritdoc/>
        public string Name { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }

        /// <inheritdoc/>
        public IValueStoreDefinition Store { get; set; }

        /// <inheritdoc/>
        public string[] PrecursorVerbs { get; set; }

        /// <inheritdoc/>
        private IParserConfig InternalParserConfig { get; set; }
    }
}
