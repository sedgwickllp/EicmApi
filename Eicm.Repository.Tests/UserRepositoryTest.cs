// <copyright file="UserRepositoryTest.cs">Copyright ©  2017</copyright>
using System;
using System.Threading.Tasks;
using Eicm.Core.Extensions;
using Eicm.Repository;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eicm.Repository.Tests
{
    /// <summary>This class contains parameterized unit tests for UserRepository</summary>
    [PexClass(typeof(UserRepository))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class UserRepositoryTest
    {
        /// <summary>Test stub for AddUserAsync(Nullable`1&lt;Guid&gt;, String, String, String, String)</summary>
        [PexMethod]
        public Task<ICommonResult<int>> AddUserAsyncTest(
            [PexAssumeUnderTest]UserRepository target,
            Guid? userId,
            string userName,
            string email,
            string firstName,
            string lastName
        )
        {
            Task<ICommonResult<int>> result
               = target.AddUserAsync(userId, userName, email, firstName, lastName);
            return result;
            // TODO: add assertions to method UserRepositoryTest.AddUserAsyncTest(UserRepository, Nullable`1<Guid>, String, String, String, String)
        }
    }
}
