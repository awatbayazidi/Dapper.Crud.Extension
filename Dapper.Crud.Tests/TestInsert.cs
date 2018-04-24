﻿using Dapper.Crud.Tests.ModelTest;
using Dapper.Crud.VSExtension.Helpers;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Dapper.Crud.Tests
{
    public class TestInsert
    {
        [Fact]
        public void GenerateInsert()
        {
            // Arrange
            var objUser = new User();
            IList<PropertyInfo> props = new List<PropertyInfo>(objUser.GetType().GetProperties());

            // Act
            var ret = DapperGenerator.Insert("User", props, false, false);

            // Assert
            Assert.True(ret.Contains("INSERT INTO [User] (Id, Name, Email) VALUES (@Id, @Name, @Email)"));
            Assert.True(ret.Contains("db.Execute(sql, new { Id = user.Id, Name = user.Name, Email = user.Email }, commandType: CommandType.Text);"));
        }
    }
}