﻿using System.Net.Mime;
using CloudNative.CloudEvents;
using Kubernetes.EventGrid.Core.CloudEvents;
using Kubernetes.EventGrid.Core.Extensions;
using Kubernetes.EventGrid.Core.Kubernetes;
using Kubernetes.EventGrid.Core.Kubernetes.Events;
using Kubernetes.EventGrid.Core.Kubernetes.Events.Interfaces;
using Kubernetes.EventGrid.Tests.Unit.Events;
using Moq;
using Xunit;

namespace Kubernetes.EventGrid.Tests.Unit.CloudEvents
{
    [Trait("Category", "Unit")]
    public class CloudEventFactoryUnitTests
    {
        [Fact]
        public void ParseFromRawNativeEvent_ParseRawEvent_ReturnsRawEvent()
        {
            // Arrange
            var expectedContentType = new ContentType("application/json");
            var expectedSource = "http://kubernetes/";
            var kubernetesEvent = new RawKubernetesEvent();
            var rawKubernetesEvent = KubernetesEventSamples.GetRawContainerStartedEvent();
            var mockedKubernetesEventParser = CreateMockedKubernetesEventParser(kubernetesEvent);
            var cloudEventFactory = new CloudEventFactory(mockedKubernetesEventParser.Object);

            // Act
            var cloudEvent = cloudEventFactory.CreateFromRawKubernetesEvent(rawKubernetesEvent);

            // Assert
            Assert.NotNull(cloudEvent);
            Assert.Equal(kubernetesEvent.Type.GetDescription(), cloudEvent.Type);
            Assert.Equal(kubernetesEvent.Payload, cloudEvent.Data);
            Assert.Equal(expectedContentType, cloudEvent.DataContentType);
            Assert.NotNull(cloudEvent.Source);
            Assert.Equal(expectedSource, cloudEvent.Source.AbsoluteUri);
            Assert.Equal(CloudEventsSpecVersion.V1_0, cloudEvent.SpecVersion);
            mockedKubernetesEventParser.Verify(parser=>parser.ParseFromRawNativeEvent(It.IsAny<string>()), Times.Once);
        }

        private static Mock<KubernetesEventParser> CreateMockedKubernetesEventParser(IKubernetesEvent kubernetesEvent)
        {
            var mockedKubernetesEventParser = new Mock<KubernetesEventParser>();
            mockedKubernetesEventParser.Setup(parser => parser.ParseFromRawNativeEvent(It.IsAny<string>()))
                                       .Returns(kubernetesEvent);

            return mockedKubernetesEventParser;
        }
    }
}