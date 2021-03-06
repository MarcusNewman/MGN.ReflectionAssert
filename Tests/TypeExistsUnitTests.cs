﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MGN.ReflectionAssert.Tests
{
    [TestClass]
    public class TypeExistsUnitTests : UnitTestsBase
    {
        string methodName = "TypeExists";

        [TestMethod]
        public void TypeExistsMethodShouldExist()
        {
            GetTypeExistsMethod();
        }

        [TestMethod]
        public void TypeExistsShouldReturnTheCorrectTypeWithAValidTypeName()
        {
            var type = InvokeTypeExists(typeName);
            var actual = type.Name;
            var expected = typeName;
            var message = methodName + " should return the correct type with a valid typeName.";
            Assert.AreEqual(expected, actual, message);
        }

        [TestMethod]
        public void TypeExistsShouldThrowAnAssertFailedExceptionIfTheTypeIsNotFound()
        {
            var actualException = TryToInvokeTypeExistsWithInvalidName();
            var expectedType = typeof(AssertFailedException);
            var message = methodName + " should throw an AssertFailed exception if the type is not found.";
            Assert.IsInstanceOfType(actualException, expectedType, message);
        }

        [TestMethod]
        public void TypeExistsErrorMessageShouldBeAssemblyShouldExist()
        {
            var actualException = TryToInvokeTypeExistsWithInvalidName();
            var actual = actualException.Message;
            var expected = invalidName + " type should exist.";
            var message = methodName + " error message should be " + expected;
            Assert.AreEqual(expected, actual, message);
        }

        Type InvokeTypeExists(string typeName)
        {
            var methodInfo = GetTypeExistsMethod();
            var parameters = new object[] { GetAssembly(), typeName, namespaceName };
            return (Type)methodInfo.Invoke(null, parameters);
        }

        Exception TryToInvokeTypeExistsWithInvalidName()
        {
            Exception result = null;
            try
            {
                InvokeTypeExists(invalidName);
            }
            catch (TargetInvocationException exception)
            {
                //Return InnerException to skip the target of the invocation layer.
                result = exception.InnerException;
            }
            return result;
        }

        public MethodInfo GetTypeExistsMethod()
        {
            MethodInfo methodInfo = null;
            try
            {
                methodInfo = GetMethod(
              methodName: methodName,
              shouldBeStatic: true,
              expectedReturnType: typeof(Type),
              shouldBeAnExtentionMethod: true,
              parameterTypesAndNames: new List<Tuple<Type, string>>() {
                Tuple.Create(typeof(Assembly), "assembly"),
                Tuple.Create(typeof(string), "typeName"),
                Tuple.Create(typeof(string), "namespaceName") });
            }
            catch
            {
                throw new AssertFailedException("TypeExists method should exist.");
            }
            return methodInfo;
        }
    }
}