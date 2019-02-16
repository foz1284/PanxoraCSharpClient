# PanxoraCSharpClient

Basic usage example:

```csharp
PanxoraService panxoraService = new PanxoraService(rootURL, apikey);
Console.WriteLine(JsonConvert.SerializeObject(panxoraService.GetCashBalances()));
```
