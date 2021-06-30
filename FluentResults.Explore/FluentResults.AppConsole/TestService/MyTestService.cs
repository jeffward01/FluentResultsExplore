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


        /// <summary>
        /// This will fail for some reason. It throws error:
        /// ERROR: Result is in status failed. Value is not set.
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// This returns an Result with an embedded object. Appears to be working fine.
        /// </summary>
        /// <returns></returns>
        public Result<SomeClass> TestSuccessResultWithObject()
        {
            var doesSomethingExist = this._doSomeWorkThatWillPass();
            if (doesSomethingExist == false)
            {
                return Result.Fail<SomeClass>("This failed because of an external check or blah blah reason.");
            }

            var someResultToReturnOnSuccess = this._getSomeClassOnSuccess();

            // Question - 
            // A.) Is it better to return this below
            return Result.Ok(someResultToReturnOnSuccess);

            //B.) or is it better to return: someResultToReturnOnSuccess.ToResult() 
            // Instead of what is above?
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