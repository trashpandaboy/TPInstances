# TPInstances

TPInstances is a simple library for managing object instances in Unity. It provides tools for object pooling and service management.

## Installation

To install TPInstances, add the following dependency to your `manifest.json` file in Unity:

```json
{
  "dependencies": {
    "com.trashpandaboy.instances": "1.0.0"
  }
}
```

## Usage

### PoolsManager

The `PoolsManager` class is responsible for managing object pools. Here is an example of how to use it:

```csharp
using com.trashpandaboy.instances.Pooling;
using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    void Start()
    {
        GameObject prefab = ...; // The prefab of the object to pool
        ObjectPool pool = PoolsManager.Instance.GetObjectPool(prefab);
        
        GameObject pooledObject = pool.GetObject();
        pooledObject.SetActive(true);
    }
}
```

### ObjectPool

The `ObjectPool` class manages the pool of objects for a given prefab. You can configure the pool using the `Setup` method:

```csharp
using com.trashpandaboy.instances.Pooling;
using UnityEngine;

public class ExampleUsage : MonoBehaviour
{
    void Start()
    {
        GameObject prefab = ...; // The prefab of the object to pool
        ObjectPool pool = PoolsManager.Instance.GetObjectPool(prefab);
        
        pool.Setup(prefab);
    }
}
```

### Service

The `Service<T>` class is a base class for managing singleton services. Here is an example of how to create a custom service:

```csharp
using com.trashpandaboy.instances;

public class MyService : Service<MyService>
{
    protected override void Awake()
    {
        base.Awake();
        // Service initialization
    }
}
```

### ServiceLocator

The [`ServiceLocator`](command:_github.copilot.openSymbolFromReferences?%5B%22%22%2C%5B%7B%22uri%22%3A%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2FUsers%2Fwilliamsoro%2FSource%2FTPInstances%2FRuntime%2FServiceLocator.cs%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%2C%22pos%22%3A%7B%22line%22%3A13%2C%22character%22%3A17%7D%7D%5D%2C%22da13a357-69e3-42ac-a76a-61fa99ade547%22%5D "Go to definition") class is responsible for providing access to various services in the game. It maintains a dictionary of services and allows for their retrieval by type.

#### Methods

- **Register<T>(T service)**: Registers a service with the [`ServiceLocator`](command:_github.copilot.openSymbolFromReferences?%5B%22%22%2C%5B%7B%22uri%22%3A%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2FUsers%2Fwilliamsoro%2FSource%2FTPInstances%2FRuntime%2FServiceLocator.cs%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%2C%22pos%22%3A%7B%22line%22%3A13%2C%22character%22%3A17%7D%7D%5D%2C%22da13a357-69e3-42ac-a76a-61fa99ade547%22%5D "Go to definition").
  - **T**: The type of the service to register.
  - **service**: The service instance to register.

- **Get<T>()**: Retrieves a service from the [`ServiceLocator`](command:_github.copilot.openSymbolFromReferences?%5B%22%22%2C%5B%7B%22uri%22%3A%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2FUsers%2Fwilliamsoro%2FSource%2FTPInstances%2FRuntime%2FServiceLocator.cs%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%2C%22pos%22%3A%7B%22line%22%3A13%2C%22character%22%3A17%7D%7D%5D%2C%22da13a357-69e3-42ac-a76a-61fa99ade547%22%5D "Go to definition").
  - **T**: The type of the service to retrieve.
  - **Returns**: The service instance if found; otherwise, null.

- **Unregister<T>()**: Unregisters a service from the [`ServiceLocator`](command:_github.copilot.openSymbolFromReferences?%5B%22%22%2C%5B%7B%22uri%22%3A%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2FUsers%2Fwilliamsoro%2FSource%2FTPInstances%2FRuntime%2FServiceLocator.cs%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%2C%22pos%22%3A%7B%22line%22%3A13%2C%22character%22%3A17%7D%7D%5D%2C%22da13a357-69e3-42ac-a76a-61fa99ade547%22%5D "Go to definition").
  - **T**: The type of the service to unregister.

#### Example Usage

```csharp
// Registering a service
ServiceLocator.Register<MyService>(new MyService());

// Retrieving a service
var myService = ServiceLocator.Get<MyService>();

// Unregistering a service
ServiceLocator.Unregister<MyService>();
```


## Contributing

If you want to contribute to TPInstances, feel free to fork the repository and submit a pull request. Any contribution is welcome!

## License

This project is licensed under the Unlicense. For more details, see the `LICENSE` file.

## Author

TPInstances is developed by [TrashPandaBoy](https://github.com/trashpandaboy).
```