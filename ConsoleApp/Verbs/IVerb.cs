namespace Blackrazor.CLI.Verbs
{
    internal interface IVerb<TOptions> where TOptions : IVerbOptions
    {
        /// <summary>
        /// Executes the <see cref="IVerb{TOptions}"/> with the provided <typeparamref name="TOptions"/>
        /// </summary>
        /// <param name="options"></param>
        public void Execute(TOptions options);
    }

    internal interface IVerbOptions { }
}
