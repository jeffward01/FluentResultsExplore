namespace FluentResults.AppConsole.TestService
{
    using FluentResults.AppConsole.TestClass;
    using LoremNETCore;

    public class MyTestService
    {
        public Result TestFailingResultWithNoObject()
        {
            return Result.Fail(Generate.Sentence(6, 12));
        }

        public Result TestSuccessResultWithNoObject()
        {
            return Result.Ok();
        }

        public Result<SomeClass> TestFailResultWithObject()
        {
            var doesSomethingExist = this._doSomeWorkThatWillFail();
            if (doesSomethingExist == false)
            {
                return Result.Fail<SomeClass>("This failed because of an external check or blah blah reason.");
            }

            var someResultToReturnOnSuccess = this._getSomeClassOnSuccess();


            return Result.Ok(someResultToReturnOnSuccess);
        }

        public Result<SomeClass> TestSuccessResultWithObject()
        {
            var doesSomethingExist = this._doSomeWorkThatWillPass();
            if (doesSomethingExist == false)
            {
                return Result.Fail<SomeClass>("This failed because of an external check or blah blah reason.");
            }

            var someResultToReturnOnSuccess = this._getSomeClassOnSuccess();


            return Result.Ok(someResultToReturnOnSuccess);
        }


        private SomeClass _getSomeClassOnSuccess()
        {
            return new SomeClass();
        }
        private bool _doSomeWorkThatWillPass()
        {
            return true;
        }
        private bool _doSomeWorkThatWillFail()
        {
            return false;
        }
    }
}