![Logo](./docs/media/logo-with-name.png)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Ftomkerkhove%2Fk8s-event-grid-bridge.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Ftomkerkhove%2Fk8s-event-grid-bridge?ref=badge_shield)

[![Artifact HUB](https://img.shields.io/endpoint?url=https://artifacthub.io/badge/repository/k8s-event-grid-bridge)](https://artifacthub.io/packages/search?repo=k8s-event-grid-bridge)

A simple event bridge for Kubernetes native events forwarding [CloudEvents v1.0](https://cloudevents.io/) compliant events to Azure Event Grid into Microsoft Azure.

The bridge is not in charge of acquiring the events from Kubernetes, but you can use tools such as [Opsgenie's Kubernetes Event Exporter](https://github.com/opsgenie/kubernetes-event-exporter) and forward them to the bridge.

# Documentation

Learn more about Kubernetes Event Grid Bridge on [docs.k8s-event-grid-bridge.io](https://docs.k8s-event-grid-bridge.io/) such as :

- Supported events
- Deployment
- ...

## License

This is licensed under The MIT License (MIT). Which means that you can use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the web application. But you always need to state that Tom Kerkhove is the original author of this web application.


[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Ftomkerkhove%2Fk8s-event-grid-bridge.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Ftomkerkhove%2Fk8s-event-grid-bridge?ref=badge_large)