namespace FluentResults.AppConsole.TestClass
{
    using LoremNETCore;

    public class SomeClass
    {
        public SomeClass()
        {
            this.Title = Generate.Words(3);
        }


        public string Title { get; }
    }
}