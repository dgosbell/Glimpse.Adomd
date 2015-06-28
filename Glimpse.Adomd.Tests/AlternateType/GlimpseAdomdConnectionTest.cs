﻿using System.Data;

namespace Glimpse.Adomd.Tests.AlternateType
{
    using System;
    using Adomd.AlternateType;
    using Messages;
    using Microsoft.AnalysisServices.AdomdClient;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class GlimpseAdomdConnectionTest
    {
        [Test]
        public void Constructor_NullConnection_Throws()
        {
            Assert.That(
                () => new GlimpseAdomdConnection(null, new Mock<ITimedMessagePublisher>().Object),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_NullPublisher_Throws()
        {
            Assert.That(
                () => new GlimpseAdomdConnection(new Mock<IAdomdConnection>().Object, null),
                Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_SetsDefaults()
        {
            var conn = new GlimpseAdomdConnection(new Mock<IAdomdConnection>().Object,
                new Mock<ITimedMessagePublisher>().Object);

            Assert.That(conn.ConnectionId, Is.Not.Null);
        }

        [Test]
        public void WrapsConnectionString()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupProperty(p => p.ConnectionString, "TEST");

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.ConnectionString, Is.EqualTo("TEST"));
            mockConn.VerifyGet(p => p.ConnectionString, Times.Once);
            conn.ConnectionString = "ABC";
            Assert.That(conn.ConnectionString, Is.EqualTo("ABC"));
            mockConn.VerifySet(p => p.ConnectionString = It.Is<string>(s => s == "ABC"), Times.Once);
        }

        [Test]
        public void WrapsConnectionTimeout()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupGet(p => p.ConnectionTimeout).Returns(30);

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.ConnectionTimeout, Is.EqualTo(30));
            mockConn.VerifyGet(p => p.ConnectionTimeout, Times.Once);
        }
        
        [Test]
        public void WrapsDatabase()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupGet(p => p.Database).Returns("TEST");

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.Database, Is.EqualTo("TEST"));
            mockConn.VerifyGet(p => p.Database, Times.Once);
        }

        [Test]
        public void WrapsState()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupGet(p => p.State).Returns(ConnectionState.Closed);

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.State, Is.EqualTo(ConnectionState.Closed));
            mockConn.VerifyGet(p => p.State, Times.Once);
        }

        [Test]
        public void WrapsCubes()
        {
            var mockConn = new Mock<IAdomdConnection>();

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.Cubes, Is.EqualTo(null));
            mockConn.VerifyGet(p => p.Cubes, Times.Once);
        }

        [Test]
        public void WrapsMiningModels()
        {
            var mockConn = new Mock<IAdomdConnection>();

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.MiningModels, Is.EqualTo(null));
            mockConn.VerifyGet(p => p.MiningModels, Times.Once);
        }

        [Test]
        public void WrapsMiningStructures()
        {
            var mockConn = new Mock<IAdomdConnection>();

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.MiningStructures, Is.EqualTo(null));
            mockConn.VerifyGet(p => p.MiningStructures, Times.Once);
        }

        [Test]
        public void WrapsMiningServices()
        {
            var mockConn = new Mock<IAdomdConnection>();

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.MiningServices, Is.EqualTo(null));
            mockConn.VerifyGet(p => p.MiningServices, Times.Once);
        }

        [Test]
        public void WrapsProviderVersion()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupGet(p => p.ProviderVersion).Returns("12.0");

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.ProviderVersion, Is.EqualTo("12.0"));
            mockConn.VerifyGet(p => p.ProviderVersion, Times.Once);
        }
    
        [Test]
        public void WrapsServerVersion()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupGet(p => p.ServerVersion).Returns("11.0");

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.ServerVersion, Is.EqualTo("11.0"));
            mockConn.VerifyGet(p => p.ServerVersion, Times.Once);
        }

        [Test]
        public void WrapsClientVersion()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupGet(p => p.ClientVersion).Returns("10.0");

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.ClientVersion, Is.EqualTo("10.0"));
            mockConn.VerifyGet(p => p.ClientVersion, Times.Once);
        }

        [Test]
        public void WrapsSessionID()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupGet(p => p.SessionID).Returns("1.0");

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.SessionID, Is.EqualTo("1.0"));
            mockConn.VerifyGet(p => p.SessionID, Times.Once);
        }

        [Test]
        public void WrapsShowHiddenObjects()
        {
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.SetupGet(p => p.ShowHiddenObjects).Returns(true);

            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);
            Assert.That(conn.ShowHiddenObjects, Is.True);
            mockConn.VerifyGet(p => p.ShowHiddenObjects, Times.Once);
        }

        [Test]
        public void WrapsCreateCommand()
        {
            var mockCmd = new Mock<IAdomdCommand>();
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.Setup(p => p.CreateCommand()).Returns(mockCmd.Object);
            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);

            var cmd = conn.CreateCommand();
            Assert.That(cmd, Is.Not.Null);
            Assert.That(cmd, Is.InstanceOf<GlimpseAdomdCommand>());
            GlimpseAdomdCommand command = (GlimpseAdomdCommand) cmd;
            Assert.That(conn, Is.EqualTo(command.Connection));
            Assert.That(conn.ConnectionId, Is.EqualTo(command.ConnectionId));
            mockConn.Verify(p => p.CreateCommand(), Times.Once);
        }

        [Test]
        public void WrapsCreateCommandWithExplicitInterfaceCall()
        {
            var mockCmd = new Mock<IAdomdCommand>();
            var mockConn = new Mock<IAdomdConnection>();
            mockConn.Setup(p => p.CreateCommand()).Returns(mockCmd.Object);
            var conn = new GlimpseAdomdConnection(mockConn.Object, new Mock<ITimedMessagePublisher>().Object);

            var cmd = ((IDbConnection)conn).CreateCommand();
            Assert.That(cmd, Is.Not.Null);
            Assert.That(cmd, Is.InstanceOf<GlimpseAdomdCommand>());
            GlimpseAdomdCommand command = (GlimpseAdomdCommand)cmd;
            Assert.That(conn, Is.EqualTo(command.Connection));
            Assert.That(conn.ConnectionId, Is.EqualTo(command.ConnectionId));
            mockConn.Verify(p => p.CreateCommand(), Times.Once);
        }
    }
}