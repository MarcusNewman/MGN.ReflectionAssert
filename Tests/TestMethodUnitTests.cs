﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MGN.ReflectionAssert.Tests
{
    /// <summary>
    /// Summary description for TestMethodUnitTests
    /// </summary>
    [TestClass]
    public class TestMethodUnitTests : UnitTestsBase
    {
        string methodName = "TestMethod";

        [TestMethod]
        public void MethodShouldExist()
        {
            GetMethod();
        }

        public MethodInfo GetMethod()
        {
            return GetMethod(
                methodName: methodName,
                shouldBeStatic: true,
                expectedReturnType: typeof(void),
                shouldBeAnExtentionMethod: true,
                parameterTypesAndNames: new List<Tuple<Type, string>>() {
                    Tuple.Create(typeof(MethodInfo), "methodInfo"),
                    Tuple.Create(typeof(object), "obj"),
                    Tuple.Create(typeof(object[]), "parameters"),
                    Tuple.Create(typeof(object), "expectedResult") });
        }

        //TODO: Need to redo this so that it expects an actual invoked result
        //[TestMethod]
        //public void ShouldFailIfResultIncorrect()
        //{
        //    object expectedResult = null;
        //    Exception actualException = null;
        //    try
        //    {
        //        GetMethod().Invoke(null, new object[] { null, null, null, expectedResult });
        //    }
        //    catch (TargetInvocationException exception)
        //    {
        //        actualException = exception.InnerException;
        //    }
        //    Assert.IsInstanceOfType(actualException, typeof(AssertFailedException), methodName + " should fail if the result does not equal the expected result.");
        //    Assert.IsTrue(actualException.Message.EndsWith(" did not match expected result of " + expectedResult), "Message should say did not match expected result of");
        //}

        //TODO: Need to redo this so that it expects an actual invoked exception
        //[TestMethod]
        //public void ShouldPassIfExpectedResultIsExceptionAndMatches()
        //{
        //    var expectedResult = new Exception("Object reference not set to an instance of an object.");
        //    GetMethod().Invoke(null, new object[] { null, null, new object[] { null, null, null, null }, expectedResult });
        //}        
    }
}