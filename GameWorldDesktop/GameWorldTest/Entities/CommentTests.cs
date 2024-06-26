﻿using GameWorld.Models;

namespace GameWorld.Entities.Tests
{
    [TestClass()]
    public class CommentTests
    {
        [TestMethod()]
        public void Constructor_WithValidParameters_InitializesProperties()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            string message = "Test message";
            DateTime createdTime = DateTime.UtcNow;

            // Act
            Comment comment = new Comment(id, userId, message, createdTime);

            // Assert
            Assert.AreEqual(id, comment.Id);
            Assert.AreEqual(userId, comment.PosterUserId);
            Assert.AreEqual(message, comment.CommentMessage);
            Assert.AreEqual(createdTime, comment.CreationTime);
        }
    }
}
